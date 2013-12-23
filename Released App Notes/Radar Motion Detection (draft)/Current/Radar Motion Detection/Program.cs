// IIIT-A Forest Tracking Program for eMote
// Author: Sandip Bapat (sandip.bapat@samraksh.com)

// This program reads BumbleBee sensor data using the eMote's ADC
// The program processes the data  and detects if there is a Displacement Detection.
// It signals the start and stop of each Displacement Detect to a base station using a messaging layer
// The messaging layer uses the CTP routing protocol to route packets

using System.Threading;
using Microsoft.SPOT;



enum PI {
    HALF = 6434,
    FULL = 12868,
    NEG = -12868,
    TWO = 25736,
}

// Detector parameters
enum DETECTOR {
    INTER_SAMP_TIME = 4, // sampling rate in ms
    SAMPRATE = 250,
    M = 2,
    N = 8,
    THRESH = 100,
    DC_EST_SECS = 10,
    START_TYPE = 0,
    STOP_TYPE = 1,
}

namespace Samraksh.AppNote {
    public class PDRTracking {
        public struct Comp {
            public int I, Q;

            public Comp(int p1, int p2) {
                I = p1;
                Q = p2;
            }
        }


        public static class CumulativeCuts {
            public static Comp prevSample;
            public static int cumCuts;

            public static void init() {
                prevSample.I = prevSample.Q = 0;
            }

            public static void reset() {
                cumCuts = 0;
            }

            public static void update(Comp currSample) {
                if (((prevSample.I * currSample.Q - currSample.I * prevSample.Q) < 0) && (currSample.Q > 0) && (prevSample.Q < 0))
                    cumCuts += 1;
                else if (((prevSample.I * currSample.Q - currSample.I * prevSample.Q) > 0) && (currSample.Q < 0) && (prevSample.Q > 0))
                    cumCuts -= 1;

                prevSample.I = currSample.I;
                prevSample.Q = currSample.Q;
            }
        }

        // Main function - initialize DC estimator, phase estimator, start Timer for sampling and ADC
        public static void Main() {
            SensorData.initNoise();
            PhaseUnwrapping.init();
            CumulativeCuts.init();
            MessageHandler.init();
            ADC.Init(0x04);
            MofNFilter.init();

            Timer sampleTimer = new Timer(sampleFired, null, (int)DETECTOR.INTER_SAMP_TIME, (int)DETECTOR.INTER_SAMP_TIME);
            Debug.Print("Starting");

            Thread.Sleep(Timeout.Infinite);
        }

        public static class SensorData {
            public static int meanI = 0;
            public static int meanQ = 0;
            public static int sampNum = 0;
            public static int noiseSumI = 0;
            public static int noiseSumQ = 0;
            public static ushort[] currSample = new ushort[2];
            public static int tempPhase;
            public static Comp compSample = new Comp(0, 0);

            public static void initNoise() {
                meanI = meanQ = sampNum = 0;
                noiseSumI = noiseSumQ = 0;
            }
        }

        public static class MessageHandler {
            public static byte[] payload = new byte[5];
            public static ushort seqNum = 0;

            public static void init() {
                seqNum = 0;
                MessageLayer.Init();
                payload[0] = (byte)((1 >> 8) & 0xff);
                payload[1] = (byte)(1 & 0xff);
            }

            private static void insertSeqNum() {
                payload[2] = (byte)((seqNum >> 8) & 0xff);
                payload[3] = (byte)(seqNum & 0xff);
                seqNum++;
            }

            public static void sendStart() {
                insertSeqNum();
                payload[4] = (byte)DETECTOR.START_TYPE;
                //Messaging.Send(0xffff, payload);
                MessageLayer.Send(0, 0xffff, payload, 5);
            }

            public static void sendStop() {
                insertSeqNum();
                payload[4] = (byte)DETECTOR.STOP_TYPE;
                //Messaging.Send(0xffff, payload);
                MessageLayer.Send(0, 0xffff, payload, 5);
            }

        }

        public static class myGPIO {
            public static OutputPort Gpio0 = new OutputPort((Cpu.Pin)10, false);
            public static OutputPort Gpio1 = new OutputPort((Cpu.Pin)9, false);
        }

        public static class MofNFilter {
            public static int snippetIndex, snippetNum;
            public static int Thresh = 100;
            public static int snippetMin, snippetMax;

            private static int M = 2;
            private static int N = 8;

            private static int[] Buff = new int[M];
            public static int state = 0;
            public static int prevstate = 0;
            private static int i, End;

            public static void init() {
                snippetIndex = snippetNum = 0;
                state = prevstate = 0;

                End = 0;
                for (i = 0; i < M; i++)
                    Buff[i] = -N;
            }

            public static void update(int index, int detect) {
                prevstate = state;

                if (index - Buff[End] < N)
                    state = 1;
                else
                    state = 0;

                if (detect == 1) {
                    Buff[End] = index;
                    End = (End + 1) % M;
                }
            }
        }

        // Interrupt handler activated when Timer fires
        // Read data from ADC
        // If initial data, estimate DC
        // Otherwise, unwrap phase and test whether displacement > threshold
        static void sampleFired(object o) {

            SensorData.sampNum += 1;

            if (SensorData.sampNum % 2 == 0) {
                myGPIO.Gpio0.Write(true);
                //Debug.Print("Timer");
            }
            else
                myGPIO.Gpio0.Write(false);


            ADC.getData(SensorData.currSample, 0, 2);

            // for the first DC_EST_SECS * SAMPRATE samples, collect noise data
            if (SensorData.sampNum < (int)DETECTOR.SAMPRATE * (int)DETECTOR.DC_EST_SECS) {
                SensorData.noiseSumI += SensorData.currSample[0];
                SensorData.noiseSumQ += SensorData.currSample[1];
            }

            if (SensorData.sampNum == (int)DETECTOR.SAMPRATE * (int)DETECTOR.DC_EST_SECS) {
                SensorData.meanI = SensorData.noiseSumI / ((int)DETECTOR.SAMPRATE * (int)DETECTOR.DC_EST_SECS);
                SensorData.meanQ = SensorData.noiseSumQ / ((int)DETECTOR.SAMPRATE * (int)DETECTOR.DC_EST_SECS);
            }

            if (SensorData.sampNum >= (int)DETECTOR.SAMPRATE * (int)DETECTOR.DC_EST_SECS) {
                SensorData.compSample.I = (int)(SensorData.currSample[0]) - SensorData.meanI;
                SensorData.compSample.Q = (int)(SensorData.currSample[1]) - SensorData.meanQ;

                /*
                SensorData.tempPhase = PhaseUnwrapping.unwrap(SensorData.compSample) / 4096;
                if (MofNFilter.snippetIndex == 0)
                    MofNFilter.snippetMin = MofNFilter.snippetMax = SensorData.tempPhase;
                else if (SensorData.tempPhase > MofNFilter.snippetMax)
                    MofNFilter.snippetMax = SensorData.tempPhase;
                else if (SensorData.tempPhase < MofNFilter.snippetMin)
                    MofNFilter.snippetMin = SensorData.tempPhase;
                */

                if (MofNFilter.snippetIndex == 0)
                    CumulativeCuts.reset();
                CumulativeCuts.update(SensorData.compSample);

                MofNFilter.snippetIndex++;

                if (MofNFilter.snippetIndex == (int)DETECTOR.SAMPRATE) // one snippet
                {

                    //myGPIO.Gpio1.Write(true);
                    //if (MofNFilter.snippetMax - MofNFilter.snippetMin >= MofNFilter.Thresh)
                    if (System.Math.Abs(CumulativeCuts.cumCuts) > 5)
                        MofNFilter.update(MofNFilter.snippetNum, 1);
                    else
                        MofNFilter.update(MofNFilter.snippetNum, 0);

                    MofNFilter.snippetNum++;
                    MofNFilter.snippetIndex = 0;

                    // new detect event started
                    if (MofNFilter.prevstate == 0 && MofNFilter.state == 1) {
                        myGPIO.Gpio1.Write(true);
                        MessageHandler.sendStart();
                    }

                // current detect event ended
                    else if (MofNFilter.state == 0 && MofNFilter.prevstate == 1) {
                        myGPIO.Gpio1.Write(false);
                        MessageHandler.sendStop();
                    }
                    //myGPIO.Gpio1.Write(false);
                }


            }
        }
    }
}