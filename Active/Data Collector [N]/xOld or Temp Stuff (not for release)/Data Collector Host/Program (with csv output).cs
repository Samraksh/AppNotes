﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using Samraksh.AppNote.Utility;
using _DBG = Microsoft.SPOT.Debugger;
using _WP = Microsoft.SPOT.Debugger.WireProtocol;

namespace Samraksh.Library.DataCollector.Host {

    internal class Program {

        // Serial stream
        private static Stream _serialStream;
        private const int SerialBitRate = 115200;

        // The output file steams
        private static BinaryWriter _binaryFileStream;
        private static StreamWriter _csvFileStream;

        // Size of the data collect buffer
        //  Used to give data for spot check
        private const int DataCollectBufferSize = 256; // ushorts

        // End of file value
        //  This must be the same value across all Data Collector programs 
        private const byte Eof = 0xF0;  // A ushort of F0F0 (2 bytes of Eof) is larger than a 12-bit sample (max 0FFF)

        // A semaphore used to signal when the input is finished
        private static readonly AutoResetEvent EofFoundSemaphore = new AutoResetEvent(false);

        // Misc definitions
        private static int _fileSize;
        private const string Padding = "  : ";

        /// <summary>
        /// The main program
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args) {

            ConsoleDebugWriteLine("Data Collector Host");
            VersionInfo.Init(Assembly.GetExecutingAssembly());
            ConsoleDebugWriteLine("Version " + VersionInfo.Version + ", build timestamp " + VersionInfo.BuildDateTime);

            ConsoleDebugWriteLine("");

            ConsoleDebugWriteLine("This run: " + DateTime.Now);

            // The port for serial reading
            //  Note that this is a special kind of port since we'll be attaching to an MF device
            _DBG.PortDefinition portDef;

            // Get the com port
            while (true) {
                Console.WriteLine("\nEnter the COM port ");
                Console.Write(Padding);
                var portName = Console.ReadLine();
                portDef = _DBG.PortDefinition.CreateInstanceForSerial(portName, portName, SerialBitRate);
                if (portDef.TryToOpen()) {
                    break;
                }
                Console.WriteLine("Cannot open COM port. Enter again.");
            }

            // Get the output file name
            while (true) {
                Console.WriteLine("\nEnter the storage file name, without extension (.data will be appended) ");
                Console.Write(Padding);
                var outputFileName = Console.ReadLine();
                var binaryFileName = string.Empty;
                var csvFileName = string.Empty;
                try {
                    Debug.Assert(outputFileName != null, "outputFileName != null");
                    binaryFileName = outputFileName.Trim() + ".data";
                    _binaryFileStream = new BinaryWriter(File.Open(binaryFileName, FileMode.Create));
                }
                catch (Exception ex) {
                    Console.WriteLine("Cannot open \"" + binaryFileName + "\" for write\n" + ex.Message);
                    Console.WriteLine("Enter again.");
                    continue;
                }
                try {
                    Debug.Assert(outputFileName != null, "outputFileName != null");
                    csvFileName = outputFileName.Trim() + ".csv";
                    _csvFileStream = new StreamWriter(File.Open(csvFileName, FileMode.Create));
                }
                catch (Exception ex) {
                    Console.WriteLine("Cannot open \"" + csvFileName + "\" for write\n" + ex.Message);
                    Console.WriteLine("Enter again.");
                    continue;
                }
                break;
            }

            Console.WriteLine("\nPress Enter when ready to start receiving");
            Console.ReadLine();
            Console.WriteLine("Waiting for data from mote");

            // Have to wait till this point to open the serial stream
            //  Otherwise mote boot-up messages can come thru
            _serialStream = portDef.Open();

            // Kick off the serial read
            SerialRead();

            // Wait until we're signaled that the input is finished
            EofFoundSemaphore.WaitOne();
            ConsoleDebugWriteLine("");

            // Close the serial stream
            //  Doing it in a thread to avoid hanging. This reflects a long-standing issue in .NET's implementation of serial.
            (new Thread(() => _serialStream.Close())).Start();
            // Close the file stream
            _binaryFileStream.Close();
            _csvFileStream.Close();

            // Report on the results
            var fileSizeUshorts = _fileSize / sizeof(ushort);
            ConsoleDebugWriteLine("\nRead " + _fileSize + " bytes (" + fileSizeUshorts + " ushort samples), " + fileSizeUshorts / DataCollectBufferSize + " buffers");

            Console.WriteLine("\nFinished. Press enter to quit");
            Console.ReadLine();
        }

        /// <summary>
        /// Write a message to the console and the debugger, with end of line
        /// </summary>
        /// <param name="msg"></param>
        private static void ConsoleDebugWriteLine(string msg) {
            Console.WriteLine(msg);
            Debug.WriteLine(msg);
        }

        /// <summary>
        /// Write a message to the console and the debugger; no end of line
        /// </summary>
        /// <param name="msg"></param>
        private static void ConsoleDebugWrite(string msg) {
            Console.Write(msg);
            Debug.Write(msg);
        }

        /// <summary>
        /// Safe serial read
        /// </summary>
        /// <remarks>
        /// See http://www.sparxeng.com/blog/software/must-use-net-system-io-ports-serialport
        /// Note that the code as given doesn't compile. A separate method such as the one below must be used.
        /// Also, it uses tail recursion which isn't fully supported in C#.
        /// Hence converted to a loop.
        /// </remarks>
        private static void SerialRead() {
            var serialBuffer = new byte[1024];
            // Read from serial until EOF is found
            while (true) {
                _serialStream.BeginRead(serialBuffer, 0, serialBuffer.Length, iar => {
                    try {
                        // Get the actual length
                        var actualLength = _serialStream.EndRead(iar);
                        // Create a buffer to receive the data
                        var rcvBuffer = new byte[actualLength];
                        // Copy to the buffer
                        Buffer.BlockCopy(serialBuffer, 0, rcvBuffer, 0, actualLength);
                        // Write the data to the output file
                        WriteFile(rcvBuffer, actualLength);
                    }
                    catch (IOException ex) {
                        ConsoleDebugWriteLine("Error reading from serial stream\n" + ex);
                    }
                }, null);
                // If no EOF, continue
                if (!_eofFound) {
                    continue;
                }
                // Else set the semaphore
                EofFoundSemaphore.Set();
                return;
            }
        }
        private static bool _eofFound;

        /// <summary>
        /// Write the data to the file
        /// </summary>
        /// <param name="buffer">The byte buffer to write</param>
        /// <param name="actualLength">The actual length of data</param>
        private static void WriteFile(byte[] buffer, int actualLength) {
            //ConsoleDebugWrite("\n # ");
            //for (var i = 0; i < actualLength; i++) {
            //    Debug.Write(buffer[i].ToString("X2") + " ");
            //}
            //ConsoleDebugWriteLine("\n");

            // If EOF, write buffer, set flag, and return
            for (var i = 0; i < actualLength - 1; i++) {
                if (buffer[i] != Eof || buffer[i + 1] != Eof) { continue; }
                // Set flag that input is finished
                _eofFound = true;
                // Write up to but not including the EOF
                if (i <= 1) { return; }
                _binaryFileStream.Write(buffer, 0, i - 1);
                CsvWrite(buffer, 0, i - 1);
                _fileSize += (i - 1);
                return;
            }

            // If no EOF (and if not disposed), write the buffer
            //  Closing the serial port can lead to this code after the streams have been closed
            //  If so, just return
            try {
                _binaryFileStream.Write(buffer, 0, actualLength);
                CsvWrite(buffer, 0, actualLength);
            }
            catch (ObjectDisposedException) {
                return;
            }
            _fileSize += actualLength;
            for (var i = 0; i < actualLength; i += 2) {
                string infoStr;
                if (_ushortCntr == -1) {
                    infoStr = "\nSampling Interval (millisec): " + BitConverter.ToUInt16(buffer, i);
                    ConsoleDebugWriteLine(infoStr);
                    _ushortCntr = 0;
                }
                var bufferOffset = _ushortCntr % DataCollectBufferSize;
                switch (bufferOffset) {
                    case 0:
                        infoStr = "\n* " + _bufferCntr + " first " + BitConverter.ToUInt16(buffer, i);
                        ConsoleDebugWrite(infoStr);
                        _bufferCntr++;
                        break;
                    case 1:
                        infoStr = ", " + BitConverter.ToUInt16(buffer, i);
                        ConsoleDebugWrite(infoStr);
                        break;
                    case DataCollectBufferSize - 2:
                        infoStr = " / last " + BitConverter.ToUInt16(buffer, i);
                        ConsoleDebugWrite(infoStr);
                        break;
                    case DataCollectBufferSize - 1:
                        infoStr = ", " + BitConverter.ToUInt16(buffer, i);
                        ConsoleDebugWrite(infoStr);
                        break;
                }
                _ushortCntr++;
            }
        }
        private static int _ushortCntr;
        private static int _bufferCntr;

        /// <summary>
        /// Write a buffer in CSV format
        /// </summary>
        /// <remarks>Assumes the size of the buffer is even</remarks>
        /// <param name="buffer"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        private static void CsvWrite(byte[] buffer, int start, int length) {
            for (var i = start; i < Math.Max(buffer.Length, length); i += 2) {
                var valueUshort = BitConverter.ToInt16(buffer, i);
                _csvFileStream.Write(valueUshort.ToString(CultureInfo.CurrentCulture));
                _csvFileStream.Write(i % 4 == 2 ? "\n" : ",");
            }
        }
    }

}