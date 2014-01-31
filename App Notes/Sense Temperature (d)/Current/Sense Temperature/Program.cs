#define MyCode

using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using SB = Samraksh.SPOT.Hardware.SensorBoard;


using Samraksh.AppNote.Utility;

using Samraksh.SPOT.AppNote.Utility;
using Samraksh.SPOT.Hardware.EmoteDotNow;

namespace Samraksh.AppNote.SenseTemperature {
    /// <summary>
    /// Temperature Sensor App Note
    /// </summary>
    /// <remarks>
    /// Assumes that Sensor Board's Other Power is enabled via GPIO Pin 4
    ///     and that temperature sensor input is GPIO Pin 3
    /// </remarks>
    public class Program {

        static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();

        /// <summary>
        /// Main program
        /// </summary>
        public static void Main() {
            Debug.EnableGCMessages(false);
            Debug.Print("\nSense Temperature " + VersionInfo.Version + " (" + VersionInfo.BuildDateTime + ")");
            Lcd.Display("temp");
            var otherPower = new OutputPort(Pins.GPIO_J11_PIN4, true);
            Thread.Sleep(4000);

#if MyCode
            try {
                Thread.Sleep(500);
                var temperatureSensor = new TemperatureSensor(Pins.GPIO_J11_PIN3);
                while (true) {
                    temperatureSensor.Sense();
                    var temperatureC = temperatureSensor.TemperatureC;
                    var temperatureF = temperatureSensor.TemperatureF;
                    Debug.Print("Temperature =" + temperatureC + " / " + temperatureF);
                    Thread.Sleep(3000);
                }
            }
            catch (Exception e) {
                Debug.Print(e.ToString());
                Lcd.Display("Err");
                Thread.Sleep(Timeout.Infinite);
            }
#else
            try {
                var temperatureSensor = new SB.TemperatureSensor(Pins.GPIO_J11_PIN3, 1000);
                while (true) {
                    Thread.Sleep(3000);
                    var currTemp = temperatureSensor.Temperature;
                    Debug.Print("Temp: " + currTemp);

                }
            }
            catch (Exception e) {
                Debug.Print(e.ToString());
                Lcd.Display("Err");
                Thread.Sleep(Timeout.Infinite);
            }
#endif
        }

    }
}
