using System;
using System.Threading;
using Microsoft.SPOT;

namespace Samraksh.AppNote.DotNow.RadarDisplacementDetector {
    /// <summary>
    /// A FIFO buffer
    /// </summary>
    public static class SampleBuffer {
        private static int _bufferLen = 1000;
        private static ushort[] _buffer = new ushort[_bufferLen];
        private static int _begin;
        private static int _end;

        public static AutoResetEvent SampleAdded = new AutoResetEvent(false);

        public static bool IsEmpty { get { return (_begin == _end); } }

        public static bool IsFull { get { return (_begin + 1) % _bufferLen == _end; } }

        public static void Add(ushort val) {
            if (IsFull) { throw new Exception("Buffer is full"); }
            _buffer[_end] = val;
            _end = (_end + 1) % _bufferLen;
            SampleAdded.Set();
        }

        public static ushort Get() {
            if (IsEmpty) { throw new Exception("Buffer is empty"); }
            var val = _buffer[_begin];
            _begin = (_begin + 1) % _bufferLen;
            return val;
        }

        public static AutoResetEvent SampleReceived = new AutoResetEvent(false);
    }
}
