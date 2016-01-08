/*--------------------------------------------------------------------
 * Serial On-Off Switch for PC: app note for the eMote .NOW 1.0
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *  1.0: initial release
---------------------------------------------------------------------*/

using System;
using System.Windows.Forms;

namespace Serial_On_Off_Switch_PC {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SerialOnOffPc());
        }
    }
}
