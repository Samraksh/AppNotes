using Microsoft.SPOT;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;
using Samraksh.eMote.NonVolatileMemory;

namespace Samraksh.AppNote.DataCollector.Radar {
    public partial class Program {

        /// <summary>
        /// Copy DataStore data to the SD card
        /// </summary>
        /// <returns>True iff the copy succeeded</returns>
        private static bool CopyToSD() {
            try {
                // Byte buffer to hold the data to write to the SD card
                var sdBytes = new byte[ADCBufferSize * sizeof(ushort)];

                Debug.Print("Starting copy to SD");
                EnhancedLcd.Display(LCDMessages.TransferingToSD);

                // Reuse the ADC buffer
                var buffer = ADCBuffer;

                // Initialize the LargeDataReference
                //  This causes reads to start from the beginning
                if ((_retVal = LargeDataRef.InitializeRead()) != DataStoreReturnStatus.Success) {
                    Debug.Print("Error LargeDataReference.InitializeRead. Return value: " + _retVal);
                    return false;
                }

                Debug.Print("   Writing data");

                // Keep track of the number of buffers
                var bufferCnt = 0;

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
                        break;
                    }

                    // Convert the samples to a byte array
                    for (var i = 0; i < buffer.Length; i++) {
                        // Convert a sample to a pair of bytes
                        //  Note the "i << 1". This is a fast way to multiply by 2.
                        BitConverter.GetBytes(sdBytes, i << 1, buffer[i]);
                    }
                    // Write to the SD card. If not successful, return failure
                    if (!SD.Write(sdBytes, 0, (ushort) sdBytes.Length)) {
                        return false;
                    }
                    // Print first and last values in the buffer
                    if (_debuggerIsAttached) {
                        Debug.Print(bufferCnt++ + " " + buffer[0] + " / " + buffer[buffer.Length - 1]);
                    }
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
