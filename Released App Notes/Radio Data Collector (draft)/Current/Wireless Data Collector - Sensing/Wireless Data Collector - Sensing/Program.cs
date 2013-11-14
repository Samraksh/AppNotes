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
using Samraksh.AppNote.Utility;
using Samraksh.SPOT.Net;
using Samraksh.SPOT.Net.Mac;
using Samraksh.SPOT.Net.Radio;

namespace Samraksh.AppNote {
    /// <summary>
    ///     This program collects data from sensing nodes, with synchronized time.
    ///     A mote can be a base station node or a sensing node.
    ///     The base station listens for sensing node messages and collects the info. It makes adjustments for time differences
    ///     between base and sensing nodes, including clock drift.
    /// </summary>
    public class Program {

        // These must be the same in Base and Sensing programs
        private const string PayloadIdentifier = "DC";
        private enum MsgTypes : byte { Hello, Reply, Data };

        private static readonly int PayloadIdentifierSize = PayloadIdentifier.Length;
        private static readonly int PayloadTypeSize = sizeof(MsgTypes);
        private const int PayloadSequenceSize = sizeof(int);
        private const int PayloadTimeSize = sizeof(long);
        private static readonly int PayloadHeaderSize = PayloadIdentifierSize + PayloadTypeSize + PayloadSequenceSize + PayloadTimeSize;

        private const int PayloadIdentifierPos = 0;
        private static readonly int PayloadTypePos = PayloadIdentifierPos + PayloadIdentifierSize;
        private static readonly int PayloadSequencePos = PayloadTypePos + PayloadTypeSize;
        private static readonly int PayloadTimePos = PayloadSequencePos + PayloadSequenceSize;


        private const int PayloadDataSize = sizeof(int);
        private const int PayloadTimeDataSize = PayloadTimeSize + PayloadDataSize;
        private static byte[] _payloadIdentifierBytes = new byte[PayloadIdentifierSize];



        private const int HelloInterval = 4000;
        private const int SensingInterval = 4000;
        private const int MessageTimeout = 1000;

        // Timers - all are one-shot (period of 0)
        private static readonly SimpleTimer HelloTimer = new SimpleTimer(HelloCallback, null, HelloInterval);
        private static readonly SimpleTimer SensingTimer = new SimpleTimer(SensingCallback, null, SensingInterval);

        private static SimpleCsmaRadio _csmaRadio;
        private static EmoteLCDUtil _lcd = new EmoteLCDUtil();
        private static byte[] _appIdentifierBytes;
        private static byte _appIdentifierSize;
        private static int _baseStationId = -1;
        private static int _messageSequence;
        private static readonly ArrayList MessageTimers = new ArrayList();
        private static byte[] _emptyBytes;

        private static States _currState = States.Hello;
        private static readonly Random SensorSurrogate = new Random();



        /// <summary>
        /// </summary>
        public static void Main() {
            Debug.EnableGCMessages(false); // We don't want to see garbage collector messages in the Output window

            Debug.Print(Resources.GetString(Resources.StringResources.ProgramName));

            // Set up LCD and display a welcome message
            _lcd = new EmoteLCDUtil();
            _lcd.Display("S");
            Thread.Sleep(4000);

            // Convert the app identifier to a byte array
            _appIdentifierBytes = Encoding.UTF8.GetBytes(PayloadIdentifier);
            _appIdentifierSize = (byte)_appIdentifierBytes.Length;
            _emptyBytes = new byte[0];

            // Set up the radio for CSMA interaction
            //  The first two arguments are fairly standard but you're free to try changing them
            //  The last argument is the method to call when a message is received
            _csmaRadio = new SimpleCsmaRadio(140, TxPowerValue.Power_0Point7dBm, RadioReceive);

            // Start broadcasting Hello messages
            HelloCallback(null);

            // Sleep forever
            Thread.Sleep(Timeout.Infinite);
        }

        /// <summary>
        ///     Handle a received message
        /// </summary>
        /// <remarks>
        ///     We are only interested in messages that
        ///     1. Have the right app identifier.
        ///     2. Have the right message type.
        ///     3. Are unicast.
        ///     These messages must be from the base station as it is the only one that would be unicasting to this node.
        /// </remarks>
        /// <param name="csma">A CSMA object that has the message info</param>
        private static void RadioReceive(CSMA csma) {
            var rcvMsg = csma.GetNextPacket();
            if (rcvMsg == null) {
                return;
            }
            var rcvPayloadBytes = rcvMsg.GetMessage();

            // Print message details
            Debug.Print("Got a " + (rcvMsg.Unicast ? "Unicast" : "Broadcast") + " message from src: " + rcvMsg.Src +
                        ", size: " + rcvMsg.Size + ", rssi: " + rcvMsg.RSSI + ", lqi: " + rcvMsg.LQI);

            //var rcvPayloadByteStr = new StringBuilder("  Payload [");
            //for (var i = 0; i < rcvPayloadBytes.Length; i++) {
            //    rcvPayloadByteStr.Append(rcvPayloadBytes + " ");
            // }
            //rcvPayloadByteStr.Append("]");
            //Debug.Print(rcvPayloadByteStr.ToString());

            // Check the app identifier
            for (var i = 0; i < _appIdentifierSize; i++) {
                if (rcvPayloadBytes[PayloadIdentifierPos + i] != _appIdentifierBytes[i]) {
                    return;
                }
            }
            // Check the message type & cast mode
            if (rcvPayloadBytes[PayloadTypePos] != (byte)MsgTypes.Reply || !rcvMsg.Unicast) {
                return;
            }

            // All is ok ... set the source ID of the base station
            _baseStationId = rcvMsg.Src;
            var rcvSeq = BitConverter.ToInt32(rcvPayloadBytes, PayloadSequencePos);

            // Stop the message timer
            var messageFound = false;
            for (var i = 0; i < MessageTimers.Count; i++) {
                if (((MessageTimer)MessageTimers[i]).Sequence != rcvSeq) continue;
                ((MessageTimer)MessageTimers[i]).SeqTimer.Stop();
                messageFound = true;
            }
            // If we didn't find it, just return ... this should never happen
            if (!messageFound) {
                Debug.Print("MessageTimer not found!");
                return;
            }

            // Set the current state to Sense & begin sensing
            _currState = States.Sense;
            SensingCallback(null);
        }

        private static void RadioSend(Addresses dest, MsgTypes msgType, byte[] payload) {
            if (dest != Addresses.BROADCAST) {
                if (_baseStationId < 0) {
                    // No sending if unicast and if base station address not known
                    return;
                }
            }

            Debug.Print("Sending " + msgType.ToString() + " message, sequence #: " + _messageSequence);

            // Create the message
            var msg = new byte[_appIdentifierSize + PayloadTypeSize + PayloadSequencePos + payload.Length];
            byte currPos = 0;

            // Copy app identifier
            for (var i = 0; i < _appIdentifierSize; i++) {
                msg[currPos++] = _appIdentifierBytes[i];
            }
            // Copy message type
            msg[currPos++] = (byte)msgType;

            // Copy message sequence
            var messageSequenceBytes = BitConverter.GetBytes(_messageSequence);
            for (var i = 0; i < PayloadSequenceSize; i++) {
                msg[currPos++] = messageSequenceBytes[i];
            }

            // Copy payload
            for (var i = 0; i < payload.Length; i++) {
                msg[currPos++] = payload[i];
            }

            // Send the message
            _csmaRadio.Send(dest, msg);

            // Set a timer for the message
            var messageTimerFound = false;
            var messageTimer = new SimpleTimer(MessageTimeoutCallback, _messageSequence, MessageTimeout);
            // If message timer slot is available, reuse it
            for (byte i = 0; i < (byte)MessageTimers.Count; i++) {
                if (!((MessageTimer)MessageTimers[i]).SeqTimer.IsStopped) continue; // If not stopped, keep looking
                // Reuse the stopped timer
                MessageTimers[i] = new MessageTimer(_messageSequence, messageTimer);
                messageTimerFound = true;
                break;
            }
            // If available message timer slot not available, create a new one
            if (!messageTimerFound) {
                // No null items found, so create new one
                MessageTimers.Add(new MessageTimer(_messageSequence, messageTimer));
            }
            // Start the TheTimer
            messageTimer.Start();
            Debug.Print("Number of message timers: " + MessageTimers.Count);

            // Increment the counter
            _messageSequence++;
        }

        private static void HelloCallback(object obj) {
            if (_currState != States.Hello) {
                return;
            }
            RadioSend(Addresses.BROADCAST, MsgTypes.Hello, BitConverter.GetBytes(DateTime.Now.Ticks));
            HelloTimer.Start();
        }


        private static void SensingCallback(object obj) {
            if (_currState != States.Sense) {
                return;
            }
            if (_baseStationId < 0) {
                return;
            }
            var sensedValue = SensorSurrogate.Next();
            var sensedTimeBytes = BitConverter.GetBytes(DateTime.Now.Ticks);
            var sensedValueBytes = BitConverter.GetBytes(sensedValue);
            var timeValueBytes = new byte[sensedTimeBytes.Length + sensedValueBytes.Length];
            var currPos = 0;
            for (var i = 0; i < sensedTimeBytes.Length; i++) {
                timeValueBytes[currPos++] = sensedTimeBytes[i];
            }
            for (var i = 0; i < sensedValueBytes.Length; i++) {
                timeValueBytes[currPos++] = sensedValueBytes[i];
            }

            RadioSend((Addresses)_baseStationId, MsgTypes.Data, timeValueBytes);
            SensingTimer.Start();
        }


        private static void MessageTimeoutCallback(object obj) {
            Debug.Print("Message timeout: " + (int)obj);
            // Kill all the timers
            foreach (var theMessageTimer in MessageTimers) {
                ((MessageTimer)theMessageTimer).SeqTimer.Stop();
            }
            // Go back to a listening state
            _currState = States.Hello;
        }

        internal class MessageTimer {
            internal int Sequence { get; private set; }
            internal SimpleTimer SeqTimer { get; private set; }
            internal MessageTimer(int sequence, SimpleTimer seqTimer) {
                Sequence = sequence;
                SeqTimer = seqTimer;
            }
        }


        private enum States {
            Hello,
            Sense
        };
    }
}