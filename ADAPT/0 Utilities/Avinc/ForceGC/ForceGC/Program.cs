
using System;
using System.Threading;
using Microsoft.SPOT;


namespace Samraksh.AppNote.DotNow.Avinc {

    /// <summary>
    /// Force GC
    /// </summary>
    public static class ForceGc {


        /// <summary>
        /// Get things started
        /// </summary>
        public static void Main() {
            const int numThreads = 300;
            Debug.Print("Starting " + numThreads + " threads");
            
            
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
                var microSec = now.Hour * 24 * 60 * 60 * 1000 + now.Minute * 60 * 60 * 1000 + now.Second * 60 * 1000 + now.Millisecond;
                Debug.Print(microSec.ToString());
                Thread.Sleep(1000);
            }
        }

        private static void MainThread(int threadNum) {
            Debug.Print("Starting " + threadNum);
            while (true) {
                var a = new byte[1];
                Thread.Sleep(1);
            }
        }


    }
}