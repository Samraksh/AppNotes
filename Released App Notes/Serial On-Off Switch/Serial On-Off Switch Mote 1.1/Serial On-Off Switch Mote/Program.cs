/*--------------------------------------------------------------------
 * Serial On-Off Switch for mote: app note for the eMote .NOW 1.0
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *  1.0: initial release
---------------------------------------------------------------------*/

using System;
using System.IO.Ports;
using System.Threading;

using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.SPOT.Hardware.EmoteDotNow;

using Samraksh.AppNote.Utility;

namespace OnOffSwitchExfiltrator {

    /// <summary>
    /// This eMote.NOW server program interacts with PC client via the serial port.
    /// Communication is bi-directional:
    ///      The mote server sends messages about switch state to the PC client, which are displayed in a text box.
    ///      The user can make the PC client turn the message transmission on or off.
    ///      
    /// To keep the main program simple, classes have been included to abstract switch handling and serial communication
    /// </summary>
    public class Program {

        static EmoteLCD lcd = new EmoteLCD();   // Define the LCD
        static SerialComm serialComm;           // Define serial comm
        static bool sendSwitchVal = true;       // True iff switch data should be sent to PC client
        const string commPort = "COM1";         // The comm port to use. Due to limitations in drivers, must be COM1, COM2 or COM3.

        /// <summary>
        /// Initialize things and start the threads to handle switch and serial I/O
        /// </summary>
        public static void Main() {
            lcd.Initialize();
            // Flash a hello message for a second, to  let us know the program is starting
            lcd.Write('H'.ToLCD(), 'o'.ToLCD(), 'l'.ToLCD(), 'a'.ToLCD());
            Thread.Sleep(1000);
            lcd.Write(' '.ToLCD(), ' '.ToLCD(), ' '.ToLCD(), ' '.ToLCD());

            // Set up an input switch, using the InputSwitch class
            //  This specifies the pin to use, the resistor mode, and a callback method to process switch results
            InputSwitch onOffSwitch = new InputSwitch(Pins.GPIO_J12_PIN1, Port.ResistorMode.PullUp, SwitchCallback);

            // Set up serial comm. 
            //  This specifies the comm port to use and a callback method to process data received from the PC
            try {
                serialComm = new SerialComm(commPort, ExfiltrationSerialCallback);
                serialComm.Open();
            }
            // If can't open the port, display error on LCD
            catch {
                lcd.Write('E'.ToLCD(), 'r'.ToLCD(), 'r'.ToLCD(), ' '.ToLCD());
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
            ExfilLCD.SwitchValue((switchValue) ? '0' : '1');    // Display the switch value
            // Send the switch value only if the PC has told us to do so
            if (sendSwitchVal) {
                serialComm.Write((switchValue) ? "Off\n" : "On\n");
            }
        }

        /// <summary>
        /// Process input serial data
        /// </summary>
        /// <param name="readBytes">Data received</param>
        private static void ExfiltrationSerialCallback(byte[] readBytes) {
            char[] readChars = System.Text.Encoding.UTF8.GetChars(readBytes);   // Decode the input bytes as char using UTF8
            // If 1, note that PC wants to get switch data
            if (readChars[0] == '1') {
                sendSwitchVal = true;
                ExfilLCD.InputValue('a');
                serialComm.Write("-- Switch enabled\n");  // Let the PC know we got it
                return;
            }
            // If 0, note that PC does not want to get switch data
            if (readChars[0] == '0') {
                sendSwitchVal = false;
                ExfilLCD.InputValue('b');
                serialComm.Write("-- Switch disabled\n"); // Let the PC know we got it
                return;
            }
            // If neither one, use LCD to display data received, one char at a time
            string readStr = readChars.ToString();
            for (int i = 0; i < readStr.Length; i++) {
                ExfilLCD.InputValue(readStr[i]);
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Used when switch or serial data received to display a char in a designated cell
        /// </summary>
        static class ExfilLCD {
            private static char lcd1 = ' ';
            private static char lcd2 = ' ';
            private static char lcd3 = ' ';
            private static char lcd4 = ' ';

            /// <summary>
            /// Display switch value
            /// </summary>
            /// <param name="swVal"></param>
            public static void SwitchValue(char swVal) {
                lcd1 = swVal;
                WriteLcd();
            }

            /// <summary>
            /// Display send status
            /// </summary>
            /// <param name="inVal"></param>
            public static void InputValue(char inVal) {
                lcd3 = inVal;
                WriteLcd();
            }

            // Write to LCD
            private static void WriteLcd() {
                lcd.Write(lcd1.ToLCD(), lcd2.ToLCD(), lcd3.ToLCD(), lcd4.ToLCD());
            }
        }

    }
}
