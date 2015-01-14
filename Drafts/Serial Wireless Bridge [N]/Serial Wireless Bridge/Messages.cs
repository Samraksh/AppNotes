namespace Samraksh.AppNote.SerialWirelessBridge {
    internal static class Messages {
        /// <summary>Types of messages</summary>
        internal enum MessageType : byte {
            /// <summary>Leader election</summary>
            Election,
            /// <summary>Outgoing message</summary>
            Outgoing,
            /// <summary>Return message</summary>
            Return,
            /// <summary>Confirmation message</summary>
            Confirm,
            /// <summary>Error message</summary>
            Error,
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
                public const int ElectStatus = NodeId + 8; // byte
                public const int MsgLen = ElectStatus + 1; // Length of message
            }

            internal static class OutGoing {
                public const int Type = 0; // byte
                public const int Value = Type + 1; // byte[4]
                public const int MsgLen = Value + 1; // Length of message
            }

        }
    }
}
