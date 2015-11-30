namespace Samraksh.AppNote.Utility {
    /// <summary>
    /// Circular buffer
    /// </summary>
    /// <remarks>
    ///     Uses Producer-Consumer pattern. Assumes:
    ///     <para>Buffer never overlows.</para>
    /// </remarks>
    public class CircularBuffer {
        private readonly byte[] _circBuffer;
        private readonly int _buffSize;
        private int _buffStart;
        private int _buffEnd;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="buffSize">Size of buffer</param>
        public CircularBuffer(int buffSize) {
            _circBuffer = new byte[buffSize];
            _buffSize = buffSize;
            _buffStart = _buffEnd = 0;
        }

        /// <summary>
        /// Is there any data in the buffer?
        /// </summary>
        public bool IsData {
            get {
                lock (this) {   // Avoid race condition with get/put
                    return _buffStart != _buffEnd;
                }
            }
        }

        /// <summary>
        /// Return the current length of the circular buffer
        /// </summary>
        public int CurrLength {
            get {
                lock (this) {   // Avoid race condition with get/put
                    if (_buffStart <= _buffEnd) {
                        return _buffEnd - _buffStart + 1;
                    }
                    return _buffSize - _buffStart + _buffEnd + 2;
                }
            }
        }

        /// <summary>
        /// Get the next value
        /// </summary>
        /// <returns>Next value</returns>
        /// <remarks>Precondition: IsData is true</remarks>
        public byte Get() {
            lock (this) {
                var retVal = _circBuffer[_buffStart]; // Get the next value
                _buffStart = ++_buffStart % _buffSize; // Advance the pointer
                return retVal;
            }
        }

        /// <summary>
        /// Put a value into the buffer
        /// </summary>
        /// <param name="value">Value to put</param>
        /// <remarks>Postcondition: IsData is true</remarks>
        public void Put(byte value) {
            lock (this) {
                _buffEnd = ++_buffEnd % _buffSize; // Advance the end pointer
                _circBuffer[_buffEnd] = value; // Put the value
            }
        }

        /// <summary>
        /// Put an array of values into the buffer
        /// </summary>
        /// <param name="valueArr">Array to put</param>
        /// <param name="numVals">Number of values to put</param>
        public void Put(byte[] valueArr, int numVals) {
            lock (this) {
                for (var i = 0; i < numVals; i++) {
                    _buffEnd = ++_buffEnd % _buffSize; // Advance the end pointer
                    _circBuffer[_buffEnd] = valueArr[i]; // Put the value
                }
            }
        }
    }
}
