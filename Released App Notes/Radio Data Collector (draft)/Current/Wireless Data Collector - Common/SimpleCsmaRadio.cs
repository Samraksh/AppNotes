using System;
using Microsoft.SPOT;
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
        /// <param name="ccaSensetime">CCA sense time, in ms</param>
        /// <param name="txPowerValue">Power level</param>
        /// <param name="radioReceivedData">Method to call when data received. Can be null if user does not want to be notified of received messages</param>
        public SimpleCsmaRadio(byte ccaSensetime, TxPowerValue txPowerValue, RadioReceivedData radioReceivedData) {
            var macConfig = new MacConfiguration();

            macConfig.NeighbourLivelinesDelay = 100;    // Neighbor timeout. Neighbor changes are ignored but we still have to specify a value
            macConfig.CCASenseTime = ccaSensetime;
            macConfig.radioConfig.SetTxPower(txPowerValue);
            _userReceivedDataCallback = radioReceivedData;

            try {
                CSMA.Configure(macConfig, Receive, NeighborChange); // Set up CSMA with the MAC configuration, receive callback and neighbor change callback (which does nothing)
                _csma = CSMA.Instance;
            }
            catch (Exception e) {
                Debug.Print("CSMA configuration error " + e.ToString());
            }

            Debug.Print("CSMA address is :  " + _csma.GetAddress().ToString());
        }

        /// <summary>
        /// Send a message
        /// </summary>
        /// <param name="msgType">Message type: broadcast ... </param>
        /// <param name="message">Message to be sent, as a byte array</param>
        public void Send(Addresses msgType, byte[] message) {
            _csma.Send((ushort)msgType, message, 0, (ushort)message.Length);
        }

        /// <summary>
        /// Callback when neighborhood changes
        /// </summary>
        /// <remarks>
        /// We are ignoring neighborhood changes so this method does nothing
        /// </remarks>
        /// <param name="numberOfNeighbors"></param>
        private static void NeighborChange(UInt16 numberOfNeighbors) {
            return;
        }

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
