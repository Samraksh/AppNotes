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
    /// The base station listens for sensing node messages and collects the info. It makes adjustments for time differences between base and sensing nodes, including clock drift.
    /// </summary>
    public class Program {

        // These must be the same in Base and Sensing programs
        const string APP_IDENTIFIER = "DC";
        enum MsgTypes : byte { Hello, Reply, Data };

        static SimpleCsmaRadio csmaRadio;
        static EmoteLCDUtil lcd = new EmoteLCDUtil();
        static SensingNodes sensingNodes = new SensingNodes();


        /// <summary>
        /// 
        /// </summary>
        public static void Main() {

            Debug.EnableGCMessages(false);  // We don't want to see garbage collector messages in the Output window

            Debug.Print(Resources.GetString(Resources.StringResources.ProgramName));

            // Set up LCD and display a welcome message
            lcd.Display("Hola");
            Thread.Sleep(4000);

            // Set up the radio for CSMA interaction
            //  The first two arguments are fairly standard but you're free to try changing them
            //  The last argument is the method to call when a message is received
            csmaRadio = new SimpleCsmaRadio(140, TxPowerValue.Power_0Point7dBm, RadioReceive);

            // As base station node, just listen for incoming messages & respond
            Thread.Sleep(Timeout.Infinite);
        }

        /// <summary>
        /// Handle a received message
        /// </summary>
        /// <param name="csma">A CSMA object that has the message info</param>
        static void RadioReceive(CSMA csma) {
            int numPackets = csma.GetPendingPacketCount();
            for (int packetNum = 0; packetNum < numPackets; packetNum++) {
                long messageReceiveTime = DateTime.Now.Ticks; // Should get from MAC layer ...
                Message rcvMsg = csma.GetNextPacket();
                byte[] rcvPayloadBytes = rcvMsg.GetMessage();
                char[] rcvPayloadChar = System.Text.Encoding.UTF8.GetChars(rcvPayloadBytes);
                try {
                    Debug.Print("Got a " + (rcvMsg.Unicast ? "Unicast" : "Broadcast") + " message from src: " + rcvMsg.Src + ", size: " + rcvPayloadBytes + ", rssi: " + rcvMsg.RSSI + ", lqi: " + rcvMsg.LQI);
                    Debug.Print("   Payload [" + new string(rcvPayloadChar) + "]");
                    if (new string(rcvPayloadChar, 0, 2) != APP_IDENTIFIER) {
                        // not for us
                        return;
                    }
                    switch (rcvPayloadBytes[2]) {
                        case (byte)MsgTypes.Hello: {
                                // Send the response
                                SendResponse(rcvMsg.Src);
                                // Payload is 8 bytes of time
                                long sendTime = BitConverter.ToInt64(rcvPayloadBytes, 3);
                                // Add or replace the node
                                sensingNodes.Add(rcvMsg.Src, new InitialTimePair(messageReceiveTime, sendTime));
                                break;
                            }
                        case (byte)MsgTypes.Data: {
                                // If sensing node is not in our list, ignore ... this should never happen
                                if (!sensingNodes.Contains(rcvMsg.Src)) {
                                    return;
                                }
                                // Send the response
                                SendResponse(rcvMsg.Src);
                                // Payload is 8 bytes of time followed by pairs of [sample time (8 bytes), sample value (4 bytes)]
                                long sensorSendtime = BitConverter.ToInt64(rcvPayloadBytes, 3);
                                int numPairs = (rcvPayloadBytes.Length - (3 + 8)) / (8 + 4);
                                long sampleTime;
                                int sampleValue;

                                // Get the initial time values
                                InitialTimePair initialTimePair = sensingNodes[rcvMsg.Src];
                                long sensorInitialTime = initialTimePair.sensingNodeTime;
                                long baseInitialTime = initialTimePair.baseTime;
                                Debug.Print("Sample received from " + rcvMsg.Src + ", sensor initial time: " + sensorInitialTime + ", base initial time:" + baseInitialTime);
                                for (int i = 0; i < numPairs; i++) {
                                    sampleTime = BitConverter.ToInt64(rcvPayloadBytes, (3 + 8) + (8 + 4) * i);
                                    sampleValue = BitConverter.ToInt32(rcvPayloadBytes, (3 + 8) + ((8 + 4) * i) + 8);

                                    // Adjust for time
                                    //  We have initial time and message send time for the sensor mote
                                    //  We have initial time and message receive time for the base mote
                                    //
                                    //  adjustmentFactor = (sendSensor - initialSensor) / (receiveBase - initialBase)
                                    //  sampleTimeAdjusted = sampleTime * adjustmentFactor
                                    double adjustmentFactor = (double)(sampleTime - sensorInitialTime) / (double)(messageReceiveTime - baseInitialTime);
                                    long adjustedSampleTime = (long)((double)sampleTime * adjustmentFactor);
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

        static void SendResponse(int dest) {
            byte[] payload = new byte[1];
            payload[0] = (byte)MsgTypes.Reply;
            csmaRadio.Send((Addresses)dest, payload);
        }

        internal class InitialTimePair {
            internal long baseTime { get; private set; }
            internal long sensingNodeTime { get; private set; }
            internal InitialTimePair(long _baseTime, long _sensingTime) {
                baseTime = _baseTime;
                sensingNodeTime = _sensingTime;
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

