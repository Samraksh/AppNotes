using System;
using Microsoft.SPOT;

namespace Samraksh.AppNote.DotNow.Radar.DisplacementAnalysis {
    public static partial class AnalyzeDisplacement {

        /// <summary>
        /// Displacement detection state values
        /// </summary>
        public enum ConfirmedDisplacementState {
            /// <summary>Confirmed that no displacement is happening</summary>
            Inactive = 0,

            /// <summary>Confirmed that displacement is happening</summary>
            Displacing = 1,
        }

        /// <summary>
        /// Hold a sample pair
        /// </summary>
        private class Sample {
            /// <summary>I value</summary>
            public int I;

            /// <summary>Q value</summary>
            public int Q;
        }

        /// <summary>
        /// Sample data
        /// </summary>
        private static class SampleData {
            /// <summary>Sample Counter</summary>
            public static int SampleCounter = 0;

            ///// <summary>Current sample</summary>
            //public static Sample CurrSample = new Sample();

            /// <summary>Current sample, adjusted by mean for comparison</summary>
            public static Sample CompSample = new Sample();

            /// <summary>Sum of samples</summary>
            public static Sample SampleSum = new Sample();
        }

    }
}