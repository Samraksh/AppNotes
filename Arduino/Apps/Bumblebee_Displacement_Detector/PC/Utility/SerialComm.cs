using System;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq.Expressions;
using Globals;

namespace Samraksh.AppNote.Utility {

	public class SerialComm {

		//Stream _serialStream;                // The serial stream
		//readonly PortDefinition _portDef;      // Serial port definition
		//AsyncCallback _serialCallback;       // Callback when serial data received
		readonly byte[] _inputBytes = new byte[1000];    // Buffer for input received. 
		public delegate void SerialCallback(char[] theInput);   // Signature for callback
		readonly SerialCallback _callBack;            // Callback so user code can process received data
		//private string _portName;
		//private int _bitRate;
		private readonly SerialPort _serialPort;
		int _count;                      // Counter for serial comm

		/// <summary>
		/// Constructor
		/// </summary>
		public SerialComm(SerialCallback callBack, string portName, int bitRate = 115200) {
			//_portName = portName;
			//_bitRate = bitRate;
			_serialPort = new SerialPort(portName, bitRate);
			//_serialPort.DataReceived += ProcessData;
			//_portDef = PortDefinition.CreateInstanceForSerial(portName, portName, bitRate);
			_callBack = callBack;
		}

		/// <summary>
		/// Try to start the serial comm
		/// </summary>
		/// <returns>If successful, null; else the exception</returns>
		public Exception Start() {
			try {
				_serialPort.Open();
				_serialPort.BaseStream.BeginRead(_inputBytes, 0, _inputBytes.Length, ProcessData, _count);
				++_count;
				return null;
			}
			catch (Exception ex) {
				return ex;
			}
		}

		/// <summary>
		/// Stop the serial comm
		/// </summary>
		public void Stop() {
			if (!_serialPort.IsOpen) { return; }
			_serialPort.Close();   // Close the stream
			_serialPort.Dispose(); // Dispose of all resources
		}

		/// <summary>
		/// Send data to mote
		/// </summary>
		/// <param name="strToSend">String to send</param>
		public void Write(string strToSend) {
			var bytesToSend = System.Text.Encoding.UTF8.GetBytes(strToSend); // Convert string to string using UTF8 encoding
			_serialPort.Write(bytesToSend, 0, bytesToSend.Length);
			_serialPort.BaseStream.Flush();   // Flush causes it to be sent now, not wait on buffering
		}

		/// <summary>
		/// Process serial data received
		/// </summary>
		private void ProcessData(IAsyncResult iar) {
			if (!_serialPort.IsOpen || GlobalVals.FormIsClosing) {
				return;
			}
			var numBytesRead = _serialPort.BaseStream.EndRead(iar);
			Debug.Print("Serial chars read: {0}", numBytesRead);
			var inputChars = System.Text.Encoding.UTF8.GetChars(_inputBytes, 0, numBytesRead);   // Decode the bytes as string, using UTF8 encoding
			_callBack(inputChars);  // Call user method to process the received data
			try {	// Getting fatalexecutionerror
				_serialPort.BaseStream.BeginRead(_inputBytes, 0, _inputBytes.Length, ProcessData, _count); // Begin another read
				++_count;
			}
			catch (InvalidOperationException) { }
		}

	}
}
