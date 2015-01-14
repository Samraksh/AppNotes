using System;

namespace Samraksh.AppNote.LowDutyCycle {
    public class Common {
        public const string AppName = "LDC";
        public int AppPos;
        public int AppLen;
        public int MessagePos;
        public int MessageLen;
        public byte[] MessageBuffer;

        public Common() {
            // Encode the app identifier
            var appBytes = System.Text.Encoding.UTF8.GetBytes(AppName);
            // Setup the message buffer
            MessageBuffer = new byte[sizeof(int) + appBytes.Length];

            // Define the message fields
            AppPos = 0;
            AppLen = appBytes.Length;
            MessagePos = appBytes.Length;
            MessageLen = sizeof(int);

            // Copy the app identifier to the beginning of the message buffer
            Array.Copy(appBytes, 0, MessageBuffer, AppPos, AppLen);

        }
    }
}
