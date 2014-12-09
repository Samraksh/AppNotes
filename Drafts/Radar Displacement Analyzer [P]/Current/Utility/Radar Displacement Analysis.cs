/*=========================
 * Radar Displacement Analysis Class
 *  Do displacement analysis on radar sample data
 * Versions
 *  1.0 Initial Version
 * Notes
 *  Static class. Use Initialize method first.
 =========================*/

#if MF
using System;
using Microsoft.SPOT;
#endif

#if PC
using System.Diagnostics;
#endif

namespace Samraksh.AppNote.Utility {
    namespace Radar.DisplacementAnalysis {
        public static class DisplacementAnalysis {

            /// <summary>
            /// Method signature for call-back to signal displacement
            /// </summary>
            /// <param name="displacing">true iff displacing</param>
            public delegate void EventCallback(bool displacing, long snippetNumber);

            private static class ClassParameters {
                /// <summary>Number of samples per snippet</summary>
                public static int SamplesPerSnippet;

                /// <summary>Number of minor displacement events that must occur for displacement detection</summary>
                public static int M;

                /// <summary>Number of seconds for which a displacement detection can last</summary>
                public static int N;

                /// <summary>Minimum number of cuts (phase unwraps) that must occur for a minor displacement event</summary>
                public static int MinCumCuts;

                /// <summary>The centimeters traversed by one cut. This is a fixed characteristic of the Bumblebee; do not change this value.</summary>
                public const float CutDistanceCm = 5.2f / 2;

                /// <summary>Method to call when M of N confirms displacement</summary>
                public static EventCallback MofNConfirmationCallback;

                /// <summary>Method to call when M of N confirms displacement</summary>
                public static EventCallback DisplacementCallback;
            }

            /// <summary>Remember last displacement detection</summary>
            private static bool _lastDisplacementDetected;

            /// <summary>Remember last M of N confirmation</summary>
            private static bool _lastMofNconfirmation;

            /// <summary>True causes diagnostic Debug.Print</summary>
            private static bool _diagnosticPrint;


            /// <summary>
            /// Initialize displacement analysis
            /// </summary>
            /// <param name="samplesPerSnippet">Samples per snippet (for 1 second snippets, give samples per second)</param>
            /// <param name="m">Minimum number of snippets having displacement to detect major displacement</param>
            /// <param name="n">Size of window snippet to check for minimum</param>
            /// <param name="minCumCuts">Minimum number of cumulative cuts for snippet displacement</param>
            /// <param name="displacementCallback">Method to call to signal displacement in a snippet</param>
            /// <param name="mofNConfirmationCallback">Method to call to signal M of N confirmation</param>
            /// <param name="diagnosticPrint">True to cause diagnostic Debug.Print</param>
            public static void Initialize(int samplesPerSnippet, int m, int n, int minCumCuts
                    , EventCallback displacementCallback, EventCallback mofNConfirmationCallback
                    , bool diagnosticPrint = false) {
                // Save parameters
                ClassParameters.SamplesPerSnippet = samplesPerSnippet;
                ClassParameters.M = m;
                ClassParameters.N = n;
                ClassParameters.MinCumCuts = minCumCuts;
                ClassParameters.DisplacementCallback = displacementCallback;
                ClassParameters.MofNConfirmationCallback = mofNConfirmationCallback;
                _diagnosticPrint = diagnosticPrint;

                // Initialize analysis classes
                CumulativeCuts.Initialize();
                MofNConfirmation.Initialize();
            }

            /// <summary>
            /// Analyze a sample for displacement
            /// </summary>
            /// <remarks>
            /// Samples are partitioned into snippets of specified duration
            /// Displacement occurs if the abs(sum of cuts) in a snippet is at least a specified minimum
            ///     The assumption is that a fixed object such as a tree will not exhibit this much net displacement.
            /// To further confirm displacement (reduce false positives), look for at least M displacements in N seconds.
            /// For N of M, note that we do not care if the target alternately moves forward and backward the required distance.
            /// </remarks>
            public static void Analyze(int iValue, int qValue) {
                SampleData.SampleCounter++;

                SampleData.SampleSum.I += iValue;
                SampleData.SampleSum.Q += qValue;

                // Adjust current sample by the current mean and check for a cut
                SampleData.CompSample.I = iValue - (SampleData.SampleSum.I / SampleData.SampleCounter);
                SampleData.CompSample.Q = qValue - (SampleData.SampleSum.Q / SampleData.SampleCounter);

                CumulativeCuts.CheckForCut(SampleData.CompSample);

                // Update snippet counter and see if we've reached a snippet boundary (one second)
                CumulativeCuts.SnippetCntr++;
                if (CumulativeCuts.SnippetCntr != ClassParameters.SamplesPerSnippet) {
                    return;
                }

                // We've collected cumulative cut data for a snippet. See if snippet displacement has occurred
                //  Displacement occurs only if there are more than MinCumCuts in the snippet
                var displacementDetected = (System.Math.Abs(CumulativeCuts.CumCuts) >= ClassParameters.MinCumCuts);

                // If we're doing displacement callback and there's been a change, notify
                if (ClassParameters.DisplacementCallback != null && _lastDisplacementDetected != displacementDetected) {
                    ClassParameters.DisplacementCallback(displacementDetected, CumulativeCuts.SnippetNum);
                    _lastDisplacementDetected = displacementDetected;
                }

                // If we're not doing M of N callback, return
                if (ClassParameters.MofNConfirmationCallback == null) {
                    return;
                }

                // See if we've had displacement in N of the last M snippets
                MofNConfirmation.UpdateDetectionState(CumulativeCuts.SnippetNum, displacementDetected);

                if (_diagnosticPrint) {
                    var statusStr = AlignRight(CumulativeCuts.SnippetNum, "    ") + " " +
                                    AlignRight(CumulativeCuts.CumCuts, "    ")
                                    + (displacementDetected ? " *" : "  ")
                                    + (MofNConfirmation.MofNconf ? " #" : "  ")
                        ;
                    Debug.Print(statusStr);
                }

                // Displacement event change
                if (_lastMofNconfirmation != MofNConfirmation.MofNconf) {
                    ClassParameters.MofNConfirmationCallback(MofNConfirmation.MofNconf, CumulativeCuts.SnippetNum);
                    _lastMofNconfirmation = MofNConfirmation.MofNconf;
                }

                // Update snippet info and reset cumulative cuts values
                CumulativeCuts.SnippetNum++;
                CumulativeCuts.Reset();
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
                public static int SnippetCntr;

                /// <summary>Snippet Number. Incremented once per second.</summary>
                public static int SnippetNum;

                /// <summary>
                /// Initialize 
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
                internal static void CheckForCut(Sample currSample) {
                    if (SampleData.SampleCounter > 1) {
                        var dotProduct = currSample.Q * PrevSample.I - currSample.I * PrevSample.Q;

                        //Debug.Print("# " + SampleData.SampleCounter + " L= " + dotProduct + "; (" + currSample.Q + "," + PrevSample.Q + "); (" + currSample.I + "," + PrevSample.I + ")");

                        if (dotProduct < 0 && PrevSample.Q < 0 && currSample.Q > 0) {
                            CumCuts += 1;
                            //Debug.Print("\n# " + SampleData.SampleCounter + " += " + CumCuts + " "
                            //    + " L = " + dotProduct + "; (" + currSample.Q + "," + PrevSample.Q + "); (" + currSample.I + "," + PrevSample.I + ")");
                        }
                        else if (dotProduct > 0 && PrevSample.Q > 0 && currSample.Q < 0) {
                            CumCuts -= 1;
                            //Debug.Print("\n# " + SampleData.SampleCounter + " -= " + CumCuts + " "
                            //    + " L = " + dotProduct + "; (" + currSample.Q + "," + PrevSample.Q + "); (" + currSample.I + "," + PrevSample.I + ")");
                        }
                    }
                    PrevSample.I = currSample.I;
                    PrevSample.Q = currSample.Q;
                }
            }

            //private static int altCumCuts = 0;

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
            private static class MofNConfirmation {

                private static int[] _buff;
                private static int _currBuffPtr;

                public static bool MofNconf;

                /// <summary>
                /// Initialize M of N filter
                /// </summary>
                public static void Initialize() {
                    _buff = new int[ClassParameters.M];
                    for (var i = 0; i < _buff.Length; i++)
                        _buff[i] = -ClassParameters.N; // Any value less than -N will do
                }

                /// <summary>
                /// Determine whether we are detecting motion or not
                /// </summary>
                /// <param name="snippetNumber">Snippet Number</param>
                /// <param name="displacement">true iff displacement detection has occurred</param>
                public static void UpdateDetectionState(int snippetNumber, bool displacement) {

                    // If displacement occurred, record the current snippet number and advance the current buffer location
                    if (displacement) {
                        _buff[_currBuffPtr] = snippetNumber;
                        _currBuffPtr = (_currBuffPtr + 1) % ClassParameters.M;
                    }

                    MofNconf = snippetNumber - _buff[_currBuffPtr] < ClassParameters.N;

                }
            }

            //---------------------------------------------------------------------------------------------------------------------------------

            #region Utility Classes


            /// <summary>
            /// Hold a sample pair
            /// </summary>
            private class Sample {
                /// <summary>I value</summary>
                public int I;

                /// <summary>Q value</summary>
                public int Q;
            }

            /// <summary>
            /// Sample data
            /// </summary>
            private static class SampleData {
                /// <summary>Sample Counter</summary>
                public static int SampleCounter;

                /// <summary>Current sample, adjusted by mean for comparison</summary>
                public static readonly Sample CompSample = new Sample();

                /// <summary>Sum of samples</summary>
                public static readonly Sample SampleSum = new Sample();
            }

            /// <summary>
            /// Right-align a number
            /// </summary>
            /// <param name="val"></param>
            /// <param name="pad"></param>
            /// <returns></returns>
            private static string AlignRight(int val, string pad) {
                // ReSharper disable once SpecifyACultureInStringConversionExplicitly
                var valStr = val.ToString();
                return valStr == string.Empty ? pad : (pad + val).Substring(valStr.Length, pad.Length);
            }

            #endregion

        }
    }
}

