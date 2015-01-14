// Copyright 2013 The Samraksh Company http://samraksh.com

using System;
using Microsoft.SPOT;
using System.Threading;

// You might get an error on the reference to this assembly the first time you compile this. 
// If so, delete the reference and recreate it where you've stored the Samraksh DLL's.
using Samraksh.eMote.DotNow;

// Use extension methods. See the definition at the end of this file.
using ExtensionMethods;


/* ******************************************************
 * Reminder: before you deploy this app to eMote, be sure to check the deployment properties.
 * Click on Project > Scrolling Hello World Properties, choose the .NET Micro Framework tab,
 * and make sure that Transport and Device are set correctly. 
 * ******************************************************/

namespace Scrolling_Hello_World {
    /// <summary>
    /// The Hello World program scrolls "Hello World  " across the eMote.NOW LCD display.
    /// </summary>
    public class Program {
        // The string to be displayed
        static string msg = "Hello World  ";
        // The time (in ms) to wait between display refresh
        static int sleepTime = 500; // half a second

        public static void Main() {
            Debug.Print(Resources.GetString(Resources.StringResources.String1));
            // Set up the LCD instance
            EmoteLCD lcd = new EmoteLCD();
            lcd.Initialize();
            // Define the string to be displayed
            // The display can hold 4 characters
            LCD char1, char2, char3, char4;
            // Scroll loop
            for (int index = 0; index < 10000; index++) {
                // Get the next four characters based on the message string and an index
                GetFour(msg, index, out char1, out char2, out char3, out char4);
                // Write the next four characters
                lcd.Write(char1, char2, char3, char4);
                // Pause a bit
                Thread.Sleep(sleepTime);
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
            int msglen = msg.Length;
            // If string is empty, return null
            if (msglen == 0) {
                char1 = char2 = char3 = char4 = LCD.CHAR_NULL;
                return;
            }
            // Quadruple the string to make sure we have at least 4 characters
            string msg4 = msg + msg + msg + msg;
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

