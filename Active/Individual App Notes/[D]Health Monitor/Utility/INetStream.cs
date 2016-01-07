using Samraksh.eMote.Net.Mac;

namespace Samraksh.AppNote.Utility
{
	/// <summary>
	/// Interface for network streams
	/// </summary>
	public interface INetStream
	{
		/// <summary>Add a callback to a stream</summary>
		void Subscribe(StreamCallback streamCallback);

		/// <summary>Remove a callback from a stream</summary>
		void Unsubscribe(StreamCallback streamCallback);

		/// <summary>Send a message</summary>
		void Send(Addresses dest, byte streamId, byte[] message);
	}

	/// <summary>
	/// Callback for network streams
	/// </summary>
	/// <remarks>
	/// 
	/// </remarks>
	public class StreamCallback
	{
		/// <summary>Special stream ID for all streams</summary>
		public const byte AllStreams = byte.MaxValue;

		/// <summary>Get the stream ID</summary>
		public byte StreamId { get; private set; }

		/// <summary>
		/// A StreamCallback instance consists of a stream ID and a callback method
		/// </summary>
		public StreamCallback(byte streamId, MessageReceived messageReceivedHandler)
		{
			StreamId = streamId;
			MessageReceivedHandler = messageReceivedHandler;
		}
		/// <summary>Get the callback method</summary>
		public MessageReceived MessageReceivedHandler { get; private set; }

		/// <summary>
		/// A stream callback gets a Message and a byte array containing the message contents
		/// </summary>
		/// <param name="message">The message received</param>
		/// <param name="messageBytes">The message contents</param>
		/// <remarks>
		/// The message contents are included separately for 2 reasons:
		/// - It excludes the stream ID.
		/// - Checking for stream ID requires getting the received message contents. This can only be done once.
		/// </remarks>
		public delegate void MessageReceived(eMote.Net.Message message, byte[] messageBytes);


	}

}
