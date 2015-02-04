using System;
using System.Threading;
using System.IO.Ports;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;


namespace SerialTx {

    static class Globals {
        public static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();
    }

    public class Program {
        //public static OutputPort csmaSend = new OutputPort((Cpu.Pin)24, true);
        //public static OutputPort csmaNoBeacon = new OutputPort((Cpu.Pin)25, true);
        //public static OutputPort csmaReceive = new OutputPort((Cpu.Pin)29, true);


        public static void Main() {
            Debug.EnableGCMessages(false);
            CopperTx ct = new CopperTx();

            while (true) {
                Thread.Sleep(100);
            }
        }
    }


    public class CopperTx : Program {
        public CopperTx() {
            SerialPort serialPort = new SerialPort("COM2");
            serialPort.BaudRate = 115200;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.DataBits = 8;
            serialPort.Handshake = Handshake.None;

            serialPort.Open();

            int count = 1;

            var payload = new byte[sizeof(int)];    // added by Bill

            while (true) {
                //var payload = System.Text.Encoding.UTF8.GetBytes(count.ToString());   // removed by Bill

                BitConverter.GetBytes(payload, count);  // added by Bill

                serialPort.Write(payload, 0, payload.Length);
                serialPort.Flush(); // added by Bill

                Globals.Lcd.Display(count % 10000);

                Thread.Sleep(1000);
                count++;
            }
        }
    }

}


