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
	public class Program
	{
		/// <summary>
		/// ###
		/// </summary>
		public static void Main()
		{
			Debug.Print("\nHealth Monitor " + VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));
			Thread.Sleep(4000);

			var lcd = new EnhancedEmoteLCD();

			var msgBytes = new byte[sizeof(bool) + sizeof(int)];

			const byte streamId = 1;

			var simpleCSMA = new SimpleCSMA(RadioName.RF231RADIO, SimpleCSMA.Default.CCASenseTime, SimpleCSMA.Default.TxPowerValue, Channels.Channel_11);
			var simpleCSMAStream = new SimpleCSMAStream(simpleCSMA);
			var streamCallback = new StreamCallback(streamId, Callback);
			simpleCSMAStream.AddStreamCallback(streamCallback);

			// ReSharper disable once ConditionIsAlwaysTrueOrFalse
			if (streamId != StreamCallback.AllStreams)
			{
				var cntr = 0;
				while (cntr++ < int.MaxValue)
				{
					lcd.Write(cntr);
					BitConverter.InsertValueIntoArray(msgBytes, 1, cntr);
					simpleCSMAStream.Send(Addresses.BROADCAST, streamId, msgBytes);
					Thread.Sleep(2000);
				}
			}

			Debug.Print("Finished sending");
			Thread.Sleep(Timeout.Infinite);

		}

		private static void Callback(Message rcvMsg)
		{
			var rcvPayloadBytes = rcvMsg.GetMessage();
			if (rcvPayloadBytes.Length == 0)
			{
				Debug.Print("*** zero length message received");
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
