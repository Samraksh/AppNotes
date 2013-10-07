using System;
using Microsoft.SPOT;

using Samraksh.SPOT.Hardware.EmoteDotNow;
using Samraksh.SPOT.Net;
using Samraksh.SPOT.Net.Mac;

namespace Samraksh.APPS.Test {
    public class PacketLossTest {

        byte[] testMessageInBytes;
        public TestMessage tmessage;
        static CSMA myCSMA;
        ReceiveCallBack myReceiveCB;
        NeighbourhoodChangeCallBack myNeighborCB;
        MacConfiguration macConfig = new MacConfiguration();
        System.Threading.Timer displayTimer;
        NetworkStatistics ns;
        NodeStatistics nodeData;

        public PacketLossTest() {
            tmessage = new TestMessage();

            macConfig.NeighbourLivelinesDelay = 180;
            macConfig.CCASenseTime = 140; //Carries sensing time in micro seconds
            macConfig.radioConfig.SetTxPower(Samraksh.SPOT.Net.Radio.TxPowerValue.Power_0Point7dBm);

            Debug.Print("Configuring:  CSMA...");
            try {
                myReceiveCB = Receive;
                myNeighborCB = NeighborChange;
                CSMA.Configure(macConfig, myReceiveCB, myNeighborCB);
                myCSMA = CSMA.Instance;
            }
            catch (Exception e) {
                Debug.Print(e.ToString());
            }

            ns = new NetworkStatistics();

            nodeData = new NodeStatistics();

        }

        public void Run() {
            displayTimer = new System.Threading.Timer(DisplayTimerCallback, null, 1000, 2000);
            while (true) {
                tmessage.IncrementSeqNo();
                testMessageInBytes = tmessage.ToBytes();
                myCSMA.Send((ushort)Samraksh.SPOT.Net.Mac.Addresses.BROADCAST, testMessageInBytes, (ushort)0, tmessage.getLength());
                System.Threading.Thread.Sleep(500);
            }
        }

        void NeighborChange(UInt16 noOfNeigbors) { }

        void HandleMessage(byte[] msg, UInt16 size, UInt16 src, bool unicast, byte rssi, byte lqi) {
            UInt16 currentSeqNo = 0;

            currentSeqNo = msg[0];
            currentSeqNo |= (ushort)(msg[1] << 8);

            nodeData.src = src;
            nodeData.lastRecievedPacketNo = currentSeqNo;

            //Debug.Print("Updating network stats table with" + nodeData.src.ToString() + "\t" + nodeData.lastRecievedPacketNo.ToString());
            ns.UpdateNode(nodeData);


        }

        void Receive(UInt16 noOfPackets) {
            Message rcvMsg = myCSMA.GetNextPacket();

            if (rcvMsg == null)
                return;

            byte[] rcvPayload = rcvMsg.GetMessage();

            HandleMessage(rcvPayload, (UInt16)rcvPayload.Length, rcvMsg.Src, rcvMsg.Unicast, rcvMsg.RSSI, rcvMsg.LQI);

        }

        void DisplayTimerCallback(Object state) {
            ns.DisplayStats();
        }



        

    }
}
