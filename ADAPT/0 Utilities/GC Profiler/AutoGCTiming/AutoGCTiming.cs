//#define Rand
#define Const

using System;
using Microsoft.SPOT;

namespace Samraksh.Profiling.DotNow.GCProfiler {

    public class AutoGCTiming {

        const int SetAsidePower = 0;
        const int SetAsideSize = (1 << SetAsidePower);

        const int ConstAllocExp = 16;
        const int ConstAllocSize = (1 << ConstAllocExp);

        const int RandLowerAllocSize = 1;
        const int RandUpperAllocSize = 1024;
        const int RandAllocSizeRange = RandUpperAllocSize - RandLowerAllocSize;

        const long TicksPerMillisecond = TimeSpan.TicksPerMillisecond;

        public void Start() {
            Debug.EnableGCMessages(true);

            Debug.Print("\nGC Profiler: AutoGCTiming");
            Debug.Print("Set aside size: " + SetAsideSize);
#if Const
            Debug.Print("Constant Allocation Size: " + ConstAllocSize);
            var dupCheck = 0;   // check whether two tests are defined
#endif
#if Rand
            Debug.Print("Random Allocation Size: [" + RandLowerAllocSize + "," + RandUpperAllocSize + "]; Range " + RandAllocSizeRange);
            var rand = new Random();
            var dupCheck = 0;   // check whether two tests are defined
#endif
            var noneCheck = dupCheck; // check whether at least one test defined
            Debug.Print("");

            var setAside = new byte[SetAsideSize];

            var numLoops = 0;
            long totLoopTime = 0;
            long lastLoopStart = 0;
            long lastLoopTime = 0;
            long currLoopTime = 0;
            //long startTime = DateTime.Now.Ticks;
            while (true) {
                var currLoopStart = DateTime.Now.Ticks;
                if (lastLoopStart > 0) {
                    currLoopTime = currLoopStart - lastLoopStart;
                    totLoopTime += currLoopTime;
                    numLoops++;
                    //Debug.Print(loopTime + ", mean " + (totLoopTime / numLoops) + ": " + totLoopTime + "," + numLoops + ": " + interval + "," + lastTime);
                    var mean = totLoopTime / numLoops;
                    if (currLoopTime > lastLoopTime * 2 && lastLoopTime > 0) {
                        Debug.Print("\n" + numLoops + " curr " + currLoopTime + " last " + lastLoopTime + " mean " + mean + "\n");
                    }
                }

                lastLoopStart = currLoopStart;
                lastLoopTime = currLoopTime;

                setAside[0] = 0;    // Make sure array is not discarded

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
}
