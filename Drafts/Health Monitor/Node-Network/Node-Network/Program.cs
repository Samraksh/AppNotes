using System;
using System.Reflection;
using System.Text;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;
using Samraksh.eMote.Net;
using Samraksh.eMote.Net.Mac;
using Samraksh.eMote.Net.Radio;
using BitConverter = Samraksh.AppNote.Utility.BitConverter;

namespace Samraksh.AppNote.HealthMonitor
{

	/// <summary>
	/// ###
	/// </summary>
	public static class Program
	{
		private static SimpleCSMAStream _simpleCSMAStream;
		private static readonly EnhancedEmoteLCD Lcd = new EnhancedEmoteLCD();

		private static readonly OutputPort ResetEnable = new OutputPort(Pins.GPIO_J12_PIN1, true);

		/// <summary>
		/// ###
		/// </summary>
		public static void Main()
		{
			Debug.Print("\nHealth Monitor " + VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));
			Thread.Sleep(4000);


			var msgBytes = new byte[sizeof(bool) + sizeof(int)];

			var simpleCSMA = new SimpleCSMA(RadioName.RF231RADIO, SimpleCSMA.Default.CCASenseTime, SimpleCSMA.Default.TxPowerValue, Common.Channel);
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
					Lcd.Write(cntr);
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

		
	}
}
