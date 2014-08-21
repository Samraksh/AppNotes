/*=========================
 * Debounce Timer Class
 *  Define a timer for debouncing a switch
 * Versions
 *  1.0 Initial Version
 *  1.1 Minor edits
=========================*/

using System.Threading;

namespace Samraksh.AppNote.Utility {
    /// <summary>
    /// Debounce a switch
    /// </summary>
    class DebounceTimer {

        // Define a variable to if interrupts (caused by switch bounce) should be ignored or not
        private int _interruptIgnore = False;
        private const int True = 1; 
        private const int False = 0;

        // Define a timer that blocks interrupts until it expires
        readonly int _debounceInterval;
        private Timer _debounceTimer;
        private void TimerCallback(object obj) {
            _interruptIgnore = False;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="debounceInterval">Interval to debounce</param>
        public DebounceTimer(int debounceInterval) {
            _debounceInterval = debounceInterval;
        }

        /// <summary>
        /// Checks whether OK to process switch value or not
        /// </summary>
        /// <returns>True iff ok to process switch value</returns>
        public bool OkToProcess() {
            // Check if it's ok to process the switch value or not
            //  When we get the first interrupt, start the debounce timer; reject subsequent interrupts until the timer expires
            //  Uses an atomic test-and-set to avoid the race conditon where a new interrupt arrives after the test but before the set
            if (Interlocked.CompareExchange(ref _interruptIgnore, True, False) == True) {
                return false;   // Timer is already running; not ok to process
            }
            // Start (or restart) the timer
            if (_debounceTimer == null) {
                _debounceTimer = new Timer(TimerCallback, _interruptIgnore, _debounceInterval, 0);
            }
            else {
                _debounceTimer.Change(_debounceInterval, 0);
            }
            return true;    // Just started the timer; ok to process
        }

    }
}
