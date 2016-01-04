using Samraksh.eMote.Net.Radio;

namespace Samraksh.AppNote.HealthMonitor
{
	public static class Common
	{
		public enum ControllerMessage : byte
		{
			Ping = 0,
			SendLCD = 1,
			Reset = 2,
		}

		public enum NodeMessage : byte
		{
			Pong = 0,
			CurrLCD = 1,
			NowResetting = 2,
		}

		public const byte NetworkStreamId = 1;
		public const byte MonitorStreamId = 2;

		public const Channels Channel = Channels.Channel_11;
		

	}


}
