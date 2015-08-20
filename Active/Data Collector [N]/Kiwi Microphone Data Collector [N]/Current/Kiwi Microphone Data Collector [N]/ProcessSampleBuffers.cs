using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;

namespace Samraksh.AppNote.DataCollector.Mic {
	/// <summary>
	/// Main program
	/// </summary>
	public partial class Program {

		// ---------------------------------------------
		// Handle ADC callback and write sample buffers
		// ---------------------------------------------

		// A semaphore used by the ADC callback to signal WriteSampleBufferQueue that data is ready for processing
		private static readonly AutoResetEvent SampleBufferSemaphore = new AutoResetEvent(false);

		// The ADC buffers that are populated by the ADC driver
		private static readonly ushort[] ADCBuffer = new ushort[ADCBufferSize];

		// The buffer queue and it's maximum length
		private static readonly Queue BufferQueue = new Queue();
		private const int MaxBufferQueueLen = 3;

		// A circular array of pre-allocated buffers that receive the contents of the ADC buffers
		private static readonly ArrayList ADCCopyBuffers = new ArrayList();
		private const int ADCCopyBuffersCnt = MaxBufferQueueLen;
		private static int _adcCopyBuffersPtr;

		// Misc definitions
		private static int _buffersProcessedCtr;

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
				var buffer = new ushort[ADCBufferSize];
				ADCCopyBuffers.Add(buffer);
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
			//  Note that BufferQueue.Count can become smaller after this statement if WriteSampleBufferQueue dequeues a buffer
			//      but it cannot become larger
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

			// Get a buffer that will receive the ADC buffer data
			//  Note that we're using pre-allocated buffers rather than creating new
			//  This protects against the garbage collector
			var buffer = (ushort[])ADCCopyBuffers[_adcCopyBuffersPtr];
			// Copy to the pair
			ADCBuffer.CopyTo(buffer, 0);
			// Update the circular buffer pointer
			_adcCopyBuffersPtr = (_adcCopyBuffersPtr + 1) % ADCCopyBuffersCnt;

			// Enqueue the buffer for processing
			BufferQueue.Enqueue(buffer);
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
				//_buffCtr++;
				//Debug.Print("Buffer " + _buffCtr);
				//Globals.EnhancedLcd.Write(_buffCtr);
				_buffersProcessedCtr++;
				Debug.Print("Buffer " + _buffersProcessedCtr);
				Globals.EnhancedLcd.Write(_buffersProcessedCtr);
				// Process as many buffers as are available
				while (BufferQueue.Count > 0) {
					// Get a buffer to process
					var buffer = (ushort[])BufferQueue.Dequeue();
					WriteSampleBuffer(buffer);
				}
				// Check if the end-sampling flag is set. If so, we're done
				if (!_collectIsDone) {
					continue;
				}
				// Let the user know right away that we're finished sampling
				//  The flush can take a while ...
				Globals.EnhancedLcd.Write(LCDMessages.FinishSampling);
				Debug.Print("Finished sampling");
				AnalogInput.StopSampling();
				LargeDataRef.Flush(256, 0);
				// Terminate the thread and join with the main program
				return;
			}
		}
		//static private int _buffCtr;

		/// <summary>
		/// Process a buffer
		/// </summary>
		/// <param name="buffer">The buffer</param>
		/// <returns>True iff we're done sampling</returns>
		private static void WriteSampleBuffer(ushort[] buffer) {
			// Write buffers to DataStore
			LargeDataRef.Write(buffer);

			// If not debugging, don't print
			//  Avoids impact on cpu time as well as heap and possible garbage collection
			if (_debuggerIsAttached) {
				// Print first and last values the buffer
				Debug.Print(_buffersProcessedCtr++ + " " + buffer[0] + " / " + buffer[ADCBufferSize - 1] + ", buffers " + _maxBuffersEnqueued);
			}
		}
	}
}
