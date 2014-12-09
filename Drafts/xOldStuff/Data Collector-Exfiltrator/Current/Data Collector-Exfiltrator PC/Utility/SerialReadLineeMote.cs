using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.SPOT.Debugger;

namespace Utility {
    /// <summary>
    /// Reads serial ASCUII input from eMote, one line at a time 
    /// </summary>
    public class SerialReadLineeMote {
        private PortDefinition _port;
        private Stream _serialStream;
        private StreamReader _serialStreamReader;
        private CancellationTokenSource _cancelToken = new CancellationTokenSource();
        private Task _readLines;

        public delegate void SerialCallback(string theInput);   // Signature for callback
        private SerialCallback _callBack;            // Callback so user code can process received

        /// <summary>
        /// Reads and returns whole lines from the eMote serial port
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="callBack"></param>
        public SerialReadLineeMote(string portName, SerialCallback callBack) {
            _port = PortDefinition.CreateInstanceForSerial(portName, portName, 115200);
            _callBack = callBack;
        }

        /// <summary>
        /// Try to start the serial comm
        /// </summary>
        /// <returns>True iff start was successful</returns>
        public bool Start() {
            if (!_port.TryToOpen()) {
                return false;
            }
            _serialStream = _port.Open();
            _serialStreamReader = new StreamReader(_serialStream);
            _readLines = Task.Factory.StartNew(ReadLines, _cancelToken.Token);
            return true;
        }

        private async void ReadLines() {
            //_serialStreamReader.BaseStream.ReadTimeout = 100;
            while (true) {
                if (_cancelToken.Token.IsCancellationRequested) {
                    return;
                }
                try {
                    var result = await _serialStreamReader.ReadLineAsync();
                    _callBack(result);
                }
                catch (TimeoutException) { }
            }
        }

        /// <summary>
        /// Send data to mote
        /// </summary>
        /// <param name="strToSend">String to send</param>
        public void Write(string strToSend) {
            var bytesToSend = Encoding.UTF8.GetBytes(strToSend); // Convert string to bytes using UTF8 encoding
            _serialStream.Write(bytesToSend, 0, bytesToSend.Length);
            _serialStream.Flush();   // Flush causes it to be sent now, not wait on buffering
        }

        /// <summary>
        /// Stop the serial comm
        /// </summary>
        public void Stop() {
            _cancelToken.Cancel();
            if (_readLines != null) {
                _readLines.Wait();
            }
            _serialStream.Close();   // Close the stream
            _serialStream.Dispose(); // Dispose of all resources
        }

    }
}
