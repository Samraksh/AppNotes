using System;
using System.Threading;
using Microsoft.SPOT;

namespace Samraksh {
    namespace AppNote {
        namespace Utility {

            /// <summary>
            /// Timer with a simplified interface
            /// </summary>
            public class SimpleTimer {
                private Timer TheTimer; // Can't inherit since the timer class is sealed

                private readonly TimerCallback _timerCallback;
                private readonly object _callBackValue;
                private readonly int _initialDueTime;
                private readonly int _initialPeriod;
                private int _currDueTime;
                private int _currPeriod;

                /// <summary>
                /// Timer start time
                /// </summary>
                public long StartTime { get; private set; }

                /// <summary>
                /// This creates a one-shot timer since the currPeriod is 0
                /// </summary>
                /// <param name="timerCallback"></param>
                /// <param name="callBackValue"></param>
                /// <param name="currDueTime"></param>
                public SimpleTimer(TimerCallback timerCallback, object callBackValue, int currDueTime) {
                    _timerCallback = timerCallback;
                    _callBackValue = callBackValue;
                    _initialDueTime = _currDueTime = currDueTime;
                    _initialPeriod = _currPeriod = 0;
                }

                /// <summary>
                /// This creates a periodic timer
                /// </summary>
                /// <param name="timerCallback"></param>
                /// <param name="callBackValue"></param>
                /// <param name="currDueTime"></param>
                /// <param name="currPeriod"></param>
                public SimpleTimer(TimerCallback timerCallback, object callBackValue, int currDueTime, int currPeriod) {
                    _timerCallback = timerCallback;
                    _callBackValue = callBackValue;
                    _currDueTime = currDueTime;
                    _currPeriod = currPeriod;
                }

                /// <summary>
                /// Start (or restart) the timer
                /// </summary>
                public void Start() {
                    if (TheTimer == null) {
                        TheTimer = new Timer(_timerCallback, _callBackValue, _initialDueTime, _initialDueTime);
                    }
                    else {
                        TheTimer.Change(_initialDueTime, _initialPeriod);
                    }
                    StartTime = DateTime.Now.Ticks;
                }

                /// <summary>
                /// Stop the timer
                /// </summary>
                public void Stop() {
                    if (TheTimer == null) {
                        return;
                    }
                    lock (this) {
                        // Make sure we're not in the callback before killing the timer
                        _currDueTime = _currPeriod = Timeout.Infinite;
                        TheTimer.Change(_currDueTime, _currPeriod);
                    }
                }

                /// <summary>
                /// Check if the timer is stopped
                /// </summary>
                public bool IsStopped {
                    get { return (TheTimer == null || _currDueTime == Timeout.Infinite); }
                }

                /// <summary>
                /// Prevent disposal during callback
                /// </summary>
                /// <param name="obj"></param>
                private void CallBack(object obj) {
                    lock (this) {
                        // Prevent disposal while in callback method
                        _timerCallback(obj);
                    }
                }
            }
        }
    }
}