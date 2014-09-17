using System;
using Microsoft.SPOT;
using Samraksh.SPOT.Net;
using Samraksh.SPOT.Net.Mac;
using Microsoft.SPOT.Hardware;
using System.Threading;

namespace Samraksh.SPOT.Tests {
    public class PingMsg {
        public bool Response;
        public ushort MsgID;
        public UInt16 Src;
        public uint EventTime;
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
            EventTime = (uint)(rcv_msg[5] << 8);
            EventTime += (uint)rcv_msg[6];

            dummySrc = (UInt16)(0xefef);

        }

        public byte[] ToBytes() {
            byte[] b_msg = new byte[9];
            /*b_msg[0] = Response ? (byte)1 : (byte)0;
            b_msg[1] = (byte)((MsgID >> 8) & 0xFF);
            b_msg[2] = (byte)(MsgID & 0xFF);
            b_msg[3] = (byte)((Src >> 8) & 0xFF);
            b_msg[4] = (byte)(Src & 0xFF);
            b_msg[5] = (byte)((EventTime >> 8) & 0xFF);
            b_msg[6] = (byte)(EventTime & 0xFF);
            b_msg[7] = (byte)(0xef);
            b_msg[8] = (byte)(0xef);*/

            b_msg[0] = 1;
            b_msg[1] = 0;
            b_msg[2] = 1;
            b_msg[3] = 0;
            b_msg[4] = 1;
            b_msg[5] = 0;
            b_msg[6] = 1;
            b_msg[7] = 0;
            b_msg[8] = 1;
            return b_msg;
        }
    }

    public class LongRadio {
        private Timer sendTimer;

        private CSMA myCSMA;

        private MacConfiguration macconfig;

        private ReceiveCallBack callback;

        private NeighbourhoodChangeCallBack myNeighborCB;

        private PingMsg sendMsg = new PingMsg();

        private UInt16 mySeqNo = 0;

        private Samraksh.SPOT.Hardware.EmoteDotNow.EmoteLCD lcd;


        private UInt16 myAddress;

        private void HandleMessage(UInt16 numberOfPackets) {
            lcd.Write(Samraksh.SPOT.Hardware.EmoteDotNow.LCD.CHAR_3, Samraksh.SPOT.Hardware.EmoteDotNow.LCD.CHAR_3,
                Samraksh.SPOT.Hardware.EmoteDotNow.LCD.CHAR_3, Samraksh.SPOT.Hardware.EmoteDotNow.LCD.CHAR_3);
            Debug.Print("Number Of Packets in Buffer : " + numberOfPackets.ToString() + "\n");

            UInt16 packetsToRead = numberOfPackets;

            while (true) {
                Message recvMessage = myCSMA.GetNextPacket();

                if (recvMessage == null) {
                    Debug.Print("No packets in buffer \n");
                    return;
                }

                byte[] packet = recvMessage.GetMessage();

                byte LQI = recvMessage.LQI;
                ushort src = recvMessage.Src;
                byte RSSI = recvMessage.RSSI;
                bool unicast = recvMessage.Unicast;

                UInt16 msgid = (UInt16)(packet[2] & 0xff);
                msgid |= (UInt16)((packet[1] << 8) & 0xff00);

                UInt16 source = (UInt16)(packet[4] & 0xff);
                source |= (UInt16)((packet[3] << 8) & 0xff00);

                //uint eventTime = (uint)(packet[6] & 0xff);
                //eventTime |= (uint)((packet[5] << 8) & 0xff00);

                ///long eventTime = recvMessage.senderEventTimeStamp;

                // bool eventStatus = recvMessage.IsSenderTimeStamped();

                // long sendTime = recvMessage.senderEventTimeStamp;

                //  Debug.Print( "Source address" + source.ToString() + "Recieved Message Msgid " + msgid.ToString() + " " + " LQI : " + LQI.ToString() + " SRC : " + src.ToString() + " RSSI : " + RSSI.ToString() + " UNICAST : " + unicast.ToString() + "\n");

                //packetsToRead--;

                // Debug.Print("Recieved Message Msgid " + msgid.ToString() + " " + " SRC : " + src.ToString() + " Event Time : " + eventTime.ToString() + "EventStatus" + eventStatus.ToString()+ "\n");

                Debug.Print("Recieved Message Msgid " + msgid.ToString() + " " + " SRC : " + src.ToString() + "\n");
                lcd.Write(Samraksh.SPOT.Hardware.EmoteDotNow.LCD.CHAR_R, Samraksh.SPOT.Hardware.EmoteDotNow.LCD.CHAR_R,
                    Samraksh.SPOT.Hardware.EmoteDotNow.LCD.CHAR_R, Samraksh.SPOT.Hardware.EmoteDotNow.LCD.CHAR_R);

                myCSMA.ReleasePacket();

            }

        }

        private void NeighborChange(UInt16 noOfNeigbors) {
        }

        public LongRadio() {
            try {

                macconfig = new MacConfiguration();

                macconfig.radioConfig.SetRadioName(Samraksh.SPOT.Net.Radio.RadioName.RF231RADIOLR);

                Debug.Print("After setting radio name");

                myNeighborCB = NeighborChange;


                callback = HandleMessage;

                lcd = new Samraksh.SPOT.Hardware.EmoteDotNow.EmoteLCD();

                lcd.Initialize();

                lcd.Clear();
                lcd.Write(Hardware.EmoteDotNow.LCD.CHAR_7, Hardware.EmoteDotNow.LCD.CHAR_7,
                    Hardware.EmoteDotNow.LCD.CHAR_7, Hardware.EmoteDotNow.LCD.CHAR_7);
                Thread.Sleep(4000);


                if (CSMA.Configure(macconfig, callback, myNeighborCB) != DeviceStatus.Success) {
                    lcd.Clear();
                    lcd.Write(Samraksh.SPOT.Hardware.EmoteDotNow.LCD.CHAR_1,
                        Samraksh.SPOT.Hardware.EmoteDotNow.LCD.CHAR_1, Samraksh.SPOT.Hardware.EmoteDotNow.LCD.CHAR_1,
                        Samraksh.SPOT.Hardware.EmoteDotNow.LCD.CHAR_1);
                    Debug.Print("The CSMA Configure call failed \n");
                    Thread.Sleep(Timeout.Infinite);
                }

                try {
                    myCSMA = CSMA.Instance;
                    lcd.Clear();
                    lcd.Write(Samraksh.SPOT.Hardware.EmoteDotNow.LCD.CHAR_2,
                        Samraksh.SPOT.Hardware.EmoteDotNow.LCD.CHAR_2, Samraksh.SPOT.Hardware.EmoteDotNow.LCD.CHAR_2,
                        Samraksh.SPOT.Hardware.EmoteDotNow.LCD.CHAR_2);
                }
                catch (MacNotConfiguredException ex) {
                    lcd.Clear();
                    lcd.Write(Samraksh.SPOT.Hardware.EmoteDotNow.LCD.CHAR_9,
                        Samraksh.SPOT.Hardware.EmoteDotNow.LCD.CHAR_9, Samraksh.SPOT.Hardware.EmoteDotNow.LCD.CHAR_9,
                        Samraksh.SPOT.Hardware.EmoteDotNow.LCD.CHAR_9);
                    Debug.Print("Exception in MasterBasicPing due to Mac not being configured\n" + ex);
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (Exception ex) {
                    lcd.Clear();
                    lcd.Write(Hardware.EmoteDotNow.LCD.CHAR_0, Hardware.EmoteDotNow.LCD.CHAR_0,
                        Hardware.EmoteDotNow.LCD.CHAR_0, Hardware.EmoteDotNow.LCD.CHAR_0);
                    Debug.Print("Unknown exception in MasterBasicPing\n" + ex);
                    Thread.Sleep(Timeout.Infinite);
                }

                Debug.Print("CSMA Init done. \n");

                lcd.Clear();
                lcd.Write(Hardware.EmoteDotNow.LCD.CHAR_8, Hardware.EmoteDotNow.LCD.CHAR_8,
                    Hardware.EmoteDotNow.LCD.CHAR_8, Hardware.EmoteDotNow.LCD.CHAR_8);


                myAddress = myCSMA.GetAddress();
            }
            catch {
                lcd.Clear();
                lcd.Write(Hardware.EmoteDotNow.LCD.CHAR_a, Hardware.EmoteDotNow.LCD.CHAR_a,
                    Hardware.EmoteDotNow.LCD.CHAR_a, Hardware.EmoteDotNow.LCD.CHAR_a);
                Thread.Sleep(Timeout.Infinite);

            }
        }

        public void Run() {
            try {
                lcd.Clear();
                lcd.Write(Hardware.EmoteDotNow.LCD.CHAR_4, Hardware.EmoteDotNow.LCD.CHAR_4,
                    Hardware.EmoteDotNow.LCD.CHAR_4,
                    Hardware.EmoteDotNow.LCD.CHAR_4);

                Debug.Print("Starting timer...\n");

                sendTimer = new Timer(Sender, null, 0, 1000);
                Debug.Print("Timer init done.");

                Thread.Sleep(Timeout.Infinite);
            }
            catch {
                lcd.Clear();
                lcd.Write(Hardware.EmoteDotNow.LCD.CHAR_c, Hardware.EmoteDotNow.LCD.CHAR_c,
                    Hardware.EmoteDotNow.LCD.CHAR_c,
                    Hardware.EmoteDotNow.LCD.CHAR_c);
                Thread.Sleep(Timeout.Infinite);
            }

        }


        void Send_Ping(PingMsg ping) {
            //UInt16 sender = ping.Src;
            //Debug.GC(true);
            lcd.Clear();
            lcd.Write(Hardware.EmoteDotNow.LCD.CHAR_5, Hardware.EmoteDotNow.LCD.CHAR_5, Hardware.EmoteDotNow.LCD.CHAR_5, Hardware.EmoteDotNow.LCD.CHAR_5);

            Debug.Print("Sending Broadcast message : " + mySeqNo.ToString() + " from " + myAddress.ToString());
            uint eventTime = (uint)DateTime.Now.Ticks;

            ping.Response = false;
            ping.MsgID = mySeqNo++;
            ping.Src = myAddress;
            // ping.EventTime = eventTime;

            byte[] msg = ping.ToBytes();
            // myCSMA.SendTimeStamped((UInt16)Addresses.BROADCAST, msg, 0, (ushort)msg.Length, (uint)eventTime);

            myCSMA.Send((UInt16)Addresses.BROADCAST, msg, 0, (ushort)msg.Length);

            //Debug.Print("EventTime :"+eventTime.ToString());
            Thread.Sleep(500);
            lcd.Write(Hardware.EmoteDotNow.LCD.CHAR_6, Hardware.EmoteDotNow.LCD.CHAR_6, Hardware.EmoteDotNow.LCD.CHAR_6, Hardware.EmoteDotNow.LCD.CHAR_6);

        }

        void Sender(Object state) {
            try {
                Send_Ping(sendMsg);
            }
            catch (Exception) {
                Debug.Print("Exception");
            }
            //return;

        }

        public static void Main() {
            Debug.EnableGCMessages(false);

            LongRadio lr = new LongRadio();

            lr.Run();

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
