/********************************************************
 * Simple CSMA Radio class
 *  Simplify the definition of a CSMA radio
 * Versions
 *  1.0 Initial version
 *  1.1 Added parameter for type of radio
 *********************************************************/
using System;
using System.Threading;
using Microsoft.SPOT;

using Samraksh.SPOT.Net;
using Samraksh.SPOT.Net.Mac;
using Samraksh.SPOT.Net.Radio;

namespace Samraksh.AppNote.Utility {
    /// <summary>
    /// Handle CSMA radio communication
    /// To keep it simple, we ignore neighborhood changes
    /// </summary>
    public class SimpleCsmaRadio {

        // Set up for callback to user method to handle incoming packets
        public delegate void RadioReceivedData(CSMA csma);

        readonly RadioReceivedData _userReceivedDataCallback;

        // CSMA object that's created & passed back to the user.
        readonly CSMA _csma;

        /// <summary>
        /// CSMA radio constructor with neighbor change callback
        /// </summary>
        /// <param name="radioName">Name of the radio (internal, long range)</param>
        /// <param name="ccaSensetime">CCA sense time, in ms</param>
        /// <param name="txPowerValue">Power level</param>
        /// <param name="radioReceivedData">Method to call when data received. Can be null if user does not want to be notified of received messages</param>
        public SimpleCsmaRadio(RadioName radioName, byte ccaSensetime, TxPowerValue txPowerValue, RadioReceivedData radioReceivedData) {
            var macConfig = new MacConfiguration { NeighbourLivelinesDelay = 100, CCASenseTime = ccaSensetime };
            macConfig.radioConfig.SetTxPower(txPowerValue);
            macConfig.radioConfig.SetRadioName(radioName);
            _userReceivedDataCallback = radioReceivedData;

            try {
                DeviceStatus retVal;
                retVal = CSMA.Configure(macConfig, Receive, NeighborChange);
                    // Set up CSMA with the MAC configuration, receive callback and neighbor change callback (which does nothing)
                if (retVal != DeviceStatus.Success) {
                    var lcd = new EnhancedEmoteLcd();
                    lcd.Display("5555");
                    Thread.Sleep(Timeout.Infinite);
                }

                _csma = CSMA.Instance;
            }
            catch (MacNotConfiguredException e) {
                Debug.Print("CSMA configuration error " + e);
                var lcd = new EnhancedEmoteLcd();
                lcd.Display("1111");
                Thread.Sleep(Timeout.Infinite);
                throw;
            }
            catch (Exception e) {
                Debug.Print("Unknown error " + e);
                var lcd = new EnhancedEmoteLcd();
                lcd.Display("2222");
                Thread.Sleep(Timeout.Infinite);
                throw;
            }
            Debug.Print("CSMA address is :  " + _csma.GetAddress());
        }

        /// <summary>
        /// Send a message
        /// </summary>
        /// <param name="msgType">Message type: broadcast or CSMA address of recipient</param>
        /// <param name="message">Message to be sent, as a byte array</param>
        public void Send(Addresses msgType, byte[] message) {
            var lcd = new EnhancedEmoteLcd();
            //lcd.Display("3333");
            _csma.Send((ushort)msgType, message, 0, (ushort)message.Length);
            //Thread.Sleep(100);
            //lcd.Display("4444");
        }

        /// <summary>
        /// Callback when neighborhood changes
        /// </summary>
        /// <remarks>
        /// We are ignoring neighborhood changes so this method does nothing
        /// </remarks>
        /// <param name="numberOfNeighbors"></param>
        public static void NeighborChange(UInt16 numberOfNeighbors) { }

        /// <summary>
        /// Callback when radio message received
        /// </summary>
        /// <remarks>
        /// If user callback is not null then call with CSMA object
        /// </remarks>
        /// <param name="numberOfPackets"></param>
        private void Receive(UInt16 numberOfPackets) {
            // If the user doesn't want to be notified of received messages, return
            if (_userReceivedDataCallback == null) {
                return;
            }
            // Send the CSMA object to the user.
            // No need to send numberOfPackets; that's available as CSMA.GetPendingPacketCount
            _userReceivedDataCallback(_csma);
        }
    }
}
