using System;
using Microsoft.SPOT;
using Samraksh.eMote.Net;

namespace Samraksh.eMote.Net
{
    namespace Mac
    {
        /// <summary>
        /// MAC address type
        /// </summary>
        public enum AddressType
        {
            /// <summary>
            /// Indicates destination is all nodes in range. 
            /// <para>Other values indicate a particular node.</para>
            /// </summary>
            BROADCAST = 65535,
        };

        /// <summary>
        /// Link quality
        /// </summary>
        public class Link
        {
            /// <summary>Average Received Signal Strength Indication, RSSI </summary>
            public byte AveRSSI;
            /// <summary>Link quality</summary>
            public byte LinkQuality;
            /// <summary>Average delay</summary>
            public byte AveDelay;
        };

        /// <summary>
        /// Neighbor status
        /// </summary>
        public enum NeighborStatus
        {
            /// <summary>Neighbor is alive</summary>
            Alive,
            /// <summary>Neighbor is dead</summary>
            Dead,
            /// <summary>Neighbor is suspect</summary>
            Suspect
        };

        /// <summary>
        /// Neighbor details
        /// </summary>
        public class Neighbor
        {
            /// <summary>MAC address of neighbor</summary>
            public UInt16 MacAddress;
            /// <summary>Forward link of neighbor</summary>
            public Link ForwardLink;
            /// <summary>Reverse link of neighbor</summary>
            public Link ReverseLink;
            /// <summary>Status of neighbor</summary>
            public NeighborStatus Status;
            /// <summary>Packets received from neighbor</summary>
            public UInt16 PacketsReceived;
            /// <summary>Last time heard from neighbor</summary>
            public UInt64 LastHeardTime;
            /// <summary>Receive duty cycle of neighbor</summary>
            public byte ReceiveDutyCycle; //percentage
            /// <summary>Frame length of neighbor</summary>
            public UInt16 FrameLength;

        };

        /// <summary>
        /// List of neighbors and their details
        /// </summary>
        public class NeighborTable
        {
            /// <summary>Number of neighbor's valid neighbors</summary>
            public byte NumberValidNeighbor;
            /// <summary>Neighbor</summary>
            public Neighbor[] Neighbor;
        };

        /// <summary>
		/// MAC configuration
		/// </summary>
		public class MACConfiguration {
			/// <summary>
			/// Enable or disable MAC CCA (clear channel assessment)
			/// </summary>
			public bool CCA;
			/// <summary>
			/// Number of times to try sending before MAC gives up
			/// </summary>
			public byte NumberOfRetries;
            /// <summary>
			/// Duration of CCA
			/// </summary>
			public byte CCASenseTime;
            /// <summary>
			/// Size of send buffer
			/// </summary>
			public byte BufferSize;
            /// <summary>
			/// Radio type used by current MAC
			/// </summary>
			public Radio.RadioType RadioType;
            /// <summary>
			/// Delay before a neighbor is deemed dead
			/// </summary>
			public UInt32 NeighborLivenessDelay;
            /// <summary>
            /// Configuration of the radio power and channel 
            /// </summary>
            public Radio.RadioConfiguration MACRadioConfig;

            /// <summary>
            /// MAC configuration constructor
            /// </summary>
            public MACConfiguration()
            {
                this.CCA = true;
                this.BufferSize = 8;
                this.NumberOfRetries = 0;
                this.RadioType = Radio.RadioType.RF231RADIO;
                this.CCASenseTime = 140;
                this.NeighborLivenessDelay = 100;
                this.MACRadioConfig = new Radio.RadioConfiguration();
            }

            /// <summary>
            /// MAC configuration constructor
            /// </summary>
            /// <param name="config">Configuration to apply</param>
            public MACConfiguration(MACConfiguration config)
            {
                this.CCA = config.CCA;
                this.BufferSize = config.BufferSize;
                this.NumberOfRetries = config.NumberOfRetries;
                this.RadioType = config.RadioType;
                this.CCASenseTime = config.CCASenseTime;
                this.NeighborLivenessDelay = config.NeighborLivenessDelay;
                this.MACRadioConfig = new Radio.RadioConfiguration(config.MACRadioConfig);
            }
        };

		/// <summary>
        /// MAC interface
        /// </summary>
        public interface IMAC
        {
            //Basic functions
            //DeviceStatus Initialize(MACConfiguration config, ReceiveCallBack callback); //Initializes Return the ID of the Radio layer that was initialized
            //DeviceStatus Configure(MACConfiguration config);

            /// <summary>
            /// Unitialize MAC
            /// </summary>
            /// <returns>Success of operation</returns>
            DeviceStatus UnInitialize();
            
            /// <summary>
            /// Send message
            /// </summary>
            /// <param name="address">Address of recipient (can use Addresses.BROADCAST)</param>
            /// <param name="message">Byte array of to send</param>
            /// <param name="offset">Offset into array</param>
            /// <param name="size">Size of message</param>
            /// <returns></returns>
            NetOpStatus Send(UInt16 address, byte[] message, UInt16 offset, UInt16 size);
            
            /// <summary>
            /// Get address of radio
            /// </summary>
            /// <returns>Address</returns>
            UInt16 GetRadioAddress();

            /// <summary>
            /// Set address of radio
            /// </summary>
            /// <param name="address">Address</param>
            /// <returns>Success of operation</returns>
            DeviceStatus SetRadioAddress(UInt16 address);

            /// <summary>
            /// Get MAC type
            /// </summary>
            /// <returns>MAC type</returns>
            byte GetMACType();

            //Neighbor methods

			/// <summary>
			/// Get neighbor status
			/// </summary>
			/// <param name="macAddress">MAC address of neighbor</param>
			/// <returns>Neighbor status</returns>
			Neighbor GetNeighborStatus(UInt16 macAddress);

			/// <summary>
            /// Get pending packet count of MAC instance
            /// </summary>
            /// <returns></returns>
            byte GetPendingPacketCount_Send();

            /// <summary>
            /// Get pending packet count of MAC instance
            /// </summary>
            /// <returns></returns>
            byte GetPendingPacketCount_Receive();

            /// <summary>
            /// Remove packet from pending
            /// </summary>
            /// <param name="packet">Packet to remove</param>
            /// <returns>Status of result</returns>
            DeviceStatus RemovePacket(byte[] packet);

            //MAC Aggregate APIs
            //bool MacLayer_Initialize();
            //bool MacLayer_UnInitialize();
            //byte MacLayer_NumberMacsSupported();
        }

    }
}