using System;
using System.Threading;

using Microsoft.SPOT;
using Samraksh.SPOT.Hardware.EmoteDotNow;
using Samraksh.SPOT.Net;
using Samraksh.SPOT.Net.Radio;
using Samraksh.SPOT.Net.Mac;

using Samraksh.AppNote.Utility;

namespace Samraksh.AppNote.PingPong {

    public class Program {

        const string HEADER = "PingPong";

        static int currVal;
        static EmoteLCDUtil lcd;
        static CsmaRadio csmaRadio;

        static Timer sendDelayTimer;
        static TimerCallback sendDelayTimerCallback = new TimerCallback(sendDelay_Timeout);
        static Timer noResponseDelayTimer;
        static TimerCallback noResponseDelayTimerCallback = new TimerCallback(noResponseDelay_Timeout);
        const int SEND_INTERVAL = 4000;
        const int NO_RESPONSE_INTERVAL = SEND_INTERVAL * 4;

        public static void Main() {
            Debug.EnableGCMessages(false);  // We don't want to see garbage collector messages in the Output window

            Debug.Print(Resources.GetString(Resources.StringResources.ProgramName));

            // Set up LCD and display a 
            lcd = new EmoteLCDUtil();
            lcd.Display("Hola");
            Thread.Sleep(4000);

            currVal = (new Random()).Next(999);
            lcd.Display(currVal);

            csmaRadio = new CsmaRadio(140, TxPowerValue.Power_0Point7dBm, RadioReceive, 100, NeighborhoodChange);

            RadioSend(currVal.ToString().Trim());

            StartOneshotTimer(ref noResponseDelayTimer, noResponseDelayTimerCallback, NO_RESPONSE_INTERVAL);

            Thread.Sleep(Timeout.Infinite);
        }

        static void RadioReceive(CSMA csma) {
            // Check if there's at least one packet
            if (csma.GetPendingPacketCount() < 1) {
                return;
            }

            // Check to be sure there's something in the packet
            Message packet = csma.GetNextPacket();
            if (packet == null) {
                return;
            }

            // Check if message is for us
            byte[] msgByte = packet.GetMessage();
            char[] msgChar = System.Text.UTF8Encoding.UTF8.GetChars(msgByte);
            string msgStr = new string(msgChar);
            if (msgStr == null || msgStr.Substring(0, HEADER.Length) != HEADER) {
                return;
            }

            // Get payload and check if it is in the correct format (an integer)
            string payload = msgStr.Substring(HEADER.Length);
            int recVal;
            try {
                recVal = Int32.Parse(payload);
            }
            catch {
                return;
            }

            // If we've received a correct message, reset the no-response timer
            StartOneshotTimer(ref noResponseDelayTimer, noResponseDelayTimerCallback, NO_RESPONSE_INTERVAL);

            // Update the current value
            int origVal = currVal;
            currVal = System.Math.Max(currVal, recVal);
            currVal++;
            lcd.Display(currVal);
            Debug.Print("Orig val " + origVal + ", rec val " + recVal + ", new val " + currVal);

            // Wait a bit before sending reply
            StartOneshotTimer(ref sendDelayTimer, sendDelayTimerCallback, SEND_INTERVAL);
        }

        static void NeighborhoodChange(Neighbor[] neighborhood) {
            Debug.Print("Neighborhood Change. New neighborhood has " + neighborhood.Length + " members");
            foreach (Neighbor theNeighbor in neighborhood) {
                Debug.Print("   At" + theNeighbor.MacAddress + ", last heard from at " + theNeighbor.LastHeardTime);
            }
        }

        static void RadioSend(string toSend) {
            byte[] toSendByte = System.Text.Encoding.UTF8.GetBytes(HEADER + toSend);
            csmaRadio.Send(Addresses.BROADCAST, toSendByte);
        }

        static void sendDelay_Timeout(object obj) {
            RadioSend(currVal.ToString().Trim());
            Debug.Print("Sending message");
        }

        static void noResponseDelay_Timeout(object obj) {
            RadioSend(currVal.ToString().Trim());
            lcd.Display("aaaa");
            Thread.Sleep(500);
            lcd.Display(currVal);
            StartOneshotTimer(ref noResponseDelayTimer, noResponseDelayTimerCallback, NO_RESPONSE_INTERVAL);
            Debug.Print("No message received ... broadcasting again");
        }

        static void StartOneshotTimer(ref Timer timer, TimerCallback callBack, int interval) {
            if (timer == null) {
                timer = new Timer(callBack, null, interval, Timeout.Infinite);
            }
            else {
                timer.Change(interval, Timeout.Infinite);
            }
        }

    }
}

