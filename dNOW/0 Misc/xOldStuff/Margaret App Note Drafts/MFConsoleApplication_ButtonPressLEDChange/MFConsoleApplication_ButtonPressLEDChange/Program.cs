using System;
using Microsoft.SPOT;
using System.Threading;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Messaging;


namespace MFConsoleApplication_ButtonPressLEDChange
{

     public class ButtonPressLEDChange
    {

     InterruptPort _button_InterruptPort ;
     static OutputPort _led_port ;
     static bool   button_state ;

     ButtonPressLEDChange()
     {
         //Instantiate the Output port
         _led_port = new OutputPort((Cpu.Pin)1, false );

         //Instantiate the interrupt port
         _button_InterruptPort = new InterruptPort((Cpu.Pin)4, false, Port.ResistorMode.PullDown, Port.InterruptMode.InterruptEdgeBoth);

         //Connect the interrupt to the handler method
         _button_InterruptPort.OnInterrupt += new NativeEventHandler(button_OnInterrupt);

     }


     static void button_OnInterrupt(uint data1, uint data2, DateTime time)
     {
         //Toggle button_state
         button_state = !button_state;
         _led_port.Write(button_state); //write the state to LED
         Debug.Print("Button " + ((button_state) ? "Down" : "Up"));
     }


        public static void Main()
        {
            ButtonPressLEDChange bpLEDc = new ButtonPressLEDChange();
            Thread.Sleep(Timeout.Infinite);            
        }

    }
}
