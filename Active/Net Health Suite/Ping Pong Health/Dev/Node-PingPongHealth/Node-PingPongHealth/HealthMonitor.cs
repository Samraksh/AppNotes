using System;
using System.Text;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Health;
using Samraksh.AppNote.HealthMonitor;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.Net.Mac;

namespace Samraksh.AppNote.CSMAPingPongWithHealthMonitor
{
	/// <summary>
	/// Health monitor component for the main app
	/// </summary>
	public static class HealthMonitor
	{
		private static EnhancedEmoteLCD _lcd;
		private static SimpleCSMAStream _simpleCSMAStreamInstance;
		private static OutputPort _resetPort;

		private static Random _randomizer;
		private static int _sendDelay;

		/// <summary>
		/// Health Monitor initialization
		/// </summary>
		/// <param name="simpleCSMAStreamInstance"></param>
		/// <param name="lcd"></param>
		/// <param name="resetPort"></param>
		public static void Initialize(SimpleCSMAStream simpleCSMAStreamInstance, EnhancedEmoteLCD lcd, OutputPort resetPort)
		{
			// Save the argument values
			_simpleCSMAStreamInstance = simpleCSMAStreamInstance;
			_lcd = lcd;
			_resetPort = resetPort;

			// Define the monitor stream callback
			var monitorStreamCallback = new StreamCallback(Common.MonitorStreamId, MonitorCallback);
			// Subscribe the callback to the stream
			_simpleCSMAStreamInstance.Subscribe(monitorStreamCallback);

			// Send a startup message to the controller
			Send(Addresses.BROADCAST, Common.MonitorStreamId, (byte)Common.AppNodeMessage.Starting, Encoding.UTF8.GetBytes("Now Starting"));

			// Set a random delay for replies, based on the node's CSMA address
			_randomizer = new Random(simpleCSMAStreamInstance.SimpleCSMAInstance.CSMAInstance.GetAddress());
			_sendDelay = _randomizer.Next(100);
		}

		/// <summary>
		/// Health Monitor callback
		/// </summary>
		/// <remarks>Handles stream message from controller</remarks>/// <param name="rcvMsg"></param>
		/// <param name="rcvMsgBytes"></param>
		public static void MonitorCallback(eMote.Net.Message rcvMsg, byte[] rcvMsgBytes)
		{
			Debug.Print("\nMonitor received " + (rcvMsg.Unicast ? "Unicast" : "Broadcast")
						+ ", message from src: " + rcvMsg.Src
						+ ", stream number: " + rcvMsgBytes[0]
						+ ", size: " + rcvMsg.Size
						+ ", rssi: " + rcvMsg.RSSI
						+ ", lqi: " + rcvMsg.LQI);

			if (rcvMsgBytes.Length == 0)
			{
				Debug.Print("*** Monitor: message of length " + rcvMsgBytes.Length + " received");
				return;
			}

			// Get the kind of message and respond accordingly
			var controllerMessageName = rcvMsgBytes[0];
			switch (controllerMessageName)
			{
				// Ping. Respond with Pong + other eMote info
				case (byte)Common.ControllerMessage.Ping:
					Debug.Print("Received " + Common.ControllerMessage.Ping);
					Thread.Sleep(_sendDelay);
					Send((Addresses)rcvMsg.Src, Common.MonitorStreamId, (byte)Common.AppNodeMessage.Pong, Encoding.UTF8.GetBytes(
						"Pong"
						+ ", CPU Power: " + PowerState.CurrentPowerLevel
						+ ", Radio Power: " + _simpleCSMAStreamInstance.SimpleCSMAInstance.TxPowerValue));
					break;

				// SendLCD. Respond with current LCD
				case (byte)Common.ControllerMessage.SendLCD:
					Debug.Print("Received " + Common.ControllerMessage.SendLCD);
					var currLcd = _lcd.CurrentChars;
					var currLcdChar = new char[currLcd.Length];
					for (var i = 0; i < currLcd.Length; i++)
					{
						currLcdChar[currLcd.Length - i - 1] = currLcd[i].ToChar();
					}
					Thread.Sleep(_sendDelay);
					Send((Addresses)rcvMsg.Src, Common.MonitorStreamId, (byte)Common.AppNodeMessage.CurrLCD, Encoding.UTF8.GetBytes("CurrLCD <" + new string(currLcdChar) + ">"));
					break;

				// Reset. Respond with "resetting" message and reset
				case (byte)Common.ControllerMessage.Reset:
					Thread.Sleep(_sendDelay);
					Send((Addresses)rcvMsg.Src, Common.MonitorStreamId, (byte)Common.AppNodeMessage.NowResetting, Encoding.UTF8.GetBytes("Now Resetting"));
					Thread.Sleep(1000);	// Sleep to let radio stabilize before resetting
					_resetPort.Write(false);
					break;

				// Unknown message
				default:
					Debug.Print("Unknown message received from controller: " + controllerMessageName);
					break;
			}
		}

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
			var messageEx = new byte[message.Length + 1];
			for (var i = 0; i < message.Length; i++)
			{
				messageEx[i + 1] = message[i];
			}
			messageEx[0] = messageName;

			// Send the message
			_simpleCSMAStreamInstance.Send(address, streamId, messageEx);
		}
	}
}
