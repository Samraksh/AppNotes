using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;
using System.IO.Ports;
using System.IO;
using Samraksh.eMote.Net;
using Samraksh.eMote.DotNow;

namespace Samraksh.eMote.Net.Mac.Ping
{
    public class DummyMsg
    {
        public byte[] data = new byte[10];
        public DummyMsg()
        {
            data[0] = 1; data[2] = 2; data[4] = 4; data[6] = 6; data[8] = 8;
        }
    }


    public class PingMsg
    {
        public bool Response;
        public ushort MsgID;
        public UInt16 Src;
        public UInt16 dummySrc;

        public PingMsg()
        {
        }
        public static int Size()
        {
            return 7;
        }
        public PingMsg(byte[] rcv_msg, ushort size)
        {
            Response = rcv_msg[0] == 0 ? false : true;
            MsgID = (UInt16)(rcv_msg[1] << 8);
            MsgID += (UInt16)rcv_msg[2];
            Src = (UInt16)(rcv_msg[3] << 8);
            Src += (UInt16)rcv_msg[4];
            dummySrc = (UInt16)(0xefef);

        }

        public byte[] ToBytes()
        {
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

    public class Program
    {
        const int firstPos = 20;
        const int testCount = 150;
        UInt16 myAddress;
        UInt16 mySeqNo = 1;
        UInt16 receivePackets = 0;
        UInt16 lastRxSeqNo = 0;
        ushort[] rxBuffer = new ushort[testCount];
        Timer sendTimer;
        EmoteLCD lcd;
        PingMsg sendMsg = new PingMsg();
        //DummyMsg myDummy = new DummyMsg();
        Random rand = new Random();
        //Radio.Radio_802_15_4 my_15_4 = new Radio.Radio_802_15_4();
        //Radio.RadioConfiguration radioConfig = new Radio.RadioConfiguration();
        //int myRadioID;

        static Mac.CSMA myCSMA;
        ReceiveCallBack myReceiveCB;
        NeighbourhoodChangeCallBack myNeighborCB;

        Mac.MacConfiguration macConfig = new MacConfiguration();

        public static OutputPort csmaPing = new OutputPort((Cpu.Pin)24, true);
        public static OutputPort csmaPong = new OutputPort((Cpu.Pin)25, true);
        public static OutputPort csmaReceive = new OutputPort((Cpu.Pin)29, true);
        public static OutputPort csmaReceiveResponse = new OutputPort((Cpu.Pin)30, true);

        public void Initialize()
        {
            Debug.Print("Initializing:  EmotePingwLCD");
            Thread.Sleep(1000);
            lcd = new EmoteLCD();
            lcd.Initialize();
            lcd.Write(LCD.CHAR_I, LCD.CHAR_N, LCD.CHAR_I, LCD.CHAR_7);

            macConfig.NeighbourLivelinesDelay = 180;
            macConfig.CCASenseTime = 140; //Carries sensing time in micro seconds

            Debug.Print("Configuring:  CSMA...");
            try
            {
                myReceiveCB = Receive;
                myNeighborCB = NeighborChange;
                CSMA.Configure(macConfig, myReceiveCB, myNeighborCB);
                myCSMA = CSMA.Instance;
            }
            catch (Exception e)
            {
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

#if TRUE
        public void Start()
        {
            Debug.Print("Starting timer...");
            sendTimer = new Timer(new TimerCallback(sendTimerCallback), null, 0, 400);
            Debug.Print("Timer init done.");
        }

        void sendTimerCallback(Object o)
        {
            // We receieved enough data....looking to see if we received all packets (even in best case scenario we could have a few errors)
            // we wait a bit longer just so the other side will also receive enough packets
            if (receivePackets >= (testCount + 20))
            {
                int i, j;
                bool found = false;
                int errors = 0;
                // searching for testCount-20 numbers starting with the first number we received
                ushort comparisonValue = rxBuffer[firstPos];
                for (i = firstPos; i < testCount - 20; i++)
                {
                    found = false;
                    for (j = firstPos; j < testCount; j++)
                    {
                        if (rxBuffer[j] == comparisonValue + 1)
                        {
                            found = true;
                        }
                    }
                    if (found != true)
                    {
                        Debug.Print("couldn't find " + (comparisonValue + 1).ToString() + " @ " + i.ToString() + " found " + rxBuffer[i].ToString());
                        errors++;
                    }
                    comparisonValue = rxBuffer[i];
                }
                if ((receivePackets % 5) == 0)
                {
                    if (errors < 6)
                    {
                        Debug.Print("result = PASS");
                        Debug.Print("accuracy = " + errors.ToString());
                        Debug.Print("resultParameter1 = " + rxBuffer[firstPos].ToString());
                        Debug.Print("resultParameter2 = " + rxBuffer[testCount - 1].ToString());
                        Debug.Print("resultParameter3 = " + receivePackets.ToString());
                        Debug.Print("resultParameter4 = null");
                        Debug.Print("resultParameter5 = null");
                    }
                    else
                    {
                        Debug.Print("result = FAIL");
                        Debug.Print("accuracy = " + errors.ToString());
                        Debug.Print("resultParameter1 = " + rxBuffer[firstPos].ToString());
                        Debug.Print("resultParameter2 = " + rxBuffer[testCount - 1].ToString());
                        Debug.Print("resultParameter3 = " + receivePackets.ToString());
                        Debug.Print("resultParameter4 = null");
                        Debug.Print("resultParameter5 = null");
                    }
                }
            }
            try
            {
                Send_Ping(sendMsg);
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
            }
        }
#endif

        void NeighborChange(UInt16 noOfNeigbors)
        {
        }

        void Receive(UInt16 noOfPackets)
        {
            if (myCSMA.GetPendingPacketCount() == 0)
            {
                Debug.Print("no packets");
                return;
            }

            //while (myCSMA.GetPendingPacketCount() > 0) {
            Message rcvMsg = myCSMA.GetNextPacket();
            if (rcvMsg == null)
            {
                Debug.Print("null");
                return;
            }

            byte[] rcvPayload = rcvMsg.GetMessage();
            HandleMessage(rcvPayload, (UInt16)rcvMsg.Size, rcvMsg.Src, rcvMsg.Unicast, rcvMsg.RSSI, rcvMsg.LQI);
            //}
            /*try{
            // Check if there's at least one packet
            if (myCSMA.GetPendingPacketCount() < 1) {
                Debug.Print("no packets");
                return;
            }
				
            Message rcvMsg = myCSMA.GetNextPacket();
            if (rcvMsg == null) {
                Debug.Print("null");
                return;
            }
			
            byte[] rcvPayload = rcvMsg.GetMessage();
            HandleMessage(rcvPayload, (UInt16)rcvMsg.Size, rcvMsg.Src, rcvMsg.Unicast, rcvMsg.RSSI, rcvMsg.LQI);
            }
             catch (Exception e)
            {
                Debug.Print("Receive:" + e.ToString());
            }*/
        }



        void HandleMessage(byte[] msg, UInt16 size, UInt16 src, bool unicast, byte rssi, byte lqi)
        {
            Debug.Print("MSG: " + msg[0].ToString() + " " + msg[1].ToString() + " " + msg[2].ToString() + " " + msg[3].ToString() + " " + msg[4].ToString() + " " + msg[5].ToString());
#if TRUE
            try
            {
                /*if (unicast)
                {
                    Debug.Print("Got a Unicast message from src: " + src.ToString() + ", size: " + size.ToString() + ", rssi: " + rssi.ToString() + ", lqi: " + lqi.ToString());
                }
                else
                {
                    Debug.Print("Got a broadcast message from src: " + src.ToString() + ", size: " + size.ToString() + ", rssi: " + rssi.ToString() + ", lqi: " + lqi.ToString());
                }*/
                if (size == PingMsg.Size())
                {

                    //Debug.Print("MSG: " + msg[0].ToString() + " " + msg[1].ToString() + " " + msg[2].ToString() + " " + msg[3].ToString() + " " + msg[4].ToString() + " " + msg[5].ToString());
                    PingMsg rcvMsg = new PingMsg(msg, size);

                    if (rcvMsg.Response)
                    {
                        csmaReceiveResponse.Write(true);
                        if (receivePackets < testCount)
                        {
                            //This is a response to my message						
                            rxBuffer[receivePackets] = rcvMsg.MsgID;
                        }
                        receivePackets++;
                        //Debug.Print("Received response from: " + rcvMsg.Src.ToString() + " for seq no: " + rcvMsg.MsgID.ToString());						
                        lcd.Write(LCD.CHAR_P, LCD.CHAR_P, LCD.CHAR_P, LCD.CHAR_P);
                        csmaReceiveResponse.Write(false);
                    }
                    else
                    {
                        csmaReceive.Write(true);
                        //if ( ((UInt16)rcvMsg.MsgID) != lastRxSeqNo + 1)
                        //	Debug.Print("***** Missing seq no: " + (lastRxSeqNo + 1).ToString() + " *****");
                        //Debug.Print("Sending a Pong to SRC: " + rcvMsg.Src.ToString() + " for seq no: " + rcvMsg.MsgID.ToString());
                        lastRxSeqNo = (UInt16)rcvMsg.MsgID;
                        lcd.Write(LCD.CHAR_R, LCD.CHAR_R, LCD.CHAR_R, LCD.CHAR_R);
                        csmaReceive.Write(false);
                        //Send_Pong(rcvMsg);
                    }
                    //Debug.GC(true);
                }
                else
                {
                    Debug.Print("not proper size with possible ID of: " + ((UInt16)(msg[1] << 8)).ToString());
                }
            }
            catch (Exception e)
            {
                Debug.Print("HandleMessage:" + e.ToString());
            }
#endif
        }

#if TRUE
        void Send_Pong(PingMsg ping)
        {
            try
            {
                csmaPong.Write(true);
                UInt16 sender = ping.Src;
                ping.Response = true;

                ping.Src = myAddress;

                byte[] msg = ping.ToBytes();
                myCSMA.Send(sender, msg, 0, (ushort)msg.Length);
                csmaPong.Write(false);
            }
            catch (Exception e)
            {
                Debug.Print("Send_Pong:" + e.ToString());
            }
        }

        public void Send_Ping(PingMsg ping)
        {
            try
            {
                csmaPing.Write(true);
                //UInt16 sender = ping.Src;
                //Debug.GC(true);
                ping.Response = false;
                ping.MsgID = mySeqNo++;
                ping.Src = myAddress;


                byte[] msg = ping.ToBytes();
                myCSMA.Send((UInt16)Mac.Addresses.BROADCAST, msg, 0, (ushort)msg.Length);
                int char0 = (mySeqNo % 10) + (int)LCD.CHAR_0;
                lcd.Write(LCD.CHAR_S, LCD.CHAR_S, LCD.CHAR_S, (LCD)char0);
                csmaPing.Write(false);
            }
            catch (Exception e)
            {
                Debug.Print("Send_Ping:" + e.ToString());
            }
        }
#endif

        public static void Main()
        {
            //SerialComm sComm = new SerialComm();
            Program p = new Program();
            p.Initialize();
            //p.Start();
            Thread.Sleep(Timeout.Infinite);
        }
    }

#if TRUE
    public class SerialComm
    {
        Program p;

        public SerialComm()
        {
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
        }

        public void SerialPortHandler(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] m_recvBuffer = new byte[10];
            SerialPort serialPort = (SerialPort)sender;
            int numBytes = serialPort.BytesToRead;
            serialPort.Read(m_recvBuffer, 0, numBytes);

            PingMsg rcvMsg = new PingMsg(m_recvBuffer, (ushort)m_recvBuffer.Length);
            //p.Send_Ping(rcvMsg);
            //m_recvBufferSend(m_recvBuffer);

            //Debug.Print("Data RX"+ m_recvBuffer[0].ToString());
        }
    }
#endif
}

