using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.eMote;
using Samraksh.eMote.DotNow;

namespace Samraksh.AppNote.DotNow.RadarDisplacementDetector {
    
    /// <summary>
    /// Displacement detection state values
    /// </summary>
    public enum DisplacementState {
        /// <summary>No displacement is happening</summary>
        Inactive = 0,
        /// <summary>Displacement is happening</summary>
        Displacing = 1,
    }

    /// <summary>
    /// Hold a sample pair
    /// </summary>
    public struct Sample {
        /// <summary>I value</summary>
        public int I;
        /// <summary>Q value</summary>
        public int Q;
    }

    /// <summary>
    /// Sample data
    /// </summary>
    public static class SampleData {
        /// <summary>Sample Counter</summary>
        public static int SampleCounter = 0;
        /// <summary>Current sample</summary>
        public static Sample CurrSample = new Sample();
        /// <summary>Sum of samples</summary>
        public static Sample SampleSum = new Sample();
    }

    /////// <summary>
    /////// Keep a running total and compute a running average via a circular buffer
    /////// </summary>
    ////public static class SampleMean {
    ////    private static int _bits;
    ////    //private const int BufferSize = (2 << (Bits - 1)); // This should be 2^Bits
    ////    private static Sample[] _sampBuffer;// = new Sample[BufferSize];
    ////    private static int _sampBufferPtr;
    ////    private static Sample _sum;
    ////    private static Sample _retVal;

    ////    /// <summary>
    ////    /// Get the buffer size
    ////    /// </summary>
    ////    public static int BufferSize {
    ////    get { return _sampBuffer.Length; }
    ////    }

    ////    /// <summary>
    ////    /// Initialize the buffer
    ////    /// </summary>
    ////    /// <param name="bits">The number of bits. Buffer size = 2 ^ bits</param>
    ////    public static void Initialize(int bits) {
    ////        _bits = bits;
    ////        var bufferSize = (1 << _bits);
    ////        _sampBuffer = new Sample[bufferSize];
    ////    }

    //    /// <summary>
    //    /// True iff buffer has been filled (pointer has wrapped)
    //    /// </summary>
    //    public static bool Filled = false;

    //    /// <summary>
    //    /// Return the average
    //    /// </summary>
    //    public static Sample Mean {
    //        get {
    //            _retVal.I = _sum.I >> _bits;
    //            _retVal.Q = _sum.Q >> _bits;
    //            return _retVal;
    //        }
    //    }

    //    /// <summary>
    //    /// Add in a new sample
    //    /// </summary>
    //    /// <param name="theSample">Sample to add in</param>
    //    public static void AddSample(Sample theSample) {
    //        // Subtract the values of the sample that's going away
    //        _sum.I -= _sampBuffer[_sampBufferPtr].I;
    //        _sum.Q -= _sampBuffer[_sampBufferPtr].Q;
    //        // Add the new sample values
    //        _sum.I += theSample.I;
    //        _sum.Q += theSample.Q;
    //        // Move in the new sample
    //        _sampBuffer[_sampBufferPtr] = theSample;
    //        // Update the pointer
    //        _sampBufferPtr = (_sampBufferPtr + 1) % _sampBuffer.Length;
    //        // If the pointer has wrapped around, mark the buffer as filled
    //        if (_sampBufferPtr == 0) {
    //            Filled = true;
    //        }
    //    }
    //}


    /// <summary>
    /// Define GPIO ports
    /// </summary>
    public static class GpioPorts {
        /// <summary>Indicate when sample is processed</summary>
        public static OutputPort SampleProcessed = new OutputPort(Pins.GPIO_J12_PIN1, false);

        /// <summary>Indicate whether or not event detected</summary>
        public static OutputPort DetectEvent = new OutputPort(Pins.GPIO_J12_PIN2, false);

        /// <summary>Enable the BumbleBee. Set this false to disable. </summary>
        public static OutputPort EnableBumbleBee = new OutputPort(Pins.GPIO_J11_PIN3, true);
    }

    /// <summary>
    /// Bool surrogate that can be passed as ref
    /// </summary>
    struct IntBool {
        public const int True = 1;
        public const int False = 0;
    }

}
