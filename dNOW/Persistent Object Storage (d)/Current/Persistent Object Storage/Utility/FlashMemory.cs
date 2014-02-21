using System;
using Microsoft.SPOT;

using NVM = Samraksh.SPOT.NonVolatileMemory;
using EDN = Samraksh.SPOT.Hardware.EmoteDotNow;

namespace Samraksh {
    namespace AppNote {
        namespace Utility {
            namespace FlashMemory {

                /// <summary>
                /// Manage eMote .NOW on-board NOR flash
                /// </summary>
                //public class DataStorage {

                //    //public const uint NorSize = 12*1024*1024;

                //    //public int bytesWritten = 0;
                //    public static int readCounter = 0;

                //    //public ushort[] verfier = new ushort[1024];
                //    //public byte[] verfierDS = new byte[1024];

                //    private NVM.Data[] dataRefArray;
                //    private NVM.DataStore dStore;
                //    private NVM.Data dataDS;

                //    private Type dataType = typeof (ushort);

                //    public DataStorage() {
                //        dStore = new NVM.DataStore((int) NVM.StorageType.NOR);
                //        }

                //    public NVM.DataStatus EraseAll() {
                //        return NVM.DataStore.EraseAll();
                //    }

                //    public bool Write(ushort[] data, UInt16 length) {
                //        dataDS = new NVM.Data(dStore, (uint) data.Length, dataType);
                //        if (dataDS.Write(data, (uint) data.Length) == NVM.DataStatus.Success) {
                //            return true;
                //        }
                //        Debug.Print("Write to NOR failed\n");
                //        return false;
                //    }

                //    public bool Write(byte[] data, UInt16 length) {
                //        return !SPOT.Hardware.EmoteDotNow.NOR.IsFull();
                //    }

                //    public ushort[] Read(int readIndex, int bufferSize) {
                //        if (readCounter == 0) {
                //            dataRefArray = new NVM.Data[dStore.CountOfDataIds()];
                //            dStore.ReadAllDataReferences(dataRefArray, 0); //Get the data references into dataRefArray.
                //            ++readCounter;
                //        }

                //        ushort[] readBuffer = new ushort[bufferSize];
                //        if (readIndex <= (dStore.CountOfDataIds() - 1)) {
                //            if ((dataRefArray[readIndex].Read(readBuffer, 0, (uint) readBuffer.Length)) !=
                //                NVM.DataStatus.Success) {
                //                Debug.Print("Read from NOR failed during verification\n");
                //            }
                //        }
                //        return readBuffer;
                //    }


                //    public bool WriteEof(uint bufferSize) {
                //        ushort[] eof = new ushort[bufferSize];

                //        for (UInt16 i = 0; i < eof.Length; i++) {
                //            eof[i] = 0x0c0c;
                //        }

                //        dataDS = new NVM.Data(dStore, (uint) eof.Length, dataType);
                //        return dataDS.Write(eof, (uint) eof.Length) == NVM.DataStatus.Success;
                //    }
                //}

            }
        }
    }
}