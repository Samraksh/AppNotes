using System;
using Microsoft.SPOT;

namespace Misc {
    public static class Globals {

        public const int TicksPerMillisecond = (int)TimeSpan.TicksPerMillisecond;  // 10,000
        public const int TicksPerMicrosecond = TicksPerMillisecond / 1000; // 10
        
        // The minimum number of increase in ticks that indicates a GC has taken place
        public const long MinGCTicks = 5 * (int)TimeSpan.TicksPerMillisecond; // Ticks
    }
}
