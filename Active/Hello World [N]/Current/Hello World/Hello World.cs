/*--------------------------------------------------------------------
 * GPIO Toggle: app note for the eMote .NOW
 * (c) 2015 The Samraksh Company
 * 
 * Hello World: Scroll across LCD display
 * 
 * Version history
 *      1.0:	- Initial release
 *      
 *      1.1:	- Added eMote folder with DLLs and TinyClr
 *				- Other minor changes
---------------------------------------------------------------------*/

// Use extension methods. See the definition at the end of this file.

using System.Reflection;
using System.Threading;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;


/* ******************************************************
 * Reminder: before you deploy this app to a .NOW, be sure to check the deployment properties.
 * Click on Project > Scrolling Hello World Properties, choose the .NET Micro Framework tab,
 * and make sure that Transport and Device are set correctly. 
 * ******************************************************/

namespace Samraksh.AppNote.DotNow.HelloWorld {
    /// <summary>
    /// The Hello World program scrolls "Hello World  " across the eMote.NOW LCD display.
    /// </summary>
    public class Program {
        // The string to be displayed
	    private const string Msg = "Hello World  ";
	    // The time (in ms) to wait between display refresh
	    private const int SleepTime = 500; // half a second

	    public static void Main() {
			Debug.EnableGCMessages(false);

			Debug.Print("\nHello World");

			// Print the version and build info
			VersionInfo.Init(Assembly.GetExecutingAssembly());
			Debug.Print("Version " + VersionInfo.Version + ", build " + VersionInfo.BuildDateTime);
			Debug.Print("");

            // Set up the LCD instance
            var lcd = new EmoteLCD();
            
	        // Scroll loop
			//	The display can hold 4 characters
			for (var index = 0; index < 10000; index++) {
                // Get the next four characters based on the message string and an index
	            LCD char1;
	            LCD char2;
	            LCD char3;
	            LCD char4;
	            GetFour(Msg, index, out char1, out char2, out char3, out char4);
                // Write the next four characters
                lcd.Write(char1, char2, char3, char4);
                // Pause a bit
                Thread.Sleep(SleepTime);
            }
        }

        /// <summary>
        /// Get the next four characters from a string
        /// </summary>
        /// <param name="msg">Input: The string that has the characters to be displayed</param>
        /// <param name="index">Input: The index in the string of the first character required. This can be larger than the length of msg; a modulo value will be used.</param>
        /// <param name="char1">Output: The LCD value of the first character.</param>
        /// <param name="char2">Output: The LCD value of the second character.</param>
        /// <param name="char3">Output: The LCD value of the third character.</param>
        /// <param name="char4">Output: The LCD value of the fourth character.</param>
        static void GetFour(string msg, int index, out LCD char1, out LCD char2, out LCD char3, out LCD char4) {
            var msglen = msg.Length;
            // If string is empty, return null
            if (msglen == 0) {
                char1 = char2 = char3 = char4 = LCD.CHAR_NULL;
                return;
            }
            // Quadruple the string to make sure we have at least 4 characters
            var msg4 = msg + msg + msg + msg;
            // Trim the index to the modulo value 
            index = index % msglen;
            // Get the 4 characters
            char1 = msg4[index + 0].ToLCD();
            char2 = msg4[index + 1].ToLCD();
            char3 = msg4[index + 2].ToLCD();
            char4 = msg4[index + 3].ToLCD();
        }

    }
}

