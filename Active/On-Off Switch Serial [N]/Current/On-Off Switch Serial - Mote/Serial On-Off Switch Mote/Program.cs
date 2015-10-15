/*--------------------------------------------------------------------
 * Serial On-Off Switch for mote: app note for the eMote .NOW 1.0
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *  1.0:	- initial release
 *  1.1:	- Updated to eMote v. 12 namespaces
 *			- Refactor to include project Utility
---------------------------------------------------------------------*/

using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;

namespace Samraksh.Appnote.DotNow.OnOffSwitchSerialLink {

	/// <summary>
	/// This eMote.NOW server program interacts with PC client via the serial port.
	/// Communication is bi-directional:
	///      The mote server sends messages about switch state to the PC client, which are displayed in a text box.
	///      The user can make the PC client turn the message transmission on or off.
	///      
	/// To keep the main program simple, classes have been included to abstract switch handling and serial communication
	/// </summary>
	public class Program {

		static SerialComm _serialComm;		// Define serial comm
		static bool _sendSwitchVal = true;	// True iff switch data should be sent to PC client
		const string CommPort = "COM1";		// The comm port to use. Due to limitations in drivers, must be COM1, COM2 or COM3.
		static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();

		/// <summary>
		/// Initialize things and start the threads to handle switch and serial I/O
		/// </summary>
		public static void Main() {

			Debug.Print(VersionInfo.VersionBuild());

			// Flash a hello message for a second, to  let us know the program is starting
			Lcd.Write("Hola");
			Thread.Sleep(1000);
			Lcd.Clear();

			// Set up an input switch, using the InputSwitch class
			//  This specifies the pin to use, the resistor mode, and a callback method to process switch results
			// ReSharper disable once UnusedVariable
			var onOffSwitch = new InputSwitch(Pins.GPIO_J12_PIN1, Port.ResistorMode.PullUp, SwitchCallback);

			// Set up serial comm. 
			//  This specifies the comm port to use and a callback method to process data received from the PC
			try {
				_serialComm = new SerialComm(CommPort, SerialCallback);
				_serialComm.Open();
			}
			// If can't open the port, display error on LCD
			catch {
				Lcd.Write("Err");
			}

			// Sleep forever
			//  All the real work is handled by the input switch and serial comm threads, which are event driven.
			Thread.Sleep(Timeout.Infinite);
		}

		/// <summary>
		/// Process input switch data
		/// </summary>
		/// <remarks>
		/// This is called whenever the switch value changes
		/// </remarks>
		/// <param name="switchValue">The value of the switch</param>
		private static void SwitchCallback(bool switchValue) {
			SerialLCD.SwitchValue((switchValue) ? '0' : '1');    // Display the switch value
			// Send the switch value only if the PC has told us to do so
			if (_sendSwitchVal) {
				_serialComm.Write((switchValue) ? "Off\n" : "On\n");
			}
		}

		/// <summary>
		/// Process input serial data
		/// </summary>
		/// <param name="readBytes">Data received</param>
		private static void SerialCallback(byte[] readBytes) {
			var readChars = System.Text.Encoding.UTF8.GetChars(readBytes);   // Decode the input bytes as char using UTF8
			// If 1, note that PC wants to get switch data
			if (readChars[0] == '1') {
				_sendSwitchVal = true;
				SerialLCD.InputValue('e');
				_serialComm.Write("-- Switch enabled\n");  // Let the PC know we got it
				return;
			}
			// If 0, note that PC does not want to get switch data
			if (readChars[0] == '0') {
				_sendSwitchVal = false;
				SerialLCD.InputValue('d');
				_serialComm.Write("-- Switch disabled\n"); // Let the PC know we got it
				return;
			}
			// If neither one, use LCD to display data received, one char at a time
			var readStr = readChars.ToString();
			for (var i = 0; i < readStr.Length; i++) {
				SerialLCD.InputValue(readStr[i]);
				Thread.Sleep(1000);
			}
		}

		/// <summary>
		/// Used when switch or serial data received to display a char in a designated cell
		/// </summary>
		static class SerialLCD {
			private static char _lcd1 = ' ';
			private const char Lcd2 = ' ';
			private static char _lcd3 = ' ';
			private const char Lcd4 = ' ';

			/// <summary>
			/// Display switch value
			/// </summary>
			/// <param name="swVal"></param>
			public static void SwitchValue(char swVal) {
				_lcd1 = swVal;
				WriteLcd();
			}

			/// <summary>
			/// Display send status
			/// </summary>
			/// <param name="inVal"></param>
			public static void InputValue(char inVal) {
				_lcd3 = inVal;
				WriteLcd();
			}

			// Write to LCD
			private static void WriteLcd() {
				Lcd.Write(_lcd1.ToLcd(), Lcd2.ToLcd(), _lcd3.ToLcd(), Lcd4.ToLcd());
			}
		}

	}
}
