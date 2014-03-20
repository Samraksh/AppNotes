using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.SPOT.Debugger;


namespace Serial_On_Off_Switch_PC {

    public class SerialComm {

        Stream serialStream;                // The serial stream
        PortDefinition portDef = null;      // Serial port definition
        AsyncCallback serialCallback;       // Callback when serial data received
        byte[] inputBytes = new byte[1];    // Buffer for input received. Set to size 1 so that each character will be delivered when it arrives.
        public delegate void SerialCallback(string theInput);   // Signature for callback
        SerialCallback callBack;            // Callback so user code can process received data
        int count = 0;                      // Counter for serial comm

        /// <summary>
        /// Constructor
        /// </summary>
        public SerialComm(string portName, SerialCallback _callBack) {
            uint bitRate = 115200;
            portDef = PortDefinition.CreateInstanceForSerial(portName, portName, bitRate);
            callBack = _callBack;
        }

        /// <summary>
        /// Try to start the serial comm
        /// </summary>
        /// <returns>True iff start was successful</returns>
        public bool Start() {
            if (!portDef.TryToOpen()) {
                return false;
            }
            serialStream = portDef.Open();
            serialCallback = new AsyncCallback(ProcessData);
            serialStream.BeginRead(inputBytes, 0, inputBytes.Length, serialCallback, count);
            ++count;
            return true;
        }

        /// <summary>
        /// Send data to mote
        /// </summary>
        /// <param name="strToSend">String to send</param>
        public void Write(string strToSend) {
            byte[] bytesToSend = System.Text.Encoding.UTF8.GetBytes(strToSend); // Convert string to string using UTF8 encoding
            serialStream.Write(bytesToSend, 0, bytesToSend.Length);
            serialStream.Flush();   // Flush causes it to be sent now, not wait on buffering
        }

        /// <summary>
        /// Process serial data received
        /// </summary>
        /// <param name="result"></param>
        private void ProcessData(IAsyncResult result) {
            string inputString = System.Text.Encoding.UTF8.GetString(inputBytes);   // Decode the bytes as string, using UTF8 encoding
            callBack(inputString);  // Call user method to process the received data
            serialStream.BeginRead(inputBytes, 0, inputBytes.Length, serialCallback, count);    // Begin another read
            ++count;
        }

        /// <summary>
        /// Stop the serial comm
        /// </summary>
        public void Stop() {
            serialStream.Close();   // Close the stream
            serialStream.Dispose(); // Dispose of all resources
        }

    }
}
