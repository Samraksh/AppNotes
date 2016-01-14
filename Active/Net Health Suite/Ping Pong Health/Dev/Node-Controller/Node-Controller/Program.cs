/****************************************************************
 * Health Monitor - Controller Node
 *	Interacts with Health Monitor component of demo program PingPongHealth node
 *	
 * 1.0
 *	- Initial release
****************************************************************/

using System.Reflection;
using System.Text;
using System.Threading;
using Samraksh.AppNote.Health;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.Net;
using Samraksh.eMote.Net.Mac;
using Samraksh.eMote.Net.Radio;

/****************************************************************
 *			NOTES
 *	This appnote uses .NOW COM2 (serial) 
 *		along with SparkFun RS232 Shifter (https://www.sparkfun.com/products/449)
 *		and TRENDnet USB to Serial Converter (http://trendnet.com/products/proddetail.asp?prod=150_TU-S9&cat=49)
 *	This permits easy use in the field with terminal emulator on a computer or hand-held device.
 *	
 *	It can be modified to use COM1 via eMote .NOW USB-serial.
 * 
 *	Wiring for COM2 with SparkFun RS232 Shifter
 *		.NOW					SparkFun
 *		---------------------	--------
 *		J12/10 (ground)			GND
 *		J11/2 (+2v)				VCC
 *		J11/5 (COM2 Transmit)	Rx-0
 *		J11/6 (COM2 Receive)	Tx-1
 *	Note: for VCC it is important to use +2v as this provides the reference for shifting.
 *		Using a higher voltage such as VOut (J11/1) will probably not as transmit/receive high values may not be shifted correctly.
 ****************************************************************/

namespace Samraksh.AppNote.HealthMonitor
{
	/// <summary>
	/// Main program
	/// </summary>
	public static class Program
	{
		private static SerialComm _serialComm;
		private static SimpleCSMAStream _simpleCSMAStream;
		private static readonly byte[] MonitorSendBytes = new byte[2];

		/// <summary>
		/// Console commands
		/// </summary>
		private static class ConsoleCommands
		{
			public const char Ping = 'P';
			public const char SendLCD = 'L';
			public const char Reset = 'R';
			public const char Help = '?';
		}

		/// <summary>
		/// Main program
		/// </summary>
		public static void Main()
		{
			// Set up serial communications
			_serialComm = new SerialComm("COM2", SerialCallback);
			_serialComm.Open();

			SerialWriteCrLf("\r \nNode-Controller " + VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));

			// Set up SimpleCSMA and SimpleCSMAStream
			var simpleCSMA = new SimpleCSMA(RadioName.RF231RADIO, SimpleCSMA.Default.CCASenseTime, SimpleCSMA.Default.TxPowerValue, Common.Channel);
			_simpleCSMAStream = new SimpleCSMAStream(simpleCSMA);

			// Define the monitor stream callback
			var monitorStreamCallback = new StreamCallback(Common.MonitorStreamId, MonitorCallback);
			// Subscribe the callback to the stream
			_simpleCSMAStream.Subscribe(monitorStreamCallback);

			// Show the list of commands
			ShowHelp();

			// Sleep forever
			//	The program listens for serial input from the operator and wireless messages from the monitored program
			Thread.Sleep(Timeout.Infinite);
		}

		//===================================================================================================
		/// <summary>
		/// Serial callback method
		/// </summary>
		/// <remarks>Enacts commands from operator</remarks>
		/// <param name="readBytes"></param>
		private static void SerialCallback(byte[] readBytes)
		{
			for (var i = 0; i < readBytes.Length; i++)
			{
				var rcvChar = Encoding.UTF8.GetChars(readBytes, i, 1)[0];
				//SerialWriteCrLf("\tSerial in: " + readBytes[i] + " " + rcvChar);
				switch (rcvChar.ToUpper())
				{
					case ConsoleCommands.Ping:
						SerialWriteCrLf("<< Ping");
						Send(Addresses.BROADCAST, Common.MonitorStreamId, (byte)Common.ControllerMessage.Ping, MonitorSendBytes);
						break;
					case ConsoleCommands.SendLCD:
						SerialWriteCrLf("<< Send LCD");
						Send(Addresses.BROADCAST, Common.MonitorStreamId, (byte)Common.ControllerMessage.SendLCD, MonitorSendBytes);
						break;
					case ConsoleCommands.Reset:
						SerialWriteCrLf("<< Send Reset");
						Send(Addresses.BROADCAST, Common.MonitorStreamId, (byte)Common.ControllerMessage.Reset, MonitorSendBytes);
						break;
					case ConsoleCommands.Help:
						ShowHelp();
						break;
					default:
						SerialWriteCrLf("*** Unrecognized command " + rcvChar);
						break;
				}
			}
		}

		//===================================================================================================
		/// <summary>
		/// Health Monitor callback
		/// </summary>
		/// <remarks>Handles stream message from monitored program</remarks>
		/// <param name="rcvMsg"></param>
		/// <param name="rcvMsgBytes"></param>
		private static void MonitorCallback(Message rcvMsg, byte[] rcvMsgBytes)
		{
			// In all cases, print the message along with info about the sender
			switch (rcvMsgBytes[0])
			{
				case (byte)Common.AppNodeMessage.Pong:
				case (byte)Common.AppNodeMessage.CurrLCD:
				case (byte)Common.AppNodeMessage.NowResetting:
				case (byte)Common.AppNodeMessage.Starting:
					var response = Bytes2String(rcvMsgBytes, 1, rcvMsgBytes.Length - 1);
					SerialWriteCrLf(">>" + response + SourceRssi(rcvMsg));
					break;
				default:
					SerialWriteCrLf(">>Unrecognized node response " + rcvMsgBytes[0]);
					break;
			}
			SerialWriteCrLf();
		}

		//===================================================================================================
		/// <summary>
		/// Send message via the stream
		/// </summary>
		/// <param name="address"></param>
		/// <param name="streamId"></param>
		/// <param name="messageName"></param>
		/// <param name="message"></param>
		private static void Send(Addresses address, byte streamId, byte messageName, byte[] message)
		{
			// Shift the message right and insert message name
			for (var i = 0; i < message.Length - 1; i++)
			{
				message[i + 1] = message[i];
			}
			message[0] = messageName;

			// Send the message
			_simpleCSMAStream.Send(address, streamId, message);
		}

		private static void ShowHelp()
		{
			SerialWriteCrLf("\r \nCommands");
			SerialWriteCrLf("Ping : " + ConsoleCommands.Ping);
			SerialWriteCrLf("Send LCD: " + ConsoleCommands.SendLCD);
			SerialWriteCrLf("Reset: " + ConsoleCommands.Reset);
			SerialWriteCrLf("Help: " + ConsoleCommands.Help);
			SerialWriteCrLf();
		}

		private static string SourceRssi(Message rcvMsg)
		{
			return "\r \n\tfrom " + rcvMsg.Src + ", rssi " + rcvMsg.RSSI;
		}

		private static string Bytes2String(byte[] packet, int start, int length)
		{
			var packetString = new StringBuilder();
			for (var i = start; i < start + length; i++)
			{
				if (packet[i] > 0)
				{
					packetString.Append(Encoding.UTF8.GetChars(packet, i, 1));
				}
			}
			return packetString.ToString();
		}

		private static void SerialWriteCrLf(string line)
		{
			_serialComm.Write(line);
			SerialWriteCrLf();
		}

		private static void SerialWriteCrLf()
		{
			_serialComm.Write("\r \n");

		}
	}
}
