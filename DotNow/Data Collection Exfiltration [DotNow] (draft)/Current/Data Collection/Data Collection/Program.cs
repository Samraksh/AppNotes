/*--------------------------------------------------------------------
 * Data Collection: app note for the eMote .NOW
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *      1.0: initial release
 *      
---------------------------------------------------------------------*/

using System;
using System.Reflection;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using AnalogInput = Samraksh.eMote.DotNow.AnalogInput;
using Samraksh.eMote.DotNow;
using Samraksh.eMote.NonVolatileMemory;

using Samraksh.AppNote.Utility;

namespace Samraksh.AppNote.DotNow.DataCollector {
    /// <summary>
    /// ADC parameters
    /// </summary>
    public struct AdcParameters {
        /// <summary>Number of milliseconds between samples</summary>
        public const int SamplingIntervalMilliSec = 4000;    // Larger values => fewer samples/sec
        /// <summary>Number of samples to collect before presenting for processing</summary>
        //public const int BufferSize = 500;
        public const int BufferSize = 500;
        /// <summary>Number of samples per second</summary>
        public const int SamplesPerSecond = 1000000 / SamplingIntervalMilliSec;
        /// <summary>Number of microseconds between invocation of buffer processing callback</summary>
        public const int CallbackIntervalMs = (BufferSize * 1000) / SamplesPerSecond;
        /// <summary>How long to sample</summary>
        public const int SamplingDurationSec = 10;
        ///// <summary>Number of minor displacement events that must occur for displacement detection</summary>
        //public const int M = 2;
        ///// <summary>Number of seconds for which a displacement detection can last</summary>
        //public const int N = 8;
        ///// <summary>Minimum number of cuts (phase unwraps) that must occur for a minor displacement event</summary>
        ////public const int MinCumCuts = 4;
        //public const int MinCumCuts = 6;
        ///// <summary>The centimeters traversed by one cut. This is a fixed characteristic of the Bumblebee; do not change this value.</summary>
        //public const float CutDistanceCm = 5.2f / 2;
    }


    /// <summary>
    /// Data Collector
    ///     Collects data and saves it for later exfiltration
    /// </summary>
    public static class DataCollector {

        private static readonly OutputPort EnableBumbleBee = new OutputPort(Pins.GPIO_J11_PIN3, true);

        private static readonly ushort[] Ibuffer = new ushort[AdcParameters.BufferSize];
        private static readonly ushort[] Qbuffer = new ushort[AdcParameters.BufferSize];

        private static readonly EmoteLcdUtil Lcd = new EmoteLcdUtil();

        private static readonly DataStore Dstore =  DataStore.Instance(STORAGE_TYPE.NOR);
        private static DATASTORE_RETURN_STATUS _retVal;

        private static readonly AutoResetEvent WaitForCollectionDone = new AutoResetEvent(false);

        /// <summary>
        /// Get things started
        /// </summary>
        public static void Main() {
            // Basic setup
            Debug.EnableGCMessages(false);

            VersionInfo.Init(Assembly.GetExecutingAssembly());
            Debug.Print("Data Collector " + VersionInfo.Version + " (" + VersionInfo.BuildDateTime + ")");
            Lcd.Display("d c");

            Debug.Print("Power Level: " + PowerState.CurrentPowerLevel + " (16=High, 32=Med, 48=Low");
            PowerState.ChangePowerLevel(PowerLevel.High);

            Debug.Print("Bytes free: " + Debug.GC(true));

            Debug.Print("Parameters");
            Debug.Print("   SamplingIntervalMilliSec " + AdcParameters.SamplingIntervalMilliSec);
            Debug.Print("   BufferSize " + AdcParameters.BufferSize);
            Debug.Print("   SamplesPerSecond " + AdcParameters.SamplesPerSecond);
            Debug.Print("   CallbackIntervalMs " + AdcParameters.CallbackIntervalMs);
            Debug.Print("");

            Thread.Sleep(4000); // Wait a bit before launch

            // Start ADC sampling
            AnalogInput.InitializeADC();
            AnalogInput.ConfigureContinuousModeDualChannel(Ibuffer, Qbuffer, (uint)Ibuffer.Length, AdcParameters.SamplingIntervalMilliSec, AdcBuffer_Callback);

            // Initialize the data store
            if ((_retVal = Dstore.DeleteAllData()) != DATASTORE_RETURN_STATUS.Success) {
                throw new Exception("Cannot delete the data store; return value " + _retVal);
            }
            Debug.Print("Data store initialized");

            // Initialize the SD card
            if (!SD.Initialize()) {
                Debug.Print("Cannot initialize SD");
                return;
            }
            Debug.Print("SD initialized");

            // Store the sampling info first
            var parameters = new[] { (uint)AdcParameters.SamplesPerSecond };
            var dref = new DataReference(Dstore, parameters.Length, REFERENCE_DATA_TYPE.UINT32);
            if ((_retVal = dref.Write(parameters, 0, parameters.Length)) != DATASTORE_RETURN_STATUS.Success) {
                throw new Exception("Failed write data reference for samples per second" + _retVal);
            }
            Debug.Print("Stored the samples per second");


            // Start collecting sample data
            var processSampleBufferThread = new Thread(ProcessSampleBuffer);
            processSampleBufferThread.Start();

            // Collect for a while
            Debug.Print("* Collection started");

            // Run for the specified time
            //  Doing it this way since Data Store might fill up first; it can also signal that collection is done
            (new Thread(() => {
                Thread.Sleep(AdcParameters.SamplingDurationSec * 1000);
                WaitForCollectionDone.Set();
            })).Start();


            WaitForCollectionDone.WaitOne();

            // Stop sampling and terminate
            AnalogInput.StopSampling();
            Debug.Print("* Collection stopped");

        }

        private static int _currentlyProcessingBuffer = IntBool.False;
        private static int _callbackCtr;
        static readonly AutoResetEvent ProcessSampleBufferEvent = new AutoResetEvent(false);

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
            ProcessSampleBufferEvent.Set();
        }

        private static readonly byte[] DataArray = new byte[4];

        private static void ProcessSampleBuffer() {
            while (true) {
                ProcessSampleBufferEvent.WaitOne();
                var startProcessing = DateTime.Now;
                for (var i = 0; i < Ibuffer.Length; i++) {
                    DataArray[0] = (byte)(Ibuffer[i] >> 8);
                    DataArray[1] = (byte)(Ibuffer[i] & 0xff);
                    DataArray[2] = (byte)(Qbuffer[i] >> 8);
                    DataArray[3] = (byte)(Qbuffer[i] & 0xff);
                    if (i % 10 == 0) {
                        Debug.Print("I: " + Ibuffer[i] + " Q: " + Qbuffer[i]);
                    }
                    SD.Write(DataArray, 0, (ushort)DataArray.Length);
                }
                var processingTime = DateTime.Now - startProcessing;
                Debug.Print("\nProcessing Time: " + (processingTime.Seconds * 1000 + processingTime.Milliseconds) + ", Callback Interval: " + AdcParameters.CallbackIntervalMs);
                Debug.Print("");
                _currentlyProcessingBuffer = IntBool.False;
            }
        }

        private struct IntBool {
            public const int True = 1;
            public const int False = 0;
        }

    }
}