using System.Text;
using Microsoft.SPOT;
using Samraksh.AppNote.HealthMonitor;
using Samraksh.eMote.Net;
using Samraksh.eMote.Net.Mac;

namespace Samraksh.AppNote.Utility
{
	/// <summary>
	/// ###
	/// </summary>
	public class HealthMonitor
	{
		private  byte[] _nodeMonitorSendBytes = new byte[100];
		private readonly EnhancedEmoteLCD _lcd;
		private readonly SimpleCSMAStream _simpleCSMAStream;

		public HealthMonitor(SimpleCSMAStream simpleCSMAStream, EnhancedEmoteLCD lcd, out )
		{
			_simpleCSMAStream = simpleCSMAStream;
			_lcd = lcd;
		}

		public void MonitorCallback(Message rcvMsg)
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
					ResetEnable.Write(false);
					break;
				default:
					Debug.Print("Unknown message received from controller: " + controllerMessage);
					break;
			}
		}
	}
}
