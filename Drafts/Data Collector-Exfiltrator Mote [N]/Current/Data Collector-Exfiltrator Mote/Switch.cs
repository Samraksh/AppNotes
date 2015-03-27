using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;
using Globals;

namespace Samraksh.AppNote.DotNow.DataCollectorExfiltrator {
    public static class Switch {

        // Set up an input switch, using the InputSwitch class
        //  This specifies the pin to use, the resistor mode, and a callback method to process switch results
        private static InputSwitch onOffSwitch = new InputSwitch(Pins.GPIO_J12_PIN1, Port.ResistorMode.PullUp, SwitchCallback);

        /// <summary>
        /// Process input switch data
        /// </summary>
        /// <remarks>
        /// This is called whenever the switch value changes
        /// </remarks>
        /// <param name="switchValue">The value of the switch</param>
        private static void SwitchCallback(bool switchValue) {
            SerialLcd.SensedValue((switchValue) ? '0' : '1');    // Display the switch value
            // Send the switch value only if the PC has told us to do so
            if (GlobalValues._sendSensedData) {
                GlobalValues._serialComm.Write((switchValue) ? "Off\n" : "On\n");
            }
        }

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
                GlobalValues.Lcd.Write(_lcd1.ToLcd(), _lcd2.ToLcd(), _lcd3.ToLcd(), _lcd4.ToLcd());
            }
        }
    }
}
