using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;

namespace Sleep
{
    public class Program
    {
        //MSM-GPIO controlled red LEDs on the dev board.
        private static OutputPort[] lights = new OutputPort[4] { 
                                                new OutputPort((Cpu.Pin)52, true),
                                                new OutputPort((Cpu.Pin)53, true),
                                                new OutputPort((Cpu.Pin)55, true),
                                                new OutputPort((Cpu.Pin)58, true) };
        
        public static void Main() {
            
            int itr = 0;
            bool toggleLight = true;

            // Example how to enter sleep power state.
            //Microsoft.SPOT.Hardware.PowerState.Sleep(SleepLevel.Sleep, HardwareEvent.SystemTimer);

            Debug.Print(
                Resources.GetString(Resources.StringResources.String1));

            while (true) {
                for (itr = 0; itr < lights.Length; ++itr) {
                    lights[itr].Write(toggleLight);
                    Thread.Sleep(250);
                }
                toggleLight = !toggleLight;
            }
            
        }

    }
}
