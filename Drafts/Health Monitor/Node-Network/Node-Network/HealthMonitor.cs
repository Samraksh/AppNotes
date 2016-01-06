using System;
using System.Text;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.Net;
using Samraksh.eMote.Net.Mac;

namespace Samraksh.AppNote.HealthMonitor
{
	/// <summary>
	/// ###
	/// </summary>
	public static class HealthMonitor
	{
		private static byte[] _nodeMonitorSendBytes = new byte[100];
		private static EnhancedEmoteLCD _lcd;
		private static SimpleCSMAStream _simpleCSMAStream;
		private static OutputPort _resetPort;

		/// <summary>
		/// Health Monitor constructor
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
			_simpleCSMAStream.AddStreamCallback(monitorStreamCallback);
		}

		/// <summary>
		/// Health Monitor callback
		/// </summary>
		/// <param name="rcvMsg"></param>
		public static void MonitorCallback(Message rcvMsg)
		{
			var rcvPayloadBytes = rcvMsg.GetMessage();

			Debug.Print("\nMonitor received " + (rcvMsg.Unicast ? "Unicast" : "Broadcast")
						+ ", message from src: " + rcvMsg.Src
						+ ", stream number: " + rcvPayloadBytes[0]
						+ ", size: " + rcvMsg.Size
						+ ", rssi: " + rcvMsg.RSSI
						+ ", lqi: " + rcvMsg.LQI);


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
					_nodeMonitorSendBytes = Encoding.UTF8.GetBytes("**Pong        ");
					_nodeMonitorSendBytes[1] = (byte)Common.NodeMessage.Pong;
					_simpleCSMAStream.Send((Addresses)rcvMsg.Src, Common.MonitorStreamId, _nodeMonitorSendBytes);
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
					_nodeMonitorSendBytes = Encoding.UTF8.GetBytes("**CurrLCD <" + new string(currLcdChar) + ">");
					_nodeMonitorSendBytes[1] = (byte)Common.NodeMessage.CurrLCD;
					_simpleCSMAStream.Send((Addresses)rcvMsg.Src, Common.MonitorStreamId, _nodeMonitorSendBytes);
					break;
				case (byte)Common.ControllerMessage.Reset:
					_nodeMonitorSendBytes = Encoding.UTF8.GetBytes("**Now Resetting");
					_nodeMonitorSendBytes[1] = (byte)Common.NodeMessage.NowResetting;
					_simpleCSMAStream.Send((Addresses)rcvMsg.Src, Common.MonitorStreamId, _nodeMonitorSendBytes);
					_resetPort.Write(false);
					break;
				default:
					Debug.Print("Unknown message received from controller: " + controllerMessage);
					break;
			}
		}
	}
}
