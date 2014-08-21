using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using Samraksh.AppNote.Utility;
using _DBG = Microsoft.SPOT.Debugger;
using _WP = Microsoft.SPOT.Debugger.WireProtocol;

namespace Samraksh.Library.DataCollector.Host {

    internal class Program {

        private static Stream _serialStream;
        private const int SerialBitRate = 115200;
        private const int DataCollectBufferSize = 256; // ushorts
        //private const byte Eof = 0xC;
        private const byte Eof = 0xF0;

        private static int _fileSize;

        private static readonly AutoResetEvent InputFinishedSemaphore = new AutoResetEvent(false);

        private static BinaryWriter _outputFile;

        private const string Padding = "  : ";

        private static void Main(string[] args) {

            ConsoleDebugWriteLine("Data Collector Host");
            VersionInfo.Init(Assembly.GetExecutingAssembly());
            ConsoleDebugWriteLine("Version "+VersionInfo.Version + ", build timestamp "+VersionInfo.BuildDateTime);

            ConsoleDebugWriteLine("");

            ConsoleDebugWriteLine("This run: "+DateTime.Now);

            _DBG.PortDefinition portDef;

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
            while (true) {
                Console.WriteLine("\nEnter the name of the storage file without extension (.data will be appended) ");
                Console.Write(Padding);
                var outputFileName = Console.ReadLine();
                try {
                    Debug.Assert(outputFileName != null, "outputFileName != null");
                    outputFileName = outputFileName.Trim() + ".data";
                    _outputFile = new BinaryWriter(File.Open(outputFileName, FileMode.Create));
                }
                catch (Exception ex) {
                    Console.WriteLine("Cannot open \"" + outputFileName + "\" for write\n" + ex.Message);
                    Console.WriteLine("Enter again.");
                }
                break;
            }

            Console.WriteLine("\nPress Enter when ready to start receiving");
            Console.ReadLine();
            Console.WriteLine("Waiting for data from mote");

            // Have to wait till this point to open the serial stream
            //  Otherwise debug messages will come thru
            _serialStream = portDef.Open();

            // Kick off the serial read
            SerialRead();

            InputFinishedSemaphore.WaitOne();
            ConsoleDebugWriteLine("");

            _serialStream.Close();
            _outputFile.Close();

            var fileSizeUshorts = _fileSize / sizeof(ushort);
            ConsoleDebugWriteLine("\nRead " + _fileSize + " bytes (" + fileSizeUshorts + " ushort samples), " + fileSizeUshorts / DataCollectBufferSize + " buffers");

            Console.WriteLine("\nFinished. Press enter to quit");
            Console.ReadLine();
        }

        private static void ConsoleDebugWriteLine(string msg) {
            Console.WriteLine(msg);
            Debug.WriteLine(msg);
        }

        private static void ConsoleDebugWrite(string msg) {
            Console.Write(msg);
            Debug.Write(msg);
        }

        /// <summary>
        /// Safe serial read
        /// </summary>
        /// <remarks>http://www.sparxeng.com/blog/software/must-use-net-system-io-ports-serialport</remarks>
        private static void SerialRead() {
            var serialBuffer = new byte[1024];
            _serialStream.BeginRead(serialBuffer, 0, serialBuffer.Length, iar => {
                try {
                    var actualLength = _serialStream.EndRead(iar);
                    var rcvBuffer = new byte[actualLength];
                    Buffer.BlockCopy(serialBuffer, 0, rcvBuffer, 0, actualLength);
                    WriteFile(rcvBuffer, actualLength);
                    if (_inputFinished) {
                        InputFinishedSemaphore.Set();
                        return;
                    }
                }
                catch (IOException ex) {
                    Debug.Print("Error reading from serial stream\n" + ex);
                    return;
                }
                SerialRead();
            }, null);
        }
        private static bool _inputFinished;


        private static void WriteFile(byte[] buffer, int actualLength) {

            Debug.Write("\n # ");
            for (var i = 0; i < actualLength; i++) {
                Debug.Write(buffer[i].ToString("X2") + " ");
            }
            Debug.WriteLine("\n");

            // Check for EOF
            for (var i = 0; i < actualLength - 1; i++) {
                if (buffer[i] != Eof || buffer[i + 1] != Eof) { continue; }
                // Set flag that input is finished
                _inputFinished = true;
                // Write up to but not including the EOF
                if (i <= 1) { return; }
                _outputFile.Write(buffer, 0, i - 1);
                _fileSize += (i - 1);
                return;
            }

            // If no EOF, write the buffer
            _outputFile.Write(buffer, 0, actualLength);
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
        //private static int _ushortCntr = -1;
        private static int _ushortCntr = 0;
        private static int _bufferCntr;

        //private static int BytesToInt(byte[] serialBuffer, int offset) {
        //    var retVal = (serialBuffer[offset + 1] << 8) + serialBuffer[offset];
        //    return retVal;
        //}

    }
}
