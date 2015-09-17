/*--------------------------------------------------------------------
 * Serial On-Off Switch for PC: app note for the eMote .NOW 1.0
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *  1.0: initial release
 *  
 *  1.1:
 *  
 *  1.2:
 *  
 *  1.3: Changes for release 13
---------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
