using System;
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


/*=====================================================
 * Configuration
 * Jumper .NOW J12/1 (GPIO output) to J12/6 (reset)
 ====================================================*/

namespace Samraksh.AppNote.CSMAPingPongWithHealthMonitor
{
	/// <summary>
	/// ###
	/// </summary>
	public static class Program
	{
		private static SimpleCSMAStream _simpleCSMAStream;
		private static readonly EnhancedEmoteLCD Lcd = new EnhancedEmoteLCD();

		/// <summary>
		/// This port is used to reset the node. 
		/// Under command of the health monitor controller, the port is pulled low.
		/// Since it is jumpered to J12/6 (reset), this brings J12/6 low and resets the mote.
		/// </summary>
		private static readonly OutputPort ResetPort = new OutputPort(Pins.GPIO_J12_PIN1, true);


		// This is used as a header for the packet payload to identify the app
		private const string Header = "PingPong";

		// The current value
		static int _currVal;

		// Reply timer. Slows down interaction by not sending reply messages until the timer expires
		private const int SendInterval = 4000; // Time to wait before sending reply
		static Timer _replyTimer;
		static readonly TimerCallback ReplyTimerCallback = reply_Timeout;

		// No response timer. If no message received, send current value again
		//  Timer is reset whenever a message is received
		private const int NoResponseInterval = SendInterval * 4; // Time to wait before re-sending; must be larger than send interval
		private static Timer _noResponseDelayTimer;
		private static readonly TimerCallback NoResponseDelayTimerCallback = noResponseDelay_Timeout;


		/// <summary>
		/// Main program
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
			_simpleCSMAStream.Subscribe(appStreamCallback);



			// Display a welcome message
			Lcd.Write("Hola");
			Thread.Sleep(4000);

			// Pick a value randomly
			_currVal = (new Random()).Next(99);  // We're choosing a fairly small value to avoid runover on the LCD display (since it only has 4 positions)
			Lcd.Write(_currVal);

			// Send the current value now
			_simpleCSMAStream.Send(Addresses.BROADCAST, Common.AppStreamId, Encoding.UTF8.GetBytes(_currVal.ToString().Trim()));

			// Start a one-shot timer that resets itself whenever it expires
			StartOneshotTimer(ref _noResponseDelayTimer, NoResponseDelayTimerCallback, NoResponseInterval);

			// Everything is set up. Go to sleep forever, pending events
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
