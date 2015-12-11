using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using Samraksh.eMote.DotNow;

namespace Samraksh.AppNote.DataCollector.Radar {
    public partial class Program {

        // ---------------------------------------------
        // Handle ADC callback and write sample buffers
        // ---------------------------------------------

        /// <summary>
        /// I-Q buffer pair
        /// </summary>
        /// <remarks>Lets a pair of buffers be handled together as a single object</remarks>
        private class IQPair {
            // ReSharper disable once InconsistentNaming
            public readonly ushort[] IBuff;
            public readonly ushort[] QBuff;
            public IQPair(ushort[] iBuff, ushort[] qBuff) {
                IBuff = iBuff;
                QBuff = qBuff;
            }
        }

        // A semaphore used by the ADC callback to signal WriteSampleBufferQueue that data is ready for processing
        private static readonly AutoResetEvent SampleBufferSemaphore = new AutoResetEvent(false);

        // The ADC buffers that are populated by the ADC driver
        private static readonly ushort[] ADCBufferI = new ushort[ADCBufferSize];
        private static readonly ushort[] ADCBufferQ = new ushort[ADCBufferSize];

        // The buffer queue and it's maximum length
        private static readonly Queue BufferQueue = new Queue();
        private const int MaxBufferQueueLen = 3;

        // A circular array of pre-allocated buffers that receive the contents of the ADC buffers
        private static readonly ArrayList ADCCopyBuffers = new ArrayList();
        private const int ADCCopyBuffersCnt = MaxBufferQueueLen;
        private static int _adcCopyBuffersPtr;

        // Misc definitions
        private static int _channelBuffersProcessedCtr;

        /// <summary>
        /// Populate the circular queue of ADC buffers
        /// </summary>
        /// <remarks>
        /// Since the buffers are pre-allocated and the references are stored in a static object,
        ///     they won't be de-referenced over the lifetime of the program.
        /// This ensures that allocating and de-referencing buffers won't cause the garbage collector to run
        /// </remarks>
        private static void SetupADCBuffers() {
            for (var i = 0; i < ADCCopyBuffersCnt; i++) {
                var iBuff = new ushort[ADCBufferSize];
                var qBuff = new ushort[ADCBufferSize];
                var iqBuff = new IQPair(iBuff, qBuff);
                ADCCopyBuffers.Add(iqBuff);
            }
            _adcCopyBuffersPtr = 0;
        }

        /// <summary>
        /// ADC callback
        /// </summary>
        /// <remarks>Called when the ADC driver has collected a buffer's worth of data</remarks>
        /// <param name="threshhold"></param>
        private static void ADCCallback(long threshhold) {
            // Track the number of queues used
            //  Note that BufferQueue.Count can become smaller after this statement
            //      if WriteSampleBufferQueue dequeues a buffer but it cannot become larger
            var bqCnt = BufferQueue.Count;
            _maxBuffersEnqueued = System.Math.Max(_maxBuffersEnqueued, bqCnt + 1);  // Add 1 because we're about to enqueue

            // If queue is full, we can't add another entry
            //  Exit with the _bufferQueueIsFull and _collectIsDone flags set
            if (!_bufferQueueIsFull && bqCnt > MaxBufferQueueLen - 1) {
                _bufferQueueIsFull = true;
                _collectIsDone = true;
                AnalogInput.StopSampling();
                return;
            }

            // There's space in the queue: copy the buffers and enqueue them
            //      We need to copy to avoid a race condition. 
            //      Whenever ADC is ready to call back, the new set of samples is stored in the specified buffer.
            //      Hence if we're processing one buffer when the next callback occurs, the values in the current buffer can change.

            // Get an I-Q buffer pair that will receive the ADC buffer data
            //  Note that we're using pre-allocated buffers rather than creating new
            //  This protects against the garbage collector
            var iq = (IQPair)ADCCopyBuffers[_adcCopyBuffersPtr];
            // Copy to the pair
            ADCBufferI.CopyTo(iq.IBuff, 0);
            ADCBufferQ.CopyTo(iq.QBuff, 0);
            // Update the circular buffer pointer
            _adcCopyBuffersPtr = (_adcCopyBuffersPtr + 1) % ADCCopyBuffersCnt;

            // Enqueue the pair for processing
            BufferQueue.Enqueue(iq);
            // Signal the processing thread
            SampleBufferSemaphore.Set();
        }

        /// <summary>
        /// Process the sample buffer in a separate thread
        /// </summary>
        /// <remarks>
        /// We do this so that the ADC callback will return quickly.
        /// The main program blocks until this thread ends
        /// </remarks>
        private static void WriteSampleBufferQueue() {
            // Run until user indicates end or there is a queue-full error
            while (true) {
                // Wait for signal that a buffer is ready for processing
                SampleBufferSemaphore.WaitOne();
                // Process as many buffers as are available
                while (BufferQueue.Count > 0) {
                    // Get a buffer to process
                    var iq = (IQPair)BufferQueue.Dequeue();
                    WriteSampleBuffers(iq);
                }
                // Check if the end-sampling flag is set. If so, we're done
                if (!_collectIsDone) {
                    continue;
                }
                // Let the user know right away that we're finished sampling
                //  The flush can take a while ...
                EnhancedLcd.Write(LCDMessages.FinishSampling);
                Debug.Print("Finished sampling");
                AnalogInput.StopSampling();
                LargeDataRef.Flush(256, 0);
                // Terminate the thread and join with the main program
                return;
            }
        }

        /// <summary>
        /// Process an I-Q pair of buffers
        /// </summary>
        /// <param name="iq">The I-Q pair</param>
        /// <returns>True iff we're done sampling</returns>
        private static void WriteSampleBuffers(IQPair iq) {
            // Pull the members out. Referencing this way seems to be more efficient.
            var iBuff = iq.IBuff;
            var qBuff = iq.QBuff;

            // Write buffers to DataStore
            // Copy to IQ Buffer
            var iqBuffer = new ushort[ADCBufferSize * 2];
            for (var i = 0; i < ADCBufferSize; i++) {
                var offset = i << 1; // i * 2
                iqBuffer[offset] = iBuff[i];
                iqBuffer[offset + 1] = qBuff[i];
            }
            LargeDataRef.Write(iqBuffer);

            // If not debugging, don't print
            //  Avoids impact on heap and possible garbage collection
            //  Also, is more efficient
            if (!_debuggerIsAttached) { return; }
            // Print first and last values of each half of IBuff and QBuff buffers
            //      This will correspond to the first and last values when CopyToSD reads in a ADCBufferSize at a time
            for (var i = 0; i < ADCBufferSize; i += ADCBufferSize / 2) {
                var last = (ADCBufferSize / 2) + i - 1;
                Debug.Print(_channelBuffersProcessedCtr++ + " I: " + iBuff[i] + ", Q: " + qBuff[i]
                            + " / I: " + iBuff[last] + ", Q: " + qBuff[last]);
            }
        }
    }
}
