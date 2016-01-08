using System.Text;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.HealthMonitor;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.Net;
using Samraksh.eMote.Net.Mac;

namespace Samraksh.AppNote.CSMAPingPongWithHealthMonitor
{
	/// <summary>
	/// ###
	/// </summary>
	public static class HealthMonitor
	{
		private static EnhancedEmoteLCD _lcd;
		private static SimpleCSMAStream _simpleCSMAStream;
		private static OutputPort _resetPort;

		/// <summary>
		/// Health Monitor initialization
		/// </summary>
		/// <param name="simpleCSMAStream"></param>
		/// <param name="lcd"></param>
		/// <param name="resetPort"></param>
		public static void Initialize(SimpleCSMAStream simpleCSMAStream, EnhancedEmoteLCD lcd, OutputPort resetPort)
		{
			_simpleCSMAStream = simpleCSMAStream;
			_lcd = lcd;
			_resetPort = resetPort;

			var monitorStreamCallback = new StreamCallback(Common.MonitorStreamId, MonitorCallback);
			_simpleCSMAStream.Subscribe(monitorStreamCallback);
			Send(Addresses.BROADCAST, Common.MonitorStreamId, (byte)Common.NodeMessage.Starting, Encoding.UTF8.GetBytes("Now Starting"));
		}

		/// <summary>
		/// Health Monitor callback
		/// </summary>
		/// <param name="rcvMsg"></param>
		/// <param name="rcvMsgBytes"></param>
		public static void MonitorCallback(Message rcvMsg, byte[] rcvMsgBytes)
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
					Send((Addresses)rcvMsg.Src, Common.MonitorStreamId, (byte)Common.NodeMessage.Pong, Encoding.UTF8.GetBytes("Pong"));
					break;
				case (byte)Common.ControllerMessage.SendLCD:
					Debug.Print("Received " + Common.ControllerMessage.SendLCD);
					var currLcd = _lcd.CurrentChars;
					var currLcdChar = new char[currLcd.Length];
					for (var i = 0; i < currLcd.Length; i++)
					{
						currLcdChar[currLcd.Length - i - 1] = currLcd[i].ToChar();
					}
					//var currLcdString = Encoding.UTF8.GetBytes(new string(currLcdChar));
					Send((Addresses)rcvMsg.Src, Common.MonitorStreamId, (byte)Common.NodeMessage.CurrLCD, Encoding.UTF8.GetBytes("CurrLCD <" + new string(currLcdChar) + ">"));
					break;
				case (byte)Common.ControllerMessage.Reset:
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
			Common.PrintByteVals("1 ",message);

			// Shift the message right and insert message name
			var messageEx = new byte[message.Length + 1];
			for (var i = 0; i < message.Length; i++)
			{
				messageEx[i + 1] = message[i];
			}
			messageEx[0] = messageName;

			Common.PrintByteVals("2 ", message);

			_simpleCSMAStream.Send(address, streamId, messageEx);
		}
	}
}
