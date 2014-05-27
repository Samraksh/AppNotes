
using System;
using System.Threading;
using Microsoft.SPOT;


namespace Samraksh.AppNote.DotNow.Avinc {

    /// <summary>
    /// Force GC
    /// </summary>
    public static class ForceGc {
        const int NumItems = 100;


        /// <summary>
        /// Get things started
        /// </summary>
        public static void Main() {
            const int numThreads = 300;
            Debug.EnableGCMessages(true);
            Debug.Print("Starting " + numThreads + " threads" + ", " + NumItems + " items per allocation");


            for (var i = 0; i < numThreads; i++) {
                var i1 = i;
                var thread = new Thread(() => MainThread(i1));
                thread.Start();
                //new Thread(MainThread).Start();
            }

            new Thread(PrintThread).Start();

        }

        private static void PrintThread() {
            while (true) {
                var now = DateTime.Now;
                Debug.Print(now.Ticks.ToString());
                Thread.Sleep(1000);
            }
        }

        private static void MainThread(int threadNum) {
            //var cnt = 0;
            Debug.Print("Starting " + threadNum);
            while (true) {
                //if (cnt % 1000 == 0) { Debug.Print(threadNum + ", " + cnt++); }
                var a = new byte[NumItems];
                Thread.Sleep(1);
            }
        }


    }
}