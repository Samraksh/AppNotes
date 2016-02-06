using Microsoft.SPOT;
using Samraksh.AppNote.DotNow.RadarDisplacement.Detector.Globals;
using AnalyzeDisplacement = Samraksh.AppNote.DotNow.RadarDisplacement.Analysis.AnalyzeDisplacement;

namespace Samraksh.AppNote.DotNow.RadarDisplacement.Detector {

	

	public static partial class RadarDisplacementDetector {

		private static void MofNConfirmationCallback(bool conf) {
#if Sam_Emulator
            GlobalItems.GpioPorts.SamrakshEmulator.DetectConf.Write(displacing);
#endif
			GlobalItems.GpioPorts.DotNow.DetectConf.Write(conf);
		}

		private static void DisplacementCallback(bool displacing) {
#if Sam_Emulator
            GlobalItems.GpioPorts.SamrakshEmulator.DetectDisplacement.Write(displacing);
#endif
			GlobalItems.GpioPorts.DotNow.DetectDisplacement.Write(displacing);
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
					if (GlobalItems.LoggingFinished)
					{
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

				if (OutputItems.SnippetDispAndConf.OutOpt.SampleAndPrint>0) {
					Debug.Print("# " + (AnalyzeDisplacement.SampleData.SampleNum + 1));
				}

				// Process each sample
				for (var i = 0; i < DetectorParameters.BufferSize; i++) {

					AnalyzeDisplacement.Analyze(new GlobalItems.Sample(Ibuffer[i], Qbuffer[i]));
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
