using Microsoft.SPOT;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;
using Samraksh.eMote.NonVolatileMemory;

namespace Samraksh.AppNote.DataCollector.Radar {
	public partial class Program {

		// Keep track of the number of buffers
		private static int _buffersCopiedCtr;

		/// <summary>
		/// Copy DataStore data to the SD card
		/// </summary>
		/// <returns>True iff the copy succeeded</returns>
		private static bool CopyToSD() {
			try {
				// Byte buffer to hold the data to write to the SD card
				var sdBytes = new byte[ADCBufferSize * sizeof(ushort)];

				Debug.Print("Starting copy to SD");
				EnhancedLcd.Write(LCDMessages.TransferingToSD);

				// Reuse the ADC I buffer
				var buffer = ADCBufferI;

				// Initialize the LargeDataReference
				//  This causes reads to start from the beginning
				if ((_retVal = LargeDataRef.InitializeRead()) != DataStoreReturnStatus.Success) {
					Debug.Print("Error LargeDataReference.InitializeRead. Return value: " + _retVal);
					return false;
				}

				Debug.Print("Writing data");

				// Keep track of the number of buffers

				while (true) {
					LargeDataReference.ReturnStatus retValL;
					// Try to read the next buffer's worth of data
					//  If success, keep on
					if ((retValL = LargeDataRef.ReadNext(buffer)) != LargeDataReference.ReturnStatus.Success) {
						// If we've reached the end of the data, we're done
						if (retValL == LargeDataReference.ReturnStatus.NoMoreData) {
							break;
						}
						// Otherwise, something went wrong
						Debug.Print("Error LargeDataReference.ReadNext: " + retValL);
						return false;
					}
					// If zero values, we're done
					if (buffer[0] == 0) {
						Debug.Print("Zero value found at beginning of buffer");
						break;
					}

					// Convert the samples to a byte array
					for (var i = 0; i < buffer.Length; i++) {
						// Convert a sample to a pair of bytes
						//  Note the "i << 1". This is a fast way to multiply by 2.
						//	Meaning: put the ushort at buffer[i] to a pair of bytes beginning at sdBytes[i*2]
						BitConverter.GetBytes(sdBytes, i << 1, buffer[i]);
					}
					// Write to the SD card. If not successful, return failure
					if (!SD.Write(sdBytes, 0, (ushort)sdBytes.Length)) {
						Debug.Print("Error writing to SD card");
						return false;
					}
					// Print first and last values in the buffer
					Debug.Print("\t" + _buffersCopiedCtr + " I: " + buffer[0] + ", Q: " + buffer[1]
								+ " / I: " + buffer[buffer.Length - 2] + ", Q: " + buffer[buffer.Length - 1]);
					_buffersCopiedCtr++;	// We're inputting buffers of I-Q pairs from DataStore so only count by buffers by 1.
				}

				// Write EOF and quit
				for (var i = 0; i < sdBytes.Length; i++) {
					sdBytes[i] = Eof;
				}
				return SD.Write(sdBytes, 0, (ushort)sdBytes.Length);
			}
			finally {
				Debug.Print("");
			}
		}
	}
}
