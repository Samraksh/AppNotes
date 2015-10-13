using Microsoft.SPOT.Hardware;

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
        public static int SampleNumber = 0;
        /// <summary>Current sample</summary>
        public static Sample CurrSample = new Sample();
        /// <summary>Sum of samples</summary>
        public static Sample SampleSum = new Sample();
    }


    /// <summary>
    /// Pin definitions for the ADAPT dev board
    /// </summary>
    public static class AdaptDevBoardPins {
        /// <summary>
        /// Mapping between the GPIO pins stenciled on the ADAPT Dev board and those on the CPU itself
        /// </summary>
        /// <remarks>On the Dev board, GPIO 01-04 are connected to LEDs</remarks>
        public enum PinMap {
            /// <summary>MSM GPIO 01</summary>
            Gpio01 = 58,
            /// <summary>MSM GPIO 02</summary>
            Gpio02 = 55,
            /// <summary>MSM GPIO 03</summary>
            Gpio03 = 53,
            /// <summary>MSM GPIO 04</summary>
            Gpio04 = 52,
            /// <summary>MSM GPIO 05</summary>
            Gpio05 = 51
        };

        // Define the LEDs
        /// <summary>LED 1</summary>
        public const Cpu.Pin Led1 = (Cpu.Pin)PinMap.Gpio01;
        /// <summary>LED 2</summary>
        public const Cpu.Pin Led2 = (Cpu.Pin)PinMap.Gpio02;
        /// <summary>LED 3</summary>
        public const Cpu.Pin Led3 = (Cpu.Pin)PinMap.Gpio03;
        /// <summary>LED 4</summary>
        public const Cpu.Pin Led4 = (Cpu.Pin)PinMap.Gpio04;
    }

    /// <summary>
    /// Define GPIO ports
    /// </summary>
    public static class GpioPorts {
        /// <summary>Indicate when sample is processed</summary>
        public static OutputPort SampleProcessed = new OutputPort(AdaptDevBoardPins.Led1, false);

        /// <summary>Indicate whether or not event detected</summary>
        public static OutputPort DetectEvent = new OutputPort(AdaptDevBoardPins.Led2, false);

    }

    /// <summary>
    /// Bool surrogate that can be passed as ref
    /// </summary>
    struct IntBool {
        public const int True = 1;
        public const int False = 0;
    }

}
