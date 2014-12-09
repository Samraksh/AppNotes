using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Samraksh.SPOT.Tests
{
    public class ADCContinuousDualModeTest
    {
        public static bool samplesReady = false;

        uint samplingTime = 1000;

        const uint numberOfSamples = 1000;

        public Microsoft.SPOT.Hardware.OutputPort debugPort = new OutputPort(Samraksh.SPOT.Hardware.EmoteDotNow.Pins.GPIO_J12_PIN1, false);

        public ushort[] ibuffer = new ushort[numberOfSamples];

        public ushort[] qbuffer = new ushort[numberOfSamples];

        public void adcCallback(long threshold)
        {
            debugPort.Write(true);
            debugPort.Write(false);

            Debug.Print(" I " + ibuffer[200].ToString() + " Q " + qbuffer[200].ToString() + "\n");

            samplesReady = true;
        }

        public ADCContinuousDualModeTest()
        {
            Samraksh.SPOT.Hardware.EmoteDotNow.AnalogInput.InitializeADC();

            Samraksh.SPOT.Hardware.EmoteDotNow.AdcCallBack adcCallbackDelegate = adcCallback;

            Samraksh.SPOT.Hardware.EmoteDotNow.AnalogInput.ConfigureContinuousModeDualChannel(ibuffer, qbuffer, numberOfSamples, samplingTime, adcCallback);

        }

        public static void Main()
        {
            ADCContinuousDualModeTest adcTest = new ADCContinuousDualModeTest();

            while (true)
            {
                System.Threading.Thread.Sleep(1000);
            }

        }

    }
}
