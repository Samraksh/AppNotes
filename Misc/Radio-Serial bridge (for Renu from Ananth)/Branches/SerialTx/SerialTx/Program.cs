using System;
using System.Text;
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
            var ct = new CopperTx();

            while (true) {
                Thread.Sleep(100);
            }
        }
    }


    public class CopperTx : Program {
        public CopperTx() {
            var serialPort = new SerialPort("COM2") {
                BaudRate = 115200,
                Parity = Parity.None,
                StopBits = StopBits.One,
                DataBits = 8,
                Handshake = Handshake.None
            };

            serialPort.Open();

            var count = 1;

            var payloadBytes = new byte[sizeof(int)];    // added by Bill
            //var newLineChar = new char[1] ;
            //var newLineChar = new[]{'\n'};
            var newLineBytes = Encoding.UTF8.GetBytes("\n");
            serialPort.Write(newLineBytes, 0, newLineBytes.Length);

            while (true) {
                //var payload = System.Text.Encoding.UTF8.GetBytes(count.ToString());   // removed by Bill

                //BitConverter.GetBytes(payloadBytes, count);  // added by Bill
                payloadBytes = Encoding.UTF8.GetBytes(count.ToString());

                serialPort.Write(payloadBytes, 0, payloadBytes.Length);
                serialPort.Write(newLineBytes, 0, newLineBytes.Length);
                serialPort.Flush(); // added by Bill

                Globals.Lcd.Display((count / 10) % 10000);
                count++;

                Thread.Sleep(1000);
            }
        }
    }

}


