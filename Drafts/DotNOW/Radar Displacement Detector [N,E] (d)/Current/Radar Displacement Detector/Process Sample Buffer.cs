using System;
using Microsoft.SPOT;
using Samraksh.AppNote.Samraksh.AppNote.DotNow.Radar.DisplacementAnalysis;

namespace Samraksh.AppNote.DotNow.RadarDisplacementDetector {

    /// <summary>
    /// Displacement detection parameters
    /// </summary>
    public static class DetectorParameters {
        /// <summary>Number of microseconds between samples</summary>
        //public const int SamplingIntervalMicroSec = 4000;    // Larger values => fewer samples/sec
        public const int SamplingIntervalMicroSec = 3096;    // Larger values => fewer samples/sec

        /// <summary>Number of samples to collect before presenting for processing</summary>
        //public const int BufferSize = 500;
        public const int BufferSize = 256;

        /// <summary>Number of samples per second (rounded)</summary>
        public const int SamplesPerSecond = (int)(((float)1000000 / SamplingIntervalMicroSec) + .5);

        /// <summary>Number of microseconds between invocation of buffer processing callback</summary>
        public const int CallbackIntervalMs = (BufferSize * 1000) / SamplesPerSecond;

        /// <summary>Number of minor displacement events that must occur for displacement detection</summary>
        public const int M = 2;

        /// <summary>Number of seconds for which a displacement detection can last</summary>
        public const int N = 8;

        /// <summary>Minimum number of cuts (phase unwraps) that must occur for a minor displacement event</summary>
        //public const int MinCumCuts = 4;
        public const int MinCumCuts = 6;

        /// <summary>The centimeters traversed by one cut. This is a fixed characteristic of the Bumblebee; do not change this value.</summary>
        public const float CutDistanceCm = 5.2f / 2;
    }


    public static partial class RadarDisplacementDetector {

        private static void MofNConfirmationCallback(bool displacing) {
#if Sam_Emulator
            Globals.GpioPorts.MofNConfirmationPort.Write(displacing);
#endif
#if DotNow
            Globals.GpioPorts.DetectEvent.Write(displacing);
#endif
        }

        private static void DisplacementCallback(bool displacing) {
#if Sam_Emulator
            Globals.GpioPorts.DisplacementPort.Write(displacing);
#endif
#if DotNow
            Globals.GpioPorts.DetectEvent.Write(displacing);
#endif
        }

        static int _totalTimeMs;
        /// <summary>
        /// Process the sample buffer in a separate thread
        /// </summary>
        /// <remarks>
        /// We do this so that the ADC callback will return quickly
        /// </remarks>
        private static void ProcessSampleBuffer() {
            // Run forever
            while (true) {
                // Wait for callback to signal that a buffer is ready for processing
                ProcessSampleBufferAutoResetEvent.WaitOne();

                // Set up to calculate speed of processing samples
                var callbackCtr = _callbackCtr; // avoid race condition
                var started = DateTime.Now;
                //Debug.Print("Started  " + started.Minute + ":" + started.Second + "." + started.Millisecond);

                // Process each sample
                for (var i = 0; i < DetectorParameters.BufferSize; i++) {
                    Radar.DisplacementAnalysis.AnalyzeDisplacement.Analyze(Ibuffer[i], Qbuffer[i]);
                }

                // Report on time to process buffer
                var timeSpan = DateTime.Now - started;
                var timeMs = timeSpan.Seconds * 1000 + timeSpan.Milliseconds;
                _totalTimeMs += timeMs;
                //Debug.Print("Callback #" + callbackCtr + ", time " + timeMs + ", mean time " + (_totalTimeMs / callbackCtr) + ", max time allowed " + DetectorParameters.CallbackIntervalMs + "\n");

                // Indicate that we've finished processing the buffer and are ready for the next one
                _currentlyProcessingBuffer = IntBool.False;
            }
        }

    }


}
