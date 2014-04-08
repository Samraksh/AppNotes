using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;
using Samraksh.SPOT.Hardware.EmoteDotNow;
using AnalogInput = Samraksh.SPOT.Hardware.EmoteDotNow.AnalogInput;

namespace Samraksh.AppNote.DotNow.RadarDisplacementDetector {

    //enum Pi {
    //    Half = 6434,
    //    Full = 12868,
    //    Neg = -12868,
    //    Two = 25736,
    //}

    // Detector parameters
    enum Detector {
        SamplingIntervalMs = 1000,
        NumberOfSamplesPerInterval = 250,
        SamplesPerSecond = NumberOfSamplesPerInterval / (SamplingIntervalMs / 1000),
        M = 2,
        N = 8,
        MinCumCuts = 5,
    }

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
            AnalogInput.ConfigureContinuousModeDualChannel(Ibuffer, Qbuffer, (int)Detector.NumberOfSamplesPerInterval, (int)Detector.SamplingIntervalMs, SampleFired);

            MofNFilter.Init();

            Thread.Sleep(Timeout.Infinite);
        }

        /// <summary>
        /// Hold a sample pair
        /// </summary>
        public struct Sample {
            /// <summary>I value</summary>
            public int I;
            /// <summary>Q value</summary>
            public int Q;
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
        /// Sample data
        /// </summary>
        public static class SampleData {
            /// <summary>Sample Counter</summary>
            public static int SampNum = 0;
            /// <summary>Average value of background noise</summary>
            public static Sample Mean = new Sample();
            /// <summary>Sum of background noise values</summary>
            public static Sample NoiseSum = new Sample();
            /// <summary>Current sample</summary>
            public static Sample CurrSample = new Sample();
            /// <summary>Current sample, adjusted for background noise</summary>
            public static Sample CompSample = new Sample();

            /// <summary>
            /// Initialize background noise values
            /// </summary>
            public static void InitNoise() {
                Mean.I = Mean.Q = SampNum = 0;
                NoiseSum.I = NoiseSum.Q = 0;
            }
        }

        /// <summary>
        /// Define GPIO ports
        /// </summary>
        public static class MyGpio {
            /// <summary>Indicate when sample is processed</summary>
            public static OutputPort SampleProcessed = new OutputPort(Pins.GPIO_J12_PIN1, false);

            /// <summary>Indicate whether or not event detected</summary>
            public static OutputPort DetectEvent = new OutputPort(Pins.GPIO_J12_PIN2, false);

            /// <summary>Enable the BumbleBee. Set this false to disable. </summary>
            public static OutputPort EnableBumbleBee = new OutputPort(Pins.GPIO_J11_PIN3, true);
        }

        /// <summary>
        /// Check if, in the last N seconds, there were M seconds in which events were detected.
        /// </summary>
        /// <remarks>
        /// Buff is a circular buffer of size M. 
        /// </remarks>
        public static class MofNFilter {
            /// <summary>Counts samples to see when a snippet (one second) has been reached</summary>
            public static int SnippetCntr;
            /// <summary>Snippet Number. Incremented once per second.</summary>
            public static int SnippetNum;

            private const int M = (int)Detector.M;  // Syntactic sugar
            private const int N = (int)Detector.N;

            private static readonly int[] Buff = new int[M];
            private static int _currentBuffLoc;
            /// <summary>Current state</summary>
            public static int State = 0;
            /// <summary>Previous state</summary>
            public static int Prevstate = 0;

            /// <summary>
            /// Initialize M of N filter
            /// </summary>
            public static void Init() {
                SnippetCntr = SnippetNum = 0;
                State = Prevstate = 0;
                _currentBuffLoc = 0;
                for (var i = 0; i < M; i++)
                    Buff[i] = -N;   // Any value less than -N will do
            }

            /// <summary>
            /// Determine whether we are detecting motion or not
            /// </summary>
            /// <param name="snippetNumber">Snippet Number</param>
            /// <param name="displacement">true iff displacement detection has occurred</param>
            public static void UpdateDetectionState(int snippetNumber, bool displacement) {
                Prevstate = State;
                State = (snippetNumber - Buff[_currentBuffLoc] < N) ? 1 : 0;

                if (displacement) {
                    Debug.Print("*d");
                    Buff[_currentBuffLoc] = snippetNumber;
                    _currentBuffLoc = (_currentBuffLoc + 1) % M;
                }
            }
        }

        // In the last N seconds, there were M seconds (snippets) in which more than 5 cuts were traversed
        // 5 cuts = 60 cm ?

        // Interrupt handler activated when Timer fires
        // Read data from ADC
        // If initial data, estimate DC
        // Otherwise, unwrap phase and test whether displacement > threshold
        private static void SampleFired(long threshold) {
            Debug.Print("* " + _firing++);
            for (var i = 0; i < (int)Detector.NumberOfSamplesPerInterval; i++) {
                SampleData.CurrSample.I = Ibuffer[i];
                SampleData.CurrSample.Q = Qbuffer[i];
                ProcessSample();
            }
        }
        private static int _firing;

        private static void ProcessSample() {
            SampleData.SampNum += 1;

            MyGpio.SampleProcessed.Write(SampleData.SampNum % 2 == 0);
            Lcd.Display(SampleData.SampNum);
            //Debug.Print("\nSample " + SampleData.SampNum);

            //ADC.getData(SampleData.currSample, 0, 2);

            const int samplesToWait = (int)Detector.SamplesPerSecond * 10; // Wait for 10 seconds

            if (SampleData.SampNum < samplesToWait) {
                SampleData.NoiseSum.I += SampleData.CurrSample.I;
                SampleData.NoiseSum.Q += SampleData.CurrSample.Q;
                return;
            }

            if (SampleData.SampNum == samplesToWait) {
                SampleData.Mean.I = SampleData.NoiseSum.I / samplesToWait;
                SampleData.Mean.Q = SampleData.NoiseSum.Q / samplesToWait;
                Debug.Print("*** Start moving");
            }

            SampleData.CompSample.I = SampleData.CurrSample.I - SampleData.Mean.I;
            SampleData.CompSample.Q = SampleData.CurrSample.Q - SampleData.Mean.Q;

            CumulativeCuts.Update(SampleData.CompSample);

            MofNFilter.SnippetCntr++;

            // one snippet = one second
            if (MofNFilter.SnippetCntr != (int)Detector.SamplesPerSecond) {
                return;
            }
            var displacementDetected = System.Math.Abs(CumulativeCuts.CumCuts) > (int)Detector.MinCumCuts;
            MofNFilter.UpdateDetectionState(MofNFilter.SnippetNum, displacementDetected);

            MofNFilter.SnippetNum++;
            MofNFilter.SnippetCntr = 0;
            CumulativeCuts.Reset();

            // displacement event started
            if (MofNFilter.Prevstate == 0 && MofNFilter.State == 1) {
                MyGpio.DetectEvent.Write(true);
                Debug.Print("\n-------------------------Detect Event started");
            }

            // displacement event ended
            else if (MofNFilter.State == 0 && MofNFilter.Prevstate == 1) {
                MyGpio.DetectEvent.Write(false);
                Debug.Print("\n-------------------------Detect Event ended");
            }
        }

    }
}