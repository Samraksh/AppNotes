/*=========================
 * eMote .NOW Large Data Reference
 *  Pack smaller buffers into larger data references
 *      Gets around the issue of having at most 256 data references
 * Versions
 *  1.0 Initial Version
 =========================*/

using Samraksh.eMote.NonVolatileMemory;

namespace Samraksh.AppNote.Utility {
    /// <summary>
    /// Manage large DataStore references
    /// </summary>
    public class LargeDataReference {
        /// <summary>The number of items in each data reference</summary>
        public readonly int Size;

        private readonly DataStore _dataStore;
        private DataReference _dataRef;
        private int _writeOffset;
        private int _readOffset;
        private readonly DataReference[] _readDataReference = new DataReference[1];
        private int _dataReferenceOffset;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataStore">Reference to DataStore</param>
        /// <param name="size">The number of items in each data reference</param>
        public LargeDataReference(DataStore dataStore, int size) {
            _dataStore = dataStore;
            Size = _writeOffset = size;
        }

        /// <summary>
        /// Write a buffer to DataStore
        /// </summary>
        /// <remarks>Will add buffers to data reference; when full, starts new data reference</remarks>
        /// <param name="buffer">Buffer to store</param>
        /// <returns></returns>
        public DataStoreReturnStatus Write(ushort[] buffer) {
            if (_writeOffset + buffer.Length > Size) {
                _dataRef = new DataReference(_dataStore, Size, ReferenceDataType.UINT16);
                _writeOffset = 0;
            }
            var retVal = _dataRef.Write(buffer, _writeOffset, buffer.Length);
            //Debug.Print("Writing value " + buffer[0] + " at offset " + _writeOffset);
            _writeOffset += buffer.Length;
            return retVal;
        }

        /// <summary>
        /// Flush the buffer by writing the fill values
        /// </summary>
        /// <param name="fillBufSize">Size of the buffer to fill</param>
        /// <param name="fillVal">Value to be used for fill</param>
        /// <returns>Status of attempt to write</returns>
        public DataStoreReturnStatus Flush(int fillBufSize, ushort fillVal) {
            if (_writeOffset >= Size) {
                return DataStoreReturnStatus.Success;
            }
            var fillBuff = new ushort[fillBufSize];
            if (fillVal != 0) {
                for (var i = 0; i < fillBufSize; i++) {
                    fillBuff[i] = fillVal;
                }
            }
            DataStoreReturnStatus retVal;
            while (_writeOffset + fillBufSize <= Size) {
                if ((retVal = _dataRef.Write(fillBuff, _writeOffset, fillBufSize)) != DataStoreReturnStatus.Success) {
                    return retVal;
                }
                _writeOffset += fillBufSize;
            }
            if (_writeOffset < Size) {
                if ((retVal = _dataRef.Write(fillBuff, _writeOffset, Size-_writeOffset)) != DataStoreReturnStatus.Success) {
                    return retVal;
                }
                _writeOffset += fillBufSize;
            }
            _writeOffset = Size;
            return DataStoreReturnStatus.Success;
        }

        /// <summary>
        /// Initialize reading
        /// </summary>
        /// <returns>Status of attempt to ReadAllDataReferences</returns>
        public DataStoreReturnStatus InitializeRead() {
            _readOffset = 0;
            // Initialize _readDataReference[0] so it's not null
            var retVal = _dataStore.ReadAllDataReferences(_readDataReference, 0);
            _dataReferenceOffset = _readDataReference.Length;
            return retVal;
        }

        /// <summary>
        /// Read the next buffer
        /// </summary>
        /// <remarks>Returns NoMoreData if read null data reference, Failure if buffer is larger than LargeDataReference size. 
        ///     Else returns the status of attempt to read next data reference.</remarks>
        /// <param name="buffer">The buffer to fill</param>
        /// <returns>Status of the attempt to read</returns>
        public ReturnStatus ReadNext(ushort[] buffer) {
            DataStoreReturnStatus retVal;
            var readDataReference = _readDataReference[0];
            // If the read would take us past the reference, read the next one
            if (_readOffset + buffer.Length > Size) {
                if ((retVal = _dataStore.ReadAllDataReferences(_readDataReference, _dataReferenceOffset)) != DataStoreReturnStatus.Success) {
                    return (ReturnStatus)((int)retVal);
                }
                _dataReferenceOffset += _readDataReference.Length;
                _readOffset = 0;
                readDataReference = _readDataReference[0];
                // If still past the data reference, buffer size is too large
                if (_readOffset + buffer.Length > Size) { return ReturnStatus.Failure; }
            }
            // If null, we're out of data
            if (readDataReference == null) { return ReturnStatus.NoMoreData; }
            // Read the buffer data
            retVal = readDataReference.Read(buffer, _readOffset, buffer.Length);
            _readOffset += buffer.Length;
            return (ReturnStatus)((int)retVal);
        }

        /// <summary>
        /// Return status values for ReadNext
        /// </summary>
        public enum ReturnStatus {
            /// <summary>Success</summary>
            Success = DataStoreReturnStatus.Success,

            /// <summary>DataStore instance not initialized</summary>
            DataStoreNotInitialized = DataStoreReturnStatus.DataStoreNotInitialized,

            /// <summary>Failure</summary>
            Failure = DataStoreReturnStatus.Failure,

            /// <summary>Invalid argument</summary>
            InvalidArgument = DataStoreReturnStatus.InvalidArgument,

            /// <summary>Invalid reference</summary>
            InvalidReference = DataStoreReturnStatus.InvalidReference,

            /// <summary>No more data</summary>
            NoMoreData = 10,
        }

    }

}
