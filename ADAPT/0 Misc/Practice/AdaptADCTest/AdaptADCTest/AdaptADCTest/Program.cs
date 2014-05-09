using System;
using System.Threading;
using Microsoft.SPOT;
using Samraksh.eMote.Adapt;

namespace Samraksh.Adapt.ADCTest
{
    public class Program
    {
        public static void Main()
        {
            Program p = new Program();
            int ADC_channel_0 = 0;
            int ADC_channel_1 = 1;
            Samraksh.eMote.Adapt.AnalogInput analogInput = new Samraksh.eMote.Adapt.AnalogInput();
            ushort result;

            while (true)
            {
                result = analogInput.Read(ADC_channel_0);
                Debug.Print("Result from channel 0 is " + result.ToString());
                result = analogInput.Read(ADC_channel_1);
                Debug.Print("Result from channel 1 is " + result.ToString());
                Thread.Sleep(500);
            }
        }
    }

    
}
