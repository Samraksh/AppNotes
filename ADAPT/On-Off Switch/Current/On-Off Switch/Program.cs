/*--------------------------------------------------------------------
 * On-Off Switch app note for the eMote ADAPT Platform
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *  1.0: initial release
---------------------------------------------------------------------*/

using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;

namespace Switch {
    public class Program {

        // Initialize the input button as an interrupt port. 
        // Constructor arguments
        //      We are going to input from the port associated with connector CPU pin 58 (which is GP01 on the ADAPT Platform)
        //      We use Port.ResistorMode.PullUp so that when the switch is off (circuit is open), the port is pulled high and will read True. 
        //          Without PullUp, the port will float and the value will be undefined.
        //          When the switch is on (circuit is closed), the port will be pulled to low and will read False.
        //      We want to trigger an interrupt on both leading and trailing edge of the signal.
        //  Other notes
        //      The second argument in the contructor, glitchFilter, is not currently implenmeted.
        //      The InputPort class does not have a constructor that includes Port.InterruptMode.
        //          However, InputPort inherits from InterruptPort, so we can use its constructor.
        private static readonly InterruptPort InputSwitch = new InterruptPort((Cpu.Pin)58, false, Port.ResistorMode.PullUp, Port.InterruptMode.InterruptEdgeBoth);

        // Define the switch status port. It is raised (set high) when the button is pressed
        static readonly OutputPort SwitchStatus = new OutputPort((Cpu.Pin)52, false);

        // Keep track of the number of button interrupts and the last time a button interrupt was called
        //  This is optional
        static int _interruptCnt;
        static DateTime _lastInterruptDateTime = DateTime.Now;

        public static void Main() {
            try {
                // Print the name of the app note
                Debug.Print("On-Off Switch");

                // Flash the LED a few times to make sure we're working
                for (var i = 0; i < 5; i++) {
                    SwitchStatus.Write(true);
                    Thread.Sleep(500);
                    SwitchStatus.Write(false);
                    Thread.Sleep(500);
                }

                // Set the callback method that is accessed when an interrupt occurs
                InputSwitch.OnInterrupt += inputSwitch_OnInterrupt;

                // Put this thread to sleep and don't wake up
                //  If this isn't included, the Main program will exit now and nothing else will happen.
                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception ex) {
                Debug.Print("Exception thrown: " + ex.ToString());
            }
        }

        // Set up to disable interrupt
        const int TimerInterval = 10;   // Timer duration in ms. Increase this if you have trouble with switch bounce.
        static Timer _debounceTimer;    // The timer

        // Switch debounce variables
        const int True = 1;
        const int False = 0;
        static int _isSwitchInterruptDisabled = False;   // True if interrupt disabled, else False. Initially enabled.

        /// <summary>
        /// Timer callback
        /// </summary>
        /// <remarks>Called when timer expires</remarks>
        /// <param name="obj"></param>
        static void DebounceTimer_Callback(object obj) {
            _isSwitchInterruptDisabled = False;          // Enable interrupt
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
            //  After an interrupt, switch input is effectively disabled for a short period of time (controlled by the variable TimerInterval).
            //  First, decide whether to continue or not. CompareExchange is an atomic test-and-set.
            //      If interruptDisabled is FALSE (third arg), set it to TRUE. Return original value of interruptDisabled.
            //      Hence, if not disabled, will disable it. If disabled, will return.
            //  Second, start the timer (see below)

            // Do an atomic compare and swap
            //  If the interrupt is disabled, we've had an interrupt recently and we want to ignore them for a while.
            //  If disabled, the result will be True; else False
            //  This is done atomically and avoids a potential race condition if bounce interrupts come quickly

            Debug.Print("Switch press ...");

            if (Interlocked.CompareExchange(ref _isSwitchInterruptDisabled, True, False) == True) {
                return;
            }

            // Print out the parameter values. This is optional.
            //  Note that pin is a numeric value. It corresponds to the enum associated with the defined pin.
            //      In this case, J12/1 is number 24.
            //  State is 0 if low, 1 if high
            //  Time is when the interrupt happened (in local time). To show the difference, also print the time span from Now.

            Debug.Print("--- " + pin + " " + state + " " + time + " " + (DateTime.Now - time));

            // Calculate the time from the last interrupt. This is optional.
            var lastInterruptSpan = DateTime.Now - _lastInterruptDateTime;
            _lastInterruptDateTime = DateTime.Now;

            // Count the interrupts. This is optional.
            _interruptCnt++;

            // Read the button value. True = reset (low), false = set (high)
            var buttonValue = !InputSwitch.Read();

            // Set switch status port value
            SwitchStatus.Write(buttonValue);

            // Print the status
            Debug.Print("Switch " + (buttonValue ? "ON" : "OFF") + _interruptCnt + " " + lastInterruptSpan.Milliseconds);

            // Finish debouncing the switch
            //  This will disable the switch port interrupt for the specified interval
            if (_debounceTimer == null) {
                // Timer has not been created; do so now
                //  Period of 0 means it is a one shot timer: will run once and stop
                _debounceTimer = new Timer(DebounceTimer_Callback, _isSwitchInterruptDisabled, TimerInterval, 0);
            }
            else {
                // Timer exists; restart it
                _debounceTimer.Change(TimerInterval, 0);
            }

        }
    }
}
