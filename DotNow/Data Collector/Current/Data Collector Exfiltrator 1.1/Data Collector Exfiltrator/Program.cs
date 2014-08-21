// note that after you see the EHFL on the lcd of emote, then click enter in the command window and input the port number and the filename 
// (there are 15 seconds between the EHFL showing on the lcd, and the starting of real exfiltration, and this 15 seconds can be used to type in the command window)


using System;
using System.IO;
using System.Reflection;
using Microsoft.SPOT;
using System.IO.Ports;
using System.Threading;

using Samraksh.eMote.DotNow;

using Samraksh.AppNote.Utility;

namespace Samraksh.Library.DataCollector.Exfiltrator {
    public class Program {

        //private const byte Eof = 0xC;
        private const byte Eof = 0xF0;
        private const int BlockSizeBytes = 512;

        private static readonly EnhancedEmoteLcd EnhancedLCD = new EnhancedEmoteLcd();

        public static void Main() {
            Debug.EnableGCMessages(false);

            Debug.Print("\nData Collector Exfiltrator");

            // Initialize VersionInfo for this assembly
            VersionInfo.Init(Assembly.GetExecutingAssembly());
            Debug.Print("Version " + VersionInfo.Version + ", build " + VersionInfo.BuildDateTime);
            Debug.Print("");

            var serialBuffer = new byte[BlockSizeBytes];
            var finalMsg = string.Empty;

            try {
                // ReSharper disable once ObjectCreationAsStatement
                new SD(status => { });

                if (!SD.Initialize()) {
                    throw new IOException("SD Card Initialization failed");
                }

                var serialPort = new SerialPort("COM1") {
                    BaudRate = 115200,
                    Parity = Parity.None,
                    StopBits = StopBits.One,
                    DataBits = 8,
                    Handshake = Handshake.None
                };
                serialPort.Open();

                EnhancedLCD.Display("conn");

                Thread.Sleep(10000);

                EnhancedLCD.Display("ex");

                // ReSharper disable once NotAccessedVariable
                var rdCnt = 0;
                while (true) {
                    if (!SD.Read(serialBuffer, 0, (ushort)serialBuffer.Length)) {
                        throw new IOException("SD read failed");
                    }

                    //Debug.Print("\n" + rdCnt + " first: " + BitConverter.ToInt16(serialBuffer, 0) + ", " +
                    //            BitConverter.ToInt16(serialBuffer, 2)
                    //            + " / last: " + BitConverter.ToInt16(serialBuffer, serialBuffer.Length - 4) + ", " +
                    //            BitConverter.ToInt16(serialBuffer, serialBuffer.Length - 2));

                    var foundEof = false;
                    for (var i = 0; i < serialBuffer.Length - 4; i = i + 4) {
                        if (
                            !(serialBuffer[i] == Eof && serialBuffer[i + 1] == Eof && serialBuffer[i + 2] == Eof &&
                              serialBuffer[i + 3] == Eof)) {
                            continue;
                        }
                        foundEof = true;
                        serialPort.Write(serialBuffer, 0, serialBuffer.Length);
                        serialPort.Flush();
                        for (var j = 0; j < serialBuffer.Length; j++) {
                            serialBuffer[j] = Eof;
                        }
                        serialPort.Write(serialBuffer, 0, serialBuffer.Length);
                        serialPort.Flush();
                        break;
                    }

                    if (foundEof) {
                        break;
                    }

                    AlertSerialWrite(true);
                    serialPort.Write(serialBuffer, 0, serialBuffer.Length);
                    serialPort.Flush();
                    AlertSerialWrite(false);


                    rdCnt++;
                }

                //serialPort.Close();

                EnhancedLCD.Display("0000");
                finalMsg = "Done";
            }
            catch (Exception ex) {
                finalMsg = ex.Message;
                EnhancedLCD.Display("err");
            }
            finally {
                Debug.Print(finalMsg);
                Thread.Sleep(Timeout.Infinite);
            }
        }

        /// <summary>
        /// Show buffer write status
        /// </summary>
        /// <param name="alert">True iff alert</param>
        private static void AlertSerialWrite(bool alert) {
            // Note that LCD char numbers are right to left; 0 is right-most
            EnhancedLCD.WriteN(1, (alert ? LCD.CHAR_1 : LCD.CHAR_NULL));
        }

        //static void SerialPortHandler(object sender, SerialDataReceivedEventArgs e) {
        //    byte[] m_recvBuffer = new byte[100];
        //    SerialPort serialPort = (SerialPort)sender;

        //    int numBytes = serialPort.BytesToRead;
        //    serialPort.Read(m_recvBuffer, 0, numBytes);
        //    serialPort.Write(m_recvBuffer, 0, numBytes);
        //    serialPort.Flush();

        //}
    }
}
