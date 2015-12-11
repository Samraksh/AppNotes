/*=========================
 * Debounced Switch Class
 *  Debounce a GPIO input
 * Versions
 *  1.0
 *      Initial release
==========================*/

using System;
using System.Threading;
using Microsoft.SPOT.Hardware;

namespace Samraksh.AppNote.Utility
{
    /// <summary>
    /// Debounce an on-off switch attached to one of the eMote .NOW GPIO ports
    /// </summary>
    /// <remarks>
    /// An event-driven GPIO input debouncer. Debouncing takes two forms:
    /// 
    /// 1. Debounce momentary contact
    /// 
    ///     When the GPIO interrupt occurs, check whether there's been a change in input. If so, set (or reset) a timer for DebounceInterval ms.
    ///     The timer will not fire unless there's been no change in input for DebounceInterval.
    /// 
    /// 2. Debounce duplicates
    /// 
    ///     When the timer fires, check to see if the current value is a duplicate of the last one. If so, skip. Else, call user callback.
    ///     This ensures that the sequence to the user is alternating pressed - not pressed.
    /// 
    /// </remarks>
    public class DebouncedSwitch
    {
        /// <summary>The signature of the user-supplied callback method</summary>
        /// <param name="switchStatus"></param>
        public delegate void DebouncedSwitchCallback(bool switchStatus);

        private readonly DebouncedSwitchCallback _userCallBack;

        private const int DebounceInterval = 100;
        private Timer _debounceTimer;
        private uint _stableVal;
        private uint _lastStableVal;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="portId">GPIO input to use</param>
        /// <param name="resistorMode">Pull up or pull down or neither</param>
        /// <param name="userCallBack">User callback for input changes</param>
        public DebouncedSwitch(Cpu.Pin portId, Port.ResistorMode resistorMode, DebouncedSwitchCallback userCallBack)
        {
            _userCallBack = userCallBack;
            InputPort switchPort = new InterruptPort(portId, false, resistorMode, Port.InterruptMode.InterruptEdgeBoth);
            switchPort.OnInterrupt += InputSwitch_OnInterrupt;
        }

        /// <summary>
        /// GPIO interrupt callback
        /// </summary>
        /// <remarks>
        /// Set or reset the debounce timer if there's a change in input
        /// </remarks>
        /// <param name="pin">The GPIO pin</param>
        /// <param name="state">0 if low, 1 if high</param>
        /// <param name="time">When the interrupt occurred</param>
        private void InputSwitch_OnInterrupt(uint pin, uint state, DateTime time)
        {
            // If the state is unchanged, all is good so far. Just return.
            if (state == _stableVal) { return; }
            // Otherwise start (or restart) the debounce timer.
            _stableVal = state;
            if (_debounceTimer == null)
            {
                _debounceTimer = new Timer(DebounceTimer_OnTimeout, null, DebounceInterval, -1);
            }
            else
            {
                _debounceTimer.Change(DebounceInterval, 0);
            }
        }

        /// <summary>
        /// Debounce timer callback
        /// </summary>
        /// <remarks>
        /// Call user callback unless no change in value sent.
        /// </remarks>
        /// <param name="obj"></param>
        private void DebounceTimer_OnTimeout(object obj)
        {
            // If the stable value is the same as last time, ignore
            if (_stableVal == _lastStableVal) { return; }
            // Otherwise, return the value to the user
            _lastStableVal = _stableVal;
            _userCallBack(_stableVal != 0);
        }
    }
}
