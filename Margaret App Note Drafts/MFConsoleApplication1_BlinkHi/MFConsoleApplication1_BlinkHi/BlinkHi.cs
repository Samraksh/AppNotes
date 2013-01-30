using System;
using Microsoft.SPOT;
using System.Threading;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Messaging;

namespace MFConsoleApplication1_BlinkHi
{

    public class BlinkHi
    {
         static OutputPort _led_port;

        //constructor
        BlinkHi()
        {
        //instantiate output ports
            _led_port = new OutputPort((Cpu.Pin)1, false);
         }

        public static void Main()
        {
           // Debug.Print(
             //   Resources.GetString(Resources.StringResources.String1));

            BlinkHi bh = new BlinkHi();
            while (true) {
            //H is dot dot dot dot
                _led_port.Write(true) ;
                Thread.Sleep(50) ;
                _led_port.Write(false) ;
                Thread.Sleep(50) ;
                _led_port.Write(true) ;
                Thread.Sleep(50) ;
                _led_port.Write(false) ;
                Thread.Sleep(50) ;
               _led_port.Write(true) ;
                Thread.Sleep(50) ;
                _led_port.Write(false) ;
                Thread.Sleep(50) ;
                _led_port.Write(true) ;
                Thread.Sleep(50) ;
                _led_port.Write(false) ;

             //I is dot dot 
                _led_port.Write(true) ;
                Thread.Sleep(50) ;
                _led_port.Write(false) ;
                Thread.Sleep(50) ;
                _led_port.Write(true) ;
                Thread.Sleep(50) ;
                _led_port.Write(false) ;
                Thread.Sleep(500) ;
            }
            //Thread.Sleep(Timeout.Infinite);
        }

    }
}
