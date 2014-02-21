/*--------------------------------------------------------------------
 * Radio Signal Meter: app note for the eMote .NOW 1.1
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *  1.0: initial release
 *  1.1: Corrected an issue with reporting on the length of the message
---------------------------------------------------------------------*/

using System;
using System.Reflection;
using System.Threading;

using Microsoft.SPOT;
using Samraksh.SPOT.Hardware.EmoteDotNow;
using Samraksh.SPOT.Net;
using Samraksh.SPOT.Net.Radio;
using Samraksh.SPOT.Net.Mac;

using Samraksh.AppNote.Utility;

namespace Samraksh.AppNote {

    /// <summary>
    /// This program listens for radio packets and prints information about identity, signal strength, etc.
    /// It also periodically sends radio packets that another mote can listen to.
    /// It can help you debug another program by "sniffing" what's coming over the radio.
    /// </summary>
    public class Program {

        static SimpleCsmaRadio csmaRadio;
        static EmoteLCDUtil lcd = new EmoteLCDUtil();
        static int sendCounter = 0;
        const string HEADER = "SignalMeter";
        const int sendDelay = 1000; // ms
        const int printInterval = 10;  // messages

        /// <summary>
        /// 
        /// </summary>
        public static void Main() {

            Debug.EnableGCMessages(false);  // We don't want to see garbage collector messages in the Output window

            // Print out the program name and version
            Version currVersion = Assembly.GetExecutingAssembly().GetName().Version;
            Debug.Print(Resources.GetString(Resources.StringResources.ProgramName)+", Version " + currVersion.ToString());

            // Set up LCD and display a welcome message
            lcd = new EmoteLCDUtil();
            lcd.Display("Hola");
            Thread.Sleep(4000);

            // Set up the radio for CSMA interaction
            //  The first two arguments are fairly standard but you're free to try changing them
            //  The last argument is the method to call when a message is received
            csmaRadio = new SimpleCsmaRadio(140, TxPowerValue.Power_0Point7dBm, RadioReceive);

            while (true) {
                // Send a probe
                byte[] toSendByte = System.Text.Encoding.UTF8.GetBytes(HEADER + " " + sendCounter++);
                csmaRadio.Send(Addresses.BROADCAST, toSendByte);
                Thread.Sleep(sendDelay);
            }

        }

        /// <summary>
        /// Handle a received message
        /// </summary>
        /// <param name="csma">A CSMA object that has the message info</param>
        static void RadioReceive(CSMA csma) {
            Message rcvMsg = csma.GetNextPacket();
            byte[] rcvPayloadBytes = rcvMsg.GetMessage();
            char[] rcvPayloadChar = System.Text.Encoding.UTF8.GetChars(rcvPayloadBytes);
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

