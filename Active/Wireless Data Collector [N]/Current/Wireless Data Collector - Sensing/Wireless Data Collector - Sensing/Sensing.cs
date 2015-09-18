/*--------------------------------------------------------------------
 * Radio Data Collector: app note for the eMote .NOW 1.1
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *  1.0: initial release
 *  1.1: added member doc, revised namespace structure
 *  1.2: Updated dlls based on eMote ver. 4.3.0.13 (Sep 18, 2015)
---------------------------------------------------------------------*/

#define Show_Reply_Time

using System;
using System.Text;
using System.Threading;
using Microsoft.SPOT;

using Samraksh.AppNote.Utility;

using Samraksh.eMote.Net;
using Samraksh.eMote.Net.Mac;
using Samraksh.eMote.Net.Radio;

namespace Samraksh {
    namespace AppNote {
        namespace WirelessDataCollector {
            namespace Sensing {
                /// <summary>
                ///     This program collects data from sensing nodes, with synchronized time.
                ///     A mote can be a base station node or a sensing node.
                ///     The base station listens for sensing node messages and collects the info. It makes adjustments for time differences
                ///     between base and sensing nodes, including clock drift.
                /// </summary>
                public partial class Program {

                    // Set intervals, in ms
                    // HelloInterval and SensingInterval should be larger than TimeoutInterval
                    //  Otherwise it might happen that two or more messages are sent before the first one's response times out.
                    private const int HelloInterval = 4000;
                    // How long till the next Hello message is sent (if in Hello state)

                    private const int SensingInterval = 4000;
                    // How long till data is sensed and sent (if in Sensing state)

                    private const int TimeoutInterval = 1000;
                    // How long to wait before deciding a message has not received a response

                    // Timers - all are one-shot (period of 0)
                    private static readonly SimpleTimer HelloTimer = new SimpleTimer(HelloTimerCallback, null,
                        HelloInterval);

                    private static readonly SimpleTimer SensingTimer = new SimpleTimer(SensingTimerCallback, null,
                        SensingInterval);

                    private static readonly SimpleTimer TimeoutTimer = new SimpleTimer(MessageTimeoutCallback, null,
                        TimeoutInterval);

                    // Define the radio and LCD
                    private static SimpleCsmaRadio _csmaRadio;
                    private static readonly EmoteLcdUtil Lcd = new EmoteLcdUtil();

                    // Misc definitions
                    private static int _baseStationId = -1;
                    // -1 means we haven't heard from the base station; else it contains the base station id

                    private static int _messageSequence; // Message sequence number

                    // Define the states and the current state variable
                    private enum States {
                        Hello,
                        Sense
                    };

                    private static States _currState;

                    // In place of actual sampling, use a random number generator as a surrogate
                    private static readonly Random SensorSurrogate = new Random();

#if Show_Reply_Time
                    // Keep stats on reply time
                    //  This is optional and can be bypassed by removing the #define at the top
                    private static double _replyMsMin = double.MaxValue;
                    private static double _replyMsMax = double.MinValue;
#endif

                    /// <summary>
                    /// Set up the LCD and the radio, and other initialization.
                    /// Sleeps when done; everything else is event driven.
                    /// </summary>
                    public static void Main() {
                        Debug.EnableGCMessages(false);
                        // We don't want to see garbage collector messages in the Output window

                        Debug.Print(Resources.GetString(Resources.StringResources.ProgramName));

                        // Set up LCD and display a welcome message
                        Lcd.Display("S");
                        Thread.Sleep(4000);

                        // Convert the app identifier to a byte array
                        Common.ApplicationIdBytes = Encoding.UTF8.GetBytes(Common.ApplicationId);

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
                            // Ignore null messages
                            if (rcvMsg == null) {
                                return;
                            }

                            // Get the message
                            var msgBytes = rcvMsg.GetMessage();

                            // Print message details
                            //  This is optional
                            Debug.Print("\nGot a " + (rcvMsg.Unicast ? "Unicast" : "Broadcast") + " message from src: " +
                                        rcvMsg.Src +
                                        ", size: " + rcvMsg.Size + ", rssi: " + rcvMsg.RSSI + ", lqi: " + rcvMsg.LQI);

                            // Check the message type & cast mode
                            if (msgBytes[Common.PayloadTypePos] != (byte)Common.PayloadTypes.Reply || !rcvMsg.Unicast) {
                                return;
                            }

                            // Check the app identifier
                            for (var i = 0; i < Common.ApplicationIdSize; i++) {
                                if (msgBytes[Common.ApplicationIdPos + i] != Common.ApplicationIdBytes[i]) {
                                    return;
                                }
                            }

                            // All is ok ... set the source ID of the base station
                            _baseStationId = rcvMsg.Src;

                            // Stop the message timer
                            TimeoutTimer.Stop();

                            // Turn the radio off
                            Debug.Print("\nTurn Radio OFF\n");
                            _csmaRadio.SetRadioState(SimpleCsmaRadio.RadioStates.Off);

                            // Set the current state to Sense & begin sensing
                            if (_currState != States.Sense) {
                                ChangeState(States.Sense);
                            }

#if Show_Reply_Time
                            // Calculate stats on reply time ... this is optional and can be bypassed by removing the #define at the top
                            var currTicks = DateTime.Now.Ticks;
                            var replyTicks = currTicks - TimeoutTimer.StartTime;
                            double replyMs = TicksToMs(replyTicks);
                            _replyMsMin = System.Math.Min(replyMs, _replyMsMin);
                            _replyMsMax = System.Math.Max(replyMs, _replyMsMax);
                            Debug.Print("Time to receive reply: [" + (long)_replyMsMin + "," + (long)replyMs + "," +
                                        (long)_replyMsMax + "]; timeout value used: " + TimeoutInterval +
                                        "; curr time: " +
                                        (long)currTicks + "; timer start time: " + TimeoutTimer.StartTime);
#endif
                        }
                    }

                    /// <summary>
                    /// Send a message and start timeout timer
                    /// </summary>
                    /// <param name="dest">Destination</param>
                    /// <param name="payloadType">Type of payload</param>
                    /// <param name="payloadData">Byte array of payload data</param>
                    private static void RadioSend(Addresses dest, Common.PayloadTypes payloadType, byte[] payloadData) {
                        // No sending if unicast and if base station address not known
                        if (dest != Addresses.BROADCAST && _baseStationId < 0) return;

                        Debug.Print("Sending " + payloadType.ToString() + " message, sequence #: " + _messageSequence);

                        // Create the message
                        var msg =
                            new byte[
                                Common.ApplicationIdSize + Common.PayloadTypeSize + Common.MessageSequenceSize + Common.MessageTimeSize +
                                payloadData.Length];
                        var currPos = 0;
                        // Copy app identifier
                        Common.ApplicationIdBytes.CopyTo(msg, currPos);
                        currPos += Common.ApplicationIdBytes.Length;
                        // Copy payloadData type
                        msg[currPos] = (byte)payloadType;
                        currPos++;
                        // Copy message sequence
                        var messageSequenceBytes = BitConverter.GetBytes(_messageSequence);
                        messageSequenceBytes.CopyTo(msg, currPos);
                        currPos += messageSequenceBytes.Length;
                        // Copy payload time
                        var payloadTime = BitConverter.GetBytes(DateTime.Now.Ticks);
                        payloadTime.CopyTo(msg, currPos);
                        currPos += payloadTime.Length;
                        // Copy payload data
                        payloadData.CopyTo(msg, currPos);

                        // Turn on the radio and send the message
                        //  Lock in order to prevent race conditions
                        lock (_csmaRadio) {
                            Debug.Print("\nTurn Radio ON\n");
                            var result = _csmaRadio.SetRadioState(SimpleCsmaRadio.RadioStates.On);
                            if (result != DeviceStatus.Success) {
                                throw new Exception("Could not turn radio on to send");
                            }
                            _csmaRadio.Send(dest, msg);
                        }

                        // Start the timeout timer
                        TimeoutTimer.Start();

                        // Increment the counter
                        _messageSequence++;
                    }

                    /// <summary>
                    /// Callback for Hello message timer
                    /// </summary>
                    /// <remarks>The timer is one-shot, so it has to be restarted if desired.</remarks>
                    /// <param name="obj">(ignored)</param>
                    private static void HelloTimerCallback(object obj) {
                        // Ignore the callback if our current state is not Hello
                        //  Since the timer is one-shot, it won't fire again until we re-enter the Hello state.
                        if (_currState != States.Hello) {
                            return;
                        }
                        // Otherwise, send Hello message and (re)start the timer
                        RadioSend(Addresses.BROADCAST, Common.PayloadTypes.Hello, new byte[0]);
                        HelloTimer.Start();
                    }

                    /// <summary>
                    /// Handle a tick of the sensing timer
                    /// </summary>
                    /// <remarks>The timer is one-shot, so it has to be restarted if desired.</remarks>
                    /// <param name="obj">(ignored)</param>
                    private static void SensingTimerCallback(object obj) {
                        // Ignore the callback if our current state is not Sense
                        //  Since the timer is one-shot, it won't fire again until we re-enter the Sense state.
                        if (_currState != States.Sense) {
                            return;
                        }
                        // Also ignore if we haven't heard yet from the base station.
                        //  This should not occur
                        if (_baseStationId < 0) {
                            return;
                        }
                        // Get a sensed value and set it up to send
                        var sensedValue = SensorSurrogate.Next();
                        // Generate a random value. This could be replace with real sensing.
                        var sensedTimeBytes = BitConverter.GetBytes(DateTime.Now.Ticks);
                        // Get the current time as a byte vector
                        var sensedValueBytes = BitConverter.GetBytes(sensedValue);
                        // Convert the sensed value to a byte array
                        var timeValueBytes = new byte[sensedTimeBytes.Length + sensedValueBytes.Length];
                        // Copy the two byte arrays into a composite one to send
                        sensedTimeBytes.CopyTo(timeValueBytes, 0);
                        sensedValueBytes.CopyTo(timeValueBytes, sensedTimeBytes.Length);
                        // Send the sensed value
                        RadioSend((Addresses)_baseStationId, Common.PayloadTypes.Data, timeValueBytes);
                        // Restart the sensing timer
                        SensingTimer.Start();
                    }

                    /// <summary>
                    /// Handle a message timeout
                    /// </summary>
                    /// <remarks>The timer is one-shot, so it has to be restarted if desired.</remarks>
                    /// <param name="obj">(ignored)</param>
                    private static void MessageTimeoutCallback(object obj) {
                        Debug.Print("\n### Message timeout\n");

                        // Stop the timer
                        TimeoutTimer.Stop();

                        // Turn off the radio
                        lock (_csmaRadio) {
                            Debug.Print("\nTurn Radio OFF\n");
                            _csmaRadio.SetRadioState(SimpleCsmaRadio.RadioStates.Off);
                        }

                        // Go back to a Hello state
                        ChangeState(States.Hello);
                    }

                    /// <summary>
                    /// Change between Hello and Sense states
                    /// </summary>
                    /// <param name="state">New state</param>
                    private static void ChangeState(States state) {
                        Debug.Print("\nSwitching to state " + state);
                        switch (state) {
                            // Hello state
                            case States.Hello:
                                // Be sure sensing timer is stopped
                                SensingTimer.Stop();
                                Debug.Print("HelloTimer.IsStopped: " + HelloTimer.IsStopped);
                                // Start the hello timer if it is stopped
                                if (HelloTimer.IsStopped) {
                                    HelloTimer.Start();
                                }
                                // Set the current state
                                _currState = state;
                                break;
                            // Sense state
                            case States.Sense:
                                // Be sure hello timer is stopped
                                HelloTimer.Stop();
                                Debug.Print("SensingTimer.IsStopped: " + SensingTimer.IsStopped);
                                // Start the sensing timer if it is stopped
                                if (SensingTimer.IsStopped) {
                                    SensingTimer.Start();
                                }
                                // Set the current state
                                _currState = state;
                                break;
                        }
                    }

                    /// <summary>
                    /// Convert timer ticks to microseconds
                    /// </summary>
                    /// <param name="ticks">Number of ticks</param>
                    /// <returns></returns>
                    private static int TicksToMs(long ticks) {
                        var replyTimeSpan = TimeSpan.FromTicks(ticks);
                        return replyTimeSpan.Days * 24 * 60 * 60 + replyTimeSpan.Hours * 60 * 60 * 1000 +
                               replyTimeSpan.Minutes * 60 * 1000 +
                               replyTimeSpan.Seconds * 1000 + replyTimeSpan.Milliseconds;
                    }
                }
            }
        }
    }
}