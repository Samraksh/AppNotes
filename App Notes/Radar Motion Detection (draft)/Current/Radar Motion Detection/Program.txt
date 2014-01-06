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
using Samraksh.SPOT.Hardware;
using Samraksh.SPOT.Hardware.EmoteDotNow;
using AnalogInput = Samraksh.SPOT.Hardware.EmoteDotNow.AnalogInput;

enum PI {
    HALF = 6434,
    FULL = 12868,
    NEG = -12868,
    TWO = 25736,
}

// Detector parameters
enum Detector {
    InterSampTime = 4, // sampling rate in ms
    Samprate = 250,
    M = 2,
    N = 8,
    Thresh = 100,
    DcEstSecs = 10,
    StartType = 0,
    StopType = 1,
}

namespace Samraksh.AppNote.RadarMotionDetection {
    public class PDRTracking {
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

        private const uint SamplingTime = 1000;
        private const uint NumberOfSamples = 1000;
        private static readonly ushort[] Ibuffer = new ushort[NumberOfSamples];
        private static readonly ushort[] Qbuffer = new ushort[NumberOfSamples];

        private static readonly EmoteLcdUtil Lcd = new EmoteLcdUtil();

        // Main function - initialize DC estimator, phase estimator, start Timer for sampling and ADC
        public static void Main() {
            // Basic setup
            Debug.EnableGCMessages(false);
            Debug.Print("Radar Motion Detection " + VersionInfo.Version + " (" + VersionInfo.BuildDateTime + ")");
            Lcd.Display("radar");
            Thread.Sleep(4000);

            // Initialize radar fields
            SensorData.InitNoise();
            PhaseUnwrapping.init();
            CumulativeCuts.Init();

            AnalogInput.InitializeADC();
            AnalogInput.ConfigureContinuousModeDualChannel(Ibuffer, Qbuffer, NumberOfSamples, SamplingTime, SampleFired);

            MofNFilter.Init();

            Debug.Print("Starting");

            Thread.Sleep(Timeout.Infinite);
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

            private const int M = 2;
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

                Debug.Print("    index: " + index + ", Buff[_end]: " + Buff[_end] + ", index - Buff[_end]: " + (index - Buff[_end]) + ", N: " + N + ", (index - Buff[_end] < N):" + (index - Buff[_end] < N) + ", State: " + State);

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
        private static int _firing = 0;
        private static void SampleFired(long threshold) {
            Debug.Print("* " + _firing++);
            for (var i = 0; i < NumberOfSamples; i++) {
                SensorData.CurrSample[0] = Ibuffer[i];
                SensorData.CurrSample[1] = Qbuffer[i];
                ProcessSample();
            }
        }

        private static void ProcessSample() {
            SensorData.SampNum += 1;

            MyGpio.Gpio0.Write(SensorData.SampNum % 2 == 0);

            //ADC.getData(SensorData.currSample, 0, 2);

            // for the first DC_EST_SECS * SAMPRATE samples, collect noise data
            if (SensorData.SampNum < (int)Detector.Samprate * (int)Detector.DcEstSecs) {
                SensorData.NoiseSumI += SensorData.CurrSample[0];
                SensorData.NoiseSumQ += SensorData.CurrSample[1];
            }

            if (SensorData.SampNum == (int)Detector.Samprate * (int)Detector.DcEstSecs) {
                SensorData.MeanI = SensorData.NoiseSumI / ((int)Detector.Samprate * (int)Detector.DcEstSecs);
                SensorData.MeanQ = SensorData.NoiseSumQ / ((int)Detector.Samprate * (int)Detector.DcEstSecs);
            }

            if (SensorData.SampNum >= (int)Detector.Samprate * (int)Detector.DcEstSecs) {
                SensorData.CompSample.I = (int)(SensorData.CurrSample[0]) - SensorData.MeanI;
                SensorData.CompSample.Q = (int)(SensorData.CurrSample[1]) - SensorData.MeanQ;

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

                // one snippet
                if (MofNFilter.SnippetIndex == (int)Detector.Samprate) {

                    //myGPIO.Gpio1.Write(true);
                    //if (MofNFilter.snippetMax - MofNFilter.snippetMin >= MofNFilter.Thresh)
                    MofNFilter.Update(MofNFilter.SnippetNum, System.Math.Abs(CumulativeCuts.CumCuts) > 5 ? 1 : 0);

                    MofNFilter.SnippetNum++;
                    MofNFilter.SnippetIndex = 0;

                    // new detect event started
                    if (MofNFilter.Prevstate == 0 && MofNFilter.State == 1) {
                        MyGpio.Gpio1.Write(true);
                        Debug.Print("\nDetect Event started");
                        //MessageHandler.sendStart();
                    }

                        // current detect event ended
                    else if (MofNFilter.State == 0 && MofNFilter.Prevstate == 1) {
                        MyGpio.Gpio1.Write(false);
                        Debug.Print("\nDetect Event ended");
                        //MessageHandler.sendStop();
                    }
                    //myGPIO.Gpio1.Write(false);
                }

            }

        }
    }
}