#if Switch

using System.Threading;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;
using Samraksh.AppNote.DotNow.DataCollectorExfiltrator.Globals;

namespace Samraksh.AppNote.DotNow.DataCollectorExfiltrator.Sensors {
    /// <summary>
    /// On-Off Switch Sensor
    /// </summary>
    public static class Sensor {

        // Set up an input switch, using the InputSwitch class
        //  This specifies the pin to use, the resistor mode, and a callback method to process switch results
        private static InputSwitch _onOffSwitch;

        private static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd(); // Define the LCD

        /// <summary>
        /// Name of the sensor
        /// </summary>
        public const string SensorName = "On-Off Switch";

        /// <summary>
        /// Initialize the sensor
        /// </summary>
        public static void Initialize() {

            Lcd.Initialize();
            // Flash a hello message for a second, to  let us know the program is starting
            Lcd.Display("Hola");
            Thread.Sleep(1000);
            Lcd.Display("");

            _onOffSwitch = new InputSwitch(Pins.GPIO_J12_PIN1, Port.ResistorMode.PullUp, SwitchCallback);
        }

        /// <summary>
        /// Handle an error message
        /// </summary>
        public static void ErrorMsg(string error) {
            Lcd.Display(error);
        }

        /// <summary>
        /// Process input switch data
        /// </summary>
        /// <remarks>
        /// This is called whenever the switch value changes
        /// </remarks>
        /// <param name="switchValue">The value of the switch</param>
        private static void SwitchCallback(bool switchValue) {
            SerialLcd.SensedValue((switchValue) ? '0' : '1'); // Display the switch value
            // Send the switch value only if the PC has told us to do so
            if (Global.SendSensedData) {
                Global.Serial.Write((switchValue) ? "Off\n" : "On\n");
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
                Lcd.Write(_lcd1.ToLcd(), _lcd2.ToLcd(), _lcd3.ToLcd(), _lcd4.ToLcd());
            }


        }
    }
}

#endif