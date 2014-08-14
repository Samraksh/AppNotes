using System;
using Microsoft.SPOT;
using Samraksh.eMote.NonVolatileMemory;

namespace Samraksh.AppNote.Utility {
    public class LargeDataStoreReference {

        private readonly DataStore _dataStore;
        public readonly int BufferSize;
        private DataReference _dataRef;
        private int _writeOffset;
        private int _readOffset;
        private readonly DataReference[] _readDataReference = new DataReference[1];
        private int _dataReferenceOffset;

        public LargeDataStoreReference(DataStore dataStore, int bufferSize) {
            _dataStore = dataStore;
            BufferSize = _writeOffset = bufferSize;
        }

        public DataStoreReturnStatus Write(UInt16[] buffer) {
            if (_writeOffset + buffer.Length > BufferSize) {
                _dataRef = new DataReference(_dataStore, BufferSize, ReferenceDataType.UINT16);
                _writeOffset = 0;
            }
            var retVal = _dataRef.Write(buffer, _writeOffset, buffer.Length);
            _writeOffset += buffer.Length;
            return retVal;
        }

        public DataStoreReturnStatus Flush() {
            if (_writeOffset >= BufferSize) { return DataStoreReturnStatus.Success; }
            var zeroBuf = new UInt16[BufferSize - _writeOffset];
            var retVal = _dataRef.Write(zeroBuf);
            _writeOffset = BufferSize;
            return retVal;
        }

        public DataStoreReturnStatus ReadStart() {
            _readOffset = 0;
            _dataReferenceOffset = 0;
            // Initialize _readDataReference[0]
            return _dataStore.ReadAllDataReferences(_readDataReference, _dataReferenceOffset);
        }

        public LargeDataStoreReferenceReturnStatus ReadNext(UInt16[] buffer) {
            DataStoreReturnStatus retVal;
            var readDataReference = _readDataReference[0];
            // If null, we're out of data
            if (readDataReference == null) { return LargeDataStoreReferenceReturnStatus.NoMoreData; }
            // If the read would take us past the reference, read the next one
            if (_readOffset + buffer.Length > readDataReference.getDataReferenceSize) {
                retVal = _dataStore.ReadAllDataReferences(_readDataReference, _dataReferenceOffset);
                if (retVal != DataStoreReturnStatus.Success) {
                    return (LargeDataStoreReferenceReturnStatus)((int)retVal);
                }
                _dataReferenceOffset += _readDataReference.Length;
                _readOffset = 0;
                readDataReference = _readDataReference[0];
            }
            // If still past the data reference, buffer size is too large
            if (_readOffset + buffer.Length > readDataReference.getDataReferenceSize) { return LargeDataStoreReferenceReturnStatus.Failure; }
            // Read the buffer data
            retVal = readDataReference.Read(buffer, _readOffset, buffer.Length);
            _readOffset += buffer.Length;
            return (LargeDataStoreReferenceReturnStatus)((int)retVal);
        }

        public enum LargeDataStoreReferenceReturnStatus {
            Success = DataStoreReturnStatus.Success,
            DataStoreNotInitialized = DataStoreReturnStatus.DataStoreNotInitialized,
            Failure = DataStoreReturnStatus.Failure,
            InvalidArgument = DataStoreReturnStatus.InvalidArgument,
            InvalidReference = DataStoreReturnStatus.InvalidReference,
            NoMoreData = 10,
        }
        
    }

}
