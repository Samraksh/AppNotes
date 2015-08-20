using System;
using Microsoft.SPOT.Hardware;

namespace Samraksh.AppNote.Utility {

    /// <summary>
    /// Handle an on-off switch attached to one of the eMote .NOW I/O ports
    /// </summary>
    public class InputSwitch {

        public delegate void SwitchCallback(bool switchStatus); // The signature of the user-supplied callback method
        private readonly SwitchCallback _switchCallBack;  // The user callback method

        private readonly InputPort _switchPort;   // The port to use for the switch
        private readonly DebounceTimer _debounceTimer = new DebounceTimer(10);    // A debounce timer, set to 10 ms

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="portId">The port to which the switch is attached</param>
        /// <param name="resistorMode">Whether resistor is pull-up or pull-down (or no pullup at all)</param>
        /// <param name="switchCallBack">A method to call when the switch value changes</param>
        public InputSwitch(Cpu.Pin portId, Port.ResistorMode resistorMode, SwitchCallback switchCallBack ) {
            _switchCallBack = switchCallBack;

            _switchPort = new InterruptPort(portId, false, resistorMode, Port.InterruptMode.InterruptEdgeBoth);
            _switchPort.OnInterrupt += onOffSwitch_OnInterrupt;
        }

        /// <summary>
        /// Process a switch interrupt
        /// </summary>
        /// <param name="pin">The pin on which the interrupt occurred</param>
        /// <param name="state">The state of the pin</param>
        /// <param name="time">The (local) time the interrupt occurred</param>
        private void onOffSwitch_OnInterrupt(uint pin, uint state, DateTime time) {
            // If an interrupt arrives too soon after the last one, ignore it via the debounce timer
            if (!_debounceTimer.OkToProcess()) {
                return;
            }
            // Read the port value and call the user-provided callback method
            var buttonValue = _switchPort.Read();
            _switchCallBack(buttonValue);
        }

    }
}
