using Samraksh.AppNote.Utility;
using Samraksh.eMote.Net.Radio;

namespace Samraksh.AppNote.DotNow.RadarDisplacementDetector.Common
{
	/// <summary>
	/// Common items for Radar Displacement Detector
	/// </summary>
	public static class CommonItems
	{
		/// <summary>
		/// Radio Updates
		/// </summary>
		public static class RadioUpdates
		{
			/// <summary>Radio object</summary>
			public static SimpleCSMA Radio;

			/// <summary>Radio channel to use</summary>
			public const Channels Channel = Channels.Channel_11;

			/// <summary>Prepended to each packet to identify the app</summary>
			public static char AppIdentifierHdr = 'D';

			/// <summary>
			/// Radio buffer definition
			/// </summary>
			public static class BufferDef
			{
				/// <summary>Radio buffer</summary>
				public static byte[] Buffer = new byte[BuffSize];

				/// <summary>Message type position</summary>
				public const int AppIdentifier = 0;

				/// <summary>Is Displacement? position</summary>
				public const int IsDisplacement = AppIdentifier + sizeof (char);

				/// <summary>Is Confirmed? position</summary>
				public const int IsConf = IsDisplacement + sizeof (bool);

				/// <summary>Buffer size</summary>
				public const int BuffSize = IsConf + sizeof (bool);
			}
		}
	}
}