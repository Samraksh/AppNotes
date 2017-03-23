/*--------------------------------------------------------------------
 * CSMA Radio Ping-Pong: app note for the eMote .NOW
 * (c) 2013-2015 The Samraksh Company
 * 
 * Version history
 *	1.0:
 *		- Initial release
 *  1.1:
 *		- Upgraded to v. 12 namespaces
 *		- Various cleanup and refactoring
 *	1.2:
 *		- Changes to include eMote v.13 changes (Sep 17, 2015)
 *	1.3:
 *		- Updated to eMote v. 14
---------------------------------------------------------------------*/

using System;
using System.Reflection;
using System.Text;
using System.Threading;
using Microsoft.SPOT;

using Samraksh.AppNote.Utility;
using Samraksh.eMote.Net;
using Samraksh.eMote.Net.MAC;
using Samraksh.eMote.Net.Radio;

namespace Samraksh.AppNote.DotNow.PingPong
{

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
    public class Program
    {

        // This is used as a header for the packet payload to identify the app
        private const string Header = "PingPong";

        // The current value
        static int _currVal;

        // LCD and Radio objects
        static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();

        // Reply timer. Slows down interaction by not sending reply messages until the timer expires
        private const int SendInterval = 4000; // Time to wait before sending reply
        static Timer _replyTimer;
        static readonly TimerCallback ReplyTimerCallback = Reply_Timeout;

        // No response timer. If no message received, send current value again
        //  Timer is reset whenever a message is received
        private const int NoResponseInterval = SendInterval * 4; // Time to wait before re-sending; must be larger than send interval
        private static Timer _noResponseDelayTimer;
        private static readonly TimerCallback NoResponseDelayTimerCallback = noResponseDelay_Timeout;

        private static MACBase _macBase;

        /// <summary>
        /// Main program. Set things up and then go to sleep forever.
        /// </summary>
        public static void Main()
        {

            Debug.EnableGCMessages(false);  // We don't want to see garbage collector messages in the Output window

            Debug.Print(VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));

            // Display a welcome message
            Lcd.Write("Hola");
            Thread.Sleep(4000);

            // Pick a value randomly
            _currVal = (new Random()).Next(99);  // We're choosing a fairly small value to avoid runover on the LCD display (since it only has 4 positions)
            Lcd.Write(_currVal);

            _macBase = RadioConfiguration.GetMAC();
            _macBase.OnReceive += RadioReceive;
            _macBase.OnNeighborChange += _macBase_OnNeighborChange;

            Debug.Print("=======================================");
            var info = "MAC Type: " + _macBase.GetType()
                + ", Channel: " + _macBase.MACRadioObj.Channel
                + ", Power: " + _macBase.MACRadioObj.TxPower
                + ", Radio Address: " + _macBase.MACRadioObj.RadioAddress
                + ", Radio Type: " + _macBase.MACRadioObj.RadioName
                + ", Neighbor Liveness Delay: " + _macBase.NeighborLivenessDelay;
            Debug.Print(info);
            Debug.Print("=======================================");

            // Send the current value now
            RadioSend(_currVal.ToString().Trim());

            // Start a one-shot timer that resets itself whenever it expires
            StartOneshotTimer(ref _noResponseDelayTimer, NoResponseDelayTimerCallback, NoResponseInterval);

            var neighborList = MACBase.NeighborListArray();
            while (true)
            {
                _macBase.NeighborList(neighborList);
                PrintNeighborList("Neighbor list for Node [" + _macBase.MACRadioObj.RadioAddress + "]: ", neighborList);
                Thread.Sleep(30 * 1000);
            }

            // Everything is set up. Go to sleep forever, pending events
            Thread.Sleep(Timeout.Infinite);
        }

        static void _macBase_OnNeighborChange(IMAC macInstance, DateTime time)
        {
            var neighborList = MACBase.NeighborListArray();
            macInstance.NeighborList(neighborList);
            PrintNeighborList("Neighbor list CHANGE for Node [" + _macBase.MACRadioObj.RadioAddress + "]: ", neighborList);
        }


        /// <summary>
        /// Print the neighbor list for a given list of neighbors
        /// </summary>
        private static void PrintNeighborList(string prefix, ushort[] neighborList)
        {
            PrintNumericVals(prefix, neighborList);
        }

        /// <summary>
        /// Print ushort values
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="messageEx"></param>
        public static void PrintNumericVals(string prefix, ushort[] messageEx)
        {
            var msgBldr = new StringBuilder(prefix);
            foreach (var val in messageEx)
            {
                msgBldr.Append(val + " ");
            }
            Debug.Print(msgBldr.ToString());
        }


        /// <summary>
        /// Handle a received message
        /// </summary>
        /// <param name="macBase"></param>
        /// <param name="receiveDateTime"></param>
        /// <param name="packet"></param>
        private static void RadioReceive(IMAC macBase, DateTime receiveDateTime, Packet packet)
        {
            Debug.Print("Received " + packet.Payload.Length + " bytes from " + packet.Src);

            // Check if message is for us
            var msgByte = packet.Payload;
            var msgChar = Encoding.UTF8.GetChars(msgByte);
            var msgStr = new string(msgChar);
            if (msgStr.Substring(0, Header.Length) != Header)
            {
                return;
            }
            // Get payload and check if it is in the correct format (an integer)
            string payload = msgStr.Substring(Header.Length);
            int recVal;
            try
            {
                recVal = int.Parse(payload);
            }
            catch
            {
                return;
            }

            //
            // We've received a correct message
            //

            // Reset the no-response timer
            StartOneshotTimer(ref _noResponseDelayTimer, NoResponseDelayTimerCallback, NoResponseInterval);

            // Update the current value
            int origVal = _currVal;
            _currVal = System.Math.Max(_currVal, recVal);
            _currVal++;
            Lcd.Write(_currVal);
            Debug.Print("Orig val " + origVal + ", rec val " + recVal + ", new val " + _currVal);

            // Wait a bit before sending reply
            StartOneshotTimer(ref _replyTimer, ReplyTimerCallback, SendInterval);
        }

        /// <summary>
        /// Send a message
        /// </summary>
        /// <remarks>It will be preceded by the HEADER</remarks>
        /// <param name="toSend">String to be sent</param>
        private static void RadioSend(string toSend)
        {
            var toSendByte = Encoding.UTF8.GetBytes(Header + toSend);
            var neighborList = MACBase.NeighborListArray();
            _macBase.NeighborList(neighborList);
            foreach (var theNeighbor in neighborList)
            {
                if (theNeighbor == 0)
                {
                    break;
                }
                Debug.Print("Sending message \"" + toSend + "\" to " + theNeighbor);
                _macBase.Send(theNeighbor, toSendByte, 0, (ushort)toSendByte.Length);
            }
        }

        /// <summary>
        /// Send the current value when the reply timer expires
        /// </summary>
        /// <param name="obj">Ignored</param>
        private static void Reply_Timeout(object obj)
        {
            RadioSend(_currVal.ToString().Trim());
            Debug.Print("Sending message " + _currVal);
        }

        /// <summary>
        /// Resend the current value when the no-response timer expires
        /// </summary>
        /// <param name="obj">Ignored</param>
        static void noResponseDelay_Timeout(object obj)
        {
            RadioSend(_currVal.ToString().Trim());
            // Give a short interruption to show that we've received no response
            Lcd.Write("aaaa");
            Thread.Sleep(500);
            Lcd.Write(_currVal);
            // Restart the no-response timer & display a message
            StartOneshotTimer(ref _noResponseDelayTimer, NoResponseDelayTimerCallback, NoResponseInterval);
            Debug.Print("No message received ... broadcasting again");
        }

        /// <summary>
        /// Start (or restart) a one-shot timer
        /// </summary>
        /// <remarks>It will run once and then stop</remarks>
        /// <param name="timer">The timer</param>
        /// <param name="callBack">The timer's callback</param>
        /// <param name="interval">The interval</param>
        static void StartOneshotTimer(ref Timer timer, TimerCallback callBack, int interval)
        {
            if (timer == null)
            {
                timer = new Timer(callBack, null, interval, Timeout.Infinite);
            }
            else
            {
                timer.Change(interval, Timeout.Infinite);
            }
        }

    }
}

