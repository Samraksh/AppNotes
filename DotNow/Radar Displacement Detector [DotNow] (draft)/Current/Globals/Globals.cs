using System;
using Microsoft.SPOT;
#if DotNow
#endif
using Microsoft.SPOT.Hardware;
using Samraksh.eMote.DotNow;

namespace Samraksh.AppNote.Samraksh.AppNote.DotNow.Radar.DisplacementAnalysis {
    public class Globals {
        /// <summary>
        /// Define GPIO ports
        /// </summary>
        public static class GpioPorts {
#if Sam_Emulator
        public static Cpu.Pin Led1Pin = 0;
        public static Cpu.Pin Led2Pin = (Cpu.Pin)1;
        public static Cpu.Pin Led3Pin = (Cpu.Pin)2;
        public static Cpu.Pin Button1Pin = (Cpu.Pin)3;
        public static Cpu.Pin Button2Pin = (Cpu.Pin)4;
        public static Cpu.Pin Button3Pin = (Cpu.Pin)5;
        /// <summary>On iff snippet displacement</summary>
        public static OutputPort DisplacementPort = new OutputPort(Led1Pin, false);
        /// <summary>On iff MofN confirms displacement</summary>
        public static OutputPort MofNConfirmationPort = new OutputPort(Led2Pin, false);
#endif
#if DotNow
            /// <summary>Indicate when sample is processed</summary>
            public static OutputPort SampleProcessed = new OutputPort(Pins.GPIO_J12_PIN1, false);

            /// <summary>Indicate whether or not event detected</summary>
            public static OutputPort DetectEvent = new OutputPort(Pins.GPIO_J12_PIN2, false);

            /// <summary>Enable the BumbleBee. Set this false to disable. </summary>
            public static OutputPort EnableBumbleBee = new OutputPort(Pins.GPIO_J11_PIN3, true);

            /// <summary>For a logic analyzer</summary>
            public static OutputPort LogicJ11Pin4 = new OutputPort(Pins.GPIO_J11_PIN4, false);
#endif
        }
    }
}
