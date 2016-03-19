using System;

namespace Samraksh.eMote.Net.Radio
{
    /// <summary>
    /// Kind of user
    /// </summary>
    public enum RadioUser
    {
        /// <summary>
        /// Radio Object is used by a C# application
        /// </summary>
        CSharp,
        /// <summary>
        /// Radio is being used by the CSMA Mac object
        /// </summary>
        CSMAMAC,
        /// <summary>
        /// Radio is being used by the OMAC Mac object
        /// </summary>
        OMAC,
        /// <summary>
        /// Radio is idle
        /// </summary>
        IDLE,
    };


    /// <summary>
    /// Radio configuration
    /// </summary>
    public class RadioConfiguration
    {
       /// <summary>
        /// Transmission power of the radio
        /// </summary>
        public TxPowerValue TxPower;
        /// <summary>
        /// Channel the radio will transmit on
        /// </summary>
        public Channel Channel;
        /// <summary>
        /// 
        /// </summary>
        public RadioType RadioType;
        /// <summary>
        /// 
        /// </summary>
        public ReceiveCallBack OnReceiveCallback;
        /// <summary>
        /// 
        /// </summary>
        public NeighborhoodChangeCallBack OnNeighborChangeCallback;

        /// <summary>
        /// Radio configuration constructor
        /// </summary>
        public RadioConfiguration()
        {
            TxPower = TxPowerValue.Power_3dBm;
            Channel = Channel.Channel_26;
            RadioType = RadioType.RF231RADIO;
            OnReceiveCallback = null;
            OnNeighborChangeCallback = null;
        }

        /// <summary>
        /// Radio configuration constructor
        /// </summary>
        /// <param name="config">Radio configuration</param>
        public RadioConfiguration(RadioConfiguration config)
        {
            this.TxPower = config.TxPower;
            this.Channel = config.Channel;
            this.RadioType = config.RadioType;
            this.OnReceiveCallback = config.OnReceiveCallback;
            this.OnNeighborChangeCallback = config.OnNeighborChangeCallback;
        }

        /// <summary>
        /// Radio configuration constructor
        /// </summary>
        /// <param name="power">Transmission power</param>
        /// <param name="channel">Channel</param>
        /// <param name="type">type</param>
        public RadioConfiguration(TxPowerValue power, Channel channel, RadioType type)
        {
            this.Channel = channel;
            this.TxPower = power;
            this.RadioType = type;
        }
    };


    /// <summary>
    /// Radio interface
    /// </summary>
    public interface IRadio
    {
        //DeviceStatus Initialize(RadioConfiguration config, ReceiveCallBack callback); //Initializes Return the ID of the Radio layer that was initialized
        //DeviceStatus Configure(RadioConfiguration config, ReceiveCallBack callback);  //Change configuration after initialization

        /// <summary>
        /// Unitialize radio
        /// </summary>
        /// <returns>Success of operation</returns>
        DeviceStatus UnInitialize();

        /// <summary>
        /// Reconfigure radio
        /// </summary>
        /// <param name="config">New radio configuration</param>
        /// <returns>Success of operation</returns>
        DeviceStatus ReConfigure(RadioConfiguration config);

        /// <summary>
        /// Get radio address
        /// </summary>
        /// <returns>Radio address</returns>
        UInt16 GetRadioAddress(byte radioType);

        /// <summary>
        /// Set radio address
        /// </summary>
        /// <param name="radioType">Radio ID</param>
        /// <param name="address">Radio address</param>
        /// <returns></returns>
        bool SetRadioAddress(byte radioType, UInt16 address);

        /// <summary>
        /// Turn radio on
        /// </summary>
        /// <param name="radioType">Radio ID</param>
        /// <returns>Success of operation</returns>
        DeviceStatus TurnOnRx(byte radioType);

        /// <summary>
        /// Put radio to sleep
        /// </summary>
        /// <param name="radioType">Radio ID</param>
        /// <param name="level">Sleep level</param>
        /// <returns>Success of operation</returns>
        DeviceStatus Sleep(byte radioType, byte level);

        /// <summary>
        /// Preload radio
        /// </summary>
        /// <param name="packet">Packet to preload</param>
        /// <param name="size">Size of packet</param>
        /// <returns>Success of operation</returns>
        NetOpStatus PreLoad(byte[] packet, UInt16 size);

        /// <summary>
        /// Send preloaded message
        /// </summary>
        /// <returns>Success of operation</returns>
        NetOpStatus SendStrobe(byte radioType, UInt16 size);

        /// <summary>
        /// Send message on radio
        /// </summary>
        /// <param name="radioType">Radio ID</param>
        /// <param name="packet">Packet to send</param>
        /// <param name="size">Size of packet</param>
        /// <returns>Success of operation</returns>
        NetOpStatus Send(byte radioType, byte[] packet, UInt16 size);

        /// <summary>
        /// Sent time-stamped message
        /// </summary>
        /// <param name="radioType">Radio ID</param>
        /// <param name="packet">Packet buffer to send</param>
        /// <param name="size">Size of packet</param>
        /// <param name="eventTime">Time stamp of message</param>
        /// <returns>Send status</returns>
        NetOpStatus SendTimeStamped(byte radioType, byte[] packet, UInt16 size, UInt32 eventTime);

        /// <summary>
        /// Check if channel is clear
        /// </summary>
        /// <param name="radioType">Radio ID</param>
        /// <returns>True iff clear</returns>
        bool ClearChannelAssesment(byte radioType);

        /// <summary>
        /// Check if channel has been clear for the specified interval of time
        /// </summary>
        /// <param name="radioType">Radio ID</param>
        /// <param name="numberOfMicroSecond">Interval (microseconds)</param>
        /// <returns>True iff clear</returns>
        bool ClearChannelAssesment(byte radioType, UInt16 numberOfMicroSecond);

        //UInt32 GetSNR();
        //UInt32 GetRSSI();

    }
}
