using Samraksh.eMote.Net.Radio;

namespace Samraksh.AppNote.HealthMonitor
{
	/// <summary>
	/// Common items for health monitor
	/// </summary>
	public static class Common
	{
		/// <summary>
		/// Controller messages
		/// </summary>
		public enum ControllerMessage : byte
		{
			/// <summary>
			/// Ping managed nodes
			/// </summary>
			Ping = 0,
			/// <summary>
			/// Request current LCD values from managed nodes
			/// </summary>
			SendLCD = 1,
			/// <summary>
			/// Request that managed nodes reset
			/// </summary>
			Reset = 2,
		}

		/// <summary>
		/// App node messages
		/// </summary>
		public enum NodeMessage : byte
		{
			/// <summary>
			/// Reply with pong
			/// </summary>
			Pong = 0,
			/// <summary>
			/// Reply with current LCD values
			/// </summary>
			CurrLCD = 1,
			/// <summary>
			/// Reply that now resetting
			/// </summary>
			NowResetting = 2,
			/// <summary>
			/// Broadcast that starting
			/// </summary>
			Starting = 3,
		}

		/// <summary>
		/// Application stream id
		/// </summary>
		public const byte AppStreamId = 1;

		/// <summary>
		/// Health monitor stream ID
		/// </summary>
		public const byte MonitorStreamId = 2;

		/// <summary>
		/// Radio channel for app and health monitor
		/// </summary>
		public const Channels Channel = Channels.Channel_11;
		

	}


}
