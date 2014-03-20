using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.SPOT.Hardware.SensorBoard;
using System.Threading;

namespace Samraksh.SPOT.Tests
{
    public class TemperatureSensorTest
    {
        public static void Main()
        {
            Cpu.Pin bus = (Cpu.Pin)Samraksh.SPOT.Hardware.EmoteDotNow.Pins.GPIO_J12_PIN4;

            Cpu.Pin otherPowerVoltageDomainPin = (Cpu.Pin)Samraksh.SPOT.Hardware.EmoteDotNow.Pins.GPIO_J12_PIN5;

            // Enable the voltage domain for the temperature sensor 
            Microsoft.SPOT.Hardware.OutputPort voltageDomainPort = new OutputPort((Cpu.Pin)otherPowerVoltageDomainPin, true);

            TemperatureSensor ts = new TemperatureSensor(bus, 1000);

            while (true)
            {
                Thread.Sleep(2000);

                Debug.Print("The current temperature is " + ts.Temperature.ToString());

                
            }

        }

    }
}
