using System;
using System.Text;
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


		public static readonly OutputPort J12Pin1 = new OutputPort(Pins.GPIO_J12_PIN1, false);  // Alive
		public static readonly OutputPort J12Pin2 = new OutputPort(Pins.GPIO_J12_PIN2, false);  // Serial receive
		public static readonly OutputPort J12Pin3 = new OutputPort(Pins.GPIO_J12_PIN3, false);  // Radio send

	}


	public class DummyMsg {
		public byte[] Data = new byte[10];
		public DummyMsg() {
			Data[0] = 1; Data[2] = 2; Data[4] = 4; Data[6] = 6; Data[8] = 8;
		}
	}


	public class PingMsg {
		public bool Response;
		public ushort MsgId;
		public UInt16 Src;
		public UInt16 DummySrc;

		public PingMsg() {
		}

		public static int Size() {
			return 7;
		}

		public PingMsg(byte[] rcvMsg, ushort size) {
			Response = rcvMsg[0] == 0 ? false : true;
			MsgId = (UInt16)(rcvMsg[1] << 8);
			MsgId += (UInt16)rcvMsg[2];
			Src = (UInt16)(rcvMsg[3] << 8);
			Src += (UInt16)rcvMsg[4];
			DummySrc = (UInt16)(0xefef);
		}

		public byte[] ToBytes() {
			var bMsg = new byte[7];
			bMsg[0] = Response ? (byte)1 : (byte)0;
			bMsg[1] = (byte)((MsgId >> 8) & 0xFF);
			bMsg[2] = (byte)(MsgId & 0xFF);
			bMsg[3] = (byte)((Src >> 8) & 0xFF);
			bMsg[4] = (byte)(Src & 0xFF);
			bMsg[5] = (byte)(0xef);
			bMsg[6] = (byte)(0xef);
			return bMsg;
		}
	}

	public class Program {


		//const int firstPos = 20;
		//const int testCount = 150;
		UInt16 myAddress;
		UInt16 mySeqNo = 1;
		//UInt16 receivePackets = 0;
		//UInt16 lastRxSeqNo = 0;
		//ushort[] rxBuffer = new ushort[testCount];
		//Timer sendTimer;
		//EmoteLCD lcd;
		//PingMsg sendMsg = new PingMsg();

		static CSMA myCSMA;
		ReceiveCallBack myReceiveCB;
		NeighbourhoodChangeCallBack myNeighborCB;
		MacConfiguration macConfig = new MacConfiguration();

		//public static OutputPort csmaPing = new OutputPort((Cpu.Pin)24, true);
		//public static OutputPort csmaPong = new OutputPort((Cpu.Pin)25, true);
		//public static OutputPort csmaSend = new OutputPort((Cpu.Pin)29, true);
		//public static OutputPort csmaReceiveResponse = new OutputPort((Cpu.Pin)30, true);

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
			Debug.Print("My default address is :  " + myAddress);

			/*myCSMA.SetAddress(52);
			myAddress = myCSMA.GetAddress();
			Debug.Print("My New address is :  " + myAddress.ToString());
			 */

			// Start an I'm Alive timer that toggles every second
			var aliveTimer = new Timer(TimerTick, null, 0, 1000);

		}

		static void TimerTick(object obj) {
			Globals.J12Pin1.Write(true);
			Globals.J12Pin1.Write(false);
		}

		void NeighborChange(UInt16 noOfNeigbors) {
		}

		void Receive(UInt16 noOfPackets) {
		}

		public void Start() {
			Debug.Print("Starting timer...");
			//sendTimer = new Timer(new TimerCallback(sendTimerCallback), null, 0, 400);
			Debug.Print("Timer init done.");
		}

		//void sendTimerCallback(Object o) {
		//    //Send_Ping(sendMsg);
		//}

		// Added by Bill
		public void Send_Ping(byte[] msg, int numBytes) {
			try {
				//csmaPing.Write(true); //J12-pin1
				//csmaPing.Write(false);

				myCSMA.Send((UInt16)Addresses.BROADCAST, msg, 0, (ushort)numBytes);

				//csmaPing.Write(true); //J12-pin1
				//csmaPing.Write(false);
			}
			catch (Exception) {
				Globals.Lcd.Display("C ex");
			}
		}

		public void Send_Ping(PingMsg ping) {
			try {
				//csmaPing.Write(true);           //J12-pin1
				//csmaPing.Write(false);
				ping.Response = false;
				ping.MsgId = mySeqNo++;
				ping.Src = myAddress;

				//csmaPing.Write(true);
				//csmaPing.Write(false);
				var msg = ping.ToBytes();
				myCSMA.Send((UInt16)Addresses.BROADCAST, msg, 0, (ushort)msg.Length);
				//int char0 = (mySeqNo % 10) + (int)LCD.CHAR_0;
				//lcd.Write(LCD.CHAR_S, LCD.CHAR_S, LCD.CHAR_S, (LCD)char0);
				//csmaPing.Write(true);
				//csmaPing.Write(false);
			}
			catch (Exception e) {
				Debug.Print("Send_Ping:" + e);
			}
		}

		public static void Main() {
			//var sComm = new SerialComm();
			// ReSharper disable once ObjectCreationAsStatement
			new SerialComm();
			Thread.Sleep(Timeout.Infinite);
		}
	}

	public class SerialComm {
		Program p;
		//public static OutputPort csmaPong = new OutputPort((Cpu.Pin)25, true);
		//public static OutputPort csmaSend = new OutputPort((Cpu.Pin)29, true);

		public SerialComm() {
			p = new Program();
			p.Initialize();
			p.Start();

			var serialPort = new SerialPort("COM2") {
				BaudRate = 115200,
				Parity = Parity.None,
				StopBits = StopBits.One,
				DataBits = 8,
				Handshake = Handshake.None
			};

			serialPort.DataReceived += SerialPortHandler;

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

		readonly byte[] _rcvBuff = new byte[100];
		readonly StringBuilder _rcvStrBld = new StringBuilder();
		public void SerialPortHandler(object sender, SerialDataReceivedEventArgs e) {
			try {
				Globals.J12Pin2.Write(true);
				Globals.J12Pin2.Write(false);

				var serialPort = (SerialPort)sender;
				var numBytes = serialPort.BytesToRead;

				Globals.J12Pin2.Write(true);
				Globals.J12Pin2.Write(false);
				serialPort.Read(_rcvBuff, 0, numBytes);
				Debug.Print("0a " + numBytes);
				if (numBytes == 0) {
					return;
				}

				var diagInput = new StringBuilder("0b ");
				for (var i = 0; i < numBytes; i++) {
					diagInput.Append(_rcvBuff[i]);
					diagInput.Append(' ');
				}
				Debug.Print(diagInput.ToString());

				//serialPort.Flush();
				for (var rcvBuffPtr = 0; rcvBuffPtr < numBytes; rcvBuffPtr++) {

					// This shouldn't happen but if it does ...
					if (_rcvBuff[rcvBuffPtr] == 0) {
						continue;
					}

					//Debug.Print("1a " + rcvBuffPtr + " " + _rcvBuff[rcvBuffPtr]);
					char[] currChar;
					try {
						currChar = Encoding.UTF8.GetChars(_rcvBuff, rcvBuffPtr, 1);
					}
					catch {
						Debug.Print("## Invalid character received from serial port");
						continue;
					}

					//Debug.Print("1b " + currChar.Length);
					//Debug.Print("1c " + currChar[0]);

					if (currChar[0] == '\n') {

						//Debug.Print("2 " + rcvBuffPtr);

						var payLoadStr = _rcvStrBld.ToString();
						var payLoadBytes = Encoding.UTF8.GetBytes(payLoadStr);

						//Debug.Print("3 " + payLoadStr);

						try {
							Globals.Lcd.Display((Int32.Parse(payLoadStr) / 10) % 10000);
							p.Send_Ping(payLoadBytes, payLoadBytes.Length);
							Globals.J12Pin3.Write(true);
							Globals.J12Pin3.Write(false);
						}
						catch {
							Debug.Print("## Error converting payload to int");
							Globals.Lcd.Display("Err");
						}
						finally {
							Debug.Print("0c " + _rcvStrBld.Length + " <" + payLoadStr + ">");
							_rcvStrBld.Clear();
						}

						// Continue getting data from the serial receive buffer
						continue;
					}

					_rcvStrBld.Append(currChar);
				}
			}
			catch (Exception ex) {
				Debug.Print("Serial Receive Exception " + ex + ", _rcvStrBld length: " + _rcvStrBld.Length);
			}
		}
	}
}

