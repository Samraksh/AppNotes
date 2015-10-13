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
	/// Similarly, each SD.Read reads a whole SD block and fills the array argument. The rest of the block is ignored.
	/// Hence SD Read and Write should both use the same array size, which does not have to equal the SD block size.
	/// </remarks>
	public static class SdBufferedWrite {
		private static ushort _bufferSize;
		private static byte _eof;
		private static  byte[] _buffer;
		private static int _nextByte;

		/// <summary>
		/// Number of buffers written
		/// </summary>
		public static int BuffersWritten = 0;

		/// <summary>
		/// Initialize buffering
		/// </summary>
		/// <param name="bufferSize"></param>
		/// <param name="eof"></param>
		public static void Init(ushort bufferSize, byte eof) {
			_bufferSize = bufferSize;
			_buffer = new byte[bufferSize];
			_eof = eof;
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
		public static void Write(byte[] dataArray, ushort offset, ushort length)
		{
			if (_bufferSize == 0) {
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
		public static void Flush()
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

			if (BuffersWritten == 1) {
				var valsStr = new StringBuilder('\t');
				for (var i = 0; i < _bufferSize; i++) {
					valsStr.Append(_buffer[i]);
					valsStr.Append('\t');
				}
				Debug.Print(valsStr.ToString());
			}
		}
	}
}
