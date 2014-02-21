using System;
using Microsoft.SPOT;
using Samraksh.SPOT.Hardware.SensorBoard;

namespace Samraksh.SPOT.Tests
{
    public class AxlTest
    {

        private Accelerometer.AxlCallbackType sensorCallback;

        private Accelerometer axl;

        private UInt16 RefreshRate = 500;

        private void SensorEventCallback(Accelerometer.EventType typeOfEvent, DateTime timestamp)
        {
            if (typeOfEvent == Accelerometer.EventType.DataUpdate)
            {
                Debug.Print(axl.CurrentData.ToString());
            }
        }

        public AxlTest()
        {
            axl = new Accelerometer(500, SensorEventCallback);
            
        }

        public static void Main()
        {
            AxlTest axlTest = new AxlTest();

            while (true)
            {
                System.Threading.Thread.Sleep(500);
            }
        }

    }
}
