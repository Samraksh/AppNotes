/*--------------------------------------------------------------------
 * Radio Signal Meter: app note for the eMote .NOW
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *      1.0: initial release
 *      1.1: Corrected an issue with reporting on the length of the message
 *      1.2: Added build profiles for on-board and long-range radios
 *      1.3: Added option to choose the radio channel
 *      1.3: Added option to choose the radio channel
 *      
 *  Remarks
 *      Choose "Long Range" or "On Board" solution configuration depending on which radio you're using.
---------------------------------------------------------------------*/

using System.Text;
using System.Threading;

using Microsoft.SPOT;
using Samraksh.eMote.Net.Mac;
using Samraksh.eMote.Net.Radio;
using Samraksh.AppNote.Utility;

namespace Samraksh.AppNote.DotNow {

    /// <summary>
    /// This program listens for radio packets and prints information about identity, signal strength, etc.
    /// It also periodically sends radio packets that another mote can listen to.
    /// It can help you debug another program by "sniffing" what's coming over the radio.
    /// </summary>
    public class Program {

        const Channels RadioChannel = Channels.Channel_11;

        static SimpleCsmaRadio _csmaRadio;
        static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();
        static int _sendCounter;
        const string Header = "SignalMeter";
        const int SendDelay = 1000; // ms

#if LONG_RANGE_RADIO
        const RadioName TheRadioName = RadioName.RF231RADIOLR;
#elif  ON_BOARD_RADIO
        const RadioName TheRadioName = RadioName.RF231RADIO;
#else
#error Incorrect Solution Configuration. Please choose Long-Range or On-Board Radio
#endif

        /// <summary>
        /// Set up the radio to listen and to send
        /// </summary>
        public static void Main() {

            //Debug.EnableGCMessages(false); // We don't want to see garbage collector messages in the Output window

            // Print out the program name and version
            Debug.Print(VersionInfo.VersionBuild());

            // Set up LCD and display a welcome message
            Lcd.Display("Strt");

            // Set up the radio for CSMA interaction
            //  The first argument specifies the radio
            //  The next two arguments are fairly standard but you're free to try changing them
            //  The fourth argument is the method to call when a message is received
            //  The last argument is an optional radio channel
            try {
                _csmaRadio = new SimpleCsmaRadio(TheRadioName, 140, TxPowerValue.Power_0Point7dBm, RadioReceive, RadioChannel);
            }
            catch {
                Lcd.Display("Err");
                Thread.Sleep(Timeout.Infinite);
            }

            // Show that we've initialized and are running
            Lcd.Display("Run");

            while (true) {
                try {
                    // Send a probe
                    var toSendByte = Encoding.UTF8.GetBytes(Header + " " + _sendCounter++);
                    _csmaRadio.Send(Addresses.BROADCAST, toSendByte);
                    Thread.Sleep(SendDelay);
                }
                catch {
                    Lcd.Display("8888");
                    Thread.Sleep(Timeout.Infinite);
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }

        /// <summary>
        /// Handle a received message
        /// </summary>
        /// <param name="csma">A CSMA object that has the message info</param>
        static void RadioReceive(CSMA csma) {
            var rcvMsg = csma.GetNextPacket();
            var rcvPayloadBytes = rcvMsg.GetMessage();
            Debug.Print("\nReceived " + (rcvMsg.Unicast ? "Unicast" : "Broadcast") + " message from src: " + rcvMsg.Src + ", size: " + rcvMsg.Size + ", rssi: " + rcvMsg.RSSI + ", lqi: " + rcvMsg.LQI);
            //try {
            //    var rcvPayloadChar = Encoding.UTF8.GetChars(rcvPayloadBytes);
            //    Debug.Print("   " + new string(rcvPayloadChar));
            //}
            //// Catch and ignore any exceptions. This can happen when payloads contain binary data.
            //// ReSharper disable once EmptyGeneralCatchClause
            //catch (Exception ex) {
            //    Debug.Print("Except");
            //}
            var rcvPayloadStrBldr = new StringBuilder();
            foreach (var theByte in rcvPayloadBytes) {
                rcvPayloadStrBldr.Append(theByte.ToString());
                rcvPayloadStrBldr.Append(" ");
            }
            Debug.Print("   " + rcvPayloadStrBldr);

            Lcd.Display(_rcvCntr++);
        }

        private static int _rcvCntr;

    }
}


