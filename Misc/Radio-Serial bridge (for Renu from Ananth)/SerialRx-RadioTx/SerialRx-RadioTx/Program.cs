using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;
using System.IO.Ports;
using System.IO;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.Net;
using Samraksh.eMote.DotNow;

namespace Samraksh.eMote.Net.Mac.Ping {

    static class Globals {
        public static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();
    }
    public class DummyMsg {
        public byte[] data = new byte[10];
        public DummyMsg() {
            data[0] = 1; data[2] = 2; data[4] = 4; data[6] = 6; data[8] = 8;
        }
    }


    public class PingMsg {
        public bool Response;
        public ushort MsgID;
        public UInt16 Src;
        public UInt16 dummySrc;

        public PingMsg() {
        }

        public static int Size() {
            return 7;
        }

        public PingMsg(byte[] rcv_msg, ushort size) {
            Response = rcv_msg[0] == 0 ? false : true;
            MsgID = (UInt16)(rcv_msg[1] << 8);
            MsgID += (UInt16)rcv_msg[2];
            Src = (UInt16)(rcv_msg[3] << 8);
            Src += (UInt16)rcv_msg[4];
            dummySrc = (UInt16)(0xefef);
        }

        public byte[] ToBytes() {
            byte[] b_msg = new byte[7];
            b_msg[0] = Response ? (byte)1 : (byte)0;
            b_msg[1] = (byte)((MsgID >> 8) & 0xFF);
            b_msg[2] = (byte)(MsgID & 0xFF);
            b_msg[3] = (byte)((Src >> 8) & 0xFF);
            b_msg[4] = (byte)(Src & 0xFF);
            b_msg[5] = (byte)(0xef);
            b_msg[6] = (byte)(0xef);
            return b_msg;
        }
    }

    public class Program {
        const int firstPos = 20;
        const int testCount = 150;
        UInt16 myAddress;
        UInt16 mySeqNo = 1;
        UInt16 receivePackets = 0;
        UInt16 lastRxSeqNo = 0;
        ushort[] rxBuffer = new ushort[testCount];
        Timer sendTimer;
        //EmoteLCD lcd;
        PingMsg sendMsg = new PingMsg();

        static Mac.CSMA myCSMA;
        ReceiveCallBack myReceiveCB;
        NeighbourhoodChangeCallBack myNeighborCB;
        Mac.MacConfiguration macConfig = new MacConfiguration();

        public static OutputPort csmaPing = new OutputPort((Cpu.Pin)24, true);
        //public static OutputPort csmaPong = new OutputPort((Cpu.Pin)25, true);
        //public static OutputPort csmaReceive = new OutputPort((Cpu.Pin)29, true);
        public static OutputPort csmaReceiveResponse = new OutputPort((Cpu.Pin)30, true);

        public void Initialize() {
            Debug.Print("Initializing:  EmotePingwLCD");
            Thread.Sleep(1000);
            //lcd = new EmoteLCD();
            //lcd.Initialize();
            Globals.Lcd.Display("INI7");
            //lcd.Write(LCD.CHAR_I, LCD.CHAR_N, LCD.CHAR_I, LCD.CHAR_7);

            macConfig.NeighbourLivelinesDelay = 180;
            macConfig.CCASenseTime = 140; //Carries sensing time in micro seconds

            Debug.Print("Configuring:  CSMA...");
            try {
                myReceiveCB = Receive;
                myNeighborCB = NeighborChange;
                CSMA.Configure(macConfig, myReceiveCB, myNeighborCB);
                myCSMA = CSMA.Instance;
            }
            catch (Exception e) {
                Debug.Print(e.ToString());
            }

            Debug.Print("CSMA Init done.");
            myAddress = myCSMA.GetAddress();
            Debug.Print("My default address is :  " + myAddress.ToString());

            /*myCSMA.SetAddress(52);
            myAddress = myCSMA.GetAddress();
            Debug.Print("My New address is :  " + myAddress.ToString());
             */
        }

        void NeighborChange(UInt16 noOfNeigbors) {
        }

        void Receive(UInt16 noOfPackets) {
        }

        public void Start() {
            Debug.Print("Starting timer...");
            sendTimer = new Timer(new TimerCallback(sendTimerCallback), null, 0, 400);
            Debug.Print("Timer init done.");
        }

        void sendTimerCallback(Object o) {
            //Send_Ping(sendMsg);
        }

        // Added by Bill
        public void Send_Ping(byte[] msg, int numBytes) {
            try {
                csmaPing.Write(true); //J12-pin1
                csmaPing.Write(false);

                myCSMA.Send((UInt16)Addresses.BROADCAST, msg, 0, (ushort)numBytes);

                csmaPing.Write(true); //J12-pin1
                csmaPing.Write(false);
            }
            catch (Exception ex) {
                Globals.Lcd.Display("C ex");
            }
        }

        public void Send_Ping(PingMsg ping) {
            try {
                csmaPing.Write(true);           //J12-pin1
                csmaPing.Write(false);
                ping.Response = false;
                ping.MsgID = mySeqNo++;
                ping.Src = myAddress;

                csmaPing.Write(true);
                csmaPing.Write(false);
                byte[] msg = ping.ToBytes();
                myCSMA.Send((UInt16)Mac.Addresses.BROADCAST, msg, 0, (ushort)msg.Length);
                //int char0 = (mySeqNo % 10) + (int)LCD.CHAR_0;
                //lcd.Write(LCD.CHAR_S, LCD.CHAR_S, LCD.CHAR_S, (LCD)char0);
                csmaPing.Write(true);
                csmaPing.Write(false);
            }
            catch (Exception e) {
                Debug.Print("Send_Ping:" + e.ToString());
            }
        }

        public static void Main() {
            SerialComm sComm = new SerialComm();
            Thread.Sleep(Timeout.Infinite);
        }
    }

    public class SerialComm {
        Program p;
        public static OutputPort csmaPong = new OutputPort((Cpu.Pin)25, true);
        public static OutputPort csmaReceive = new OutputPort((Cpu.Pin)29, true);

        public SerialComm() {
            p = new Program();
            p.Initialize();
            p.Start();

            SerialPort serialPort = new SerialPort("COM2");
            serialPort.BaudRate = 115200;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.DataBits = 8;
            serialPort.Handshake = Handshake.None;

            serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortHandler);

            serialPort.Open();

            /*while (true)
            {
                csmaPong.Write(true);       //J12-pin2
                csmaPong.Write(false);

                serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortHandler);
                //serialPort.Open();
                Thread.Sleep(1000);

                csmaPong.Write(true);
                csmaPong.Write(false);
            }*/
        }

        public void SerialPortHandler(object sender, SerialDataReceivedEventArgs e) {
            csmaReceive.Write(true);        //J12-pin3
            csmaReceive.Write(false);

            byte[] m_recvBuffer = new byte[100];
            SerialPort serialPort = (SerialPort)sender;
            int numBytes = serialPort.BytesToRead;
            csmaReceive.Write(true);
            csmaReceive.Write(false);
            serialPort.Read(m_recvBuffer, 0, numBytes);
            serialPort.Flush();

            var payLoad = BitConverter.ToInt32(m_recvBuffer, 0);
            Globals.Lcd.Display(payLoad % 10000);

            //PingMsg rcvMsg = new PingMsg(m_recvBuffer, (ushort)m_recvBuffer.Length); // Removed by Bill

            csmaReceive.Write(true);
            csmaReceive.Write(false);
            //if(rcvMsg.MsgID != 0)
            //p.Send_Ping(rcvMsg);  // Removed by Bill
            p.Send_Ping(m_recvBuffer, numBytes);  // Added by Bill
        }
    }
}

