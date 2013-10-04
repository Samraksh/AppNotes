using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

using _DBG = Microsoft.SPOT.Debugger;
using _WP = Microsoft.SPOT.Debugger.WireProtocol;

namespace DataCollectorHost {
    public class DataCollector {
        Stream UsartStream;
        string port;
        AsyncCallback serialCallback;
        StreamWriter inpFile;
        static bool dDone = true;
        static byte[] buffer = new byte[1];

        public DataCollector(string port, string fileName) {
            _DBG.PortDefinition pd = null;
            this.port = port;
            uint baudrate = 115200;

            pd = _DBG.PortDefinition.CreateInstanceForSerial(this.port, this.port, baudrate);

            if (pd.TryToOpen()) {
                UsartStream = pd.Open();

                Console.WriteLine("Opening Port : " + pd.DisplayName.ToString());

            }
            else {
                Console.WriteLine("The Port can not be opened");
            }

            inpFile = new StreamWriter(fileName, true);

        }

        public void Write(string strToSend) {
            byte[] bytesToSend = System.Text.Encoding.UTF8.GetBytes(strToSend);
            UsartStream.Write(bytesToSend,0,bytesToSend.Length);
            UsartStream.Flush();
        }

        public void ProcessData(IAsyncResult result) {
            for (int i = 0; i < buffer.Length; i++) {
                inpFile.Write(buffer[i]);
            }

            inpFile.WriteLine();

            string decoded = System.Text.Encoding.UTF8.GetString(buffer);
            Console.Write(decoded);

            dDone = true;
        }

        public void Run() {

            Thread t = new Thread(() => {
                Debug.Print("Starting thread");
                while (true) {
                    byte[] msgBytes = System.Text.Encoding.UTF8.GetBytes("1");
                    UsartStream.Write(msgBytes,0,msgBytes.Length);
                    UsartStream.Flush();
                    Thread.Sleep(10000);
                    msgBytes = System.Text.Encoding.UTF8.GetBytes("0");
                    UsartStream.Write(msgBytes,0,msgBytes.Length);
                    UsartStream.Flush();
                    Thread.Sleep(10000);
                }
            });
            t.IsBackground = true;
            t.Start();

            serialCallback = new AsyncCallback(ProcessData);

            int count = 0;

            while (true) {
                if (dDone) {
                    dDone = false;

                    UsartStream.BeginRead(buffer, 0, buffer.Length, serialCallback, count);
                    ++count;

                }
            }
        }

    }


    class Program {
        static void Main(string[] args) {
            string port = "";
            string inputFile = "";


            //Console.WriteLine("Enter the COM Port : ");
            //port = Console.ReadLine();
            port = "COM1";
            //Console.WriteLine("Enter the name of the storage file : ");
            //inputFile = Console.ReadLine();
            inputFile = @"c:\temp\datacollector.txt";

            DataCollector dc = new DataCollector(port, inputFile);

            dc.Run();


        }
    }
}
