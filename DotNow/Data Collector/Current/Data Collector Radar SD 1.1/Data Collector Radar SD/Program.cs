/*******************************************
 * Data Collector Radar SD
 *      Collects BumbleBee radar data and stores it on an SD card for later exfiltration
 * Version
 *  1.1 Initial version (1.0 was a very early version and was not released)
*******************************************/

using System;
using System.IO;
using System.Reflection;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;
using Samraksh.eMote.NonVolatileMemory;
using AnalogInput = Samraksh.eMote.DotNow.AnalogInput;

namespace Samraksh.AppNote.DataCollector.Radar {
    /// <summary>
    /// Main program
    /// </summary>
    public partial class Program {

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
        private const byte Eof = 0xF0;  // A ushort of F0F0 (2 bytes of Eof) is larger than a 12-bit sample (max 0FFF)

        // Misc definitions
        private static readonly EnhancedEmoteLcd EnhancedLcd = new EnhancedEmoteLcd();
        private static readonly DataStore DataStore = DataStore.Instance(StorageType.SD, true);
        private static readonly LargeDataReference LargeDataRef = new LargeDataReference(DataStore, LargeDataStoreReferenceSize);
        private static DataStoreReturnStatus _retVal;
        private static bool _debuggerIsAttached;

        // The sampling interval in micro seconds. Sample rate = 1,000,000 / SampleIntervalMicroSec
        private const int SampleIntervalMicroSec = 3906;

        // Define the GPIO pins used
        private static class GpioPins {
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
            public const string FinishSampling = "----";
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

                Debug.Print("\nData Collector Radar");

                // Print the version and build info
                VersionInfo.Init(Assembly.GetExecutingAssembly());
                Debug.Print("Version " + VersionInfo.Version + ", build " + VersionInfo.BuildDateTime);
                Debug.Print("");

                // Note whether the debugger is attached
                //  Used to suppress print messages during buffer processing if not debugging
                //  Otherwise, print statements can create and discard strings and trigger a garbage collection
                _debuggerIsAttached = System.Diagnostics.Debugger.IsAttached;

                // Set up the GPIO to detect end of collection
                GpioPins.EndCollect.OnInterrupt += (pin, state, time) => { _collectIsDone = true; };

                // Set up the SD card
                Debug.Print("Setting up SD storage");
                EnhancedLcd.Display(LCDMessages.Erasing);
                // ReSharper disable once ObjectCreationAsStatement
                new SD(status => { });  // Even though this seems to be a do-nothing method call, it's still necessary before initializing the SD card
                if (!SD.Initialize()) {
                    throw new InvalidOperationException("SD storage failed to initialize");
                }

                // Start sampling
                Debug.Print("Start sampling");
                EnhancedLcd.Display(LCDMessages.Collecting);
                
                // Start the ADC buffer processing thread
                //  This is done first since the ADC sampling below starts right away, so better to start WriteSampleBufferQueue thread first
                //      Note that since we have ADC buffer queues, this isn't strictly necessary
                var bufferThread = new Thread(WriteSampleBufferQueue);
                bufferThread.Start();

                // Set up ADC
                Debug.Print("Set up ADC");
                // Pre-allocate an array of sample buffers
                SetupADCBuffers();
                // Initialize the ADC and the channels
                AnalogInput.InitializeADC();
                AnalogInput.InitChannel(ADCChannel.ADC_Channel1);
                AnalogInput.InitChannel(ADCChannel.ADC_Channel2);
                // Start the continuous mode dual channel sampling
                //  SampleIntervalMicroSec gives the interval between samples, in micro seconds
                //  ADCCallback is called when ADCBufferSize number of samples has been collected
                //  On callback, ADCBufferI and ADCBufferQ contain the data
                if (
                    !AnalogInput.ConfigureContinuousModeDualChannel(ADCBufferI, ADCBufferQ, ADCBufferSize, SampleIntervalMicroSec,
                        ADCCallback)) {
                    throw new InvalidOperationException("Could not initialize ADC");
                }

                // Wait till we're finished sampling
                //  When the user enagles the EndCollect pin, bufferThread will terminate
                bufferThread.Join();

                // If the buffer filled up, give error
                if (_bufferQueueIsFull) {
                    EnhancedLcd.Display(LCDMessages.BufferQueueFull);
                    throw new IOException("Buffer queue is full");
                }

                // Copy from DataStore to SD card
                if (!CopyToSD()) {
                    throw new IOException("Writing to SD card failed");
                }
                finalMsg = "Finished";
                EnhancedLcd.Display(LCDMessages.Done);
            }
            catch (Exception ex) {
                finalMsg = ex.Message;
                EnhancedLcd.Display(LCDMessages.Error);
            }
            finally {
                Debug.Print("Up to " + _maxBuffersEnqueued + " buffers were enqueued");
                Debug.Print(finalMsg);
            }
        }
    }
}
