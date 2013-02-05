using System;
using Microsoft.SPOT;
using System.Threading;

using Samraksh.SPOT.Net;
using Samraksh.SPOT.Net.Mac;
using Samraksh.SPOT.Hardware.EmoteDotNow;

namespace Samraksh.eMote.AppNote.eMotePing {

    /// <summary>
    /// Defines the message used when sending a ping
    /// </summary>
    public class PingMsg {
        /// <summary>
        /// True iff a message was received
        /// </summary>
        public bool Response;
        
        /// <summary>
        /// 16 bit message id
        /// </summary>
        public UInt16 MsgID;

        /// <summary>
        /// 16 bit sender id
        /// </summary>
        public UInt16 Src;

        /// <summary>
        /// A dummy place holder to fill up the space
        /// </summary>
        public UInt16 dummySrc;

        /// <summary>
        /// Initialize a message for ping
        /// </summary>
        public PingMsg() { }

        /// <summary>
        /// Initialize a message for ping
        /// </summary>
        /// <param name="rcv_msg">A 2-byte array containing the message</param>
        /// <param name="size">Unused; provide any unsigned 16 bit integer</param>
        public PingMsg(byte[] rcv_msg, UInt16 size) {
            Response = rcv_msg[0] == 0 ? false : true;
            MsgID = (UInt16)(rcv_msg[1] << 8);
            MsgID += (UInt16)rcv_msg[2];
            Src = (UInt16)(rcv_msg[3] << 8);
            Src += (UInt16)rcv_msg[4];
            dummySrc = (UInt16)(0xefef);
        }

        /// <summary>
        /// Convert PingMsg class members to a 7-byte array
        /// </summary>
        /// <returns>7-byte array containing the class members</returns>
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

   /// <summary>
   /// Send ping messages to all other motes and listen for pong replies
   /// </summary>
    public class Ping {
        UInt16 myAddress;
        UInt16 mySeqNo = 0;
        Timer sendTimer;
        EmoteLCD lcd;
        PingMsg sendMsg = new PingMsg();

        // Commented code
        //Radio.Radio_802_15_4 my_15_4 = new Radio.Radio_802_15_4();
        //Radio.RadioConfiguration radioConfig = new Radio.RadioConfiguration();
        //int myRadioID;

        CSMA myCSMA = new CSMA();
        MacConfiguration macConfig = new MacConfiguration();
        ReceiveCallBack myReceive;

        /// <summary>
        /// Initialize the hardware
        /// </summary>
        void Initialize() {

            Debug.Print("Initializing:  EmotePingwLCD");
            Thread.Sleep(1000);

            // Initialize the LCD and display "INI7"
            lcd = new EmoteLCD();
            lcd.Initialize();
            lcd.Write(LCD.CHAR_I, LCD.CHAR_N, LCD.CHAR_I, LCD.CHAR_7);

#region Commented code ...
            //Debug.Print("Initializing:  Radio");
            //try
            //{
            //    my_15_4.Initialize(radioConfig, null);
            //}
            //catch (Exception e)
            //{
            //    Debug.Print(e.ToString());
            //}
            //
            //Debug.Print("Radio init done.");
            //
            //myRadioID = my_15_4.GetID();
            // *
            //Debug.Print("My radio ID is : " + myRadioID);
#endregion

            // Initialize the MAC configuration
            macConfig.CCA = true;
            macConfig.BufferSize = 8;
            macConfig.NumberOfRetries = 0;
            //macConfig.RadioID = (byte) myRadioID;
            macConfig.RadioID = (byte)1;
            macConfig.CCASenseTime = 140; //Carries sensing time in micro seconds

            myReceive = HandleMessage; //Assign the delegate to a function

            Debug.Print("Initializing:  CSMA...");
            try {
                myCSMA.Initialize(macConfig, myReceive);
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

        void Start() {
            Debug.Print("Starting timer...");
            sendTimer = new Timer(new TimerCallback(sendTimerCallback), null, 0, 2000);
            Debug.Print("Timer init done.");
        }

        void sendTimerCallback(Object o) {
            //mySeqNo++;
            Debug.Print("Sending broadcast ping msg:  " + mySeqNo.ToString());
            Send_Ping(sendMsg);
        }

        void HandleMessage(byte[] msg, ushort size) {
            PingMsg rcvMsg = new PingMsg(msg, size);

            if (rcvMsg.Response) {
                //This is a response to my message
                Debug.Print("Received response from: " + rcvMsg.Src);
                lcd.Write(LCD.CHAR_A, LCD.CHAR_A, LCD.CHAR_A, LCD.CHAR_A);
            }
            else {
                Debug.Print("Sending a Pong to SRC: " + rcvMsg.Src);
                lcd.Write(LCD.CHAR_B, LCD.CHAR_B, LCD.CHAR_B, LCD.CHAR_B);
                Send_Pong(rcvMsg);
            }
        }

        void Send_Pong(PingMsg ping) {
            UInt16 sender = ping.Src;
            ping.Response = true;

            ping.Src = myAddress;

            byte[] msg = ping.ToBytes();
            myCSMA.Send(sender, msg, 0, (ushort)msg.Length);
        }

        /// <summary>
        /// Sent a ping message
        /// </summary>
        /// <param name="ping">The message to send</param>
        void Send_Ping(PingMsg ping) {
            //UInt16 sender = ping.Src;
            ping.Response = false;
            ping.MsgID = mySeqNo++;
            ping.Src = myAddress;

            byte[] msg = ping.ToBytes();
            myCSMA.Send((UInt16)Addresses.BROADCAST, msg, 0, (ushort)msg.Length);
        }

        /// <summary>
        /// Entry point for the program
        /// </summary>
        /// <remarks>
        /// Initializes the hardware and then starts the main part of the program
        /// </remarks>
        public static void Main() {
            Debug.Print("Changing app");
            Ping p = new Ping();
            p.Initialize();
            p.Start();
            Thread.Sleep(Timeout.Infinite);
        }
    }
}