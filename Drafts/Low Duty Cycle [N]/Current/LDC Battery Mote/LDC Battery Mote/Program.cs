/*--------------------------------------------------------------------
 * Low Duty Cycle - Battery: app note for the eMote .NOW
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *      1.0: initial release
---------------------------------------------------------------------*/


using System.Reflection;
using System.Text;
using System.Threading;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.Net.Mac;
using Samraksh.eMote.Net.Radio;

namespace Samraksh.AppNote.LowDutyCycle {
    namespace Battery {
        /// <summary>
        /// Low Duty Cycle app note
        /// Run from battery
        /// </summary>
        public static class Program {

            const Channels RadioChannel = Channels.Channel_11;

            private const int DutyCycleIntervalMilliSec = 5 * 1000;
            private const int RadioPowerTimerTimeoutMilliSec = 100;

            private static EnhancedEmoteLcd _lcd;
            private static int _counter = 125;
            private static SimpleCsmaRadio _radio;

            private static Timer _radioPowerTimer;

            private static Common _commonItems;

            /// <summary>
            /// Low Duty Cycle app note: main program
            /// </summary>
            public static void Main() {
                Debug.Print("\nLow Duty Cycle\n");

                Debug.Print(VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));
                Debug.Print("");

                _lcd = new EnhancedEmoteLcd();
                //LCD.Initialize();

                _commonItems = new Common();

                _radio = new SimpleCsmaRadio(RadioName.RF231RADIO, 10, TxPowerValue.Power_3dBm, PacketReceived, RadioChannel);
                _radio.SetRadioState(SimpleCsmaRadio.RadioStates.Off);

                // Create the timer but don't start it (Timeout.Infinite)
                //  Timer is started in method DutyCycleActions
                //  When it ticks, turn the radio and the timer off
                _radioPowerTimer = new Timer(_ => TurnRadioAndTimerOff(), null, Timeout.Infinite,
                    RadioPowerTimerTimeoutMilliSec);

                while (true) {
                    DutyCycleActions();
                    Thread.Sleep(DutyCycleIntervalMilliSec);
                }
            }

            /// <summary>
            /// Actions to perform on scheduled awake time
            /// </summary>
            private static void DutyCycleActions() {
                // Display current value
                _lcd.Display(_counter);

                // Send a message on the radio
                BitConverter.InsertValueIntoArray(_commonItems.MessageBuffer, _commonItems.MessagePos, _counter);

                var hex = new StringBuilder(": ");
                foreach (var theByte in _commonItems.MessageBuffer) {
                    hex.Append(theByte.ToString("x2"));
                    hex.Append(' ');
                }
                Debug.Print("Message Buffer bytes" + hex + "; " + _commonItems.MessagePos);



                _radio.SetRadioState(SimpleCsmaRadio.RadioStates.On);
                _radio.Send(Addresses.BROADCAST, _commonItems.MessageBuffer);
                _radioPowerTimer.Change(0, RadioPowerTimerTimeoutMilliSec);
                // Start the timer to turn the radio power off if acknowledgment not received soon enuf

                Debug.Print("Send # " + _counter);

                // Update the counter
                _counter++;
            }

            /// <summary>
            /// Turn the radio and the associated timer off
            /// </summary>
            private static void TurnRadioAndTimerOff() {
                // Turn the radio off
                _radio.SetRadioState(SimpleCsmaRadio.RadioStates.Off);
                // Stop the timer
                _radioPowerTimer.Change(Timeout.Infinite, int.MaxValue);

                Debug.Print("Turned ack timer off");
            }


            /// <summary>
            /// Process incoming packet
            /// </summary>
            private static void PacketReceived(CSMA csma) {
                var packet = csma.GetNextPacket();

                // If null packet, skip
                if (packet == null) {
                    return;
                }
                // If broadcast (not unicast), not for us
                if (!packet.Unicast) {
                    return;
                }

                // Check if this is for us
                var msgBytes = packet.GetMessage();
                var protocolName =
                    System.Text.Encoding.UTF8.GetChars(msgBytes, _commonItems.AppPos, _commonItems.AppLen).ToString();
                // If wrong app name, not for us
                if (protocolName != Common.AppName) {
                    return;
                }

                // Is for us: consider it an acknowledgement and turn the radio & timer off
                TurnRadioAndTimerOff();

                Debug.Print("Received ack");
            }

            //var timer = new eMote.RealTime.Timer("RealTimeInteropTimer", 10000, 0);
            //timer.OnInterrupt += DutyCycleAction;

            //DutyCycleAction(0, 0, DateTime.Now);

            //Thread.Sleep(Timeout.Infinite);


            //private static void DutyCycleAction(uint data1, uint data2, DateTime time) {
            //    LCD.Display(_counter);
            //    _counter++;
            //}

        }
    }
}