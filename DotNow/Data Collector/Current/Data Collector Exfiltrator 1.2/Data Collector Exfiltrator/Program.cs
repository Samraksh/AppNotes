/***************************************************
 * eMote .NOW Data Collector Exfiltrator
 *      Exfiltrate data from Data Collector Radar or Microphone to PC via serial port
 *      Reads collected data from SD card
 *  Versions
 *      1.1 Initial release (1.0 was a very early version and was not released)
 *      1.2 *** tbd
 **************************************************/

using System;
using System.IO;
using System.Reflection;
using Microsoft.SPOT;
using System.IO.Ports;
using System.Threading;

using Samraksh.eMote.DotNow;

using Samraksh.AppNote.Utility;

namespace Samraksh.AppNote.DataCollector.Exfiltrator {
    /// <summary>
    /// The main program
    /// </summary>
    public class Program {

        // End of file value
        //  This must be the same value across all Data Collector programs 
        private const byte Eof = 0xF0;  // A ushort of F0F0 (2 bytes of Eof) is larger than a 12-bit sample (max 0FFF)

        // The blocksize used by the collector
        //  Used for giving spot-check info
        private const int BlockSizeBytes = 512;

        // Misc definitions
        private static readonly EnhancedEmoteLcd EnhancedLCD = new EnhancedEmoteLcd();

        /// <summary>
        /// The main program
        /// </summary>
        /// <exception cref="IOException"></exception>
        public static void Main() {
            Debug.EnableGCMessages(false);

            Debug.Print("\nData Collector Exfiltrator");

            // Initialize VersionInfo for this assembly
            VersionInfo.Init(Assembly.GetExecutingAssembly());
            Debug.Print("Version " + VersionInfo.Version + ", build " + VersionInfo.BuildDateTime);
            Debug.Print("");

            // Set up the serial buffer
            var serialBuffer = new byte[BlockSizeBytes];

            // Initialize the final message
            var finalMsg = string.Empty;

            try {
                // ReSharper disable once ObjectCreationAsStatement
                new SD(status => { });  // Even though this seems to be a do-nothing method call, it's still necessary before initializing the SD card

                if (!SD.Initialize()) {
                    throw new IOException("SD Card Initialization failed");
                }

                // Set up the serial port
                var serialPort = new SerialPort("COM1") {
                    BaudRate = 115200,
                    Parity = Parity.None,
                    StopBits = StopBits.One,
                    DataBits = 8,
                    Handshake = Handshake.None
                };
                serialPort.Open();

                // Show user that now is the time to start the PC host program
                EnhancedLCD.Display("conn");
                // Wait a few seconds
                Thread.Sleep(10000);
                // Show the user that we're exfiltrating
                EnhancedLCD.Display("ex");

                // ReSharper disable once NotAccessedVariable
                var rdCnt = 0;

                // Set flag for EOF
                var foundEof = false;

                // Read from the SD card and write to the serial port till done
                while (true) {
                    // read a buffer's worth of data
                    if (!SD.Read(serialBuffer, 0, (ushort)serialBuffer.Length)) {
                        throw new IOException("SD read failed");
                    }

                    //Debug.Print("\n" + rdCnt + " first: " + BitConverter.ToInt16(serialBuffer, 0) + ", " +
                    //            BitConverter.ToInt16(serialBuffer, 2)
                    //            + " / last: " + BitConverter.ToInt16(serialBuffer, serialBuffer.Length - 4) + ", " +
                    //            BitConverter.ToInt16(serialBuffer, serialBuffer.Length - 2));

                    // Check for EOF
                    for (var i = 0; i < serialBuffer.Length - 4; i = i + 4) {
                        if (
                            !(serialBuffer[i] == Eof && serialBuffer[i + 1] == Eof && serialBuffer[i + 2] == Eof &&
                              serialBuffer[i + 3] == Eof)) {
                            continue;
                        }
                        foundEof = true;
                        // Write the buffer
                        serialPort.Write(serialBuffer, 0, serialBuffer.Length);
                        serialPort.Flush();
                        // For good measure, write a buffer's worth of EOF
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

                    // Write the buffer
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
    }
}
