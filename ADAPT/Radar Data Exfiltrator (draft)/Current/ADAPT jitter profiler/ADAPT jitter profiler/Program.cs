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

using System;
using System.IO.Ports;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
//using AnalogInput = Samraksh.eMote.Adapt.AnalogInput;

namespace Samraksh.AppNote.DotNow.RadarDataExfiltrator {

    /// <summary>
    /// Detector parameters
    /// </summary>
    public struct DetectorParameters {
        /// <summary>Number of milliseconds between samples</summary>
        //public const int SamplingIntervalMilliSec = 4000;    // Larger values => fewer samples/sec
        public const int SamplingIntervalMilliSec = 50000;    // Larger values => fewer samples/sec
        /// <summary>Number of samples per second</summary>
        public const int SamplesPerSecond = 1000000 / SamplingIntervalMilliSec;
        /// <summary>Number of microseconds between between samples</summary>
        public const int CallbackIntervalMs = SamplingIntervalMilliSec / 1000;
    }



    /// <summary>
    /// Jitter profiler
    /// </summary>
    public static class RadarDisplacementDetector {

        // Mapping between the GPIO pins stenciled on the ADAPT Dev board and those on the CPU itself
        //  On the Dev board, GPIO 01-04 are connected to LEDs
        private enum PinMap { Gpio01 = 58, Gpio02 = 55, Gpio03 = 53, Gpio04 = 52, Gpio05 = 51 };

        private static readonly OutputPort Led1 = new OutputPort((Cpu.Pin)PinMap.Gpio01, false);


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
            var sampleTimer = new Timer(TimerCallback, null, 0, DetectorParameters.CallbackIntervalMs);
            Debug.Print("Started the timer with interval " + DetectorParameters.CallbackIntervalMs);

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
        }
    }
}