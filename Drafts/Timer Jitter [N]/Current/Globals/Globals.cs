using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;

namespace Globals {
    public static class Globals {
        public static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();
        public static readonly OutputPort GpioJ12P1 = new OutputPort(Samraksh.eMote.DotNow.Pins.GPIO_J12_PIN1, false);
    }
}
