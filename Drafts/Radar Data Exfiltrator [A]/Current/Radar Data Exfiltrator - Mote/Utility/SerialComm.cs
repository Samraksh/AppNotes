/*=========================
 * Serial Comm Class
 *  Define serial comm with simplified interface
 * Versions
 *  1.0 Initial Version
 *  1.1 Fix naming, add message on write exception
=========================*/

using System;
using System.IO.Ports;
using Microsoft.SPOT;


namespace Samraksh.AppNote.Utility {

    /// <summary>
    /// Sends and receives from a serial port.
    /// </summary>
    public class SerialComm {

        /// <summary>Serial port name</summary>
        public SerialPort Port { get; private set; }
        /// <summary>Delegate for read callback</summary>
        /// <param name="readBytes">Bytes read</param>
        public delegate void ReadCallback(byte[] readBytes);

        private readonly ReadCallback _readCallback;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serialPortName">Serial port name (e.g., COM1)</param>
        /// <param name="readCallback">Callback method to process incoming data.</param>
        public SerialComm(string serialPortName, ReadCallback readCallback) {
            _readCallback = readCallback;
            // Set up the serial port
            Port = new SerialPort(serialPortName, 115200, Parity.None, 8, StopBits.One) { Handshake = Handshake.None };
            Port.DataReceived += PortHandler;
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
                var bytes = System.Text.Encoding.UTF8.GetBytes(str);
                Port.Write(bytes, 0, bytes.Length);
                Port.Flush();
                return true;
            }
            catch (Exception ex) {
                Debug.Print("SerialComm Write(String) exception " + ex);
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
            var numBytes = Port.BytesToRead;
            var recvBuffer = new byte[numBytes];
            Port.Read(recvBuffer, 0, numBytes);
            _readCallback(recvBuffer);
        }
    }
}
