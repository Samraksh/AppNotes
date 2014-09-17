/*=========================
 * Bit Converter Class
 *  Define methods to duplicate BitConverter class for full .NET framework
 * Versions
 *  1.0 Initial Version
 *  1.1 Added methods to use reference arguments for arrays rather than create and return arrays
=========================*/

using Hardware = Microsoft.SPOT.Hardware;

//
// Copyright 2011-2012 Antao Almada
// https://bitbucket.org/aalmada/hydramf/src/779d1c524a9c/HydraMF.Hardware/BitConverter.cs
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

// Note that this requires the /unsafe build option.

// See also http://forums.netduino.com/index.php?/topic/308-bitconverter/, and accompanying comments.

namespace Samraksh.AppNote.Utility {

    /// <summary>
    /// Converts base data types to an array of bytes, and an array of bytes to base data types.
    /// </summary>
    public static class BitConverter {
        /// <summary>
        /// Indicates the byte order ("endianness") in which data is stored in this computer architecture.
        /// </summary>
        public static readonly bool IsLittleEndian =
            Hardware.Utility.ExtractValueFromArray(new byte[] { 0xaa, 0xbb }, 0, 2) == 0xbbaa;

        #region Boolean

        /// <summary>
        /// Inserts a value at a specified position in a byte array.
        /// </summary>
        /// <param name="data">The array into which you want to insert the specified value.</param>
        /// <param name="startIndex">The position in the array where you want to insert the specified value.</param>
        /// <param name="value">The value you want to insert into the array.</param>
        public static void InsertValueIntoArray(byte[] data, int startIndex, bool value) {
            Hardware.Utility.InsertValueIntoArray(data, startIndex, 1, value ? 1u : 0u);
        }

        /// <summary>
        /// Returns the specified Boolean value as an array of bytes.
        /// </summary>
        /// <param name="value">A Boolean value. </param>
        /// <returns>An array of bytes with length 1.</returns>
        public static byte[] GetBytes(bool value) {
            var array = new byte[1];
            InsertValueIntoArray(array, 0, value);
            return array;
        }

        /// <summary>
        /// Returns the specified Boolean value as an array of bytes
        /// </summary>
        /// <param name="array">The return array: bytes[1]</param>
        /// <param name="value">A Boolean value</param>
        public static void GetBytes(byte[] array, bool value) {
            InsertValueIntoArray(array, 0, value);
        }

        /// <summary>
        /// Returns a Boolean value converted from one byte at a specified position in a byte array.
        /// </summary>
        /// <param name="value">An array of bytes. </param>
        /// <param name="startIndex">The starting position within value. </param>
        /// <returns>true if the byte at startIndex in value is nonzero; otherwise, false.</returns>
        public static bool ToBoolean(byte[] value, int startIndex) {
            return Hardware.Utility.ExtractValueFromArray(value, startIndex, 1) != 0u;
        }

        #endregion

        #region Char

        /// <summary>
        /// Inserts a value at a specified position in a byte array.
        /// </summary>
        /// <param name="data">The array into which you want to insert the specified value.</param>
        /// <param name="startIndex">The position in the array where you want to insert the specified value.</param>
        /// <param name="value">The value you want to insert into the array.</param>
        public static void InsertValueIntoArray(byte[] data, int startIndex, char value) {
            Hardware.Utility.InsertValueIntoArray(data, startIndex, 2, value);
        }

        /// <summary>
        /// Returns the specified Unicode character value as an array of bytes.
        /// </summary>
        /// <param name="value">A character to convert.</param>
        /// <returns>An array of bytes with length 2.</returns>
        public static byte[] GetBytes(char value) {
            var array = new byte[2];
            InsertValueIntoArray(array, 0, value);
            return array;
        }

        /// <summary>
        /// Returns the specified Unicode character value as an array of bytes.
        /// </summary>
        /// <param name="array">The return array: bytes[2]</param>
        /// <param name="value">A character to convert.</param>
        public static void GetBytes(byte[] array, char value) {
            InsertValueIntoArray(array, 0, value);

        }

        /// <summary>
        /// Returns a Unicode character converted from two bytes at a specified position in a byte array.
        /// </summary>
        /// <param name="value">An array of bytes.</param>
        /// <param name="startIndex">The starting position within value.</param>
        /// <returns>A character formed by two bytes beginning at startIndex.</returns>
        public static char ToChar(byte[] value, int startIndex) {
            return (char)Hardware.Utility.ExtractValueFromArray(value, startIndex, 2);
        }

        #endregion

        #region Int16

        /// <summary>
        /// Inserts a value at a specified position in a byte array.
        /// </summary>
        /// <param name="data">The array into which you want to insert the specified value.</param>
        /// <param name="startIndex">The position in the array where you want to insert the specified value.</param>
        /// <param name="value">The value you want to insert into the array.</param>
        public static void InsertValueIntoArray(byte[] data, int startIndex, short value) {
            Hardware.Utility.InsertValueIntoArray(data, startIndex, 2, (uint)value);
        }

        /// <summary>
        /// Returns the specified 16-bit signed integer value as an array of bytes.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 2.</returns>
        public static byte[] GetBytes(short value) {
            var array = new byte[2];
            InsertValueIntoArray(array, 0, value);
            return array;
        }

        /// <summary>
        /// Returns the specified 16-bit signed integer value as an array of bytes.
        /// </summary>
        /// <param name="array">The return array: bytes[2]</param>
        /// <param name="value">The number to convert.</param>
        public static void GetBytes(byte[] array, short value) {
            InsertValueIntoArray(array, 0, value);
        }

        /// <summary>
        /// Returns a 16-bit signed integer converted from two bytes at a specified position in a byte array.
        /// </summary>
        /// <param name="value">An array of bytes.</param>
        /// <param name="startIndex">The starting position within value.</param>
        /// <returns>A 16-bit signed integer formed by two bytes beginning at startIndex.</returns>
        public static short ToInt16(byte[] value, int startIndex) {
            return (short)Hardware.Utility.ExtractValueFromArray(value, startIndex, 2);
        }

        #endregion

        #region UInt16 (ushort)

        /// <summary>
        /// Inserts a value at a specified position in a byte array.
        /// </summary>
        /// <param name="data">The array into which you want to insert the specified value.</param>
        /// <param name="startIndex">The position in the array where you want to insert the specified value.</param>
        /// <param name="value">The value you want to insert into the array.</param>
        public static void InsertValueIntoArray(byte[] data, int startIndex, ushort value) {
            Hardware.Utility.InsertValueIntoArray(data, startIndex, 2, (uint)value);
        }

        /// <summary>
        /// Returns the specified 16-bit unsigned integer value as an array of bytes.
        /// This API is not CLS-compliant. 
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 2.</returns>
        public static byte[] GetBytes(ushort value) {
            var array = new byte[2];
            InsertValueIntoArray(array, 0, value);
            return array;
        }

        /// <summary>
        /// Returns the specified 16-bit unsigned integer value as an array of bytes.
        /// This API is not CLS-compliant. 
        /// </summary>
        /// <param name="array">The return array: byte[]</param>
        /// <param name="value">The number to convert.</param>
        public static void GetBytes(byte[] array, ushort value) {
            InsertValueIntoArray(array, 0, value);
        }

        /// <summary>
        /// Returns the specified 16-bit unsigned integer value as an array of bytes.
        /// This API is not CLS-compliant. 
        /// </summary>
        /// <param name="array">The return array: byte[]</param>
        /// <param name="offset">Offset into the array</param>
        /// <param name="value">The number to convert.</param>
        public static void GetBytes(byte[] array, int offset, ushort value) {
            InsertValueIntoArray(array, offset, value);
        }

        /// <summary>
        /// Returns a 16-bit unsigned integer converted from two bytes at a specified position in a byte array.
        /// This API is not CLS-compliant. 
        /// </summary>
        /// <param name="value">An array of bytes.</param>
        /// <param name="startIndex">The starting position within value.</param>
        /// <returns>A 16-bit unsigned integer formed by two bytes beginning at startIndex.</returns>
        public static ushort ToUInt16(byte[] value, int startIndex) {
            return (ushort)Hardware.Utility.ExtractValueFromArray(value, startIndex, 2);
        }

        #endregion

        #region Int32

        /// <summary>
        /// Inserts a value at a specified position in a byte array.
        /// </summary>
        /// <param name="data">The array into which you want to insert the specified value.</param>
        /// <param name="startIndex">The position in the array where you want to insert the specified value.</param>
        /// <param name="value">The value you want to insert into the array.</param>
        public static void InsertValueIntoArray(byte[] data, int startIndex, int value) {
            Hardware.Utility.InsertValueIntoArray(data, startIndex, 4, (uint)value);
        }

        /// <summary>
        /// Returns the specified 32-bit signed integer value as an array of bytes.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 4.</returns>
        public static byte[] GetBytes(int value) {
            var array = new byte[4];
            InsertValueIntoArray(array, 0, value);
            return array;
        }

        /// <summary>
        /// Returns the specified 32-bit signed integer value as an array of bytes.
        /// </summary>
        /// <param name="array">The return array: byte[]</param>
        /// <param name="value">The number to convert.</param>
        public static void GetBytes(byte[] array, int value) {
            InsertValueIntoArray(array, 0, value);
        }

        /// <summary>
        /// Returns a 32-bit signed integer converted from four bytes at a specified position in a byte array.
        /// </summary>
        /// <param name="value">An array of bytes.</param>
        /// <param name="startIndex">The starting position within value.</param>
        /// <returns>A 32-bit signed integer formed by four bytes beginning at startIndex.</returns>
        public static int ToInt32(byte[] value, int startIndex) {
            return (int)Hardware.Utility.ExtractValueFromArray(value, startIndex, 4);
        }

        #endregion

        #region UInt32

        /// <summary>
        /// Inserts a value at a specified position in a byte array.
        /// </summary>
        /// <param name="data">The array into which you want to insert the specified value.</param>
        /// <param name="startIndex">The position in the array where you want to insert the specified value.</param>
        /// <param name="value">The value you want to insert into the array.</param>
        public static void InsertValueIntoArray(byte[] data, int startIndex, uint value) {
            Hardware.Utility.InsertValueIntoArray(data, startIndex, 4, value);
        }

        /// <summary>
        /// Returns the specified 32-bit unsigned integer value as an array of bytes.
        /// This API is not CLS-compliant. 
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 4.</returns>
        public static byte[] GetBytes(uint value) {
            var array = new byte[4];
            InsertValueIntoArray(array, 0, value);
            return array;
        }

        /// <summary>
        /// Returns the specified 32-bit unsigned integer value as an array of bytes.
        /// This API is not CLS-compliant. 
        /// </summary>
        /// <param name="array">The return array: byte[4]</param>
        /// <param name="value">The number to convert.</param>
        public static void GetBytes(byte[] array, uint value) {
            InsertValueIntoArray(array, 0, value);
        }

        /// <summary>
        /// Returns a 32-bit unsigned integer converted from four bytes at a specified position in a byte array.
        /// This API is not CLS-compliant. 
        /// </summary>
        /// <param name="value">An array of bytes.</param>
        /// <param name="startIndex">The starting position within value.</param>
        /// <returns>A 32-bit unsigned integer formed by four bytes beginning at startIndex.</returns>
        public static uint ToUInt32(byte[] value, int startIndex) {
            return Hardware.Utility.ExtractValueFromArray(value, startIndex, 4);
        }

        #endregion

        #region Int64

        /// <summary>
        /// Inserts a value at a specified position in a byte array.
        /// </summary>
        /// <param name="data">The array into which you want to insert the specified value.</param>
        /// <param name="startIndex">The position in the array where you want to insert the specified value.</param>
        /// <param name="value">The value you want to insert into the array.</param>
        public static void InsertValueIntoArray(byte[] data, int startIndex, long value) {
            var high = (uint)(value >> 32);
            var low = (uint)value;

            if (IsLittleEndian) {
                Hardware.Utility.InsertValueIntoArray(data, startIndex, 4, low);
                Hardware.Utility.InsertValueIntoArray(data, startIndex + 4, 4, high);
            }
            else {
                Hardware.Utility.InsertValueIntoArray(data, startIndex, 4, high);
                Hardware.Utility.InsertValueIntoArray(data, startIndex + 4, 4, low);
            }
        }

        /// <summary>
        /// Returns the specified 64-bit signed integer value as an array of bytes.
        /// </summary>
        /// <param name="value">The number to convert. </param>
        /// <returns>An array of bytes with length 8.</returns>
        public static byte[] GetBytes(long value) {
            var array = new byte[8];
            InsertValueIntoArray(array, 0, value);
            return array;
        }

        /// <summary>
        /// Returns the specified 64-bit signed integer value as an array of bytes.
        /// </summary>
        /// <param name="array">The return array: byte[8]</param>
        /// <param name="value">The number to convert. </param>
        public static void GetBytes(byte[] array, long value) {
            InsertValueIntoArray(array, 0, value);
        }
        /// <summary>
        /// Returns a 64-bit signed integer converted from eight bytes at a specified position in a byte array.
        /// </summary>
        /// <param name="value">An array of bytes.</param>
        /// <param name="startIndex">The starting position within value.</param>
        /// <returns>A 64-bit signed integer formed by eight bytes beginning at startIndex.</returns>
        public static long ToInt64(byte[] value, int startIndex) {
            var value0 = (ulong)Hardware.Utility.ExtractValueFromArray(value, startIndex, 4);
            var value1 = (ulong)Hardware.Utility.ExtractValueFromArray(value, startIndex + 4, 4);

            if (IsLittleEndian) {
                return (long)(value1 << 32 | value0);
            }
            else {
                return (long)(value0 << 32 | value1);
            }
        }

        #endregion

        #region UInt64

        /// <summary>
        /// Inserts a value at a specified position in a byte array.
        /// </summary>
        /// <param name="data">The array into which you want to insert the specified value.</param>
        /// <param name="startIndex">The position in the array where you want to insert the specified value.</param>
        /// <param name="value">The value you want to insert into the array.</param>
        public static void InsertValueIntoArray(byte[] data, int startIndex, ulong value) {
            var high = (uint)(value >> 32);
            var low = (uint)value;

            if (IsLittleEndian) {
                Hardware.Utility.InsertValueIntoArray(data, startIndex, 4, low);
                Hardware.Utility.InsertValueIntoArray(data, startIndex + 4, 4, high);
            }
            else {
                Hardware.Utility.InsertValueIntoArray(data, startIndex, 4, high);
                Hardware.Utility.InsertValueIntoArray(data, startIndex + 4, 4, low);
            }
        }

        /// <summary>
        /// Returns the specified 64-bit unsigned integer value as an array of bytes.
        /// This API is not CLS-compliant. 
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 8.</returns>
        public static byte[] GetBytes(ulong value) {
            var array = new byte[8];
            InsertValueIntoArray(array, 0, value);
            return array;
        }

        /// <summary>
        /// Returns the specified 64-bit unsigned integer value as an array of bytes.
        /// This API is not CLS-compliant. 
        /// </summary>
        /// <param name="array">The return array: byte[8]</param>
        /// <param name="value">The number to convert.</param>
        public static void GetBytes(byte[] array, ulong value) {
            InsertValueIntoArray(array, 0, value);
        }

        /// <summary>
        /// Returns a 64-bit unsigned integer converted from eight bytes at a specified position in a byte array.
        /// This API is not CLS-compliant. 
        /// </summary>
        /// <param name="value">An array of bytes.</param>
        /// <param name="startIndex">The starting position within value.</param>
        /// <returns>A 64-bit unsigned integer formed by the eight bytes beginning at startIndex.</returns>
        public static ulong ToUInt64(byte[] value, int startIndex) {
            var value0 = (ulong)Hardware.Utility.ExtractValueFromArray(value, startIndex, 4);
            var value1 = (ulong)Hardware.Utility.ExtractValueFromArray(value, startIndex + 4, 4);

            if (IsLittleEndian) {
                return value1 << 32 | value0;
            }
            else {
                return value0 << 32 | value1;
            }
        }

        #endregion

        #region Single

        /// <summary>
        /// Inserts a value at a specified position in a byte array.
        /// </summary>
        /// <param name="data">The array into which you want to insert the specified value.</param>
        /// <param name="startIndex">The position in the array where you want to insert the specified value.</param>
        /// <param name="value">The value you want to insert into the array.</param>
        public static void InsertValueIntoArray(byte[] data, int startIndex, float value) {
            unsafe {
                var buffer = *((uint*)&value);
                Hardware.Utility.InsertValueIntoArray(data, startIndex, 4, buffer);
            }
        }

        /// <summary>
        /// Returns the specified single-precision floating point value as an array of bytes.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 4.</returns>
        public static byte[] GetBytes(float value) {
            var array = new byte[4];
            InsertValueIntoArray(array, 0, value);
            return array;
        }

        /// <summary>
        /// Returns the specified single-precision floating point value as an array of bytes.
        /// </summary>
        ///<param name="array">The return array: byte[4]</param>
        /// <param name="value">The number to convert.</param>
        public static void GetBytes(byte[] array, float value) {
            InsertValueIntoArray(array, 0, value);
        }

        /// <summary>
        /// Returns a single-precision floating point number converted from four bytes at a specified position in a byte array.
        /// </summary>
        /// <param name="value">An array of bytes.</param>
        /// <param name="startIndex">The starting position within value.</param>
        /// <returns>A single-precision floating point number formed by four bytes beginning at startIndex.</returns>
        public static float ToSingle(byte[] value, int startIndex) {
            var result = Hardware.Utility.ExtractValueFromArray(value, startIndex, 4);
            unsafe {
                return *((float*)&result);
            }
        }

        #endregion

        #region Double

        /// <summary>
        /// Inserts a value at a specified position in a byte array.
        /// </summary>
        /// <param name="data">The array into which you want to insert the specified value.</param>
        /// <param name="startIndex">The position in the array where you want to insert the specified value.</param>
        /// <param name="value">The value you want to insert into the array.</param>
        public static void InsertValueIntoArray(byte[] data, int startIndex, double value) {
            unsafe {
                var buffer = *((ulong*)&value);
                InsertValueIntoArray(data, startIndex, buffer);
            }
        }

        /// <summary>
        /// Returns the specified double-precision floating point value as an array of bytes.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>An array of bytes with length 8.</returns>
        public static byte[] GetBytes(double value) {
            var array = new byte[8];
            InsertValueIntoArray(array, 0, value);
            return array;
        }

        /// <summary>
        /// Returns the specified double-precision floating point value as an array of bytes.
        /// </summary>
        /// <param name="array">The return array: byte[8]</param>
        /// <param name="value">The number to convert.</param>
        public static void GetBytes(byte[] array, double value) {
            InsertValueIntoArray(array, 0, value);
        }

        /// <summary>
        /// Returns a double-precision floating point number converted from eight bytes at a specified position in a byte array.
        /// </summary>
        /// <param name="value">An array of bytes.</param>
        /// <param name="startIndex">The starting position within value.</param>
        /// <returns>A double precision floating point number formed by eight bytes beginning at startIndex.</returns>
        public static double ToDouble(byte[] value, int startIndex) {
            var result = ToUInt64(value, startIndex);
            unsafe {
                return *((double*)&result);
            }
        }


        /// <summary>
        /// Converts the specified double-precision floating point number to a 64-bit signed integer.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>A 64-bit signed integer whose value is equivalent to value.</returns>
        public static long DoubleToInt64Bits(double value) {
            unsafe {
                return *((long*)&value);
            }
        }

        /// <summary>
        /// Converts the specified 64-bit signed integer to a double-precision floating point number.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>A double-precision floating point number whose value is equivalent to value.</returns>
        public static double Int64BitsToDouble(long value) {
            unsafe {
                return *((double*)&value);
            }
        }

        #endregion

    }
}