/*--------------------------------------------------------------------
 * GPIO Toggle: app note for the eMote .NOW
 * (c) 2015 The Samraksh Company
 * 
 * Toggle a GPIO
 * 
 * Version history
 *      1.0: initial release
 *      1.1: tbd
---------------------------------------------------------------------*/

using System.Threading;
using Microsoft.SPOT.Hardware;

namespace Samraksh.eMote.GPIOToggle {
    public class Program {

        /// <summary>
        /// The program
        /// </summary>
        public static void Main() {
            // GPIO J12 Pin 1 is toggled
            var gpio = new OutputPort((Cpu.Pin)24, true);

            // Run forever
            while (true) {
                // Toggle the GPIO
                gpio.Write(!gpio.Read());
                // Sleep for a second
                Thread.Sleep(1000);
            }
        }

    }
}
