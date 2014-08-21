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

namespace Samraksh.Library.DataCollector.Radar {
    public partial class Program {

        private const int DataStoreBlockSize = 128 * 1024; // 128k bytes/block
        // ReSharper disable once UnusedMember.Local
        private const int DataStoreNumBlocks = 125;

        private const int BufferSize = 256; // Number of ushorts per ADC buffer
        private const int LargeDataStoreReferenceSize = (DataStoreBlockSize / 2) / sizeof(ushort);

        private const byte Eof = 0xF0;  // A ushort of F0F0 (2 bytes of Eof) is larger than a 12-bit sample (max 0FFF)

        private static readonly EnhancedEmoteLcd EnhancedLcd = new EnhancedEmoteLcd();
        private static readonly DataStore DataStore = DataStore.Instance(StorageType.SD, true);
        private static readonly LargeDataReference LargeDataRef = new LargeDataReference(DataStore, LargeDataStoreReferenceSize);

        private const int SampleIntervalMicroSec = 3906;

        private static DataStoreReturnStatus _retVal;

        private static class GpioPins {
            public static readonly InterruptPort EndCollect = new InterruptPort(Pins.GPIO_J11_PIN5, false, Port.ResistorMode.PullUp, Port.InterruptMode.InterruptEdgeBoth);
        }

        private static class LCDMessages {
            public const string Erasing = "eras";
            public const string Collecting = "cccc";
            public const string FinishSampling = "----";
            public const string TransferingToSD = "tttt";
            public const string Done = "0000";
            public const string Error = "err";
            public const string BufferQueueFull = "full";
        }

        private static bool _endCollectFlag;
        private static bool _bufferQueueIsFull;

        private static int _maxBuffersEnqueued;

        public static void Main() {
            var finalMsg = string.Empty;

            try {
                Debug.Print("\nData Collector Radar");

                // Initialize VersionInfo for this assembly
                VersionInfo.Init(Assembly.GetExecutingAssembly());
                Debug.Print("Version " + VersionInfo.Version + ", build " + VersionInfo.BuildDateTime);
                Debug.Print("");

                // Set up to detect end of collection
                GpioPins.EndCollect.OnInterrupt += (pin, state, time) => { _endCollectFlag = true; };

                // Set up SD
                Debug.Print("Setting up SD storage");
                EnhancedLcd.Display(LCDMessages.Erasing);
                // ReSharper disable once ObjectCreationAsStatement
                new SD(status => { });
                if (!SD.Initialize()) {
                    throw new InvalidOperationException("SD storage failed to initialize");
                }

                // Start sampling
                Debug.Print("Start sampling");
                EnhancedLcd.Display(LCDMessages.Collecting);


                // Start the ADC buffer processing thread
                var bufferThread = new Thread(ProcessSampleBufferQueue);
                bufferThread.Start();

                // Set up ADC
                //  This is done last since it starts right away, so ProcessSampleBufferQueue thread needs to be ready
                Debug.Print("Set up ADC");
                SetupADCBuffers();
                AnalogInput.InitializeADC();
                AnalogInput.InitChannel(ADCChannel.ADC_Channel1);
                AnalogInput.InitChannel(ADCChannel.ADC_Channel2);
                if (
                    !AnalogInput.ConfigureContinuousModeDualChannel(ADCBufferI, ADCBufferQ, BufferSize, SampleIntervalMicroSec,
                        ADCCallback)) {
                    throw new InvalidOperationException("Could not initialize ADC");
                }

                // Wait till we're finished sampling
                bufferThread.Join();

                if (_bufferQueueIsFull) {
                    EnhancedLcd.Display(LCDMessages.BufferQueueFull);
                    finalMsg = "Buffer queue is full";
                    return;
                }

                // Copy from DataStore to SD card
                if (!CopyToSD()) { throw new IOException("Writing to SD card failed"); }
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
                Thread.Sleep(Timeout.Infinite);
            }
        }

        //private static void SDCallback(DeviceStatus status) {

        //}

        //private static void EndCollect_Callback(uint pin, uint state, DateTime time) {
        //    _endCollectFlag = true;
        //}

    }
}
