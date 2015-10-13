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
#if UseRadio
using Samraksh.eMote.Net.Mac;
using Samraksh.eMote.Net.Radio;
#endif

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
#if UseRadio
			public static readonly SimpleCsmaRadio CsmaRadio = new SimpleCsmaRadio(RadioName.RF231RADIO, 100, TxPowerValue.Power_0Point0dBm, null);
#endif
			public static void DisableAll()
			{
				CpuBoundEnable.Reset();
				RadioTxEnable.Reset();
#if UseRadio
				CsmaRadio.SetRadioState(SimpleCsmaRadio.RadioStates.Off);
#endif
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
#if UseRadio
					ModeFields.CsmaRadio.Send(Addresses.BROADCAST, msg);
#endif
				}
				// ReSharper disable once FunctionNeverReturns
			});
		}


		/// <summary>
		/// Program entry point
		/// </summary>
		public static void Main()
		{
			Debug.Print("\nData Collector Radar");

			// Print the version and build info
			Debug.Print(VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));
			Debug.Print("");

			ToggleMode.OnInterrupt += ChangeMode.CallBack;

			ModeFields.DisableAll();
			ActivityThreads.StartAll();
			
			SetSleepMode();

			Thread.Sleep(Timeout.Infinite);

		}

		private static class ChangeMode
		{
			private static DateTime _lastEventTime = DateTime.MinValue;
			private static readonly TimeSpan BounceTime = new TimeSpan(0, 0, 0, 0, 300);

			public static void CallBack(uint port, uint state, DateTime currEventTime) {
				var isBbounceInterval = currEventTime - _lastEventTime < BounceTime;
				// Debounce the switch
				if (isBbounceInterval)
				{
					return;
				}
				_lastEventTime = currEventTime;

				//Lcd.Write(ToggleMode.Read() ? 1 : 0);
				//Thread.Sleep(500);

				//	Toggle the mode
				switch (_currMode)
				{
					case ModeStates.Sleep:
						SetPowerLowMode();
						break;
					case ModeStates.PowerLow:
						SetPowerMediumMode();
						break;
					case ModeStates.PowerMedium:
						SetPowerHighMode();
						break;
					case ModeStates.PowerHigh:
						SetRadioOnMode();
						break;
					case ModeStates.RadioRx:
						SetRadioTxLo();
						break;
					case ModeStates.RadioTxLo:
						SetRadioTxHi();
						break;
					case ModeStates.RadioTxHi:
						SetSleepMode();
						break;
					default:
						Lcd.Write("err");
						throw new ApplicationException("Unhandled mode " + _currMode);
				}
			}
		}

		private static void SetSleepMode()
		{
			ModeFields.DisableAll();
			_currMode = ModeStates.Sleep;
			Lcd.Write("P 0");
		}

		private static void SetPowerLowMode()
		{
			ModeFields.DisableAll();
			PowerState.ChangePowerLevel(PowerLevel.Low);
			_currMode = ModeStates.PowerLow;
			ModeFields.CpuBoundEnable.Set();
		}

		private static void SetPowerMediumMode()
		{
			ModeFields.DisableAll();
			PowerState.ChangePowerLevel(PowerLevel.Medium);
			_currMode = ModeStates.PowerMedium;
			ModeFields.CpuBoundEnable.Set();
		}

		private static void SetPowerHighMode()
		{
			ModeFields.DisableAll();
			PowerState.ChangePowerLevel(PowerLevel.High);
			ModeFields.CpuBoundEnable.Set();
			_currMode = ModeStates.PowerHigh;
		}

		private static void SetRadioOnMode()
		{
			ModeFields.DisableAll();
#if UseRadio
			ModeFields.CsmaRadio.SetRadioState(SimpleCsmaRadio.RadioStates.On);
#endif
			_currMode = ModeStates.RadioRx;
			Lcd.Write("Rdo");
		}

		private static void SetRadioTxLo()
		{
			ModeFields.DisableAll();
#if UseRadio
			ModeFields.CsmaRadio.MacConfig.radioConfig.SetTxPower(TxPowerValue.Power_Minus17dBm);
			ModeFields.CsmaRadio.SetRadioState(SimpleCsmaRadio.RadioStates.On);
#endif
			ModeFields.RadioTxEnable.Set();
			_currMode = ModeStates.RadioTxLo;
			Lcd.Write("Tx 0");
		}

		private static void SetRadioTxHi()
		{
			ModeFields.DisableAll();
#if UseRadio
			ModeFields.CsmaRadio.MacConfig.radioConfig.SetTxPower(TxPowerValue.Power_3dBm);
			ModeFields.CsmaRadio.SetRadioState(SimpleCsmaRadio.RadioStates.On);
#endif
			ModeFields.RadioTxEnable.Set();
			_currMode = ModeStates.RadioTxHi;
			Lcd.Write("Tx 1");
		}

	}
}
