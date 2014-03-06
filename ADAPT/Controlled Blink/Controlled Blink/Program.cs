using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using Samraksh.AppNote.Utility;

namespace Samraksh.SPOT.AppNote.ADAPT.ControlledBlink {

    /// <summary>
    /// Blink lights under switch control
    /// </summary>
    public class Program {
        //MSM-GPIO controlled red LEDs on the dev board.
        // Give the mapping between the GPIO pins stenciled on the ADAPT Dev board and those on the CPU itself
        private enum PinMap { Gpio01 = 58, Gpio02 = 55, Gpio03 = 53, Gpio04 = 52, Gpio05 = 51 };

        private static readonly OutputPort[] Leds = { 
            new OutputPort((Cpu.Pin)PinMap.Gpio01, true),
            new OutputPort((Cpu.Pin)PinMap.Gpio02, true),
            new OutputPort((Cpu.Pin)PinMap.Gpio03, true),
        };

        private static readonly OutputPort SimulatedGround = new OutputPort((Cpu.Pin)PinMap.Gpio04, false);
        private static readonly InputPort Input = new InputPort((Cpu.Pin)PinMap.Gpio05, false, Port.ResistorMode.PullUp);

        /// <summary>
        /// ***
        /// </summary>
        public static void Main() {

            Debug.Print("Controlled Blink " + VersionInfo.VersionDateTime);

            var toggleLight = true;
            var cntr = 0;

            while (true) {
                var mode = Input.Read();
                Debug.Print("\n " + ++cntr + " mode = " + mode);
                if (mode) {
                    for (var itr = 0; itr < Leds.Length; itr++) {
                        Debug.Print("  itr " + itr);
                        Leds[itr].Write(toggleLight);
                        //Thread.Sleep((toggleLight) ? 250 : 2000);
                        Thread.Sleep(250);
                    }
                    //Leds[0].Write(false);
                    //Thread.Sleep(1000);
                    //Leds[1].Write(false);
                    //Thread.Sleep(1000);
                    //Leds[2].Write(false);
                    //Thread.Sleep(1000);
                }
                else {
                    for (var itr = Leds.Length - 1; itr >= 0; itr--) {
                        Debug.Print("  itr " + itr);
                        Leds[itr].Write(toggleLight);
                        Thread.Sleep(250);
                    }
                }
                toggleLight = !toggleLight;
                Thread.Sleep(500);
            }

        }

    }
}
