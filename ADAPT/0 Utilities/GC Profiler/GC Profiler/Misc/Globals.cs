using System;

namespace Samraksh.Profiling.DotNow.GCProfiler.Misc {
    /// <summary>
    /// 
    /// </summary>
    public static class Globals {

        /// <summary>
        /// 
        /// </summary>
        public enum PinMap {
            /// <summary></summary>
            Gpio01 = 58,
            /// <summary></summary>
            Gpio02 = 55,
            /// <summary></summary>
            Gpio03 = 53,
            /// <summary></summary>
            Gpio04 = 52,
            /// <summary></summary>
            Gpio05 = 51
        };

        /// <summary>
        /// 
        /// </summary>
        public const int TicksPerMillisecond = (int)TimeSpan.TicksPerMillisecond;  // 10,000
        /// <summary>
        /// 
        /// </summary>
        public const int TicksPerMicrosecond = TicksPerMillisecond / 1000; // 10

        /// <summary>
        /// 
        /// </summary>
        public const int TicksPerSecond = TicksPerMillisecond * 1000; // 10,000,000

        // The minimum number of increase in ticks that indicates a GC has taken place
        /// <summary>
        /// 
        /// </summary>
        public const long MinGCTicks = 5 * (int)TimeSpan.TicksPerMillisecond; // Ticks
    }
}
