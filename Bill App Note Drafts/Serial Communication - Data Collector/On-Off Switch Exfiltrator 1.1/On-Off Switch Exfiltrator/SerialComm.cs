using System;
using System.IO.Ports;

using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;



namespace SamrakshAppNoteUtility {

    /// <summary>
    /// Sends and receives from a serial port.
    /// </summary>
    public class SerialComm {

        public  SerialPort Port { get; private set; }
        public delegate void ReadCallback(byte[] readBytes);

        private ReadCallback readCallback;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_serialPortName">Serial port name (e.g., COM1)</param>
        /// <param name="_readCallback">Callback method to process incoming data.</param>
        public SerialComm(string _serialPortName, ReadCallback _readCallback) {

            readCallback = _readCallback;
            Port = new SerialPort(_serialPortName, 115200, Parity.None, 8, StopBits.One);
            Port.Handshake = Handshake.None;
            Port.DataReceived += new SerialDataReceivedEventHandler(PortHandler);
        }

        /// <summary>
        /// Open the port
        /// </summary>
        public void Open() {
                Port.Open();
        }

       /// <summary>
       /// Write a string to the port
       /// </summary>
       /// <param name="str">The string to write</param>
       /// <remarks>Flushes the port after writing the bytes to ensure it all gets sent.</remarks>
       /// <returns></returns>
        public bool Write(string str) {
            try {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
                Port.Write(bytes, 0, bytes.Length);
                Port.Flush();
                return true;
            }
            catch {
                return false;
            }
        }

        /// <summary>
        /// Handle a read event
        /// </summary>
        /// <remarks>Reads the incoming data and calls a user-provided method to process it.</remarks>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void PortHandler(object sender, SerialDataReceivedEventArgs e) {
            int numBytes = Port.BytesToRead;
            byte[] recvBuffer = new byte[numBytes];
            Port.Read(recvBuffer, 0, numBytes);
            readCallback(recvBuffer);
        }
    }
}
