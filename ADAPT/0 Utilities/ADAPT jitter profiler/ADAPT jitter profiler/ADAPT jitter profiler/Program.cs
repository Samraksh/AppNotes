/*--------------------------------------------------------------------
 * Radar Displacement Detector: app note for the eMote .NOW
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *      1.0: initial release
 *      1.1: Removed check for background noise
 *      
---------------------------------------------------------------------*/

//#define Empty
#define ProfileThread
//#define InlineProfiling
//#define CodeSerialPort
//#define Adc
//#define AdcInterpolate
//#define Displacement
//#define Sleep

using System;
using System.IO.Ports;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
//using AnalogInput = Samraksh.eMote.Adapt.AnalogInput;

namespace Samraksh.AppNote.DotNow.RadarDataExfiltrator {

    /// <summary>
    /// Sampling parameters
    /// </summary>
    public struct SamplingParameters {
        /// <summary>Number of milliseconds between samples</summary>
        public const int SamplingIntervalMilliSec = 4000;    // Larger values => fewer samples/sec
        //public const int SamplingIntervalMilliSec = 50000;    // Larger values => fewer samples/sec
        /// <summary>Number of samples per second</summary>
        public const int SamplesPerSecond = 1000000 / SamplingIntervalMilliSec;
        /// <summary>Number of microseconds between between samples</summary>
        public const int CallbackIntervalMs = SamplingIntervalMilliSec / 1000;
    }



    /// <summary>
    /// Jitter profiler
    /// </summary>
    public static partial class RadarDisplacementDetector {

#if CodeSerialPort
        private static SerialPort _port;
        private static byte[] _serialPayload = System.Text.Encoding.UTF8.GetBytes("abcdef");
#endif
#if Adc || AdcInterpolate || Displacement
        private static eMote.Adapt.AnalogInput _adc;
        private const int AdcChannelI = 0;
        private const int AdcChannelQ = 1;
#endif
#if AdcInterpolate || Displacement
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
            /// <summary>Last value read from ADC</summary>
            public static ushort LastRead;
            /// <summary>Sample Counter</summary>
            public static int SampleNumber = 0;
            /// <summary>Current sample</summary>
            public static Sample CurrSample = new Sample();
            /// <summary>Sum of samples</summary>
            public static Sample SampleSum = new Sample();
        }

        /// <summary>
        /// Data for sample interpolation
        /// </summary>
        public static class Interpolation {

            /// <summary>Minimum number of samples before interpolation can start</summary>
            public const int BeginInterpolation = 2;

            /// <summary>Size of the buffer</summary>
            public const int BufferSize = 4;
            /// <summary>Samples buffer</summary>
            public static ushort[] Samples = new ushort[BufferSize];
            /// <summary>Next-sample pointer</summary>
            public static int CurrSample = 0;

            /// <summary>Add this value to CurrSample to go back 1</summary>
            public const int Back1 = BufferSize - 1;
            /// <summary>Add this value to CurrSample to go back 2</summary>
            public const int Back2 = BufferSize - 2;
            /// <summary>Add this value to CurrSample to go back 3</summary>
            public const int Back3 = BufferSize - 3;
        }

#endif


        // Mapping between the GPIO pins stenciled on the ADAPT Dev board and those on the CPU itself
        //  On the Dev board, GPIO 01-04 are connected to LEDs
        private enum PinMap { Gpio01 = 58, Gpio02 = 55, Gpio03 = 53, Gpio04 = 52, Gpio05 = 51 };

        private static readonly OutputPort Led1 = new OutputPort((Cpu.Pin)PinMap.Gpio01, false);
        private static readonly OutputPort Led2 = new OutputPort((Cpu.Pin)PinMap.Gpio02, false);
        private static readonly OutputPort Led3 = new OutputPort((Cpu.Pin)PinMap.Gpio03, false);
        private static readonly OutputPort Led4 = new OutputPort((Cpu.Pin)PinMap.Gpio04, false);


        /// <summary>
        /// Get things started
        /// </summary>
        public static void Main() {
            // Basic setup
            Debug.EnableGCMessages(false);

            //VersionInfo.Init(Assembly.GetExecutingAssembly());
            //Debug.Print("Radar Motion Detector [ADAPT] " + VersionInfo.Version + " (" + VersionInfo.BuildDateTime + ")");

            Debug.Print("Power Level: " + PowerState.CurrentPowerLevel + " (16=High, 32=Med, 48=Low");
            PowerState.ChangePowerLevel(PowerLevel.High);

            Debug.Print("Bytes free: " + Debug.GC(true));

            Debug.Print("Parameters");
            Debug.Print("   SamplingIntervalMilliSec " + SamplingParameters.SamplingIntervalMilliSec);
            Debug.Print("   SamplesPerSecond " + SamplingParameters.SamplesPerSecond);
            Debug.Print("   CallbackIntervalMs " + SamplingParameters.CallbackIntervalMs);
            Debug.Print("");

#if Empty
            const string theProfile = "*** Empty callback ***";
            Debug.Print(theProfile);
#endif

#if ProfileThread
            const string theProfile = "*** Profile thread ***";
            Debug.Print(theProfile);
#endif
#if InlineProfiling
            const string theProfile = "*** Inline profiling ***";
            Debug.Print(theProfile);
#endif
#if CodeSerialPort
            try {
                _port = new SerialPort("COM1", 115200, Parity.None, 8, StopBits.None);
            }
            catch (Exception ex) {
                Debug.Print("Serial port exception:\n" + ex);
            }
            const string theProfile = "*** Serial Port ***";
            Debug.Print(theProfile);
#endif
#if Adc
            const string theProfile = "*** Adc ***";
            Debug.Print(theProfile);
            // Set up ADC sampling
            _adc = new eMote.Adapt.AnalogInput();
            Debug.Print("    Initializing ADC");
            _adc.Initialize();
            Debug.Print("    ADC initialized");
#endif
#if AdcInterpolate
            const string theProfile = "*** AdcInterpolate ***";
            Debug.Print(theProfile);
            // Set up ADC sampling
            _adc = new eMote.Adapt.AnalogInput();
            Debug.Print("    Initializing ADC");
            _adc.Initialize();
            Debug.Print("    ADC initialized");
#endif
#if Displacement
            const string theProfile = "*** Displacement ***";
            Debug.Print(theProfile);
            // Set up ADC sampling
            _adc = new eMote.Adapt.AnalogInput();
            Debug.Print("    Initializing ADC");
            _adc.Initialize();
            Debug.Print("    ADC initialized");

            MofNFilter.Initialize();
            CumulativeCuts.Initialize();

            Debug.Print("Starting");
#endif
#if Sleep
            const string theProfile = "*** Sleep ***";
            Debug.Print(theProfile);
#endif

            var checkIfTheProfileStringExists = theProfile;

            //------------------------------------------------------

#if ProfileThread
            var profile = new Thread(() => {
                while (true) {
                    ProfileSync.WaitOne();
                    if (_sampleCounter == 0) { _startTime = DateTime.Now; }
                    if (_sampleCounter%ReportInterval != HalfReportInterval) continue;
                    var time = DateTime.Now - _startTime;
                    var millisecs = time.Seconds * 1000 + time.Milliseconds;
                    Debug.Print(_sampleCounter + " T " + millisecs + " M " +
                                (millisecs / ReportInterval));
                    _startTime = DateTime.Now;
                }
            });
            profile.Start();
#endif

            Debug.EnableGCMessages(true);

            // Start the timer
            var sampleTimer = new Timer(TimerCallback, null, 0, SamplingParameters.CallbackIntervalMs);
            Debug.Print("Started the timer with interval " + SamplingParameters.CallbackIntervalMs);

            Thread.Sleep(Timeout.Infinite);
        }

        private static DateTime _startTime;
        private static int _sampleCounter;
        private const int ReportInterval = 100;
        private const int HalfReportInterval = ReportInterval / 2;

        private static readonly AutoResetEvent ProfileSync = new AutoResetEvent(false);

        /// <summary>
        /// Callback for timer
        /// </summary>
        private static void TimerCallback(object state) {
#if Empty
            Led1.Write(true);

            Led1.Write(false);
#endif
#if ProfileThread
            Led1.Write(true);
            
            _sampleCounter++;
            ProfileSync.Set();

            Led1.Write(false);
#endif
#if InlineProfiling
            Led1.Write(true);

            if (_sampleCounter % ReportInterval == HalfReportInterval) {
                var time = DateTime.Now - _startTime;
                var millisecs = time.Seconds * 1000 + time.Milliseconds;
                Debug.Print(_sampleCounter + " T " + millisecs + " M " + (millisecs / ReportInterval));
                _startTime = DateTime.Now;
            }
            _sampleCounter++;

            Led1.Write(false);
#endif
#if CodeSerialPort
            Led1.Write(true);

            _port.Write(_serialPayload,0,_serialPayload.Length);

            //_serialPayload = System.Text.Encoding.UTF8.GetBytes("S " + _sampleCounter);
            //_port.Write(_serialPayload, 0, _serialPayload.Length);
            //Debug.Print("P " + _sampleCounter);
            //_sampleCounter++;

            Led1.Write(false);
#endif
#if Adc
            Led1.Write(true);

            var sample = _adc.Read(AdcChannelI);

            Led1.Write(false);
#endif
#if AdcInterpolate || Displacement
            try {
                Led1.Write(true);

                // Set which channel to read
                var adcChannel = SampleData.SampleNumber % 2 == 0 ? AdcChannelI : AdcChannelQ;

                // Read the sample
                //Debug.Print("ProcessSampleThread. Preparing to read from ADC channel " + adcChannel);

                //Debug.Print("#$# " + SampleData.SampleNumber + "," + sample);
                //Serial.Write("#$# " + SampleData.SampleNumber + "," + sample);

                SampleData.LastRead = _adc.Read(adcChannel);
                Interpolation.Samples[Interpolation.CurrSample] = SampleData.LastRead;

                //Debug.Print("ProcessSampleThread. Finished reading from ADC. Sample read:  " + Interpolation.Samples[Interpolation.CurrSample]);


                // We need 3 samples before we can do interpolation
                if (SampleData.SampleNumber < Interpolation.BeginInterpolation) {
                    //Debug.Print("Initial collection. Sample number: " + SampleData.SampleNumber + ", BeginInterpolation: " + Interpolation.BeginInterpolation);
                    return;
                }

                Led2.Write(true);

                //Debug.Print("Now processing sample " + SampleData.SampleNumber);

                // Get the I-Q pair to process
                //  Pointer is positioned at current sample. 
                //  Actual value to be returned is (curr - 1) value.
                //  Interpolated value to be returned is average of (curr) and (curr - 2) values.

                // Actual is (curr - 1) value. For modulo arithmetic, add an offset that takes to 1 position back when modulo applied
                var prevActual = Interpolation.Samples[(Interpolation.CurrSample + Interpolation.Back1) % Interpolation.BufferSize];

                // Interpolated is average of (curr) and (curr - 2) values;
                ushort prevInterpolated;
                {
                    var back2 = Interpolation.Samples[(Interpolation.CurrSample + Interpolation.Back2) % Interpolation.BufferSize];
                    prevInterpolated = (ushort)((SampleData.LastRead + back2) >> 1); // Divide by 2
                }

                // If we just sampled I value, then return previous interpolated for I and previous actual for Q
                if (adcChannel == AdcChannelI) {
                    SampleData.CurrSample.I = prevInterpolated;
                    SampleData.CurrSample.Q = prevActual;
                }
                // If we just sampled Q value, then return previous interpolated for Q and previous actual for I
                else {
                    SampleData.CurrSample.I = prevActual;
                    SampleData.CurrSample.Q = prevInterpolated;
                }

                // Add to totals
                SampleData.SampleSum.I += SampleData.CurrSample.I;
                SampleData.SampleSum.Q += SampleData.CurrSample.Q;

#if Displacement
                ProcessSample();
#endif
            }
            finally {
                //var exfil = SampleData.SampleNumber + "," + SampleData.LastRead + "," + SampleData.CurrSample.I + "," + SampleData.CurrSample.Q +
                //            "\n";
                //Debug.Print(exfil);
                
                // Update interpolation buffer pointer & sample number
                Interpolation.CurrSample = (Interpolation.CurrSample + 1) % Interpolation.BufferSize;
                SampleData.SampleNumber++;

                Led1.Write(false);
            }
#endif
#if Sleep
            Led1.Write(true);

            Thread.Sleep(1);

            Led1.Write(false);
#endif

        }
    }
}