using System.IO.Ports;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;
using Math = System.Math;

namespace Samraksh.AppNote.DotNow.SerialPingPong
{
	public abstract class PingPongMethods
	{
		public abstract void Send(byte[] sendPacket, int sendSize);
		public abstract void Send(byte[] sendPacket);
		public abstract void Send(string sendString);
	}

	/// <summary>
	/// Implementation of PingPongMethods for serial (com)
	/// </summary>
	public class SerialPingPongMethods : PingPongMethods
	{
		private readonly SerialPort _serialPort;
		private readonly byte[] _byteBuffer = new byte[200];
		private readonly BytePacket _bytePacket;
		private readonly byte _packetDelim;

		/// <summary>
		/// Constructor for SerialPingPongMethods
		/// </summary>
		/// <param name="callback"></param>
		/// <param name="maxPacketSize"></param>
		/// <param name="packetDelim"></param>
		public SerialPingPongMethods(BytePacket.PacketCallback callback, int maxPacketSize, byte packetDelim)
		{
			_packetDelim = packetDelim;
			_bytePacket = new BytePacket(callback, maxPacketSize, packetDelim);
			_serialPort = new SerialPort("COM2")
			{
				BaudRate = 115200,
				Parity = Parity.None,
				DataBits = 8,
				StopBits = StopBits.One,
				Handshake = Handshake.None,
			};
			_serialPort.DataReceived += DataReceived;
			_serialPort.Open();
		}

		/// <summary>
		/// Send bytes
		/// </summary>
		/// <param name="sendPacket"></param>
		/// <param name="sendSize"></param>
		public override void Send(byte[] sendPacket, int sendSize)
		{
			_serialPort.Write(sendPacket, 0, sendSize);
			_serialPort.WriteByte(_packetDelim);
			_serialPort.Flush();
		}

		public override void Send(byte[] sendPacket)
		{
			Send(sendPacket, sendPacket.Length);
		}

		public override void Send(string sendString)
		{
			//Debug.Print("Sending " + sendString);
			var currValBytes = System.Text.Encoding.UTF8.GetBytes(sendString);
			//Debug.Print("\t" + currValBytes.Length + " bytes");
			Send(currValBytes);
		}

		/// <summary>
		/// Receive incoming bytes
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			while (_serialPort.BytesToRead > 0)
			{
				var bytesRead = _serialPort.Read(_byteBuffer, 0, Math.Max(_serialPort.BytesToRead, _byteBuffer.Length));
				//Debug.Print("BytesToRead: " + _serialPort.BytesToRead + ", bytesRead: " + bytesRead);
				// _bytePacket.Add processes the incoming bytes and calls the user callback when a delimeter is found
				_bytePacket.Add(_byteBuffer, bytesRead);
			}
		}


	}
}
