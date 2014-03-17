// IIIT-A Forest Tracking Program for eMote
// Author: Sandip Bapat (sandip.bapat@samraksh.com)

// This program reads BumbleBee sensor data using the eMote's ADC
// The program processes the data  and detects if there is a Displacement Detection.
// It signals the start and stop of each Displacement Detect to a base station using a messaging layer
// The messaging layer uses the CTP routing protocol to route packets

using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;
using Samraksh.SPOT.Hardware.EmoteDotNow;
using AnalogInput = Samraksh.SPOT.Hardware.EmoteDotNow.AnalogInput;

namespace Samraksh.AppNote.DotNow.RadarDisplacementDetector {

    enum Pi {
        Half = 6434,
        Full = 12868,
        Neg = -12868,
        Two = 25736,
    }

    // Detector parameters
    enum Detector {
        //InterSampTime = 4, // sampling rate in ms
        //Samprate = 250,
        //private const uint SamplingIntervalMs = 1000;
        //private const uint NumberOfSamplesPerInterval = 1000;
        SamplingIntervalMs = 1000,
        NumberOfSamplesPerInterval = 250,
        SamplesPerSecond = NumberOfSamplesPerInterval / (SamplingIntervalMs / 1000),
        M = 2,
        N = 8,
        Thresh = 100,
        DcEstSecs = 10,
        StartType = 0,
        StopType = 1,
    }



    public static class RadarDisplacementDetector {

        private static readonly ushort[] Ibuffer = new ushort[(int)Detector.NumberOfSamplesPerInterval];
        private static readonly ushort[] Qbuffer = new ushort[(int)Detector.NumberOfSamplesPerInterval];

        private static readonly EmoteLcdUtil Lcd = new EmoteLcdUtil();

        // Main function - initialize DC estimator, phase estimator, start Timer for sampling and ADC
        public static void Main() {
            // Basic setup
            Debug.EnableGCMessages(false);
            Debug.Print("Radar Motion Detection " + VersionInfo.Version + " (" + VersionInfo.BuildDateTime + ")");
            Lcd.Display("radar");

            Debug.Print("*** Hold still");
            Thread.Sleep(4000); // Wait a bit to let the user stop moving

            // Initialize radar fields
            SensorData.InitNoise();
            PhaseUnwrapping.Init();
            CumulativeCuts.Init();

            AnalogInput.InitializeADC();
            AnalogInput.ConfigureContinuousModeDualChannel(Ibuffer, Qbuffer, (int)Detector.NumberOfSamplesPerInterval, (int)Detector.SamplingIntervalMs, SampleFired);

            MofNFilter.Init();

            Thread.Sleep(Timeout.Infinite);
        }

        public struct Comp {
            public int I, Q;

            public Comp(int p1, int p2) {
                I = p1;
                Q = p2;
            }
        }


        public static class CumulativeCuts {
            public static Comp PrevSample;
            public static int CumCuts;

            public static void Init() {
                PrevSample.I = PrevSample.Q = 0;
            }

            public static void Reset() {
                CumCuts = 0;
            }

            public static void Update(Comp currSample) {
                if (((PrevSample.I * currSample.Q - currSample.I * PrevSample.Q) < 0) && (currSample.Q > 0) &&
                    (PrevSample.Q < 0))
                    CumCuts += 1;
                else if (((PrevSample.I * currSample.Q - currSample.I * PrevSample.Q) > 0) && (currSample.Q < 0) &&
                         (PrevSample.Q > 0))
                    CumCuts -= 1;

                PrevSample.I = currSample.I;
                PrevSample.Q = currSample.Q;
            }
        }

        public static class SensorData {
            public static int MeanI = 0;
            public static int MeanQ = 0;
            public static int SampNum = 0;
            public static int NoiseSumI = 0;
            public static int NoiseSumQ = 0;
            public static ushort[] CurrSample = new ushort[2];
            public static int TempPhase;
            public static Comp CompSample = new Comp(0, 0);

            public static void InitNoise() {
                MeanI = MeanQ = SampNum = 0;
                NoiseSumI = NoiseSumQ = 0;
            }
        }


        public static class MyGpio {
            public static OutputPort Gpio0 = new OutputPort(Pins.GPIO_J12_PIN1, false);
            public static OutputPort Gpio1 = new OutputPort(Pins.GPIO_J12_PIN2, false);
            // Enable the BumbleBee. Set this false to disable.
            public static OutputPort EnableBumbleBee = new OutputPort(Pins.GPIO_J11_PIN3, true);
        }

        public static class MofNFilter {
            public static int SnippetIndex, SnippetNum;
            public static int Thresh = 100;
            public static int SnippetMin, SnippetMax;

            //private const int M = 2;
            private const int M = 1;
            private const int N = 8;

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

            public static void Update(int index, int detect) {
                Prevstate = State;
                State = (index - Buff[_end] < N) ? 1 : 0;

                //Debug.Print("    index: " + index + ", Buff[_end]: " + Buff[_end] + ", index - Buff[_end]: " + (index - Buff[_end]) + ", N: " + N + ", (index - Buff[_end] < N):" + (index - Buff[_end] < N) + ", State: " + State);

                if (detect == 1) {
                    Buff[_end] = index;
                    _end = (_end + 1) % M;
                }
            }
        }

        // Interrupt handler activated when Timer fires
        // Read data from ADC
        // If initial data, estimate DC
        // Otherwise, unwrap phase and test whether displacement > threshold
        private static int _firing;
        private static void SampleFired(long threshold) {
            Debug.Print("* " + _firing++);

            //var bufI = new StringBuilder("Ibuffer: ");
            //var bufQ = new StringBuilder("Qbuffer: ");
            //for (var i = 0; i < Ibuffer.Length; i++) {
            //    bufI.Append(Ibuffer[i]);
            //    bufI.Append(", ");
            //    bufQ.Append(Ibuffer[i]);
            //    bufQ.Append(", ");
            //}
            //Debug.Print(bufI.ToString());
            //Debug.Print(bufQ.ToString());

            //var buf = Ibuffer;
            //Debug.Print("\nIbuffer: " + buf[0] + ", " + buf[1] + ", " + buf[2] + ", " + buf[3] + ", " + buf[4] + ", ");
            //buf = Qbuffer;
            //Debug.Print("Qbuffer: " + buf[0] + ", " + buf[1] + ", " + buf[2] + ", " + buf[3] + ", " + buf[4] + ", ");

            //for (var i = 0; i < 10; i++) {
            for (var i = 0; i < (int)Detector.NumberOfSamplesPerInterval; i++) {
                SensorData.CurrSample[0] = Ibuffer[i];
                SensorData.CurrSample[1] = Qbuffer[i];
                ProcessSample();
            }
            //Debug.Print("SampNum: " + SensorData.SampNum);
        }

        private static void ProcessSample() {
            SensorData.SampNum += 1;

            MyGpio.Gpio0.Write(SensorData.SampNum % 2 == 0);
            Lcd.Display(SensorData.SampNum);
            //Debug.Print("\nSample " + SensorData.SampNum);

            //ADC.getData(SensorData.currSample, 0, 2);

            const int samplesToWait = (int)Detector.SamplesPerSecond * 10; // Wait for 10 seconds

            // for the first DC_EST_SECS * SAMPRATE samples, collect noise data
            //if (SensorData.SampNum < (int)Detector.Samprate * (int)Detector.DcEstSecs) {
            if (SensorData.SampNum < samplesToWait) {
                SensorData.NoiseSumI += SensorData.CurrSample[0];
                SensorData.NoiseSumQ += SensorData.CurrSample[1];
                return;
            }

            //if (SensorData.SampNum == (int)Detector.Samprate * (int)Detector.DcEstSecs) {
            if (SensorData.SampNum == samplesToWait) {
                //SensorData.MeanI = SensorData.NoiseSumI / ((int)Detector.Samprate * (int)Detector.DcEstSecs);
                //SensorData.MeanQ = SensorData.NoiseSumQ / ((int)Detector.Samprate * (int)Detector.DcEstSecs);
                SensorData.MeanI = SensorData.NoiseSumI / samplesToWait;
                SensorData.MeanQ = SensorData.NoiseSumQ / samplesToWait;
                Debug.Print("*** Start moving");
            }

            ////if (SensorData.SampNum < (int)Detector.Samprate * (int)Detector.DcEstSecs) {
            //if (SensorData.SampNum < samplesToWait) {
            //    return;
            //}

            SensorData.CompSample.I = SensorData.CurrSample[0] - SensorData.MeanI;
            SensorData.CompSample.Q = SensorData.CurrSample[1] - SensorData.MeanQ;

            /*
                SensorData.tempPhase = PhaseUnwrapping.unwrap(SensorData.compSample) / 4096;
                if (MofNFilter.snippetIndex == 0)
                    MofNFilter.snippetMin = MofNFilter.snippetMax = SensorData.tempPhase;
                else if (SensorData.tempPhase > MofNFilter.snippetMax)
                    MofNFilter.snippetMax = SensorData.tempPhase;
                else if (SensorData.tempPhase < MofNFilter.snippetMin)
                    MofNFilter.snippetMin = SensorData.tempPhase;
                */

            if (MofNFilter.SnippetIndex == 0) {
                CumulativeCuts.Reset();
            }
            CumulativeCuts.Update(SensorData.CompSample);

            MofNFilter.SnippetIndex++;

            //Debug.Print(">MofNFilter " + MofNFilter.SnippetIndex + ", " + NumberOfSamplesPerInterval);

            // one snippet
            //if (MofNFilter.SnippetIndex != (int)Detector.Samprate) {
            if (MofNFilter.SnippetIndex != (int)Detector.SamplesPerSecond) {
                return;
            }
            //myGPIO.Gpio1.Write(true);
            //if (MofNFilter.snippetMax - MofNFilter.snippetMin >= MofNFilter.Thresh)
            MofNFilter.Update(MofNFilter.SnippetNum, System.Math.Abs(CumulativeCuts.CumCuts) > 5 ? 1 : 0);

            MofNFilter.SnippetNum++;
            MofNFilter.SnippetIndex = 0;

            // new detect event started
            if (MofNFilter.Prevstate == 0 && MofNFilter.State == 1) {
                MyGpio.Gpio1.Write(true);
                Debug.Print("\n-------------------------Detect Event started");
                //MessageHandler.sendStart();
            }

                // current detect event ended
            else if (MofNFilter.State == 0 && MofNFilter.Prevstate == 1) {
                MyGpio.Gpio1.Write(false);
                Debug.Print("\n-------------------------Detect Event ended");
                //MessageHandler.sendStop();
            }
            //myGPIO.Gpio1.Write(false);
        }

    }
}