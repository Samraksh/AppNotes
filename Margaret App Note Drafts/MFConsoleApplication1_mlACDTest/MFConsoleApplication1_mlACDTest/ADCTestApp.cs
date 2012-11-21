using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Messaging;
using Samraksh.SPOT.Emulator;
using System.Threading; 

namespace MFConsoleApplication1
{
    public class ADCTest
    {

        //add an instance of the ADC
        AdcSampleTime sampleTime = AdcSampleTime.ADC_SampleTime_1_5_Cycles;
        ADC Adc;
        const int NumberOfChannels = 2 ; 
        const int NumberOfSamples = 1000;
        uint samplingTime = 2 * 1000;    //microseconds -- this gives a 2 KHz sampling frequence
        ushort[] Adc_buffer = new ushort[2 * NumberOfSamples];
       // bool BatchMode = false ;
        int BatchNumber = 0;


        ADCTest() {
            Adc = new ADC( ) ;
        }

        // this is to process samples that are provided in continuous mode
        //  up to a BatchNumber of 10
        public void ProcessSamplesContinuousModeCallback( bool status)
        {
            if (status) {
                 double[] Mean =  new double[NumberOfChannels] ;
                 for (int i=0; i < Adc_buffer.Length ; i++ )
                 {
                      Mean[i % NumberOfChannels] += Adc_buffer[i] ;
                 } //end for
                 for (int i=0; i < NumberOfChannels ; i++ )
                 {
                      Mean[i] /= (Adc_buffer.Length/NumberOfChannels) ;
                Debug.Print(" BatchNumber = " + BatchNumber + " , ADC [ " + i + " ] + Mean: " + Mean[i] ) ;    
                 Mean[i] = 0 ; 
            }//end for
                BatchNumber++ ;
                if (BatchNumber == 10) Adc.Stop() ;
             }//end if status
        else {
               Debug.Print(" Error in continuous mode from processing callback " ) ;
           }

        } //end ProcessSamplesContinuousModeCallback


        public void StartContinuousModeTest()
        {
            Debug.Print("Starting continuous mode test");
            try {
                Adc.Init(sampleTime, NumberOfChannels);
                Thread.Sleep(2000) ;
                Adc.ConfigureContinuousMode(Adc_buffer, 0, 2, NumberOfSamples,samplingTime,
                    ProcessSamplesContinuousModeCallback );
            }
            catch(Exception e)
            {
                Debug.Print(e.ToString());
            }

        }




        public static void Main()
        {
            Thread.Sleep(2000);
            ADCTest _test = new ADCTest();
            _test.StartContinuousModeTest();
            Thread.Sleep(Timeout.Infinite);

            //Debug.Print(
              //  Resources.GetString(Resources.StringResources.String1));
        }
    }




}
