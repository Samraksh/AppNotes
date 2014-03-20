using System;
using Microsoft.SPOT;
using Samraksh.SPOT.NonVolatileMemory;

namespace DataStoreExample {
    public static class AltProgram {
        // Rename this to Main
        /// <summary>
        /// Demonstrate DataStore
        /// </summary>
        /// <remarks>
        /// 1. Initialize DataStore
        /// 2. Create and write two data allocations of different types
        /// 3. Update one allocation.
        /// 4. Delete one allocation.
        /// 5. Recover existing allocations and references.
        /// Note: For simplicity, does not test return values from DataStore and Datareference methods.
        /// </remarks>
        public static void MainX() {
            // Initialize the DataStore
            DataStore.DeleteAllData();  // Not static method

            // Create the Datastore instance
            var ds = DataStore.Instance(StorageType.NOR);

            var uintData = new uint[] { 1, 0 };
            var byteData = new byte[] { 2, 0 };

            // Define two new data references; doing this also creates data allocations in DataStore
            var dr1 = new DataReference(ds, typeof(uint));
            var dr2 = new DataReference(ds, typeof(byte));

            // Write first data reference
            uintData[1] = 10;
            dr1.Write(uintData, uintData.Length);

            // Write second data reference
            byteData[1] = 20;
            dr2.Write(byteData, byteData.Length);

            Debug.Print("Values written. Reference 1: " + uintData[0] + ", " + uintData[1] + "; Reference 2: " + byteData[0] + ", " + byteData[1]);

            // Check values after write
            uintData[1] = 0;
            dr1.Read(uintData, 0, uintData.Length);

            byteData[1] = 0;
            dr2.Read(byteData, 0, byteData.Length);

            Debug.Print("Values read after write. Reference 1: " + uintData[0] + ", " + uintData[1] + "; Reference 2: " + byteData[0] + ", " + byteData[1]);

            // Update first data reference
            uintData[1] = 21;
            dr1.Write(uintData, uintData.Length);

            // Check values after update
            uintData[1] = 0;
            dr1.Read(uintData, 0, uintData.Length);

            byteData[1] = 0;
            dr2.Read(byteData, 0, byteData.Length);

            Debug.Print("Values read after update. Reference 1: " + uintData[0] + ", " + uintData[1] + "; Reference 2: " + byteData[0] + ", " + byteData[1]);

            // Delete first data reference
            dr1.Delete();

            // Release existing references ... they will be invalid after ReadAllDataReferences
            dr1 = dr2 = null;

            // Read data references from flash
            var fromFlash = new DataReference[1];   // This can be any size
            Debug.Print("\n Recover references from DataStore");
            var offset = 0;
            while (true) {
                // Fill array with data references, starting from given offset
                ds.ReadAllDataReferences(fromFlash, offset);
                // Increment the offset
                offset += fromFlash.Length;
                // Get all the data references returned
                foreach (var reference in fromFlash) {
                    // If we find null, we're done
                    if ((reference) == null) { goto breakout; }
                    // Get the data
                    reference.Read(byteData, 0, byteData.Length);
                    Debug.Print("Values recovered from DataStore: " + byteData[0] + ", " + byteData[1]);
                }
            }
        breakout:
            Debug.Print("\n Finished");
        }
    }
}
