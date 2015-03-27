/*--------------------------------------------------------------------
 * Kiwi Buzzer: app note for the eMote .NOW
 * (c) 2015 The Samraksh Company
 * 
 * Generate a tone on the Kiwi buzzer
 * 
 * Version history
 *      1.0: initial release
---------------------------------------------------------------------*/

using System.Threading;
using Microsoft.SPOT.Hardware;

namespace Samraksh.eMote.KiwiBuzzer {
    public class Program {

        // Set the desired frequency
        private const double Freq = 261.625565;    // Frequency of middle C
        // Calculate the interval between pulses
        private const int Interval = (int)(1000 / Freq);

        /// <summary>
        /// The program
        /// </summary>
        public static void Main() {
            // GPIO J12 Pin 1 is set to true (high) to enable the Kiwi board
            var enable = new OutputPort((Cpu.Pin)24, true);
            // GPIO J12 Pin 2 is used to create the sound
            var buzzer = new OutputPort((Cpu.Pin)25, false);
            // Run forever
            while (true) {
                // Toggle the GPIO
                buzzer.Write(!buzzer.Read());
                // Sleep for half the interval
                Thread.Sleep(Interval / 2);
                // Do it again
                buzzer.Write(!buzzer.Read());
                Thread.Sleep(Interval / 2);
            }
        }

    }
}
