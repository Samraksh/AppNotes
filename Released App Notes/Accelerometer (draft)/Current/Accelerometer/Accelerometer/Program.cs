/*
*/
using System;
using System.Threading;

using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;
using Samraksh.SPOT.Hardware.EmoteDotNow;
using SB = Samraksh.SPOT.Hardware.SensorBoard;

namespace Samraksh {
    namespace AppNotes {
        namespace Accelerometer {
            /// <summary>
            /// Accelerometer test
            /// </summary>
            public class Program {
                private const UInt16 RefreshRate = 500;
                private static SB.Accelerometer _axl;
                private static readonly OutputPort AccelerometerPower = new OutputPort(Pins.GPIO_J11_PIN3, true);
                private static readonly EmoteLcdUtil Lcd = new EmoteLcdUtil();

                private const int BaseX = 25;
                private const int MarginX = 15;
                private const int BaseY = 8;
                private const int MarginY = 5;
                private const int BaseZ = 242;
                private const int MarginZ = 5;

                /// <summary>
                /// Main thread: set things up
                /// </summary>
                public static void Main() {
                    // We don't want to see garbage collector messages in the Output window
                    Debug.EnableGCMessages(false);

                    Debug.Print("Accelerometer");
                    Lcd.Display("Accl");
                    Thread.Sleep(4000);

                    _axl = new SB.Accelerometer(RefreshRate, SensorEventCallback);
                    Thread.Sleep(Timeout.Infinite);
                }

                private static void SensorEventCallback(SB.Accelerometer.EventType typeOfEvent, DateTime timestamp) {
                    if (typeOfEvent != SB.Accelerometer.EventType.DataUpdate) return;
                    var currentData = _axl.CurrentData;
                    int x = currentData.RawX;
                    int y = currentData.RawY;
                    int z = currentData.RawZ;

                    int offsetX = x - BaseX;
                    int offsetY = y - BaseY;
                    int offsetZ = z - BaseZ;

                    Debug.Print("\noffsetX=" + offsetX + ", offsetY=" + offsetY + ", offsetZ=" + offsetZ);

                    // x is less than BaseX ... move away
                    if (offsetX < 0 && -offsetX > MarginX) {
                        Debug.Print("X away: " + offsetX);
                    }
                    // x is greater than BaseX ... move towards
                    if (offsetX > 0 && offsetX > MarginX) {
                        Debug.Print("X toward: " + offsetX);
                    }

                    Debug.Print("\nRawX=" + currentData.RawX + ", RawY=" + currentData.RawY + ", RawZ=" + currentData.RawZ + ", X=" + currentData.X + ", Y=" + currentData.Y + ", Z=" + currentData.Z);
                }


            }
        }
    }
}