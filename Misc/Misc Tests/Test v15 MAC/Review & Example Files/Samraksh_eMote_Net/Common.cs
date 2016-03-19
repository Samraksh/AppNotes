using System;
using Microsoft.SPOT;

namespace Samraksh.eMote.Net
{
    /// <summary>
    /// Device status
    /// </summary>
    public enum DeviceStatus
    {
        /// <summary>
        /// Success
        /// </summary>
        Success,
        /// <summary>
        /// Fail
        /// </summary>
        Fail,
        /// <summary>
        /// Ready
        /// </summary>
        Ready,
        /// <summary>
        /// Busy 
        /// </summary>
        Busy,
        /// <summary>
        /// Timeout 
        /// </summary>
        Timeout,
    };

    /// <summary>
    /// Net operation status
    /// </summary>
    public enum NetOpStatus
    {
        /// <summary>
        /// Radio initialization failed
        /// </summary>
        E_RadioInit,
        /// <summary>
        /// 
        /// </summary>
        E_RadioSync,
        /// <summary>
        /// Radio configuration failed
        /// </summary>
        E_RadioConfig,
        /// <summary>
        /// Mac layer initialization failed
        /// </summary>
        E_MacInit,
        /// <summary>
        /// Mac configuration failed
        /// </summary>
        E_MacConfig,
        /// <summary>
        /// Mac layer send failed
        /// </summary>
        E_MacSendError,
        /// <summary>
        /// Mac layer bufferis full
        /// </summary>
        E_MacBufferFull,
        /// <summary>
        /// Success
        /// </summary>
        S_Success
    };

    /// <summary>
    /// ReceiveCallback delegate 
    /// </summary>
    /// <param name="countOfPacketsReceived">Count of packets in the receive buffer</param>
    public delegate void ReceiveCallBack(UInt16 countOfPacketsReceived);

	/// <summary>
	/// Neighborhood callback delegate
	/// </summary>
	/// <param name="countOfChangedNeighbors">Count of neighbors that have changed</param>
	public delegate void NeighborhoodChangeCallBack(UInt16 countOfChangedNeighbors);
}
