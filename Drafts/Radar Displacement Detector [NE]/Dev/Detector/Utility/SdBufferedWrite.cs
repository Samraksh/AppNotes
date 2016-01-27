/*=========================
 * eMote SD Buffered Write class
 *  Buffers data and writes to SD when full
 * Versions
 *  1.0 Initial Version
=========================*/

using System;
using System.Text;
using Microsoft.SPOT;
using Samraksh.eMote.DotNow;


namespace Samraksh.Appnote.Utility
{
	/// <summary>
	/// Buffer data and write to SD when full
	/// </summary>
	/// <remarks>
	/// The SD driver has the property that each SD.Write causes a whole SD block to write; typically 512 bytes.
	///		If the array argument to the method is shorter, the rest of the block is filled with garbage.
	/// Similarly, each SD.Read reads a whole SD block and fills the array argument. If the array is shorter than the block size, the rest of the block is ignored.
	///		Hence SD Read and Write should both use the same array size, which does not have to equal the SD block size.
	/// This class avoids wasted space by packing the 
	/// </remarks>
	/// <remarks>
	/// This is a version of the singleton pattern. 
	/// A static field, _initialized, is used to indicate whether an instance has been created or now.
	/// It is set by the constructor and unset by the descructor.
	/// </remarks>
	public class SDBufferedWrite
	{
		// Static field to indicate whether the class has been initialized or not.
		private static bool _initialized;

		private readonly ushort _bufferSize;
		private readonly byte _eof;
		private readonly byte[] _buffer;
		private int _nextByte;

		/// <summary>Custom exception for the class</summary>
		public class SDBufferedWriteException : Exception
		{
			/// <summary>Constructor for the custom exception</summary>
			/// <param name="descrip"></param>
			public SDBufferedWriteException(string descrip) : base(descrip) { }
		}

		/// <summary>
		/// Number of buffers written
		/// </summary>
		public int BuffersWritten;

		/// <summary>
		/// Construct the instance
		/// </summary>
		/// <remarks>There can only be one instance since there is only one SD</remarks>
		/// <param name="bufferSize"></param>
		/// <param name="eof"></param>
		public SDBufferedWrite(ushort bufferSize, byte eof)
		{
			if (_initialized)
			{
				throw new SDBufferedWriteException("Cannot instantiate twice");
			}
			_initialized = true;

			_bufferSize = bufferSize;
			_buffer = new byte[bufferSize];
			_eof = eof;
		}

		/// <summary>
		/// Destructor
		/// </summary>
		/// <remarks>Marks the class as uninitialized</remarks>
		~SDBufferedWrite()
		{
			_initialized = false;
		}

		/// <summary>
		/// Write to SD
		/// </summary>
		/// <param name="dataArray"></param>
		/// <param name="offset"></param>
		/// <param name="length"></param>
		/// <remarks>
		/// Packs argument array into buffer and writes when full.
		/// Buffer is fully packed so that no junk is introduced.
		/// </remarks>
		public void Write(byte[] dataArray, ushort offset, ushort length)
		{
			if (_bufferSize == 0)
			{
				throw new ApplicationException("SD Buffered Write is uninitialized");
			}
			for (var i = 0; i < length; i++)
			{
				if (_nextByte >= _bufferSize)
				{
					Flush();
				}
				_buffer[_nextByte++] = dataArray[i];
			}
		}

		/// <summary>
		/// Flush the buffer by writing to SD
		/// </summary>
		public void Flush()
		{
			// If buffer is empty, nothing to do
			if (_nextByte == 0)
			{
				return;
			}
			// Fill it up with Eof
			for (var i = _nextByte; i < _bufferSize; i++)
			{
				_buffer[i] = _eof;
			}
			// Write the buffer
			SD.Write(_buffer, 0, _bufferSize);
			BuffersWritten++;
			_nextByte = 0;

			// Optional debugging output
			if (BuffersWritten != 1) { return; }
			var valsStr = new StringBuilder('\t');
			for (var i = 0; i < _bufferSize; i++)
			{
				valsStr.Append(_buffer[i]);
				valsStr.Append('\t');
			}
			Debug.Print(valsStr.ToString());
		}
	}
}
