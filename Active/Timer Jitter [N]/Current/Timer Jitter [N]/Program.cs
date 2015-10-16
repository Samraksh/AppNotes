/*--------------------------------------------------------------------
 * Timer Jitter [N] app note for eMote .NOW 1.0
 * (c) 2015 The Samraksh Company
 * 
 * Version history
 *  1.0: 
 *		Initial release
 *	1.1:
 *		todo 
---------------------------------------------------------------------*/

#define xLoopTrace
#define xPrintIntervals

using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;

namespace Samraksh.AppNote.TimerJitter
{
	internal class Program
	{

		// Interval for .NET timer
		private const int TimerIntervalMilliSec = 100;
		// Interval for RealTime timer
		private const ulong TimerIntervalMicroSec = TimerIntervalMilliSec * 1000;
		// Number of samples to collect per iteration
		private const int NumSamples = 2000;    // up to 3000 known to be OK
		// Max number of make-work threads to run
		private const int MaxNumMakeWorkThreads = 5;    // Actually, one more than the number of threads

		private static readonly AutoResetEvent NextStep = new AutoResetEvent(false);

		// Array to collect times when the timer tick occurred
		private static double[] _timerTicks;
		private static int _timerTicksPtr;

		// Timer objects
		private static eMote.RealTime.Timer _realTimeTimer;
		private static Timer _dotNetTimer;

		// Statistics class
		private static Statistics _stats;

		// Flag to signal to make-work threads that they should stop
		private static bool _makeWorkThreadStop;

		// Array to hold the stats calculated for each run of each timer.
		private static readonly Results[] RealTimeResults = new Results[MaxNumMakeWorkThreads];
		private static readonly Results[] DotNetResults = new Results[MaxNumMakeWorkThreads];

		private static void Main()
		{
			Globals.Globals.Lcd.Display("strt");
			Debug.Print("\nTimer Jitter, " + VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));

			// Debugger should NOT be attached. Debugger is incompatible with the RealTime timer.
			//      (however, MFDeploy CAN be used)
			Debug.Print("Debugger attached: " + Debugger.IsAttached);
			Debug.Print("");

			// An initial sleep can make it easier for Visual Studio to connect to the debugger
			Thread.Sleep(5000);

			// Initialize timer ticks array and stats object
			_timerTicks = new double[NumSamples];
			_stats = new Statistics(_timerTicks);

			// Set up an array for the make-work threads
			var makeWorkThreads = new Thread[MaxNumMakeWorkThreads];

			Debug.Print("Number of samples: " + NumSamples);
			Debug.Print("Timer Interval: " + TimerIntervalMilliSec + " (millisec);" + TimerIntervalMicroSec + " (microsec)");
			Debug.Print("Max number of threads: " + MaxNumMakeWorkThreads);

			// Run the profiling with make-work threads running. 
			for (var numThreads = 0; numThreads < MaxNumMakeWorkThreads; numThreads++)
			{
				// Reset the thread-stop flag
				_makeWorkThreadStop = false;

				Debug.Print("\n--------------- Number of MakeWork threads: " + numThreads);

				// Create and start the threads
				for (var i = 0; i < numThreads; i++)
				{
					var i1 = i; // Need to use local copy so lambda expression below will use the right value
					makeWorkThreads[i] = new Thread(() =>
					{
						Debug.Print("  Starting Makework thread " + i1);
						// ReSharper disable once NotAccessedVariable
						var cntr = 0;
						while (true)
						{
							if (_makeWorkThreadStop) { return; }    // If time to stop, return
							cntr++;
						}
					});
					makeWorkThreads[i].Start();
				}

				// Profile the realtime timer
				if (!ProfileRealTimeTimer(numThreads)) return;

				// Profile the .NET timer
				ProfileDotNetTimer(numThreads);

				// Stop the threads and wait till stopped
				_makeWorkThreadStop = true;
				for (var i = 0; i < numThreads; i++)
				{
					makeWorkThreads[i].Join();
					Debug.Print("  Joined MakeWork thread " + i);
				}
			}

			// Give the stats in a table that can be imported easily into Excel or other spreadsheet
			const string header = "Threads,"
				+ ","
				+ "RT_MeanError,RT_Min,RT_Max,RT_Range,RT_Mean,RT_Std,"
				+ ","
				+ "DN_MeanError,DN_Min,DN_Max,DN_Range,DN_Mean,DN_Std,";
			Debug.Print("");
			Debug.Print("Result times in millisec");
			Debug.Print("Timer interval:," + TimerIntervalMilliSec + ",millisec");
			Debug.Print("Samples:," + NumSamples);
			Debug.Print(header);
			for (var i = 0; i < MaxNumMakeWorkThreads; i++)
			{
				var realtimeResults = RealTimeResults[i];
				var dotnetResults = DotNetResults[i];
				var resultsPrint = i + ",,";
				if (realtimeResults != null)
				{
					resultsPrint += realtimeResults.MeanError + "," + realtimeResults.Min + "," + realtimeResults.Max + "," + realtimeResults.Range + "," + realtimeResults.Mean + "," + realtimeResults.Std + ",";
				}
				else
				{
					resultsPrint += ",,,,,,";
				}
				resultsPrint += ",";
				if (dotnetResults != null)
				{
					resultsPrint += dotnetResults.MeanError + "," + dotnetResults.Min + "," + dotnetResults.Max + "," + dotnetResults.Range + "," + dotnetResults.Mean + "," + dotnetResults.Std + ",";
				}
				else
				{
					resultsPrint += ",,,,,,";
				}
				Debug.Print(resultsPrint);
			}

			// We're done
			Globals.Globals.Lcd.Display("done");
		}

		/// <summary>
		/// Profile the RealTime timer
		/// </summary>
		/// <param name="numThreads">Number of make-work threads</param>
		/// <returns></returns>
		private static bool ProfileRealTimeTimer(int numThreads)
		{
			Globals.Globals.Lcd.Display("RT 0");
			// Check if debuggeer is attached. If so, abort
			if (Debugger.IsAttached)
			{
				Debug.Print("\n*** Debugger is incompatible with RealTime timer. Exiting.\n");
				return false;
			}
			var beginTime = DateTime.Now;
			// Create the timer and set the interrupt
			_realTimeTimer = new eMote.RealTime.Timer(TimerIntervalMicroSec, 0);
			_realTimeTimer.OnInterrupt += (data1, data2, time) => TimerCommon.OnTick(time, _realTimeTimer);

			// Wait until threads are done
			NextStep.WaitOne();

			var endTime = DateTime.Now;
			var elapsedTime = endTime - beginTime;
			var totalMilliseconds = elapsedTime.Ticks / TimeSpan.TicksPerMillisecond;
			Debug.Print("Elapsed time " + totalMilliseconds + " ms");
			Globals.Globals.Lcd.Display("RT 1");
			var results = CalculateStats("Samraksh RealTime Timer");
			RealTimeResults[numThreads] = results;
			PrintIntervals();
			return true;
		}

		private static void ProfileDotNetTimer(int numThreads)
		{
			Globals.Globals.Lcd.Display("Dn 0");
			_dotNetTimer = new Timer(_ => TimerCommon.OnTick(DateTime.Now, _dotNetTimer), null, 0, TimerIntervalMilliSec);

			// Wait until threads are done
			NextStep.WaitOne();

			Globals.Globals.Lcd.Display("Dn 1");
			var results = CalculateStats(".NET Timer");
			DotNetResults[numThreads] = results;
			PrintIntervals();
		}

		private static void PrintIntervals()
		{
#if PrintIntervals
			Debug.Print("===============================");
			for (var i = 0; i < _timerTicks.Length; i++) {
				Debug.Print(i + "," + _timerTicks[i]);
			}
			Debug.Print("===============================");
#endif
		}

		private static class TimerCommon
		{
			private static bool _firstTick = true;
			private static long _lastTick;

			public static void OnTick(DateTime time, object timer)
			{
				Globals.Globals.GpioJ12P1.Write(true);
				Globals.Globals.GpioJ12P1.Write(false);

				// If we're done, reset things, raise the semaphore, and return
				if (_timerTicksPtr >= _timerTicks.Length)
				{
					if (timer is eMote.RealTime.Timer)
					{
						((NativeEventDispatcher)_realTimeTimer).Dispose(); // destroy the timer
						//_realTimeTimer.Dispose();
					}
					else if (timer is Timer)
					{
						_dotNetTimer.Dispose(); // destroy the timer
					}
					else
					{
						Globals.Globals.Lcd.Display("Excp");
						throw new Exception("Unknown timer type");
					}
					_timerTicksPtr = 0; // reset the pointer for next time
					_firstTick = true;  // set to prime the pump
					NextStep.Set(); // raise the semaphore so Main can continue
					return;
				}

				// Get the current ticks value
				var thisTick = time.Ticks;

				// Prime the pump
				if (_firstTick)
				{
					_lastTick = thisTick;
					_firstTick = false;
					return;
				}

				// Calculate difference from last time
				_timerTicks[_timerTicksPtr] = thisTick - _lastTick;  // Store the difference wrt last
#if LoopTrace
                if ((thisTick - _lastTick) > 2000000) {
                    Debug.Print("_timerTicksPtr:" + _timerTicksPtr + " thistick:" + thisTick + " _lastTick:" + _lastTick);
                }
#endif
				_lastTick = thisTick;
				Globals.Globals.Lcd.Display(_timerTicksPtr);

				_timerTicksPtr++;
			}
		}

		private static Results CalculateStats(string timerType)
		{
			const long scalingFactor = TimeSpan.TicksPerMillisecond;
			const string scalingFactorLabel = "Millisecond";
			Debug.Print("");
			Debug.Print(timerType);
			Debug.Print("Units: " + scalingFactorLabel);

			double sumError = 0;
			foreach (var timerTick in _timerTicks)
			{
				var error = System.Math.Abs((timerTick / scalingFactor) - TimerIntervalMilliSec);
				sumError += error;
			}
			var meanError = sumError / _timerTicks.Length;
			Debug.Print("Mean error: " + meanError);

			var mean = _stats.Mean();
			Debug.Print("Mean: " + mean / scalingFactor);
			var min = _stats.Min();
			Debug.Print("Min: " + min / scalingFactor);
			var max = _stats.Max();
			Debug.Print("Max: " + max / scalingFactor);
			var range = _stats.Range();
			Debug.Print("Range: " + range / scalingFactor);
			//var median = Stats.Q2();
			//Debug.Print("Median: " + median / scalingFactor);
			//var mode = Stats.Mode();
			//Debug.Print("Mode: " + mode / scalingFactor);
			var std = _stats.S();
			Debug.Print("Std: " + std / scalingFactor);
			//Debug.Print("");
			var results = new Results(meanError, mean / scalingFactor, min / scalingFactor, max / scalingFactor, range / scalingFactor, std / scalingFactor);
			return results;
		}

		private class Results
		{
			public readonly double Mean;
			public readonly double Min;
			public readonly double Range;
			public readonly double Max;
			public readonly double Std;
			public readonly double MeanError;

			public Results(double meanError, double mean, double min, double max, double range, double std)
			{
				MeanError = meanError;
				Mean = mean;
				Min = min;
				Max = max;
				Range = range;
				Std = std;
				Range = range;
			}

		}

	}
}
