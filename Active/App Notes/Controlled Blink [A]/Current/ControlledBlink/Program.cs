/*--------------------------------------------------------------------
 * Controlled Blink app note for the eMote ADAPT Platform
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *  1.0: initial release
---------------------------------------------------------------------*/

using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using Samraksh.AppNote.Utility;

namespace Samraksh.SPOT.AppNote.ADAPT.ControlledBlink {

    /// <summary>
    /// Blink lights whose pattern varies depending on a polled digital input value
    /// </summary>
    public class Program {

        // Mapping between the GPIO pins stenciled on the ADAPT Dev board and those on the CPU itself
        //  On the Dev board, GPIO 01-04 are connected to LEDs
        private enum PinMap { Gpio01 = 58, Gpio02 = 55, Gpio03 = 53, Gpio04 = 52, Gpio05 = 51 };

        // Define the LEDs
        private const Cpu.Pin Led1 = (Cpu.Pin)PinMap.Gpio01;
        private const Cpu.Pin Led2 = (Cpu.Pin)PinMap.Gpio02;
        private const Cpu.Pin Led3 = (Cpu.Pin)PinMap.Gpio03;

        // Define the LEDs to blink and their order of blinking
        private static readonly OutputPort[] Leds = { 
            new OutputPort(Led1, true),
            new OutputPort(Led2, true),
            new OutputPort(Led3, true),
        };

        // How much to delay between LED changes
        private const int Delay = 250;

        // Produce a signal high value. This can be connected to the input port to give a high reading
        private static readonly OutputPort SignalHigh = new OutputPort((Cpu.Pin)PinMap.Gpio04, true);

        // Input port. Port.Resistor.PullUp means that if the input pin is not connected, it will pull down (give a false value when read)
        private static readonly InputPort Input = new InputPort((Cpu.Pin)PinMap.Gpio05, false, Port.ResistorMode.PullDown);

        /// <summary>
        /// Periodically read the input port and, depending on the value, march the lights up or down.
        /// </summary>
        public static void Main() {

            Debug.Print("Controlled Blink " + VersionInfo.VersionDateTime);

            // Used to turn lights on or off
            var toggleLight = true;

            // Counter for console display purposes. This is optional.
            var cntr = 0;

            // Run forever
            while (true) {

                // Read the input
                var inputVal = Input.Read();
                Debug.Print("\n " + ++cntr + " mode = " + inputVal);

                // If high (true), turn lights on/off from 1-3
                if (inputVal) {
                    for (var itr = 0; itr < Leds.Length; itr++) {
                        Debug.Print("  itr " + itr);
                        Leds[itr].Write(toggleLight);
                        // Wait a while between lights
                        Thread.Sleep(Delay);
                    }
                }
                // If low (false), turn lights on/off from 3-1
                else {
                    for (var itr = Leds.Length - 1; itr >= 0; itr--) {
                        Debug.Print("  itr " + itr);
                        Leds[itr].Write(toggleLight);
                        Thread.Sleep(Delay);
                    }
                }

                // Switch between lights on and off
                toggleLight = !toggleLight;

                // Wait a while between loops
                Thread.Sleep(Delay);
            }

        }

    }
}
