/*--------------------------------------------------------------------
 * On-Off Switch app note for the eMote .NOW 1.0
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *  1.0: initial release
 *  1.1: fix bug: on and off switch responses are reversed
---------------------------------------------------------------------*/

using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;

// This makes it easy to reference the eMote hardware class
using Samraksh.SPOT.Hardware.EmoteDotNow;

// This includes extensions the LCD class with a method that makes it easy to convert a char to LCD. See the file LcdExtensionMethods.cs
using LcdExtensionMethods;

namespace Switch {
    public class Program {

        // Define input button instance. Initialized below.
        static InputPort inputSwitch;

        // Define an LCD instance.
        static EmoteLCD lcd = new EmoteLCD();

        // Keep track of the number of button interrupts and the last time a button interrupt was called
        static int interruptCnt = 0;
        static DateTime lastInterruptDateTime = DateTime.Now;

        public static void Main() {
            try {

                // Print the name of the app note

                Debug.Print(Resources.GetString(Resources.StringResources.AppNoteDescription));
                Debug.Print("-------------- ready -------------");

                // Initialize the LCD display. Nothing will be displayed if this is not done.

                lcd.Initialize();

                // Initialize the input button as an interrupt port. 
                // Constructor arguments
                //      We are going to input from the port associated with connector J12 Pin 1 on the .NOW board.
                //      We use Port.ResistorMode.PullDown so that when the switch is off (circuit is open), the port is pulled to ground and will read False. 
                //          Otherwise, the port will float and the value will be undefined.
                //          When the switch is on (circuit is closed), the port will be pulled to Vref+ and will read True.
                //      We want to trigger an interrupt on both leading and trailing edge of the signal.
                //  Other notes
                //      The second argument in the contructor, glitchFilter, is not currently implenmeted.
                //      The InputPort class does not have a constructor that includes Port.InterruptMode.
                //          However, InputPort inherits from InterruptPort, so we can use its constructor.

                inputSwitch = new InterruptPort(Pins.GPIO_J12_PIN1, false, Port.ResistorMode.PullUp, Port.InterruptMode.InterruptEdgeBoth);

                // Set the callback method that is accessed when an interrupt occurs

                inputSwitch.OnInterrupt += inputSwitch_OnInterrupt;

                // Loop forever
                //  If this isn't included, the Main program will exit now and nothing else will happen.

                //while (true) {
                //    Thread.Sleep(int.MaxValue);
                //}
            }
            catch (Exception ex) {
                Debug.Print("Exception thrown: " + ex.ToString());
            }
        }

        // Set up to disable interrupt
        const int TIMER_INTERVAL = 10;          // Timer duration in ms. Increase this if you have trouble with switch bounce.
        static Timer interruptTimer;            // The timer

        const int TRUE = 1;
        const int FALSE = 0;
        static int interruptDisabled = FALSE;   // TRUE if interrupt disabled, else FALSE. Initially enabled.
        /// <summary>
        /// Timer callback
        /// </summary>
        /// <remarks>Called when tiner expires</remarks>
        /// <param name="obj"></param>
        static void callback(object obj) {  
            interruptDisabled = FALSE;          // Enable interrupt
        }

        /// <summary>
        /// Handle switch interrupt
        /// </summary>
        /// <param name="pin">The pin number that caused the timeout</param>
        /// <param name="state">The state of the pin</param>
        /// <param name="time">The (local) time of the interrupt</param>
        static void inputSwitch_OnInterrupt(uint pin, uint state, DateTime time) {

            // Debounce the switch
            //  Debouncing is needed because mechanical contacts will tend to make and break momentarily when opening or closing.
            //  After an interrupt, it is effectively disabled for a short period of time (controlled by the variable TIMER_INTERVAL).
            //  First, decide whether to continue or not. CompareExchange is an atomic test-and-set.
            //      If interruptDisabled is FALSE (third arg), set it to TRUE. Return original value of interruptDisabled.
            //      Hence, if not disabled, will disable it. If disabled, will return.
            //  Second, start the timer (see below)

            if (Interlocked.CompareExchange(ref interruptDisabled, TRUE, FALSE) == TRUE) {
                return;
            }
                        
            // Print out the parameter values. This is optional.
            //  Note that pin is a numeric value. It corresponds to the enum associated with the defined pin.
            //      In this case, J12/1 is number 24.
            //  State is 0 if low, 1 if high
            //  Time is when the interrupt happened (in local time). To show the difference, also print the time span from Now.

            Debug.Print("--- " + pin + " " + state + " " + time + " " + (DateTime.Now - time).ToString());

            // Calculate the time from the last interrupt. This is optional.
            TimeSpan lastInterruptSpan = DateTime.Now - lastInterruptDateTime;
            lastInterruptDateTime = DateTime.Now;
            
            // Count the interrupts. This is optional.
            interruptCnt++;
            
            // Read the button value. True = set (high), false = reset (low)

            bool buttonValue = inputSwitch.Read();

            // Display ON or OFF to LCD, depending on switch value

            if (buttonValue) {
                lcd.Write('O'.ToLCD(), 'F'.ToLCD(), 'F'.ToLCD(), ' '.ToLCD());
                Debug.Print("Switch OFF " + interruptCnt + " " + lastInterruptSpan.Milliseconds);
            }
            else {
                lcd.Write('O'.ToLCD(), 'N'.ToLCD(), ' '.ToLCD(), ' '.ToLCD());
                Debug.Print("Switch ON  " + interruptCnt + " " + lastInterruptSpan.Milliseconds);
            }

            // Finish debouncing the switch
            //  Create and start, or restart the timer, depending on whether the timer has been created or not.
            //  Setting the period to 0 means it will run once and stop.

            if (interruptTimer == null) {
                interruptTimer = new Timer(new TimerCallback(callback), interruptDisabled, TIMER_INTERVAL, 0);
            } 
            else {
                interruptTimer.Change(TIMER_INTERVAL,0);
            }

        }


    }
}
