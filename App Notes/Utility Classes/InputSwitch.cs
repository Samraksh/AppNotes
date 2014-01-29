/*=========================
 * Input Switch Class
 *  Define a mechanical on-off switch with debouncing
 *  Requires the class DebounceTimer
 * Versions
 *  1.0 Initial Version
=========================*/

using System;
using System.Threading;

using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using Samraksh.SPOT.Hardware.EmoteDotNow;

namespace Samraksh.AppNote.Utility {

    /// <summary>
    /// Handle an on-off switch attached to one of the eMote .NOW I/O ports
    /// </summary>
    /// <remarks>Requires DebounceTimer class</remarks>
    public class InputSwitch {

        public delegate void SwitchCallback(bool switchStatus); // The signature of the user-supplied callback method
        private SwitchCallback switchCallBack;  // The user callback method

        private InputPort switchPort;   // The port to use for the switch
        private DebounceTimer debounceTimer = new DebounceTimer(10);    // A debounce timer, set to 10 ms

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="portId">The port to which the switch is attached</param>
        /// <param name="resistorMode">Whether resistor is pull-up or pull-down (or no pullup at all)</param>
        /// <param name="_switchCallBack">A method to call when the switch value changes</param>
        public InputSwitch(Cpu.Pin portId, Port.ResistorMode resistorMode, SwitchCallback _switchCallBack ) {
            switchCallBack = _switchCallBack;

            switchPort = new InterruptPort(portId, false, resistorMode, Port.InterruptMode.InterruptEdgeBoth);
            switchPort.OnInterrupt += onOffSwitch_OnInterrupt;
        }

        /// <summary>
        /// Process a switch interrupt
        /// </summary>
        /// <param name="pin">The pin on which the interrupt occurred</param>
        /// <param name="state">The state of the pin</param>
        /// <param name="time">The (local) time the interrupt occurred</param>
        private void onOffSwitch_OnInterrupt(uint pin, uint state, DateTime time) {
            // If an interrupt arrives too soon after the last one, ignore it via the debounce timer
            if (!debounceTimer.OkToProcess()) {
                return;
            }
            // Read the port value and call the user-provided callback method
            bool buttonValue = switchPort.Read();
            switchCallBack(buttonValue);
        }

    }
}
