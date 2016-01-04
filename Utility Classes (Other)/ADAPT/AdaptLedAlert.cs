using Microsoft.SPOT.Hardware;

namespace Samraksh.AppNote.Utility {
    public static class AdaptLedAlert {

        // Define the LEDs for the ADAPT dev board
        // Mapping between the GPIO pins stenciled on the ADAPT Dev board and those on the CPU itself
        //  On the Dev board, GPIO 01-04 are connected to LEDs
        private enum PinMap { Gpio01 = 58, Gpio02 = 55, Gpio03 = 53, Gpio04 = 52, Gpio05 = 51 };

        // Define the LEDs
        private const Cpu.Pin Led1 = (Cpu.Pin)PinMap.Gpio01;
        private const Cpu.Pin Led2 = (Cpu.Pin)PinMap.Gpio02;
        private const Cpu.Pin Led3 = (Cpu.Pin)PinMap.Gpio03;
        private const Cpu.Pin Led4 = (Cpu.Pin)PinMap.Gpio04;

        // Define the GPIO ports
        private static readonly OutputPort _p1 = new OutputPort(Led1, false);
        private static readonly OutputPort _p2 = new OutputPort(Led2, false);
        private static readonly OutputPort _p3 = new OutputPort(Led3, false);
        private static readonly OutputPort _p4 = new OutputPort(Led4, false);

        /// <summary>
        /// Give an on-board alert
        /// </summary>
        /// <param name="display"></param>
        public static void Alert(int display) {
            if (display < 0 || display > 9) {
                return;
            }
            bool b1, b2, b3, b4;
            b1 = b2 = b3 = b4 = false;
            switch (display) {
                case 0:
                    break;
                case 1:
                    b4 = true;
                    break;
                case 2:
                    b3 = true;
                    break;
                case 3:
                    b3 = b4 = true;
                    break;
                case 4:
                    b2 = true;
                    break;
                case 5:
                    b2 = b4 = true;
                    break;
                case 6:
                    b2 = b3 = true;
                    break;
                case 7:
                    b2 = b3 = b4 = true;
                    break;
                case 8:
                    b1 = true;
                    break;
                case 9:
                    b1 = b4 = true;
                    break;
            }
            _p1.Write(b1);
            _p2.Write(b2);
            _p3.Write(b3);
            _p4.Write(b4);
        }
    }
}
