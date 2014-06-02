using System;
using System.IO.Ports;
using System.Threading;

using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Samraksh.SPOT.Emulator
{
    enum AdcMode { SingleShot, Batch, Continuous };
    enum AdcDataAlign { Right, Left };
    enum AdcExternalTrigConv { None, Rising, Falling };

    public class ADC_Configuration
    {
        public short NumberOfChannels = 3;
        public AdcSampleTime SampleTime;
    }
    
    public enum AdcSampleTime
    {
        ADC_SampleTime_1_5_Cycles = 0,
        ADC_SampleTime_7_5_Cycles = 1,
        ADC_SampleTime_13_5_Cycles = 2,
        ADC_SampleTime_28_5_Cycles = 3,
        ADC_SampleTime_41_5_Cycles = 4,
        ADC_SampleTime_55_5_Cycles = 5,
        ADC_SampleTime_71_5_Cycles = 6,
        ADC_SampleTime_239_5_Cycles = 7,
    }

    public delegate void AdcCallback(bool Status);
    
    public class ADC
    {
        //ADC_Configuration Config;
        ushort NumberOfChannels=3;
        SerialPort ADCPort;
        ushort[] ADCValue;
        uint SamplingTime =100000;
        Thread SamplingThread;

        //Batch/Continous mode parameters
        bool BatchMode = false;
        bool ContinuousMode = false;
        uint NumberOfSamples = 0;
        AdcCallback AppCallback;
        ushort[] BatchBuffer;
        ushort[] ContinuousBuffer;
        uint CurSampleNumber=0;

      
        /*public ADC(ushort NumberOfChannels, AdcSampleTime SampleTime)
        {
            Config = Configuration;
            ADCValue = new ushort[Config.NumberOfChannels];
        }*/
      
        public int Init(AdcSampleTime SampleTime, int _NumberOfChannels)
        {
            Debug.Print("Initializing ADC...");
            try
            {
                NumberOfChannels = (ushort)_NumberOfChannels;
                ADCValue = new ushort[NumberOfChannels];
                SamplingThread = new Thread(new ThreadStart(ReadChannels));
                ADCPort = new SerialPort("COM1");
                ADCPort.ReadTimeout = 0;      
                ADCPort.Open();
                //ADCPort.DataReceived += new SerialDataReceivedEventHandler(ADCPort_DataReceived);
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
                return 0;
            }
            
            SamplingThread.Start();
            return 1;
        }

        public void Stop()
        {
            SamplingThread.Suspend();
            BatchMode = false;
            ContinuousMode = false;
            AppCallback = null;
            NumberOfSamples = 0;
        }
               
        public int GetData(ushort[] currSample, uint startChannel, uint numChannels)
        {
            if (startChannel > 2 || (startChannel + numChannels > 3))
                return 0;

            if (!ADCPort.IsOpen)
            {
                Debug.Print("Opening ADCPort");
                ADCPort.Open();
            }
           
            for (int i = (int)startChannel; i < (int)startChannel+numChannels; i++)
                currSample[i] = ADCValue[i];
            return 1;
        }
        
        public int ConfigureBatchMode(ushort[] SampleBuff, uint StartChannel, uint NumChannels, uint NumSamples, uint _SamplingTime, AdcCallback Callback)
        {
            if (StartChannel > 2 || (StartChannel + NumChannels > 3))
                return 0;
            
            if (ContinuousMode) return 0; //Check if continuous mode is already running

            BatchMode = true;
            NumberOfSamples = NumSamples;
            SamplingTime = _SamplingTime;
            AppCallback = Callback;
            BatchBuffer = SampleBuff;

            if (!SamplingThread.IsAlive) SamplingThread.Start();
            if (SamplingThread.ThreadState == ThreadState.Suspended) SamplingThread.Resume();

            if (!ADCPort.IsOpen)
            {
                Debug.Print("Opening ADCPort");
                ADCPort.Open();
            }     
            return 1;
        }

        public int ConfigureContinuousMode(ushort[] SampleBuff, uint StartChannel, uint NumChannels, uint NumSamples, uint _SamplingTime, AdcCallback Callback)
        {
            if (StartChannel > 2 || (StartChannel + NumChannels > 3))
                return 0;

            if (BatchMode) return 0; //Check if continuous mode is already running

            if (!SamplingThread.IsAlive) SamplingThread.Start();
            if (SamplingThread.ThreadState == ThreadState.Suspended) SamplingThread.Resume();

            ContinuousMode = true;
            NumberOfSamples = NumSamples;
            SamplingTime = _SamplingTime;
            AppCallback = Callback;
            BatchBuffer=SampleBuff;
            ContinuousBuffer = new ushort[NumChannels * NumSamples];

            if (!ADCPort.IsOpen)
            {
                Debug.Print("Opening ADCPort");
                ADCPort.Open();
            }
            return 1;
        }

        void ReadChannels()
        {
            byte[] readBuffer = new byte[NumberOfChannels * 2];
            Debug.Print("Staring to sample ADC port...");

            while (true)
            {
                if (ADCPort.IsOpen)
                {
                    if (ADCPort.BytesToRead >= readBuffer.Length)
                    {
                        int bytes_read = ADCPort.Read(readBuffer, 0, 2 * NumberOfChannels);
                        //Debug.Print("Thread: Reading...");
                        if (bytes_read > 0)
                        {
                            try
                            {
                                ByteArrayToUShortArray(readBuffer, ADCValue, readBuffer.Length);
                                if (BatchMode || ContinuousMode)
                                {
                                    for (int i = 0; i < NumberOfChannels; i++)
                                    {
                                        ContinuousBuffer[CurSampleNumber * NumberOfChannels + i] = ADCValue[i];
                                    }
                                    CurSampleNumber++;
                                    if (CurSampleNumber == NumberOfSamples)
                                    {
                                        CurSampleNumber = 0;
                                        ContinuousBuffer.CopyTo(BatchBuffer, 0);
                                        Array.Clear(ContinuousBuffer,0,ContinuousBuffer.Length);
                                        AppCallback(true);
                                    }
                                    if (BatchMode) Stop();
                                }
                            }catch (Exception e){
                                Debug.Print(e.ToString());
                            }
                        }
                    }
                    else
                    {
                        //Debug.Print("Thread: Nothing to read."); 
                    }

                    //Testing write
                    //byte[] writebuf = new byte[10] {0,1,2,3,4,5,6,7,8,9};
                    //ADCPort.Write(writebuf, 0, 10);

                }
                else { Debug.Print("ADC Port not open."); }

                Thread.Sleep((int)(SamplingTime / 1000));
            }
        }
        
        // Helper Functions
        void ByteArrayToUShortArray(byte[] x, ushort[] ret, int byte_length)
        {
            for (int i = 0; i < byte_length / 2; i++)
            {
                ret[i] = (ushort)(x[i * 2] << 8);
                ret[i] += x[i * 2 + 1];
            }
        }
        
        /* void ADCPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            byte[] readBuffer = new byte[Config.NumberOfChannels * 2];                       
            int bytes_read = ADCPort.Read(readBuffer, 0, Config.NumberOfChannels);
            
            if (bytes_read > 0)
            {
                CopyByteToShort(readBuffer, ADCValue, Config.NumberOfChannels);
                Debug.Print(bytes_read.ToString());
            }
            else Debug.Print("Handler: Nothing.");
            
        }*/

    }
}
