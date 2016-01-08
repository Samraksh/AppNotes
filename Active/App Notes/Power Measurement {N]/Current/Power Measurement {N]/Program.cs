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

		private static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();

		// Toggle mode switch
		private static readonly InterruptPort ToggleMode = new InterruptPort(Pins.GPIO_J12_PIN1, false, Port.ResistorMode.PullUp,
			Port.InterruptMode.InterruptEdgeHigh);

		// Power modes
		private enum ModeStates { Sleep, PowerLow, PowerMedium, PowerHigh, RadioRx, RadioTxLo, RadioTxHi, };
		private static ModeStates _currMode;

		private static class ModeFields
		{
			public static readonly ManualResetEvent CpuBoundEnable = new ManualResetEvent(false);
			public static readonly ManualResetEvent RadioTxEnable = new ManualResetEvent(false);
			public static SimpleCsmaRadio CsmaRadio;

			public static void DisableAll()
			{
				Debug.Print("Disable all");

				// Set power level to low
				Debug.Print("\tChange power level");
				PowerState.ChangePowerLevel(PowerLevel.Low);
				// Block CpuBound thread
				Debug.Print("\tCpuBoundEnable.Reset");
				CpuBoundEnable.Reset();
				// Block RadioTx thread
				Debug.Print("\tRadioTxEnable.Reset");
				RadioTxEnable.Reset();
				// Discard old radio object and create new. Ensures that it is turned off.
				Debug.Print("\tDiscard Radio");
				CsmaRadio = null;
				Debug.GC(true);
			}

			public static void DefineRadio(TxPowerValue txPowerValue)
			{
				Debug.Print("DefineRadio");
				CsmaRadio = new SimpleCsmaRadio(RadioName.RF231RADIO, 100, txPowerValue, null);
				//CsmaRadio.SetRadioState(SimpleCsmaRadio.RadioStates.Off);
			}
		}

		private static class ActivityThreads
		{
			public static void StartAll()
			{
				CpuBoundThread.Start();
				RadioTxThread.Start();
			}

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

			//// Set power level to low
			//Debug.Print("\tChange power level to Low: " + PowerLevel.Low);
			//PowerState.ChangePowerLevel(PowerLevel.Low);
			
			ToggleMode.OnInterrupt += ChangeMode.CallBack;

			ModeFields.DisableAll();

			Debug.Print("ActivityThreads.StartAll");
			ActivityThreads.StartAll();

			SetModes.SetSleepMode();

			Debug.Print("Waiting for GPIO");

			Thread.Sleep(Timeout.Infinite);

		}

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
					case ModeStates.Sleep:
						SetModes.SetPowerLowMode();
						break;
					case ModeStates.PowerLow:
						SetModes.SetPowerMediumMode();
						break;
					case ModeStates.PowerMedium:
						SetModes.SetPowerHighMode();
						break;
					case ModeStates.PowerHigh:
						SetModes.SetRadioOnMode();
						break;
					case ModeStates.RadioRx:
						SetModes.SetRadioTxLo();
						break;
					case ModeStates.RadioTxLo:
						SetModes.SetRadioTxHi();
						break;
					case ModeStates.RadioTxHi:
						ModeFields.DisableAll();
						Lcd.Write("Done");
						//SetModes.SetSleepMode();
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

			public static void SetRadioOnMode()
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
				ModeFields.DisableAll();

				ModeFields.DefineRadio(TxPowerValue.Power_Minus17dBm);
				//ModeFields.CsmaRadio.SetRadioState(SimpleCsmaRadio.RadioStates.On);
				ModeFields.RadioTxEnable.Set();
				_currMode = ModeStates.RadioTxLo;
				Lcd.Write("Tx 0");
			}

			public static void SetRadioTxHi()
			{
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
