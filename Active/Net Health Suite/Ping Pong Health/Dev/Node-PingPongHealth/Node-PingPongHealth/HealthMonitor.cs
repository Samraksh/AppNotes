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
	/// ###
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
			_simpleCSMAStreamInstance = simpleCSMAStreamInstance;
			_lcd = lcd;
			_resetPort = resetPort;

			var monitorStreamCallback = new StreamCallback(Common.MonitorStreamId, MonitorCallback);
			_simpleCSMAStreamInstance.Subscribe(monitorStreamCallback);
			Send(Addresses.BROADCAST, Common.MonitorStreamId, (byte)Common.NodeMessage.Starting, Encoding.UTF8.GetBytes("Now Starting"));

			// Set a random delay for replies, based on the node's CSMA address
			_randomizer = new Random(simpleCSMAStreamInstance.SimpleCSMAInstance.CSMAInstance.GetAddress());
			_sendDelay = _randomizer.Next(100);
		}

		/// <summary>
		/// Health Monitor callback
		/// </summary>
		/// <param name="rcvMsg"></param>
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
			var controllerMessage = rcvMsgBytes[0];
			switch (controllerMessage)
			{
				case (byte)Common.ControllerMessage.Ping:
					Debug.Print("Received " + Common.ControllerMessage.Ping);
					Thread.Sleep(_sendDelay);
					Send((Addresses)rcvMsg.Src, Common.MonitorStreamId, (byte)Common.NodeMessage.Pong, Encoding.UTF8.GetBytes(
						"Pong"
						+ ", CPU Power: " + PowerState.CurrentPowerLevel
						+ ", Radio Power: " + _simpleCSMAStreamInstance.SimpleCSMAInstance.TxPowerValue));
					break;
				case (byte)Common.ControllerMessage.SendLCD:
					Debug.Print("Received " + Common.ControllerMessage.SendLCD);
					var currLcd = _lcd.CurrentChars;
					var currLcdChar = new char[currLcd.Length];
					for (var i = 0; i < currLcd.Length; i++)
					{
						currLcdChar[currLcd.Length - i - 1] = currLcd[i].ToChar();
					}
					Thread.Sleep(_sendDelay);
					Send((Addresses)rcvMsg.Src, Common.MonitorStreamId, (byte)Common.NodeMessage.CurrLCD, Encoding.UTF8.GetBytes("CurrLCD <" + new string(currLcdChar) + ">"));
					break;
				case (byte)Common.ControllerMessage.Reset:
					Thread.Sleep(_sendDelay);
					Send((Addresses)rcvMsg.Src, Common.MonitorStreamId, (byte)Common.NodeMessage.NowResetting, Encoding.UTF8.GetBytes("Now Resetting"));
					Thread.Sleep(1000);
					_resetPort.Write(false);
					break;
				default:
					Debug.Print("Unknown message received from controller: " + controllerMessage);
					break;
			}
		}

		private static void Send(Addresses address, byte streamId, byte messageName, byte[] message)
		{
			Common.PrintByteVals("1 ", message);

			// Shift the message right and insert message name
			var messageEx = new byte[message.Length + 1];
			for (var i = 0; i < message.Length; i++)
			{
				messageEx[i + 1] = message[i];
			}
			messageEx[0] = messageName;

			Common.PrintByteVals("2 ", message);

			_simpleCSMAStreamInstance.Send(address, streamId, messageEx);
		}
	}
}
