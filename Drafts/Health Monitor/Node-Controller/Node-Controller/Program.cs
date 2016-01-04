using System.Reflection;
using System.Text;
using System.Threading;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.Net;
using Samraksh.eMote.Net.Mac;
using Samraksh.eMote.Net.Radio;

namespace Samraksh.AppNote.HealthMonitor
{
	public static class Program
	{
		private static SerialComm _serialComm;
		private static SimpleCSMAStream _simpleCSMAStream;

		public static void Main()
		{

			_serialComm = new SerialComm("COM2", SerialCallback);
			_serialComm.Open();

			SerialWriteCrLf("\r \nNode-Controller " + VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));

			ShowHelp();

			var simpleCSMA = new SimpleCSMA(RadioName.RF231RADIO, SimpleCSMA.Default.CCASenseTime, SimpleCSMA.Default.TxPowerValue, Common.Channel);
			_simpleCSMAStream = new SimpleCSMAStream(simpleCSMA);

			var monitorStreamCallback = new StreamCallback(Common.MonitorStreamId, MonitorCallback);
			_simpleCSMAStream.AddStreamCallback(monitorStreamCallback);

			//var cntr = 0;
			//while (cntr++ < int.MaxValue)
			//{
			//	var cntrStr = cntr + "\r"+"\n";
			//	//var utf16Bytes = Encoding.UTF8.GetBytes(cntrStr);
			//	_serialComm.Write(cntrStr);
			//	Thread.Sleep(5000);
			//}

			Thread.Sleep(Timeout.Infinite);
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

		private static readonly byte[] MonitorSendBytes = new byte[2];

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
						MonitorSendBytes[1] = (byte)Common.ControllerMessage.Ping;
						_simpleCSMAStream.Send(Addresses.BROADCAST, Common.MonitorStreamId, MonitorSendBytes);
						break;
					case ConsoleCommands.SendLCD:
						SerialWriteCrLf("<< Send LCD");
						MonitorSendBytes[1] = (byte)Common.ControllerMessage.SendLCD;
						_simpleCSMAStream.Send(Addresses.BROADCAST, Common.MonitorStreamId, MonitorSendBytes);
						break;
					case ConsoleCommands.Reset:
						MonitorSendBytes[1] = (byte)Common.ControllerMessage.Reset;
						_simpleCSMAStream.Send(Addresses.BROADCAST, Common.MonitorStreamId, MonitorSendBytes);
						break;
					case ConsoleCommands.Help:
						ShowHelp();
						break;
					default:
						SerialWriteCrLf("*** Unrecognized command " + rcvChar);
						break;
				}
			}

			//var bytestr = new StringBuilder();
			//foreach (var theByte in readBytes)
			//{
			//	bytestr.Append(theByte);
			//	bytestr.Append(' ');
			//}
			//Debug.Print(bytestr.ToString());
			//_serialComm.Write(bytestr + "\r" + "\n");
		}

		private static void MonitorCallback(Message rcvMsg)
		{
			var rcvPayloadBytes = rcvMsg.GetMessage();
			switch (rcvPayloadBytes[1])
			{
				case (byte)Common.NodeMessage.Pong:
				case (byte)Common.NodeMessage.CurrLCD:
				case (byte)Common.NodeMessage.NowResetting:
					var response = Packet2String(rcvPayloadBytes, 2, rcvPayloadBytes.Length - 2);
					SerialWriteCrLf(">>" + response + SourceRssi(rcvMsg));
					break;
				default:
					SerialWriteCrLf(">>Unrecognized node response " + rcvPayloadBytes[1]);
					break;
			}
			SerialWriteCrLf();

			//SerialWriteCrLf("\nReceived " + (rcvMsg.Unicast ? "Unicast" : "Broadcast")
			//	+ ", message from src: " + rcvMsg.Src
			//	+ ", stream number: " + rcvPayloadBytes[0]
			//	+ ", size: " + rcvMsg.Size
			//	+ ", rssi: " + rcvMsg.RSSI
			//	+ ", lqi: " + rcvMsg.LQI);
			//var rcvPayloadStrBldr = new StringBuilder();
			//for (var i = 1; i < rcvPayloadBytes.Length; i++)
			//{
			//	if (rcvPayloadBytes[i] > 0)
			//	{
			//		rcvPayloadStrBldr.Append(Encoding.UTF8.GetChars(rcvPayloadBytes, i, 1));
			//	}
			//rcvPayloadStrBldr.Append(rcvPayloadBytes[i].ToString());
			//rcvPayloadStrBldr.Append(" ");
			//}
			//SerialWriteCrLf("\t" + rcvPayloadStrBldr);
		}

		private static string SourceRssi(Message rcvMsg)
		{
			return " from " + rcvMsg.Src + ", rssi " + rcvMsg.RSSI;
		}

		private static string Packet2String(byte[] packet, int start, int length)
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

		private static class ConsoleCommands
		{
			public const char Ping = 'P';
			public const char SendLCD = 'L';
			public const char Reset = 'R';
			public const char Help = '?';
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
