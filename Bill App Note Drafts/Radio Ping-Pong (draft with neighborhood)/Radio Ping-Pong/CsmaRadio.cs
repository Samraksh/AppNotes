using System;
using Microsoft.SPOT;

using Samraksh.SPOT.Net;
using Samraksh.SPOT.Net.Mac;
using Samraksh.SPOT.Net.Radio;

namespace Samraksh.AppNote.Utility {
    public class CsmaRadio {

        public delegate void RadioNeighborChange(Neighbor[] neighborList);
        public delegate void RadioReceivedData(CSMA csma);

        MacConfiguration macConfig = new MacConfiguration();
        CSMA csma;
        RadioNeighborChange userNeighborChange;
        RadioReceivedData userReceivedData;

        /// <summary>
        /// CSMA radio constructor with neighbor change callback
        /// </summary>
        /// <param name="_ccaSensetime">CCA sense time, in ms</param>
        /// <param name="_txPowerValue">Power level</param>
        /// <param name="_radioReceivedData">Method to call when data received</param>
        /// <param name="_neighborLivenessDelay">How long a node remains a neighbor if not heard from, in ms</param>
        /// <param name="_radioNeighborChange">Method to call when neighborhood changes</param>
        public CsmaRadio(byte _ccaSensetime, TxPowerValue _txPowerValue, RadioReceivedData _radioReceivedData, uint _neighborLivenessDelay, RadioNeighborChange _radioNeighborChange) {

            ushort myAddress;

            macConfig.NeighbourLivelinesDelay = _neighborLivenessDelay;
            macConfig.CCASenseTime = _ccaSensetime;
            macConfig.radioConfig.SetTxPower(_txPowerValue);
            userNeighborChange = _radioNeighborChange;
            userReceivedData = _radioReceivedData;

            try {
                CSMA.Configure(macConfig, Receive, NeighborChange);
                csma = CSMA.Instance;
            }
            catch (Exception e) {
                Debug.Print("CSMA configuration error " + e.ToString());
            }

            myAddress = csma.GetAddress();
            Debug.Print("CSMA address is :  " + myAddress.ToString());
        }

        /// <summary>
        /// Send a message
        /// </summary>
        /// <param name="msgType">Message type: broadcast ... </param>
        /// <param name="message">Message to be sent, as a byte array</param>
        public void Send(Addresses msgType, byte[] message) {
            csma.Send((ushort)msgType, message, 0, (ushort)message.Length);
            //Debug.Print("Sending message " + (sendCounter++) + ", length " + message.Length);
        }
        int sendCounter = 0;

        /// <summary>
        /// Callback when neighborhood changes
        /// </summary>
        /// <remarks>
        /// If user callback is not null then call with neighbor list.
        /// </remarks>
        /// <param name="numberOfNeighbors"></param>
        private void NeighborChange(UInt16 numberOfNeighbors) {
            if (userNeighborChange == null) {
                return;
            }
            ushort[] neighborListMac = csma.GetNeighbourList();
            Neighbor[] neighborList = new Neighbor[neighborListMac.Length];
            for (int i = 0; i < neighborList.Length; i++) {
                neighborList[i] = csma.GetNeighborStatus(neighborListMac[i]);
            }
            userNeighborChange(neighborList);
        }

        /// <summary>
        /// Callback when radio message received.
        /// </summary>
        /// <remarks>
        /// If user callback is not null then call with CSMA object
        /// </remarks>
        /// <param name="numberOfPackets"></param>
        private void Receive(UInt16 numberOfPackets) {
            if (userReceivedData == null) {
                return;
            }
            //Debug.Print("Receiving message " + (receiveCounter++) + ", packets " + csma.GetPendingPacketCount());
            
            // No need to send numberOfPackets; that's available as CSMA.GetPendingPacketCount
            userReceivedData(csma);
        }
        int receiveCounter = 0;

    }
}
