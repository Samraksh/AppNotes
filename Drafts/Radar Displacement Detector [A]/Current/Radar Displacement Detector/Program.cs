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
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;
using AnalogInput = Samraksh.eMote.Adapt.AnalogInput;

namespace Samraksh.AppNote.DotNow.RadarDisplacementDetector {


    /// <summary>
    /// Radar Displacement Detector
    ///     Detects displacement (towards or away from the radar)
    ///     Filters out "back and forth" movement (such as trees blowing in the wind)
    /// </summary>
    public static partial class RadarDisplacementDetector {

        /// <summary>
        /// Parameters for sampling
        /// </summary>
        public struct SamplingParameters {
            /// <summary>Number of milliseconds between samples</summary>
            public const int SamplingIntervalMilliSec = 4000;    // Larger values => fewer samples/sec
            /// <summary>Number of samples to collect before presenting for processing</summary>
            //public const int BufferSize = 500;
            public const int BufferSize = 500;
            /// <summary>Number of samples per second</summary>
            public const int SamplesPerSecond = 1000000 / SamplingIntervalMilliSec;
            /// <summary>Number of microseconds between invocation of buffer processing callback</summary>
            public const int CallbackIntervalMs = (BufferSize * 1000) / SamplesPerSecond;
        }


        private const int AdcChannelI = 0;
        private const int AdcChannelQ = 1;
        private static readonly AnalogInput Adc = new AnalogInput();

        private static readonly SimpleTimer SampleTimer = new SimpleTimer(TimerCallback, 0, SamplingParameters.SamplingIntervalMilliSec / 1000);

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

            Debug.Print("Sampling Parameters");
            Debug.Print("   SamplingIntervalMilliSec " + SamplingParameters.SamplingIntervalMilliSec);
            Debug.Print("   SamplesPerSecond " + SamplingParameters.SamplesPerSecond);
            Debug.Print("   CallbackIntervalMs " + SamplingParameters.CallbackIntervalMs);

            Debug.Print("Detection Paramters");
            Debug.Print("   M " + DetectorParameters.M);
            Debug.Print("   N " + DetectorParameters.N);
            Debug.Print("   MinCumCuts " + DetectorParameters.MinCumCuts);
            Debug.Print("   CutDistCm " + DetectorParameters.CutDistanceCm);
            Debug.Print("");

            //Thread.Sleep(4000); // Wait a bit before launch

            // Initialize detection
            CumulativeCuts.Initialize();
            MofNFilter.Initialize();

            // Set up thread to process the sample
            (new Thread(ProcessSampleThread)).Start();
            Debug.Print("Started ProcessSample thread");

            // Set up ADC sampling
            Adc.Initialize();
            Debug.Print("Initialized ADC");

            //// Testing
            //for (var i = 0; i < 4; i++) {
            //    Debug.Print("");
            //    Debug.Print("Driver. Sample num before: " + SampleData.SampleNumber);
            //    TimerCallback(null);
            //    Thread.Sleep(4 * DetectorParameters.SamplingIntervalMilliSec / 1000);
            //    Debug.Print("Driver. Sample num after: " + SampleData.SampleNumber);
            //}

            // Start the timer
            //SampleTimer = new SimpleTimer(TimerCallback, 0, SamplingParameters.SamplingIntervalMilliSec / 1000);
            SampleTimer.Start();
            Debug.Print("Started the timer with interval " + SamplingParameters.SamplingIntervalMilliSec / 1000);

            Thread.Sleep(Timeout.Infinite);
        }

        /// <summary>
        /// Callback for timer
        /// </summary>
        private static void TimerCallback(object state) {
            // Set which channel to read
            var adcChannel = SampleData.SampleNumber % 2 == 0 ? AdcChannelI : AdcChannelQ;

            // Read the sample
            Debug.Print("TimerCallback. Preparing to read from ADC channel " + adcChannel);
            if (SampleBuffer.IsFull) {
                Debug.Print("Buffer is full");
                SampleTimer.Stop();
                return;
            }
            SampleBuffer.Add(Adc.Read(adcChannel));
        }

        private static DateTime _startTime;
        private static int _sumSampleProcessingTime = 0;
        static void ProcessSampleThread() {
            while (true) {
                // Wait for callback to signal that a sample is ready for processing
                ProcessingSynchronization.ProcessSampleResetEvent.WaitOne();

                Debug.Print("ProcessSampleThread. Resetting reset event. Currently " + ProcessingSynchronization.ProcessSampleResetEvent.WaitOne(0, false));
                ProcessingSynchronization.ProcessSampleResetEvent.Reset();
                Debug.Print("  After reset: " + ProcessingSynchronization.ProcessSampleResetEvent.WaitOne(0, false));

                Debug.Print("ProcessSampleThread. Begin");

                _startTime = DateTime.Now;


                Debug.Print("ProcessSampleThread. Finished reading from ADC. Sample read:  " + Interpolation.Samples[Interpolation.NextSample]);

                // Print trace info
                var modSampleNumber = SampleData.SampleNumber % 100;
                if (modSampleNumber == 0) { Debug.Print(""); }
                if (modSampleNumber >= 0 && modSampleNumber < 10) {
                    var samples = "Interpolation Samples ";
                    foreach (var theSample in Interpolation.Samples) {
                        samples += " " + theSample;
                    }
                    Debug.Print(samples + ", NextSample:" + Interpolation.NextSample);
                    Debug.Print(SampleData.SampleNumber + " I:" + SampleData.CurrSample.I + ", Q:" + SampleData.CurrSample.Q);
                }

                // Process the sample
                ProcessSample();

                // Show processing time statistics
                var runTime = DateTime.Now - _startTime;
                _sumSampleProcessingTime += (runTime.Seconds * 1000) + runTime.Milliseconds;
                if (SampleData.SampleNumber % 10 == 0) {
                    Debug.Print("Sample Processing Time. Sum:" + _sumSampleProcessingTime + ", # samples:" + SampleData.SampleNumber + ", Mean:" + (_sumSampleProcessingTime / SampleData.SampleNumber));
                }

                ProcessingSynchronization.CurrentlyProcessingSample = IntBool.False;
            }
        }

    }
}