/*=========================
 * Simple Timer Class
 *  Define a simple one-shot or recurring timer
 * Versions
 *  1.0 Initial Version
 *  1.1 Fixed bugs 
 *      - Recurring timer
 *      - Thread-safe callback (use CallBack method with lock)
 *  1.2:
 *		- Refactored into SimpleOneshotTimer and SimplePeriodicTimer
 *		- Obsoleted SimpleTimer
=========================*/

using System;
using System.Threading;

namespace Samraksh.AppNote.Utility
{
	/// <summary>
	/// Simplified timer. Makes it easier to manage one-shot and periodic timers
	/// </summary>
	public abstract class SimpleTimerBase
	{
		private Timer _theTimer; // Can't inherit since the timer class is sealed

		/// <summary>User callback</summary>
		public TimerCallback UserCallback { private get; set; }
		/// <summary>Call back value</summary>
		public object CallBackValue { private get; set; }

		/// <summary>Initially-specified due time</summary>
		protected int InitialDueTime;
		/// <summary>Initially-specified period</summary>
		protected int InitialPeriod;
		// Need current values in order to tell if timer is running or not
		//  Cannot reflect on timer to determine its status
		/// <summary>Current due time</summary>
		protected int CurrDueTime;
		/// <summary>Current period</summary>
		protected int CurrPeriod;

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
				UserCallback(obj);
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
		/// <param name="userCallback"></param>
		/// <param name="callBackValue"></param>
		/// <param name="dueTime"></param>
		public SimpleTimer(TimerCallback userCallback, object callBackValue, int dueTime)
		{
			UserCallback = userCallback;
			CallBackValue = callBackValue;
			InitialDueTime = CurrDueTime = dueTime;
			InitialPeriod = CurrPeriod = 0;
		}

		/// <summary>
		/// This creates a periodic timer
		/// </summary>
		/// <param name="userCallback"></param>
		/// <param name="callBackValue"></param>
		/// <param name="dueTime"></param>
		/// <param name="period"></param>
		public SimpleTimer(TimerCallback userCallback, object callBackValue, int dueTime, int period)
		{
			UserCallback = userCallback;
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
		/// <summary>
		/// One-Shot Timer
		/// </summary>
		/// <param name="userCallback"></param>
		/// <param name="callBackValue"></param>
		/// <param name="dueTime"></param>
		public SimpleOneshotTimer(TimerCallback userCallback, object callBackValue, int dueTime)
		{
			UserCallback = userCallback;
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
		/// <summary>
		/// Periodic Timer
		/// </summary>
		/// <param name="userCallback"></param>
		/// <param name="callBackValue"></param>
		/// <param name="dueTime"></param>
		/// <param name="period"></param>
		public SimplePeriodicTimer(TimerCallback userCallback, object callBackValue, int dueTime, int period)
		{
			UserCallback = userCallback;
			CallBackValue = callBackValue;
			InitialDueTime = CurrDueTime = dueTime;
			InitialPeriod = CurrPeriod = period;
		}
	}
}
