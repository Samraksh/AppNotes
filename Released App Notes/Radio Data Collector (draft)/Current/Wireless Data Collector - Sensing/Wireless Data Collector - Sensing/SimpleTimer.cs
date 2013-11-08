using System;
using System.Threading;
using Microsoft.SPOT;

namespace Samraksh.AppNote.Utility {

    public class SimpleTimer {

        private Timer theTimer; // Can't inherit since the Timer class is sealed

        private TimerCallback timerCallback;
        private object callBackValue;
        private int dueTime;
        private int period;

        /// <summary>
        /// This creates a one-shot timer since the period is 0
        /// </summary>
        /// <param name="_timerCallback"></param>
        /// <param name="_callBackValue"></param>
        /// <param name="_dueTime"></param>
        public SimpleTimer(TimerCallback _timerCallback, object _callBackValue, int _dueTime) {
            timerCallback = _timerCallback;
            callBackValue = _callBackValue;
            dueTime = _dueTime;
            period = 0;
        }

        /// <summary>
        /// This creates a recurrent timer
        /// </summary>
        /// <param name="_timerCallback"></param>
        /// <param name="_callBackValue"></param>
        /// <param name="_dueTime"></param>
        /// <param name="_period"></param>
        public SimpleTimer(TimerCallback _timerCallback, object _callBackValue, int _dueTime, int _period) {
            timerCallback = _timerCallback;
            callBackValue = _callBackValue;
            dueTime = _dueTime;
            period = _period;
        }

        public void StartNew() {
            theTimer = new Timer(timerCallback, callBackValue, dueTime, period);
        }

        public void Start() {
            if (theTimer == null) {
                theTimer = new Timer(timerCallback, callBackValue, dueTime, period);
            }
            else {
                theTimer.Change(dueTime, period);
            }
        }

        public void Stop() {
            if (theTimer == null) {
                return;
            }
            lock (this) {   // Make sure we're not in the callback before killing the timer
                theTimer.Dispose();
            }
        }

        private void CallBack(object obj) {
            lock (this) {   // Prevent disposal while in callback method
                timerCallback(obj);
            }
        }
    }
}
