using Microsoft.SPOT;
using Samraksh.AppNote.DotNow.Radar.DisplacementAnalysis;
using Samraksh.AppNote.Samraksh.AppNote.DotNow.Radar;

namespace Samraksh.AppNote.DotNow.RadarDisplacementDetector {

	

	public static partial class RadarDisplacementDetector {

		private static void MofNConfirmationCallback(bool conf) {
#if Sam_Emulator
            Globals.GpioPorts.MofNConfirmationPort.Write(displacing);
#endif
#if DotNow
			Globals.GpioPorts.DetectConf.Write(conf);
#endif
		}

		private static void DisplacementCallback(bool displacing) {
#if Sam_Emulator
            Globals.GpioPorts.DisplacementPort.Write(displacing);
#endif
#if DotNow
			Globals.GpioPorts.DetectDisplacement.Write(displacing);
#endif
		}

		//static int _totalTimeMs;
		/// <summary>
		/// Process the sample buffer in a separate thread
		/// </summary>
		/// <remarks>
		/// We do this so that the ADC callback will return quickly
		/// </remarks>
		private static void ProcessSampleBuffer() {
			// Run forever
			while (true) {
				while (true) {
					// Wait for callback to signal that a buffer is ready for processing
					var processSampleBufferFlag = ProcessSampleBufferAutoResetEvent.WaitOne(DetectorParameters.CallbackIntervalMicroSec + DetectorParameters.CallbackIntervalMicroSec / 10, false);
					if (Globals.LoggingFinished) {
						return;
					}
					if (processSampleBufferFlag) {
						break;
					}
				}

				// Set up to calculate speed of processing samples
				//var callbackCtr = _callbackCtr; // avoid race condition
				//var started = DateTime.Now;
				//Debug.Print("Started  " + started.Minute + ":" + started.Second + "." + started.Millisecond);

				if (!OutputItems.SnippetDispAndConf.Opt.Print) {
					Debug.Print("# " + (AnalyzeDisplacement.SampleData.SampleNum + 1));
				}

				// Process each sample
				for (var i = 0; i < DetectorParameters.BufferSize; i++) {

					AnalyzeDisplacement.Analyze(new Globals.Sample(Ibuffer[i], Qbuffer[i]));
				}

				// Report on time to process buffer
				//var timeSpan = DateTime.Now - started;
				//var timeMs = timeSpan.Seconds * 1000 + timeSpan.Milliseconds;
				//_totalTimeMs += timeMs;
				//Debug.Print("Callback #" + callbackCtr + ", time " + timeMs + ", mean time " + (_totalTimeMs / callbackCtr) + ", max time allowed " + DetectorParameters.CallbackIntervalMicroSec + "\n");

				// Indicate that we've finished processing the buffer and are ready for the next one
				_currentlyProcessingBuffer = IntBool.False;
			}
		}
	}


}
