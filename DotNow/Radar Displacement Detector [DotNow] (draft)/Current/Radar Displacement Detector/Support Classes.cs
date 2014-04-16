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
        public static int SampNum = 0;
        ///// <summary>Mean value of background noise</summary>
        //public static Sample Mean = new Sample();
        ///// <summary>Sum of background noise values</summary>
        //public static Sample NoiseSum = new Sample();
        /// <summary>Current sample</summary>
        public static Sample CurrSample = new Sample();
        ///// <summary>Current sample, adjusted for background noise</summary>
        //public static Sample CompSample = new Sample();

        ///// <summary>
        ///// Initialize background noise values
        ///// </summary>
        //public static void InitNoise() {
        //    Mean.I = Mean.Q = SampNum = 0;
        //    NoiseSum.I = NoiseSum.Q = 0;
        //}
    }

    /// <summary>
    /// Keep a running total and compute a running average via a circular buffer
    /// </summary>
    public static class SampleMean {
        private const int Bits = 8;
        private const int BufferSize = 256; // This should be 2^Bits
        private static readonly Sample[] SampBuffer = new Sample[BufferSize];
        private static int _sampBufferPtr;
        private static Sample _sum;
        private static Sample _retVal;

        /// <summary>
        /// True iff buffer has been filled (pointer has wrapped)
        /// </summary>
        public static bool Filled = false;

        /// <summary>
        /// Return the average
        /// </summary>
        public static Sample Mean {
            get {
                _retVal.I = _sum.I >> Bits;
                _retVal.Q = _sum.Q >> Bits;
                return _retVal;
            }
        }

        /// <summary>
        /// Add in a new sample
        /// </summary>
        /// <param name="theSample">Sample to add in</param>
        public static void AddSample(Sample theSample) {
            // Subtract the values of the sample that's going away
            _sum.I -= SampBuffer[_sampBufferPtr].I;
            _sum.Q -= SampBuffer[_sampBufferPtr].Q;
            // Add the new sample values
            _sum.I += theSample.I;
            _sum.Q += theSample.Q;
            // Move in the new sample
            SampBuffer[_sampBufferPtr] = theSample;
            // Update the pointer
            _sampBufferPtr = (_sampBufferPtr + 1) % SampBuffer.Length;
            // If the pointer has wrapped around, mark the buffer as filled
            if (_sampBufferPtr == 0) {
                Filled = true;
            }
        }
    }


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
