using System;
using Microsoft.SPOT;
using System.Threading;
using Microsoft.SPOT.Hardware;
using Samraksh.eMote.Emulator;

namespace Detector_Emulator {
    public class Program {

        const int BufferSize = 2;
        static readonly ushort[] BufferI = new ushort[BufferSize];
        static readonly ushort[] BufferQ = new ushort[BufferSize];

        public static void Main() {

            //AnalogInput.InitializeADC();

            Samraksh.eMote.Emulator.AnalogInput.ConfigureContinuousModeDualChannel(BufferI, BufferQ, BufferSize, 1000, AdcCallback);

            Thread.Sleep(Timeout.Infinite);
        }

        private static void AdcCallback(long arg) {
            Debug.Print("");
            for (var index = 0; index < BufferSize; index++) {
                var valI = BufferI[index];
                var valQ = BufferQ[index];
                Debug.Print(sampleNum++ + ", I: " + valI + ", Q: " + valQ);
            }
        }

        private static int sampleNum;

    }
}
