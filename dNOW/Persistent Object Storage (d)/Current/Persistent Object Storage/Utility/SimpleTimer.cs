/*=========================
 * Simple Timer Class
 *  Define a simple one-shot or recorring timer
 * Versions
 *  1.0 Initial Version
 *  1.1 Fixed bugs 
 *      - Rcurrent timer
 *      - Thread-safe callback (use CallBack method with lock
=========================*/

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
                private Timer _theTimer; // Can't inherit since the timer class is sealed

                private readonly TimerCallback _timerCallback;
                private readonly object _callBackValue;
                private readonly int _initialDueTime;
                private readonly int _initialPeriod;
                // Need current values in order to tell if timer is running or not
                //  Cannot reflect on timer to determine its status
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
                    _initialDueTime = _currDueTime = currDueTime;
                    _initialPeriod = _currPeriod = currPeriod;
                }

                /// <summary>
                /// Start (or restart) the timer
                /// </summary>
                public void Start() {
                    if (_theTimer == null) {
                        _theTimer = new Timer(CallBack, _callBackValue, _initialDueTime, _initialPeriod);
                    }
                    else {
                        _theTimer.Change(_initialDueTime, _initialPeriod);
                    }
                    StartTime = DateTime.Now.Ticks;
                }

                /// <summary>
                /// Stop the timer
                /// </summary>
                public void Stop() {
                    if (_theTimer == null) {
                        return;
                    }
                    lock (this) {
                        // Make sure we're not in the callback before killing the timer
                        _currDueTime = _currPeriod = Timeout.Infinite;
                        _theTimer.Change(_currDueTime, _currPeriod);
                    }
                }

                /// <summary>
                /// Check if the timer is stopped
                /// </summary>
                public bool IsStopped {
                    get { return (_theTimer == null || _currDueTime == Timeout.Infinite); }
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