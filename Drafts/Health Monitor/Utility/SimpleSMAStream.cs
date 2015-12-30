using System;
using System.Collections;
using Samraksh.eMote.Net.Mac;

namespace Samraksh.AppNote.Utility
{

	/// <summary>###</summary>
	public class SimpleCSMAStream : INetStream
	{
		private readonly ArrayList _streamCallbacks = new ArrayList();

		private readonly SimpleCSMA _simpleCSMA;

		/// <summary>###</summary>
		public SimpleCSMAStream(SimpleCSMA simpleCSMA)
		{
			_simpleCSMA = simpleCSMA;
			_simpleCSMA.OnReceive += ReceivePacketHandler;
		}

		private void ReceivePacketHandler(CSMA csma)
		{
			var rcvMsg = csma.GetNextPacket();
			if (rcvMsg == null) { return; }
			var rcvPayloadBytes = rcvMsg.GetMessage();
			if (rcvPayloadBytes.Length == 0) { return; }
			var rcvStreamId = rcvPayloadBytes[0];
			foreach (var theStreamCallbackObj in _streamCallbacks)
			{
				var theStreamCallback = (StreamCallback)theStreamCallbackObj;
				if (theStreamCallback.StreamId == rcvStreamId || theStreamCallback.StreamId == StreamCallback.AllStreams)
				{
					theStreamCallback.CallbackHandlerStreamMessage(rcvMsg);
				}
			}
		}

		/// <summary>###</summary>
		public void AddStreamCallback(StreamCallback streamCallback)
		{
			foreach (var theStreamCallbackObj in _streamCallbacks)
			{
				var theStreamCallback = (StreamCallback)theStreamCallbackObj;
				if (theStreamCallback.StreamId == streamCallback.StreamId
					&& theStreamCallback.CallbackHandlerStreamMessage == streamCallback.CallbackHandlerStreamMessage)
				{
					return;
				}
			}
			_streamCallbacks.Add(streamCallback);
		}

		/// <summary>###</summary>
		public void RemoveStreamCallback(StreamCallback streamCallback)
		{
			for (var i = 0; i < _streamCallbacks.Count; i++)
			{
				var theStreamCallback = (StreamCallback)_streamCallbacks[i];
				if (theStreamCallback.StreamId == streamCallback.StreamId
					&& theStreamCallback.CallbackHandlerStreamMessage == streamCallback.CallbackHandlerStreamMessage)
				{
					_streamCallbacks.RemoveAt(i);
				}
			}
		}

		/// <summary>###</summary>
		public void Send(Addresses dest, byte streamId, byte[] message)
		{
			if (streamId == StreamCallback.AllStreams)
			{
				throw new ArgumentOutOfRangeException("streamId must be less than " + StreamCallback.AllStreams);
			}
			if (message.Length == 0) { return; }
			message[0] = streamId;
			_simpleCSMA.Send(dest,message);
		}

	}

}
