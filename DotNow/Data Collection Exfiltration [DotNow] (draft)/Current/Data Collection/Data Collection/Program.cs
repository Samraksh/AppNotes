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
        public const int BufferSize = 512;
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

        private static readonly ushort[] IQbuffer = new ushort[AdcParameters.BufferSize * 2];

        private static readonly EmoteLcdUtil Lcd = new EmoteLcdUtil();

        private static readonly DataStore Dstore = DataStore.Instance(STORAGE_TYPE.NOR);
        private static DATASTORE_RETURN_STATUS _retVal;

        private static readonly AutoResetEvent StartSavingCollectionData = new AutoResetEvent(false);

        private static int _dataReferencesIn, _dataItemsIn;

        /// <summary>
        /// Get things started
        /// </summary>
        public static void Main() {
            // Basic setup
            Debug.EnableGCMessages(false);

            VersionInfo.Init(Assembly.GetExecutingAssembly());
            Debug.Print("Data Collector " + VersionInfo.Version + " (" + VersionInfo.BuildDateTime + ")");
            Lcd.Display("d c2");

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
            var samplesPerSecondBytes = new byte[4];
            ConvertUintToByteArray(AdcParameters.SamplesPerSecond, samplesPerSecondBytes);
            SD.Write(samplesPerSecondBytes, 0, 4);

            Debug.Print("Stored the samples per second value");

            // Start collecting sample data
            var processSampleBufferThread = new Thread(ProcessSampleBuffer);
            processSampleBufferThread.Start();

            // Collect for a while
            Debug.Print("* Collection started");

            // Run for the specified time
            //  Doing it this way since Data Store might fill up first; it can also signal that collection is done
            (new Thread(() => {
                Thread.Sleep(AdcParameters.SamplingDurationSec * 1000);
                Debug.Print("Collected for " + AdcParameters.SamplingDurationSec + " seconds");
                StartSavingCollectionData.Set();
            })).Start();

            // Wait till the collection time has elapsed or the Data Store is filled up
            StartSavingCollectionData.WaitOne();

            // Stop collecting
            AnalogInput.StopSampling();
            Debug.Print("* Collection stopped");

            // Copy from Data Store to SD
            var dataReferences = new DataReference[10];
            var offset = 0;
            var dataReferencesOut = 0;
            var dataItemsOut = 0;
            var sampleBytes = new byte[2];
            while (true) {
                if ((_retVal = Dstore.ReadAllDataReferences(dataReferences, offset)) != DATASTORE_RETURN_STATUS.Success) {
                    throw new Exception("Cannot get data references from offset " + offset + "; return value " + _retVal);
                }
                offset += dataReferences.Length;
                dataReferencesOut++;
                foreach (var theReference in dataReferences) {
                    dataItemsOut++;
                    if (dataItemsOut % 10 == 0) {
                        Debug.Print("  Writing sample " + dataItemsOut);
                    }
                    if (theReference == null) {
                        goto finished;
                    }
                    if (theReference.getDataReferenceSize != IQbuffer.Length) {
                        throw new Exception("Data reference size " + theReference.getDataReferenceSize + " is not equal to IQbuffer length " + IQbuffer.Length);
                    }
                    if (theReference.getDataReferenceType != typeof(ushort)) {
                        throw new Exception("Data reference type is " + theReference.getDataReferenceType + "; must be ushort");
                    }
                    if ((_retVal = theReference.Read(IQbuffer, 0, IQbuffer.Length)) != DATASTORE_RETURN_STATUS.Success) {
                        throw new Exception("Cannot read data from allocation (DS); return value " + _retVal);
                    }
                    foreach (var theSample in IQbuffer) {
                        ConvertUshortToByteArray(theSample, sampleBytes);
                    }
                    SD.Write(sampleBytes, 0, (ushort)sampleBytes.Length);
                }
            }
        finished:
            
            Debug.Print("\nFinished writing to SD");

            Debug.Print("");
            var dr = "Data References " + _dataReferencesIn + " in, " + dataReferencesOut + " out";
            Debug.Print(_dataReferencesIn == dataReferencesOut ? "" : "***** " + dr);
            var ditems = "Data Items" + _dataItemsIn + " in, " + dataItemsOut + " out";
            Debug.Print(_dataItemsIn == dataItemsOut ? "" : "***** " + ditems);
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

        private static void ProcessSampleBuffer() {
            while (true) {
                ProcessSampleBufferEvent.WaitOne();
                var startProcessing = DateTime.Now;
                for (var i = 0; i < Ibuffer.Length; i++) {
                    var iqIndex = i << 1;
                    IQbuffer[iqIndex] = Ibuffer[i];
                    IQbuffer[iqIndex | 1] = Qbuffer[i];
                    if (i % 10 == 0) {
                        Debug.Print("I: " + Ibuffer[i] + " Q: " + Qbuffer[i]);
                    }
                }

                var free = Dstore.FreeBytes;
                if (free < IQbuffer.Length * 2) {
                    Debug.Print("Filled up data store");
                    StartSavingCollectionData.Set();
                    return;
                }

                var dref = new DataReference(Dstore, IQbuffer.Length, REFERENCE_DATA_TYPE.UINT32);
                if ((_retVal = dref.Write(IQbuffer, 0, IQbuffer.Length)) != DATASTORE_RETURN_STATUS.Success) {
                    throw new Exception("Failed write data reference" + _retVal);
                }

                // Counters for later verification
                _dataReferencesIn++;
                _dataItemsIn += IQbuffer.Length;

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

        /// <summary>
        /// Convert Uint to Byte Array
        /// </summary>
        /// <param name="input">Input value</param>
        /// <param name="output">Byte array; must be size 4 or larger, else exception</param>
        private static void ConvertUintToByteArray(uint input, byte[] output) {
            output[0] = (byte)(input >> 24);
            output[1] = (byte)((input >> 16) & 0xff);
            output[2] = (byte)((input >> 8) & 0xff);
            output[3] = (byte)(input & 0xff);
        }

        /// <summary>
        /// Convert Ushort to Byte Array
        /// </summary>
        /// <param name="input">Input value</param>
        /// <param name="output">Byte array; must be size 2 or larger, else exception</param>
        private static void ConvertUshortToByteArray(ushort input, byte[] output) {
            output[0] = (byte)(input >> 8);
            output[1] = (byte)(input & 0xff);

        }

    }
}