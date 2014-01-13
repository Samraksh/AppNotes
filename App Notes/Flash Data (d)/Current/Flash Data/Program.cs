using System.Threading;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;

namespace Samraksh {
    namespace AppNote {
        namespace FlashData {
            /// <summary>
            /// Exercise the flash memory on the eMote .NOW
            /// </summary>
            public class Program {

                private static readonly EasyLcd Lcd = new EasyLcd();

                /// <summary>
                /// Set things up
                /// </summary>
                public static void Main() {
                    Lcd.Write('a'.ToLcd(), 'a'.ToLcd(), 'a'.ToLcd(), 'a'.ToLcd());
                    Lcd.Display("Flash");
                    Debug.Print("Flash Data " + VersionInfo.Version + " (" + VersionInfo.BuildDateTime + ")");
                    Thread.Sleep(4000);

                    Thread.Sleep(Timeout.Infinite);
                }

            }
        }
    }
}
