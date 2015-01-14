using System.IO.Ports;
using System.Reflection;
using System.Threading;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;

namespace Test_COM2_send_receive {
    public static class Program {

        private static SerialPort _port;
        private static readonly byte[] ByteBuffer = new byte[128];
        static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();


        public static void Main() {
            Debug.Print("\nTest COM2 send-receive");
            Debug.Print(Assembly.GetExecutingAssembly().GetName().Name);
            Debug.Print(VersionInfo.VersionBuild());
            Debug.Print("");

            _port = new SerialPort("COM2") {
                BaudRate = 115200,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.None,
            };
            _port.DataReceived += DataReceived;
            _port.Open();

            var ctr = 0;
            while (true) {
                Thread.Sleep(3000);
                _port.WriteByte((byte)ctr);
                _port.Flush();
                ctr = (ctr + 1) % 256;
                ToggleLcd.Toggle(0, '0');
            }
        }

        private static void DataReceived(object sender, SerialDataReceivedEventArgs e) {
            ToggleLcd.Toggle(3, '3');
            var bytesRead = _port.Read(ByteBuffer, 0, ByteBuffer.Length);
            for (var i = 0; i < bytesRead; i++) {
                Debug.Print(ByteBuffer[i] + " ");
            }
            Debug.Print("");
        }

        public static class ToggleLcd {
            private static readonly bool[] Status = { false, false, false, false };
            public static void Toggle(int pos, char value) {
                Status[pos] = !Status[pos];
                Lcd.WriteN(pos, Status[pos] ? value.ToLcd() : LCD.CHAR_NULL);
            }
        }


    }
}
