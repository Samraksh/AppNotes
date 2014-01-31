/*--------------------------------------------------------------------
 * DataStore: app note for the eMote .NOW
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *  1.0: initial release
 ---------------------------------------------------------------------*/

using System.Threading;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;

namespace Samraksh {
    namespace AppNote {
        namespace DataStore {
            /// <summary>
            /// ***
            /// </summary>
            public class Program {

                private static readonly EasyLcd Lcd = new EasyLcd();

                /// <summary>
                /// Set things up
                /// </summary>
                public static void Main() {
                    Lcd.Write('a'.ToLcd(), 'a'.ToLcd(), 'a'.ToLcd(), 'a'.ToLcd());
                    Lcd.Display("data");
                    Debug.Print("DataStore " + VersionInfo.Version + " (" + VersionInfo.BuildDateTime + ")");
                    Thread.Sleep(4000);

                    Thread.Sleep(Timeout.Infinite);
                }

            }
        }
    }
}
