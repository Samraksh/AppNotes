using System;
using Microsoft.SPOT;

namespace Samraksh.eMote.Net
{
    /// <summary>Packet object. Passed to native</summary>
    public class Packet
    {
        /// <summary>
        /// Defines the default size of the mac packet
        /// </summary>
        const byte MacPacketSize = 128;

        /// <summary>Received Signal Strength of packet</summary>
        /// <value>RSSI value</value>
        public byte RSSI;

        /// <summary>Link Quality Indication measured during the packet reception</summary>
        /// <value>LQI measured</value>
        public byte LQI;

        /// <summary>
        /// Source of the packet transmitted
        /// </summary>
        /// <value>Source of the packet</value>
        public UInt16 Src;

        /// <summary>Was packet unicast?</summary>
        /// <value>True if packet was unicast, else broadcast</value>
        public bool IsUnicast;

        /// <summary>
        /// Received packet
        /// </summary>
        public byte[] Payload;

        /// <summary>Size of the packet payload</summary>
        /// <value>Size of packet payload</value>
        public UInt16 Size;

        /// <summary>The time at which the packet was sent out</summary>
        /// <value>Time the packet was sent out (microseconds)</value>
        public long SenderEventTimeStamp;

        /// <summary>
        /// 
        /// </summary>
        public bool IsPacketTimeStamped;

        /*/// <summary>Check if packet is timestamped</summary>
        /// <returns>True iff packet is timestamped</returns>
        public bool IsPacketTimeStamped()
        {
            return IsPacketTimeStamped;
        }*/

        /// <summary>Create a packet with the default size</summary>
        public Packet()
        {
            Payload = new byte[MacPacketSize];
        }

        /// <summary>Create a packet with Size, Payload, RSSI, LQI, Src and Unicast information specified in packet array</summary>
        /// <param name="msg">Packet. Size, Payload, RSSI, LQI, Src and Unicast information specified in the first 6 bytes. Rest is payload</param>
        public Packet(byte[] msg)
        {
            UInt16 i = 0;
            UInt16 length = (UInt16) msg[0];
            length |= (UInt16) (msg[1] << 8);

            Size = length;

            Payload = new byte[MacPacketSize];

            for (i = 0; i < length; i++)
            {
                Payload[i] = msg[i + 2];
            }

            RSSI = msg[i++ + 2];
            LQI = msg[i++ + 2];

            Src = msg[i++ + 2];
            Src |= (UInt16) (msg[i++ + 2] << 8);

            // Determines whether the packet is unicast or not 
            if (msg[i++ + 2] == 1)
                IsUnicast = true;
            else
                IsUnicast = false;

            // Check if the packet is timestamped from the sender 
            if (msg[i++ + 2] == 1)
                IsPacketTimeStamped = true;
            else
                IsPacketTimeStamped = false;

            // Elaborate conversion plan because nothing else works 
            UInt32 lsbItem = msg[i++ + 2];
            lsbItem |= ((UInt32)msg[i++ + 2] << 8);
            lsbItem |= ((UInt32)msg[i++ + 2] << 16);
            lsbItem |= ((UInt32)msg[i++ + 2] << 24);

            UInt32 msbItem = msg[i++ + 2];
            msbItem |= ((UInt32)msg[i++ + 2] << 8);
            msbItem |= ((UInt32)msg[i++ + 2] << 16);
            msbItem |= ((UInt32)msg[i++ + 2] << 24);

            
            long tempTimeStamp = ((long)msbItem << 32) | lsbItem;

            SenderEventTimeStamp = tempTimeStamp;

        }

        /// <summary>Create a packet with specified parameters</summary>
        /// <param name="payload">Packet payload</param>
        /// <param name="Src">Source of the packet</param>
        /// <param name="IsUnicast">Was transmission unicast</param>
        /// <param name="RSSI">RSSI</param>
        /// <param name="LQI">LQI</param>
        public Packet(byte[] payload, UInt16 Src, bool IsUnicast, byte RSSI, byte LQI)
        {
            //Create a payload object of default size
            Payload = new byte[MacPacketSize];

            // Copy the payload to the receive packet buffer the traditional way 
            for (int i = 0; i < payload.Length; i++)
            {
                Payload[i] = payload[i];
            }

            // Copy other parameters to this object 
            this.Src = Src;
            this.IsUnicast = IsUnicast;
            this.RSSI = RSSI;
            this.LQI = LQI;
        }

        /// <summary>Create a packet with specified parameters</summary>
        /// <param name="payload">Packet payload</param>
        /// <param name="Src">Source of the packet</param>
        /// <param name="IsUnicast">Was transmission unicast</param>
        /// <param name="RSSI">RSSI</param>
        /// <param name="LQI">LQI</param>
        /// <param name="Size">Size of the payload buffer </param>
        public Packet(byte[] payload, UInt16 Src, bool IsUnicast, byte RSSI, byte LQI, UInt16 Size)
        {
            //Create a message object of default size
            Payload = new byte[Size];

            // Copy the message to the receive message buffer the traditional way 
            for (int i = 0; i < payload.Length; i++)
            {
                Payload[i] = payload[i];
            }

            // Copy other parameters to this object 
            this.Src = Src;
            this.IsUnicast = IsUnicast;
            this.RSSI = RSSI;
            this.LQI = LQI;
        }

        /// <summary>Create a packet with specified parameters</summary>
        /// <param name="payload"></param>
        /// <param name="Src"></param>
        /// <param name="IsUnicast"></param>
        /// <param name="RSSI"></param>
        /// <param name="LQI"></param>
        /// <param name="Size"></param>
        /// <param name="IsPacketTimeStamped"></param>
        public Packet(byte[] payload, UInt16 Src, bool IsUnicast, byte RSSI, byte LQI, UInt16 Size, bool IsPacketTimeStamped)
        {
            //Create a message object of default size
            Payload = new byte[Size];

            // Copy the message to the receive message buffer the traditional way 
            for (int i = 0; i < payload.Length; i++)
            {
                Payload[i] = payload[i];
            }

            // Copy other parameters to this object 
            this.Src = Src;
            this.IsUnicast = IsUnicast;
            this.RSSI = RSSI;
            this.LQI = LQI;
            this.IsPacketTimeStamped = IsPacketTimeStamped;
        }

        /// <summary>Configure size of messages</summary>
        /// <param name="Size">Size of messages</param>
        public Packet(int Size)
        {
            Payload = new byte[Size];
        }
    }
}
