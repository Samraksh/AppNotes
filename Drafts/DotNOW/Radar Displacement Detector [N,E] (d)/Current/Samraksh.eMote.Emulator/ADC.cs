using System;
using System.IO.Ports;
using System.Threading;

using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.eMote.Emulator;

namespace Samraksh.eMote.Emulator {
    enum AdcMode { SingleShot, Batch, Continuous };
    enum AdcDataAlign { Right, Left };
    enum AdcExternalTrigConv { None, Rising, Falling };

    public class ADC_Configuration {
        public short NumberOfChannels = 3;
        public AdcSampleTime SampleTime;
    }

    public enum AdcSampleTime {
        ADC_SampleTime_1_5_Cycles = 0,
        ADC_SampleTime_7_5_Cycles = 1,
        ADC_SampleTime_13_5_Cycles = 2,
        ADC_SampleTime_28_5_Cycles = 3,
        ADC_SampleTime_41_5_Cycles = 4,
        ADC_SampleTime_55_5_Cycles = 5,
        ADC_SampleTime_71_5_Cycles = 6,
        ADC_SampleTime_239_5_Cycles = 7,
    }

    public delegate void AdcCallback(bool status);

}
/// <summary>
/// 
/// </summary>
public class ADC {
    //ADC_Configuration Config;
    ushort _numberOfChannels = 3;
    SerialPort _adcPort;
    ushort[] _adcValue;
    uint _samplingTime = 100000;
    Thread _samplingThread;

    //Batch/Continous mode parameters
    bool _batchMode;
    bool _continuousMode;
    uint _numberOfSamples;
    AdcCallback _appCallback;
    ushort[] _batchBuffer;
    ushort[] _continuousBuffer;
    uint _curSampleNumber;


    /*public ADC(ushort NumberOfChannels, AdcSampleTime SampleTime)
    {
        Config = Configuration;
        ADCValue = new ushort[Config.NumberOfChannels];
    }*/

    public int Init(AdcSampleTime sampleTime, int numberOfChannels) {
        Debug.Print("Initializing ADC...");
        try {
            _numberOfChannels = (ushort)numberOfChannels;
            _adcValue = new ushort[_numberOfChannels];
            _samplingThread = new Thread(ReadChannels);
            _adcPort = new SerialPort("COM1") { ReadTimeout = 0 };
            _adcPort.Open();
            //ADCPort.DataReceived += new SerialDataReceivedEventHandler(ADCPort_DataReceived);
        }
        catch (Exception e) {
            Debug.Print(e.ToString());
            return 0;
        }

        _samplingThread.Start();
        return 1;
    }

    /// <summary>
    /// Stop ADC sampling
    /// </summary>
    public void Stop() {
        _samplingThread.Suspend();
        _batchMode = false;
        _continuousMode = false;
        _appCallback = null;
        _numberOfSamples = 0;
    }

    /// <summary>
    /// Get data from ADC
    /// </summary>
    /// <param name="currSample">Array to hold sample</param>
    /// <param name="startChannel"></param>
    /// <param name="numChannels"></param>
    /// <returns></returns>
    public int GetData(ushort[] currSample, uint startChannel, uint numChannels) {
        if (startChannel > 2 || (startChannel + numChannels > 3))
            return 0;

        if (!_adcPort.IsOpen) {
            Debug.Print("Opening ADCPort");
            _adcPort.Open();
        }

        for (int i = (int)startChannel; i < (int)startChannel + numChannels; i++)
            currSample[i] = _adcValue[i];
        return 1;
    }

    public int ConfigureBatchMode(ushort[] sampleBuff, uint startChannel, uint numChannels, uint numSamples, uint samplingTime, AdcCallback callback) {
        if (startChannel > 2 || (startChannel + numChannels > 3))
            return 0;

        if (_continuousMode) return 0; //Check if continuous mode is already running

        _batchMode = true;
        _numberOfSamples = numSamples;
        _samplingTime = samplingTime;
        _appCallback = callback;
        _batchBuffer = sampleBuff;

        if (!_samplingThread.IsAlive) _samplingThread.Start();
        if (_samplingThread.ThreadState == ThreadState.Suspended) _samplingThread.Resume();

        if (!_adcPort.IsOpen) {
            Debug.Print("Opening ADCPort");
            _adcPort.Open();
        }
        return 1;
    }

    public int ConfigureContinuousMode(ushort[] sampleBuff, uint startChannel, uint numChannels, uint numSamples, uint samplingTime, AdcCallback callback) {
        if (startChannel > 2 || (startChannel + numChannels > 3))
            return 0;

        if (_batchMode) return 0; //Check if continuous mode is already running

        if (!_samplingThread.IsAlive) _samplingThread.Start();
        if (_samplingThread.ThreadState == ThreadState.Suspended) _samplingThread.Resume();

        _continuousMode = true;
        _numberOfSamples = numSamples;
        _samplingTime = samplingTime;
        _appCallback = callback;
        _batchBuffer = sampleBuff;
        _continuousBuffer = new ushort[numChannels * numSamples];

        if (!_adcPort.IsOpen) {
            Debug.Print("Opening ADCPort");
            _adcPort.Open();
        }
        return 1;
    }

    void ReadChannels() {
        var readBuffer = new byte[_numberOfChannels * 2];
        Debug.Print("Staring to sample ADC port...");

        while (true) {
            if (_adcPort.IsOpen) {
                if (_adcPort.BytesToRead >= readBuffer.Length) {
                    var bytesRead = _adcPort.Read(readBuffer, 0, 2 * _numberOfChannels);
                    //Debug.Print("Thread: Reading...");
                    if (bytesRead > 0) {
                        try {
                            ByteArrayToUShortArray(readBuffer, _adcValue, readBuffer.Length);

                            //if ((_inputCtr % 100) == 0) {
                            //    var adcValsStr = string.Empty;
                            //    for (var i = 0; i < ADCValue.Length; i++) {
                            //        adcValsStr += ADCValue[i] + " ";
                            //    }
                            //    Debug.Print("*** " + _inputCtr + " " + adcValsStr);
                            //}
                            //_inputCtr++;

                            if (_batchMode || _continuousMode) {
                                for (var i = 0; i < _numberOfChannels; i++) {
                                    _continuousBuffer[(int)(_curSampleNumber * _numberOfChannels) + i] = _adcValue[i];
                                }
                                _curSampleNumber++;
                                if (_curSampleNumber == _numberOfSamples) {
                                    _curSampleNumber = 0;
                                    _continuousBuffer.CopyTo(_batchBuffer, 0);
                                    Array.Clear(_continuousBuffer, 0, _continuousBuffer.Length);
                                    _appCallback(true);
                                }
                                if (_batchMode) Stop();
                            }
                        }
                        catch (Exception e) {
                            Debug.Print(e.ToString());
                        }
                    }
                }
                else {
                    //Debug.Print("Thread: Nothing to read."); 
                }

                //Testing write
                //byte[] writebuf = new byte[10] {0,1,2,3,4,5,6,7,8,9};
                //ADCPort.Write(writebuf, 0, 10);

            }
            else { Debug.Print("ADC Port not open."); }

            Thread.Sleep((int)(_samplingTime / 1000));
            //Thread.Sleep((int)(SamplingTime));
        }
    }
    //private int _inputCtr;

    // Helper Functions
    void ByteArrayToUShortArray(byte[] x, ushort[] ret, int byteLength) {
        for (var i = 0; i < byteLength / 2; i++) {
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