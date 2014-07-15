using System;
using Microsoft.SPOT;

namespace Samraksh.AppNote.DotNow.Radar.DisplacementAnalysis {
    public static partial class AnalyzeDisplacement {

        /// <summary>
        /// Method to call to signal major detection
        /// </summary>
        /// <param name="displacing">true iff displacing</param>
        public delegate void DetectDisplacementCallback(bool displacing);

        private static class DetectorParameters {
            /// <summary>Number of milliseconds between samples</summary>
            public static int SamplingIntervalMilliSec = 4000;    // Larger values => fewer samples/sec

            /// <summary>Number of samples per second</summary>
            public static readonly int SamplesPerSecond = 1000000 / SamplingIntervalMilliSec;

            /// <summary>Number of minor displacement events that must occur for displacement detection</summary>
            public static int M = 2;

            /// <summary>Number of seconds for which a displacement detection can last</summary>
            public static int N = 8;

            /// <summary>Minimum number of cuts (phase unwraps) that must occur for a minor displacement event</summary>
            public static int MinCumCuts = 6;

            /// <summary>The centimeters traversed by one cut. This is a fixed characteristic of the Bumblebee; do not change this value.</summary>
            public const float CutDistanceCm = 5.2f / 2;
        }

        private static DetectDisplacementCallback _detectDisplacementCallback;

        /// <summary>
        /// Initialize displacement analysis
        /// </summary>
        /// <param name="samplingIntervalMilliSec">Number of milliseconds between samples</param>
        /// <param name="m">Minimum number of snippets having displacement to detect major displacement</param>
        /// <param name="n">Size of window snippet to check for minimum</param>
        /// <param name="minCumCuts">Minimum number of cumulative cuts for snippet displacement</param>
        /// <param name="detectDisplacementCallback">Method to call to signal major detection start/stop</param>
        public static void Initialize(int samplingIntervalMilliSec, int m, int n, int minCumCuts, DetectDisplacementCallback detectDisplacementCallback) {
            DetectorParameters.SamplingIntervalMilliSec = samplingIntervalMilliSec;
            DetectorParameters.M = m;
            DetectorParameters.N = n;
            DetectorParameters.MinCumCuts = minCumCuts;
            _detectDisplacementCallback = detectDisplacementCallback;
            CumulativeCuts.Initialize();
            MofNFilter.Initialize();
        }

        /// <summary>
        /// Analyze a sample for displacement
        /// </summary>
        /// <remarks>
        /// Samples are partitioned into snippets; currently 1 second.
        /// Displacement occurs if the abs(sum of cuts) in a snippet exceeds a maximum such as 6. 
        ///     The assumption is that a fixed object such as a tree will not exhibit this much net displacement.
        /// To further confirm displacement (reduce false positives), look for at least M displacements in N seconds.
        /// For N of M, note that we do not care if the target alternately moves forward and backward the required distance.
        /// </remarks>
        public static void Analyze(int iValue, int qValue) {
            SampleData.SampleCounter++;

            SampleData.SampleSum.I += iValue;
            SampleData.SampleSum.Q += qValue;

            // Adjust current sample by the mean and check for a cut
            SampleData.CompSample.I = iValue - (SampleData.SampleSum.I / SampleData.SampleCounter);
            SampleData.CompSample.Q = qValue - (SampleData.SampleSum.Q / SampleData.SampleCounter);
            CumulativeCuts.Update(SampleData.CompSample);

            // Update snippet counter and see if we've reached a snippet boundary (one second)
            CumulativeCuts.SnippetCntr++;
            if (CumulativeCuts.SnippetCntr != DetectorParameters.SamplesPerSecond) {
                return;
            }

            //Debug.Print("Snippet cntr " + MofNFilter.SnippetCntr + ", samples/sec " + DetectorParameters.SamplesPerSecond + ", samp num " + _sampNum);

            // We've collected cumulative cut data for a snippet. See if snippet displacement has occurred
            //  Displacement occurs only if there are more than MinCumCuts in the snippet
            var displacementDetected = (System.Math.Abs(CumulativeCuts.CumCuts) >= DetectorParameters.MinCumCuts);

            // See if we've had displacement in N of the last M snippets
            MofNFilter.UpdateDetectionState(CumulativeCuts.SnippetNum, displacementDetected);

            // Update snippet info and reset cumulative cuts values
            CumulativeCuts.SnippetNum++;
            CumulativeCuts.Reset();

            // Displacement event started
            if (MofNFilter.PrevState == DisplacementState.Inactive && MofNFilter.CurrState == DisplacementState.Displacing) {
                _detectDisplacementCallback(true);
                Debug.Print("\n-------------------------Detect Event started");
            }

            // Displacement event ended
            else if (MofNFilter.PrevState == DisplacementState.Displacing &&
                     MofNFilter.CurrState == DisplacementState.Inactive) {
                _detectDisplacementCallback(false);
                Debug.Print("\n-------------------------Detect Event ended");
            }
        }

        /// <summary>
        /// Calculate cumulative cuts
        /// </summary>
        /// <remarks>One cut = 5.2 cm distance</remarks>
        private static class CumulativeCuts {
            private static readonly Sample PrevSample = new Sample();

            /// <summary>Cumulative cuts</summary>
            public static int CumCuts;

            /// <summary>Counts samples to see when a snippet (one second) has been reached</summary>
            public static int SnippetCntr = 0;

            /// <summary>Snippet Number. Incremented once per second.</summary>
            public static int SnippetNum = 0;

            /// <summary>
            /// Constructor: Initialize previous values
            /// </summary>
            public static void Initialize() {
                PrevSample.I = PrevSample.Q = 0;
                Reset();
            }

            /// <summary>
            /// Reset the cumulative cuts
            /// </summary>
            public static void Reset() {
                CumCuts = 0;
                SnippetCntr = 0;
            }

            /// <summary>
            /// Increment or decrement the cumulative cuts based on previous and current sample
            /// </summary>
            /// <param name="currSample"></param>
            public static void Update(Sample currSample) {
                if (PrevSample.I == 0) {
                    var direction = PrevSample.I * currSample.Q - currSample.I * PrevSample.Q;

                    //Debug.Print("# " + direction + "; (" + currSample.Q + "," + _prevSample.Q + "); (" + currSample.I + "," + _prevSample.I + ")");

                    if (direction < 0 && PrevSample.Q < 0 && currSample.Q > 0) {
                        CumCuts += 1;
                        //Debug.Print("\n+= " + CumCuts + "\n");
                    }
                    else if (direction > 0 && PrevSample.Q > 0 && currSample.Q < 0) {
                        CumCuts -= 1;
                        //Debug.Print("\n-= " + CumCuts + "\n");
                    }
                }

                PrevSample.I = currSample.I;
                PrevSample.Q = currSample.Q;
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

            private static readonly int M = DetectorParameters.M; // Syntactic sugar
            private static readonly int N = DetectorParameters.N;

            private static readonly int[] Buff = new int[M];
            private static int _currBuffPtr;

            public static DisplacementState CurrState = DisplacementState.Inactive;

            public static DisplacementState PrevState = DisplacementState.Inactive;

            /// <summary>
            /// Initialize M of N filter
            /// </summary>
            public static void Initialize() {
                for (var i = 0; i < Buff.Length; i++)
                    Buff[i] = -N; // Any value less than -N will do
            }

            /// <summary>
            /// Determine whether we are detecting motion or not
            /// </summary>
            /// <param name="snippetNumber">Snippet Number</param>
            /// <param name="displacement">true iff displacement detection has occurred</param>
            public static void UpdateDetectionState(int snippetNumber, bool displacement) {

                //if (PrevState != CurrState) { Debug.Print("States " + PrevState + CurrState); }

                // Save the current state so we can check if there's been a change
                PrevState = CurrState;

                // Check if the snippet number occurred sufficiently recently
                CurrState = (snippetNumber - Buff[_currBuffPtr] < N)
                    ? DisplacementState.Displacing
                    : DisplacementState.Inactive;

                //Debug.Print("MofN: curr snippet " + snippetNumber + ", curr buff val " + Buff[_currBuffPtr] + ", disp state " + CurrState);

                // If displacement occurred, record the current snippet number and advance the current buffer location
                if (!displacement) {
                    return;
                }
                Debug.Print("** displacement cuts " + CumulativeCuts.CumCuts + ", distance " +
                            (CumulativeCuts.CumCuts * DetectorParameters.CutDistanceCm));
                Buff[_currBuffPtr] = snippetNumber;
                _currBuffPtr = (_currBuffPtr + 1) % M;
            }
        }


    }

}
