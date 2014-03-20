using System;
using System.Threading;

using Microsoft.SPOT;
using Samraksh.SPOT.Hardware.EmoteDotNow;
using Samraksh.SPOT.Net;
using Samraksh.SPOT.Net.Radio;
using Samraksh.SPOT.Net.Mac;

using Samraksh.AppNote.Utility;

namespace Samraksh.AppNote.PingPong {

    /// <summary>
    /// Set up two motes to send and receive messages between each other.
    /// The goal is to converge on a shared value.
    /// Each mote randomly chooses an initial current value and sends it to the other.
    /// When a mote receives a message, it sets its current value to the maximum of the two and then increments it by 1, and displays it on the LCD.
    /// After a delay, the mote sends the new value. The delay is to keep the LCD display from changing too fast.
    /// 
    /// If a mote does not hear from the other, then after a (longer) delay, it resends its current value.
    /// It does this repeatedly, at the longer interval.
    /// </summary>
    public class Program {

        // This is used as a header for the packet payload to identify the app
        const string HEADER = "PingPong";

        // The current value
        static int currVal;

        // LCD and Radio objects
        static EmoteLCDUtil lcd;
        static SimpleCsmaRadio csmaRadio;

        // Reply timer. Slows down interaction by not sending reply messages until the timer expires
        const int SEND_INTERVAL = 4000; // Time to wait before sending reply
        static Timer replyTimer;
        static TimerCallback replyTimerCallback = new TimerCallback(reply_Timeout);

        // No response timer. If no message received, send current value again
        //  Timer is reset whenever a message is received
        const int NO_RESPONSE_INTERVAL = SEND_INTERVAL * 4; // Time to wait before re-sending; must be larger than send interval
        static Timer noResponseDelayTimer;
        static TimerCallback noResponseDelayTimer_Callback = new TimerCallback(noResponseDelay_Timeout);

        /// <summary>
        /// Main program. Set things up and then go to sleep forever.
        /// </summary>
        public static void Main() {

            Debug.EnableGCMessages(false);  // We don't want to see garbage collector messages in the Output window

            Debug.Print(Resources.GetString(Resources.StringResources.ProgramName));

            // Set up LCD and display a welcome message
            lcd = new EmoteLCDUtil();
            lcd.Display("Hola");
            Thread.Sleep(4000);

            // Pick a value randomly
            currVal = (new Random()).Next(99);  // We're choosing a fairly small value to avoid runover on the LCD display (since it only has 4 positions)
            lcd.Display(currVal);

            // Set up the radio for CSMA interaction
            //  The first two arguments are fairly standard but you're free to try changing them
            //  The last argument is the method to call when a message is received
            csmaRadio = new SimpleCsmaRadio(140, TxPowerValue.Power_0Point7dBm, RadioReceive);

            // Send the current value now
            RadioSend(currVal.ToString().Trim());

            // Start a one-shot timer that resets itself whenever it expires
            StartOneshotTimer(ref noResponseDelayTimer, noResponseDelayTimer_Callback, NO_RESPONSE_INTERVAL);

            // Everything is set up. Go to sleep forever, pending events
            Thread.Sleep(Timeout.Infinite);
        }

        /// <summary>
        /// Handle a received message
        /// </summary>
        /// <param name="csma">A CSMA object that has the message info</param>
        static void RadioReceive(CSMA csma) {
            //
            // Check to be sure it's a message we're interested in
            //

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

            //
            // We've received a correct message
            //

            // Reset the no-response timer
            StartOneshotTimer(ref noResponseDelayTimer, noResponseDelayTimer_Callback, NO_RESPONSE_INTERVAL);

            // Update the current value
            int origVal = currVal;
            currVal = System.Math.Max(currVal, recVal);
            currVal++;
            lcd.Display(currVal);
            Debug.Print("Orig val " + origVal + ", rec val " + recVal + ", new val " + currVal);

            // Wait a bit before sending reply
            StartOneshotTimer(ref replyTimer, replyTimerCallback, SEND_INTERVAL);
        }

        /// <summary>
        /// Send a message
        /// </summary>
        /// <remarks>It will be preceded by the HEADER</remarks>
        /// <param name="toSend">String to be sent</param>
        static void RadioSend(string toSend) {
            byte[] toSendByte = System.Text.Encoding.UTF8.GetBytes(HEADER + toSend);
            csmaRadio.Send(Addresses.BROADCAST, toSendByte);
        }

        /// <summary>
        /// Send the current value when the reply timer expires
        /// </summary>
        /// <param name="obj">Ignored</param>
        static void reply_Timeout(object obj) {
            RadioSend(currVal.ToString().Trim());
            Debug.Print("Sending message " + currVal);
        }

        /// <summary>
        /// Resend the current value when the no-response timer expires
        /// </summary>
        /// <param name="obj">Ignored</param>
        static void noResponseDelay_Timeout(object obj) {
            RadioSend(currVal.ToString().Trim());
            // Give a short interruption to show that we've received no response
            lcd.Display("aaaa");
            Thread.Sleep(500);
            lcd.Display(currVal);
            // Restart the no-response timer & display a message
            StartOneshotTimer(ref noResponseDelayTimer, noResponseDelayTimer_Callback, NO_RESPONSE_INTERVAL);
            Debug.Print("No message received ... broadcasting again");
        }

        /// <summary>
        /// Start (or restart) a one-shot timer
        /// </summary>
        /// <remarks>It will run once and then stop</remarks>
        /// <param name="timer">The timer</param>
        /// <param name="callBack">The timer's callback</param>
        /// <param name="interval">The interval</param>
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

