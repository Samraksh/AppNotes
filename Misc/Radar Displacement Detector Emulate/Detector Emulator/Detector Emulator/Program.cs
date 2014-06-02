using System;
using Microsoft.SPOT;
//using Samraksh.SPOT.Emulator;
using System.Threading;
using Samraksh.SPOT.Emulator;

namespace Detector_Emulator {
    public class Program {
        public static void Main() {
            int x = 3;
            var adcConfig = new ADC_Configuration();
            var adc = new ADC(adcConfig);
            ADC.Init(4000);
            Thread.Sleep(Timeout.Infinite);
        }

    }
}
