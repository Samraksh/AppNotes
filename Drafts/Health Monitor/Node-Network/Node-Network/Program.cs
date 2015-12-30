using System.Reflection;
using System.Text;
using System.Threading;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.Net;
using Samraksh.eMote.Net.Mac;
using Samraksh.eMote.Net.Radio;

namespace Samraksh.AppNote.HealthMonitor
{

	/// <summary>
	/// ###
	/// </summary>
	public static class Program
	{
		private static SimpleCSMAStream _simpleCSMAStream;

		/// <summary>
		/// ###
		/// </summary>
		public static void Main()
		{
			Debug.Print("\nHealth Monitor " + VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));
			Thread.Sleep(4000);

			var lcd = new EnhancedEmoteLCD();

			var msgBytes = new byte[sizeof(bool) + sizeof(int)];

			var simpleCSMA = new SimpleCSMA(RadioName.RF231RADIO, SimpleCSMA.Default.CCASenseTime, SimpleCSMA.Default.TxPowerValue, Channels.Channel_11);
			_simpleCSMAStream = new SimpleCSMAStream(simpleCSMA);

			var networkStreamCallback = new StreamCallback(Common.NetworkStreamId, NetworkCallback);
			_simpleCSMAStream.AddStreamCallback(networkStreamCallback);

			var monitorStreamCallback = new StreamCallback(Common.MonitorStreamId, MonitorCallback);
			_simpleCSMAStream.AddStreamCallback(monitorStreamCallback);

			// Network nodes merely display & exchange incrementing values

			// ReSharper disable once ConditionIsAlwaysTrueOrFalse
			if (Common.NetworkStreamId != StreamCallback.AllStreams)
			{
				var cntr = 0;
				while (cntr++ < int.MaxValue)
				{
					lcd.Write(cntr);
					BitConverter.InsertValueIntoArray(msgBytes, 1, cntr);
					_simpleCSMAStream.Send(Addresses.BROADCAST, Common.NetworkStreamId, msgBytes);
					Thread.Sleep(2000);
				}
			}

			Debug.Print("Finished sending");
			Thread.Sleep(Timeout.Infinite);

		}

		private static void NetworkCallback(Message rcvMsg)
		{
			var rcvPayloadBytes = rcvMsg.GetMessage();
			if (rcvPayloadBytes.Length == 0)
			{
				Debug.Print("*** Network: zero length message received");
				return;
			}
			Debug.Print("\nReceived " + (rcvMsg.Unicast ? "Unicast" : "Broadcast")
				+ ", message from src: " + rcvMsg.Src
				+ ", stream number: " + rcvPayloadBytes[0]
				+ ", size: " + rcvMsg.Size
				+ ", rssi: " + rcvMsg.RSSI
				+ ", lqi: " + rcvMsg.LQI);
			var rcvPayloadStrBldr = new StringBuilder();
			for (var i = 1; i < rcvPayloadBytes.Length; i++)
			{
				rcvPayloadStrBldr.Append(rcvPayloadBytes[i].ToString());
				rcvPayloadStrBldr.Append(" ");
			}
			Debug.Print("\t" + rcvPayloadStrBldr);
		}

		private static void MonitorCallback(Message rcvMsg)
		{
			var rcvPayloadBytes = rcvMsg.GetMessage();
			if (rcvPayloadBytes.Length <= 1)
			{
				Debug.Print("*** Monitor: message of length " + rcvPayloadBytes.Length + " received");
				return;
			}
			var controllerMessage = rcvPayloadBytes[1];
			switch (controllerMessage)
			{
				case (byte)Common.ControllerMessage.Ping:
					Debug.Print("Received " + Common.ControllerMessage.Ping);
					_simpleCSMAStream.Send((Addresses)rcvMsg.Src, Common.MonitorStreamId, new byte[0]);
					break;
				default:
					Debug.Print("Unknown message received from controller: " + controllerMessage);
					break;
			}
		}
	}
}
