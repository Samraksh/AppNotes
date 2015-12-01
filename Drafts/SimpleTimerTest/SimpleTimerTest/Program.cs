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
			// Test one-shot timer
			const int dueTimex = 4 * 1000;
			var timer1 = new Timer(TimerTick,null,dueTimex,-1);
			_baseTime = TimeNow();
			Debug.Print("Timer 1 (one shot). Time = " + _baseTime);
			Thread.Sleep((int)(1.1 * dueTimex));

			var timer2 = new Timer(TimerTick, null, dueTimex, -1);
			_baseTime = TimeNow();
			Debug.Print("Timer 2 (one shot). Time = " + _baseTime);
			Thread.Sleep((int)(1.1 * dueTimex));
			
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
			Thread.Sleep((int)4.5 * periodTime);
			periodic.Stop();
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
