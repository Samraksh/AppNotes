﻿/***************************************************
 * eMote .NOW Data Collector Exfiltrator
 *      Exfiltrate data from Data Collector Radar or Microphone to PC via serial port
 *      Reads collected data from SD card
 *  Versions
 *      1.1 Initial release (1.0 was a very early version and was not released)
 *      1.2 
 *          -   Fixed issue wrt reporting bytes received
 *          -   Added Testing symbol to print in human-readable form to debug log instead of binary
 *      1.3
 *			-	Upgraded to eMote v. 1.0.12
 *			-	Minor cleanup
 **************************************************/

//#define Testing   // Enable this flag to provide testing output rather than raw data to the serial port

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
        private const byte Eof = 0xF0;  // A ushort of F0F0 (2 bytes of EOF) is larger than a 12-bit sample (max 0FFF)

        // The blocksize used by the collector
        //  Used for giving spot-check info
        private const int BlockSizeBytes = 512;

        /// <summary>
        /// Count the number of bytes and buffers received and sent
        /// </summary>
        private static int _byteCntr;

        // Misc definitions
        private static readonly EnhancedEmoteLcd EnhancedLCD = new EnhancedEmoteLcd();

        /// <summary>
        /// The main program
        /// </summary>
        /// <exception cref="IOException"></exception>
        public static void Main() {
            Debug.EnableGCMessages(false);

	        EnhancedLCD.Write("Hola");
			Thread.Sleep(1000);

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
	            EnhancedLCD.Write("Init");

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
                EnhancedLCD.Write("conn");
                // Wait a few seconds
                Thread.Sleep(10000);
                // Show the user that we're exfiltrating
                EnhancedLCD.Write("ex");

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

                    // Check for 2 EOFs in a row in the buffer
                    for (var i = 0; i < serialBuffer.Length; i = i + 2) {
                        if (!(serialBuffer[i] == Eof && serialBuffer[i + 1] == Eof)) {
                            // Count the number of bytes
                            _byteCntr += 2;
                            // Loop again
                            continue;
                        }
                        // Signal that EOFs have been found
                        foundEof = true;
                        // Write the buffer
                        SerialWriteAndFlush(serialPort, serialBuffer);
                        // For good measure, write a buffer's worth of EOF
                        for (var j = 0; j < serialBuffer.Length; j++) {
                            serialBuffer[j] = Eof;
                        }
                        SerialWriteAndFlush(serialPort, serialBuffer);
                        break;
                    }

                    if (foundEof) {
                        break;
                    }

                    // Write the buffer
                    AlertSerialWrite(true);
                    SerialWriteAndFlush(serialPort, serialBuffer);
                    AlertSerialWrite(false);
                }

                //serialPort.Close();

                EnhancedLCD.Write("0000");
                finalMsg = "Done";
            }
            catch (Exception ex) {
                finalMsg = ex.Message;
                EnhancedLCD.Write("err");
            }
            finally {
                Debug.Print(finalMsg);
                Debug.Print(_byteCntr + " bytes, " + _byteCntr / 2 + " ushorts, " + (_byteCntr / (float)BlockSizeBytes).ToString("F") + " buffers");
                //Thread.Sleep(Timeout.Infinite);
            }
        }

        private static void SerialWriteAndFlush(SerialPort serialPort, byte[] serialBuffer) {
#if Testing
            Debug.Print("Buffer " + _bufferCntr);
                for (var i = 0; i < serialBuffer.Length; i += 2) {
                    var ushortVal = BitConverter.ToInt16(serialBuffer, i);
                    Debug.Print("  " + i + " " + ushortVal);
                }
                Debug.Print("");
            }
#else
            serialPort.Write(serialBuffer, 0, serialBuffer.Length);
            serialPort.Flush();
#endif
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