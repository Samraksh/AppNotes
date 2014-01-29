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
    /// Assumes that Sensor Board's Other Power is enabled via GPIO Pin 4
    ///     and that temperature sensor input is GPIO Pin 3
    /// </remarks>
    public class Program {

        static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();
        private static TemperatureSensor _temperatureSensor;

        /// <summary>
        /// Main program
        /// </summary>
        public static void Main() {
            Debug.EnableGCMessages(false);
            Debug.Print("\nSense Temperature " + VersionInfo.Version + " (" + VersionInfo.BuildDateTime + ")");
            Lcd.Display("temp");
            Thread.Sleep(4000);

            try {
                var otherPower = new OutputPort(Pins.GPIO_J11_PIN4, true);
                Thread.Sleep(500);
                _temperatureSensor = new TemperatureSensor(Pins.GPIO_J11_PIN3);
                while (true) {
                    _temperatureSensor.Sense();
                    var temperatureC = _temperatureSensor.TemperatureC;
                    var temperatureF = _temperatureSensor.TemperatureF;
                    Debug.Print("Temperature =" + temperatureC + " / " + temperatureF);
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
}
