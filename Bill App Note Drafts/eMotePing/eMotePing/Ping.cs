using System;
using Microsoft.SPOT;
using System.Threading;

using Samraksh.SPOT.Net;
using Samraksh.SPOT.Net.Mac;
using Samraksh.SPOT.Hardware.EmoteDotNow;

namespace Samraksh.eMote.AppNote.eMotePing {


   /// <summary>
   /// Send ping messages to all other motes and listen for pong replies
   /// </summary>
   /// <remarks>
   /// The overall structure is as follows.
   /// 1. The radio is initialized and configured.
   /// 2. A timer periodically calls a method that broadcasts a ping.
   /// 3. Incoming ping or pong messages are caught and handled via an interrupt.
   /// </remarks>
    public class Ping {

        UInt16 myAddress;
        UInt16 mySeqNo = 0;
        Timer sendTimer;
        EmoteLCD lcd;
        PingMsg sendMsg = new PingMsg();
        CSMA myCSMA = new CSMA();
        MacConfiguration macConfig = new MacConfiguration();
        
        /// <summary>
        /// Entry point for the program
        /// </summary>
        /// <remarks>
        /// Initializes the hardware and start the periodic ping timer.
        /// </remarks>
        public static void Main() {
            Debug.Print("Starting eMotePing");
            Ping p = new Ping();
            p.Initialize();
            p.Start();
            Thread.Sleep(Timeout.Infinite);
        }
         
        // Commented code
        //Radio.Radio_802_15_4 my_15_4 = new Radio.Radio_802_15_4();
        //Radio.RadioConfiguration radioConfig = new Radio.RadioConfiguration();
        //int myRadioID;

        /// <summary>
        /// Initialize the hardware.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        ///     <item>Initialize the LCD display.</item>
        ///     <item>Initialize the MAC configuration.</item>
        /// </list>
        /// </remarks>
        void Initialize() {
            Debug.Print("Initializing:  EmotePing LCD");
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
            macConfig.CCA = true; // Check for clear channel
            macConfig.BufferSize = 8; // Number of packets buffered by MAC layer for send and receive (Send returns false when buffer full)
            macConfig.NumberOfRetries = 0; // In case of collision
            macConfig.RadioID = (byte)1; // Specifies 802.15.4 internal radio
            macConfig.CCASenseTime = 140; //Carrier sensing time in micro seconds

            Debug.Print("Initializing:  CSMA...");
            try {
                myCSMA.Initialize(macConfig, HandleMessage);
            }
            catch (Exception e) {
                Debug.Print(e.ToString());
            }
            Debug.Print("CSMA Init done.");
            myAddress = myCSMA.GetAddress();
            Debug.Print("My default address is :  " + myAddress.ToString());
        }

        /// <summary>
        /// Start the ping timer.
        /// </summary>
        /// <remarks>
        /// After this, program is event-driven. 
        /// <list type="bullet">
        ///     <item>When the timer fires, a ping is sent.</item>
        ///     <item>When a message is received, it is processed.</item>
        /// </list>
        /// </remarks>
        void Start() {
            Debug.Print("Starting timer...");
            sendTimer = new Timer(new TimerCallback(SendTimerCallback), null, 0, 2000);
            Debug.Print("Timer init done.");
        }

        /// <summary>
        /// Send a ping message.
        /// </summary>
        /// <param name="o"></param>
        /// <remarks>Called by timer.</remarks>
        void SendTimerCallback(Object o) {
            //mySeqNo++;
            Debug.Print("Sending broadcast ping msg:  " + mySeqNo.ToString());
            Send_Ping(sendMsg);
        }


        /// <summary>
        /// Process a received message.
        /// </summary>
        /// <param name="msg">The received message</param>
        /// <param name="size">The size of the message</param>
        /// <remarks>
        /// The received message can be either pong in response to earlier ping, or a ping from a neighbor.
        /// <list type="bullet">
        ///    <item>If it is a pong then AAAis shown on the LCD display.</item>
        ///    <item>If it is a ping, then a pong is sent and BBBB is shown on the LCD display.</item>
        /// </list>
        ///</remarks>
        void HandleMessage(byte[] msg, ushort size) {
            PingMsg rcvMsg = new PingMsg(msg, size);

            if (rcvMsg.Response) {
                // This is a pong response to myearlieer  message
                Debug.Print("Received response from: " + rcvMsg.Src);
                lcd.Write(LCD.CHAR_A, LCD.CHAR_A, LCD.CHAR_A, LCD.CHAR_A);
            }
            else {
                // This is a ping from a neighbor
                Debug.Print("Sending a Pong to SRC: " + rcvMsg.Src);
                lcd.Write(LCD.CHAR_B, LCD.CHAR_B, LCD.CHAR_B, LCD.CHAR_B);
                Send_Pong(rcvMsg);
            }
        }

        /// <summary>
        /// Sent a pong message in response to a received ping
        /// </summary>
        /// <param name="pingMsg">The received ping message</param>
        void Send_Pong(PingMsg pingMsg) {
            UInt16 sender = pingMsg.Src;
            pingMsg.Response = true;

            pingMsg.Src = myAddress;

            byte[] msg = pingMsg.ToBytes();
            myCSMA.Send(sender, msg, 0, (ushort)msg.Length);
        }

        /// <summary>
        /// Send a ping message
        /// </summary>
        /// <param name="pingMsg">The message to send</param>
        void Send_Ping(PingMsg pingMsg) {
            //UInt16 sender = ping.Src;
            pingMsg.Response = false;
            pingMsg.MsgID = mySeqNo++;
            pingMsg.Src = myAddress;

            byte[] msg = pingMsg.ToBytes();
            myCSMA.Send((UInt16)Addresses.BROADCAST, msg, 0, (ushort)msg.Length);
        }
        // *** total msg < 128 bytes; message header consumes 9 bytes
        // *** 3rd parameter of CSMA.Send is index to first desired byte in message. 4th parameter is number of bytes (< 128-9)

    }
}