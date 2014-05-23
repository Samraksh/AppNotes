using System;
using System.Threading;
using Microsoft.SPOT;

namespace Samraksh.AppNote.DotNow.RadarDisplacementDetector {
    /// <summary>
    /// A producer-consumer buffer
    /// </summary>
    public static class SampleBuffer {
        private static Sample[] _buffer = new Sample[1000];
        private static int _bufferLen = _buffer.Length;
        private static int _begin = 0;
        private static int _end = 0;

        public static bool IsEmpty{get { return (_begin == _end); }}

        public static AutoResetEvent SampleReceived = new AutoResetEvent(false);
    }
}
