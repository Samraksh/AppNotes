/*************************************************************
 * eMote .NOW Microphone Data Collector
 *      Collects microphone data and stores it on an SD card for later exfiltration
 * Versions
 *      1.1 
 *			-	Initial release (1.0 was a very early version and was not released)
 *		1.2
 *			-	Minor updates
 *      1.3
 *			-	Update to eMote v. 1.12 namespaces
 ***********************************************************/

using System;
using System.Reflection;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.IO;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;
using Samraksh.eMote.NonVolatileMemory;
using AnalogInput = Samraksh.eMote.DotNow.AnalogInput;

namespace Samraksh.AppNote.DataCollector.Mic {
    public static partial class Program {

        // Set up parameters for collection and for DataStore
        //  DataStore can only track 256 data references. 
        //      If each ADC buffer's work were a separate data reference, the limit would be quickly reached.
        //  LargeDataStore lets multiple buffers be stored in one data reference
        //  For efficiency, ADCBufferSize should divide LargeDataStoreReferenceSize
        private const int DataStoreBlockSize = 128 * 1024; // 128k bytes/block
        // ReSharper disable once UnusedMember.Local
        private const int DataStoreNumBlocks = 125;
        private const int ADCBufferSize = 256; // Number of ushorts per ADC buffer
        private const int LargeDataStoreReferenceSize = (DataStoreBlockSize / 2) / sizeof(ushort);

        // End of file value
        //  This must be the same value across all Data Collector programs 
        private const byte Eof = 0xF0; // A ushort of F0F0 (2 bytes of Eof) is larger than a 12-bit sample (max 0FFF)

        // Misc definitions
        private static readonly DataStore DStore = DataStore.Instance(StorageType.NOR, true);
        private static readonly LargeDataReference LargeDataRef = new LargeDataReference(DStore, LargeDataStoreReferenceSize);
        private static DataStoreReturnStatus _retVal;
        private static bool _debuggerIsAttached;

        // The sampling interval in micro seconds. Sample rate per sec = 1,000,000 / SampleIntervalMicroSec
        private const int SampleIntervalMicroSec = 1000;

        // Define the GPIO pins used
        private static class GpioPins {
            // Pin 11/5
            public static readonly InterruptPort EndCollect = new InterruptPort(Pins.GPIO_J11_PIN5, false, Port.ResistorMode.PullUp, Port.InterruptMode.InterruptEdgeBoth);
        }

        // Flag that's set when the user enables the EndCollect GPIO pin
        //  This stops the data collection after the current buffer is processed
        private static bool _collectIsDone;

        // Flag that the sample data buffer queue is full
        //  This means that the time to process data was larger than the time required to collect the data
        //  This means the data collection failed
        private static bool _bufferQueueIsFull;

        // The maximum number of buffers used. Reported at the end.
        private static int _maxBuffersEnqueued;

	    // Define the messages displayed on the LCD
        private static class LCDMessages {
            public const string Erasing = "eras";
            public const string Collecting = "cccc";
            public const string FinishSampling = "xxxx";
            public const string TransferingToSD = "tttt";
            public const string Done = "0000";
            public const string Error = "err";
            public const string BufferQueueFull = "full";
        }

        /// <summary>
        /// The main program
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="IOException"></exception>
        public static void Main() {
            var finalMsg = string.Empty;
            try {
                Debug.EnableGCMessages(false);

                Debug.Print("\nData Collector Microphone");

                // Print the version and build info
                Debug.Print(VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));
                Debug.Print("");

                // Note whether the debugger is attached
                //  Used to suppress print messages during buffer processing if not debugging
                //  Otherwise, print statements can create and discard strings and trigger a garbage collection
                _debuggerIsAttached = System.Diagnostics.Debugger.IsAttached;

                // Set up the GPIO to detect end of collection
                GpioPins.EndCollect.OnInterrupt += (pin, state, time) => { _collectIsDone = true; };

                // Set up the SD card
                Debug.Print("Setting up SD storage");
				Globals.EnhancedLcd.Write(LCDMessages.Erasing);
                // ReSharper disable once ObjectCreationAsStatement
                new SD(status => { }); // Even though this seems to be a do-nothing method call, it's still necessary before initializing the SD card
                if (!SD.Initialize()) {
                    throw new InvalidOperationException("SD storage failed to initialize");
                }

                // Start sampling
                Debug.Print("Start sampling");
				Globals.EnhancedLcd.Write(LCDMessages.Collecting);

                // Start the ADC buffer processing thread
                //  This is done first since the ADC sampling below starts right away, so better to start WriteSampleBufferQueue thread first
                //      Note that since we have ADC buffer queues, this isn't strictly necessary
                var bufferThread = new Thread(WriteSampleBufferQueue);
                bufferThread.Start();

                // Set up ADC
                Debug.Print("Set up ADC");
                // Pre-allocate an array of sample buffers
                SetupADCBuffers();

                AnalogInput.InitializeADC();
                AnalogInput.InitChannel(ADCChannel.ADC_Channel1);
                var retVal = AnalogInput.ConfigureContinuousMode(ADCBuffer, ADCChannel.ADC_Channel1, ADCBufferSize, SampleIntervalMicroSec, ADCCallback);
                if (retVal != 1) {
					Globals.EnhancedLcd.Write(LCDMessages.Error);
                    throw new InvalidOperationException("Could not initialize ADC");
                }
                // Wait till we're finished sampling
                //  When the user enagles the EndCollect pin, bufferThread will terminate
                bufferThread.Join();

                // If the buffer filled up, give error
                if (_bufferQueueIsFull) {
					Globals.EnhancedLcd.Write(LCDMessages.BufferQueueFull);
                    throw new IOException("Buffer queue is full");
                }

                // Copy from DataStore to SD card
                if (!CopyToSD()) {
                    throw new IOException("Writing to SD card failed");
                }
                finalMsg = "Finished";
				Globals.EnhancedLcd.Write(LCDMessages.Done);
            }
            catch (Exception ex) {
                finalMsg = ex.Message;
				Globals.EnhancedLcd.Write(LCDMessages.Error);
            }
            finally {
                var samplesProcessed = _buffersProcessedCtr * ADCBufferSize;
                Debug.Print("");
                Debug.Print(samplesProcessed * sizeof(ushort) + " bytes, " + samplesProcessed + " ushorts, " + _buffersProcessedCtr + " buffers");
                Debug.Print("Up to " + _maxBuffersEnqueued + " buffers were enqueued");
                Debug.Print(finalMsg);
                Debug.Print("");
            }
        }
    }
}
