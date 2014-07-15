using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Threading;
using System.Text;
using System.IO;

using Samraksh.PhysicalModel;

namespace MicrophonePhysicalApp
{
    class MicrophoneSamples
    {
        PhysicalModelEmulatorComm EmulatorComm; //Emulator Communication
        int SampleTime; //in microseconds
        Thread SampleThread; //thread to create samples
        static int NumberOfChannels = 2; //Default number of channels
        ushort[] CurrentValues = new ushort[NumberOfChannels]; //Current value of the channels
        ushort[] Adc_buffer = new ushort[1000 * NumberOfChannels];
        double[] Mean = new double[NumberOfChannels]; 
        static Random RandomNumberGen = new Random(NumberOfChannels); //Random number generator
        int BatchNumber;  //Current Batch number
        int CurrSampleNumber = 0;
        uint NumberOfSamples = 1000*10; //Number of samples to generate
        StreamWriter logFile; //Log file to write the samples

        MicrophoneSamples(int _SampleTime, int _numberOfChannels)
        {
            EmulatorComm = new PhysicalModelEmulatorComm();        
            EmulatorComm.ConnectToEmulator();
            SampleTime = _SampleTime;
            NumberOfChannels = _numberOfChannels;

            //Create a file with current datetime to use as log
            DateTime now = DateTime.Now;
            String nowString = now.ToString("yyyy_MM_dd_H_mm");
            logFile = new System.IO.StreamWriter("MicroPhoneApp_" + nowString + ".txt");
        }

        ~MicrophoneSamples(){
            //Stop();
        }
        void Stop()
        {
            logFile.Flush();
            logFile.Close();        
        }
        void Start()
        {
            SampleThread = new Thread(new ThreadStart(GenerateRandomSamples));
            SampleThread.Start();        
        }

        void GenerateRandomSamples()
        {
            BatchNumber = 0;
            for(int j=0; j<NumberOfSamples; j++)
            {                
                for (int i = 0; i < NumberOfChannels; i++)
                {
                    CurrentValues[i] = (ushort)RandomNumberGen.Next(4095); //12-bit number
                    Adc_buffer[CurrSampleNumber * NumberOfChannels + i] = CurrentValues[i];
                    Mean[i] += CurrentValues[i];
                }
                CurrSampleNumber++;
                EmulatorComm.SendToADC(CurrentValues, NumberOfChannels);
                //Console.WriteLine(j + ", " + CurrentValues[0] + ", " + CurrentValues[1]);
                logFile.WriteLine(j + ", " + CurrentValues[0] + ", " + CurrentValues[1]);

                //A Batch of 1000 samples done, compute mean for each channel and display
                if (CurrSampleNumber== 1000)
                {
                    CurrSampleNumber = 0;
                    for (int i = 0; i < NumberOfChannels; i++)
                    {
                        Mean[i] /= (Adc_buffer.Length / NumberOfChannels);
                        Console.WriteLine("BatchNumber: " + BatchNumber + ", ADC[" + i + "] Mean:" + Mean[i]);
                        logFile.WriteLine("BatchNumber: " + BatchNumber + ", ADC[" + i + "] Mean:" + Mean[i]);
                        Mean[i] = 0;
                    }
                    BatchNumber++;
                }              
                Thread.Sleep(SampleTime / 1000);
            }
            
            Stop();
            //Environment.Exit(1);
        }


        static void MainX(string[] args)
        {
            MicrophoneSamples Samples = new MicrophoneSamples(1000,2); //1 millisecond interval and 2 channels
            Thread.Sleep(2000);
            Console.WriteLine("Starting Sample Generation...");
            Samples.Start();

            Thread.Sleep(Timeout.Infinite); //Go to sleep
        }
    }
}
