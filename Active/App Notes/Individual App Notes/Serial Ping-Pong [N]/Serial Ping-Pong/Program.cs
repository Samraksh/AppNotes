/*--------------------------------------------------------------------
 * Serial Radio Ping-Pong: app note for the eMote .NOW
 * (c) 2013-2015 The Samraksh Company
 * 
 * Version history
 *	1.0:
 *		- Initial release
 ---------------------------------------------------------------------*/

/************************************************************************
 *					IMPORTANT
 *	eMote has two serial COM ports: COM1 and COM2. 
 *		COM1 is for system and debugging (MFDeploy and VS Debugging)
 *			It can also be used for user data.
 *		COM2 is for user data only.
 *	If an eMote .NOW is connected to MFDeploy or to VS Debugging then COM2 will be redirected to COM1.
 *	For this app note, this is undesirable. The app note listens to COM2, so if MFDeploy or VS Debugging is connected then nothing will be sent on COM2.
 *	To see the system and debugging messages (including Debug.Print) from COM1, you can use a terminal emulator such as PuTTY. For PuTTY, configure as follows:
 *		Connection type: Serial
 *		Serial line: COMx, where x is the (standard) COM port for an eMote .NOW. Example: COM22
 *		Speed: 115200
 *		Data bits: 8
 *		Stop bits: 1
 *		Parity: None
 *		Flow-control: XON/XOFF
 *	
 ***********************************************************************/

using System;
using System.Reflection;
using System.Text;
using System.Threading;
using Microsoft.SPOT;

using Samraksh.AppNote.Utility;

namespace Samraksh.AppNote.DotNow.SerialPingPong
{
	/// <summary>
	/// Set up two motes to send and receive messages between each other.
	/// The goal is to converge on a shared value.
	/// Each mote randomly chooses an initial current value and sends it to the other.
	/// When a mote receives a message, it sets its current value to the maximum of the two and then increments it by 1, and displays it on the LCD.
	/// After a delay, the mote sends the new value. The delay is to keep the LCD display from changing too fast.
	/// 
	/// If a mote does not hear from the other, then after a (longer) delay, it resends its current value.
	/// It does this repeatedly, at the longer interval.
	/// </summary>
	public static class Program
	{
		// The current value
		private static int _currVal;

		// LCD and Radio objects
		private static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();
		//static SimpleCsmaRadio _csmaRadio;

		// Reply timer. Slows down interaction by not sending reply messages until the timer expires
		private const int SendInterval = 4000; // Time to wait before sending reply
		private static readonly SimpleOneshotTimer ReplyTimer = new SimpleOneshotTimer(Reply_Timeout, null, SendInterval);

		// No response timer. If no message received, send current value again
		//  Timer is reset whenever a message is received
		private const int NoResponseInterval = SendInterval * 4; // Time to wait before re-sending; must be larger than send interval
		private static readonly SimpleOneshotTimer NoResponseDelayTimer = new SimpleOneshotTimer(NoResponseDelay_Timeout, null, NoResponseInterval);

		// Serial ping-pong communication methods
		private static readonly SerialPingPongMethods Comm = new SerialPingPongMethods(ReceiveCallback, 100, 0x01);

		/// <summary>
		/// Main program. Set things up and then go to sleep forever.
		/// </summary>
		public static void Main()
		{
			Debug.EnableGCMessages(false);  // We don't want to see garbage collector messages in the debug stream

			Debug.Print(VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));

			// Display a welcome message
			Lcd.Write("Hola");
			Thread.Sleep(4000);

			// Pick a value randomly
			_currVal = new Random().Next(99);  // We're choosing a fairly small value to avoid runover on the LCD display (since it only has 4 positions)
			Lcd.Write(_currVal);

			// Send the current value now
			Debug.Print("Sending initial value");
			Comm.Send(_currVal.ToString().Trim());

			// Start a one-shot timer
			NoResponseDelayTimer.Start();

			// Everything is set up. Go to sleep forever
			//	All other activity is triggered by events such as timer tick or packet received.
			Thread.Sleep(Timeout.Infinite);
		}

		/// <summary>
		/// Handle a received packet
		/// </summary>
		/// <param name="packet"></param>
		/// <param name="packetLength"></param>
		private static void ReceiveCallback(byte[] packet, int packetLength)
		{
			// Reset the no-response timer
			NoResponseDelayTimer.Stop();

			//	You can enable this and other debugging messages if you'd like
			//PrintByteVals(packet, packetLength);

			// Make sure the packet value is in the correct format (int)

			var msgChars = Encoding.UTF8.GetChars(packet, 0, packetLength);
			var msgStr = new string(msgChars);
			int recVal;
			try
			{
				recVal = int.Parse(msgStr);
			}
			catch
			{
				Debug.Print("Invalid value received");
				return;
			}

			// Update the current value
			//var origVal = _currVal;
			_currVal = System.Math.Max(_currVal, recVal);
			_currVal++;
			Lcd.Write(_currVal);
			//Debug.Print("Orig val " + origVal + ", rec val " + recVal + ", new val " + _currVal);

			// Wait a bit before sending reply
			ReplyTimer.Start();
		}

		/// <summary>
		/// Print the numeric values of the bytes in a packet.
		/// Useful for debugging.
		/// </summary>
		/// <param name="packet"></param>
		/// <param name="packetLength"></param>
		private static void PrintByteVals(byte[] packet, int packetLength)
		{
			var thePacketVals = new StringBuilder();
			for (var i = 0; i < packetLength; i++)
			{
				thePacketVals.Append(packet[i].ToString());
				thePacketVals.Append(' ');
			}
			thePacketVals.Append('\n');
			Debug.Print(thePacketVals.ToString());
		}

		/// <summary>
		/// Send the current value when the reply timer expires
		/// </summary>
		/// <param name="obj">Ignored</param>
		private static void Reply_Timeout(object obj)
		{
			//Debug.Print("Sending response message " + _currVal);
			Comm.Send(_currVal.ToString().Trim());
		}

		/// <summary>
		/// Resend the current value when the no-response timer expires
		/// </summary>
		/// <param name="obj">Ignored</param>
		private static void NoResponseDelay_Timeout(object obj)
		{
			Debug.Print("No message received ... sending again");
			Comm.Send(_currVal.ToString().Trim());
			// Give a short pause to show that we've received no response
			Lcd.Write("aaaa");
			Thread.Sleep(500);
			Lcd.Write(_currVal);
			// Restart the no-response timer
			NoResponseDelayTimer.Start();
		}


	}
}

