using System;
using Microsoft.SPOT;

using NVM = Samraksh.SPOT.NonVolatileMemory;
using EDN = Samraksh.SPOT.Hardware.EmoteDotNow;

namespace Samraksh {
    namespace AppNote {
        namespace Utility {
            namespace FlashMemory {

                ///// <summary>
                ///// Define the interface for a FlashMemory class
                ///// </summary>
                //public abstract class FlashMemory {
                //    /// <summary>
                //    /// Write ushort array to flash
                //    /// </summary>
                //    /// <param name="data">Data array to write</param>
                //    /// <param name="length">Number of data items to write</param>
                //    /// <returns>True iff write was successful</returns>
                //    public abstract bool Write(ushort[] data, UInt16 length);
                //    /// <summary>
                //    /// Write byte array to flash
                //    /// </summary>
                //    /// <param name="data">Data array to write</param>
                //    /// <param name="length">Number of data items to write</param>
                //    /// <returns>True iff write was successful</returns>
                //    public abstract bool Write(byte[] data, UInt16 length);
                //    /// <summary>
                //    /// Read ushort array from flash
                //    /// </summary>
                //    /// <param name="index">Position to read from</param>
                //    /// <param name="bufferSize">The amount of data to return</param>
                //    /// <returns></returns>
                //    public abstract ushort[] Read(int index, int bufferSize);
                //    public abstract bool WriteEof(uint bufferSize);
                //}

                public class NorStore {

                    public const uint NorSize = 12*1024*1024;

                    public const bool debugMode = false;
                    public bool flag = true;
                    public int bytesWritten = 0;
                    public static int readCounter = 0;

                    public ushort[] verfier = new ushort[1024];
                    public byte[] verfierDS = new byte[1024];

                    private NVM.Data[] dataRefArray;
                    private NVM.DataStore dStore;
                    private NVM.Data dataDS;

                    private Type dataType = typeof (ushort);

                    public NorStore() {
                        dStore = new NVM.DataStore((int) NVM.StorageType.NOR);

                        if (NVM.DataStore.EraseAll() == NVM.DataStatus.Success) {
                            Debug.Print("Datastore succesfully erased");
                        }
                    }

                    public bool Write(ushort[] data, UInt16 length) {
                        dataDS = new NVM.Data(dStore, (uint) data.Length, dataType);
                        if (dataDS.Write(data, (uint) data.Length) == NVM.DataStatus.Success) {
                            return true;
                        }
                        Debug.Print("Write to NOR failed\n");
                        return false;
                    }

                    public bool Write(byte[] data, UInt16 length) {
                        return !SPOT.Hardware.EmoteDotNow.NOR.IsFull();
                    }

                    public ushort[] Read(int readIndex, int bufferSize) {
                        if (readCounter == 0) {
                            dataRefArray = new NVM.Data[dStore.CountOfDataIds()];
                            dStore.ReadAllDataReferences(dataRefArray, 0); //Get the data references into dataRefArray.
                            ++readCounter;
                        }

                        ushort[] readBuffer = new ushort[bufferSize];
                        if (readIndex <= (dStore.CountOfDataIds() - 1)) {
                            if ((dataRefArray[readIndex].Read(readBuffer, 0, (uint) readBuffer.Length)) !=
                                NVM.DataStatus.Success) {
                                Debug.Print("Read from NOR failed during verification\n");
                            }
                        }
                        return readBuffer;
                    }


                    public bool WriteEof(uint bufferSize) {
                        ushort[] eof = new ushort[bufferSize];

                        for (UInt16 i = 0; i < eof.Length; i++) {
                            eof[i] = 0x0c0c;
                        }

                        dataDS = new NVM.Data(dStore, (uint) eof.Length, dataType);
                        return dataDS.Write(eof, (uint) eof.Length) == NVM.DataStatus.Success;
                    }
                }

            }
        }
    }
}