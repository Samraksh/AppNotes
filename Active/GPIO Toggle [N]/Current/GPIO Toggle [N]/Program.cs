/*--------------------------------------------------------------------
 * GPIO Toggle: app note for the eMote .NOW
 * (c) 2015 The Samraksh Company
 * 
 * Toggle a GPIO
 * 
 * Version history
 *      1.0:	Initial release
 *      
 *      1.1:	Changed to use Samraksh.eMote.DotNow.Pins for pin assignment
 *				Changed namespace to conform with other app notes
 *				Added eMote folder with DLLs and TinyClr
---------------------------------------------------------------------*/

using System.Reflection;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;

namespace Samraksh.AppNote.DotNow.GPIOToggle {
    public class Program {

        /// <summary>
        /// Toggle a GPIO pin once a second forever
        /// </summary>
        public static void Main() {
			Debug.EnableGCMessages(false);

			Debug.Print("\nGPIO Toggle");

			// Print the version and build info
			VersionInfo.Init(Assembly.GetExecutingAssembly());
			Debug.Print("Version " + VersionInfo.Version + ", build " + VersionInfo.BuildDateTime);
			Debug.Print("");


			
			// GPIO J12 Pin 1 is toggled
	        var gpio = new OutputPort(Pins.GPIO_J12_PIN1, true);

            // Run forever
            while (true) {
                // Toggle the GPIO
				//	Read the present value, reverse it, and write it
                gpio.Write(!gpio.Read());
                // Sleep for a second
                Thread.Sleep(1000);
            }
        }

    }
}
