using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.SPOT.Hardware;
using Samraksh.SPOT.NonVolatileMemory;
using System.IO.Ports;
using System.Threading;


namespace Samraksh.SPOT.APPS {
    public abstract class PersistentStorage {
        abstract public bool Write(ushort[] data, UInt16 length);
        abstract public bool Write(byte[] data, UInt16 length);
        abstract public byte[] Read(int bufferSize);
        abstract public bool Read(ushort[] data, UInt16 length);
        abstract public bool WriteEof();
        abstract public int GetBytesSaved();
    }

    public class NorStore : PersistentStorage {
        public static OutputPort resultFailure = new OutputPort(Samraksh.SPOT.Hardware.EmoteDotNow.Pins.GPIO_J11_PIN3, false);
        public static OutputPort resultRWData = new OutputPort(Samraksh.SPOT.Hardware.EmoteDotNow.Pins.GPIO_J12_PIN2, false);
        //public static OutputPort resultDeleteData = new OutputPort(Samraksh.SPOT.Hardware.EmoteDotNow.Pins.GPIO_J12_PIN2, false);

        public const uint NorSize = 12 * 1024 * 1024;
        public const bool debugMode = true;
        public bool flag = true;
        public int bytesWritten = 0;

        public ushort[] verfier = new ushort[1024];
        public byte[] verfierDS = new byte[1024];

        DataStore dStore;
        Data dataDS;
        Type dataType = typeof(System.Byte);

        public NorStore() {
            dStore = new DataStore((int)StorageType.NOR);
        }

        public override bool Write(byte[] data, UInt16 length) {
            resultRWData.Write(false);
            dataDS = new Data(dStore, (uint)data.Length, dataType);
            if (dataDS.Write(data, (uint)data.Length) == DataStatus.Success) {
                Debug.Print("Write to NOR succeeded\n");
                resultRWData.Write(true);
                //return true;
            }
            else {
                Debug.Print("Write to NOR failed\n");
                resultRWData.Write(false);
                resultFailure.Write(true);
                return false;
            }

            if (debugMode) {
                verfierDS = Read(1024);
                /*if (dataDS.Read(verfierDS) != DataStatus.Success)
                {
                    Debug.Print("Read from NOR failed during verification\n");
                    resultRWData.Write(false);
                    resultFailure.Write(true);
                    return false;
                }*/

                for (UInt16 index = 0; index < verfierDS.Length; index++) {
                    if (verfierDS[index] != data[index]) {
                        Debug.Print("Write Failed");
                        resultRWData.Write(false);
                        resultFailure.Write(true);
                        flag = false;
                        return false;
                    }
                }
                if (flag == true)
                    Debug.Print("Write and read succeeded");
            }
            return true;
        }


        public override int GetBytesSaved() {
            return bytesWritten;
        }


        /*public override bool Write(ushort[] data, UInt16 length)
        {
            if (Samraksh.SPOT.Hardware.EmoteDotNow.NOR.IsFull())
            {
                return false;
            }

            if (!Samraksh.SPOT.Hardware.EmoteDotNow.NOR.Write(data, length))
            {
                Debug.Print("Write Failed");
                return false;
            }

            Samraksh.SPOT.Hardware.EmoteDotNow.NOR.Read(verfier, length);

            Debug.Print(verfier[10].ToString());

            bytesWritten += length * 2;

            if (debugMode)
            {
                if (Samraksh.SPOT.Hardware.EmoteDotNow.NOR.Read(verfier, length) != Samraksh.SPOT.Hardware.DeviceStatus.Success)
                {
                    Debug.Print("Read from NOR failed during verification\n");
                    return false;
                }

                for (UInt16 i = 0; i < length; i++)
                {
                    if (verfier[i] != data[i])
                    {
                        Debug.Print("Write Failed");
                    }
                    else if (data[i] == 255)
                    {
                        Debug.Print("Writing 255");
                    }
                }
            }

            return true;
        }*/


        public override byte[] Read(int bufferSize) {
            byte[] readBuffer = new byte[bufferSize];
            if (dataDS.Read(readBuffer, 0, (uint)bufferSize) != DataStatus.Success) {
                Debug.Print("Read from NOR failed during verification\n");
                resultRWData.Write(false);
                resultFailure.Write(true);
            }
            return readBuffer;
        }


        /*public override bool Read(ushort[] data, UInt16 length)
        {
            if (!Samraksh.SPOT.Hardware.EmoteDotNow.NOR.eof())
            {
                if (Samraksh.SPOT.Hardware.EmoteDotNow.NOR.Read(data, length) != Samraksh.SPOT.Hardware.DeviceStatus.Success)
                {
                    Debug.Print("Read from NOR failed \n");
                    return false;
                }
            }
            else
                return false;

            return true;
        }*/

        public override bool WriteEof() {
            byte[] eof = new byte[1024];

            for (UInt16 i = 0; i < eof.Length; i++) {
                eof[i] = (byte)0x0c;
            }

            //Samraksh.SPOT.Hardware.EmoteDotNow.NOR.Write(eof, (ushort) eof.Length);
            dataDS = new Data(dStore, (uint)eof.Length, dataType);
            if (dataDS.Write(eof, (uint)eof.Length) == DataStatus.Success)
                return true;
            else
                return false;
        }
    }


    public class BufferStorage {
        public ushort[] buffer;
        public byte[] byteBuffer;

        public Object bufferLock = new object();
        public bool bufferfull = false;

        public BufferStorage(uint BufferSize) {
            buffer = new ushort[BufferSize];
        }

        public void Copy(ushort[] inpArray) {
            lock (bufferLock) {
                inpArray.CopyTo(buffer, 0);
                bufferfull = true;
            }
        }

        public bool IsFull() {
            lock (bufferLock) {
                return bufferfull;
            }
        }

        public bool Persist(PersistentStorage storage) {
            lock (bufferLock) {
                byteBuffer = ShortToByte(buffer);
                //if (!storage.Write(buffer, (ushort)buffer.Length))
                if (!storage.Write(byteBuffer, (UInt16)byteBuffer.Length)) {
                    return false;
                }

                bufferfull = false;
            }

            return true;
        }

        public byte[] ShortToByte(ushort[] inputBuffer) {
            byte[] outputBuffer = new byte[inputBuffer.Length * 2];
            //outputBuffer = (byte)(Convert.ToByte(inputBuffer));
            for (UInt16 index = 0; index < inputBuffer.Length; index++) {
                outputBuffer[index] = (byte)(inputBuffer[index] >> 8);
                outputBuffer[index + 1] = (byte)(inputBuffer[index] & 255);
            }
            return outputBuffer;
        }

    }


    public class DataCollectorNOR {
        public const bool debugMode = false;
        public const uint bufferSize = 1024;
        //public const uint sampleTime = 1000;
        uint samplingTime = 1000;
        const uint numberOfSamples = 1000;

        public ushort[] sampleBuffer = new ushort[bufferSize];
        public ushort[] ibuffer = new ushort[numberOfSamples];
        public ushort[] qbuffer = new ushort[numberOfSamples];

        public Samraksh.SPOT.Hardware.EmoteDotNow.AdcCallBack adcCallbackPtr;
        public System.IO.Ports.SerialPort serialPort;
        public BufferStorage buffer;
        public PersistentStorage storage;

        public static OutputPort debugPort = new OutputPort(Samraksh.SPOT.Hardware.EmoteDotNow.Pins.GPIO_J12_PIN1, false);
        //public static OutputPort norWriteTime = new OutputPort(Samraksh.SPOT.Hardware.EmoteDotNow.Pins.GPIO_J12_PIN5, false);

        public int dataCollected = 0;
        public static bool stopExperimentFlag = false;
        public static InterruptPort stopExperiment = new InterruptPort(Samraksh.SPOT.Hardware.EmoteDotNow.Pins.GPIO_J11_PIN7, false, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeLow);

        public DataCollectorNOR() {
            buffer = new BufferStorage(bufferSize);
            storage = new NorStore();

            Debug.Print("Initializing Serial ....");

            serialPort = new SerialPort("COM1");
            serialPort.BaudRate = 115200;
            serialPort.Parity = System.IO.Ports.Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.DataBits = 8;
            serialPort.Handshake = Handshake.None;

            Debug.Print("Initializing ADC .....");

            stopExperiment.OnInterrupt += stopExperiment_OnInterrupt;

            adcCallbackPtr = AdcCallbackFn;
            Samraksh.SPOT.Hardware.EmoteDotNow.AnalogInput.InitializeADC();
            //Samraksh.SPOT.Hardware.EmoteDotNow.AnalogInput.InitChannel(Samraksh.SPOT.Hardware.EmoteDotNow.ADCChannel.ADC_Channel1);
            //Samraksh.SPOT.Hardware.EmoteDotNow.AnalogInput.ConfigureContinuousMode(sampleBuffer, Samraksh.SPOT.Hardware.EmoteDotNow.ADCChannel.ADC_Channel1, bufferSize, sampleTime, AdcCallbackFn);

            Samraksh.SPOT.Hardware.EmoteDotNow.AnalogInput.ConfigureContinuousModeDualChannel(ibuffer, qbuffer, numberOfSamples, samplingTime, AdcCallbackFn);
        }

        void stopExperiment_OnInterrupt(uint data1, uint data2, DateTime time) {
            Samraksh.SPOT.Hardware.EmoteDotNow.AnalogInput.StopSampling();
            stopExperimentFlag = true;
        }

        public void AdcCallbackFn(long threshold) {
            debugPort.Write(true);
            debugPort.Write(false);
            Debug.Print(" I " + ibuffer[200].ToString() + " Q " + qbuffer[200].ToString() + "\n");
            buffer.Copy(sampleBuffer);
            dataCollected += (sampleBuffer.Length * 2);
        }

        public void Run() {
            while (true) {
                if (buffer.IsFull()) {
                    //norWriteTime.Write(true);
                    buffer.Persist(storage);
                    //norWriteTime.Write(false);
                }

                System.Threading.Thread.Sleep(1000);

                if (stopExperimentFlag) {
                    storage.WriteEof();
                    break;
                }
            }

            Debug.Print("Total number of bytes collected : " + dataCollected.ToString());
            Debug.Print("Total number of bytes written : " + storage.GetBytesSaved().ToString());
            Debug.Print("Experiment Complete\n");
        }

        public static void Main() {

            Debug.EnableGCMessages(false);

            Debug.Print("Sleeping for 10s");
            Thread.Sleep(10000);

            Debug.Print("Starting ..");

            DataCollectorNOR dcrn = new DataCollectorNOR();

            dcrn.Run();
        }

    }
}
