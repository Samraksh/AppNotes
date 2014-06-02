using System;
using Microsoft.SPOT;
using System.Threading;
using Samraksh.eMote.Emulator;

namespace Detector_Emulator {
    public class Program {

        const int BufferSize = 2;
        static readonly ushort[] BufferI = new ushort[BufferSize];
        static readonly ushort[] BufferQ = new ushort[BufferSize];

        public static void Main() {

            //AnalogInput.InitializeADC();
            AnalogInput.ConfigureContinuousModeDualChannel(BufferI, BufferQ, BufferSize, 4, AdcCallback);

            Thread.Sleep(Timeout.Infinite);
        }

        private static void AdcCallback(long arg) {
            Debug.Print("");
            for (var i = 0; i < BufferSize; i++) {
                Debug.Print(sampleNum++ + " I " + " Q");
            }
        }

        private static int sampleNum;

    }
}
