using System;
using System.Reflection;
using System.Text;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Health;
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

		// The current value
		private static int _currVal;

		// Reply timer. Slows down interaction by not sending reply messages until the timer expires
		private const int SendInterval = 4000; // Time to wait before sending reply
		private static readonly SimpleOneshotTimer ReplyTimer = new SimpleOneshotTimer(Reply_Timeout, null, SendInterval);

		// No response timer. If no message received, send current value again
		//  Timer is reset whenever a message is received
		private const int NoResponseInterval = SendInterval * 4; // Time to wait before re-sending; must be larger than send interval
		private static readonly SimpleOneshotTimer NoResponseDelayTimer = new SimpleOneshotTimer(NoResponseDelay_Timeout, null, NoResponseInterval);

		//===================================================================================================
		/// <summary>
		/// Main program
		/// </summary>
		public static void Main()
		{
			Debug.Print("\nHealth Monitor " + VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));
			Thread.Sleep(4000);

			// Set up CSMA and CSMA Stream
			var simpleCSMA = new SimpleCSMA(RadioName.RF231RADIO, SimpleCSMA.Default.CCASenseTime, SimpleCSMA.Default.TxPowerValue, Common.Channel);
			_simpleCSMAStream = new SimpleCSMAStream(simpleCSMA);

			// Set up health monitor
			HealthMonitor.Initialize(_simpleCSMAStream, Lcd, ResetPort);

			// Set up app stream
			var appStreamCallback = new StreamCallback(Common.AppStreamId, AppCallback);
			_simpleCSMAStream.Subscribe(appStreamCallback);

			// Begin the logic of the program

			// Display a welcome message
			Lcd.Write("Hola");
			Thread.Sleep(4000);

			// Pick a value randomly
			_currVal = new Random().Next(99);  // We're choosing a fairly small value to avoid runover on the LCD display (since it only has 4 positions)
			Lcd.Write(_currVal);

			// Send the current value now
			SendAppMessage(_currVal);

			// Start the no-response timer
			//	This is reset when a response is received
			//	When it fires, it sends the current value again
			NoResponseDelayTimer.Start();

			// Everything is set up. Go to sleep forever, pending events
			Thread.Sleep(Timeout.Infinite);
		}

		//===================================================================================================
		/// <summary>
		/// Send the current value when the reply timer expires
		/// </summary>
		/// <param name="obj">Ignored</param>
		private static void Reply_Timeout(object obj)
		{
			//Debug.Print("Sending response message " + _currVal);
			SendAppMessage(_currVal);
		}

		//===================================================================================================
		/// <summary>
		/// Resend the current value when the no-response timer expires
		/// </summary>
		/// <param name="obj">Ignored</param>
		private static void NoResponseDelay_Timeout(object obj)
		{
			Debug.Print("No message received ... sending again");
			SendAppMessage(_currVal);
			// Give a short pause to show that we've received no response
			Lcd.Write("aaaa");
			Thread.Sleep(500);
			Lcd.Write(_currVal);
			// Restart the no-response timer
			NoResponseDelayTimer.Start();
		}

		//===================================================================================================
		/// <summary>
		/// Send an app message via Netstream
		/// </summary>
		/// <param name="value"></param>
		private static void SendAppMessage(int value)
		{
			Lcd.Write(value);
			BitConverter.InsertValueIntoArray(ValueBytes, 0, value);
			_simpleCSMAStream.Send(Addresses.BROADCAST, Common.AppStreamId, ValueBytes);
		}
		private static readonly byte[] ValueBytes = new byte[sizeof(int)];

		//===================================================================================================
		/// <summary>
		/// Netstream callback for the app
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
						+ ", msg size: " + rcvMsgBytes.Length
						+ ", rssi: " + rcvMsg.RSSI
						+ ", lqi: " + rcvMsg.LQI);
			var rcvPayloadStrBldr = new StringBuilder("Netstream rcv ");
			for (var i = 0; i < rcvMsgBytes.Length; i++)
			{
				rcvPayloadStrBldr.Append(rcvMsgBytes[i].ToString());
				rcvPayloadStrBldr.Append(" ");
			}
			Debug.Print("\t" + rcvPayloadStrBldr);

			if (rcvMsgBytes.Length < sizeof(int))
			{
				Debug.Print("*** Network: message received too short: " + rcvMsgBytes.Length + " bytes; should be at least " + sizeof(int));
				return;
			}
			var receivedValue = BitConverter.ToInt32(rcvMsgBytes, 0);

			// Stabilize to max and increment
			_currVal = System.Math.Max(receivedValue, _currVal) + 1;
			Lcd.Write(_currVal);

			// Start the reply timer
			ReplyTimer.Start();
			//	(Re)start the no-response timer
			NoResponseDelayTimer.Start();
		}
	}
}
