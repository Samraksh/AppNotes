using Microsoft.SPOT.Hardware;
using AnalogInput = Samraksh.eMote.DotNow.AnalogInput;
#if Radar
using Samraksh.AppNote.DotNow.DataCollectorExfiltrator.Globals;
using System.Threading;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;


namespace Samraksh.AppNote.DotNow.DataCollectorExfiltrator.Sensors {
    public static class Sensor {

        /// <summary>
        /// Displacement detection parameters
        /// </summary>
        struct AdcParameters {

            /// <summary>Number of milliseconds between samples</summary>
            public const int SamplingIntervalMilliSec = 4000;    // Larger values => fewer samples/sec

            /// <summary>Number of samples to collect before presenting for processing</summary>
            public const int BufferSize = 300;

            /// <summary>Number of samples per second</summary>
            public const int SamplesPerSecond = 1000000 / SamplingIntervalMilliSec;

            /// <summary>Number of microseconds between invocation of buffer processing callback</summary>
            public const int CallbackIntervalMs = (BufferSize * 1000) / SamplesPerSecond;
        }

        private static readonly ushort[] Ibuffer = new ushort[AdcParameters.BufferSize];
        private static readonly ushort[] Qbuffer = new ushort[AdcParameters.BufferSize];

        private static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();

        public const string SensorName = "Radar";

        public static void Alert() {
            Lcd.Initialize();
            Lcd.Display("radr");
        }

        public static void Initialize() {
            Debug.Print("Parameters");
            Debug.Print("   SamplingIntervalMilliSec " + AdcParameters.SamplingIntervalMilliSec);
            Debug.Print("   BufferSize " + AdcParameters.BufferSize);
            Debug.Print("   SamplesPerSecond " + AdcParameters.SamplesPerSecond);
            Debug.Print("   CallbackIntervalMs " + AdcParameters.CallbackIntervalMs);
            Debug.Print("");

            var J11Pin3 = new OutputPort(eMote.DotNow.Pins.GPIO_J11_PIN3, true);

            Global.Serial.Write(Global.DataPrefix + "Sample,I,Q\n");

            AnalogInput.InitializeADC();
            AnalogInput.ConfigureContinuousModeDualChannel(Ibuffer, Qbuffer, (uint)Ibuffer.Length, AdcParameters.SamplingIntervalMilliSec, AdcBuffer_Callback);

        }

        /// <summary>
        /// Handle an error message
        /// </summary>
        public static void ErrorMsg(string error) {
            Lcd.Display(error);
        }


        /// <summary>
        /// Callback for buffered ADC
        /// </summary>
        /// <param name="threshold"></param>
        private static void AdcBuffer_Callback(long threshold) {
            try {
                // Check if we're currently processing a buffer. If so, give message and return
                //  The variable _currentlyProcessingBuffer is reset below.
                if (Interlocked.CompareExchange(ref _currentlyProcessingBuffer, IntBool.True, IntBool.False) == IntBool.True) {
                    Debug.Print(
                        "********************************************************* Missed a buffer; callback #" + (_callbackCtr));
                    return;
                }

                // Output the data
                for (var i = 0; i < Ibuffer.Length; i++) {
                    var payload = System.Text.Encoding.UTF8.GetBytes(Global.DataPrefix + _sampleCtr + "," + Ibuffer[i] + "," + Qbuffer[i] + "\n");
                    Global.Serial.Write(payload, 0, payload.Length);
                    _sampleCtr++;
                }
                _currentlyProcessingBuffer = IntBool.False;
            }
            finally {
                _callbackCtr++;
            }
        }
        private static int _sampleCtr;
        private static int _callbackCtr;
        private static int _currentlyProcessingBuffer = IntBool.False;

        /// <summary>
        /// Bool surrogate that can be passed as ref
        /// </summary>
        struct IntBool {
            public const int True = 1;
            public const int False = 0;
        }

    }
}
#endif
