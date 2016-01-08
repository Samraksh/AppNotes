using System;

namespace Samraksh.AppNote.Utility
{
	/// <summary>
	/// Construct packets from input bytes
	/// </summary>
	public class BytePacket
	{
		/// <summary>
		/// Packet callback signature
		/// </summary>
		/// <param name="packet"></param>
		/// <param name="packetLength"></param>
		public delegate void PacketCallback(byte[] packet, int packetLength);

		private readonly byte[] _packet;
		private int _currLen;
		private readonly byte _packetDelim;
		private readonly PacketCallback _callback;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="callback">Method to call when packet received</param>
		/// <param name="maxPacketSize">Length of the packet buffer</param>
		/// <param name="packetDelim">Delimeter signifying end of packet</param>
		public BytePacket(PacketCallback callback, int maxPacketSize, byte packetDelim)
		{
			_callback = callback;
			_packet = new byte[maxPacketSize];
			_currLen = 0;
			_packetDelim = packetDelim;
		}

		/// <summary>
		/// Reset the packet. Ignore any partial packet that may be present.
		/// </summary>
		public void Reset()
		{
			_currLen = 0;
		}

		/// <summary>
		/// Add bytes to the packet.
		/// </summary>
		/// <param name="byteBuffer">Buffer containing bytes to add</param>
		/// <param name="numBytesToAdd">Number of bytes to add</param>
		/// <exception cref="ArgumentException"></exception>
		public void Add(byte[] byteBuffer, int numBytesToAdd)
		{
			if (numBytesToAdd > byteBuffer.Length)
			{
				throw new ArgumentException("Number of bytes to add (" + numBytesToAdd + ") is larger than size of input byte buffer (" + byteBuffer.Length + ")");
			}
			for (var i = 0; i < numBytesToAdd; i++)
			{
				if (byteBuffer[i] == _packetDelim)
				{
					_callback(_packet, _currLen);
					Reset();
					continue;
				}
				_packet[_currLen++] = byteBuffer[i];
			}
		}
	}
}
