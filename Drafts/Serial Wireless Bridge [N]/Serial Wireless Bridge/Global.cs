using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;

namespace Samraksh.AppNote.SerialWirelessBridge {
	internal static class Global {
        /// <summary>Size of serial circular buffer</summary>
        internal const int SerialCircBuffSize = 512;

        internal static SimpleCsmaRadio CsmaRadio;

        internal enum LeaderStatus : byte {
            Undecided = 85, // U
            Leader = 76,    // L
            Follower = 70,  // F
        }

        //internal static class LeaderStatus {
        //    internal static byte[] Undecided = Encoding.UTF8.GetBytes("U");
        //    internal static byte[] Leader = Encoding.UTF8.GetBytes("L");
        //    internal static byte[] Follower = Encoding.UTF8.GetBytes("F");
        //}

        internal const int TimedActionIntervalMicrosec = 3000;

        internal static long NodeIdLong;
        internal static byte[] NodeIdBytes;
        internal const int NodeIdBytesLength = sizeof(long) * 2;
        internal static LeaderStatus LdrStatus;
        internal static SerialLink SrlLink;


        internal static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();

        internal static class ToggleLcd {
            private static readonly bool[] Status = { false, false, false, false };
            public static void Toggle(int pos, char value) {
                Status[pos] = !Status[pos];
                Lcd.WriteN(pos, Status[pos] ? value.ToLcd() : LCD.CHAR_NULL);
            }
        }
    }

}
