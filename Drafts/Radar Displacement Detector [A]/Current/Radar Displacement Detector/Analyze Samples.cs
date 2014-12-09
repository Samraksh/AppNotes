using Microsoft.SPOT;

namespace Samraksh.AppNote.DotNow.RadarDisplacementDetector {

    public static class Analysis {
        public static void AnalyzeSamples() {
            while (true) {
                SampleBuffer.SampleReceived.WaitOne();
                while (!SampleBuffer.IsEmpty) {
                    // Update interpolation buffer pointer & sample number
                    Interpolation.NextSample = (Interpolation.NextSample + 1) % Interpolation.BufferSize;
                    SampleData.SampleNumber++;

                    // We need 3 samples before we can do interpolation
                    if (SampleData.SampleNumber < Interpolation.MinSamplesToStart) {
                        Debug.Print("Initial collection. Sample number: " + SampleData.SampleNumber + ", MinSamplesToStart: " + Interpolation.MinSamplesToStart);
                        continue;
                    }

                    Debug.Print("Now processing sample " + SampleData.SampleNumber);

                    // Get the I-Q pair to process
                    //  Pointer is positioned at next sample. We just read (next - 1) value.
                    //  Actual value to be returned is (next - 2) value.
                    //  Interpolated value to be returned is average of (next - 1) and (next - 3) values.

                    // Actual is (next - 2) value. For modulo arithmetic, add an offset that takes to 2 positions back.
                    var prevActual = Interpolation.Samples[(Interpolation.NextSample + Interpolation.Back2) % Interpolation.BufferSize];

                    // Interpolated is average of (next - 1) and (next - 3) values;
                    ushort prevInterpolated;
                    {
                        var back1 = Interpolation.Samples[(Interpolation.NextSample + Interpolation.Back1) % Interpolation.BufferSize];
                        var back3 = Interpolation.Samples[(Interpolation.NextSample + Interpolation.Back3) % Interpolation.BufferSize];
                        prevInterpolated = (ushort)((back1 + back3) >> 1); // Divide by 2
                    }

                    // If we just sampled I value, then return previous interpolated for I and previous actutal for Q
                    if (adcChannel == AdcChannelI) {
                        SampleData.CurrSample.I = prevInterpolated;
                        SampleData.CurrSample.Q = prevActual;
                    }
                    // If we just sampled Q value, then return previous interpolated for Q and previous actutal for I
                    else {
                        SampleData.CurrSample.I = prevActual;
                        SampleData.CurrSample.Q = prevInterpolated;
                    }
                }
            }
        }

    

    }

    /// <summary>
    /// Buffer for sample interpolation
    /// </summary>
    static class Interpolation {

        /// <summary>Minimum number of samples before interpolation can start</summary>
        public const int MinSamplesToStart = 3;

        /// <summary>Size of the buffer</summary>
        public const int BufferSize = 4;
        /// <summary>Samples buffer</summary>
        public static ushort[] Samples = new ushort[BufferSize];
        /// <summary>Next-sample pointer</summary>
        public static int NextSample = 0;

        /// <summary>Add this value to NextSample to go back 1</summary>
        public const int Back1 = BufferSize - 1;
        /// <summary>Add this value to NextSample to go back 2</summary>
        public const int Back2 = BufferSize - 2;
        /// <summary>Add this value to NextSample to go back 3</summary>
        public const int Back3 = BufferSize - 3;
    }

}
