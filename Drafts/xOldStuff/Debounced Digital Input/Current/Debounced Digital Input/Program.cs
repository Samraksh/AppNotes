/*--------------------------------------------------------------------
 * Debounced Digital Input app note for the eMote ADAPT Platform
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *  1.0: initial release
---------------------------------------------------------------------*/

using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using Samraksh.AppNote.Utility;

namespace Samraksh.AppNotes.ADAPT.DebouncedDigitalInput {
    public class Program {

        // Give the mapping between the GPIO pins stenciled on the ADAPT Dev board and those on the CPU itself
        private enum PinMap { Gpio01 = 58, Gpio02 = 55, Gpio03 = 53, Gpio04 = 52, Gpio05 = 51 };

        // Initialize an interrupt port for a mechanical switch that, we assume, has bounce
        // Constructor arguments
        //      We are going to input from the port associated with connector CPU pin 58 (which is GPIO01 on the ADAPT Platform)
        //      We assume that the input will either be high or low; disconnected (neither high nor low) is undefined.
        //          We include debouncing during which input interrupts are disabled, 
        //              and assume that if the input is disconnected, it will be so for less than the debounce time.
        //      We want to trigger an interrupt on both leading and trailing edge of the signal.
        //  Other notes
        //      The second argument in the contructor, glitchFilter, is not currently implemented.
        private static readonly InterruptPort Input = new InterruptPort((Cpu.Pin)PinMap.Gpio05, false, Port.ResistorMode.PullDown, Port.InterruptMode.InterruptEdgeBoth);

        // Define the status ports. 
        static readonly OutputPort StatusHi = new OutputPort((Cpu.Pin)PinMap.Gpio01, false);    //  Raised (set high) when input is high
        static readonly OutputPort StatusLo = new OutputPort((Cpu.Pin)PinMap.Gpio02, true);     //  Reset (set low) when input is low

        // Define ports to provide logic power. 
        static readonly OutputPort PwrHigh = new OutputPort((Cpu.Pin)PinMap.Gpio04, true);      //  Provide V++ (high)

        // Keep track of the number of button interrupts and the last time a button interrupt was called
        //  This is optional
        static int _interruptCnt;
        static DateTime _lastInterruptDateTime = DateTime.Now;

        public static void Main() {
            try {
                // Print the name & version/build info 
                Debug.Print("Debounced Digital Input " + VersionInfo.VersionDateTime);

                // Flash the LED a few times to confirm we're working
                for (var i = 0; i < 5; i++) {
                    StatusHi.Write(true);
                    StatusLo.Write(!true);
                    Thread.Sleep(500);
                    StatusHi.Write(false);
                    StatusLo.Write(!false);
                    Thread.Sleep(500);
                }

                // Set the callback method that is accessed when an interrupt occurs
                Input.OnInterrupt += Input_OnInterrupt;

                Debug.Print("Ready for input");

                var cnt = 0;
                while (true) {
                    Thread.Sleep(1000);
                    Debug.Print(cnt++ + " Input value is " + Input.Read());
                }

                // Put this thread to sleep and don't wake up
                //  If this isn't included, the Main program will exit now and nothing else will happen.
                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception ex) {
                Debug.Print("Exception thrown: " + ex);
            }
        }

        // Set up to disable interrupt
        const int TimerInterval = 10;   // Timer duration in ms. Increase this if you have trouble with input bounce.
        static Timer _debounceTimer;    // The debounce timer

        // Debounce variables
        const int True = 1;
        const int False = 0;
        static int _isInputInterruptDisabled = False;   // True if interrupt disabled, else False. Initially enabled.

        /// <summary>
        /// Timer callback
        /// </summary>
        /// <remarks>Called when timer expires</remarks>
        /// <param name="obj"></param>
        static void DebounceTimer_Callback(object obj) {
            Debug.Print("Debounce expiration");
            _isInputInterruptDisabled = False;          // Enable interrupt
        }

        /// <summary>
        /// Handle input interrupt
        /// </summary>
        /// <param name="pin">The pin number that caused the timeout</param>
        /// <param name="state">The state of the pin</param>
        /// <param name="time">The (local) time of the interrupt</param>
        static void Input_OnInterrupt(uint pin, uint state, DateTime time) {

            // Debounce the input
            //  Debouncing is needed because mechanical contacts will tend to make and break momentarily when opening or closing.
            //  After an interrupt, input is effectively disabled for a short period of time (controlled by the variable TimerInterval).
            //  First, decide whether to continue or not. CompareExchange is an atomic test-and-set.
            //      If interruptDisabled is FALSE (third arg), set it to TRUE. Return original value of interruptDisabled.
            //      Hence, if not disabled, will disable it. If disabled, will return.
            //  Second, start the timer (see below)

            // Do an atomic compare and swap
            //  If the interrupt is disabled, we've had an interrupt recently and we want to ignore them for a while.
            //  If disabled, the result will be True; else False
            //  This is done atomically and avoids a potential race condition if bounce interrupts come quickly

            Debug.Print("Input change ...");

            if (Interlocked.CompareExchange(ref _isInputInterruptDisabled, True, False) == True) {
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

            // Read the button value. True = set (high); false = reset (low)
            var inputValue = Input.Read();

            // Set status port values
            StatusHi.Write(inputValue);
            StatusLo.Write(!inputValue);

            // Print the status
            Debug.Print("Input " + (inputValue ? "ON" : "OFF") + _interruptCnt + " " + lastInterruptSpan.Milliseconds);

            // Finish debouncing 
            //  This will disable the port interrupt for the specified interval
            if (_debounceTimer == null) {
                // Timer has not been created; do so now
                //  Period of 0 means it is a one shot timer: will run once and stop
                _debounceTimer = new Timer(DebounceTimer_Callback, _isInputInterruptDisabled, TimerInterval, 0);
            }
            else {
                // Timer exists; restart it
                _debounceTimer.Change(TimerInterval, 0);
            }

        }
    }
}
