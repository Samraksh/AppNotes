/*--------------------------------------------------------------------
 * Radio Signal Meter: app note for the eMote .NOW
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *      1.0: initial release
 *      1.1: Corrected an issue with reporting on the length of the message
 *      1.2: Added build profiles for on-board and long-range radios
 *      
 *  Remarks
 *      Choose "Long Range" or "On Board" solution configuration depending on which radio you're using.
---------------------------------------------------------------------*/

using System;
using System.Reflection;
using System.Threading;

using Microsoft.SPOT;

using Samraksh.SPOT.Net.Radio;
using Samraksh.SPOT.Net.Mac;

using Samraksh.AppNote.Utility;

namespace Samraksh.AppNote.DotNow {

    /// <summary>
    /// This program listens for radio packets and prints information about identity, signal strength, etc.
    /// It also periodically sends radio packets that another mote can listen to.
    /// It can help you debug another program by "sniffing" what's coming over the radio.
    /// </summary>
    public class Program {

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

            Debug.EnableGCMessages(false); // We don't want to see garbage collector messages in the Output window

            // Print out the program name and version
            var currVersion = Assembly.GetExecutingAssembly().GetName().Version;
            Debug.Print(Resources.GetString(Resources.StringResources.ProgramName) + ", Version " + currVersion.Major +
                        "." + currVersion.Minor);

            // Set up LCD and display a welcome message
            Lcd.Display("9999");
            Thread.Sleep(4000);

            // Set up the radio for CSMA interaction
            //  The first argument specifies the radio
            //  The next two arguments are fairly standard but you're free to try changing them
            //  The last argument is the method to call when a message is received
            try {
                _csmaRadio = new SimpleCsmaRadio(TheRadioName, 140, TxPowerValue.Power_0Point7dBm, RadioReceive);
            }
            catch {
                Lcd.Display("9999");
                Thread.Sleep(Timeout.Infinite);
            }

            while (true) {
                try {
                    // Send a probe
                    var toSendByte = System.Text.Encoding.UTF8.GetBytes(Header + " " + _sendCounter++);
                    _csmaRadio.Send(Addresses.BROADCAST, toSendByte);
                    Thread.Sleep(SendDelay);
                }
                catch {
                    Lcd.Display("8888");
                    Thread.Sleep(Timeout.Infinite);
                }
            }
        }

        /// <summary>
        /// Handle a received message
        /// </summary>
        /// <param name="csma">A CSMA object that has the message info</param>
        static void RadioReceive(CSMA csma) {
            var rcvMsg = csma.GetNextPacket();
            var rcvPayloadBytes = rcvMsg.GetMessage();
            var rcvPayloadChar = System.Text.Encoding.UTF8.GetChars(rcvPayloadBytes);
            try {
                Debug.Print("Received " + (rcvMsg.Unicast ? "Unicast" : "Broadcast") + " message from src: " + rcvMsg.Src + ", size: " + rcvMsg.Size + ", rssi: " + rcvMsg.RSSI + ", lqi: " + rcvMsg.LQI);
                Debug.Print("   Payload: [" + new string(rcvPayloadChar) + "]");
            }
            catch (Exception e) {
                Debug.Print(e.ToString());
            }
        }

    }
}


