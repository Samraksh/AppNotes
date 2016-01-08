using System;
using System.Collections;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.Net.Mac;


namespace Samraksh.AppNote.Health
{

	///<summary>
	/// SimpleCSMA Network Stream
	///</summary>
	public class SimpleCSMAStream : INetStream
	{
		private readonly ArrayList _streamCallbacks = new ArrayList();

		private readonly SimpleCSMA _simpleCSMA;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <remarks>
		/// Save the SimpleCSMA object and subscribe to it.
		/// </remarks>
		public SimpleCSMAStream(SimpleCSMA simpleCSMA)
		{
			_simpleCSMA = simpleCSMA;
			_simpleCSMA.OnReceive += ReceivePacketHandler;
		}

		/// <summary>
		/// Look at the message contents and decides who should get it.
		/// </summary>
		/// <param name="csma"></param>
		private void ReceivePacketHandler(CSMA csma)
		{
			var rcvMsg = csma.GetNextPacket();
			if (rcvMsg == null) { return; }
			var rcvPayloadAll = rcvMsg.GetMessage();
			if (rcvPayloadAll.Length == 0) { return; }
			Debug.Print("R: " + rcvPayloadAll[0] + "," + rcvPayloadAll[1]);
			var rcvStreamId = rcvPayloadAll[0];
			var rcvPayload = new byte[rcvPayloadAll.Length - 1];
			for (var i = 1; i < rcvPayloadAll.Length; i++)
			{
				rcvPayload[i - 1] = rcvPayloadAll[i];
			}
			foreach (var theStreamCallbackObj in _streamCallbacks)
			{
				var theStreamCallback = (StreamCallback)theStreamCallbackObj;
				if (theStreamCallback.StreamId == rcvStreamId || theStreamCallback.StreamId == StreamCallback.AllStreams)
				{

					//Common.PrintByteVals("H rcv ",rcvPayload);

					theStreamCallback.MessageReceivedHandler(rcvMsg, rcvPayload);
				}
			}
		}

		/// <summary>Subscribe to a stream</summary>
		public void Subscribe(StreamCallback streamCallback)
		{
			foreach (var theStreamCallbackObj in _streamCallbacks)
			{
				var theStreamCallback = (StreamCallback)theStreamCallbackObj;
				if (theStreamCallback.StreamId == streamCallback.StreamId
					&& theStreamCallback.MessageReceivedHandler == streamCallback.MessageReceivedHandler)
				{
					return;
				}
			}
			_streamCallbacks.Add(streamCallback);
		}

		/// <summary>
		/// Unsubscribe from a scream
		/// </summary>
		public void Unsubscribe(StreamCallback streamCallback)
		{
			for (var i = 0; i < _streamCallbacks.Count; i++)
			{
				var theStreamCallback = (StreamCallback)_streamCallbacks[i];
				if (theStreamCallback.StreamId == streamCallback.StreamId
					&& theStreamCallback.MessageReceivedHandler == streamCallback.MessageReceivedHandler)
				{
					_streamCallbacks.RemoveAt(i);
				}
			}
		}

		/// <summary>
		/// Send stream message
		/// </summary>
		/// <remarks>
		/// Inserts stream id as first byte
		/// </remarks>
		public void Send(Addresses dest, byte streamId, byte[] message)
		{
			if (streamId == StreamCallback.AllStreams)
			{
				throw new ArgumentOutOfRangeException("streamId cannot be AllStreams (" + StreamCallback.AllStreams + ")");
			}

			if (message.Length == 0)
			{
				return;
			}

			// Shift the message right and insert stream ID
			var messageEx = new byte[message.Length + 1];
			for (var i = 0; i < message.Length; i++)
			{
				messageEx[i + 1] = message[i];
			}
			messageEx[0] = streamId;

			//Common.PrintByteVals("H snd ",messageEx);

			_simpleCSMA.Send(dest, messageEx);
		}

	}

}
