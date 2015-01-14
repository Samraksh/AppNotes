using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;

namespace Samraksh.AppNote.SerialWirelessBridge {
    static class Global {
        /// <summary>Size of serial circular buffer</summary>
        internal const int SerialCircBuffSize = 512;

        internal static SimpleCsmaRadio CsmaRadio;
        
        internal  enum LeaderStatus : byte {
            Undecided = 0,
            Leader = 1,
            Follower = 2,
        }

        internal const int TimedActionIntervalMicrosec = 3000;

        internal static long NodeId;
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
