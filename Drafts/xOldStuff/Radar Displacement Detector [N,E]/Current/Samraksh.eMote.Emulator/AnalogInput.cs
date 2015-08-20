using System;
using Microsoft.SPOT;

namespace Samraksh.eMote {
    /// <summary>
    /// ADC callback
    /// </summary>
    /// <param name="thresholdTime"></param>
    public delegate void AdcCallBack(long thresholdTime);
}

namespace Samraksh.eMote.Emulator {
    /// <summary>
    /// Analog input: ADC
    /// </summary>
    public class AnalogInput {

        private static readonly ADC Adc = new ADC();
        private static ushort[] _sampleBuff, _sampleBuff1, _sampleBuff2;
        private static uint _numSamples;
        private static AdcCallBack _callback;

        /// <summary>
        /// Initialize Adc
        /// </summary>
        /// <returns>true iff successful</returns>
        /// <remarks>Needed for interface compatability but not required by the emulator</remarks>
        public static bool InitializeADC() {
            return true;
        }

        /// <summary>
        /// Continuous mode sampling with two channels
        /// </summary>
        /// <param name="sampleBuff1"></param>
        /// <param name="sampleBuff2"></param>
        /// <param name="numSamples"></param>
        /// <param name="samplingTime">Number of milliseconds between samples</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static bool ConfigureContinuousModeDualChannel(ushort[] sampleBuff1, ushort[] sampleBuff2, uint numSamples, uint samplingTime, AdcCallBack callback) {
            if (numSamples > System.Math.Min(sampleBuff1.Length, sampleBuff2.Length)) {
                throw new ArgumentException("Number of samples must not exceed length of either sample buffer");
            }
            _sampleBuff1 = sampleBuff1;
            _sampleBuff2 = sampleBuff2;
            _numSamples = numSamples;
            //_samplingtime = samplingTime;
            _callback = callback;

            _sampleBuff = new ushort[_sampleBuff1.Length + _sampleBuff2.Length];

            var retVal = Adc.Init(AdcSampleTime.ADC_SampleTime_13_5_Cycles, 2);
            if (retVal == 0) {
                return false;
            }

            retVal = Adc.ConfigureContinuousMode(_sampleBuff, 0, 2, numSamples, samplingTime, BufferCallback);
            Debug.Print("Completed ConfigureContinuousModeDualChannel " + retVal);
            return (retVal == 1);

        }

        /// <summary>
        /// Copy consolidated buffer into two sample buffers for continuous mode
        /// </summary>
        /// <param name="state"></param>
        private static void BufferCallback(bool state) {
            for (var i = 0; i < _numSamples; i++) {
                _sampleBuff1[i] = _sampleBuff[i * 2];
                _sampleBuff2[i] = _sampleBuff[i * 2 + 1];
            }
            _callback(0);
        }

    }
}
