/*--------------------------------------------------------------------
 * On-Off Switch app note for the eMote .NOW 1.0
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *  1.0:	
 *		- Initial release
 *	1.1:
 *		- Fix error: on and off switch responses are reversed
 *	1.2:
 *		- Changed main thread sleep to Timeout.Infinite; renamed LcdExtensionMethods
 *	1.3:
 *		- Updated to latest namespaces
 *		- Removed ExtensionMethod and added EnhancedLcd
 *		- Added VersionInfo
 *		- Minor changes
 *	1.4:	
 *	1.5:
 *		- Updated to include binaries from eMote release 4.3.0.13
 *	1.6
 *		- Updated to eMote 4.3.0.14
 *		- Use new DebouncedSwitch class
---------------------------------------------------------------------*/

using System;
using System.Reflection;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;

namespace Samraksh.AppNote.DotNow.OnOffSwitch
{
    public class Program
    {

        // Define input button instance. Initialized below.
        // ReSharper disable once NotAccessedField.Local
        private static DebouncedSwitch _inputSwitch;

        // Define an LCD instance.
        private static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();

        public static void Main()
        {
            try
            {
                Debug.EnableGCMessages(false);

                Debug.Print("\nOn-Off Switch");

                // Print the version and build info
                Debug.Print(VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));
                Debug.Print("");

                Lcd.Write("swch");
                Thread.Sleep(1000);

                // Initialize the input button as debounced switch
                // Constructor arguments
                //      We are going to input from the port associated with connector J12 Pin 1 on the .NOW board.
                //      We use Port.ResistorMode.PullUp so that when the switch is off (circuit is open), the port is pulled to Vref and will read False. 
                //          Otherwise, the port will float and the value will be undefined.
                //          When the switch is on (circuit is closed), the port will be pulled to Gnd and will read True.
                
                _inputSwitch = new DebouncedSwitch(Pins.GPIO_J12_PIN1, OnSwitchPress);

                // Put this thread to sleep and don't wake up
                //  If this isn't included, the Main program will exit now and nothing else will happen.

                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception ex)
            {
                Debug.Print("Exception thrown: " + ex);
            }
        }

        /// <summary>
        /// Callback for switch press
        /// </summary>
        /// <param name="buttonValue"></param>
        private static void OnSwitchPress(bool buttonValue)
        {
            // Display ON or OFF to LCD, depending on switch value

            if (!buttonValue)
            {
                Lcd.Write("ON");
                Debug.Print("Switch ON");
            }
            else
            {
                Lcd.Write("OFF");
                Debug.Print("Switch OFF");
            }
        }
    }
}
