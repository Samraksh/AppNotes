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
    public partial class Program {

        // Set intervals, in ms
        private const int HelloInterval = 4000;     // How long till the next Hello message is sent (if in Hello state)
        private const int SensingInterval = 4000;   // How long till data is sensed and sent (if in Sensing state)
        private const int MessageTimeout = 1000;    // How long to wait before deciding a message has not received a response

        // Timers - all are one-shot (period of 0)
        private static readonly SimpleTimer HelloTimer = new SimpleTimer(HelloTimerCallback, null, HelloInterval);
        private static readonly SimpleTimer SensingTimer = new SimpleTimer(SensingTimerCallback, null, SensingInterval);

        // Define the radio and LCD
        private static SimpleCsmaRadio _csmaRadio;
        private static EmoteLcdUtil _lcd = new EmoteLcdUtil();

        // Misc definitions
        private static int _baseStationId = -1; // -1 means we haven't heard from the base station; else it contains the base station id
        private static int _messageSequence;    // Message sequence number
        private static readonly ArrayList MessageTimers = new ArrayList();  // A list of timers. Entries are populated wrt a particular sent message to check for timeouts.

        // Define the states and the current state variable
        private enum States { Hello, Sense };
        private static States _currState;

        private static readonly Random SensorSurrogate = new Random();

        private static double ReplyIntervalMin = double.MaxValue;
        private static double ReplyIntervalMax = double.MinValue;

        /// <summary>
        /// </summary>
        public static void Main() {
            Debug.EnableGCMessages(false); // We don't want to see garbage collector messages in the Output window

            Debug.Print(Resources.GetString(Resources.StringResources.ProgramName));

            // Set up LCD and display a welcome message
            _lcd.Display("S");
            Thread.Sleep(4000);

            // Convert the app identifier to a byte array
            _applicationIdBytes = Encoding.UTF8.GetBytes(ApplicationId);

            // Set up the radio for CSMA interaction
            //  The first two arguments are fairly standard but you're free to try changing them
            //  The last argument is the method to call when a message is received
            _csmaRadio = new SimpleCsmaRadio(140, TxPowerValue.Power_0Point7dBm, RadioReceive);

            // Start broadcasting Hello messages
            ChangeState(States.Hello);

            // Sleep forever ... everything from here on out is event-driven
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
            int numPackets = csma.GetPendingPacketCount();
            for (var packetNum = 0; packetNum < numPackets; packetNum++) {
                var rcvMsg = csma.GetNextPacket();
                if (rcvMsg == null) {
                    return;
                }
                var rcvPayloadBytes = rcvMsg.GetMessage();

                // Print message details
                Debug.Print("\nGot a " + (rcvMsg.Unicast ? "Unicast" : "Broadcast") + " message from src: " + rcvMsg.Src +
                            ", size: " + rcvMsg.Size + ", rssi: " + rcvMsg.RSSI + ", lqi: " + rcvMsg.LQI);

                // Check the app identifier
                for (var i = 0; i < ApplicationIdSize; i++) {
                    if (rcvPayloadBytes[ApplicationIdPos + i] != _applicationIdBytes[i]) {
                        return;
                    }
                }
                // Check the message type & cast mode
                if (rcvPayloadBytes[MessageTypePos] != (byte)PayloadTypes.Reply || !rcvMsg.Unicast) {
                    return;
                }

                // All is ok ... set the source ID of the base station
                _baseStationId = rcvMsg.Src;
                var rcvSeq = BitConverter.ToInt32(rcvPayloadBytes, MessageSequencePos);

                // Stop the message timer
                var messageFound = false;
                for (var i = 0; i < MessageTimers.Count; i++) {
                    var theTimer = (MessageTimer)MessageTimers[i];
                    // If not the one we're interested in, continue
                    if (theTimer.Sequence != rcvSeq) continue;
                    // Stop the timer
                    theTimer.SeqTimer.Stop();
                    // Calculate stats on reply time
                    double replyStopTime = DateTime.Now.Ticks - theTimer.StartTime;
                    ReplyIntervalMin = System.Math.Min(replyStopTime, ReplyIntervalMin);
                    ReplyIntervalMax = System.Math.Max(replyStopTime, ReplyIntervalMax);
                    Debug.Print("Time to receive reply: [" + ReplyIntervalMin + "," + replyStopTime + "," + ReplyIntervalMax + "]; timeout used: " + MessageTimeout);
                    // Note that the message was found
                    messageFound = true;
                }
                // If we didn't find it, just return ... this should never happen
                if (!messageFound) {
                    Debug.Print("\n***MessageTimer not found!");
                    return;
                }

                // Set the current state to Sense & begin sensing
                if (_currState != States.Sense) {
                    ChangeState(States.Sense);
                }
            }
        }

        private static void RadioSend(Addresses dest, PayloadTypes payloadType, byte[] sensedTimeDataPairs) {
            // No sending if unicast and if base station address not known
            if (dest != Addresses.BROADCAST && _baseStationId < 0) return;

            Debug.Print("Sending " + payloadType.ToString() + " message, sequence #: " + _messageSequence);

            // Create the message
            var msg = new byte[ApplicationIdSize + MessageTypeSize + MessageSequenceSize + MessageTimeSize + sensedTimeDataPairs.Length];
            byte currPos = 0;

            // Copy app identifier
            for (var i = 0; i < ApplicationIdSize; i++) {
                msg[currPos++] = _applicationIdBytes[i];
            }
            // Copy sensedTimeDataPairs type
            msg[currPos++] = (byte)payloadType;

            // Copy message sequence
            var messageSequenceBytes = BitConverter.GetBytes(_messageSequence);
            for (var i = 0; i < MessageSequenceSize; i++) {
                msg[currPos++] = messageSequenceBytes[i];
            }

            // Copy payload time
            var payloadTime = BitConverter.GetBytes(DateTime.Now.Ticks);
            for (var i = 0; i < MessageTimeSize; i++) {
                msg[currPos++] = payloadTime[i];
            }

            // Copy Time-Data Pairs
            for (var i = 0; i < sensedTimeDataPairs.Length; i++) {
                msg[currPos++] = sensedTimeDataPairs[i];
            }

            // Send the message
            var sendTime = DateTime.Now.Ticks;  // Save the (approx) send time so that we can get an idea of how long it takes to get a reply
            _csmaRadio.Send(dest, msg);


            // Set a timer for the message
            var messageTimerFound = false;
            var messageTimer = new SimpleTimer(MessageTimeoutCallback, _messageSequence, MessageTimeout);
            // If message timer slot is available, reuse it
            for (byte i = 0; i < (byte)MessageTimers.Count; i++) {
                if (!(((MessageTimer)MessageTimers[i]).SeqTimer).IsStopped) continue; // If not stopped, keep looking
                // Reuse the stopped timer
                MessageTimers[i] = new MessageTimer(_messageSequence, messageTimer, sendTime);
                messageTimerFound = true;
                break;
            }
            // If available message timer slot not available, create a new one
            if (!messageTimerFound) {
                // No null items found, so create new one
                MessageTimers.Add(new MessageTimer(_messageSequence, messageTimer, sendTime));
            }
            // Start the timer
            messageTimer.Start();
            Debug.Print("Number of message timers: " + MessageTimers.Count);

            // Increment the counter
            _messageSequence++;
        }

        private static void HelloTimerCallback(object obj) {
            if (_currState != States.Hello) {
                return;
            }

            RadioSend(Addresses.BROADCAST, PayloadTypes.Hello, BitConverter.GetBytes(DateTime.Now.Ticks));
            HelloTimer.Start();
        }


        private static void SensingTimerCallback(object obj) {
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

            RadioSend((Addresses)_baseStationId, PayloadTypes.Data, timeValueBytes);
            SensingTimer.Start();
        }


        private static void MessageTimeoutCallback(object obj) {
            Debug.Print("\n### Message timeout: " + (int)obj + "\n");
            // Stop all the timers
            foreach (var theMessageTimer in MessageTimers) {
                ((MessageTimer)theMessageTimer).SeqTimer.Stop();
            }
            // Go back to a Hello state
            ChangeState(States.Hello);
        }

        internal class MessageTimer {
            internal int Sequence { get; private set; }
            internal SimpleTimer SeqTimer { get; private set; }
            internal long StartTime { get; private set; }
            internal MessageTimer(int sequence, SimpleTimer seqTimer, long startTime) {
                Sequence = sequence;
                SeqTimer = seqTimer;
                StartTime = startTime;
            }
        }


        private static void ChangeState(States state) {
            Debug.Print("\nSwitching to state " + state);
            switch (state) {
                case States.Hello:
                    SensingTimer.Stop();
                    Debug.Print("HelloTimer.IsStopped: " + HelloTimer.IsStopped);
                    if (HelloTimer.IsStopped) {
                        HelloTimer.Start();
                    }
                    _currState = state;
                    break;
                case States.Sense:
                    HelloTimer.Stop();
                    Debug.Print("SensingTimer.IsStopped: " + SensingTimer.IsStopped);
                    if (SensingTimer.IsStopped) {
                        SensingTimer.Start();
                    }
                    _currState = state;
                    break;
            }
        }
    }
}