using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;
using Globals;

namespace Samraksh.AppNote.DotNow.DataCollectorExfiltrator {
    public static class Sensor {

        // Set up an input switch, using the InputSwitch class
        //  This specifies the pin to use, the resistor mode, and a callback method to process switch results
        private static InputSwitch _onOffSwitch;

        public static void Initialize() {
            _onOffSwitch = new InputSwitch(Pins.GPIO_J12_PIN1, Port.ResistorMode.PullUp, SwitchCallback);
        }

        /// <summary>
        /// Process input switch data
        /// </summary>
        /// <remarks>
        /// This is called whenever the switch value changes
        /// </remarks>
        /// <param name="switchValue">The value of the switch</param>
        private static void SwitchCallback(bool switchValue) {
            Global.SerialLcd.SensedValue((switchValue) ? '0' : '1');    // Display the switch value
            // Send the switch value only if the PC has told us to do so
            if (Global._sendSensedData) {
                Global._serialComm.Write((switchValue) ? "Off\n" : "On\n");
            }
        }

    }
}
