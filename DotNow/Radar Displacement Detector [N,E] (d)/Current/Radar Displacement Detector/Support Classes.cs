using Microsoft.SPOT.Hardware;

#if DotNow
using Samraksh.eMote.DotNow;
#endif

namespace Samraksh.AppNote.DotNow.RadarDisplacementDetector {


    /// <summary>
    /// Bool surrogate that can be passed as ref
    /// </summary>
    struct IntBool {
        public const int True = 1;
        public const int False = 0;
    }

}