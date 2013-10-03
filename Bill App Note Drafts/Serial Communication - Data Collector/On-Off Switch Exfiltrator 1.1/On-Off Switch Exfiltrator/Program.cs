/*--------------------------------------------------------------------
 * On-Off Switch Exfiltrator app note for the eMote .NOW 1.0
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *  1.0: initial release
 ---------------------------------------------------------------------*/

using System;
using System.IO.Ports;
using System.Threading;

using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.SPOT.Hardware.EmoteDotNow;

using ExtensionMethods;
using SamrakshAppNoteUtility;

namespace OnOffSwitchExfiltrator {

    public class Program {

        static EmoteLCD lcd = new EmoteLCD();
        static SerialComm exfilPort;

        static bool sendSwitchVal = true;

        public static void Main() {
            lcd.Initialize();
            lcd.Write('1'.ToLCD(), '1'.ToLCD(), '1'.ToLCD(), '1'.ToLCD());
            Thread.Sleep(1000);
            lcd.Write(' '.ToLCD(), ' '.ToLCD(), ' '.ToLCD(), ' '.ToLCD());

            SwitchInput onOffSwitch = new SwitchInput(Pins.GPIO_J12_PIN1, Port.ResistorMode.PullUp, SwitchCallback);

            try {
                exfilPort = new SerialComm("COM1", ExfiltrationSerialCallback);
                exfilPort.Open();
            }
            catch {
                lcd.Write('9'.ToLCD(), '9'.ToLCD(), '9'.ToLCD(), '9'.ToLCD());
            }

            Thread.Sleep(Timeout.Infinite);
        }

        private static void SwitchCallback(bool switchValue) {
            if (!sendSwitchVal) {
                return;
            }
            ExfilLCD.SwitchValue((switchValue) ? '0' : '1');
            exfilPort.Write((switchValue) ? "Off\n" : "On\n");
        }

        private static void ExfiltrationSerialCallback(byte[] readBytes) {
            char[] readChars = System.Text.Encoding.UTF8.GetChars(readBytes);
            string readStr = readChars.ToString();
            if (readChars[0] == '1') {
                sendSwitchVal = true;
                ExfilLCD.InputValue('a');
                return;
            }
            if (readChars[0]== '0') {
                sendSwitchVal = false;
                ExfilLCD.InputValue('b');
                return;
            }
            for (int i = 0; i<readStr.Length;i++) {
                ExfilLCD.InputValue(readStr[i]);
                Thread.Sleep(1000);
            }
        }

        static class ExfilLCD {
            private static char lcd1 = ' ';
            private static char lcd2 = ' ';
            private static char lcd3 = ' ';
            private static char lcd4 = ' ';

            public static void SwitchValue(char swVal) {
                lcd1 = swVal;
                WriteLcd();
            }

            public static void InputValue(char inVal) {
                lcd3 = inVal;
                WriteLcd();
            }

            private static void WriteLcd() {
                lcd.Write(lcd1.ToLCD(), lcd2.ToLCD(), lcd3.ToLCD(), lcd4.ToLCD());
            }
        }

    }
}
