using System;
using System.Threading;
using Microsoft.SPOT;

namespace Samraksh.AppNote.Utility {

    public class SimpleTimer {

        public Timer TheTimer; // Can't inherit since the TheTimer class is sealed

        private readonly TimerCallback _timerCallback;
        private readonly object _callBackValue;
        private readonly int _dueTime;
        private readonly int _period;

        public bool IsStopped {get { return TheTimer == null; }}

        /// <summary>
        /// This creates a one-shot timer since the period is 0
        /// </summary>
        /// <param name="timerCallback"></param>
        /// <param name="callBackValue"></param>
        /// <param name="dueTime"></param>
        public SimpleTimer(TimerCallback timerCallback, object callBackValue, int dueTime) {
            _timerCallback = timerCallback;
            _callBackValue = callBackValue;
            _dueTime = dueTime;
            _period = 0;
        }

        /// <summary>
        /// This creates a recurrent timer
        /// </summary>
        /// <param name="timerCallback"></param>
        /// <param name="callBackValue"></param>
        /// <param name="dueTime"></param>
        /// <param name="period"></param>
        public SimpleTimer(TimerCallback timerCallback, object callBackValue, int dueTime, int period) {
            _timerCallback = timerCallback;
            _callBackValue = callBackValue;
            _dueTime = dueTime;
            _period = period;
        }

        public void StartNew() {
            TheTimer = new Timer(_timerCallback, _callBackValue, _dueTime, _period);
        }

        public void Start() {
            if (TheTimer == null) {
                TheTimer = new Timer(_timerCallback, _callBackValue, _dueTime, _period);
            }
            else {
                TheTimer.Change(_dueTime, _period);
            }
        }

        public void Stop() {
            if (TheTimer == null) {
                return;
            }
            lock (this) {   // Make sure we're not in the callback before killing the timer
                TheTimer.Dispose();
                TheTimer = null;
            }
        }

        private void CallBack(object obj) {
            lock (this) {   // Prevent disposal while in callback method
                _timerCallback(obj);
            }
        }
    }
}
