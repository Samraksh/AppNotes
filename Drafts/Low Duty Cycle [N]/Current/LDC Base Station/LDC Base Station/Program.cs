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
    namespace Base {
        public class Program {
            private static EnhancedEmoteLcd _lcd;
            private static Common _commonItems;
            private static SimpleCsmaRadio _radio;


            public static void Main() {

                Debug.Print("\nLow Duty Cycle\n");

                Debug.Print(VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));
                Debug.Print("");

                _lcd = new EnhancedEmoteLcd();
                _lcd.Clear();

                _commonItems = new Common();

                _radio = new SimpleCsmaRadio(RadioName.RF231RADIO, 10, TxPowerValue.Power_3dBm, PacketReceived);
                _radio.SetRadioState(SimpleCsmaRadio.RadioStates.Off);

                _lcd.Display("Run");

                Thread.Sleep(Timeout.Infinite);
            }

            /// <summary>
            /// Process incoming packet
            /// </summary>
            private static void PacketReceived(CSMA csma) {

                Debug.Print("Got Packet");

                var packet = csma.GetNextPacket();

                Debug.Print("Got 1");

                // If null packet, skip
                if (packet == null) {
                    Debug.Print("Packet is null");
                    return;
                }

                Debug.Print("Got 2");

                // Check if this is for us
                var msgBytes = packet.GetMessage();

                var hex = new StringBuilder(": ");
                foreach (var theByte in msgBytes) {
                    hex.Append(theByte.ToString("x2"));
                    hex.Append(' ');
                }
                Debug.Print("Message bytes: " + hex);

                var protocolName = Encoding.UTF8.GetChars(msgBytes, _commonItems.AppPos, _commonItems.AppLen).ToString();

                Debug.Print("Protocol name: " + protocolName);

                // If wrong app name, not for us
                if (protocolName != Common.AppName) {
                    return;
                }

                var payload = BitConverter.ToInt32(msgBytes, _commonItems.MessagePos);

                // Send the ack
                var sourceAddress = packet.Src;
                _radio.Send((Addresses)sourceAddress, _commonItems.MessageBuffer);

                _lcd.Display(payload);

                Debug.Print("Received payload <" + payload + "> from node " + sourceAddress + "; sent ack");
            }

        }


    }
}
