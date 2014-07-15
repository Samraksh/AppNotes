using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.eMote;
using Samraksh.eMote.DotNow;

namespace Samraksh.AppNote.DotNow.RadarDisplacementDetector {


    /// <summary>
    /// Define GPIO ports
    /// </summary>
    public static class GpioPorts {
        /// <summary>Indicate when sample is processed</summary>
        public static OutputPort SampleProcessed = new OutputPort(Pins.GPIO_J12_PIN1, false);

        /// <summary>Indicate whether or not event detected</summary>
        public static OutputPort DetectEvent = new OutputPort(Pins.GPIO_J12_PIN2, false);

        /// <summary>Enable the BumbleBee. Set this false to disable. </summary>
        public static OutputPort EnableBumbleBee = new OutputPort(Pins.GPIO_J11_PIN3, true);
    }

    /// <summary>
    /// Bool surrogate that can be passed as ref
    /// </summary>
    struct IntBool {
        public const int True = 1;
        public const int False = 0;
    }

}