/*--------------------------------------------------------------------
 * Accelerometer: app note for the eMote .NOW
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *  1.0:	- initial release
 *  1.1:	- Update to eMote v. 12 namespaces
 ---------------------------------------------------------------------*/

using System;
using System.Reflection;
using System.Threading;

using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;
using Math = Samraksh.AppNote.Utility.Math;
using SB = Samraksh.eMote.SensorBoard;

namespace Samraksh {
	namespace AppNote {
		namespace Accelerometer {

			/// <summary>
			/// Uses the sensor board's accelerometer to detect freefall: when the downward grativational force is significatly less than 1g.
			/// </summary>
			/// <remarks>
			/// The accelerometer is 3-D, so it gives acceleration in the X, Y and Z planes. 
			/// The effect of gravity is constant acceleration, pulling the accelerometer towards the center of the earth.
			/// If the accelerometer is perfectly level in the x and y dimensions, then x and y should show 0g and z should show about 1g.
			/// If not, then the x and/or y values will be non-zero, with the z value being less.
			/// Using the pythagorean theorem, we can calculate the total g force:
			///     g = sqrt(x^2 + y^2 + z^2)
			/// </remarks>
			public class Program {
				private const UInt16 RefreshRate = 1000; // The frequency in ms at which we want to get samples
				private const float FreefallThresholdFactor = 0.8F;    // The percentage of 1g at which we detect freefall

				private static SB.Accelerometer _axl;   // The accelerometer object
				// ReSharper disable once UnusedMember.Local
				private static readonly OutputPort AccelerometerPower = new OutputPort(Pins.GPIO_J11_PIN3, true);   // Enable power to the accelerometer

				//private static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();  // Define the LCD
				private static readonly EmoteLCD Lcd = new EmoteLCD();

				/// <summary>
				/// Main thread: set things up and then go to sleep.
				/// Once the accelerometer is started, an interrupt will occur according to the specified refresh rate.
				/// </summary>
				public static void Main() {

					Lcd.Initialize();
					Lcd.Clear();

					Debug.EnableGCMessages(false);  // We don't want to see garbage collector messages in the Output window

					Debug.Print(VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));
					//    Lcd.Write("Accl");
					Thread.Sleep(4000);

					_axl = new SB.Accelerometer(RefreshRate, SensorEventCallback);  // Set up the accelerometer

					Thread.Sleep(Timeout.Infinite);
					while (true) {
						Thread.Sleep(1000);
						Debug.Print("Alive");
					}
				}

				/// <summary>
				/// Handle an accelerometer event callback
				/// </summary>
				/// <param name="typeOfEvent">The kind of event</param>
				/// <param name="timestamp">The time of the event</param>
				private static void SensorEventCallback(SB.Accelerometer.EventType typeOfEvent, DateTime timestamp) {

					// If not an accelerometer data update event, we're not interested.
					if (typeOfEvent != SB.Accelerometer.EventType.DataUpdate) return;
					// Get the current accelerometer data
					var currentData = _axl.CurrentData;
					// Get the axis values and convert to micro-g
					var x = currentData.X * 1000F;
					var y = currentData.Y * 1000F;
					var z = currentData.Z * 1000F;
					// Calculate the total acceleration. At rest, this will be about 1g
					var s = Math.Sqrt(x * x + y * y + z * z);   // We're using a fast sqrt calculation
					// If the total acceleration is less than the threshold factor then we detect freefall.
					var isfFalling = (s < FreefallThresholdFactor * 1000) ? " x" : "  ";

					var isFalling4 = (isfFalling + "    ").ToCharArray();
					var isF0 = isFalling4[0].ToLcd();
					var isf1 = isFalling4[1].ToLcd();
					var isf2 = isFalling4[2].ToLcd();
					var isf3 = isFalling4[3].ToLcd();

					Debug.Print("<" + new string(isFalling4) + ">");
					Debug.Print(isF0 + " " + isf1 + " " + isf2 + " " + isf3);

					Lcd.Write(isF0, isf1, isf2, isf3);

					//Lcd.Write(isfFalling);
					return;
					Debug.Print("\n" + _seq++ + isfFalling + " x=" + x + ", y=" + y + ", z=" + z + ", S=" + s);
				}
				private static int _seq;
			}
		}
	}
}