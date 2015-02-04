using System;
using System.Threading;
using System.Text;
using System.IO.Ports;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.eMote;
using Samraksh.eMote.DotNow;

namespace HeartRate {
    public class Program {
        public static SerialPort serialPort = new SerialPort("COM2");
        public static EmoteLCD lcd = new EmoteLCD();
        public static int txCnt = 0;
        public static int rxCnt = 0;

        static void SerialPortHandler(object sender, SerialDataReceivedEventArgs e) {

            byte[] m_recvBuffer = new byte[100];
            //SerialPort serialPort = (SerialPort)sender;

            int numBytes = serialPort.BytesToRead;
            serialPort.Read(m_recvBuffer, 0, numBytes);
            rxCnt = (rxCnt + 1) % 10;
            lcd.Write(LCD.CHAR_0 + txCnt, LCD.CHAR_0, LCD.CHAR_0, LCD.CHAR_0 + rxCnt);
            Debug.Print("Got data: ");
            for (int i = 0; i < numBytes; i++) {
                Debug.Print(m_recvBuffer[i].ToString());
            }
            //serialPort.Write(m_recvBuffer, 0, numBytes);
            //serialPort.Flush();
        }

        public static void Main() {
            Debug.Print("Starting COM2 test\r\n");
            lcd.Initialize();
            lcd.Write(LCD.CHAR_0, LCD.CHAR_0, LCD.CHAR_0, LCD.CHAR_0);

            //SerialPort serialPort = new SerialPort("COM2");
            serialPort.BaudRate = 115200;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.DataBits = 8;
            serialPort.Handshake = Handshake.None;

            serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortHandler);

            serialPort.Open();

            byte[] msgBuff = Encoding.UTF8.GetBytes("xyz");
            /*Thread.Sleep(20000);
            Debug.Print("result = PASS\r\n");
            Debug.Print("accuracy = 1.2\r\n");
            Debug.Print("resultParameter1 = p1 return\r\n");
            Debug.Print("resultParameter2 = p2 return\r\n");
            Debug.Print("resultParameter3 = p3 return\r\n");
            Debug.Print("resultParameter4 = p4 return\r\n");
            Debug.Print("resultParameter5 = p5 return\r\n"); 
            */
            while (true) {
                System.Threading.Thread.Sleep(1000);
                serialPort.Write(msgBuff, 0, msgBuff.Length);
                txCnt = (txCnt + 1) % 10;
                lcd.Write(LCD.CHAR_0 + txCnt, LCD.CHAR_0, LCD.CHAR_0, LCD.CHAR_0 + rxCnt);
            }
        }


    }
}