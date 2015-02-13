using System.IO.Ports;
using System.Threading;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;
using Math = System.Math;

namespace Samraksh.AppNote.SerialWirelessBridge {
    internal class SerialLink {
        public delegate void SerialReadHandler(byte[] buffer, int bytesRead);

        public const byte MessageBegin = 0x1;
        public const byte MessageEnd = 0x2;

        private readonly SerialPort _port;
        private readonly byte[] _byteBuffer = new byte[500];

        private readonly CircularBuffer _circularBuffer = new CircularBuffer(512);
        private readonly AutoResetEvent _newData = new AutoResetEvent(false);

        public SerialLink() {
            (new Thread(ProcessCircBuffer)).Start();
            _port = new SerialPort("COM2") {
                BaudRate = 115200,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Handshake = Handshake.None,
            };
            _port.DataReceived += DataReceived;
            _port.Open();
        }

        /// <summary>
        /// Write bytes to serial port
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="bytesToSend"></param>
        public void Write(byte[] buffer, int bytesToSend) {
            Debug.Print("# Send " + _sndCnt++);
            _port.WriteByte(MessageBegin);
            _port.Write(buffer, 0, bytesToSend);
            _port.WriteByte(MessageEnd);
            _port.Flush();
        }
        private int _sndCnt;

        private void DataReceived(object sender, SerialDataReceivedEventArgs e) {
            Global.ToggleLcd.Toggle(3, '3');
            Debug.Print("  * Receive " + _rcvCnt++ + ", Bytes to read " + _port.BytesToRead);
            var bytesReadx = _port.Read(_byteBuffer, 0, Math.Max(_port.BytesToRead, _byteBuffer.Length));
            return;
            while (_port.BytesToRead > 0) {
                var bytesRead = _port.Read(_byteBuffer, 0, Math.Max(_port.BytesToRead, _byteBuffer.Length));
                Debug.Print("BytesToRead: " + _port.BytesToRead + ", bytesRead: " + bytesRead);
                _circularBuffer.Put(_byteBuffer, bytesRead);
                //for (var i = 0; i < bytesRead; i++) {
                //    _circularBuffer.Put(_byteBuffer[i]);
                //}
                _newData.Set();
            }
        }
        private int _rcvCnt;

        private enum ProcessState {
            Idle,
            Start,
            Election,
            Send,
            Receive,
        }

        private void ProcessCircBuffer() {
            var currState = ProcessState.Idle;
            var messageBytes = new byte[100];
            var messageLen = 0;

            Debug.Print("Starting ProcessCircBuffer");

            while (true) {
                _newData.WaitOne();
                while (_circularBuffer.IsData) {
                    var currByte = _circularBuffer.Get();
                    switch (currState) {
                        case ProcessState.Idle:
                            if (currByte == MessageBegin) {
                                currState = ProcessState.Start;
                            }
                            break;
                        case ProcessState.Start:
                            switch (currByte) {
                                case (byte)Messages.MessageType.Election:
                                    messageLen = 0;
                                    currState = ProcessState.Election;
                                    break;
                                case (byte)Messages.MessageType.Outgoing:
                                    messageLen = 0;
                                    currState = ProcessState.Send;
                                    break;
                                case (byte)Messages.MessageType.Return:
                                    messageLen = 0;
                                    currState = ProcessState.Receive;
                                    break;
                                default:
                                    currState = ProcessState.Idle;
                                    break;
                            }
                            break;
                        case ProcessState.Election:
                        case ProcessState.Send:
                        case ProcessState.Receive:
                            if (currByte == MessageEnd) {
                                //var messageString = Encoding.UTF8.GetChars(messageBytes, 0, messageLen).ToString();
                                switch (currState) {
                                    case ProcessState.Election:
                                        ProtocolActions.RcvSerialElection(messageBytes, messageLen);
                                        break;
                                    case ProcessState.Send:
                                        ProtocolActions.RcvSerialOutgoing(messageBytes, messageLen);
                                        break;
                                    case ProcessState.Receive:
                                        ProtocolActions.RcvSerialReturn(messageBytes, messageLen);
                                        break;
                                }
                            }
                            messageLen++;
                            messageBytes[messageLen] = currByte;
                            break;
                    }
                }
            }
        }
    }
}

