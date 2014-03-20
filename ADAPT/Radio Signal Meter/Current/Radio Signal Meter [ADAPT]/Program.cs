/*--------------------------------------------------------------------
 * Radio Signal Meter: app note for the eMote ADAPT
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *  1.0: initial release
 ---------------------------------------------------------------------*/

using System;
using System.Reflection;
using System.Threading;

using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using Samraksh.SPOT.Net;
using Samraksh.SPOT.Net.Radio;
using Samraksh.SPOT.Net.Mac;

using Samraksh.AppNote.Utility;

namespace Samraksh.AppNote.Adapt {

    /// <summary>
    /// This program listens for radio packets and prints information about identity, signal strength, etc.
    /// It also periodically sends radio packets that another mote can listen to.
    /// It can help debug another program by "sniffing" what's coming over the radio.
    /// </summary>
    public class Program {

        static SimpleCsmaRadio _csmaRadio;
        static int _sendCounter;
        const string Header = "SignalMeter";
        const int SendDelay = 1000; // ms

        /// <summary>
        /// Set up the radio to listen and to send
        /// </summary>
        public static void Main() {

            Debug.EnableGCMessages(false); // We don't want to see garbage collector messages in the Output window

            // Print out the program name and version
            var currVersion = Assembly.GetExecutingAssembly().GetName().Version;
            Debug.Print(Resources.GetString(Resources.StringResources.ProgramName) + ", Version " + currVersion.Major +
                        "." + currVersion.Minor);

            // Set up the radio for CSMA interaction
            //  The first argument specifies the radio
            //  The next two arguments are fairly standard but you're free to try changing them
            //  The last argument is the method to call when a message is received
            try {
                _csmaRadio = new SimpleCsmaRadio(RadioName.RF231RADIOLR, 140, TxPowerValue.Power_0Point7dBm, RadioReceive);
            }
            catch (Exception ex) {
                Debug.Print("Error initializing CSMA radio\n" + ex);
                Thread.Sleep(Timeout.Infinite);
            }

            while (true) {
                try {
                    // Send a probe
                    var toSendByte = System.Text.Encoding.UTF8.GetBytes(Header + " " + _sendCounter++);
                    _csmaRadio.Send(Addresses.BROADCAST, toSendByte);
                    Thread.Sleep(SendDelay);
                }
                catch (Exception ex) {
                    Debug.Print("Error sending message\n" + ex);
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

