//#define Rand
#define Const

//#define InjectPersistentObjects
//#define SuppressGCMessages

using System;
using Microsoft.SPOT;
using Samraksh.Profiling.DotNow.GCProfiler.Misc;

namespace Samraksh.Profiling.DotNow.GCProfiler.Tests {

    /// <summary>
    /// 
    /// </summary>
    public class AutoGCTiming {

        const int SetAsideExp = 0;
        const int SetAsideSize = (1 << SetAsideExp);

        const int ConstAllocExp = 7;
        const int ConstAllocSize = (1 << ConstAllocExp);

        const int RandLowerAllocSize = 1;
        const int RandUpperAllocSize = 1024;
        const int RandAllocSizeRange = RandUpperAllocSize - RandLowerAllocSize;

        const int InjectInterval = 100;  // smaller number = more frequent injections
        const int InjectSize = 1;

        const long TicksPerMillisecond = TimeSpan.TicksPerMillisecond;

        /// <summary>
        /// 
        /// </summary>
        public void Start() {

            Debug.Print("\nGC Profiler: AutoGCTiming");
            Debug.Print("Set aside size: " + SetAsideSize);
#if SuppressGCMessages
            Debug.EnableGCMessages(false);
            Debug.Print("GC messages disabled");
#else
            Debug.EnableGCMessages(true);
            Debug.Print("GC messages enabled");
#endif

#if Const
            Debug.Print("Constant Allocation Size: " + ConstAllocSize);
            var dupCheck = 0;   // check whether two tests are defined
#endif
#if Rand
            Debug.Print("Random Allocation Size: [" + RandLowerAllocSize + "," + RandUpperAllocSize + "]; Range " + RandAllocSizeRange);
            var rand = new Random();
            var dupCheck = 0;   // check whether two tests are defined
#endif

#if InjectPersistentObjects
            var persist = new ArrayList();
            Debug.Print("Inject persistent object byte[" + InjectSize + "] every " + InjectInterval + " allocations");
#endif
            var noneCheck = dupCheck; // check whether at least one test defined
            Debug.Print("");

            var setAside = new byte[SetAsideSize];

            var numLoops = 0;
            long lastLoopTime = 0;
            long totTicks = 0;

            while (true) {

                setAside[0] = 0;    // Make sure array is not discarded
#if Rand
                var allocSize = RandLowerAllocSize + rand.Next(RandAllocSizeRange);
#endif

                var currLoopStartTicks = DateTime.Now.Ticks;
#if InjectPersistentObjects
                if (numLoops % InjectInterval == 0) {
                    persist.Add(new byte[InjectSize]);
                }
#endif
#if Const
                var discard = new byte[ConstAllocSize];
                var currLoopEndTicks = DateTime.Now.Ticks;

#endif
#if Rand
                var discard = new byte[allocSize];
                var currLoopEndTicks = DateTime.Now.Ticks;

#endif
                var currLoopTicks = currLoopEndTicks - currLoopStartTicks;
                numLoops++;
                totTicks += currLoopTicks;
                if (currLoopTicks > (lastLoopTime + Globals.MinGCTicks)) {
                    var meanTicks = totTicks / numLoops;
                    Debug.Print("\n" + numLoops + ",  curr (microsec): " + currLoopTicks / Globals.TicksPerMicrosecond + " last (microsec): " + lastLoopTime / Globals.TicksPerMicrosecond + ", mean (microsec): " + meanTicks);
                    Debug.Print("Est GC time (microsec): " + (currLoopTicks - meanTicks) / Globals.TicksPerMicrosecond + "\n");
                }

                lastLoopTime = currLoopTicks;
            }
        }
    }
}
