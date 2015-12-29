using Samraksh.eMote.Net.Radio;

namespace Samraksh.AppNote.Utility
{
	public partial class SimpleCSMA 
	{
		/// <summary>
		/// Default values
		/// </summary>
		private static class Default
		{
			public const byte CCASenseTime = 100;
			public const TxPowerValue TxPowerValue = eMote.Net.Radio.TxPowerValue.Power_3dBm;
			public const Channels Channel = Channels.Channel_26;
			public const uint NeighborLivenessDelay = 100;
		}

		/// <summary>CCA sense time</summary>
		public byte CCASenseTime
		{
			get
			{
				return _ccaSenseTime;
			}
			set
			{
				_ccaSenseTime = value;
				_macConfig.CCASenseTime = value;
				EnactMACConfig();
			}
		}
		private byte _ccaSenseTime;

		/// <summary>Neighbor Liveness Delay</summary>
		public uint NeighborLivenessDelay
		{
			get { return _neighborLivenessDelay; }
			set
			{
				_neighborLivenessDelay = value;
				_macConfig.NeighborLivenessDelay = value;
				EnactMACConfig();
			}
		}
		private uint _neighborLivenessDelay;

		/// <summary>Tx power value</summary>
		public TxPowerValue TxPowerValue
		{
			get
			{
				return _txPowerValue;
			}
			set
			{
				_txPowerValue = value;
				_macConfig.radioConfig.SetTxPower(value);
				EnactMACConfig();
			}
		}
		private TxPowerValue _txPowerValue;

		/// <summary>Channel</summary>
		public Channels Channel
		{
			get
			{
				return _channel;
			}
			set
			{
				_channel = value;
				_macConfig.radioConfig.SetChannel(value);
				EnactMACConfig();
			}
		}
		private Channels _channel;

		/// <summary>RadioName</summary>
		public RadioName RadioName
		{
			get
			{
				return _radioName;
			}
			set
			{
				_radioName = value;
				_macConfig.radioConfig.SetRadioName(value);
				EnactMACConfig();
			}
		}
		private RadioName _radioName;


	}
}
