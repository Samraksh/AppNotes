using System;
using Microsoft.SPOT;

namespace Samraksh.eMote.AppNote.eMotePing {

    /// <summary>
    /// Defines the message used when sending a ping
    /// </summary>
    public class PingMsg {

        /// <summary>
        /// True iff a message was received
        /// </summary>
        public bool Response;

        /// <summary>
        /// 16 bit message id
        /// </summary>
        public UInt16 MsgID;

        /// <summary>
        /// 16 bit sender id
        /// </summary>
        public UInt16 Src;

        /// <summary>
        /// Initialize a message for ping
        /// </summary>
        public PingMsg() { }

        /// <summary>
        /// Initialize a message for ping
        /// </summary>
        /// <param name="rcv_msg">A 2-byte array containing the message</param>
        /// <param name="size">Unused; provide any unsigned 16 bit integer</param>
        public PingMsg(byte[] rcv_msg, UInt16 size) {
            Response = rcv_msg[0] == 0 ? false : true;
            MsgID = (UInt16)(rcv_msg[1] << 8);
            MsgID += (UInt16)rcv_msg[2];
            Src = (UInt16)(rcv_msg[3] << 8);
            Src += (UInt16)rcv_msg[4];
            // size sb at least 5 ... take action if not ***
        }

        /// <summary>
        /// Convert PingMsg class members to a 7-byte array
        /// </summary>
        /// <returns>7-byte array containing the class members</returns>
        public byte[] ToBytes() {
            byte[] b_msg = new byte[7];
            b_msg[0] = Response ? (byte)1 : (byte)0;
            b_msg[1] = (byte)((MsgID >> 8) & 0xFF);
            b_msg[2] = (byte)(MsgID & 0xFF);
            b_msg[3] = (byte)((Src >> 8) & 0xFF);
            b_msg[4] = (byte)(Src & 0xFF);
            b_msg[5] = (byte)(0xef);
            b_msg[6] = (byte)(0xef);
            return b_msg;
        }
    }

}
