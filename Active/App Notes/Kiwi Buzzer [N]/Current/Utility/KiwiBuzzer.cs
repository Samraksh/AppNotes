using System;
using System.Threading;
using Microsoft.SPOT.Hardware;

namespace Samraksh.AppNote.Utility
{
	/// <summary>
	/// Kiwi buzzer class
	/// </summary>
	public class KiwiBuzzer
	{
		private readonly OutputPort _togglePort;
		//private readonly int _freq;
		private readonly int _interval;
		private readonly ManualResetEvent _buzzerEnable = new ManualResetEvent(false);

		/// <summary>
		/// Set up
		/// </summary>
		/// <param name="togglePin">CPU pin to toggle</param>
		/// <param name="freq">Toggle frequency</param>
		public KiwiBuzzer(Cpu.Pin togglePin, double freq)
		{
			_togglePort = new OutputPort(togglePin, false);
			//_freq = freq;
			_interval = (int)(1000/freq);
			var buzzerThread = new Thread(() =>
			{
				while (true)
				{
					// Check if enabled; wait if not
					_buzzerEnable.WaitOne();
					// Change state
					_togglePort.Write(!_togglePort.Read());
					// Sleep for half the frequency
					Thread.Sleep(_interval >> 1);
					// Do it again
					_togglePort.Write(!_togglePort.Read());
					Thread.Sleep(_interval >> 1);
				}
				// ReSharper disable once FunctionNeverReturns
			});
			buzzerThread.Start();
		}

		/// <summary>
		/// Enable / disable buzzer
		/// </summary>
		public void Enable(bool enable)
		{
			if (enable)
			{
				_buzzerEnable.Set();
			}
			else
			{
				_buzzerEnable.Reset();
			}
		}
	}
}
