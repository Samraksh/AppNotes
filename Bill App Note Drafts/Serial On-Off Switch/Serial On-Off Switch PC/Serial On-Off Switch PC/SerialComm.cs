using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SPOT.Debugger;


namespace Serial_On_Off_Switch_PC {

    public class SerialComm {

        Stream UsartStream;
        AsyncCallback serialCallback;
        bool dataProcessed = true;
        byte[] inputBytes = new byte[1];
        PortDefinition portDef = null;
        delegate void SerialCallback(string theInput);
        SerialCallback callBack;
        bool timeToStop = false;

        public SerialComm(string portName, string fileName, SerialCallback _callBack) {
            uint bitRate = 115200;
            portDef = PortDefinition.CreateInstanceForSerial(portName, portName, bitRate);
            callBack = _callBack;
        }

        public bool Open() {
            if (portDef.TryToOpen()) {
                UsartStream = portDef.Open();
                return true;
            }
            else {
                return false;
            }
        }

        public void Write(string strToSend) {
            byte[] bytesToSend = System.Text.Encoding.UTF8.GetBytes(strToSend);
            UsartStream.Write(bytesToSend, 0, bytesToSend.Length);
            UsartStream.Flush();
        }

        public void ProcessData(IAsyncResult result) {
            string inputString = System.Text.Encoding.UTF8.GetString(inputBytes);
            callBack(inputString);
            dataProcessed = true;
        }

        public void Start() {
            serialCallback = new AsyncCallback(ProcessData);
            int count = 0;
            while (true) {

                if (dataProcessed) {
                    dataProcessed = false;
                    UsartStream.BeginRead(inputBytes, 0, inputBytes.Length, serialCallback, count);
                    ++count;
                }
            }
        }

    }
}
