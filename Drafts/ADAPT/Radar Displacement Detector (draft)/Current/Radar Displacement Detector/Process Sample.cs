using System;
using Microsoft.SPOT;

namespace Samraksh.AppNote.DotNow.RadarDisplacementDetector {

    /// <summary>
    /// Displacement detection parameters
    /// </summary>
    public struct DetectorParameters {
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

        //static int _totalTimeMs;
        ///// <summary>
        ///// Process the sample buffer in a separate thread
        ///// </summary>
        //private static void ProcessSampleBuffer() {
        //    // Run forever
        //    while (true) {

        //        // Set up to calculate speed of processing samples
        //        var callbackCtr = _callbackCtr; // avoid race condition
        //        var started = DateTime.Now;
        //        Debug.Print("Started  " + started.Minute + ":" + started.Second + "." + started.Millisecond);

        //        // Process each sample
        //        for (var i = 0; i < DetectorParameters.BufferSize; i++) {
        //            SampleData.CurrSample.I = Ibuffer[i];
        //            SampleData.CurrSample.Q = Qbuffer[i];
        //            ProcessSample();
        //        }

        //        Debug.Print("Mean: I " + SampleData.SampleSum.I / SampleData.SampleNumber + ", Q " + SampleData.SampleSum.Q / SampleData.SampleNumber);

        //        // Report on time to process buffer
        //        var timeSpan = DateTime.Now - started;
        //        var timeMs = timeSpan.Seconds * 1000 + timeSpan.Milliseconds;
        //        _totalTimeMs += timeMs;
        //        Debug.Print("Callback #" + callbackCtr + ", time " + timeMs + ", mean time " + (_totalTimeMs / callbackCtr) + ", max time allowed " + DetectorParameters.CallbackIntervalMs + "\n");

        //        // Indicate that we've finished processing the buffer and are ready for the next one
        //        _currentlyProcessingSample = IntBool.False;
        //    }
        //}

        //static bool _waitingForMean = true;
        //private static int _sampNum;
        //static readonly byte[] SampleBytes = new byte[4];
        /// <summary>
        /// Process a sample
        /// </summary>
        private static void ProcessSample() {
            SampleData.SampleSum.I += SampleData.CurrSample.I;
            SampleData.SampleSum.Q += SampleData.CurrSample.Q;

            // Adjust current sample by the mean and check for a cut
            Sample compSample;
            //compSample.I = SampleData.CurrSample.I - sampleMean.I;
            //compSample.Q = SampleData.CurrSample.Q - sampleMean.Q;
            compSample.I = SampleData.CurrSample.I - SampleData.SampleSum.I / SampleData.SampleNumber;
            compSample.Q = SampleData.CurrSample.Q - SampleData.SampleSum.Q / SampleData.SampleNumber;
            CumulativeCuts.Update(compSample);

            // Update snippet counter and see if we've reached a snippet boundary (one second)
            MofNFilter.SnippetCntr++;
            if (MofNFilter.SnippetCntr != SamplingParameters.SamplesPerSecond) {
                return;
            }

            //Debug.Print("Snippet cntr " + MofNFilter.SnippetCntr + ", samples/sec " + DetectorParameters.SamplesPerSecond + ", samp num " + _sampNum);

            // We've collected cumulative cut data for a snippet. See if displacement has occurred
            //  Displacement occurs only if there are more than MinCumCuts in the snippet
            var displacementDetected = (System.Math.Abs(CumulativeCuts.CumCuts) >= DetectorParameters.MinCumCuts);

            // See if we've had displacement in N of the last M snippets
            MofNFilter.UpdateDetectionState(MofNFilter.SnippetNum, displacementDetected);

            // Update snippet info and reset cumulative cuts values
            MofNFilter.SnippetNum++;
            MofNFilter.SnippetCntr = 0;
            CumulativeCuts.Reset();

            // Displacement event started
            if (MofNFilter.Prevstate == DisplacementState.Inactive &&
                MofNFilter.CurrState == DisplacementState.Displacing) {
                GpioPorts.DetectEvent.Write(true);
                Debug.Print("\n-------------------------Detect Event started");
            }

                // Displacement event ended
            else if (MofNFilter.Prevstate == DisplacementState.Displacing &&
                     MofNFilter.CurrState == DisplacementState.Inactive) {
                GpioPorts.DetectEvent.Write(false);
                Debug.Print("\n-------------------------Detect Event ended");
            }
        }

        /// <summary>
        /// Calculate cumulative cuts
        /// </summary>
        /// <remarks>One cut = 5.2 cm distance</remarks>
        public static class CumulativeCuts {
            private static Sample _prevSample;
            /// <summary>Cumulative cuts</summary>
            public static int CumCuts;

            /// <summary>
            /// Constructor: Initialize previous values
            /// </summary>
            public static void Initialize() {
                _prevSample.I = _prevSample.Q = 0;
            }

            /// <summary>
            /// Reset the cumulative cuts
            /// </summary>
            public static void Reset() {
                CumCuts = 0;
            }

            /// <summary>
            /// Increment or decrement the cumulative cuts based on previous and current sample
            /// </summary>
            /// <param name="currSample"></param>
            public static void Update(Sample currSample) {
                var direction = _prevSample.I * currSample.Q - currSample.I * _prevSample.Q;

                //Debug.Print("# " + direction + "; (" + currSample.Q + "," + _prevSample.Q + "); (" + currSample.I + "," + _prevSample.I + ")");

                if (direction < 0 && _prevSample.Q < 0 && currSample.Q > 0) {
                    CumCuts += 1;
                    //Debug.Print("\n+= " + CumCuts + "\n");
                }
                else if (direction > 0 && _prevSample.Q > 0 && currSample.Q < 0) {
                    CumCuts -= 1;
                    //Debug.Print("\n-= " + CumCuts + "\n");
                }

                _prevSample.I = currSample.I;
                _prevSample.Q = currSample.Q;
            }
        }

        /// <summary>
        /// Check if, in the last N seconds, there were M seconds in which displacement occurred
        /// </summary>
        /// <remarks>
        /// Buff is a circular buffer of size M. 
        ///     It is initialized to values guaranteed to be sufficiently distant in the past so as to not trigger a detection event.
        /// UpdateDetectionState is called once per snippet (once per second). 
        ///     It checks to see if the current buffer value is sufficiently recent or not and sets the detection state accordingly.
        /// If displacement occurred during this snippet, 
        ///     then the snippet number is saved and the buffer pointer advances.
        /// When we do a comparison in UpdateDetectionState, the current buffer entry is the oldest snippet where displacement occurred.
        ///     Since all the other snippets are more recent, it suffices to see if the current one occurred within N snippets.
        /// </remarks>
        public static class MofNFilter {
            /// <summary>Counts samples to see when a snippet (one second) has been reached</summary>
            public static int SnippetCntr = 0;
            /// <summary>Snippet Number. Incremented once per second.</summary>
            public static int SnippetNum = 0;

            private const int M = DetectorParameters.M;  // Syntactic sugar
            private const int N = DetectorParameters.N;

            private static readonly int[] Buff = new int[M];
            private static int _currBuffPtr;

            /// <summary>Current state</summary>
            public static DisplacementState CurrState = DisplacementState.Inactive;

            /// <summary>Previous state</summary>
            public static DisplacementState Prevstate = DisplacementState.Inactive;

            /// <summary>
            /// Initialize M of N filter
            /// </summary>
            public static void Initialize() {
                for (var i = 0; i < Buff.Length; i++)
                    Buff[i] = -N;   // Any value less than -N will do
            }

            /// <summary>
            /// Determine whether we are detecting motion or not
            /// </summary>
            /// <param name="snippetNumber">Snippet Number</param>
            /// <param name="displacement">true iff displacement detection has occurred</param>
            public static void UpdateDetectionState(int snippetNumber, bool displacement) {

                //if (Prevstate != CurrState) { Debug.Print("States " + Prevstate + CurrState); }

                // Save the current state so we can check if there's been a change
                Prevstate = CurrState;

                // Check if the snippet number occurred sufficiently recently
                CurrState = (snippetNumber - Buff[_currBuffPtr] < N) ? DisplacementState.Displacing : DisplacementState.Inactive;

                //Debug.Print("MofN: curr snippet " + snippetNumber + ", curr buff val " + Buff[_currBuffPtr] + ", disp state " + CurrState);

                // If displacement occurred, record the current snippet number and advance the current buffer location
                if (!displacement) {
                    return;
                }
                Debug.Print("** displacement cuts " + CumulativeCuts.CumCuts + ", distance " + (CumulativeCuts.CumCuts * DetectorParameters.CutDistanceCm));
                Buff[_currBuffPtr] = snippetNumber;
                _currBuffPtr = (_currBuffPtr + 1) % M;
            }
        }

    }
}
