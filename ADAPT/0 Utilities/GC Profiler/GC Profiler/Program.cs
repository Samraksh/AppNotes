
using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.Profiling.DotNow.GCProfiler.Tests;


namespace Samraksh.Profiling.DotNow.GCProfiler {

    enum PinMap { Gpio01 = 58, Gpio02 = 55, Gpio03 = 53, Gpio04 = 52, Gpio05 = 51 };


    /// <summary>
    /// Force GC
    /// </summary>
    public static class GCProfiler {

        /// <summary>
        /// Program start
        /// </summary>
        public static void Main() {
            // Exactly one of the following should be uncommented
            var test = new AutoGCTiming();
            //var test = new MemoryAllocationTiming();

            test.Start();
        }

    }
}