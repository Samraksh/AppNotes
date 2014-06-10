using System;
using Microsoft.SPOT;

namespace Misc {
    /// <summary>
    /// 
    /// </summary>
    public static class Globals {

        /// <summary>
        /// 
        /// </summary>
        public const int TicksPerMillisecond = (int)TimeSpan.TicksPerMillisecond;  // 10,000
        /// <summary>
        /// 
        /// </summary>
        public const int TicksPerMicrosecond = TicksPerMillisecond / 1000; // 10
        
        // The minimum number of increase in ticks that indicates a GC has taken place
        /// <summary>
        /// 
        /// </summary>
        public const long MinGCTicks = 5 * (int)TimeSpan.TicksPerMillisecond; // Ticks
    }
}
