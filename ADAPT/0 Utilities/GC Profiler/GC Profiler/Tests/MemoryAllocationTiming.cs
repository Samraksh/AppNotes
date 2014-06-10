#define Rand
//#define Const

//#define ForceGC     // force GC between pre/post tests

using System;
using System.Threading;
using Microsoft.SPOT;
using Misc;
using Samraksh.Profiling.DotNow.GCProfiler.Misc;
using Math = System.Math;

namespace Samraksh.Profiling.DotNow.GCProfiler {

    /// <summary>
    /// 
    /// </summary>
    public class MemoryAllocationTiming {
        
        // Set aside lets you reduce the amount of memory available to garbage collection. This affects GC timing.
        const int SetAsideExp = 0;
        const int SetAsideSize = (1 << SetAsideExp);

#if Const
        // Amount to allocate if constant allocation is chosen
        const int ConstAllocExp = 7;
        const int ConstAllocSize = (1 << ConstAllocExp);
#endif

#if Rand
        // Range of amounts to allocate if random allocation is chosen
        const int RandLowerAllocSize = 1;
        const int RandUpperAllocSize = 128 * 2;
        const int RandAllocSizeRange = RandUpperAllocSize - RandLowerAllocSize;
#endif

        /// <summary>
        /// 
        /// </summary>
        public void Start() {
            
            //const int numAllocTicksPerPeriod = 7000;
            const int numAllocTicksPerPeriod = 10000;
            var preIntervalTicks = new int[numAllocTicksPerPeriod];
            int preIntervalPtr;
            var postIntervalTicks = new int[numAllocTicksPerPeriod];
            int postIntervalPtr;


            Debug.EnableGCMessages(true);

            Debug.Print("\nGC Profiler: MemoryAllocationTIming");
            Debug.Print("Set-aside Array size: " + SetAsideSize);
            Debug.Print("Alloc Ticks Arrays size (int): " + 2 * numAllocTicksPerPeriod);
#if Const
            Debug.Print("Constant Allocation Size: " + ConstAllocSize);
            var dupCheck = 0; // check whether two tests are defined
#endif
#if Rand
            Debug.Print("Random Allocation Size: [" + RandLowerAllocSize + "," + RandUpperAllocSize + "]; Range " + RandAllocSizeRange);
            var rand = new Random();
            var dupCheck = 0;   // check whether two tests are defined
#endif

#if ForceGC
            Debug.Print("Force GC between pre/post runs");
#endif

            var noneCheck = dupCheck; // check whether at least one test defined
            Debug.Print("");

            var setAside = new byte[SetAsideSize];

            RunTillGc("Pre Interval", preIntervalTicks, out preIntervalPtr, true);

#if ForceGC
            Debug.GC(true);
#endif

            RunTillGc("Post Interval", postIntervalTicks, out postIntervalPtr, true);

            // Done collecting data ... Print stats

            Debug.GC(true);

            var overheadTicks = new int[Math.Max(preIntervalPtr, postIntervalPtr)];
            int overheadPtr;
            RunTillGc("Overhead", overheadTicks, out overheadPtr, false);
            Debug.Print("\nOverhead (microsec)\n");
            PrintStats(overheadTicks, overheadPtr);

            Debug.EnableGCMessages(false);

            Debug.Print("\nBefore first GC (microsec)\n");
            PrintStats(preIntervalTicks, preIntervalPtr);

            Debug.Print("\nAfter first GC, before second (microsec)\n");
            PrintStats(postIntervalTicks, postIntervalPtr);

            //Debug.Print("\nOverhead\n");
            //PrintTimes(overheadTicks, overheadPtr);

            //Debug.Print("\nBefore first GC (microsec)\n");
            //PrintTimes(preIntervalTicks, preIntervalPtr);

            //Debug.Print("\n*********************************************\n");

            //Debug.Print("\nAfter first GC, before second (microsec)\n");
            //PrintTimes(postIntervalTicks, postIntervalPtr);

            setAside[0]++;  // make sure array is not discarded
        }

        /// <summary>
        /// Collect allocation data
        /// </summary>
        /// <param name="testName">Name of the test</param>
        /// <param name="intervalTicks">Array of tick interval values</param>
        /// <param name="intervalTicksPtr">Number of items in tick interval used</param>
        /// <param name="doAlloc">true iff run till GC else run for fixed size</param>
        static void RunTillGc(string testName, int[] intervalTicks, out int intervalTicksPtr, bool doAlloc) {
            var rand = new Random();
            long lastIntervalTicks = 0;
            intervalTicksPtr = 0;
            while (true) {
                long currIntervalEnd;
                long currIntervalStart;
                if (doAlloc) {
#if Const
                    currIntervalStart = DateTime.Now.Ticks;
                    var discard = new byte[ConstAllocSize];
                    currIntervalEnd = DateTime.Now.Ticks;
#endif
#if Rand
                    var allocSize = RandLowerAllocSize + rand.Next(RandAllocSizeRange);

                    currIntervalStart = DateTime.Now.Ticks;
                    var discard = new byte[allocSize];
                    currIntervalEnd = DateTime.Now.Ticks;
#endif
                }
                else {
                    currIntervalStart = DateTime.Now.Ticks;
                    currIntervalEnd = DateTime.Now.Ticks;
                }


                var currIntervalTicks = currIntervalEnd - currIntervalStart;
                intervalTicks[intervalTicksPtr] = (int)currIntervalTicks;
                intervalTicksPtr++;

                // Check for GC or max number of loops
                if (((doAlloc && currIntervalTicks > (lastIntervalTicks + Globals.MinGCTicks)) || (!doAlloc && intervalTicksPtr > intervalTicks.Length - 1))) {
                    intervalTicksPtr--; // Skip the GC interval
                    Debug.Print("\n" + testName + ", loops " + intervalTicksPtr + ", curr (microsec): " + currIntervalTicks / Globals.TicksPerMicrosecond +
                                ", last (microsec): " + lastIntervalTicks / Globals.TicksPerMicrosecond + "\n");
                    break;
                }

                lastIntervalTicks = currIntervalTicks;

            }
        }

        static void PrintStats(int[] allocTicks, int allocTicksPtr) {
            var allocTimesD1 = new double[allocTicksPtr];
            for (var i = 0; i < allocTicksPtr; i++) {
                allocTimesD1[i] = (double)allocTicks[i] / Globals.TicksPerMicrosecond;
            }
            var stats = new Statistics(allocTimesD1);
            Debug.Print("Mean " + stats.Mean());
            Debug.Print("Stdev " + stats.Stdev());
            Debug.Print("Min " + (int)stats.Min());
            Debug.Print("Max " + (int)stats.Max());
            Debug.Print("N " + stats.N);
        }

        static void PrintTimes(int[] allocTimes, int allocTimesPtr) {
            for (var i = 0; i < Math.Min(allocTimesPtr, int.MaxValue); i++) {
                Debug.Print((allocTimes[i] / Globals.TicksPerMicrosecond).ToString());
            }
        }
    }
}
