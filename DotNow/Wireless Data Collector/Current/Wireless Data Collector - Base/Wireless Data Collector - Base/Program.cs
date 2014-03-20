/*--------------------------------------------------------------------
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
using Samraksh.AppNote.WirelessDataCollector;
using Samraksh.SPOT.Net.Radio;
using Samraksh.SPOT.Net.Mac;

using Samraksh.AppNote.Utility;

namespace Samraksh.AppNote {
    /// <summary>
    ///     This program collects data from sensing nodes, with synchronized time.
    ///     A mote can be a base station node or a sensing node.
    ///     The base station listens for sensing node messages and collects the info. It makes adjustments for time differences
    ///     between base and sensing nodes, including clock drift.
    /// </summary>
    public partial class Program {

        // Define radio and LCD
        static SimpleCsmaRadio _csmaRadio;
        static readonly EmoteLcdUtil Lcd = new EmoteLcdUtil();

        // Define a hashtable that is used to store sensing node info for initial time
        static readonly Hashtable SensingNodes = new Hashtable();

        /// <summary>
        /// Set up the LCD and the radio, and other initialization.
        /// Sleeps when done; everything else is event driven.
        /// </summary>
        public static void Main() {
            Debug.EnableGCMessages(false);  // We don't want to see garbage collector messages in the Output window

            Debug.Print(Resources.GetString(Resources.StringResources.ProgramName));

            //var payloadIdentifierChar = ApplicationId.ToCharArray();
            Common.ApplicationIdBytes = System.Text.Encoding.UTF8.GetBytes(Common.ApplicationId);

            // Set up LCD and display a welcome message
            Lcd.Display("B");
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
        /// <remarks>
        /// If a Hello message, store the initial time
        /// If a Data message, convert sensing node time to base station time and report the data
        ///     Other things could be done with the data, of course, such as interpolating among sensors if that makes sense, sending to the PC for subsequent analysis, etc.
        /// </remarks>
        /// <param name="csma">A CSMA object that has the message info</param>
        static void RadioReceive(CSMA csma) {
            int numPackets = csma.GetPendingPacketCount();
            for (var packetNum = 0; packetNum < numPackets; packetNum++) {
                var baseReceivedTime = DateTime.Now.Ticks;
                var rcvMsg = csma.GetNextPacket();
                // Ignore null messages
                if (rcvMsg == null) {
                    return;
                }
                // Get the message
                var msgBytes = rcvMsg.GetMessage();

                // Print message details
                //  This is optional
                Debug.Print("Got a " + (rcvMsg.Unicast ? "Unicast" : "Broadcast") + " message from src: " +
                            rcvMsg.Src + ", size: " + rcvMsg.Size + ", rssi: " + rcvMsg.RSSI + ", lqi: " +
                            rcvMsg.LQI + "; packet #: " + packetNum + " of " + numPackets);

                // Convert the payload data, if it doesn't throw an exception
                //  This is optional
                try {
                    var rcvPayloadChar = System.Text.Encoding.UTF8.GetChars(msgBytes);
                    Debug.Print("   Payload [" + new string(rcvPayloadChar) + "]");
                }
                catch {
                    Debug.Print("   Payload: can't translate to chars");
                }

                // Process the message
                try {
                    // Check to be sure the message is for us
                    var rcvHeaderChar = System.Text.Encoding.UTF8.GetChars(msgBytes, 0, 2);
                    if (rcvMsg.Size < Common.PayloadHeaderSize || new string(rcvHeaderChar, 0, 2) != Common.ApplicationId) {
                        // not for us
                        Debug.Print("Message is not for us");
                        return;
                    }

                    // Get the time the message was sent (sensing node time scale)
                    var msgSentTime = BitConverter.ToInt64(msgBytes, Common.MessageTimePos);

                    // Check which kind of message it is
                    switch (msgBytes[Common.PayloadTypeSize]) {
                        // Hello message: send response & create or update the initial time pair
                        case (byte)Common.PayloadTypes.Hello: {
                                Debug.Print("\nReceived Hello, time " + msgSentTime.ToString() + ", seq " + BitConverter.ToInt32(msgBytes, Common.MessageSequencePos).ToString());

                                // Send the response, with the sequence number of the received message
                                SendResponse((Addresses)rcvMsg.Src, msgBytes, Common.MessageSequencePos, Common.MessageSequenceSize);

                                // Save the time we received the message (base node) & the time the message was sent (sensing node)
                                //  This adds a node if it's not present and otherwise replaces it
                                SensingNodes[rcvMsg.Src] = new InitialTimePair(baseReceivedTime, msgSentTime);
                                break;
                            }
                        // 
                        case (byte)Common.PayloadTypes.Data: {
                            Debug.Print("\nReceived Data, time " + msgSentTime.ToString() + ", seq " + BitConverter.ToInt32(msgBytes, Common.MessageSequencePos).ToString());

                                // If sensing node is not in our list, ignore
                                //  This should never happen
                                if (!SensingNodes.Contains(rcvMsg.Src)) {
                                    Debug.Print("\n*** Sensing Node not found: " + rcvMsg.Src);
                                    return;
                                }

                                // Send the response, with the sequence number of the received message
                                SendResponse((Addresses)rcvMsg.Src, msgBytes, Common.MessageSequencePos, Common.MessageSequenceSize);

                                // Adjust for time

                                // Get the initial time values
                                var initialTimePair = (InitialTimePair)SensingNodes[rcvMsg.Src];
                                var sensorInitialTime = initialTimePair.SensingNodeTime;
                                var baseInitialTime = initialTimePair.BaseTime;

                                // Calculate the relative difference between the base station and the sensing node times
                                var skew = (double)(msgSentTime - sensorInitialTime) / (double)(baseReceivedTime - baseInitialTime);

                                Debug.Print("\nSample received from " + rcvMsg.Src + ", sensorSendTime: " + msgSentTime + ", sensorInitialTime: " + sensorInitialTime +
                                    ", baseInitialTime:" + baseInitialTime + ", baseReceivedTime " + baseReceivedTime + ", skew: " + skew);

                                var currPos = Common.PayloadHeaderSize;    // Initialize the current position
                                while (currPos + Common.SampleTimeDataLen <= rcvMsg.Size) {
                                    var sensorSampleTime = BitConverter.ToInt64(msgBytes, currPos);
                                    currPos += Common.MessageTimeSize;
                                    var sensorSampleValue = BitConverter.ToInt32(msgBytes, currPos);
                                    currPos += Common.SampleDataSize;

                                    // Calculate sample time (base station time)
                                    //  We have initial time and message send time for the sensor mote
                                    //  We have initial time and message receive time for the base mote
                                    var baseSampleTime = (long)((double)(sensorSampleTime - sensorInitialTime) * skew + baseInitialTime);

                                    // Print the sample received
                                    Debug.Print("\nsampleTime: " + sensorSampleTime + ", adjSampleTime" + baseSampleTime + "sampleValue" + sensorSampleValue);
                                }
                                break;
                            }
                        default: {
                                return;
                            }
                    }
                }
                catch (Exception e) {
                    Debug.Print(e.ToString());
                }
            }
        }

        /// <summary>
        /// Send the response
        /// </summary>
        /// <param name="dest">Destination node id (or Broadcast)</param>
        /// <param name="payloadBytes">Array containing the payload</param>
        /// <param name="payloadPos">The position of the payload to begin</param>
        /// <param name="payloadLen">The number of bytes in the payload to use</param>
        static void SendResponse(Addresses dest, byte[] payloadBytes, int payloadPos, int payloadLen) {
            var payload = new byte[Common.ApplicationIdSize + Common.PayloadTypeSize + payloadLen];
            int currPos = 0;
            for (var i = 0; i < Common.ApplicationIdSize; i++) {
                payload[currPos++] = Common.ApplicationIdBytes[i];
            }
            payload[currPos++] = (byte)Common.PayloadTypes.Reply;
            for (var i = 0; i < payloadLen; i++) {
                payload[currPos++] = payloadBytes[payloadPos + i];
            }
            _csmaRadio.Send(dest, payload);
        }

        /// <summary>
        /// An initial time pair, containing the base station and the sensing node times when a Hello message is received
        /// </summary>
        internal class InitialTimePair {
            internal long BaseTime { get; private set; }
            internal long SensingNodeTime { get; private set; }
            internal InitialTimePair(long baseTime, long sensingTime) {
                BaseTime = baseTime;
                SensingNodeTime = sensingTime;
            }
        }

    }
}

