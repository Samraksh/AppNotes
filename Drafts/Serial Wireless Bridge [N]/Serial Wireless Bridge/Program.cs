using Microsoft.SPOT;
using Samraksh.AppNote.Utility;

namespace Samraksh.AppNote.SerialWirelessBridge {
    /// <summary>
    /// App note that demonstrates two-way serial to wireless bridge.
    /// 
    /// Uses 3 .NOWs running the same program.
    ///     - Generate sequential data and send via serial.
    ///     - Receive serial data and send via CSMA.
    ///     - Receive CSMA data and print on console.
    /// 
    /// Connect .NOWs as follows:
    ///     - #1 connected to PC via USB-serial.
    ///     - #2 connected to #3 via cross-over serial (COM2).
    /// *** need to disambiguate #2 and #3 ...
    /// </summary>
    public class Program {
        /// <summary>
        /// 
        /// </summary>
        public static void Main() {
            Debug.Print("\nSerial Wireless Build");
            Debug.Print(VersionInfo.VersionBuild());
            Debug.Print("");
        }

    }
}
