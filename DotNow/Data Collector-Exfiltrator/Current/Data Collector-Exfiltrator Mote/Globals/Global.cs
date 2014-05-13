using System;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;

namespace Globals {
    public class Global {
        public static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();   // Define the LCD
        public static bool _sendSensedData = true;       // True iff sensed data should be sent to PC client
        public static SerialComm _serialComm;           // Define serial comm

        /// <summary>
        /// Used when switch or serial data received to display a char in a designated cell
        /// </summary>
        public static class SerialLcd {
            private static char _lcd1 = ' ';
            private static char _lcd2 = ' ';
            private static char _lcd3 = ' ';
            private static char _lcd4 = ' ';

            /// <summary>
            /// Display switch value
            /// </summary>
            /// <param name="swVal"></param>
            public static void SensedValue(char swVal) {
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
                Global.Lcd.Write(_lcd1.ToLcd(), _lcd2.ToLcd(), _lcd3.ToLcd(), _lcd4.ToLcd());
            }
        }


    }
}
