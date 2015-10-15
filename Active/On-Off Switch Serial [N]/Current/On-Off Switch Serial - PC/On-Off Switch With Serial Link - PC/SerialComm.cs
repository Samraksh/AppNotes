using System;
using System.IO;
using Microsoft.SPOT.Debugger;


namespace Serial_On_Off_Switch_PC {

    public class SerialComm {

        Stream _serialStream;                // The serial stream
	    readonly PortDefinition _portDef;      // Serial port definition
        AsyncCallback _serialCallback;       // Callback when serial data received
	    readonly byte[] _inputBytes = new byte[1];    // Buffer for input received. Set to size 1 so that each character will be delivered when it arrives.
        public delegate void SerialCallback(string theInput);   // Signature for callback
	    readonly SerialCallback _callBack;            // Callback so user code can process received data
        int _count;                      // Counter for serial comm

        /// <summary>
        /// Constructor
        /// </summary>
        public SerialComm(string portName, SerialCallback callBack) {
            const uint bitRate = 115200;
            _portDef = PortDefinition.CreateInstanceForSerial(portName, portName, bitRate);
            _callBack = callBack;
        }

        /// <summary>
        /// Try to start the serial comm
        /// </summary>
        /// <returns>True iff start was successful</returns>
        public bool Start() {
            if (!_portDef.TryToOpen()) {
                return false;
            }
            _serialStream = _portDef.Open();
            _serialCallback = ProcessData;
            _serialStream.BeginRead(_inputBytes, 0, _inputBytes.Length, _serialCallback, _count);
            ++_count;
            return true;
        }

        /// <summary>
        /// Send data to mote
        /// </summary>
        /// <param name="strToSend">String to send</param>
        public void Write(string strToSend) {
            byte[] bytesToSend = System.Text.Encoding.UTF8.GetBytes(strToSend); // Convert string to string using UTF8 encoding
            _serialStream.Write(bytesToSend, 0, bytesToSend.Length);
            _serialStream.Flush();   // Flush causes it to be sent now, not wait on buffering
        }

        /// <summary>
        /// Process serial data received
        /// </summary>
        /// <param name="result"></param>
        private void ProcessData(IAsyncResult result) {
            string inputString = System.Text.Encoding.UTF8.GetString(_inputBytes);   // Decode the bytes as string, using UTF8 encoding
            _callBack(inputString);  // Call user method to process the received data
            _serialStream.BeginRead(_inputBytes, 0, _inputBytes.Length, _serialCallback, _count);    // Begin another read
            ++_count;
        }

        /// <summary>
        /// Stop the serial comm
        /// </summary>
        public void Stop() {
            _serialStream.Close();   // Close the stream
            _serialStream.Dispose(); // Dispose of all resources
        }

    }
}
