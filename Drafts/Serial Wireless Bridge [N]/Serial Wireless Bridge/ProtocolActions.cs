using System;
using System.Threading;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;

namespace Samraksh.AppNote.SerialWirelessBridge {

    internal static class ProtocolActions {
        /// <summary>
        /// Send Serial Election Message action
        /// </summary>
        internal static class SndSerialElectionClass {
            private static readonly byte[] SndSerialElectionMessage = new byte[Messages.Field.Election.MsgLen];
            internal static Timer SndSerialElectionTimer = null;

            internal static void SndSerialElection() {
                Global.ToggleLcd.Toggle(0, '0');
                Debug.Print("$ Send Serial Election " + _sndElectionCnt++);

                // Copy in the message type
                Array.Copy(Messages.MessageType.Election, 0, SndSerialElectionMessage, Messages.Field.Election.Type, Messages.MessageType.Election.Length);
                //SndSerialElectionMessage[Messages.Field.Election.Type] = (byte)Messages.MessageType.Election;

                // Copy in the node ID
                Array.Copy(Global.NodeIdBytes, 0, SndSerialElectionMessage, Messages.Field.Election.NodeId, Global.NodeIdBytesLength);

                //BitConverter.InsertValueIntoArray(SndSerialElectionMessage, Messages.Field.Election.NodeId, Global.NodeIdLong);
                SndSerialElectionMessage[Messages.Field.Election.ElectStatus] = (byte)Global.LdrStatus;
                Global.SrlLink.Write(SndSerialElectionMessage, Messages.Field.Election.MsgLen);
            }
            private static int _sndElectionCnt;
        }

        /// <summary>
        /// Receive Serial Election Message action
        /// </summary>
        /// <param name="messageBytes"></param>
        /// <param name="messageLen"></param>
        internal static void RcvSerialElection(byte[] messageBytes, int messageLen) {
            Global.ToggleLcd.Toggle(1, '1');
            switch ((Global.LeaderStatus)messageBytes[Messages.Field.Election.ElectStatus]) {
                case Global.LeaderStatus.Leader:
                    SndSerialElectionClass.SndSerialElectionTimer.Dispose();
                    Global.LdrStatus = Global.LeaderStatus.Follower;
                    break;
                case Global.LeaderStatus.Follower:
                    SndSerialElectionClass.SndSerialElectionTimer.Dispose();
                    Global.LdrStatus = Global.LeaderStatus.Leader;
                    break;
                case Global.LeaderStatus.Undecided:
                    var otherNodeId = BitConverter.ToInt64(messageBytes, Messages.Field.Election.NodeId);
                    Global.LdrStatus = (otherNodeId > Global.NodeIdLong) ? Global.LeaderStatus.Follower : Global.LeaderStatus.Leader;
                    break;
            }
            if (Global.LdrStatus == Global.LeaderStatus.Leader && SndSerialElectionClass.SndSerialElectionTimer == null) {
                SndSerialOutgoingClass.SndSerialOutgoingTimer = new Timer(_ => SndSerialOutgoingClass.SndSerialOutgoing(), null, 0, Global.TimedActionIntervalMicrosec);
            }
        }

        internal static class SndSerialOutgoingClass {
            private static readonly byte[] SndSerialOutgoingMessage = new byte[Messages.Field.OutGoing.MsgLen];
            public static Timer SndSerialOutgoingTimer = null;
            private static int _value;
            public static void SndSerialOutgoing() {
                Global.ToggleLcd.Toggle(2, '2');
                SndSerialOutgoingMessage[Messages.Field.OutGoing.Type] = (byte)Messages.MessageType.Outgoing;
                BitConverter.InsertValueIntoArray(SndSerialOutgoingMessage, Messages.Field.OutGoing.Value, _value);
                _value++;
            }
        }

        public static void RcvSerialOutgoing(byte[] messageBytes, int messageLen) {
        }
        public static void RcvSerialReturn(byte[] messageBytes, int messageLen) {
        }
    }
}
