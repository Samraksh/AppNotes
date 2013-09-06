using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;

namespace Samraksh.SPOT.Tests
{
    public class InterruptPortTest
    {
        public const int numberOfEvents = 100;

        public static bool callbackRecieved = false;

        public static Microsoft.SPOT.Hardware.OutputPort resultPort = new OutputPort(Samraksh.SPOT.Hardware.EmoteDotNow.Pins.GPIO_J12_PIN3, false);


        public static void DisplayStats(string result, string resultParameter1, string resultParameter2, string resultParameter3, string resultParameter4, string resultParameter5, int accuracy)
        {
            Debug.Print("\r\nresult=" + result + "\r\n");
            Debug.Print("\r\naccuracy=" + accuracy.ToString() + "\r\n");
            Debug.Print("\r\nresultParameter1=" + resultParameter1 + "\r\n");
            Debug.Print("\r\nresultParameter2=" + resultParameter2 + "\r\n");
            Debug.Print("\r\nresultParameter3=" + resultParameter3 + "\r\n");
            Debug.Print("\r\nresultParameter4=" + resultParameter4 + "\r\n");
            Debug.Print("\r\nresultParameter5=" + resultParameter5 + "\r\n");
        }

        public static void Main()
        {
            UInt16 i = 0;

            UInt16 timeout = 0x0;

            Microsoft.SPOT.Hardware.InterruptPort interruptPortA = new InterruptPort(Samraksh.SPOT.Hardware.EmoteDotNow.Pins.GPIO_J12_PIN1, false, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeHigh);
            Microsoft.SPOT.Hardware.OutputPort outputPortA = new OutputPort(Samraksh.SPOT.Hardware.EmoteDotNow.Pins.GPIO_J12_PIN2, false);

            interruptPortA.OnInterrupt += interruptPortA_OnInterrupt;

            interruptPortA.DisableInterrupt();

            while (i++ <  numberOfEvents)
            {
                outputPortA.Write(true);

                Thread.Sleep(250);

                outputPortA.Write(false);

                while (timeout++ < 0xffff)
                {
                    if (callbackRecieved)
                        break;
                }

                if (timeout >= 0xffff)
                {
                    DisplayStats("FAIL", "The GPIO Level 0 CSharp Test Failed", "", "", "", "", 0);
                    return;
                }

                callbackRecieved = false;
            }

            DisplayStats("PASS", "The GPIO Level 0 CSharp Test Passed", "", "", "", "", 0);

        }

        static void interruptPortA_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            Debug.Print("Interrupt" + time.Millisecond.ToString());

            resultPort.Write(true);

            resultPort.Write(false);

            
            callbackRecieved = true;
        }

    }
}
