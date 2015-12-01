using System;
using System.Threading;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;

namespace Samraksh.AppNotes.SimpleTimerTest
{
	public class Program
	{
		private static double _baseTime;
		public static void Main()
		{
			// Test SimpleOneshotTimer
			const int dueTime = 4 * 1000;
			var oneshot = new SimpleOneshotTimer(TimerTick, null, dueTime);
			oneshot.Start();
			_baseTime = TimeNow();
			Debug.Print("SimpleOneshotTimer. Time = " + _baseTime);
			Thread.Sleep((int)(1.1 * dueTime));

			// Test SimplePeriodicTimer
			const int periodTime = 1 * 1000;
			var periodic = new SimplePeriodicTimer(TimerTick, null, periodTime, periodTime);
			_baseTime = TimeNow();
			Debug.Print("SimplePeriodicTimer. Time = " + _baseTime);
			periodic.Start();
			Thread.Sleep((int)5.5 * periodTime);
			periodic.Stop();
			// Sleep a bit before stopping. Otherwise this main thread will terminate while the timer is still active and the last tick will be late.
			Thread.Sleep(1000);
		}

		private static void TimerTick(object obj)
		{
			Debug.Print("\t" + (TimeNow() - _baseTime));
		}

		private static double TimeNow()
		{
			return (double)DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
		}
	}
}
