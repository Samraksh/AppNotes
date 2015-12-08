/*=========================
 * Simple Timer Class
 *  Define a simple one-shot or recorring timer
 * Versions
 *  1.0 Initial Version
 *  1.1 Fixed bugs 
 *      - Rcurrent timer
 *      - Thread-safe callback (use CallBack method with lock)
 *  1.2:
 *		- Refactored into SimpleOneshotTimer and SimplePeriodicTimer
 *		- Obsoleted SimpleTimer
=========================*/

using System;
using System.Threading;

namespace Samraksh.AppNote.Utility
{
	public abstract class SimpleTimerBase
	{
		private Timer _theTimer; // Can't inherit since the timer class is sealed

		public TimerCallback TimerCallback { private get; set; }
		public object CallBackValue { private get; set; }
		public int InitialDueTime { private get; set; }
		public int InitialPeriod { private get; set; }
		// Need current values in order to tell if timer is running or not
		//  Cannot reflect on timer to determine its status
		public int CurrDueTime { private get; set; }
		public int CurrPeriod { private get; set; }

		/// <summary>
		/// Timer start time
		/// </summary>
		public long StartTime { get; private set; }

		/// <summary>
		/// Start (or restart) the timer
		/// </summary>
		public void Start()
		{
			if (_theTimer == null)
			{
				lock (this)
				{
					_theTimer = new Timer(CallBack, CallBackValue, InitialDueTime, InitialPeriod);
				}
			}
			else
			{
				lock (this)
				{
					_theTimer.Change(InitialDueTime, InitialPeriod);
				}
			}
			StartTime = DateTime.Now.Ticks;
		}

		/// <summary>
		/// Stop the timer
		/// </summary>
		public void Stop()
		{
			if (_theTimer == null)
			{
				return;
			}
			lock (this)
			{
				// Make sure we're not in the callback before killing the timer
				CurrDueTime = CurrPeriod = Timeout.Infinite;
				_theTimer.Change(CurrDueTime, CurrPeriod);
			}
		}

		/// <summary>
		/// Check if the timer is stopped
		/// </summary>
		public bool IsStopped
		{
			get { return _theTimer == null || CurrDueTime <= 0; }
		}

		/// <summary>
		/// Prevent disposal during callback
		/// </summary>
		/// <param name="obj"></param>
		private void CallBack(object obj)
		{
			lock (this)
			{
				// Prevent disposal while in callback method
				TimerCallback(obj);
			}
		}
	}

	/// <summary>
	/// Timer with a simplified interface
	/// </summary>
	[Obsolete("Use SimpleOneshotTimer or SimplePeriodicTimer instead")]
	public class SimpleTimer : SimpleTimerBase
	{
		/// <summary>
		/// This creates a one-shot timer since the period is 0
		/// </summary>
		/// <param name="timerCallback"></param>
		/// <param name="callBackValue"></param>
		/// <param name="dueTime"></param>
		public SimpleTimer(TimerCallback timerCallback, object callBackValue, int dueTime)
		{
			TimerCallback = timerCallback;
			CallBackValue = callBackValue;
			InitialDueTime = CurrDueTime = dueTime;
			InitialPeriod = CurrPeriod = 0;
		}

		/// <summary>
		/// This creates a periodic timer
		/// </summary>
		/// <param name="timerCallback"></param>
		/// <param name="callBackValue"></param>
		/// <param name="dueTime"></param>
		/// <param name="period"></param>
		public SimpleTimer(TimerCallback timerCallback, object callBackValue, int dueTime, int period)
		{
			TimerCallback = timerCallback;
			CallBackValue = callBackValue;
			InitialDueTime = CurrDueTime = dueTime;
			InitialPeriod = CurrPeriod = period;
		}
	}

	/// <summary>
	/// Simple one-shot timer
	/// </summary>
	public class SimpleOneshotTimer : SimpleTimerBase
	{
		//public SimpleOneshotTimer(TimerCallback timerCallback, object callBackValue, int dueTime) : base(timerCallback, callBackValue, dueTime) { }
		public SimpleOneshotTimer(TimerCallback timerCallback, object callBackValue, int dueTime)
		{
			TimerCallback = timerCallback;
			CallBackValue = callBackValue;
			InitialDueTime = CurrDueTime = dueTime;
			InitialPeriod = CurrPeriod = 0;
		}
	}

	/// <summary>
	/// Simple periodic timer
	/// </summary>
	public class SimplePeriodicTimer : SimpleTimerBase
	{
		//public SimplePeriodicTimer(TimerCallback timerCallback, object callBackValue, int dueTime, int period): base(timerCallback, callBackValue, dueTime, period)
		public SimplePeriodicTimer(TimerCallback timerCallback, object callBackValue, int dueTime, int period)
		{
			TimerCallback = timerCallback;
			CallBackValue = callBackValue;
			InitialDueTime = CurrDueTime = dueTime;
			InitialPeriod = CurrPeriod = period;
		}
	}
}
