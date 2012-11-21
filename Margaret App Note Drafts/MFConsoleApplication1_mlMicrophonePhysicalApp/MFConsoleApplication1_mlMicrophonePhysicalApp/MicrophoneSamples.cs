using System;
using System.IO ;
using System.Threading;
using System.Text;
using Samraksh.PhysicalModel;

namespace MFConsoleApplication1
{
    public class MicrophoneSamples
    {
        PhysicalModelEmulatorComm EmulatorComm;
        int SampleTime; //microseconds
        Thread SampleThread;
        static int NumberOfChannels = 2;
        ushort[] CurrentValues = new ushort[NumberOfChannels];
        ushort[] Adc_buffer = new ushort[1000 * NumberOfChannels];
        double[] Mean = new double[NumberOfChannels];
        //
        int BatchNumber;
        int CurrSampleNumber = 0;
        uint NumberOfSamples = 1000 * 10;
        StreamWriter logFile;

        MicrophoneSamples(int _SampleTime, int _numberOfChannels)
        {
            EmulatorComm = new PhysicalModelEmulatorComm();
            EmulatorComm.ConnectToEmulator();
            SampleTime = _SampleTime;
            NumberOfChannels = _numberOfChannels;

            //log file
            DateTime now = DateTime.Now ;
            string nowString = now.ToString("yyyy_MM_dd_H_mm") ;
            logFile  = new System.IO.StreamWriter("MicroPhoneApp_" + nowString + ".txt") ;
        }


        //generating one note
        void GenerateSamples()
        {
            BatchNumber = 0;
            for (int j = 0; j < NumberOfSamples; j++)
            {
                for (int i = 0; i < NumberOfChannels; i++)
                {
                    CurrentValues[i] = (ushort) 455 ; 
                    Adc_buffer[CurrSampleNumber * NumberOfChannels + i] = CurrentValues[i];
                    Mean[i] += CurrentValues[i];
                }
                CurrSampleNumber++;
                EmulatorComm.SendToADC(CurrentValues, NumberOfChannels);
                //Console.WriteLine(j + ", " + CurrentValues[0] + ", " + CurrentValues[1]);
                logFile.WriteLine(j + ", " + CurrentValues[0] + ", " + CurrentValues[1]);

                //A Batch of 1000 samples done, compute mean for each channel and display
                if (CurrSampleNumber == 1000)
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


        void Stop()
        {
            logFile.Flush();
            logFile.Close();
        }

        void Start()
        {
            SampleThread = new Thread(new ThreadStart(GenerateSamples));
            SampleThread.Start();
        }



        public static void Main()
        {
            //Debug.Print(
                //Resources.GetString(Resources.StringResources.String1));
            MicrophoneSamples Samples = new MicrophoneSamples(1000, 2); //1 millisecond interval and 2 channels
            Thread.Sleep(2000);
            Console.WriteLine("Starting Sample Generation...");
            Samples.Start();

            Thread.Sleep(Timeout.Infinite); //Go to sleep


        }

    }
}
