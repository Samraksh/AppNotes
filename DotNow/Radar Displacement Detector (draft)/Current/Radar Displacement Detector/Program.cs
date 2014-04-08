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
        MaxCumCuts = 5,
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
            SensorData.InitNoise();
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
            /// <summary>
            /// Cumulative cuts
            /// </summary>
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
            /// <param name="compSample"></param>
            public static void Update(Sample compSample) {
                if (((_prevSample.I * compSample.Q - compSample.I * _prevSample.Q) < 0) && (compSample.Q > 0) && (_prevSample.Q < 0))
                    CumCuts += 1;
                else if (((_prevSample.I * compSample.Q - compSample.I * _prevSample.Q) > 0) && (compSample.Q < 0) && (_prevSample.Q > 0))
                    CumCuts -= 1;

                _prevSample.I = compSample.I;
                _prevSample.Q = compSample.Q;
            }
        }

        public static class SensorData {
            public static int SampNum = 0;
            public static Sample Mean = new Sample();
            public static Sample NoiseSum = new Sample();
            public static Sample CurrSample = new Sample();
            public static Sample CompSample = new Sample();

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
        public static class MofNFilter {
            public static int SnippetIndex, SnippetNum;
            public static int Thresh = 100;
            public static int SnippetMin, SnippetMax;

            private const int M = (int)Detector.M;  // Syntactic sugar
            private const int N = (int)Detector.N;

            private static readonly int[] Buff = new int[M];
            public static int State = 0;
            public static int Prevstate = 0;
            private static int _i, _end;

            public static void Init() {
                SnippetIndex = SnippetNum = 0;
                State = Prevstate = 0;
                _end = 0;
                for (_i = 0; _i < M; _i++)
                    Buff[_i] = -N;
            }

            public static void Update(int index, bool detect) {
                Prevstate = State;
                State = (index - Buff[_end] < N) ? 1 : 0;

                if (detect) {
                    Buff[_end] = index;
                    _end = (_end + 1) % M;
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
                SensorData.CurrSample.I = Ibuffer[i];
                SensorData.CurrSample.Q = Qbuffer[i];
                ProcessSample();
            }
        }
        private static int _firing;

        private static void ProcessSample() {
            SensorData.SampNum += 1;

            MyGpio.SampleProcessed.Write(SensorData.SampNum % 2 == 0);
            Lcd.Display(SensorData.SampNum);
            //Debug.Print("\nSample " + SensorData.SampNum);

            //ADC.getData(SensorData.compSample, 0, 2);

            const int samplesToWait = (int)Detector.SamplesPerSecond * 10; // Wait for 10 seconds

            if (SensorData.SampNum < samplesToWait) {
                SensorData.NoiseSum.I += SensorData.CurrSample.I;
                SensorData.NoiseSum.Q += SensorData.CurrSample.Q;
                return;
            }

            if (SensorData.SampNum == samplesToWait) {
                SensorData.Mean.I = SensorData.NoiseSum.I / samplesToWait;
                SensorData.Mean.Q = SensorData.NoiseSum.Q / samplesToWait;
                Debug.Print("*** Start moving");
            }

            SensorData.CompSample.I = SensorData.CurrSample.I - SensorData.Mean.I;
            SensorData.CompSample.Q = SensorData.CurrSample.Q - SensorData.Mean.Q;

            /*
                SensorData.tempPhase = PhaseUnwrapping.unwrap(SensorData.compSample) / 4096;
                if (MofNFilter.snippetIndex == 0)
                    MofNFilter.snippetMin = MofNFilter.snippetMax = SensorData.tempPhase;
                else if (SensorData.tempPhase > MofNFilter.snippetMax)
                    MofNFilter.snippetMax = SensorData.tempPhase;
                else if (SensorData.tempPhase < MofNFilter.snippetMin)
                    MofNFilter.snippetMin = SensorData.tempPhase;
                */

            CumulativeCuts.Update(SensorData.CompSample);

            MofNFilter.SnippetIndex++;

            // one snippet = one second
            if (MofNFilter.SnippetIndex != (int)Detector.SamplesPerSecond) {
                return;
            }
            MofNFilter.Update(MofNFilter.SnippetNum, System.Math.Abs(CumulativeCuts.CumCuts) > (int)Detector.MaxCumCuts);

            MofNFilter.SnippetNum++;
            MofNFilter.SnippetIndex = 0;
            CumulativeCuts.Reset();

            // new detect event started
            if (MofNFilter.Prevstate == 0 && MofNFilter.State == 1) {
                MyGpio.DetectEvent.Write(true);
                Debug.Print("\n-------------------------Detect Event started");
                //MessageHandler.sendStart();
            }

                // current detect event ended
            else if (MofNFilter.State == 0 && MofNFilter.Prevstate == 1) {
                MyGpio.DetectEvent.Write(false);
                Debug.Print("\n-------------------------Detect Event ended");
                //MessageHandler.sendStop();
            }
            //myGPIO.DetectEvent.Write(false);
        }

    }
}