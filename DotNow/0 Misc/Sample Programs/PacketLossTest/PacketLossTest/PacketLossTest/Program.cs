using System;
using Microsoft.SPOT;
using Samraksh.SPOT.Hardware.EmoteDotNow;
using Samraksh.SPOT.Net;
using Samraksh.SPOT.Net.Mac;

namespace Samraksh.APPS.Test {

    public class NodeStatistics {
        public UInt16 src;
        public UInt16 lastRecievedPacketNo;
        public UInt16 packetsLost;
        public float expectedPRR;
        public UInt16 totalRecievedPackets;

        public static void Main() {
            Debug.EnableGCMessages(false);
            PacketLossTest plt = new PacketLossTest();
            plt.Run();

        }

        public NodeStatistics() {
            src = 0;
            lastRecievedPacketNo = 0;
            packetsLost = 0;
            expectedPRR = 0;
            totalRecievedPackets = 0;
        }

        public NodeStatistics(NodeStatistics node) {
            this.src = node.src;
            this.lastRecievedPacketNo = node.lastRecievedPacketNo;
            this.packetsLost = node.packetsLost;
            this.expectedPRR = node.expectedPRR;
            this.totalRecievedPackets = 0;
        }

        public void UpdateValues(NodeStatistics node) {
            this.totalRecievedPackets++;
            this.src = node.src;
            this.packetsLost = (ushort)((node.lastRecievedPacketNo - this.totalRecievedPackets));
            this.lastRecievedPacketNo = node.lastRecievedPacketNo;
            this.expectedPRR = (this.packetsLost / this.lastRecievedPacketNo) * 100;
        }

        public void InsertValues(NodeStatistics node) {
            this.totalRecievedPackets++;
            this.src = node.src;
            this.packetsLost = 0;
            this.lastRecievedPacketNo = node.lastRecievedPacketNo;
            this.expectedPRR = 0;
        }

    }

    public class NetworkStatistics {
        NodeStatistics[] nodeArray;

        public NetworkStatistics() {
            nodeArray = new NodeStatistics[10];
            for (int i = 0; i < nodeArray.Length; i++) {
                nodeArray[i] = new NodeStatistics();
            }
        }

        public void DisplayStats() {
            Debug.Print(" Src ID    |   Packets Lost    |   Last Recieved Packet No. |  PRR     ");
            foreach (NodeStatistics node in nodeArray) {
                if (node.src != 0) {
                    Debug.Print(node.src.ToString() + "\t|\t" + node.packetsLost.ToString() + "\t|\t" + node.lastRecievedPacketNo.ToString() + "\t\t" + node.expectedPRR.ToString());
                }
            }

        }

        public bool UpdateNode(NodeStatistics incomingNodeData) {
            bool nodeExists = false;

            for (int i = 0; i < nodeArray.Length; i++) {

                if (nodeArray[i].src == incomingNodeData.src) {

                    nodeArray[i].UpdateValues(incomingNodeData);
                    nodeExists = true;
                    break;
                }

            }



            if (!nodeExists) {
                for (int i = 0; i < nodeArray.Length; i++) {
                    if (nodeArray[i].src == 0) {

                        nodeArray[i].InsertValues(incomingNodeData);
                        break;
                    }
                }
            }



            return true;
        }
    }


    public class TestMessage {
        private UInt16 seqNo;

        private byte[] convertedToBytes;

        public TestMessage() {
            seqNo = 0;
            convertedToBytes = new byte[2];
        }

        public void IncrementSeqNo() {
            seqNo++;
        }

        public byte[] ToBytes() {
            convertedToBytes[0] = (byte)seqNo;
            convertedToBytes[1] = (byte)(seqNo >> 8);

            return convertedToBytes;
        }

        public ushort getLength() {
            return (ushort)convertedToBytes.Length;
        }

    }

    
}
