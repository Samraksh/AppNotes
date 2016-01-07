using System.Reflection;
using System.Text;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.HealthMonitor;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;
using Samraksh.eMote.Net;
using Samraksh.eMote.Net.Mac;
using Samraksh.eMote.Net.Radio;
using BitConverter = Samraksh.AppNote.Utility.BitConverter;

namespace Samraksh.AppNote.CSMAPingPongWithHealthMonitor
{
	/// <summary>
	/// ###
	/// </summary>
	public static class Program
	{
		private static SimpleCSMAStream _simpleCSMAStream;
		private static readonly EnhancedEmoteLCD Lcd = new EnhancedEmoteLCD();
		private static readonly OutputPort ResetPort = new OutputPort(Pins.GPIO_J12_PIN1, true);

		/// <summary>
		/// ###
		/// </summary>
		public static void Main()
		{
			Debug.Print("\nHealth Monitor " + VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));
			Thread.Sleep(4000);

			var msgBytes = new byte[sizeof(byte) + sizeof(int)];

			// Set up CSMA and CSMA Stream
			var simpleCSMA = new SimpleCSMA(RadioName.RF231RADIO, SimpleCSMA.Default.CCASenseTime, SimpleCSMA.Default.TxPowerValue, Common.Channel);
			_simpleCSMAStream = new SimpleCSMAStream(simpleCSMA);

			// Set up health monitor
			HealthMonitor.Initialize(_simpleCSMAStream, Lcd, ResetPort);

			// Set up app stream
			var appStreamCallback = new StreamCallback(Common.AppStreamId, AppCallback);
			_simpleCSMAStream.AddStreamCallback(appStreamCallback);

			// Network nodes merely display & exchange incrementing values

			// ReSharper disable once ConditionIsAlwaysTrueOrFalse
			if (Common.AppStreamId != StreamCallback.AllStreams)
			{
				var cntr = 0;
				while (cntr++ < int.MaxValue)
				{
					Lcd.Write(cntr);
					BitConverter.InsertValueIntoArray(msgBytes, 0, cntr);
					_simpleCSMAStream.Send(Addresses.BROADCAST, Common.AppStreamId, msgBytes);
					Thread.Sleep(2000);
				}
			}

			Debug.Print("Finished sending");
			Thread.Sleep(Timeout.Infinite);
		}

		/// <summary>
		/// App callback
		/// </summary>
		/// <param name="rcvMsg"></param>
		/// <param name="rcvMsgBytes"></param>
		public static void AppCallback(Message rcvMsg, byte[] rcvMsgBytes)
		{
			if (rcvMsgBytes.Length == 0)
			{
				Debug.Print("*** Network: zero length message received");
				return;
			}
			Debug.Print("\nApp Received " + (rcvMsg.Unicast ? "Unicast" : "Broadcast")
						+ ", message from src: " + rcvMsg.Src
						+ ", stream number: " + rcvMsgBytes[0]
						+ ", size: " + rcvMsg.Size
						+ ", rssi: " + rcvMsg.RSSI
						+ ", lqi: " + rcvMsg.LQI);
			var rcvPayloadStrBldr = new StringBuilder();
			for (var i = 1; i < rcvMsgBytes.Length; i++)
			{
				rcvPayloadStrBldr.Append(rcvMsgBytes[i].ToString());
				rcvPayloadStrBldr.Append(" ");
			}
			Debug.Print("\t" + rcvPayloadStrBldr);
		}
	}
}
