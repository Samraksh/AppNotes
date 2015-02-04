#define LoopTrace

using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;

namespace Samraksh.AppNote.TimerJitter {
    internal class Program {

        private const int TimerIntervalMilliSec = 10;
        private const ulong TimerIntervalMicroSec = TimerIntervalMilliSec * 1000;
        private const int NumSamples = 3000;

        private static readonly AutoResetEvent NextStep = new AutoResetEvent(false);

        private static double[] _timerTicks;
        private static int _timerTicksPtr;
        private static eMote.RealTime.Timer _realTimer;
        private static Timer _stdTimer;
        private static Statistics _stats;

        private static void Main() {
            Globals.Globals.Lcd.Display("strt");
            Debug.Print("\nTimer Jitter\n");
            Debug.Print(VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));
            Debug.Print("Debugger attached: " + Debugger.IsAttached);
            Debug.Print("");


            Thread.Sleep(3000);

            _timerTicks = new double[NumSamples];
            _stats = new Statistics(_timerTicks);

            Debug.Print("Number of samples: " + NumSamples);
            Debug.Print("Timer Interval: " + TimerIntervalMilliSec + " (millisec);" + TimerIntervalMicroSec + " (microsec)");

            Thread.Sleep(3000);

            // Profile the realtime timer
            if (ProfileRealTimeTimer()) return;

            // Profile the standard timer
            ProfileStandardTimer();
            //Thread.Sleep(3000);
            //ProfileStandardTimer();

            Globals.Globals.Lcd.Display("done");
        }


        private static bool ProfileRealTimeTimer() {
            Globals.Globals.Lcd.Display("RT 0");
            if (Debugger.IsAttached) {
                Debug.Print("\n*** Debugger is incompatible with RealTime timer. Exiting.\n");
                return true;
            }
            _realTimer = new eMote.RealTime.Timer("RealTimeInteropTimer", TimerIntervalMicroSec, 0);
            _realTimer.OnInterrupt += (data1, data2, time) => TimerCommon.OnTick(time, _realTimer);
            NextStep.WaitOne();
            Globals.Globals.Lcd.Display("RT 1");
            CalculateStats("Samraksh RealTime Timer");
            return false;
        }

        private static void ProfileStandardTimer() {
            Globals.Globals.Lcd.Display("Std0");
            _stdTimer = new Timer(_ => TimerCommon.OnTick(DateTime.Now, _stdTimer), null, 0, TimerIntervalMilliSec);
            NextStep.WaitOne();
            Globals.Globals.Lcd.Display("Std1");
            CalculateStats("Standard Timer");
        }

        private static class TimerCommon {
            private static bool _firstTick = true;
            private static long _lastTick;

            public static void OnTick(DateTime time, object timer) {
                Globals.Globals.GpioJ12P1.Write(true);
                Globals.Globals.GpioJ12P1.Write(false);

                // If we're done, reset things, raise the semaphore, and return
                if (_timerTicksPtr >= _timerTicks.Length) {
                    if (timer is eMote.RealTime.Timer) {
                        ((NativeEventDispatcher)_realTimer).Dispose(); // destroy the timer
                    }
                    else if (timer is Timer) {
                        _stdTimer.Dispose(); // destroy the timer
                    }
                    else {
                        Globals.Globals.Lcd.Display("Excp");
                        throw new Exception("Unknown timer type");
                    }
                    _timerTicksPtr = 0; // reset the pointer for next time
                    _firstTick = true;  // set to prime the pump
                    NextStep.Set(); // raise the semaphore so Main can continue
                    return;
                }

                // Get the current ticks value
                var thisTick = time.Ticks;

                // Prime the pump
                if (_firstTick) {
                    _lastTick = thisTick;
                    _firstTick = false;
                    return;
                }

                // Calculate difference from last time
                _timerTicks[_timerTicksPtr] = thisTick - _lastTick;  // Store the difference wrt last
#if LoopTrace
                if (_timerTicksPtr < 10) {
                    Debug.Print(_timerTicksPtr + " " + (long)(_timerTicks[_timerTicksPtr] / TimeSpan.TicksPerMillisecond) + " " + (_lastTick / TimeSpan.TicksPerMillisecond) + " " + (thisTick/TimeSpan.TicksPerMillisecond));
                }
#endif
                _lastTick = thisTick;
                Globals.Globals.Lcd.Display(_timerTicksPtr);

                _timerTicksPtr++;
            }
        }

        private static void CalculateStats(string timerType) {
            const long scalingFactor = TimeSpan.TicksPerMillisecond;
            const string scalingFactorLabel = "Millisecond";
            Debug.Print("");
            Debug.Print(timerType);
            Debug.Print("Units: " + scalingFactorLabel);
            Debug.Print("");
            //var n = Stats.Length();
            //Debug.Print("N: " + n);
            var mean = _stats.Mean();
            Debug.Print("Mean: " + mean / scalingFactor);
            var min = _stats.Min();
            Debug.Print("Min: " + min / scalingFactor);
            var max = _stats.Max();
            Debug.Print("Max: " + max / scalingFactor);
            //var median = Stats.Q2();
            //Debug.Print("Median: " + median / scalingFactor);
            //var mode = Stats.Mode();
            //Debug.Print("Mode: " + mode / scalingFactor);
            var std = _stats.S();
            Debug.Print("Std: " + std / scalingFactor);
            Debug.Print("");
        }

    }
}
