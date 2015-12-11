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
 *	1.5
 *		- Updated to eMote 4.3.0.14
---------------------------------------------------------------------*/

using System;
using System.Reflection;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;

namespace Samraksh.AppNote.DotNow.OnOffSwitch {
	public class Program {

		// Define input button instance. Initialized below.
		static InputPort _inputSwitch;

		// Define an LCD instance.
		static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();

		// Keep track of the number of button interrupts and the last time a button interrupt was called
		static int _interruptCnt;
		static DateTime _lastInterruptDateTime = DateTime.Now;

		public static void Main() {
			try {
				Debug.EnableGCMessages(false);

				Debug.Print("\nOn-Off Switch");

				// Print the version and build info
				VersionInfo.Init(Assembly.GetExecutingAssembly());
				Debug.Print("Version " + VersionInfo.Version + ", build " + VersionInfo.BuildDateTime);
				Debug.Print("");

				// Initialize the input button as an interrupt port. 
				// Constructor arguments
				//      We are going to input from the port associated with connector J12 Pin 1 on the .NOW board.
				//      We use Port.ResistorMode.PullUp so that when the switch is off (circuit is open), the port is pulled to Vref and will read False. 
				//          Otherwise, the port will float and the value will be undefined.
				//          When the switch is on (circuit is closed), the port will be pulled to Gnd and will read True.
				//      We want to trigger an interrupt on both leading and trailing edge of the signal.
				//  Other notes
				//      The second argument in the contructor, glitchFilter, is not currently implemented.
				//      The InputPort class does not have a constructor that includes Port.InterruptMode.
				//          However, InputPort inherits from InterruptPort, so we can use its constructor.

				_inputSwitch = new InterruptPort(Pins.GPIO_J12_PIN1, false, Port.ResistorMode.PullUp, Port.InterruptMode.InterruptEdgeBoth);

				var buttonValue = _inputSwitch.Read();
				DisplaySwitchOnLCD(buttonValue);

				// Set the callback method that is accessed when an interrupt occurs

				_inputSwitch.OnInterrupt += inputSwitch_OnInterrupt;

				// Put this thread to sleep and don't wake up
				//  If this isn't included, the Main program will exit now and nothing else will happen.

				Thread.Sleep(Timeout.Infinite);
			}
			catch (Exception ex) {
				Debug.Print("Exception thrown: " + ex);
			}
		}

		// Set up to disable interrupt
		const int TimerInterval = 100;	// Timer duration in ms. Increase this if you have trouble with switch bounce.
		static Timer _interruptTimer;	// The timer

		const int True = 1;
		const int False = 0;
		static int _interruptDisabled = False;   // TRUE if interrupt disabled, else FALSE. Initially enabled.

		/// <summary>
		/// Timer callback
		/// </summary>
		/// <remarks>Called when timer expires</remarks>
		/// <param name="obj"></param>
		static void TimerCallback(object obj) {
			_interruptDisabled = False;          // Enable interrupt
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

			if (Interlocked.CompareExchange(ref _interruptDisabled, True, False) == True) {
				return;
			}

			var now = DateTime.Now;
			
			// Calculate the time from the last interrupt. This is optional.
			var lastInterruptSpan = now - _lastInterruptDateTime;
			_lastInterruptDateTime = DateTime.Now;

			// Count the interrupts. This is optional.
			_interruptCnt++;

			// Print out the callback argument values & other interrupt info. This is optional.
			//  Note that pin is a numeric value. It corresponds to the enum associated with the defined pin.
			//      In this case, J12/1 is pin 24.
			//  Time is when the interrupt happened (in local time). To show the difference, you can also print the time span from Now.

			Debug.Print("--- Pin " + pin + ", State " + state + ", Time " + time + "; Last interrupt span: " + lastInterruptSpan.Milliseconds + ", Interrupt cnt: " + _interruptCnt);

			// Read the button value. True = on (high), false = off (low)

			var buttonValue = _inputSwitch.Read();

			DisplaySwitchOnLCD(buttonValue);

			// Finish debouncing the switch
			//  Create and start, or restart the timer, depending on whether the timer has been created or not.
			//  Setting the period to 0 means it will run once and stop.

			if (_interruptTimer == null) {
				_interruptTimer = new Timer(TimerCallback, _interruptDisabled, TimerInterval, 0);
			}
			else {
				_interruptTimer.Change(TimerInterval, 0);
			}

		}

		private static void DisplaySwitchOnLCD(bool buttonValue) {
			// Display ON or OFF to LCD, depending on switch value

			if (!buttonValue) {
				Lcd.Write("ON");
				Debug.Print("Switch ON");
			}
			else {
				Lcd.Write("OFF");
				Debug.Print("Switch OFF");
			}
		}
	}
}
