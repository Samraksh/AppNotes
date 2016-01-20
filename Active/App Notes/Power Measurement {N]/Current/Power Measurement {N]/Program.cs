/*******************************************
 * Power Measurement
 *      Used in conjunction with a USB power monitor to measure power utilization in different modes
 * Version
 *	1.0	
 *		Initial version
*******************************************/

using System;
using System.Reflection;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;
using Samraksh.eMote.Net.Mac;
using Samraksh.eMote.Net.Radio;

namespace Samraksh.AppNote.PowerMeasurement
{
    /// <summary>
    /// The program
    /// </summary>
    public class Program
    {
        private static readonly EnhancedEmoteLCD Lcd = new EnhancedEmoteLCD();

        // Toggle mode switch
        private static readonly InterruptPort ToggleMode = new InterruptPort(Pins.GPIO_J12_PIN1, false, Port.ResistorMode.PullUp,
            Port.InterruptMode.InterruptEdgeHigh);

        /// <summary>
        /// Program entry point
        /// </summary>
        public static void Main()
        {
            Lcd.Write("Hola");
            Thread.Sleep(2000);
            Debug.Print("\nPower Measurement");

            // Print the version and build info
            Debug.Print(VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));
            Debug.Print("");

            ToggleMode.OnInterrupt += ChangeMode.CallBack;

            ModeFields.DisableAll();

            Debug.Print("ActivityThreads.StartAll");
            ActivityThreads.StartAll();

            SetModes.SetSleepMode();

            Debug.Print("Waiting for GPIO");

            Thread.Sleep(Timeout.Infinite);
        }

        // Power modes
        private enum ModeStates { Sleep, PowerLow, PowerMedium, PowerHigh, RadioRx, RadioTxLo, RadioTxHi, };
        private static ModeStates _currMode;

        private static class ModeFields
        {
            public static readonly ManualResetEvent CpuBoundEnable = new ManualResetEvent(false);
            public static readonly ManualResetEvent RadioTxEnable = new ManualResetEvent(false);
            public static SimpleCSMA CsmaRadio;

            public static void DisableAll()
            {
                Debug.Print("\tDisable all");

                // Set power level to low
                Debug.Print("\t\tChange power level");
                PowerState.ChangePowerLevel(PowerLevel.Low);
                // Block CpuBound thread
				Debug.Print("\t\tCpuBoundEnable.Reset");
                CpuBoundEnable.Reset();
                // Block RadioTx thread
				Debug.Print("\t\tRadioTxEnable.Reset");
                RadioTxEnable.Reset();
                // Discard old radio object and create new. Ensures that it is turned off.
				Debug.Print("\t\tDiscard Radio");
                CsmaRadio = null;
                Debug.GC(true);
            }

            public static void DefineRadio(TxPowerValue txPowerValue)
            {
                Debug.Print("\tDefineRadio");
                CsmaRadio = new SimpleCSMA(RadioName.RF231RADIO, 100, txPowerValue, Channels.Channel_17);
            }
        }

        private static class ActivityThreads
        {
            /// <summary>
            /// Start the CPU and RadioTx threads. Initially they will be disabled from actually doing anything.
            /// </summary>
            public static void StartAll()
            {
                CpuBoundThread.Start();
                RadioTxThread.Start();
            }

            /// <summary>
            /// When enabled, run a tight loop that merely burns up cpu time
            /// </summary>
            private static readonly Thread CpuBoundThread = new Thread(() =>
            {
                var lastPowerLevel = -1;
                while (true)
                {
                    ModeFields.CpuBoundEnable.WaitOne();
                    if ((int)PowerState.CurrentPowerLevel == lastPowerLevel)
                    {
                        continue;
                    }
                    lastPowerLevel = (int)PowerState.CurrentPowerLevel;
                    Lcd.Write("P " + lastPowerLevel);
                }
                // ReSharper disable once FunctionNeverReturns
            });

            /// <summary>
            /// When enabled, transmit continuously on the radio
            /// </summary>
            private static readonly Thread RadioTxThread = new Thread(() =>
            {
                var msg = new byte[1];
                while (true)
                {
                    ModeFields.RadioTxEnable.WaitOne();
                    ModeFields.CsmaRadio.Send(Addresses.BROADCAST, msg);
                }
                // ReSharper disable once FunctionNeverReturns
            });
        }

        /// <summary>
        /// Move to the next mode
        /// </summary>
        private static class ChangeMode
        {
            private static DateTime _lastEventTime = DateTime.MinValue;
            private static readonly TimeSpan BounceTime = new TimeSpan(0, 0, 0, 0, 300);

            public static void CallBack(uint port, uint state, DateTime currEventTime)
            {
                var isBounceInterval = currEventTime - _lastEventTime < BounceTime;
                // Debounce the switch
                if (isBounceInterval)
                {
                    return;
                }
                _lastEventTime = currEventTime;

                //	Toggle the mode
                switch (_currMode)
                {
                    // Switch from Sleep to CPU power low
                    case ModeStates.Sleep:
                        SetModes.SetPowerLowMode();
                        break;
                    // Switch from CPU power low to medium
                    case ModeStates.PowerLow:
                        SetModes.SetPowerMediumMode();
                        break;
                    // Switch from CPU power medium to high
                    case ModeStates.PowerMedium:
                        SetModes.SetPowerHighMode();
                        break;
                    // Switch from CPU power high to radio rx (and set CPU power to low)
                    case ModeStates.PowerHigh:
                        SetModes.SetRadioRxMode();
                        break;
                        // Switch from radio rx to radio rx + tx low power
                    case ModeStates.RadioRx:
						Debug.Print("*** 1");
                        SetModes.SetRadioTxLo();
                        break;
                        // Switch from radio tx low power to radio rx + tx high power
                    case ModeStates.RadioTxLo:
                        SetModes.SetRadioTxHi();
                        break;
                        // Switch from radio tx high power to done
                    case ModeStates.RadioTxHi:
                        ModeFields.DisableAll();
                        Lcd.Write("Done");
                        break;
                    default:
                        Lcd.Write("err");
                        throw new ApplicationException("Unhandled mode " + _currMode);
                }
            }
        }

        private static class SetModes
        {
            public static void SetSleepMode()
            {
                Debug.Print("Set sleep mode");
                ModeFields.DisableAll();

                _currMode = ModeStates.Sleep;
                Lcd.Write("P 0");
            }

            public static void SetPowerLowMode()
            {
                Debug.Print("Setting CPU power mode low");

                ModeFields.DisableAll();
                PowerState.ChangePowerLevel(PowerLevel.Low);
                _currMode = ModeStates.PowerLow;
                ModeFields.CpuBoundEnable.Set();
            }

            public static void SetPowerMediumMode()
            {
                Debug.Print("Setting CPU power mode medium");
                ModeFields.DisableAll();

                PowerState.ChangePowerLevel(PowerLevel.Medium);
                _currMode = ModeStates.PowerMedium;
                ModeFields.CpuBoundEnable.Set();
            }

            public static void SetPowerHighMode()
            {
                Debug.Print("Setting CPU power mode high");
                ModeFields.DisableAll();

                PowerState.ChangePowerLevel(PowerLevel.High);
                _currMode = ModeStates.PowerHigh;
                ModeFields.CpuBoundEnable.Set();
            }

            public static void SetRadioRxMode()
            {
                Debug.Print("Turning radio on");
                ModeFields.DisableAll();

                ModeFields.DefineRadio(TxPowerValue.Power_Minus17dBm);
                //ModeFields.CsmaRadio.SetRadioState(SimpleCsmaRadio.RadioStates.On);
                _currMode = ModeStates.RadioRx;
                Lcd.Write("Rdo");
            }

            public static void SetRadioTxLo()
            {
				Debug.Print("Setting radio Tx low");
				ModeFields.DisableAll();

                ModeFields.DefineRadio(TxPowerValue.Power_Minus17dBm);
                //ModeFields.CsmaRadio.SetRadioState(SimpleCsmaRadio.RadioStates.On);
                ModeFields.RadioTxEnable.Set();
                _currMode = ModeStates.RadioTxLo;
                Lcd.Write("Tx 0");
            }

            public static void SetRadioTxHi()
            {
				Debug.Print("Setting radio Tx high"); 
				ModeFields.DisableAll();

                ModeFields.DefineRadio(TxPowerValue.Power_3dBm);
                //ModeFields.CsmaRadio.SetRadioState(SimpleCsmaRadio.RadioStates.On);
                ModeFields.RadioTxEnable.Set();
                _currMode = ModeStates.RadioTxHi;
                Lcd.Write("Tx 1");
            }
        }
    }
}
