using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

using _DBG = Microsoft.SPOT.Debugger;
using _WP = Microsoft.SPOT.Debugger.WireProtocol;

namespace DataCollectorHost
{
    public class DataCollector
    {
        Stream UsartStream;
        string port;
        AsyncCallback serialCallback;
        StreamWriter inpFile;
        StreamWriter OutFile;
        static bool dDone = true;
        static byte[] buffer = new byte[256];

        public DataCollector(string port, string fileName)
        {
            _DBG.PortDefinition pd = null;
            this.port = port;
            uint baudrate = 115200;

            pd = _DBG.PortDefinition.CreateInstanceForSerial(this.port, this.port, baudrate);

            if (pd.TryToOpen())
            {
                UsartStream = pd.Open();

                Console.WriteLine("Opening Port : " + pd.DisplayName.ToString());

            }
            else
            {
                Console.WriteLine("The Port can not be openend");
            }

            inpFile = new StreamWriter(fileName, true);

        }

        public void ProcessData(IAsyncResult result)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                Console.Write(buffer[i].ToString());
                inpFile.Write(buffer[i]);
            }

            inpFile.WriteLine();
            Console.Write("\n");

            dDone = true;
        }

        public void Run()
        {

            serialCallback = new AsyncCallback(ProcessData);

            int count = 0;

            while (true)
            {
                if (dDone)
                {
                    dDone = false;

                    UsartStream.BeginRead(buffer, 0, buffer.Length, serialCallback, count);
                    ++count;

                }
            }
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            string port = "";
            string inputFile = "";


            Console.WriteLine("Enter the COM Port : ");
            port = Console.ReadLine();
            Console.WriteLine("Enter the name of the storage file : ");
            inputFile = Console.ReadLine();

            DataCollector dc = new DataCollector(port, inputFile);

            dc.Run();

        }
    }
}
