using System;
using Microsoft.SPOT;
using System.Threading;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Messaging;


namespace MFConsoleApplication1_Hello
{
    public class BlinkHi
    {
        

        //constructor
        //BlinkHi()
        //{
            //instantiate output ports
        //    led_port = new OutputPort((Cpu.Pin)1, false);
        //}


        public static void Main()
        {
           OutputPort led_port = new OutputPort((Cpu.Pin)1, false);

            //BlinkHi bh = new BlinkHi();

            Thread.Sleep(2000); //sleep to make sure all is up

            while (true) 
            {
            //H is dot dot dot dot
                led_port.Write(true) ;
                Thread.Sleep(50) ;
                led_port.Write(false) ;
                Thread.Sleep(50) ;
                led_port.Write(true) ;
                Thread.Sleep(50) ;
                 led_port.Write(false) ;
                Thread.Sleep(50) ;
                 led_port.Write(true) ;
                Thread.Sleep(50) ;
                led_port.Write(false) ;
                Thread.Sleep(50) ;
                led_port.Write(true) ;
                Thread.Sleep(50) ;
                led_port.Write(false) ;

             //I is dot dot 
                led_port.Write(true) ;
                Thread.Sleep(50) ;
                led_port.Write(false) ;
                Thread.Sleep(50) ;
                led_port.Write(true) ;
                Thread.Sleep(50) ;
                led_port.Write(false) ;
                Thread.Sleep(500) ;
            }
            //Thread.Sleep(Timeout.Infinite);
        }



        }

    }
