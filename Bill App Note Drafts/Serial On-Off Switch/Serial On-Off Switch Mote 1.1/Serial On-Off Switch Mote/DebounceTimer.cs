using System;
using System.Threading;

using Microsoft.SPOT;

namespace SamrakshAppNoteUtility {
    class DebounceTimer {

        private const int TRUE = 1;
        private const int FALSE = 0;
        private int interruptDisabled = FALSE;
        private int timerInterval = 10;
        private Timer interruptTimer;
        private void timerCallback(object obj) {
            interruptDisabled = FALSE;
        }

        public DebounceTimer(int _timerInterval) {
            timerInterval = _timerInterval;
        }

        public bool OkToRead() {
            if (Interlocked.CompareExchange(ref interruptDisabled, TRUE, FALSE) == TRUE) {
                return false;
            }
            if (interruptTimer == null) {
                interruptTimer = new Timer(new TimerCallback(timerCallback), interruptDisabled, timerInterval, 0);
            }
            else {
                interruptTimer.Change(timerInterval, 0);
            }
            return true;
        }

    }
}
