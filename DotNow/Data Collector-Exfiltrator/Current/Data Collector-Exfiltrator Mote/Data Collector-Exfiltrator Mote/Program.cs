/*--------------------------------------------------------------------
 * Serial On-Off Switch for mote: app note for the eMote .NOW 1.0
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *  1.0: initial release
 *  1.1: Minor changes
 *  1.2: Rename to "Data Collector-Exfiltrator". Allow building for either input switch or radar.
---------------------------------------------------------------------*/

using System.Threading;

using Microsoft.SPOT;

using Samraksh.AppNote.DotNow.DataCollectorExfiltrator.Globals;
using Samraksh.AppNote.DotNow.DataCollectorExfiltrator.Sensors;
using Samraksh.AppNote.Utility;

namespace Samraksh.AppNote.DotNow.DataCollectorExfiltrator {

    /// <summary>
    /// This eMote.NOW server program interacts with PC client via the serial port.
    /// Communication is bi-directional:
    ///      The mote server sends messages about switch state to the PC client, which are displayed in a text box.
    ///      The user can make the PC client turn the message transmission on or off.
    /// </summary>
    public class Program {

        const string CommPort = "COM1";         // The comm port to use. Due to limitations in drivers, must be COM1, COM2 or COM3.

        /// <summary>
        /// Initialize things and start the threads to handle switch and serial I/O
        /// </summary>
        public static void Main() {
            Debug.Print(Global.DataPrefix + "Input Sensor: " + Sensor.SensorName);
            Sensor.Initialize();

            // Set up serial comm. 
            //  This specifies the comm port to use and a callback method to process data received from the PC
            try {
                Global.Serial = new SerialComm(CommPort, SerialCallback);
                //                Global.Serial = new SerialComm(CommPort, SerialCallback);
                Global.Serial.Open();
            }
            // If can't open the port, display error on LCD
            catch {
                Sensor.ErrorMsg("err");
            }

            // Sleep forever
            //  All the real work is handled by the input switch and serial comm threads, which are event driven.
            Thread.Sleep(Timeout.Infinite);
        }

        /// <summary>
        /// Process input serial data
        /// </summary>
        /// <param name="readBytes">Data received</param>
        private static void SerialCallback(byte[] readBytes) {
            var readChars = System.Text.Encoding.UTF8.GetChars(readBytes);   // Decode the input bytes as char using UTF8
            // If 1, note that PC wants to get sensed data
            if (readChars[0] == '1') {
                Global.SendSensedData = true;
                //Global.SerialLcd.InputValue('a');
                Global.Serial.Write("-- Switch enabled\n");  // Let the PC know we got it
                return;
            }
            // If 0, note that PC does not want to get sensed data
            if (readChars[0] == '0') {
                Global.SendSensedData = false;
                //Global.SerialLcd.InputValue('b');
                Global.Serial.Write("-- Switch disabled\n"); // Let the PC know we got it
                return;
            }
            //// If neither one, use LCD to display data received, one char at a time
            //var readStr = readChars.ToString();
            //for (var i = 0; i < readStr.Length; i++) {
            //    Global.SerialLcd.InputValue(readStr[i]);
            //    Thread.Sleep(1000);
            //}
        }
    }
}
