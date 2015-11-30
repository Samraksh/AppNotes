using System;

/*
 * Copyright 2011-2014 Stefan Thoolen (http://www.netmftoolbox.com/)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace Samraksh.AppNote.Utility {
    /// <summary>
    /// Generic, useful tools
    /// </summary>
    public static class Tools {
        /// <summary>
        /// Returns the name of the hardware provider
        /// </summary>
        public static string HardwareProvider {
            get {
                if (_hardwareProvider != "") { return _hardwareProvider; }
                var HP = Microsoft.SPOT.Hardware.HardwareProvider.HwProvider.ToString().Split(new[] { '.' });
                _hardwareProvider = HP[HP.Length - 2];
                return _hardwareProvider;
            }
        }
        /// <summary>Contains the name of the hardware provider</summary>
        private static string _hardwareProvider = "";

        /// <summary>Escapes all non-visible characters</summary>
        /// <param name="Input">Input text</param>
        /// <returns>Output text</returns>
        public static string Escape(string Input) {
            if (Input == null) return "";

            var buffer = Input.ToCharArray();
            var retValue = "";
            for (var i = 0; i < buffer.Length; ++i) {
                if (buffer[i] == 13)
                    retValue += "\\r";
                else if (buffer[i] == 10)
                    retValue += "\\n";
                else if (buffer[i] == 92)
                    retValue += "\\\\";
                else if (buffer[i] < 32 || buffer[i] > 126)
                    retValue += "\\" + Dec2Hex((int)buffer[i], 2);
                else
                    retValue += buffer[i];
            }

            return retValue;
        }

        /// <summary>
        /// Converts a Hex string to a number
        /// </summary>
        /// <param name="hexNumber">The Hex string (ex.: "0F")</param>
        /// <returns>The decimal value</returns>
        public static uint Hex2Dec(string hexNumber) {
            // Always in upper case
            hexNumber = hexNumber.ToUpper();
            // Contains all Hex posibilities
            const string conversionTable = "0123456789ABCDEF";
            // Will contain the return value
            uint retVal = 0;
            // Will increase
            uint multiplier = 1;

            for (var index = hexNumber.Length - 1; index >= 0; --index) {
                retVal += (uint)(multiplier * (conversionTable.IndexOf(hexNumber[index])));
                multiplier = (uint)(multiplier * conversionTable.Length);
            }

            return retVal;
        }

        /// <summary>
        /// Converts a byte array to a char array
        /// </summary>
        /// <param name="input">The byte array</param>
        /// <returns>The char array</returns>
        public static char[] Bytes2Chars(byte[] input) {
            var output = new char[input.Length];
            for (var counter = 0; counter < input.Length; ++counter)
                output[counter] = (char)input[counter];
            return output;
        }

        /// <summary>
        /// Converts a char array to a byte array
        /// </summary>
        /// <param name="input">The char array</param>
        /// <returns>The byte array</returns>
        public static byte[] Chars2Bytes(char[] input) {
            var output = new byte[input.Length];
            for (var counter = 0; counter < input.Length; ++counter)
                output[counter] = (byte)input[counter];
            return output;
        }

        /// <summary>
        /// Changes a number into a string and add zeros in front of it, if required
        /// </summary>
        /// <param name="number">The input number</param>
        /// <param name="digits">The amount of digits it should be</param>
        /// <param name="character">The character to repeat in front (default: 0)</param>
        /// <returns>A string with the right amount of digits</returns>
        public static string ZeroFill(string number, int digits, char character = '0') {
            var negative = false;
            if (number.Substring(0, 1) == "-") {
                negative = true;
                number = number.Substring(1);
            }

            for (var counter = number.Length; counter < digits; ++counter) {
                number = character + number;
            }
            if (negative) number = "-" + number;
            return number;
        }

        /// <summary>
        /// Changes a number into a string and add zeros in front of it, if required
        /// </summary>
        /// <param name="Number">The input number</param>
        /// <param name="MinLength">The amount of digits it should be</param>
        /// <param name="character">The character to repeat in front (default: 0)</param>
        /// <returns>A string with the right amount of digits</returns>
        public static string ZeroFill(int Number, int MinLength, char character = '0') {
            return ZeroFill(Number.ToString(), MinLength, character);
            // In 4.2 it should be possible to replace this with the following line,
            // but due to a bug (http://netmf.codeplex.com/workitem/1322) it isn't.
            // return Number.toString("d" + MinLength.toString());
        }

        /// <summary>
        /// URL-encode according to RFC 3986
        /// </summary>
        /// <param name="Input">The URL to be encoded.</param>
        /// <returns>Returns a string in which all non-alphanumeric characters except -_.~ have been replaced with a percent (%) sign followed by two hex digits.</returns>
        public static string RawUrlEncode(string Input) {
            var RetValue = "";
            for (var Counter = 0; Counter < Input.Length; ++Counter) {
                var CharCode = (byte)(Input.ToCharArray()[Counter]);
                if (
                   CharCode == 0x2d                        // -
                   || CharCode == 0x5f                     // _
                   || CharCode == 0x2e                     // .
                   || CharCode == 0x7e                     // ~
                   || (CharCode > 0x2f && CharCode < 0x3a) // 0-9
                   || (CharCode > 0x40 && CharCode < 0x5b) // A-Z
                   || (CharCode > 0x60 && CharCode < 0x7b) // a-z
                   ) {
                    RetValue += Input.Substring(Counter, 1);
                }
                else {
                    // Calculates the hex value in some way
                    RetValue += "%" + Dec2Hex(CharCode, 2);
                }
            }

            return RetValue;
        }

        /// <summary>
        /// URL-decode according to RFC 3986
        /// </summary>
        /// <param name="Input">The URL to be decoded.</param>
        /// <returns>Returns a string in which original characters</returns>
        public static string RawUrlDecode(string Input) {
            var RetValue = "";
            for (var Counter = 0; Counter < Input.Length; ++Counter) {
                var Char = Input.Substring(Counter, 1);
                if (Char == "%") {
                    // Encoded character
                    var HexValue = Input.Substring(++Counter, 2);
                    ++Counter;
                    RetValue += (char)Hex2Dec(HexValue);
                }
                else {
                    // Normal character
                    RetValue += Char;
                }
            }

            return RetValue;
        }

        /// <summary>
        /// Encodes a string according to the BASE64 standard
        /// </summary>
        /// <param name="Input">The input string</param>
        /// <returns>The output string</returns>
        public static string Base64Encode(string Input) {
            // Pairs of 3 8-bit bytes will become pairs of 4 6-bit bytes
            // That's the whole trick of base64 encoding :-)

            var Blocks = Input.Length / 3;           // The amount of original pairs
            if (Blocks * 3 < Input.Length) ++Blocks; // Fixes rounding issues; always round up
            var Bytes = Blocks * 4;                  // The length of the base64 output

            // These characters will be used to represent the 6-bit bytes in ASCII
            var Base64_Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=".ToCharArray();

            // Converts the input string to characters and creates the output array
            var InputChars = Input.ToCharArray();
            var OutputChars = new char[Bytes];

            // Converts the blocks of bytes
            for (var Block = 0; Block < Blocks; ++Block) {
                // Fetches the input pairs
                var Input0 = (byte)(InputChars.Length > Block * 3 ? InputChars[Block * 3] : 0);
                var Input1 = (byte)(InputChars.Length > Block * 3 + 1 ? InputChars[Block * 3 + 1] : 0);
                var Input2 = (byte)(InputChars.Length > Block * 3 + 2 ? InputChars[Block * 3 + 2] : 0);

                // Generates the output pairs
                var Output0 = (byte)(Input0 >> 2);                           // The first 6 bits of the 1st byte
                var Output1 = (byte)(((Input0 & 0x3) << 4) + (Input1 >> 4)); // The last 2 bits of the 1st byte followed by the first 4 bits of the 2nd byte
                var Output2 = (byte)(((Input1 & 0xf) << 2) + (Input2 >> 6)); // The last 4 bits of the 2nd byte followed by the first 2 bits of the 3rd byte
                var Output3 = (byte)(Input2 & 0x3f);                         // The last 6 bits of the 3rd byte

                // This prevents 0-bytes at the end
                if (InputChars.Length < Block * 3 + 2) Output2 = 64;
                if (InputChars.Length < Block * 3 + 3) Output3 = 64;

                // Converts the output pairs to base64 characters
                OutputChars[Block * 4] = Base64_Characters[Output0];
                OutputChars[Block * 4 + 1] = Base64_Characters[Output1];
                OutputChars[Block * 4 + 2] = Base64_Characters[Output2];
                OutputChars[Block * 4 + 3] = Base64_Characters[Output3];
            }

            return new string(OutputChars);
        }

        /// <summary>
        /// Converts a number to a Hex string
        /// </summary>
        /// <param name="Input">The number</param>
        /// <param name="MinLength">The minimum length of the return string (filled with 0s)</param>
        /// <returns>The Hex string</returns>
        public static string Dec2Hex(int Input, int MinLength = 0) {
#if MF_FRAMEWORK_VERSION_V4_2 || MF_FRAMEWORK_VERSION_V4_3
            // Since NETMF 4.2 int.toString() exists, so we can do this:
            return Input.ToString("X" + MinLength.ToString());
#else
                // Contains all Hex posibilities
                string ConversionTable = "0123456789ABCDEF";
                // Starts the conversion
                string RetValue = "";
                int Current = 0;
                int Next = Input;
                do
                {
                    if (Next >= ConversionTable.Length)
                    {
                        // The current digit
                        Current = (Next / ConversionTable.Length);
                        if (Current * ConversionTable.Length > Next) --Current;
                        // What's left
                        Next = Next - (Current * ConversionTable.Length);
                    }
                    else
                    {
                        // The last digit
                        Current = Next;
                        // Nothing left
                        Next = -1;
                    }
                    RetValue += ConversionTable[Current];
                } while (Next != -1);

                return Tools.ZeroFill(RetValue, MinLength);
#endif
        }

        /// <summary>
        /// Converts a 16-bit array to an 8 bit array
        /// </summary>
        /// <param name="Data">The 16-bit array</param>
        /// <returns>The 8-bit array</returns>
        public static byte[] UShortsToBytes(ushort[] Data) {
            var RetVal = new byte[Data.Length * 2];

            var BytePos = 0;
            for (var ShortPos = 0; ShortPos < Data.Length; ++ShortPos) {
                RetVal[BytePos++] = (byte)(Data[ShortPos] >> 8);
                RetVal[BytePos++] = (byte)(Data[ShortPos] & 0x00ff);
            }
            return RetVal;
        }

        /// <summary>
        /// Converts an 8-bit array to a 16 bit array
        /// </summary>
        /// <param name="Data">The 8-bit array</param>
        /// <returns>The 16-bit array</returns>
        public static ushort[] BytesToUShorts(byte[] Data) {
            var RetVal = new ushort[Data.Length / 2];

            var BytePos = 0;
            for (var ShortPos = 0; ShortPos < RetVal.Length; ++ShortPos) {
                RetVal[ShortPos] = (ushort)((Data[BytePos++] << 8) + Data[BytePos++]);
            }
            return RetVal;
        }

        /// <summary>Calculates an XOR Checksum</summary>
        /// <param name="Data">Input data</param>
        /// <returns>XOR Checksum</returns>
        public static byte XorChecksum(string Data) {
            return XorChecksum(Chars2Bytes(Data.ToCharArray()));
        }

        /// <summary>Calculates an XOR Checksum</summary>
        /// <param name="Data">Input data</param>
        /// <returns>XOR Checksum</returns>
        public static byte XorChecksum(byte[] Data) {
            byte Checksum = 0;
            for (var Pos = 0; Pos < Data.Length; ++Pos)
                Checksum ^= Data[Pos];

            return Checksum;
        }

        /// <summary>
        /// Displays a number with a metric prefix
        /// </summary>
        /// <param name="Number">The number</param>
        /// <param name="BinaryMultiple">If true, will use 1024 as multiplier instead of 1000</param>
        /// <returns>The number with a metric prefix</returns>
        /// <remarks>See also: http://en.wikipedia.org/wiki/Metric_prefix </remarks>
        public static string MetricPrefix(float Number, bool BinaryMultiple = false) {
            float Multiplier = BinaryMultiple ? 1024 : 1000;
            if (Number > (Multiplier * Multiplier * Multiplier * Multiplier))
                return Round(Number / Multiplier / Multiplier / Multiplier / Multiplier) + "T";
            if (Number > (Multiplier * Multiplier * Multiplier))
                return Round(Number / Multiplier / Multiplier / Multiplier) + "G";
            if (Number > (Multiplier * Multiplier))
                return Round(Number / Multiplier / Multiplier) + "M";
            if (Number > Multiplier)
                return Round(Number / Multiplier) + "k";
            else
                return Round(Number).ToString();
        }

        /// <summary>
        /// Rounds a value to a certain amount of digits
        /// </summary>
        /// <param name="Input">The input number</param>
        /// <param name="Digits">Amount of digits after the .</param>
        /// <returns>The rounded value (as float or double gave precision errors, hence the String type)</returns>
        public static string Round(float Input, int Digits = 2) {
            var Multiplier = 1;
            for (var i = 0; i < Digits; ++i) Multiplier *= 10;
            var Rounded = ((int)(Input * Multiplier)).ToString();

            return (Rounded.Substring(0, Rounded.Length - 2) + "." + Rounded.Substring(Rounded.Length - 2)).TrimEnd(new char[] { '0', '.' });
        }

        /// <summary>
        /// Converts an integer color code to RGB
        /// </summary>
        /// <param name="Color">The integer color (0x000000 to 0xffffff)</param>
        /// <returns>A new byte[] { Red, Green, Blue }</returns>
        public static int[] ColorToRgb(int Color) {
            var Red = (byte)((Color & 0xff0000) >> 16);
            var Green = (byte)((Color & 0xff00) >> 8);
            var Blue = (byte)(Color & 0xff);

            return new int[] { Red, Green, Blue };
        }

        /// <summary>A generic event handler when receiving a string</summary>
        /// <param name="text">The actual string</param>
        /// <param name="time">Timestamp of the event</param>
        public delegate void StringEventHandler(string text, DateTime time);
    }
}