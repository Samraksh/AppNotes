using System;
using System.IO;
using System.IO.Ports;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;

using Samraksh.eMote.Net;
using Samraksh.eMote.Net.Mac;
using Samraksh.eMote.Net.Radio;
using Samraksh.eMote.DotNow;
using Samraksh.eMote.Net.Mac;

//1. This program initializes OMAC as the MAC protocol.
//  1a. Registers a function that tracks change in neighbor (NeighborChange) and a function to handle messages that are received.
//2. Pings are sent at pre-determined intervals.
//3. Pongs are sent back for received messages.
namespace Samraksh.eMote.Net.Mac.Send
{
    public class PingPayload
    {
        public UInt32 pingMsgId;
        public string pingMsgContent = "PING";

        public PingPayload()
        {

        }

        public byte[] ToBytes()
        {
            byte[] msg = new byte[4];
            msg[0] = (byte)((pingMsgId >> 24) & 0xFF);
            msg[1] = (byte)((pingMsgId >> 16) & 0xFF);
            msg[2] = (byte)((pingMsgId >> 8) & 0xFF);
            msg[3] = (byte)((pingMsgId) & 0xFF);

            //Convert string to byte array
            byte[] msgContent = System.Text.Encoding.UTF8.GetBytes(pingMsgContent);

            //Merge array containing msgID and array containing string into a single byte array for transmission
            byte[] merged = new byte[msg.Length + msgContent.Length];
            msg.CopyTo(merged, 0);
            msgContent.CopyTo(merged, msg.Length);

            return merged;
        }

        public PingPayload FromBytesToPingPayload(byte[] msg)
        {
            try
            {
                PingPayload pingPayload = new PingPayload();

                //Convert byte array to an integer
                pingPayload.pingMsgId = (UInt32)(msg[0] << 24);
                pingPayload.pingMsgId += (UInt32)(msg[1] << 16);
                pingPayload.pingMsgId += (UInt32)(msg[2] << 8);
                pingPayload.pingMsgId += (UInt32)(msg[3]);

                //Create a byte array to store the string
                byte[] msgContent = new byte[4];
                msgContent[0] = msg[4];
                msgContent[1] = msg[5];
                msgContent[2] = msg[6];
                msgContent[3] = msg[7];

                //Convert byte to char array
                char[] msgContentChar = System.Text.Encoding.UTF8.GetChars(msgContent);

                //Convert char array to string
                pingPayload.pingMsgContent = new string(msgContentChar);

                return pingPayload;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                return null;
            }
        }
    }

    public class Program
    {
        const UInt32 totalPingCount = 10001;
        const UInt16 MAX_NEIGHBORS = 12;
        const int initialDelayInMsecs = 30000;
        int dutyCyclePeriod = 20000;

        bool startSend = false;
        UInt16 myAddress;
        Timer sendTimer;
        NetOpStatus status;
        EmoteLCD lcd;
        static UInt32 sendMsgCounter = 1;
        
        PingPayload pingMsg = new PingPayload();

        OMAC myOMACObj;
        //ReceiveCallBack myReceiveCB;
        //NeighborhoodChangeCallBack myNeibhborhoodCB;
		
        MacConfiguration myMacConfig = new MacConfiguration();
        //Radio.RadioConfiguration myRadioConfig = new Radio.RadioConfiguration();

        private System.IO.Ports.SerialPort _serialPort;
        private readonly byte[] _byteBuffer = new byte[10];
        private static readonly AutoResetEvent GoSemaphore = new AutoResetEvent(false);

        public void Initialize()
        {
            //Init LCD
            lcd = new EmoteLCD();
            lcd.Initialize();
            lcd.Write(LCD.CHAR_I, LCD.CHAR_n, LCD.CHAR_i, LCD.CHAR_t);

            //Set OMAC parameters
            myMacConfig.MACRadioConfig.TxPower = TxPowerValue.Power_3dBm;
            myMacConfig.MACRadioConfig.Channel = Channel.Channel_26;
            myMacConfig.MACRadioConfig.RadioType = RadioType.RF231RADIO;
            myMacConfig.MACRadioConfig.OnReceiveCallback = Receive;
            myMacConfig.MACRadioConfig.OnNeighborChangeCallback = NeighborChange;

            //myMacConfig.MACRadioConfig = myRadioConfig;
            myMacConfig.NeighborLivenessDelay = 180;
            myMacConfig.CCASenseTime = 140; //Carries sensing time in micro seconds

            Debug.Print("Configuring OMAC...");

            try
            {
                //configure OMAC
                //myOMACObj = new OMAC(myMacConfig);
                myOMACObj = new OMAC(myMacConfig);
                
                //configure OMAC
                //myReceiveCB = Receive;
                //myNeibhborhoodCB = NeighborChange;
                //OMAC.Configure(myMacConfig, myReceiveCB, myNeibhborhoodCB);
                //myOMACObj = OMAC.Instance;
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
            }

            Debug.Print("OMAC init done");
            myAddress = myOMACObj.GetRadioAddress();
            Debug.Print("My address is: " + myAddress.ToString() + ". I am in Send mode");

            //SerialMethod();
        }

        public void SerialMethod()
        {
            _serialPort = new SerialPort("COM2")
            {
                BaudRate = 115200,
                Parity = System.IO.Ports.Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Handshake = Handshake.None,
            };
            _serialPort.DataReceived += DataReceived;
            _serialPort.Open();
        }

        /// <summary>
        /// Receive incoming bytes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            while (_serialPort.BytesToRead > 0)
            {
                var bytesRead = _serialPort.Read(_byteBuffer, 0, System.Math.Max(_serialPort.BytesToRead, _byteBuffer.Length));
                //Debug.Print("BytesToRead: " + _serialPort.BytesToRead + ", bytesRead: " + bytesRead);
                // _bytePacket.Add processes the incoming bytes and calls the user callback when a delimeter is found
                //_bytePacket.Add(_byteBuffer, bytesRead);
                if (string.Equals(_byteBuffer,"GO"))
                {
                    Debug.Print("Received GO");
                    GoSemaphore.Set();
                }
            }
        }

        //Keeps track of change in neighborhood
        public void NeighborChange(UInt16 countOfNeighbors)
        {
            Debug.Print("Count of neighbors " + countOfNeighbors.ToString());
        }

        //Starts a timer 
        public void Start()
        {
            Debug.Print("Waiting to start test");
            //GoSemaphore.WaitOne();
            //Debug.Print("GO...");
            Thread.Sleep(initialDelayInMsecs);
            Debug.Print("Starting timer...");
            TimerCallback timerCB = new TimerCallback(sendTimerCallback);
            sendTimer = new Timer(timerCB, null, 0, dutyCyclePeriod);
            Debug.Print("Timer initialization done");
        }

        //Calls ping at regular intervals
        void sendTimerCallback(Object obj)
        {
            SendPing();
        }

        public void SendPing()
        {
            try
            {
                bool sendFlag = false;
                //UInt16[] neighborList = myOMACObj.GetNeighborList();

                //for (int j = 0; j < MAX_NEIGHBORS; j++)
                //{
                    //if (neighborList[j] != 0)
                    //{
                        //Debug.Print("count of neighbors " + neighborList.Length);
                        startSend = true; sendFlag = true;
                        pingMsg.pingMsgId = sendMsgCounter;
                        byte[] msg = pingMsg.ToBytes();
                        //Debug.Print("Sending to neighbor " + neighborList[j] + " ping msgID " + sendMsgCounter);
                        //status = myOMACObj.Send(neighborList[j], msg, 0, (ushort)msg.Length);
                        Debug.Print("Sending to neighbor " + 6846 + " ping msgID " + sendMsgCounter + " msg length " + msg.Length);
                        status = myOMACObj.Send(6846, msg, 0, (ushort)msg.Length);
                        if (status != NetOpStatus.S_Success)
                        {
                            Debug.Print("Send to " + 6846 + " failed. Ping msgID " + sendMsgCounter.ToString());
                        }
                        /*Debug.Print("Sending to neighbor " + 26809 + " ping msgID " + sendMsgCounter + " msg length " + msg.Length);
                        status = myOMACObj.Send(26809, msg, 0, (ushort)msg.Length);
                        if (status != NetOpStatus.S_Success)
                        {
                            Debug.Print("Send to " + 26809 + " failed. Ping msgID " + sendMsgCounter.ToString());
                        }*/
                    //}
                //}
                if (sendFlag == false && startSend == true)
                {
                    Debug.Print("Ping failed. All neighbors dropped out");
                }
                //Increment msgCounter only if there is a send
                if (sendFlag == true)
                {
                    sendMsgCounter++;
                }

                if (sendMsgCounter < 10)
                {
                    lcd.Write(LCD.CHAR_S, LCD.CHAR_S, LCD.CHAR_S, (LCD)sendMsgCounter);
                }
                else if (sendMsgCounter < 100)
                {
                    UInt16 tenthPlace = (UInt16)(sendMsgCounter / 10);
                    UInt16 unitPlace = (UInt16)(sendMsgCounter % 10);
                    lcd.Write(LCD.CHAR_S, LCD.CHAR_S, (LCD)tenthPlace, (LCD)unitPlace);
                }
                else if (sendMsgCounter < 1000)
                {
                    UInt16 hundredthPlace = (UInt16)(sendMsgCounter / 100);
                    UInt16 remainder = (UInt16)(sendMsgCounter % 100);
                    UInt16 tenthPlace = (UInt16)(remainder / 10);
                    UInt16 unitPlace = (UInt16)(remainder % 10);
                    lcd.Write(LCD.CHAR_S, (LCD)hundredthPlace, (LCD)tenthPlace, (LCD)unitPlace);
                }
                else if (sendMsgCounter < 10000)
                {
                    UInt16 thousandthPlace = (UInt16)(sendMsgCounter / 1000);
                    UInt16 remainder = (UInt16)(sendMsgCounter % 1000);
                    UInt16 hundredthPlace = (UInt16)(remainder / 100);
                    remainder = (UInt16)(remainder % 100);
                    UInt16 tenthPlace = (UInt16)(remainder / 10);
                    UInt16 unitPlace = (UInt16)(remainder % 10);
                    lcd.Write((LCD)thousandthPlace, (LCD)hundredthPlace, (LCD)tenthPlace, (LCD)unitPlace);
                }

                if (sendMsgCounter == totalPingCount)
                {
                    sendMsgCounter--;
                    ShowStatistics();
                }
            }
            catch (Exception ex)
            {
                Debug.Print("SendPing: " + ex.ToString());
            }
        }

        //Handles received messages 
        public void Receive(UInt16 countOfPackets)
        {
            
        }

        //Show statistics
        void ShowStatistics()
        {
            Debug.Print("==============STATS================");
            Debug.Print("total msgs sent " + sendMsgCounter);
            Debug.Print("==================================");
            Thread.Sleep(Timeout.Infinite);
        }

        public static void Main()
        {
            Program p = new Program();
            p.Initialize();
            p.Start();
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
