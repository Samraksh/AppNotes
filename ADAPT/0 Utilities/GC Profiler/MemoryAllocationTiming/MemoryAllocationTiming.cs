//#define Rand
#define Const

using System;
using System.Threading;
using Microsoft.SPOT;
using Misc;
using Math = System.Math;

namespace Samraksh.Profiling.DotNow.GCProfiler {

    public class MemoryAllocationTiming {

        const int TicksPerMillisecond = (int)TimeSpan.TicksPerMillisecond;  // 10,000
        const int TicksPerMicrosecond = TicksPerMillisecond / 1000; // 1000
        const long MinGCTicks = 5 * TicksPerMillisecond; // Ticks

        const int SetAsideExp = 0;
        const int SetAsideSize = (1 << SetAsideExp);

        const int ConstAllocExp = 7;
        const int ConstAllocSize = (1 << ConstAllocExp);

        const int RandLowerAllocSize = 1;
        const int RandUpperAllocSize = 1024;
        const int RandAllocSizeRange = RandUpperAllocSize - RandLowerAllocSize;

        public void Start() {

            const int numAllocMeasuresPerPeriod = 7000;
            var preIntervalTicks = new int[numAllocMeasuresPerPeriod];
            int preIntervalPtr;
            var postIntervalTicks = new int[numAllocMeasuresPerPeriod];
            int postIntervalPtr;


            Debug.EnableGCMessages(true);

            Debug.Print("\nGC Profiler: MemoryAllocationTIming");
            Debug.Print("Set aside size: " + SetAsideSize);
            Debug.Print("AllocTimesArray size (int): " + 2 * numAllocMeasuresPerPeriod);
#if Const
            Debug.Print("Constant Allocation Size: " + ConstAllocSize);
            var dupCheck = 0; // check whether two tests are defined
#endif
#if Rand
            Debug.Print("Random Allocation Size: [" + RandLowerAllocSize + "," + RandUpperAllocSize + "]; Range " + RandAllocSizeRange);
            var rand = new Random();
            var dupCheck = 0;   // check whether two tests are defined
#endif
            var noneCheck = dupCheck; // check whether at least one test defined
            Debug.Print("");

            var setAside = new byte[SetAsideSize];

            RunTillGc("Pre Interval", preIntervalTicks, out preIntervalPtr, true);

            RunTillGc("Post Interval", postIntervalTicks, out postIntervalPtr, true);

            // Done collecting data ... Print stats

            Debug.GC(true);

            var overheadTicks = new int[Math.Max(preIntervalPtr, postIntervalPtr)];
            var overheadPtr = 0;
            RunTillGc("Overhead", overheadTicks, out overheadPtr, false);
            Debug.Print("\nOverhead\n");
            PrintStats(overheadTicks, overheadPtr);

            Debug.EnableGCMessages(false);

            Debug.Print("\nBefore first GC (microsec)\n");
            PrintStats(preIntervalTicks, preIntervalPtr);

            Debug.Print("\nAfter first GC, before second (microsec)\n");
            PrintStats(postIntervalTicks, postIntervalPtr);

            Debug.Print("\nOverhead\n");
            PrintTimes(overheadTicks, overheadPtr);

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
        /// <param name="testName"></param>
        /// <param name="intervalTicks">Array of tick interval values</param>
        /// <param name="intervalTicksPtr"></param>
        /// <param name="doAlloc"></param>
        static void RunTillGc(string testName, int[] intervalTicks, out int intervalTicksPtr, bool doAlloc) {
            var numLoops = 0;
            long lastLoopStart = 0;
            long lastLoopTicks = 0;
            long currIntervalTicks = 0;
            intervalTicksPtr = 0;
            while (true) {
                var currLoopStart = DateTime.Now.Ticks;
                if (lastLoopStart > 0) {
                    currIntervalTicks = currLoopStart - lastLoopStart;
                    numLoops++;

                    // Check for GC or max number of loops
                    if (lastLoopTicks > 0 && ((doAlloc && currIntervalTicks > (lastLoopTicks + MinGCTicks)) || (!doAlloc && intervalTicksPtr > intervalTicks.Length - 1))) {
                        intervalTicksPtr--;
                        Debug.Print("\n" + testName + ", loops " + numLoops + ", curr (microsec): " + currIntervalTicks / TicksPerMicrosecond +
                                    ", last (microsec): " + lastLoopTicks / TicksPerMicrosecond + "\n");
                        break;
                    }

                    // Put this after the check for GC so that we ignore the bump
                    intervalTicks[intervalTicksPtr] = (int)currIntervalTicks;
                    intervalTicksPtr++;

                }

                lastLoopStart = currLoopStart;
                lastLoopTicks = currIntervalTicks;

                if (doAlloc) {

#if Const
                    var discard = new byte[ConstAllocSize];
#endif
#if Rand
                var allocSize = RandLowerAllocSize + rand.Next(RandAllocSizeRange);
                var discard = new byte[allocSize];
                //Debug.Print("Alloc size " + allocSize);
#endif
                }
            }
        }

        static void PrintStats(int[] allocTicks, int allocTicksPtr) {
            var allocTimesD1 = new double[allocTicksPtr];
            for (var i = 0; i < allocTicksPtr; i++) {
                allocTimesD1[i] = (double)allocTicks[i] / TicksPerMicrosecond;
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
                Debug.Print((allocTimes[i] / TicksPerMicrosecond).ToString());
            }
        }
    }
}
