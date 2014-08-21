using Microsoft.SPOT;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;
using Samraksh.eMote.NonVolatileMemory;

namespace Samraksh.Library.DataCollector.Radar {
    public partial class Program {

        private static bool CopyToSD() {
            try {
                var sdBytes = new byte[BufferSize * sizeof(ushort)];

                Debug.Print("Starting copy to SD");
                EnhancedLcd.Display(LCDMessages.TransferingToSD);

                var buffer = ADCBufferI;
                if ((_retVal = LargeDataRef.InitializeRead()) != DataStoreReturnStatus.Success) {
                    Debug.Print("Error LargeDataReference.InitializeRead. Return value: " + _retVal);
                    return false;
                }

                //// First ushort (2 bytes) is the sampling interval in microseconds
                //Debug.Print("   Writing sample interval");
                //var sampleIntervalMicroSec = BitConverter.GetBytes((ushort)SampleIntervalMicroSec);
                //if (!SD.Write(sampleIntervalMicroSec, 0, (ushort)sampleIntervalMicroSec.Length)) {
                //    return false;
                //}

                Debug.Print("   Writing data");
                var bufferCnt = 0;
                while (true) {
                    LargeDataReference.ReturnStatus retValL;
                    if ((retValL = LargeDataRef.ReadNext(buffer)) != LargeDataReference.ReturnStatus.Success) {
                        if (retValL == LargeDataReference.ReturnStatus.NoMoreData) {
                            break;
                        }
                        Debug.Print("Error LargeDataReference.ReadNext: " + retValL);
                        return false;
                    }
                    // If zero values, done
                    if (buffer[0] == 0) {
                        break;
                    }

                    // Copy to SD
                    for (var i = 0; i < buffer.Length; i++) {
                        BitConverter.GetBytes(sdBytes, i << 1, buffer[i]);
                        //var j = i << 1; // Multiply by 2
                        //sdBytes[j] = (byte)buffer[i];
                        //sdBytes[j + 1] = (byte)((buffer[i] >> 8) & 0xff);
                    }
                    if (!SD.Write(sdBytes, 0, (ushort)sdBytes.Length)) {
                        return false;
                    }
                    // Print first and last values
                    Debug.Print(bufferCnt++ + " I: " + buffer[0] + ", Q: " + buffer[1] 
                        + " / I: " + buffer[buffer.Length - 2] + ", Q: " + buffer[buffer.Length - 1]);
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
