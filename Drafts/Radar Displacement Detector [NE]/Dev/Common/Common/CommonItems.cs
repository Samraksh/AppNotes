using Samraksh.eMote.Net;
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
			public static MACBase MAC;

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

				/// <summary>Sequence Number</summary>
				public const int SeqNum = AppIdentifier + sizeof(char);

				/// <summary>Is Displacement? position</summary>
				public const int IsDisplacement = SeqNum + sizeof (int);

				/// <summary>Is Confirmed? position</summary>
				public const int IsConf = IsDisplacement + sizeof (bool);

				/// <summary>Buffer size</summary>
				public const int BuffSize = IsConf + sizeof (bool);
			}
		}
	}
}
