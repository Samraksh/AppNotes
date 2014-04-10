using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;
using AnalogInput = Samraksh.eMote.DotNow.AnalogInput;

namespace Samraksh.AppNote.DotNow.RadarDisplacementDetector {

    /// <summary>
    /// Radar Displacement Detector
    ///     Detects displacement (towards or away from the radar)
    ///     Filters out "back and forth" movement (such as trees blowing in the wind)
    /// </summary>
    public static class RadarDisplacementDetector {

        private static readonly ushort[] Ibuffer = new ushort[(int)Detector.NumberOfSamplesPerInterval];
        private static readonly ushort[] Qbuffer = new ushort[(int)Detector.NumberOfSamplesPerInterval];

        private static readonly EmoteLcdUtil Lcd = new EmoteLcdUtil();

        /// <summary>
        /// Get things started
        /// </summary>
        public static void Main() {
            // Basic setup
            Debug.EnableGCMessages(false);
            Debug.Print("Radar Motion Detection " + VersionInfo.Version + " (" + VersionInfo.BuildDateTime + ")");
            Lcd.Display("radar");

            Debug.Print("*** Hold still");
            Thread.Sleep(4000); // Wait a bit to let the user stop moving

            // Initialize radar fields
            SampleData.InitNoise();
            CumulativeCuts.Init();

            AnalogInput.InitializeADC();
            AnalogInput.ConfigureContinuousModeDualChannel(Ibuffer, Qbuffer, (int)Detector.NumberOfSamplesPerInterval, (int)Detector.SamplingIntervalMs, AdcBuffer_Callback);

            MofNFilter.Init();

            Thread.Sleep(Timeout.Infinite);
        }


        /// <summary>
        /// Calculate cumulative cuts
        /// </summary>
        public static class CumulativeCuts {
            private static Sample _prevSample;
            /// <summary>Cumulative cuts</summary>
            public static int CumCuts;

            /// <summary>
            /// Constructor: Initialize previous values
            /// </summary>
            public static void Init() {
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
                if (direction < 0 && _prevSample.Q < 0 && currSample.Q > 0)
                    CumCuts += 1;
                else if (direction > 0 && _prevSample.Q > 0 && currSample.Q < 0)
                    CumCuts -= 1;

                _prevSample.I = currSample.I;
                _prevSample.Q = currSample.Q;
            }
        }

        /// <summary>
        /// Check if, in the last N seconds, there were M seconds in which events were detected.
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

            private const int M = (int)Detector.M;  // Syntactic sugar
            private const int N = (int)Detector.N;

            private static readonly int[] Buff = new int[M];
            private static int _currBuffPtr = 0;
            /// <summary>Current state</summary>
            public static DisplacementState State = DisplacementState.Inactive;
            /// <summary>Previous state</summary>
            public static DisplacementState Prevstate = DisplacementState.Inactive;

            /// <summary>
            /// Initialize M of N filter
            /// </summary>
            public static void Init() {
                for (var i = 0; i < Buff.Length; i++)
                    Buff[i] = -N;   // Any value less than -N will do
            }

            /// <summary>
            /// Determine whether we are detecting motion or not
            /// </summary>
            /// <param name="snippetNumber">Snippet Number</param>
            /// <param name="displacement">true iff displacement detection has occurred</param>
            public static void UpdateDetectionState(int snippetNumber, bool displacement) {
                Prevstate = State;
                // Check if the snippet number occurred sufficiently recently
                State = (snippetNumber - Buff[_currBuffPtr] < N) ? DisplacementState.Displacing : DisplacementState.Inactive;

                // If displacement occurred, record the current snippet number and advance the current buffer location
                if (!displacement) {
                    return;
                }
                Debug.Print("*d");
                Buff[_currBuffPtr] = snippetNumber;
                _currBuffPtr = (_currBuffPtr + 1) % M;
            }
        }

        /// <summary>
        /// Callback for buffered ADC
        /// </summary>
        /// <param name="threshold"></param>
        private static void AdcBuffer_Callback(long threshold) {
            Debug.Print("* " + _firing++);
            for (var i = 0; i < (int)Detector.NumberOfSamplesPerInterval; i++) {
                SampleData.CurrSample.I = Ibuffer[i];
                SampleData.CurrSample.Q = Qbuffer[i];
                ProcessSample();
            }
        }
        private static int _firing;

        /// <summary>
        /// Process a sample
        /// </summary>
        private static void ProcessSample() {
            const int samplesToWait = (int)Detector.SamplesPerSecond * 10; // Wait for 10 seconds

            SampleData.SampNum += 1;
            GpioPorts.SampleProcessed.Write(SampleData.SampNum % 2 == 0);
            Lcd.Display(SampleData.SampNum);
            
            // Collect background noise data
            if (SampleData.SampNum < samplesToWait) {
                SampleData.NoiseSum.I += SampleData.CurrSample.I;
                SampleData.NoiseSum.Q += SampleData.CurrSample.Q;
                return;
            }

            // Done collecting background noise data: calculate means and let user begin to move
            if (SampleData.SampNum == samplesToWait) {
                SampleData.Mean.I = SampleData.NoiseSum.I / samplesToWait;
                SampleData.Mean.Q = SampleData.NoiseSum.Q / samplesToWait;
                Debug.Print("*** Start moving");
            }

            // Adjust sample data by the noise mean and update cumulative cuts
            SampleData.CompSample.I = SampleData.CurrSample.I - SampleData.Mean.I;
            SampleData.CompSample.Q = SampleData.CurrSample.Q - SampleData.Mean.Q;
            CumulativeCuts.Update(SampleData.CompSample);

            // Update snippet counter and see if we've reached a snippet boundary (one second)
            MofNFilter.SnippetCntr++;
            if (MofNFilter.SnippetCntr != (int)Detector.SamplesPerSecond) {
                return;
            }

            // We've collected cumulative cut data for a snippet. See if displacement has occurred
            //  Displacement occurs only if there are more than MinCumCuts in the snippet
            var displacementDetected = System.Math.Abs(CumulativeCuts.CumCuts) > (int)Detector.MinCumCuts;
            
            // See if we've had displacement in N of the last M snippets
            MofNFilter.UpdateDetectionState(MofNFilter.SnippetNum, displacementDetected);

            // Reset M of N and cumulative cuts values
            MofNFilter.SnippetNum++;
            MofNFilter.SnippetCntr = 0;
            CumulativeCuts.Reset();

            // Displacement event started
            if (MofNFilter.Prevstate == 0 && MofNFilter.State == DisplacementState.Displacing) {
                GpioPorts.DetectEvent.Write(true);
                Debug.Print("\n-------------------------Detect Event started");
            }

            // Displacement event ended
            else if (MofNFilter.State == 0 && MofNFilter.Prevstate == DisplacementState.Inactive) {
                GpioPorts.DetectEvent.Write(false);
                Debug.Print("\n-------------------------Detect Event ended");
            }
        }

    }
}