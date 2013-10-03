using System;
using System.Threading;

using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using Samraksh.SPOT.Hardware.EmoteDotNow;

namespace SamrakshAppNoteUtility {

    public class SwitchInput {

        public delegate void SwitchCallback(bool switchStatus);

        private SwitchCallback switchCallBack;
        private InputPort switchPort;
        private DebounceTimer debounceTimer = new DebounceTimer(10);


        public SwitchInput(Cpu.Pin portId, Port.ResistorMode resistorMode, SwitchCallback _switchCallBack ) {
            switchCallBack = _switchCallBack;

            switchPort = new InterruptPort(portId, false, resistorMode, Port.InterruptMode.InterruptEdgeBoth);
            switchPort.OnInterrupt += onOffSwitch_OnInterrupt;
        }

        
        private void onOffSwitch_OnInterrupt(uint pin, uint state, DateTime time) {
            if (!debounceTimer.OkToRead()) {
                return;
            }
            bool buttonValue = switchPort.Read();
            switchCallBack(buttonValue);
        }

    }
}
