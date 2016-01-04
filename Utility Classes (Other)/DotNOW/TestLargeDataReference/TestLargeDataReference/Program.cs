using System;
using System.Threading;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.NonVolatileMemory;

namespace TestLargeDataStore {

    /// <summary>
    /// The test program class
    /// </summary>
    public class Program {

        private const int DataStoreBlockSize = 128 * 1024;
        private const int DataStoreBlocks = 125;


        private const int BufferSize = 256;
        private const int LargeDataStoreReferenceSize = (DataStoreBlockSize / 2) / sizeof(UInt16);
        private const int Iterations = (LargeDataStoreReferenceSize / BufferSize) * DataStoreBlocks;
        //private const int Iterations = 1000;

        private static readonly UInt16[] Buffer = new UInt16[BufferSize];
        private static readonly DataStore DStore = DataStore.Instance(StorageType.SD, true);
        private static readonly LargeDataReference LargeDataRef = new LargeDataReference(DStore, LargeDataStoreReferenceSize);

        private static UInt16 _lastWriteVal;

        private static DataStoreReturnStatus _retVal;


        /// <summary>
        /// The test program
        /// </summary>
        public static void Main() {
            Debug.Print("\nTest LargeDataReference");
            Debug.Print("  Buffer size: " + BufferSize);
            Debug.Print("  LargeDataStoreReference size: " + LargeDataStoreReferenceSize);
            Debug.Print("  Iterations: " + Iterations);
            Debug.Print("");

            Thread.Sleep(5000);

            //DStore.DeleteAllData();

            unchecked {
                for (var i = 0; i < Iterations; i++) {
                    for (var j = 0; j < Buffer.Length; j++) {
                        _lastWriteVal = (UInt16)(i * Buffer.Length + j + 1);
                        Buffer[j] = _lastWriteVal;
                    }
                    if ((_retVal = LargeDataRef.Write(Buffer)) != DataStoreReturnStatus.Success) {
                        Debug.Print("Write error i: " + i + ", return value " + _retVal);
                    }
                    Debug.Print("Write " + i + ", " + Buffer[0]);
                }
            }

            if ((_retVal = LargeDataRef.Flush(0)) != DataStoreReturnStatus.Success) { Debug.Print("Error flushing. Return value: " + _retVal); }

            UInt16 compVal = 1;
            var lastVal = UInt16.MaxValue;

            if ((_retVal = LargeDataRef.InitializeRead()) != DataStoreReturnStatus.Success) { Debug.Print("Error InitializeRead. Return value: " + _retVal); }
            while (true) {
                LargeDataReference.ReturnStatus retValL;
                if ((retValL = LargeDataRef.ReadNext(Buffer)) != LargeDataReference.ReturnStatus.Success) {
                    if (retValL == LargeDataReference.ReturnStatus.NoMoreData) { break; }
                    Debug.Print("Error ReadNext: " + retValL);
                }
                Debug.Print("Read " + Buffer[0]);
                if (Buffer[0] <= 0) { continue; }
                unchecked {
                    for (var l = 0; l < Buffer.Length; l++) {
                        lastVal = Buffer[l];
                        if (lastVal != compVal) {
                            Debug.Print("Read back error: Read " + lastVal + ", s/b " + compVal);
                        }
                        compVal++;
                    }
                }
            }

            if (lastVal != _lastWriteVal) {
                Debug.Print("\nError: Mismatch between values. Last read: " + lastVal + "; max written: " + _lastWriteVal);
            }
            else {
                Debug.Print("\nSuccess: Values read = values written");
            }
            Debug.Print("\n-------------------------------------------------------------------\n");
        }

    }
}
