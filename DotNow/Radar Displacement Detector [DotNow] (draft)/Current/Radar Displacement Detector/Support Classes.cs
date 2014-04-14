using Microsoft.SPOT.Hardware;
using Samraksh.eMote;
using Samraksh.eMote.DotNow;

namespace Samraksh.AppNote.DotNow.RadarDisplacementDetector {
    /// <summary>
    /// Displacement detection parameters
    /// </summary>
    enum Detector {
        SamplingIntervalMilliSec = 1000,
        SamplesPerSecond = 10 ^ 6 / SamplingIntervalMilliSec,
        BufferSize = 300,
        //SamplesPerSecond = BufferSize / (SamplingIntervalMilliSec / 1000),
        M = 2,
        N = 8,
        MinCumCuts = 5,
    }

    /// <summary>
    /// Displacement detection state values
    /// </summary>
    public enum DisplacementState {
        /// <summary>Displacement is happening</summary>
        Displacing,
        /// <summary>No displacement is happening</summary>
        Inactive,
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
        ///// <summary>Average value of background noise</summary>
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



}
