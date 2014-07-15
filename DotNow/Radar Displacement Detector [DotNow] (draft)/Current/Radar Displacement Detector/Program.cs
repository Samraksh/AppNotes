/*--------------------------------------------------------------------
 * Radar Displacement Detector: app note for the eMote .NOW
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *      1.0: initial release
 *      1.1: Removed check for background noise
 *      
---------------------------------------------------------------------*/

using System.Reflection;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;
using AnalogInput = Samraksh.eMote.DotNow.AnalogInput;

namespace Samraksh.AppNote.DotNow.RadarDisplacementDetector {

    /// <summary>
    /// Radar Displacement Detector
    ///     Detects displacement (towards or away from the radar)
    ///     Filters out "back and forth" movement (such as trees blowing in the wind)
    /// </summary>
    public static partial class RadarDisplacementDetector {

        private static readonly ushort[] Ibuffer = new ushort[DetectorParameters.BufferSize];
        private static readonly ushort[] Qbuffer = new ushort[DetectorParameters.BufferSize];

        private static readonly EmoteLcdUtil Lcd = new EmoteLcdUtil();

        /// <summary>
        /// Get things started
        /// </summary>
        public static void Main() {
            // Basic setup
            Debug.EnableGCMessages(false);

            VersionInfo.Init(Assembly.GetExecutingAssembly());
            Debug.Print("Radar Motion Detection " + VersionInfo.Version + " (" + VersionInfo.BuildDateTime + ")");
            Lcd.Display("radar");

            Debug.Print("Power Level: " + PowerState.CurrentPowerLevel + " (16=High, 32=Med, 48=Low");
            PowerState.ChangePowerLevel(PowerLevel.High);

            Debug.Print("Bytes free: " + Debug.GC(true));

            Debug.Print("Parameters");
            Debug.Print("   SamplingIntervalMilliSec " + DetectorParameters.SamplingIntervalMilliSec);
            Debug.Print("   BufferSize " + DetectorParameters.BufferSize);
            Debug.Print("   SamplesPerSecond " + DetectorParameters.SamplesPerSecond);
            Debug.Print("   CallbackIntervalMs " + DetectorParameters.CallbackIntervalMs);
            Debug.Print("   M " + DetectorParameters.M);
            Debug.Print("   N " + DetectorParameters.N);
            Debug.Print("   MinCumCuts " + DetectorParameters.MinCumCuts);
            Debug.Print("   CutDistCm " + DetectorParameters.CutDistanceCm);
            Debug.Print("");

            Thread.Sleep(4000); // Wait a bit before launch

            // Set up a thread to process sample buffers
            //  This lets the ADC callback, AdcBuffer_Callback, finish quickly and avoids issues if processing takes too long
            var processSampleBufferThread = new Thread(ProcessSampleBuffer);
            processSampleBufferThread.Start();

            // Initialize displacement analysis
            Radar.DisplacementAnalysis.AnalyzeDisplacement.Initialize(DetectorParameters.SamplingIntervalMilliSec, DetectorParameters.M, DetectorParameters.N, DetectorParameters.MinCumCuts, DetectDisplacementCallback);

            // Start ADC sampling
            AnalogInput.InitializeADC();
            AnalogInput.ConfigureContinuousModeDualChannel(Ibuffer, Qbuffer, (uint)Ibuffer.Length, DetectorParameters.SamplingIntervalMilliSec, AdcBuffer_Callback);

            Thread.Sleep(Timeout.Infinite);
        }

        private static int _currentlyProcessingBuffer = IntBool.False;
        private static int _callbackCtr;
        static readonly AutoResetEvent ProcessSampleBufferAutoResetEvent = new AutoResetEvent(false);

        /// <summary>
        /// Callback for buffered ADC
        /// </summary>
        /// <param name="threshold"></param>
        private static void AdcBuffer_Callback(long threshold) {

            // Check if we're currently processing a buffer. If so, give message and return
            //  The variable _currentlyProcessingBuffer is reset in ProcessSampleBuffer.
            if (Interlocked.CompareExchange(ref _currentlyProcessingBuffer, IntBool.True, IntBool.False) == IntBool.True) {
                Debug.Print("***************************************************************** Missed a buffer; callback #" + (++_callbackCtr));
                return;
            }

            // Not currently processing a buffer. Signal processing and return.
            ProcessSampleBufferAutoResetEvent.Set();
        }

    }
}