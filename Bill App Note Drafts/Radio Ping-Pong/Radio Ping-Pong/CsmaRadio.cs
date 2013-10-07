using System;
using Microsoft.SPOT;

using Samraksh.SPOT.Net.Mac;
using Samraksh.SPOT.Net.Radio;

namespace Samraksh.AppNote.Utility {
    public class CsmaRadio {

        public delegate void RadioNeighborChange(Neighbor[] neighborList);
        public delegate void RadioReceivedData(byte[] receivedData);

        MacConfiguration macConfig = new MacConfiguration();
        CSMA csma;
        RadioNeighborChange radioNeighborChange;
        RadioReceivedData radioReceivedData;

        public CsmaRadio(uint _neighborLivenessDelay, byte _ccaSensetime, TxPowerValue _txPowerValue, RadioNeighborChange _radioNeighborChange, RadioReceivedData _radioReceivedData) {
            macConfig.NeighbourLivelinesDelay = _neighborLivenessDelay;
            macConfig.CCASenseTime = _ccaSensetime;
            macConfig.radioConfig.SetTxPower(_txPowerValue);
            radioNeighborChange = _radioNeighborChange;
            radioReceivedData = _radioReceivedData;
            CSMA.Configure(macConfig, Receive, NeighborChange);
            csma = CSMA.Instance;
        }

        private void NeighborChange(UInt16 numberOfNeighbors) {
            ushort[] neighborListMac = csma.GetNeighbourList();
            Neighbor[] neighborList = new Neighbor[neighborListMac.Length];
            for (int i = 0; i<neighborList.Length;i++) {
                neighborList[i] = csma.GetNeighborStatus(neighborListMac[i]);
            }
            radioNeighborChange(neighborList);
        }

        private void Receive(UInt16 numberOfPackets) {

        }

    }
}
