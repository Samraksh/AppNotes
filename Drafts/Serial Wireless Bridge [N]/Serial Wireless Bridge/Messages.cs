using System.Text;

namespace Samraksh.AppNote.SerialWirelessBridge {
    internal static class Messages {
        ///// <summary>Types of messages</summary>
        //internal enum MessageType : byte {
        //    /// <summary>Leader election</summary>
        //    Election,
        //    /// <summary>Outgoing message</summary>
        //    Outgoing,
        //    /// <summary>Return message</summary>
        //    Return,
        //    /// <summary>Confirmation message</summary>
        //    Confirm,
        //    /// <summary>Error message</summary>
        //    Error,
        //}

        /// <summary>Types of messages</summary>
        internal static class MessageType {
            /// <summary>Leader election</summary>
            internal static byte[] Election = Encoding.UTF8.GetBytes("E");

            /// <summary>Outgoing message</summary>
            internal static byte[] Outgoing = Encoding.UTF8.GetBytes("O");

            /// <summary>Return message</summary>
            internal static byte[] Return = Encoding.UTF8.GetBytes("R");

            /// <summary>Confirmation message</summary>
            internal static byte[] Confirm = Encoding.UTF8.GetBytes("C");

            /// <summary>Error message</summary>
            internal static byte[] Error = Encoding.UTF8.GetBytes("E");
        }


        /// <summary>
        /// Fields for messages
        /// </summary>
        internal static class Field {
            /// <summary>
            /// Serial Election message
            /// </summary>
            internal static class Election {
                public const int Type = 0; // byte
                public const int NodeId = Type + 1; // byte[8]
                public const int ElectStatus = NodeId + Global.NodeIdBytesLength; // byte
                public const int MsgLen = ElectStatus + 1; // Length of message
            }

            internal static class OutGoing {
                public const int Type = 0; // byte
                public const int Value = Type + 1; // int
                public const int MsgLen = Value + sizeof(int); // Length of message
            }

        }
    }
}
