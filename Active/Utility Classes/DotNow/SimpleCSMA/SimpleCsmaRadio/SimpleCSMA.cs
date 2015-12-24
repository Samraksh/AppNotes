/********************************************************
 * Simple CSMA Radio class
 *  Simplify the definition of a CSMA radio
 * Versions
 *  1.0 Initial version
 *  1.1 Added parameter for type of radio
 *  1.2 Revised for eMote namespace
 *  1.3 Minor changes and corrections
 *  1.4
 *		- Changed obsolete method calls
 *	1.5
 *		- Updated to eMote v. 14
 *	1.6
 *		- Callback via subscription to OnReceive
 *********************************************************/

using System;
using Microsoft.SPOT;

using Samraksh.eMote.Net;
using Samraksh.eMote.Net.Mac;
using Samraksh.eMote.Net.Radio;

namespace Samraksh.AppNote.Utility
{
	/// <summary>
	/// CSMA exception
	/// </summary>
	public class CSMAException : Exception
	{
		/// <summary>
		/// CSMA Exception
		/// </summary>
		/// <param name="descrip">Description of exception</param>
		public CSMAException(string descrip) : base(descrip) { }

		/// <summary>
		/// CSMA Exception
		/// </summary>
		/// <param name="descrip">Description of exception</param>
		/// <param name="innerException">Inner exception</param>
		public CSMAException(string descrip, Exception innerException) : base(descrip, innerException) { }
	}

	/// <summary>
	/// Handle CSMA radio communication
	/// To keep it simple, we ignore neighborhood changes
	/// </summary>
	public class SimpleCSMA
	{
		/// <summary>
		/// Callback delegate for OnReceive events
		/// </summary>
		/// <param name="csma"></param>
		public delegate void ReceivePacket(CSMA csma);

		/// <summary>
		/// ReceiveHandler event
		/// </summary>
		public event ReceivePacket OnReceive;

		/// <summary>
		/// Callback delegate for NeighborChange events
		/// </summary>
		/// <param name="numberOfNeighbors"></param>
		/// <param name="csma"></param>
		public delegate void NeighborChange(ushort numberOfNeighbors, CSMA csma);

		/// <summary>
		/// ReceiveHandler event
		/// </summary>
		public event NeighborChange OnNeighborChange;

		// CSMA object that's created & passed back to the user.
		private readonly CSMA _csma;

		/// <summary>
		/// Radio states
		/// </summary>
		public enum RadioStates
		{
			/// <summary>Radio on</summary>
			On,
			/// <summary>Radio off</summary>
			Off
		}

		/// <summary>CCA sense time</summary>
		public byte CCASenseTime
		{
			get { return _ccaSenseTime; }
			set { _ccaSenseTime = value; }
		}
		private byte _ccaSenseTime = 100;

		/// <summary>Tx power value</summary>
		public TxPowerValue TxPowerValue
		{
			get { return _txPowerValue; }
			set { _txPowerValue = value; }
		}
		private TxPowerValue _txPowerValue = TxPowerValue.Power_3dBm;

		/// <summary>Channel</summary>
		public Channels Channel
		{
			get { return _channel; }
			set { _channel = value; }
		}
		private Channels _channel = Channels.Channel_26;

		/// <summary>Neighbor Liveness Delay</summary>
		public uint NeighborLivenessDelay
		{
			get { return _neighborLivenessDelay; }
			set { _neighborLivenessDelay = value; }
		}
		private uint _neighborLivenessDelay = 100;

		private readonly MacConfiguration _macConfig;

		/// <summary>
		/// CSMA radio constructor 
		/// </summary>
		/// <param name="radioName">Name of the radio (internal, long range)</param>
		public SimpleCSMA(RadioName radioName)
		{
			_macConfig = new MacConfiguration
			{
				NeighborLivenessDelay = NeighborLivenessDelay,
				CCASenseTime = CCASenseTime
			};
			_macConfig.radioConfig.SetTxPower(TxPowerValue);
			_macConfig.radioConfig.SetRadioName(radioName);
			_macConfig.radioConfig.SetChannel(Channel);

			try
			{
				var retVal = MACBase.Configure(_macConfig, ReceiveHandler, NeighborChangeHandler);
				// Set up CSMA with the MAC configuration, receive callback and neighbor change callback (which does nothing)
				if (retVal != DeviceStatus.Success)
				{
					throw new CSMAException("MACBase.Configure not successful");
				}

				_csma = CSMA.Instance;
			}
			catch (MacNotConfiguredException e)
			{
				throw new CSMAException("MAC configuration exception", e);
			}
			catch (Exception e)
			{
				throw new CSMAException("Exception", e);
			}
			Debug.Print("CSMA address is :  " + _csma.GetAddress());
		}

		/// <summary>
		/// CSMA radio constructor 
		/// </summary>
		/// <param name="radioName">Name of the radio (internal, long range)</param>
		/// <param name="ccaSensetime">CCA sense time, in ms</param>
		/// <param name="txPowerValue">Power level</param>
		/// <param name="channel">Channel to use</param>
		[Obsolete("Deprecated. Use SimpleCSMA(RadioName) with properties")]
		public SimpleCSMA(RadioName radioName, byte ccaSensetime, TxPowerValue txPowerValue,
			Channels channel = Channels.Channel_26) : this(radioName)
		{
			_macConfig.CCASenseTime = CCASenseTime = ccaSensetime;
			_macConfig.radioConfig.SetTxPower(TxPowerValue = txPowerValue);
			_macConfig.radioConfig.SetChannel(Channel = channel);
		}

		/// <summary>
		/// CSMA radio constructor 
		/// </summary>
		/// <param name="radioName">Name of the radio (internal, long range)</param>
		/// <param name="ccaSensetime">CCA sense time, in ms</param>
		/// <param name="txPowerValue">Power level</param>
		/// <param name="receivePacket">Method to call when data received. Can be null if user does not want to be notified of received messages</param>
		/// <param name="channel">Channel to use</param>
		[Obsolete("Use constructor without ReceivePacket argument with OnReceive += to subscribe")]
		public SimpleCSMA(RadioName radioName, byte ccaSensetime, TxPowerValue txPowerValue, ReceivePacket receivePacket, Channels channel = Channels.Channel_26) :
			this(radioName, ccaSensetime, txPowerValue, channel)
		{
			if (receivePacket != null)
			{
				OnReceive += receivePacket;
			}
		}

		/// <summary>
		/// Send a message
		/// </summary>
		/// <param name="msgType">Message type: broadcast or CSMA address of recipient</param>
		/// <param name="message">Message to be sent, as a byte array</param>
		public void Send(Addresses msgType, byte[] message)
		{
			_csma.Send((ushort)msgType, message, 0, (ushort)message.Length);
		}

		/// <summary>
		/// Set radio state
		/// </summary>
		/// <param name="radioState">Desired radio state</param>
		/// <returns>Device status: Success, Fail, Ready, Busy</returns>
		public DeviceStatus SetRadioState(RadioStates radioState)
		{
			DeviceStatus resultStatus;
			switch (radioState)
			{
				case RadioStates.On:
					{
						resultStatus = _csma.GetRadio().TurnOn();
						break;
					}
				case RadioStates.Off:
					{
						resultStatus = _csma.GetRadio().Sleep(0);
						break;
					}
				default:
					{
						throw new Exception("Undefined RadioState: " + radioState);
					}
			}
			return resultStatus;
		}

		/// <summary>
		/// Callback when neighborhood changes
		/// </summary>
		/// <remarks>
		/// We are ignoring neighborhood changes so this method does nothing
		/// </remarks>
		/// <param name="numberOfNeighbors"></param>
		public void NeighborChangeHandler(ushort numberOfNeighbors)
		{
			if (OnNeighborChange != null)
			{
				OnNeighborChange(numberOfNeighbors, _csma);
			}
		}

		/// <summary>
		/// Callback when radio message received
		/// </summary>
		/// <remarks>
		/// If user callback is not null then call with CSMA object
		/// </remarks>
		/// <param name="numberOfPackets"></param>
		private void ReceiveHandler(ushort numberOfPackets)
		{
			// Send the CSMA object to the user.
			// No need to send numberOfPackets; that's available as CSMA.GetPendingPacketCount
			if (OnReceive != null)
			{
				OnReceive(_csma);
			}
		}
	}
}
