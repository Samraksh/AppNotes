using System;
using Microsoft.SPOT;
using System.Threading;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Messaging;


namespace MLEmulatorTestApp
{
    public class MLEmulatorTest
    {
        InterruptPort _button1_InterruptPort;
        InterruptPort _button2_InterruptPort;
        InterruptPort _button3_InterruptPort;

        static OutputPort _led1_port;
        static OutputPort _led2_port;
        static OutputPort _led3_port;

        static bool button1_state;
        static bool button2_state;
        static bool button3_state;

        //constructor
        public MLEmulatorTest()
        {
            //instantiate output ports
            _led1_port = new OutputPort((Cpu.Pin)0, false);
            _led2_port = new OutputPort((Cpu.Pin)1, false);
            _led3_port = new OutputPort((Cpu.Pin)2, false);

            //instantiate interrupt ports
            _button1_InterruptPort = new InterruptPort(( Cpu.Pin)3 ,false, Port.ResistorMode.PullDown, Port.InterruptMode.InterruptEdgeBoth) ;
            _button2_InterruptPort = new InterruptPort(( Cpu.Pin)4 ,false, Port.ResistorMode.PullDown, Port.InterruptMode.InterruptEdgeBoth) ;
            _button3_InterruptPort = new InterruptPort(( Cpu.Pin)5, false, Port.ResistorMode.PullDown, Port.InterruptMode.InterruptEdgeBoth) ;

            //connect the interrupts to handler methods
            _button1_InterruptPort.OnInterrupt += new NativeEventHandler(button1_OnInterrupt) ;
            _button2_InterruptPort.OnInterrupt += new NativeEventHandler(button2_OnInterrupt);
            _button3_InterruptPort.OnInterrupt += new NativeEventHandler(button3_OnInterrupt);
        }

        //the interrupt handlers
        static void button1_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            //toggle button 1 state
            button1_state = !button1_state;
            _led1_port.Write(button1_state);  //state info to led 1
            Debug.Print("Button 1" + (( button1_state) ? "Down" : "Up" )) ;
        }


        static void button2_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            //toggle button 2 state
            button2_state = !button2_state;
            _led2_port.Write(button2_state);//state info to led 2
            Debug.Print("Button 2" + ((button2_state) ? "Down" : "Up"));
        }


        static void button3_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            //toggle button 3 state
            button3_state = !button3_state;
            _led3_port.Write(button3_state);//state info to led 2
            Debug.Print("Button 3" + ((button3_state) ? "Down" : "Up"));
        }






        public static void Main()
        {
            //Debug.Print(
               // Resources.GetString(Resources.StringResources.String1));


            MLEmulatorTest mlem = new MLEmulatorTest();
            Thread.Sleep(Timeout.Infinite) ;

        }

    }
}
