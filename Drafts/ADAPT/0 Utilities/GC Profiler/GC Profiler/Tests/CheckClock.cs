//#define ADAPT
#define DotNow

using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.Profiling.DotNow.GCProfiler.Misc;

namespace Samraksh.Profiling.DotNow.GCProfiler.Tests {
    /// <summary>
    /// 
    /// </summary>
    public class CheckClock {

        const int NumIterations = 100 * 1000;

        /// <summary>
        /// 
        /// </summary>
        public void Start() {
#if ADAPT
            Debug.Print("ADAPT");
            var dupCheck = 0; // check whether two tests are defined
#endif
#if DotNow
            Debug.Print(".NOW");
            var dupCheck = 0; // check whether two tests are defined
#endif

            var checkForDup = dupCheck;

            Debug.Print("\nGC Profiler: CheckClock");
            Debug.Print("Number of iterations: " + NumIterations);

            var A = 1.0;
            var B = 2.0;

            var gpio = new OutputPort((Cpu.Pin)Globals.PinMap.Gpio01, true);
            var startTicks = DateTime.Now.Ticks;
            for (var i = 0; i < NumIterations; i++) {
                var C = A / B;
            }
            gpio.Write(false);
            var endTicks = DateTime.Now.Ticks;

            var elapsedTicks = endTicks - startTicks;
            Debug.Print("Elapsed time: " + elapsedTicks + " ticks, " + ((double)elapsedTicks / Globals.TicksPerMillisecond) + " milliseconds, " + ((double)elapsedTicks / (Globals.TicksPerSecond)) + " seconds");

        }
    }
}
