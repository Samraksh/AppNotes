/*------------------------------------------------------------------------
 *      Declarations & constants that are common between Base and Sensing nodes
 *      
 *      Changes made here will affect both programs
 * ---------------------------------------------------------------------*/


/*------------------------------------------------------------------------
 * Message Formats
 * 
 * Hello
 *      App Identifier (2)
 *      Payload Type (1) : Hello
 *      Payload Sequence Number (4)
 *      Payload Send Time (8)
 *  Data
 *      App Identifier (2)
 *      Payload Type (1) : Data
 *      Payload Sequence Number (4)
 *      Payload Send Time (8)
 *      
 *      Sensing Time 1 (8)
 *      Sensed Data 1 (4)
 *          ...
 *      Sensing Time N (8)
 *      Sensed Data N (4)
 *  Reply
 *      App Identifier (2)
 *      Payload Type (1) : Reply
 *      Payload Sequence Number (4)
 * ---------------------------------------------------------------------*/


namespace Samraksh.AppNote.WirelessDataCollector
{
	/// <summary>
	/// Common items for Wireless Data Collector
	/// </summary>
	public partial class Common
	{
		/// <summary>
		/// Payload Types
		/// </summary>
		public enum PayloadTypes : byte
		{
			/// <summary>Hello from Sensing</summary>
			Hello,
			/// <summary>Reply from Base</summary>
			Reply,
			/// <summary>Data from Sensing</summary>
			Data
		};

		/// <summary>The application ID</summary>
		public const string ApplicationId = "DC";
		/// <summary>The size (in chars/bytes) of the application ID</summary>
		public static readonly int ApplicationIdSize = ApplicationId.Length;
		/// <summary>Position in the payload for the start of the application ID</summary>
		public const int ApplicationIdPos = 0;
		/// <summary>A byte array that stores the application ID, for easy comparison</summary>
		public static byte[] ApplicationIdBytes = new byte[ApplicationIdSize];

		/// <summary>Payload type size in bytes</summary>
		public static readonly int PayloadTypeSize = sizeof(PayloadTypes);
		/// <summary>Position in the payload for the start of the payload type</summary>
		public static readonly int PayloadTypePos = ApplicationIdPos + ApplicationIdSize;

		/// <summary>Message sequence size in bytes</summary>
		public const int MessageSequenceSize = sizeof(int);
		/// <summary>Position in the payload for the start of the message sequence number</summary>
		public static readonly int MessageSequencePos = PayloadTypePos + PayloadTypeSize;

		/// <summary>Message time size in bytes</summary>
		public const int MessageTimeSize = sizeof(long);
		/// <summary>Position in the payload for the start of the message time</summary>
		public static readonly int MessageTimePos = MessageSequencePos + MessageSequenceSize;

		/// <summary>Payload header size in bytes (sum of the sizes of application ID, payload type, message sequence number and message time)</summary>
		public static readonly int PayloadHeaderSize = ApplicationIdSize + PayloadTypeSize +
														MessageSequenceSize + MessageTimeSize;

		/// <summary>Sample time size in bytes</summary>
		public const int SampleTimeSize = MessageTimeSize;
		/// <summary>Sample data size in bytes</summary>
		public const int SampleDataSize = sizeof(int);
		/// <summary>Sample time-data size in bytes (sum of sizes of sample time and sample data</summary>
		public const int SampleTimeDataLen = SampleTimeSize + SampleDataSize;
	}
}
