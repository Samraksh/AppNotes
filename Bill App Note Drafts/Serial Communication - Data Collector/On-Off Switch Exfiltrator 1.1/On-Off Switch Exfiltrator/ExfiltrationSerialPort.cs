using System;
using Microsoft.SPOT;
using System.IO.Ports;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;



namespace OnOffSwitchExfiltrator {
    class ExfiltrationSerialPort {
        SerialPort serialPort { get; set; }

        public ExfiltrationSerialPort(string serialPortName) {
            SerialPort serialPort = new SerialPort(serialPortName);
            serialPort.BaudRate = 115200;
            serialPort.Parity = System.IO.Ports.Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.DataBits = 8;
            serialPort.Handshake = Handshake.None;
        }
    }
}
