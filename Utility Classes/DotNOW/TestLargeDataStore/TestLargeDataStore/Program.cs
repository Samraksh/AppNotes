using System;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;
using Samraksh.eMote.NonVolatileMemory;

namespace TestLargeDataStore {
    public class Program {

        private static readonly UInt16[] Buffer = new UInt16[128];
        private static readonly DataStore DStore = DataStore.Instance(StorageType.SD);
        private static readonly LargeDataStoreReference LargeDataRef = new LargeDataStoreReference(DStore, Buffer.Length);

        public static void Main() {
            Debug.Print("Test LargeDataStoreReference");

            DStore.DeleteAllData();

            for (var i = 0; i < 3; i++) {
                for (var j = 0; j < Buffer.Length; j++) {
                    Buffer[j] = (UInt16)(i * Buffer.Length + j + 1);
                }
                if (LargeDataRef.Write(Buffer) != DataStoreReturnStatus.Success) {
                    Debug.Print("Write error i:" + i);
                }
            }

            LargeDataRef.Flush();

            var compVal = 1;
            var dataRefCnt = 0;
            var dataRefs = new DataReference[5];
            while (true) {
                if (DStore.ReadAllDataReferences(dataRefs, dataRefCnt) != DataStoreReturnStatus.Success) {
                    Debug.Print("Error reading data references");
                }
                dataRefCnt += dataRefs.Length;
                foreach (var dataRef in dataRefs) {
                    if (dataRef == null) { goto next; }
                    for (var k = 0; k < LargeDataRef.BufferSize; k += Buffer.Length) {
                        if (dataRef.Read(Buffer, k * Buffer.Length, Buffer.Length) != DataStoreReturnStatus.Success) {
                            Debug.Print("Error reading from data reference");
                        }
                        for (var l = 0; l < Buffer.Length; l++) {
                            var readVal = Buffer[l];
                            if (readVal != compVal) {
                                Debug.Print("Read back error: Read " + readVal + ", s/b " + compVal);
                            }
                            compVal++;
                        }
                    }
                }
            }
        next:

            ;
        }

    }
}
