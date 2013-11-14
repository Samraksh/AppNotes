﻿/*--------------------------------------------------------------------
 * Wireless Data Collector: app note for the eMote .NOW 1.0
 * Base Node
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *  1.0: initial release
---------------------------------------------------------------------*/

using System;
using System.Collections;
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

    /*------------------------------------------------------------------------
     * Message Formats
     * 
     * Hello
     *      App Identifier (2)
     *      Message Type (1) : Hello
     *      Message Sequence Number (4)
     *      Message Send Time (8)
     *  Data
     *      App Identifier (2)
     *      Message Type (1) : Data
     *      Message Sequence Number (4)
     *      Message Send Time (8)
     *      
     *      Data Sense Time 1 (8)
     *      Data Sensed 1 (4)
     *          ...
     *      Data Sensed Time N (8)
     *      Data Sensed N (4)
     *  Reply
     *      App Identifier (2)
     *      Message Type (1) : Reply
     *      Message Sequence Number (4)
     * ---------------------------------------------------------------------*/

    /// <summary>
    /// This program collects data from sensing nodes, with synchronized time.
    /// The base station listens for sensing node messages and collects the info. It makes adjustments for time differences between base and sensing nodes, including clock drift.
    /// </summary>
    public class Program {

        // These must be the same in Base and Sensing programs
        const string PayloadIdentifier = "DC";
        enum MsgTypes : byte { Hello, Reply, Data };

        private static readonly int PayloadIdentifierSize = PayloadIdentifier.Length;
        private static readonly int PayloadTypeSize = sizeof(MsgTypes);
        private const int PayloadSequenceSize = sizeof(int);
        private const int PayloadTimeSize = sizeof(long);
        private static readonly int PayloadHeaderSize = PayloadIdentifierSize + PayloadTypeSize + PayloadSequenceSize + PayloadTimeSize;
        private static readonly int PayloadSequencePos = PayloadIdentifierSize + PayloadTypeSize;
        private static readonly int PayloadTimePos = PayloadIdentifierSize + PayloadTypeSize + PayloadSequenceSize;

        private const int PayloadDataSize = sizeof(int);
        private const int PayloadTimeDataSize = PayloadTimeSize + PayloadDataSize;
        private static byte[] _payloadIdentifierBytes = new byte[PayloadIdentifierSize];

        static SimpleCsmaRadio _csmaRadio;
        static EmoteLcdUtil lcd = new EmoteLcdUtil();
        static SensingNodes _sensingNodes = new SensingNodes();

        /// <summary>
        /// 
        /// </summary>
        public static void Main() {

            Debug.EnableGCMessages(false);  // We don't want to see garbage collector messages in the Output window

            Debug.Print(Resources.GetString(Resources.StringResources.ProgramName));

            //var payloadIdentifierChar = PayloadIdentifier.ToCharArray();
            _payloadIdentifierBytes = System.Text.Encoding.UTF8.GetBytes(PayloadIdentifier);


            // Set up LCD and display a welcome message
            lcd.Display("B");
            Thread.Sleep(4000);

            // Set up the radio for CSMA interaction
            //  The first two arguments are fairly standard but you're free to try changing them
            //  The last argument is the method to call when a message is received
            _csmaRadio = new SimpleCsmaRadio(140, TxPowerValue.Power_0Point7dBm, RadioReceive);

            // As base station node, just listen for incoming messages & respond
            Thread.Sleep(Timeout.Infinite);
        }

        /// <summary>
        /// Handle a received message
        /// </summary>
        /// <param name="csma">A CSMA object that has the message info</param>
        static void RadioReceive(CSMA csma) {
            int numPackets = csma.GetPendingPacketCount();
            for (var packetNum = 0; packetNum < numPackets; packetNum++) {
                var msgReceivedTime = DateTime.Now.Ticks; // Should get from MAC layer ...
                var rcvMsg = csma.GetNextPacket();
                var rcvPayloadBytes = rcvMsg.GetMessage();
                try {
                    var rcvPayloadChar = System.Text.Encoding.UTF8.GetChars(rcvPayloadBytes);
                    {
                        Debug.Print("Got a " + (rcvMsg.Unicast ? "Unicast" : "Broadcast") + " message from src: " +
                                    rcvMsg.Src + ", size: " + rcvMsg.Size + ", rssi: " + rcvMsg.RSSI + ", lqi: " +
                                    rcvMsg.LQI);
                        Debug.Print("   Payload [" + new string(rcvPayloadChar) + "]");
                    }
                    if (rcvMsg.Size < PayloadHeaderSize || new string(rcvPayloadChar, 0, 2) != PayloadIdentifier) {
                        // not for us
                        return;
                    }
                    var msgSentTime = BitConverter.ToInt64(rcvPayloadBytes, PayloadTimePos);

                    switch (rcvPayloadBytes[2]) {
                        case (byte)MsgTypes.Hello: {
                                Debug.Print("\nReceived Hello, time " + msgSentTime.ToString() + ", seq " + BitConverter.ToInt32(rcvPayloadBytes, PayloadSequencePos).ToString());
                                // Send the response
                                SendResponse(rcvMsg.Src, rcvPayloadBytes, PayloadSequencePos, PayloadSequenceSize);
                                // Add or replace the node
                                _sensingNodes[rcvMsg.Src] = new InitialTimePair(msgReceivedTime, msgSentTime);
                                //_sensingNodes.Add(rcvMsg.Src, new InitialTimePair(messageReceiveTime, msgSentTime));
                                break;
                            }
                        case (byte)MsgTypes.Data: {
                                Debug.Print("\nReceived Data, time " + msgSentTime.ToString() + ", seq " + BitConverter.ToInt32(rcvPayloadBytes, PayloadSequencePos).ToString());
                                // If sensing node is not in our list, ignore ... this should never happen
                                if (!_sensingNodes.Contains(rcvMsg.Src)) {
                                    return;
                                }
                                // Send the response
                                SendResponse(rcvMsg.Src, rcvPayloadBytes, PayloadSequencePos, PayloadSequenceSize);
                                // Payload is 8 bytes of time followed by pairs of [sample time (8 bytes), sample value (4 bytes)]
                                var sensorSendtime = BitConverter.ToInt64(rcvPayloadBytes, 3);

                                // Get the initial time values
                                var initialTimePair = _sensingNodes[rcvMsg.Src];
                                var sensorInitialTime = initialTimePair.SensingNodeTime;
                                var baseInitialTime = initialTimePair.BaseTime;
                                Debug.Print("Sample received from " + rcvMsg.Src + ", sensor initial time: " + sensorInitialTime + ", base initial time:" + baseInitialTime);
                                var currPos = PayloadHeaderSize;

                                while (currPos + PayloadTimeDataSize < rcvMsg.Size) {
                                    var sampleTime = BitConverter.ToInt64(rcvPayloadBytes, currPos);
                                    var sampleValue = BitConverter.ToInt32(rcvPayloadBytes, currPos + PayloadTimeSize);

                                    // Adjust for time
                                    //  We have initial time and message send time for the sensor mote
                                    //  We have initial time and message receive time for the base mote
                                    //
                                    var adjustmentFactor = (double)(sampleTime - sensorInitialTime) / (double)(msgReceivedTime - baseInitialTime);
                                    var adjustedSampleTime = (long)((double)sampleTime * adjustmentFactor);
                                    // Print the sample received
                                    Debug.Print("  Adjustment factor: " + adjustmentFactor + ", adjusted sample time:" + adjustedSampleTime + ", sample: " + sampleValue);

                                }

                                break;
                            }
                        default: {
                                break;
                            }
                    }
                }
                catch (Exception e) {
                    Debug.Print(e.ToString());
                }
            }
        }

        static void SendResponse(int dest, byte[] payloadBytes, int payloadPos, int payloadLen) {
            var payload = new byte[PayloadIdentifierSize + PayloadTypeSize + payloadLen];
            int currPos = 0;
            for (var i = 0; i < PayloadIdentifierSize; i++) {
                payload[currPos++] = _payloadIdentifierBytes[i];
            }
            payload[currPos++] = (byte)MsgTypes.Reply;
            for (var i = 0; i < payloadLen; i++) {
                payload[currPos++] = payloadBytes[payloadPos + i];
            }
            _csmaRadio.Send((Addresses)dest, payload);
        }

        internal class InitialTimePair {
            internal long BaseTime { get; private set; }
            internal long SensingNodeTime { get; private set; }
            internal InitialTimePair(long baseTime, long sensingTime) {
                BaseTime = baseTime;
                SensingNodeTime = sensingTime;
            }
        }

        internal class SensingNodes : Hashtable {
            internal void Add(int _nodeID, InitialTimePair _initialTimePair) {
                base.Add(_nodeID, _initialTimePair);
            }
            internal InitialTimePair this[int key] {
                get {
                    return (InitialTimePair)base[key];
                }
                set {
                    base[key] = value;
                }
            }
        }

    }
}

