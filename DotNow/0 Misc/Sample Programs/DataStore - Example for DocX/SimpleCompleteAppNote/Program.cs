using System;
using Microsoft.SPOT;
using System.Threading;
using Samraksh.SPOT.NonVolatileMemory;


namespace SimpleCompleteAppNote {
    public class CompleteAppNote {
        readonly Random _rand;
        readonly DataStore _dStore;
        DataReference _data;
        DataReference[] _dataRefArray;
        readonly byte[] _writeBuffer;
        readonly byte[] _readBuffer;
        readonly Type _dataType;
        int _size;
        readonly int _experimentIndex;
        int _offset, _arrayLength = 0;


        public CompleteAppNote(int arrayLength) {
            _arrayLength = arrayLength;
            Debug.Print("Starting complete app note");
            _dStore = DataStore.Instance(StorageType.NOR);

            _experimentIndex = 10;
            _size = 2;
            _rand = new Random();

            _readBuffer = new byte[_size];
            _writeBuffer = new byte[_size];
            _dataType = typeof(byte);

            //Create a flash with no data
            Debug.Print(DataStore.EraseAllData() == DATASTORE_RETURN_STATUS.Success
                ? "Datastore succesfully erased"
                : "Datastore could not be erased");

            for (UInt16 writeIndex = 0; writeIndex < _writeBuffer.Length; ++writeIndex) {
                _writeBuffer[writeIndex] = (byte)writeIndex;
            }
        }


        public static void DisplayStats(bool result, string resultParameter1, string resultParameter2, int accuracy) {
            while (true) {
                Thread.Sleep(1000);
                if (result) {
                    Debug.Print("\r\nresult=PASS\r\n");
                }
                else {
                    Debug.Print("\r\nresult=FAIL\r\n");
                }
                Debug.Print("\r\naccuracy=" + accuracy.ToString() + "\r\n");
                Debug.Print("\r\nresultParameter1=" + resultParameter1 + "\r\n");
                Debug.Print("\r\nresultParameter2=" + resultParameter2 + "\r\n");
                Debug.Print("\r\nresultParameter3= \r\b");
                Debug.Print("\r\nresultParameter4= \r\b");
                Debug.Print("\r\nresultParameter5= \r\b");
            }
        }


        public void WriteData() {
            for (UInt32 dataIndex = 0; dataIndex < _experimentIndex; ++dataIndex) {
                try {
                    _size = _rand.Next(828) + 2;
                    _data = new DataReference(_dStore, _size, _dataType);
                    DATASTORE_RETURN_STATUS retVal = _data.Write(_writeBuffer, 0, _writeBuffer.Length);
                    if (retVal == DATASTORE_RETURN_STATUS.Success)
                        Debug.Print("Write successful");
                    else if (retVal == DATASTORE_RETURN_STATUS.InvalidReference) {
                        DisplayStats(false, "Write not successful as reference is not valid", "", 0);
                        return;
                    }
                    else {
                        DisplayStats(false, "Write not successful", "", 0);
                        return;
                    }
                }
                catch (Exception ex) {
                    Debug.Print(" Write failed. Exception is: " + ex.Message);
                    throw;
                }
            }
        }


        void Program() {
            //Write data to flash
            try {
                WriteData();
            }
            catch (Exception ex) {
                Debug.Print("Write failed. Exception is: " + ex.Message);
            }

            //Get the data references into a dataRefArray which is larger than the amount of records created.
            _offset = 0;
            _dataRefArray = new DataReference[_experimentIndex * _experimentIndex];
            if (_dStore.ReadAllDataReferences(_dataRefArray, _offset) != DATASTORE_RETURN_STATUS.Success) {
                Debug.Print("ReadAllDataReferences failed");
            }

            //Read from a random reference
            var randValue = _rand.Next(_experimentIndex);
            try {
                var retVal = _dataRefArray[randValue].Read(_readBuffer, _offset, _readBuffer.Length);

                if (retVal == DATASTORE_RETURN_STATUS.InvalidReference) {
                    Debug.Print("Read failed. Invalid reference");
                    throw new DataStoreException("Invalid reference");
                }
                Debug.Print(retVal != DATASTORE_RETURN_STATUS.Success ? "Read failed" : "Read succeeded");
            }
            catch (Exception ex) {
                Debug.Print("Read failed. Exception is: " + ex.Message);
            }


            //keep reading until a null reference or end of "dataRefArray"
            var index = 0;
            while (index < _experimentIndex * _experimentIndex) {
                try {
                    if (_dataRefArray[index] == null) { break; }

                    var retVal = _dataRefArray[index].Read(_readBuffer, _offset, _readBuffer.Length);

                    if (retVal == DATASTORE_RETURN_STATUS.InvalidReference) {
                        Debug.Print("Read failed. Invalid reference");
                        throw new DataStoreException("Invalid reference");
                    }
                    Debug.Print(retVal != DATASTORE_RETURN_STATUS.Success ? "Read failed" : "Read succeeded");
                }
                catch (Exception ex) {
                    Debug.Print("Read failed. Exception is: " + ex.Message);
                }

                ++index;
            }

            //Delete a random reference
            randValue = _rand.Next(_experimentIndex);
            Debug.Print(_dataRefArray[randValue].Delete() != DATASTORE_RETURN_STATUS.Success
                ? "Data delete failed"
                : "Data delete succeeded");

            //Read from same reference
            try {
                var retVal = _dataRefArray[randValue].Read(_readBuffer, _offset, _readBuffer.Length);

                if (retVal == DATASTORE_RETURN_STATUS.InvalidReference) {
                    Debug.Print("Read failed. Invalid reference");
                    throw new DataStoreException("Invalid reference");
                }
                Debug.Print(retVal != DATASTORE_RETURN_STATUS.Success ? "Read failed" : "Read succeeded");
            }
            catch (Exception ex) {
                Debug.Print("Read failed. Exception is: " + ex.Message);
            }
        }


        public static void Main() {
            var appNote = new CompleteAppNote(3);
            appNote.Program();
        }

    }
}
