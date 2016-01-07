using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using Microsoft.SPOT;
using Samraksh.eMote.Net;
using Samraksh.eMote.Net.Mac;

namespace Samraksh.AppNote.Utility
{
	/// <summary>
	/// 
	/// </summary>
	public interface INetStream
	{
		/// <summary>###</summary>
		void AddStreamCallback(StreamCallback streamCallback);
		/// <summary>###</summary>
		void RemoveStreamCallback(StreamCallback streamCallback);
		/// <summary>###</summary>
		void Send(Addresses dest, byte streamId, byte[] message);
	}

	/// <summary>
	/// ###
	/// </summary>
	public class StreamCallback
	{
		/// <summary>###</summary>
		public const byte AllStreams = byte.MaxValue;

		/// <summary>###</summary>
		public byte StreamId { get; private set; }

		/// <summary>###</summary>
		public ReceiveDelegateStreamMessage CallbackHandlerStreamMessage { get; private set; }

		/// <summary>###</summary>
		public delegate void ReceiveDelegateStreamMessage(Message message, byte[] messageBytes);


		/// <summary>###</summary>
		public StreamCallback(byte streamId, ReceiveDelegateStreamMessage callbackHandlerStreamMessage)
		{
			StreamId = streamId;
			CallbackHandlerStreamMessage = callbackHandlerStreamMessage;
		}
	}

}
