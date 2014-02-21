/*--------------------------------------------------------------------
 * Sense Temperature (OneWire) app note for eMote .NOW 1.0
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
using Samraksh.SPOT.AppNote.Utility;
using Samraksh.SPOT.Hardware.EmoteDotNow;

namespace Samraksh.AppNote.SenseTemperature {
    /// <summary>
    /// Temperature Sensor App Note
    /// </summary>
    /// <remarks>
    /// Sensor Board's Other Power is enabled via GPIO Pin 4 & temperature sensor i/o is GPIO Pin 3
    /// </remarks>
    public class Program {

        static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();
        static readonly TemperatureSensor TempSensor = new TemperatureSensor(Pins.GPIO_J11_PIN3);

        /// <summary>
        /// Main program
        /// </summary>
        public static void Main() {
            Debug.EnableGCMessages(false);
            Debug.Print("\nSense Temperature " + VersionInfo.Version + " (" + VersionInfo.BuildDateTime + ")");
            Lcd.Display("temp");

            // Enable "Other Power" on sensor board and keep it from being garbage-collected via using
            using (var otherPower = new OutputPort(Pins.GPIO_J11_PIN4, true)) {

                // Sense the temperature periodically
                try {
                    while (true) {
                        // Sense the temperature; keep things fast by skipping the CRC check
                        var ms1 = SenseAndMeasureExecutionTime(false);
                        Debug.Print("Skip CRC: " + ms1 + " ms required; " + TempSensor.TemperatureC + "C / " +
                                    TempSensor.TemperatureF + "F");

                        // Do it again, this time checking CRC
                        var ms2 = SenseAndMeasureExecutionTime(true);
                        Debug.Print("Check CRC: " + ms2 + " ms required; " + TempSensor.TemperatureC + "C / " +
                                    TempSensor.TemperatureF + "F");

                        // Show the difference
                        Debug.Print("Skipping saves " + (ms2 - ms1) + " ms");

                        // Give a blank line & sleep for a while
                        Debug.Print("");
                        Thread.Sleep(3000);
                    }
                }
                catch (Exception e) {
                    Debug.Print(e.ToString());
                    Lcd.Display("Err");
                    Thread.Sleep(Timeout.Infinite);
                }
            }
        }

        /// <summary>
        /// Sense with optional CRC checking, and calculate ms required
        /// </summary>
        /// <param name="checkCrc"></param>
        /// <returns></returns>
        private static double SenseAndMeasureExecutionTime(bool checkCrc) {
            var beginSense = DateTime.Now.Ticks;
            TempSensor.Sense(checkCrc);
            var endSense = DateTime.Now.Ticks;
            // Subtract the sensor delay, as that does not enter into the execution time required
            var ms1 = ((double)(endSense - beginSense) / TimeSpan.TicksPerMillisecond) - TempSensor.SensorDelay;
            return ms1;
        }
    }
}
