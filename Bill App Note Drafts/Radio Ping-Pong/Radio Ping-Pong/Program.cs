using System;
using Microsoft.SPOT;

using Samraksh.SPOT.Hardware.EmoteDotNow;

namespace Samraksh.AppNote.PingPong {
    public class Program {
        public static void Main() {
            Debug.Print(Resources.GetString(Resources.StringResources.String1));

            EmoteLCD lcd = new EmoteLCD();
            lcd.Initialize();


        }

    }
}
