/*=========================
 * Insert Value Into Array Class
 * Versions
 *  1.0 Initial Version
 ========================*/

using System;
using Hardware = Microsoft.SPOT.Hardware;

namespace Samraksh.AppNote.Utility
{

	/// <summary>
	/// Inserts base types into an array of bytes.
	/// </summary>
	/// <remarks>
	///		Useful for building up byte arrays to be stored (DataStore) or sent (radio, serial, ...)
	///		For Micro Framework, avoids unnecessary impact on the heap. The byte array can be a pre-defined static member and messages built by calls to Insert methods.
	/// </remarks>
	public static class InsertValueIntoArray
	{
		/// <summary>
		/// Inserts a bool at a specified position in a byte array.
		/// </summary>
		/// <param name="data">The array into which you want to insert the specified value.</param>
		/// <param name="startIndex">The position in the array where you want to insert the specified value.</param>
		/// <param name="value">The value you want to insert into the array.</param>
		public static void Insert(byte[] data, int startIndex, bool value)
		{
			Hardware.Utility.InsertValueIntoArray(data, startIndex, 1, value ? 1u : 0u);
		}

		/// <summary>
		/// Inserts a char at a specified position in a byte array.
		/// </summary>
		/// <param name="data">The array into which you want to insert the specified value.</param>
		/// <param name="startIndex">The position in the array where you want to insert the specified value.</param>
		/// <param name="value">The value you want to insert into the array.</param>
		public static void Insert(byte[] data, int startIndex, char value)
		{
			Hardware.Utility.InsertValueIntoArray(data, startIndex, 2, value);
		}
		
		/// <summary>
		/// Inserts a short at a specified position in a byte array.
		/// </summary>
		/// <param name="data">The array into which you want to insert the specified value.</param>
		/// <param name="startIndex">The position in the array where you want to insert the specified value.</param>
		/// <param name="value">The value you want to insert into the array.</param>
		public static void Insert(byte[] data, int startIndex, short value)
		{
			Hardware.Utility.InsertValueIntoArray(data, startIndex, 2, (uint)value);
		}

		/// <summary>
		/// Inserts a ushort at a specified position in a byte array.
		/// </summary>
		/// <param name="data">The array into which you want to insert the specified value.</param>
		/// <param name="startIndex">The position in the array where you want to insert the specified value.</param>
		/// <param name="value">The value you want to insert into the array.</param>
		public static void Insert(byte[] data, int startIndex, ushort value)
		{
			Hardware.Utility.InsertValueIntoArray(data, startIndex, 2, (uint)value);
		}
		
		/// <summary>
		/// Inserts an int at a specified position in a byte array.
		/// </summary>
		/// <param name="data">The array into which you want to insert the specified value.</param>
		/// <param name="startIndex">The position in the array where you want to insert the specified value.</param>
		/// <param name="value">The value you want to insert into the array.</param>
		public static void Insert(byte[] data, int startIndex, int value)
		{
			Hardware.Utility.InsertValueIntoArray(data, startIndex, 4, (uint)value);
		}

		/// <summary>
		/// Inserts a uint at a specified position in a byte array.
		/// </summary>
		/// <param name="data">The array into which you want to insert the specified value.</param>
		/// <param name="startIndex">The position in the array where you want to insert the specified value.</param>
		/// <param name="value">The value you want to insert into the array.</param>
		public static void Insert(byte[] data, int startIndex, uint value)
		{
			Hardware.Utility.InsertValueIntoArray(data, startIndex, 4, value);
		}

		/// <summary>
		/// Inserts a long at a specified position in a byte array.
		/// </summary>
		/// <param name="data">The array into which you want to insert the specified value.</param>
		/// <param name="startIndex">The position in the array where you want to insert the specified value.</param>
		/// <param name="value">The value you want to insert into the array.</param>
		public static void Insert(byte[] data, int startIndex, long value)
		{
			var high = (uint)(value >> 32);
			var low = (uint)value;

			if (BitConverter.IsLittleEndian)
			{
				Hardware.Utility.InsertValueIntoArray(data, startIndex, 4, low);
				Hardware.Utility.InsertValueIntoArray(data, startIndex + 4, 4, high);
			}
			else
			{
				Hardware.Utility.InsertValueIntoArray(data, startIndex, 4, high);
				Hardware.Utility.InsertValueIntoArray(data, startIndex + 4, 4, low);
			}
		}

		/// <summary>
		/// Inserts a ulong at a specified position in a byte array.
		/// </summary>
		/// <param name="data">The array into which you want to insert the specified value.</param>
		/// <param name="startIndex">The position in the array where you want to insert the specified value.</param>
		/// <param name="value">The value you want to insert into the array.</param>
		public static void Insert(byte[] data, int startIndex, ulong value)
		{
			var high = (uint)(value >> 32);
			var low = (uint)value;

			if (BitConverter.IsLittleEndian)
			{
				Hardware.Utility.InsertValueIntoArray(data, startIndex, 4, low);
				Hardware.Utility.InsertValueIntoArray(data, startIndex + 4, 4, high);
			}
			else
			{
				Hardware.Utility.InsertValueIntoArray(data, startIndex, 4, high);
				Hardware.Utility.InsertValueIntoArray(data, startIndex + 4, 4, low);
			}
		}
		
		/// <summary>
		/// Inserts a float at a specified position in a byte array.
		/// </summary>
		/// <param name="data">The array into which you want to insert the specified value.</param>
		/// <param name="startIndex">The position in the array where you want to insert the specified value.</param>
		/// <param name="value">The value you want to insert into the array.</param>
		public static void Insert(byte[] data, int startIndex, float value)
		{
			unsafe
			{
				var buffer = *((uint*)&value);
				Hardware.Utility.InsertValueIntoArray(data, startIndex, 4, buffer);
			}
		}

		/// <summary>
		/// Inserts a double at a specified position in a byte array.
		/// </summary>
		/// <param name="data">The array into which you want to insert the specified value.</param>
		/// <param name="startIndex">The position in the array where you want to insert the specified value.</param>
		/// <param name="value">The value you want to insert into the array.</param>
		public static void Insert(byte[] data, int startIndex, double value)
		{
			unsafe
			{
				var buffer = *((ulong*)&value);
				Insert(data, startIndex, buffer);
			}
		}
	}
}

