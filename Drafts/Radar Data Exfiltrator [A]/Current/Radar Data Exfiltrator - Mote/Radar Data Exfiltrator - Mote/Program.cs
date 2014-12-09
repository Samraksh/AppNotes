/*--------------------------------------------------------------------
 * Radar Displacement Detector: app note for the eMote .NOW
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *      1.0: initial release
 *      1.1: Removed check for background noise
 *      
---------------------------------------------------------------------*/

using System;
using System.IO.Ports;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.DotNow.RadarDisplacementDetector;
using Samraksh.AppNote.Utility;
using AnalogInput = Samraksh.eMote.Adapt.AnalogInput;

namespace Samraksh.AppNote.DotNow.RadarDataExfiltrator {

    /// <summary>
    /// Detector parameters
    /// </summary>
    public struct DetectorParameters {

        /// <summary>Number of milliseconds between samples</summary>
        //public const int SamplingIntervalMilliSec = 4000;    // Larger values => fewer samples/sec
        public const int SamplingIntervalMilliSec = 20000;    // Larger values => fewer samples/sec

        /// <summary>Number of samples per second</summary>
        public const int SamplesPerSecond = 1000000 / SamplingIntervalMilliSec;

        /// <summary>Number of microseconds between between samples</summary>
        public const int CallbackIntervalMs = SamplingIntervalMilliSec / 1000;
    }



    /// <summary>
    /// Radar Displacement Detector
    ///     Detects displacement (towards or away from the radar)
    ///     Filters out "back and forth" movement (such as trees blowing in the wind)
    /// </summary>
    public static class RadarDisplacementDetector {

        // Mapping between the GPIO pins stenciled on the ADAPT Dev board and those on the CPU itself
        //  On the Dev board, GPIO 01-04 are connected to LEDs
        private enum PinMap { Gpio01 = 58, Gpio02 = 55, Gpio03 = 53, Gpio04 = 52, Gpio05 = 51 };

        private static readonly OutputPort Led1 = new OutputPort((Cpu.Pin)PinMap.Gpio01, false);


        private const int AdcChannelI = 0;
        private const int AdcChannelQ = 1;
        private static AnalogInput _adc;

        //private static SerialComm _serial;
        private static SerialPort _serial;
        private static void SerialCallback(byte[] readBytes) { }    // Ignore any input stuff


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
            Debug.Print("   SamplingIntervalMilliSec " + DetectorParameters.SamplingIntervalMilliSec);
            Debug.Print("   SamplesPerSecond " + DetectorParameters.SamplesPerSecond);
            Debug.Print("   CallbackIntervalMs " + DetectorParameters.CallbackIntervalMs);
            Debug.Print("");

            Thread.Sleep(4000); // Wait a bit before launch

            //// Set up thread to process the sample
            //(new Thread(ProcessSampleThread)).Start();
            //Debug.Print("Started ProcessSample thread");

            try {
                Debug.Print("Setting up the serial port");
                //_serial = new SerialComm("COM29", SerialCallback);
                _serial = new SerialPort("COM29") { BaudRate = 115200, Parity = Parity.None, DataBits = 8, StopBits = StopBits.One };
                Debug.Print("  Opening serial port");
                _serial.Open();
                Debug.Print("  Serial port set up");
            }
            catch (Exception ex) {
                Debug.Print("   ### Serial Exception\n" + ex);
            }

            // Set up ADC sampling
            _adc = new AnalogInput();
            Debug.Print("Initializing ADC");
            _adc.Initialize();
            Debug.Print("  ADC initialized");

            //// Testing
            //Debug.Print("Sleep time: " + DetectorParameters.SamplingIntervalMilliSec + " ms");
            //for (var i = 0; i < 51; i++) {
            //    //Debug.Print("");
            //    //Debug.Print("Driver. Sample num before: " + SampleData.SampleNumber);
            //    TimerCallback(null);
            //    Thread.Sleep(DetectorParameters.SamplingIntervalMilliSec);
            //    //Debug.Print("Driver. Sample num after: " + SampleData.SampleNumber);
            //}

            //var profile = new Thread(() => {
            //    while (true) {
            //        ProfileSync.WaitOne();
            //        if (_sampleCounter == 0) { _startTime = DateTime.Now; }
            //        if (_sampleCounter%ReportInterval != HalfReportInterval) continue;
            //        var time = DateTime.Now - _startTime;
            //        var millisecs = time.Seconds * 1000 + time.Milliseconds;
            //        Debug.Print(_sampleCounter + " T " + millisecs + " M " +
            //                    (millisecs / ReportInterval));
            //        _startTime = DateTime.Now;
            //    }
            //});
            //profile.Start();

            Debug.EnableGCMessages(true);
            // Start the timer
            Debug.Print("Setting up the timer");
            var sampleTimer = new SimpleTimer(TimerCallback, null, 0, DetectorParameters.CallbackIntervalMs);
            Debug.Print("  Starting the timer");
            sampleTimer.Start();
            //var sampleTimer = new Timer(TimerCallback, null, 0, DetectorParameters.CallbackIntervalMs);
            Debug.Print("Started the timer with interval " + DetectorParameters.CallbackIntervalMs);

            Thread.Sleep(30 * 1000);
            //Thread.Sleep(Timeout.Infinite);

            sampleTimer.Stop();
        }

        ///// <summary>
        ///// Data for sample interpolation
        ///// </summary>
        //public static class Interpolation {

        //    /// <summary>Minimum number of samples before interpolation can start</summary>
        //    public const int MinSamplesToStart = 3;

        //    /// <summary>Size of the buffer</summary>
        //    public const int BufferSize = 4;
        //    /// <summary>Samples buffer</summary>
        //    public static ushort[] Samples = new ushort[BufferSize];
        //    /// <summary>Next-sample pointer</summary>
        //    public static int NextSample = 0;

        //    /// <summary>Add this value to NextSample to go back 1</summary>
        //    public const int Back1 = BufferSize - 1;
        //    /// <summary>Add this value to NextSample to go back 2</summary>
        //    public const int Back2 = BufferSize - 2;
        //    /// <summary>Add this value to NextSample to go back 3</summary>
        //    public const int Back3 = BufferSize - 3;
        //}

        /// <summary>
        /// Synchronization processing between callback thread and sample processing thread
        /// </summary>
        public static class ProcessingSynchronization {

            /// <summary>True iff currently processing a sample</summary>
            public static int CurrentlyProcessingSample = IntBool.False;

            ///// <summary>Event synch</summary>
            ////public static readonly AutoResetEvent ProcessSampleResetEvent = new AutoResetEvent(false);
            //public static readonly ManualResetEvent ProcessSampleResetEvent = new ManualResetEvent(false);
        }

        private static DateTime _startTime;
        private static int _sumSampleProcessingTime = 0;
        private static int _sampleCounter;
        private const int ReportInterval = 100;
        private const int HalfReportInterval = ReportInterval / 2;

        private static readonly AutoResetEvent ProfileSync = new AutoResetEvent(false);

        /// <summary>
        /// Callback for timer
        /// </summary>
        private static void TimerCallback(object state) {
            Led1.Write(true);
            //ProfileSync.Set();
            //if (_sampleCounter % ReportInterval == HalfReportInterval) {
            //    var time = DateTime.Now - _startTime;
            //    var millisecs = time.Seconds * 1000 + time.Milliseconds;
            //    Debug.Print(_sampleCounter + " T " + millisecs + " M " + (millisecs / ReportInterval));
            //    _startTime = DateTime.Now;
            //}


            // Check if we're currently processing a sample. If so, give message and return
            //  The variable _currentlyProcessingSample is reset in ProcessSampleBuffer.
            if (Interlocked.CompareExchange(ref ProcessingSynchronization.CurrentlyProcessingSample, IntBool.True, IntBool.False) == IntBool.True) {
                Debug.Print("*************************************************** Missed a sample; sample # " + (SampleData.SampleNumber + 1));
                return;
            }

            // Not currently processing a sample ... we can proceed
            //Debug.Print("TimerCallback. Process sample");

            //ProcessingSynchronization.ProcessSampleResetEvent.Set();

            _startTime = DateTime.Now;

            // Set which channel to read
            var adcChannel = SampleData.SampleNumber % 2 == 0 ? AdcChannelI : AdcChannelQ;

            // Read the sample
            Debug.Print("ProcessSampleThread. Reading from ADC channel " + adcChannel);

            var sample = _adc.Read(adcChannel);

            Debug.Print("#$# " + SampleData.SampleNumber + "," + sample);
            //Serial.Write("#$# " + SampleData.SampleNumber + "," + sample);

            //// Show processing time statistics
            //var runTime = DateTime.Now - _startTime;
            //_sumSampleProcessingTime += (runTime.Seconds * 1000) + runTime.Milliseconds;
            //if (SampleData.SampleNumber % 10 == 0) {
            //    Debug.Print("Time. Sum:" + _sumSampleProcessingTime + ", # samples:" + SampleData.SampleNumber + ", Mean:" + (_sumSampleProcessingTime / (SampleData.SampleNumber + 1)));
            //}

            SampleData.SampleNumber++;

            ProcessingSynchronization.CurrentlyProcessingSample = IntBool.False;

            Led1.Write(false);

        }

        //static void ProcessSampleThread() {
        //    while (true) {
        //        // Wait for callback to signal that a sample is ready for processing
        //        ProcessingSynchronization.ProcessSampleResetEvent.WaitOne();

        //        //Debug.Print("ProcessSampleThread. Resetting reset event. Currently " + ProcessingSynchronization.ProcessSampleResetEvent.WaitOne(0, false));
        //        ProcessingSynchronization.ProcessSampleResetEvent.Reset();
        //        //Debug.Print("  After reset: " + ProcessingSynchronization.ProcessSampleResetEvent.WaitOne(0, false));

        //        //Debug.Print("PST.B");

        //        _startTime = DateTime.Now;

        //        // Set which channel to read
        //        var adcChannel = SampleData.SampleNumber % 2 == 0 ? AdcChannelI : AdcChannelQ;

        //        // Read the sample
        //        //Debug.Print("ProcessSampleThread. Preparing to read from ADC channel " + adcChannel);

        //        var sample = Adc.Read(adcChannel);

        //        Debug.Print("#$# " + SampleData.SampleNumber + "," + sample);
        //        //Serial.Write("#$# " + SampleData.SampleNumber + "," + sample);

        //        #region Commented code
        //        //Interpolation.Samples[Interpolation.NextSample] = Adc.Read(adcChannel);

        //        //Debug.Print("ProcessSampleThread. Finished reading from ADC. Sample read:  " + Interpolation.Samples[Interpolation.NextSample]);

        //        //// Update interpolation buffer pointer & sample number
        //        //Interpolation.NextSample = (Interpolation.NextSample + 1) % Interpolation.BufferSize;
        //        //SampleData.SampleNumber++;

        //        //// We need 3 samples before we can do interpolation
        //        //if (SampleData.SampleNumber < Interpolation.MinSamplesToStart) {
        //        //    Debug.Print("Initial collection. Sample number: " + SampleData.SampleNumber + ", MinSamplesToStart: " + Interpolation.MinSamplesToStart);
        //        //    ProcessingSynchronization.CurrentlyProcessingSample = IntBool.False;
        //        //    continue;
        //        //}

        //        //Debug.Print("Now processing sample " + SampleData.SampleNumber);

        //        //// Get the I-Q pair to process
        //        ////  Pointer is positioned at next sample. We just read (next - 1) value.
        //        ////  Actual value to be returned is (next - 2) value.
        //        ////  Interpolated value to be returned is average of (next - 1) and (next - 3) values.

        //        //// Actual is (next - 2) value. For modulo arithmetic, add an offset that takes to 2 positions back.
        //        //var prevActual = Interpolation.Samples[(Interpolation.NextSample + Interpolation.Back2) % Interpolation.BufferSize];

        //        //// Interpolated is average of (next - 1) and (next - 3) values;
        //        //ushort prevInterpolated;
        //        //{
        //        //    var back1 = Interpolation.Samples[(Interpolation.NextSample + Interpolation.Back1) % Interpolation.BufferSize];
        //        //    var back3 = Interpolation.Samples[(Interpolation.NextSample + Interpolation.Back3) % Interpolation.BufferSize];
        //        //    prevInterpolated = (ushort)((back1 + back3) >> 1); // Divide by 2
        //        //}

        //        //// If we just sampled I value, then return previous interpolated for I and previous actutal for Q
        //        //if (adcChannel == AdcChannelI) {
        //        //    SampleData.CurrSample.I = prevInterpolated;
        //        //    SampleData.CurrSample.Q = prevActual;
        //        //}
        //        //// If we just sampled Q value, then return previous interpolated for Q and previous actutal for I
        //        //else {
        //        //    SampleData.CurrSample.I = prevActual;
        //        //    SampleData.CurrSample.Q = prevInterpolated;
        //        //}

        //        //// Print trace info
        //        //var modSampleNumber = SampleData.SampleNumber % 100;
        //        //if (modSampleNumber == 0) { Debug.Print(""); }
        //        //if (modSampleNumber >= 0 && modSampleNumber < 10) {
        //        //    var samples = "Interpolation Samples ";
        //        //    foreach (var theSample in Interpolation.Samples) {
        //        //        samples += " " + theSample;
        //        //    }
        //        //    Debug.Print(samples + ", NextSample:" + Interpolation.NextSample);
        //        //    Debug.Print(SampleData.SampleNumber + " I:" + SampleData.CurrSample.I + ", Q:" + SampleData.CurrSample.Q);
        //        //}

        //        //// Process the sample
        //        //ProcessSample();
        //        #endregion

        //        // Show processing time statistics
        //        var runTime = DateTime.Now - _startTime;
        //        _sumSampleProcessingTime += (runTime.Seconds * 1000) + runTime.Milliseconds;
        //        if (SampleData.SampleNumber % 10 == 0) {
        //            Debug.Print("Time. Sum:" + _sumSampleProcessingTime + ", # samples:" + SampleData.SampleNumber + ", Mean:" + (_sumSampleProcessingTime / (SampleData.SampleNumber + 1)));
        //        }

        //        SampleData.SampleNumber++;

        //        ProcessingSynchronization.CurrentlyProcessingSample = IntBool.False;
        //    }
        //}

    }
}