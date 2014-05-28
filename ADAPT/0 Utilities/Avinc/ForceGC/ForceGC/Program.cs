
using System;
using System.Threading;
using Microsoft.SPOT;


namespace Samraksh.AppNote.DotNow.Avinc {

    /// <summary>
    /// Force GC
    /// </summary>
    public static class ForceGc {
        const int NumItems = 100;
        const int NumThreads = 300;
        const int MainThreadSleep = 100;

        static readonly long[] Buffer = new long[120];
        private static int _bufPtr;
        private static readonly AutoResetEvent WaitForFull = new AutoResetEvent(false);

        /// <summary>
        /// Get things started
        /// </summary>
        public static void Main() {
            //Debug.EnableGCMessages(true);
            Debug.Print("Save to memory array; suppress I/O while sampling");
            Debug.Print("Starting " + NumThreads + " threads" + ", " + NumItems + " items per allocation");
            Debug.Print("Collecting " + Buffer.Length + " timing samples");
            Debug.Print("Main Thread sleep time " + MainThreadSleep);

            for (var i = 0; i < NumThreads; i++) {
                var i1 = i;
                var thread = new Thread(() => MainThread(i1));
                thread.Start();
            }

            new Thread(PrintThread).Start();

            WaitForFull.WaitOne();

            Debug.Print("Results");
            for (var i = 0; i < Buffer.Length; i++) {
                Debug.Print(Buffer[i].ToString());
            }


        }

        private static void PrintThread() {
            while (true) {
                //var now = DateTime.Now;
                //Debug.Print(now.Ticks.ToString());
                if (_bufPtr >= Buffer.Length) {
                    Debug.Print("Ending Sampling");
                    WaitForFull.Set();
                    return;
                }
                Buffer[_bufPtr] = DateTime.Now.Ticks;
                _bufPtr++;
                //Debug.Print(_bufPtr+", "+Buffer.Length);
                Thread.Sleep(1000);
            }
        }

        private static void MainThread(int threadNum) {
            //var cnt = 0;
            //Debug.Print("Starting " + threadNum);
            while (true) {
                //if (cnt % 1000 == 0) { Debug.Print(threadNum + ", " + cnt++); }
                var a = new byte[NumItems];
                Thread.Sleep(MainThreadSleep);
            }
        }


    }
}