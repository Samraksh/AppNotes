using System;
using System.Threading;

using Microsoft.SPOT;

namespace Samraksh.AppNote.Utility {
    /// <summary>
    /// Debounce a switch
    /// </summary>
    class DebounceTimer {

        // Define a switch to decide if interrupts should be ignore or not
        private int interruptIgnore = FALSE;
        private const int TRUE = 1; 
        private const int FALSE = 0;

        // Define a timer that blocks interrupts until it expires
        int debounceInterval;
        private Timer debounceTimer;
        private void timerCallback(object obj) {
            interruptIgnore = FALSE;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_debounceInterval">Interval to debounce</param>
        public DebounceTimer(int _debounceInterval) {
            debounceInterval = _debounceInterval;
        }

        /// <summary>
        /// Checks whether OK to process switch value or not
        /// </summary>
        /// <returns>True iff ok to process switch value</returns>
        public bool OkToProcess() {
            // Check if it's ok to process the switch value or not
            //  When we get the first interrupt, start the debounce timer; reject subsequent interrupts until the timer expires
            //  Uses an atomic test-and-set to avoid the race conditon where a new interrupt arrives after the test but before the set
            if (Interlocked.CompareExchange(ref interruptIgnore, TRUE, FALSE) == TRUE) {
                return false;   // Timer is already running; not ok to process
            }
            // Start (or restart) the timer
            if (debounceTimer == null) {
                debounceTimer = new Timer(new TimerCallback(timerCallback), interruptIgnore, debounceInterval, 0);
            }
            else {
                debounceTimer.Change(debounceInterval, 0);
            }
            return true;    // Just started the timer; ok to process
        }

    }
}
