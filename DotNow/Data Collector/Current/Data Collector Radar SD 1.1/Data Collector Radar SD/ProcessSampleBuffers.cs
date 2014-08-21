using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using AnalogInput = Samraksh.eMote.DotNow.AnalogInput;

namespace Samraksh.Library.DataCollector.Radar {
    public partial class Program {

        //private static class IntBool { public const int True = 1; public const int False = 0;}
        //private static int _currentlyProcessingADCBuffers = IntBool.False;
        private static readonly AutoResetEvent SampleBufferSemaphore = new AutoResetEvent(false);

        private static int _halfBuffersProcessedCtr;

        private static readonly Queue BufferQueue = new Queue();
        private const int MaxBufferQueueLen = 3;

        private static readonly ushort[] ADCBufferI = new ushort[BufferSize];
        private static readonly ushort[] ADCBufferQ = new ushort[BufferSize];

        private static readonly ArrayList ADCCopyBuffers = new ArrayList();
        private const int ADCCopyBuffersCnt = MaxBufferQueueLen;
        private static int _adcCopyBuffersPtr;

        private class IQPair {
            // ReSharper disable once InconsistentNaming
            public readonly ushort[] IBuff;
            public readonly ushort[] QBuff;
            public IQPair(ushort[] iBuff, ushort[] qBuff) {
                IBuff = iBuff;
                QBuff = qBuff;
            }
        }

        private static void SetupADCBuffers() {
            for (var i = 0; i < ADCCopyBuffersCnt; i++) {
                var iBuff = new ushort[BufferSize];
                var qBuff = new ushort[BufferSize];
                var iqBuff = new IQPair(iBuff, qBuff);
                ADCCopyBuffers.Add(iqBuff);
            }
            _adcCopyBuffersPtr = 0;
        }

        private static void ADCCallback(long threshhold) {
            // Track the number of queues used
            //  Note that BufferQueue.Count can become smaller after this statement
            //      if ProcessSampleBufferQueue dequeues a buffer but it cannot become larger
            var bqCnt = BufferQueue.Count;
            _maxBuffersEnqueued = System.Math.Max(_maxBuffersEnqueued, bqCnt + 1);  // Add 1 because we're about to enqueue

            // If not enuf space, notify
            if (!_bufferQueueIsFull && bqCnt > MaxBufferQueueLen - 1) {
                _bufferQueueIsFull = true;
                SampleBufferSemaphore.Set();
                return;
            }

            // There's space in the queue: copy the buffers and enqueue them
            //      We need to copy to avoid a race condition. 
            //      Whenever ADC is ready to call back, the new set of samples is stored in the specified buffer.
            //      Hence if we're processing one buffer when the next callback occurs, the values in the current buffer can change.

            // Get an I-Q buffer pair
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

            //_halfBuffersProcessedCtr++;

            //// Check if we're currently processing a buffer. If so, give message and return
            ////      The variable _currentlyProcessingADCBuffers is reset in ProcessSampleBufferQueue.
            //if (Interlocked.CompareExchange(ref _currentlyProcessingADCBuffers, IntBool.True, IntBool.False) ==
            //    IntBool.True) {
            //    Debug.Print(
            //        "***************************************************************** Missed a buffer; callback #" +
            //        _halfBuffersProcessedCtr);
            //    EnhancedLcd.Display(LCDMessages.BufferQueueFull);
            //    _bufferQueueIsFull = true;
            //    return;

            //}
            //// Freeze the value to avoid a race condition. 
            ////      ProcessSampleBufferQueue could be processing when next callback occurs.
            ////      Note that this is opportunistic nondeterminism: we hope that the assignment will be made before the next callback.
            ////      To do it right, we would use a lock(); but this is very time consuming and can itself cause missed buffers
            //_callbackCtrFreeze = _halfBuffersProcessedCtr;
            ////Not currently processing a buffer. Signal processing and return.
            //SampleBufferSemaphore.Set();
        }

        /// <summary>
        /// Process the sample buffer in a separate thread
        /// </summary>
        /// <remarks>
        /// We do this so that the ADC callback will return quickly
        /// </remarks>
        private static void ProcessSampleBufferQueue() {
            // Run until user indicates end or there is a queue-full error
            while (true) {
                // Wait for signal that a buffer is ready for processing
                SampleBufferSemaphore.WaitOne();

                // Process as many buffers as are available
                while (BufferQueue.Count > 0) {

                    // Check if queue is full
                    if (_bufferQueueIsFull) {
                        AnalogInput.StopSampling();
                        return;
                    }

                    // Get a buffer to process
                    var iq = (IQPair)BufferQueue.Dequeue();
                    if (ProcessSampleBuffers(iq)) { return; }
                }
            }
        }

        /// <summary>
        /// Process an I-Q pair of buffers
        /// </summary>
        /// <param name="iq">The I-Q pair</param>
        /// <returns>True iff we're done sampling</returns>
        private static bool ProcessSampleBuffers(IQPair iq) {
            // Pull the members out. Referencing this way seems to be more efficient.
            var iBuff = iq.IBuff;
            var qBuff = iq.QBuff;

            // Write buffers to DataStore
            // Copy to IQ Buffer
            var iqBuffer = new ushort[BufferSize * 2];
            for (var i = 0; i < BufferSize; i++) {
                var offset = i << 1; // i * 2
                iqBuffer[offset] = iBuff[i];
                iqBuffer[offset + 1] = qBuff[i];
            }
            LargeDataRef.Write(iqBuffer);

            // Print first and last values of each half of IBuff and QBuff buffers
            //      This will correspond to the first and last values when CopyToSD reads in a BufferSize at a time
            for (var i = 0; i < BufferSize; i += BufferSize / 2) {
                var last = (BufferSize / 2) + i - 1;
                Debug.Print(_halfBuffersProcessedCtr++ + " I: " + iBuff[i] + ", Q: " + qBuff[i]
                            + " / I: " + iBuff[last] + ", Q: " + qBuff[last]);
            }

            // Check if the end-sampling flag is set. If so, we're done
            if (!_endCollectFlag) { return false; }

            EnhancedLcd.Display(LCDMessages.FinishSampling);
            Debug.Print("Finished sampling");
            AnalogInput.StopSampling();
            LargeDataRef.Flush(256, 0);
            return true;
        }
    }
}
