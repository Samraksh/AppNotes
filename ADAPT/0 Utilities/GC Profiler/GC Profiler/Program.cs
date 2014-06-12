using Samraksh.Profiling.DotNow.GCProfiler.Tests;

namespace Samraksh.Profiling.DotNow.GCProfiler {

    /// <summary>
    /// Force GC
    /// </summary>
    public static class GCProfiler {

        /// <summary>
        /// Program start
        /// </summary>
        public static void Main() {
            // Exactly one of the following should be uncommented
            //var test = new AutoGCTiming();
            //var test = new MemoryAllocationTiming();
            var test = new CheckClock();

            test.Start();
        }

    }
}