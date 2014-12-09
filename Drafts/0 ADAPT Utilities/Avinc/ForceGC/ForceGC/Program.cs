//#define EnableGCMessages
//#define PrintWhileProfiling
#define SaveWhileProfiling
//#define ForceGC
#define NoAlloc
#define SignalGPIO

using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;


namespace Samraksh.AppNote.DotNow.Avinc {

    enum PinMap { Gpio01 = 58, Gpio02 = 55, Gpio03 = 53, Gpio04 = 52, Gpio05 = 51 };


    /// <summary>
    /// Force GC
    /// </summary>
    public static class ForceGc {
        private const string Delim = ":";

        const int NumBytesPerAllocation = 100;
        const int NumAllocationsPerActivation = 300;

        const int NumMainThreads = 1;
        const int MainThreadSleep = 10;

        private const int MaxMainThreadSamples = 100;
        private const int MaxPrintThreadSamples = 15;

#if SaveWhileProfiling
        static readonly long[] PrintBuffer = new long[MaxPrintThreadSamples];
        private static int _printBufferPtr;
        private static readonly AutoResetEvent WaitForFull = new AutoResetEvent(false);
        private static bool _profiling;

        static readonly AutoResetEvent[] MainThreadSync = new AutoResetEvent[NumMainThreads];
#endif
        /// <summary>
        /// Get things started
        /// </summary>
        public static void Main() {

#if EnableGCMessages
            Debug.EnableGCMessages(true);
            Debug.Print("GC messages enabled");
#else
            Debug.EnableGCMessages(false);
            Debug.Print("GC messages disabled");
#endif



#if SaveWhileProfiling
            Debug.Print("Save while profiling");
            Debug.Print("Collecting up to " + MaxMainThreadSamples + " Main Thread / " + MaxPrintThreadSamples + " Print Thread samples");
            for (var i = 0; i < NumMainThreads; i++) {
                MainThreadSync[i] = new AutoResetEvent(false);
            }
            _profiling = true;
#endif

#if PrintWhileProfiling
            Debug.Print("Print while profiling");
#endif

#if ForceGC
            Debug.Print("Force garbage collection");
#else
            Debug.Print("Auto garbage collection");
#endif
#if NoAlloc
            Debug.Print("No data allocation");
#else
            Debug.Print("Allocating " + NumBytesPerAllocation + " bytes per allocation, " + NumAllocationsPerActivation + " allocations per activation");

#endif

            Debug.Print("Starting " + NumMainThreads + " main threads");
            Debug.Print("Main Thread sleep time " + MainThreadSleep);

            for (var i = 0; i < NumMainThreads; i++) {
                var i1 = i;
                var thread = new Thread(() => MainThread(i1));
                thread.Start();
            }

            new Thread(PrintThread).Start();
            Debug.Print("Starting");

#if SaveWhileProfiling
            WaitForFull.WaitOne();
            _profiling = false;

            Debug.Print("Results");
            Debug.EnableGCMessages(false);
            for (var i = 0; i < PrintBuffer.Length; i++) {
                if (PrintBuffer[i] == 0) {
                    break;
                }
                Debug.Print("00" + Delim + PrintBuffer[i]);
            }
            MainThreadSync[0].Set();
#endif


        }

        /// <summary>
        /// Collect profiling data
        /// </summary>
        private static void PrintThread() {
            while (true) {
#if ForceGC
                Debug.GC(true); // Force garbage collection
#endif
#if PrintWhileProfiling
                Debug.Print(DateTime.Now.Ticks.ToString());
#endif
#if SaveWhileProfiling
                if (!_profiling || _printBufferPtr >= PrintBuffer.Length) {
                    Debug.Print("Ending Sampling");
                    WaitForFull.Set();
                    return;
                }
                PrintBuffer[_printBufferPtr] = DateTime.Now.Ticks;
                _printBufferPtr++;
#endif
                Thread.Sleep(1000);
            }
        }

        //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// Work is done here 
        /// </summary>
        /// <param name="threadNum"></param>
        private static void MainThread(int threadNum) {
#if SaveWhileProfiling
            var samples = new long[MaxMainThreadSamples];
            var samplePtr = 0;
#endif
#if SignalGPIO
            const Cpu.Pin Led1 = (Cpu.Pin)PinMap.Gpio01;
            OutputPort gpio;
            var gpioState = true;
            gpio = new OutputPort(Led1, true);
#endif
            //var cnt = 0;
            //Debug.Print("Starting " + threadNum);
            while (true) {
                if (!_profiling) {
                    break;
                }
#if SignalGPIO
                if (threadNum == 0) {
                    gpioState = !gpioState;
                    gpio.Write(gpioState);
                }
#endif
#if SaveWhileProfiling
                if (samplePtr < MaxMainThreadSamples) {
                    samples[samplePtr] = DateTime.Now.Ticks;
                    samplePtr++;
                }
                else {
                    _profiling = false;
                    break;
                }
#endif
                //if (cnt % 1000 == 0) { Debug.Print(threadNum + ", " + cnt++); }
#if !NoAlloc
                for (var i = 0; i < NumAllocationsPerActivation; i++) {
                    var a = new byte[NumBytesPerAllocation];
                }
#endif
                Thread.Sleep(MainThreadSleep);
            }
#if SaveWhileProfiling
            MainThreadSync[threadNum].WaitOne();
            Debug.Print("");
            for (var i = 0; i < MaxMainThreadSamples; i++) {
                if (samples[i] == 0) {
                    break;
                }
                if (threadNum + 1 < 10) {
                    Debug.Print("0" + (threadNum + 1) + Delim + samples[i]);
                }
                else {
                    Debug.Print((threadNum + 1) + Delim + samples[i]);
                }
            }
            if (threadNum < NumMainThreads - 1) {
                MainThreadSync[threadNum + 1].Set();
            }
#endif

        }


    }
}