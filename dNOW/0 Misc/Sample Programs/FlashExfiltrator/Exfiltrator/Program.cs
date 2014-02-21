using System;
using Microsoft.SPOT;
using System.IO.Ports;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;

namespace Exfiltrator
{
    public class Program
    {
        public static bool sdSuccessFlag = false;

        public static void mySdCallback(Samraksh.SPOT.Hardware.DeviceStatus status)
        {
            Debug.Print("Recieved SD Callback\n");
            sdSuccessFlag = true;
        }

        public static void Main()
        {
            UInt16[] m_sendBuffer = new UInt16[256];
            byte[] m_serialBuffer = new byte[512];

            UInt16 counter = 0;
            UInt32 readBytes = 0;
            bool readDone = false;

            Debug.Print("Initializing Serial ....");
            SerialPort serialPort = new SerialPort("COM1");
            serialPort.BaudRate = 115200;
            serialPort.Parity = System.IO.Ports.Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.DataBits = 8;
            serialPort.Handshake = Handshake.None;

            //serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortHandler);
            //Debug.Print("Opening serial port ....");
            //serialPort.Open();

            Debug.Print("Initializing SD card ....");
            //Samraksh.SPOT.Hardware.EmoteDotNow.NOR.Initialize();
            Samraksh.SPOT.Hardware.EmoteDotNow.SD.SDCallBackType sdResultCallBack = mySdCallback;
            Samraksh.SPOT.Hardware.EmoteDotNow.SD mysd = new Samraksh.SPOT.Hardware.EmoteDotNow.SD(sdResultCallBack);
            Samraksh.SPOT.Hardware.EmoteDotNow.SD.Initialize();
            
            while (true)
            {
                Debug.Print("Reading from SD card \n");
                Samraksh.SPOT.Hardware.EmoteDotNow.SD.Read(m_serialBuffer, 0, 512);

                for (UInt16 i = 0; i < 64; i++)
                {
                    if ((m_serialBuffer[i] == 0x0c) && (m_serialBuffer[i + 1] == 0x0c) && (m_serialBuffer[i + 2] == 0x0c) && (m_serialBuffer[i + 3] == 0x0c))
                        readDone = true;
                }

                if (readDone == true)
                    break;

                serialPort.Write(m_serialBuffer, 0, 512);
                Debug.Print("Read : " + readBytes.ToString() + "\n");
                readBytes += 512;
                Thread.Sleep(200);
            }
            Debug.Print("Read is complete \n");
        }

        static void SerialPortHandler(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] m_recvBuffer = new byte[100];
            SerialPort serialPort = (SerialPort)sender;

            int numBytes = serialPort.BytesToRead;
            serialPort.Read(m_recvBuffer, 0, numBytes);
            serialPort.Write(m_recvBuffer, 0, numBytes);
            serialPort.Flush();
        }
    }
}
