/*--------------------------------------------------------------------
 * Radio Data Collector: app note for the eMote .NOW 1.0
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *  1.0: initial release
---------------------------------------------------------------------*/

using System;
using System.Collections;
using System.Text;
using System.Threading;

using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.SPOT.Hardware;
using Samraksh.SPOT.Hardware.EmoteDotNow;
using Samraksh.SPOT.Net;
using Samraksh.SPOT.Net.Radio;
using Samraksh.SPOT.Net.Mac;

using Samraksh.AppNote.Utility;

namespace Samraksh.AppNote {

    /// <summary>
    /// This program collects data from sensing nodes, with synchronized time.
    /// A mote can be a base station node or a sensing node.
    /// The base station listens for sensing node messages and collects the info. It makes adjustments for time differences between base and sensing nodes, including clock drift.
    /// </summary>
    public class Program {

        // These must be the same in Base and Sensing programs
        const string APP_IDENTIFIER = "DC";
        enum MsgTypes : byte { Hello, Reply, Data };

        // Timers - all are one-shot (period of 0)
        static SimpleTimer helloTimer = new SimpleTimer(HelloCallback, null, HELLO_INTERVAL);
        static SimpleTimer sensingTimer = new SimpleTimer(SensingCallback, null, SENSING_INTERVAL);

        static SimpleCsmaRadio csmaRadio;
        static EmoteLCDUtil lcd = new EmoteLCDUtil();
        static byte[] app_identifier_bytes;
        static byte app_identifierSize;
        static int baseStationId = -1;
        static int messageSequence = 0;
        static byte messageSequenceSize = sizeof(int);
        static byte msgTypeSize = sizeof(MsgTypes);
        static ArrayList messageTimers = new ArrayList();

        const int HELLO_INTERVAL = 4000;
        const int SENSING_INTERVAL = 4000;
        const int MESSAGE_TIMEOUT = 1000;

        enum States { Hello, Sense };
        static States currState = States.Hello;

        /// <summary>
        /// 
        /// </summary>
        public static void Main() {

            Debug.EnableGCMessages(false);  // We don't want to see garbage collector messages in the Output window

            Debug.Print(Resources.GetString(Resources.StringResources.ProgramName));

            // Set up LCD and display a welcome message
            lcd = new EmoteLCDUtil();
            lcd.Display("Hola");
            Thread.Sleep(4000);

            // Convert the app identifier to a byte array
            app_identifier_bytes = System.Text.Encoding.UTF8.GetBytes(APP_IDENTIFIER);
            app_identifierSize = (byte)app_identifier_bytes.Length;

            // Set up the radio for CSMA interaction
            //  The first two arguments are fairly standard but you're free to try changing them
            //  The last argument is the method to call when a message is received
            csmaRadio = new SimpleCsmaRadio(140, TxPowerValue.Power_0Point7dBm, RadioReceive);

            // Set up the timers ... both are one-shot and are (re)started depending on system state.
            SimpleTimer helloTimer = new SimpleTimer(HelloCallback, null, HELLO_INTERVAL);
            SimpleTimer sensingTimer = new SimpleTimer(SensingCallback, null, HELLO_INTERVAL);

            // Start broadcasting Hello messages
            HelloCallback(null);


            // Sleep forever
            Thread.Sleep(Timeout.Infinite);

        }

        /// <summary>
        /// Handle a received message
        /// </summary>
        /// <remarks>
        /// We are only interested in messages that
        ///     1. Have the right app identifier.
        ///     2. Have the right message type.
        ///     3. Are unicast.
        /// These messages must be from the base station as it is the only one that would be unicasting to this node.
        /// </remarks>
        /// <param name="csma">A CSMA object that has the message info</param>
        static void RadioReceive(CSMA csma) {
            Message rcvMsg = csma.GetNextPacket();
            byte[] rcvPayloadBytes = rcvMsg.GetMessage();
            char[] rcvPayloadChar = System.Text.Encoding.UTF8.GetChars(rcvPayloadBytes);

            // Print message details
            Debug.Print("Got a " + (rcvMsg.Unicast ? "Unicast" : "Broadcast") + " message from src: " + rcvMsg.Src + ", size: " + rcvPayloadBytes + ", rssi: " + rcvMsg.RSSI + ", lqi: " + rcvMsg.LQI);
            Debug.Print("   Payload [" + new string(rcvPayloadChar) + "]");

            StringBuilder rcvPayloadByteStr = new StringBuilder("  Payload [");
            for (int i = 0; i < rcvPayloadBytes.Length; i++) {
                rcvPayloadByteStr.Append(rcvPayloadBytes.ToString() + " ");
            }
            rcvPayloadByteStr.Append("]");
            Debug.Print(rcvPayloadByteStr.ToString());

            // Check the app identifier
            for (int i = 0; i < app_identifierSize; i++) {
                if (rcvPayloadBytes[i] != app_identifier_bytes[i]) {
                    return;
                }
            }
            // Check the message type & cast mode
            if (rcvPayloadBytes[app_identifierSize] != (byte)MsgTypes.Reply || !rcvMsg.Unicast) {
                return;
            }

            // All is ok ... set the source ID of the base station
            baseStationId = rcvMsg.Src;

            // Stop the message timer
            bool messageFound = false;
            for (int i = 0; i < messageTimers.Count; i++) {
                if (((MessageTimer)messageTimers[i]).MessageSequence == messageSequence) {
                    ((MessageTimer)messageTimers[i]).MessageTimer.Stop();
                    messageFound = true;
                }
            }
            // If we didn't find it, just return ... this should never happen
            if (!messageFound) {
                return;
            }

            // Set the current state to Sense & begin sensing
            currState = States.Sense;
            SensingCallback(null);
        }

        static void RadioSend(Addresses dest, MsgTypes msgType, byte[] payload) {
            if (dest == Addresses.BROADCAST) {
                if (baseStationId < 0) {    // No sending if base station address not known
                    return;
                }
            }

            // Create the message
            byte[] msg = new byte[msgTypeSize + app_identifierSize + messageSequenceSize + payload.Length];
            byte currPos = 0;
            // Copy message type
            msg[0] = (byte)msgType;
            currPos++; ;
            // Copy app identifier
            for (byte i = 0; i < app_identifierSize; i++) {
                msg[i + currPos] = app_identifier_bytes[i];
            }
            currPos += app_identifierSize;
            // Copy message sequence
            byte[] messageSequenceBytes = BitConverter.GetBytes(messageSequence);
            for (byte i = 0; i < messageSequenceSize; i++) {
                msg[i + currPos] = messageSequenceBytes[i];
            }
            currPos += messageSequenceSize;
            // Copy payload
            for (int i = 0; i < payload.Length; i++) {
                msg[i + 3] = payload[i];
            }
            // Send the message
            csmaRadio.Send(dest, payload);

            // Set a timer for the message
            bool messageFound = false;
            SimpleTimer messageTimer = new SimpleTimer(MessageTimeoutCallback, null, MESSAGE_TIMEOUT);
            // Check to see if we should reuse or add an entry in the list
            for (byte i = 0; i < (byte)messageTimers.Count; i++) {
                // The item is null, so reuse it
                if (((MessageTimer)messageTimers[i]).MessageTimer == null) {
                    messageTimers[i] = new MessageTimer(messageSequence, messageTimer);
                    messageFound = true;
                    break;
                }
            }
            if (!messageFound) {
                // No null items found, so create new one
                messageTimers.Add(new MessageTimer(messageSequence, messageTimer));
            }
            // Start the timer
            messageTimer.Start();

            // Increment the counter
            messageSequence++;
        }

        static void HelloCallback(object obj) {
            if (currState != States.Hello) {
                return;
            }
            RadioSend(Addresses.BROADCAST, MsgTypes.Hello, BitConverter.GetBytes(messageSequence));
            helloTimer.Start();
        }

        static Random sensorSurrogate = new Random();
        static void SensingCallback(object obj) {
            if (currState != States.Sense) {
                return;
            }
            if (baseStationId < 0) {
                return;
            }
            int sensedValue = sensorSurrogate.Next();
            RadioSend((Addresses)baseStationId, MsgTypes.Data, BitConverter.GetBytes(sensedValue));
            sensingTimer.Start();
        }

        static void MessageTimeoutCallback(object obj) {
            // Kill all the timers
            foreach (object theMessageTimer in messageTimers) {
                ((MessageTimer)theMessageTimer).MessageTimer.Stop();
            }
            // Go back to a listening state
            currState = States.Hello;
        }

        internal class MessageTimer {
            internal int MessageSequence { get; private set; }
            internal SimpleTimer MessageTimer { get; private set; }
            internal MessageTimer(int _MessageSequence, SimpleTimer _MessageTimer) {
                MessageSequence = _MessageSequence;
                MessageTimer = _MessageTimer;
            }
        }

    }
}

