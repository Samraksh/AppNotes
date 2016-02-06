using System.Reflection;
using System.Threading;
using Microsoft.SPOT;
using Samraksh.AppNote.DotNow.RadarDisplacementDetector.Common;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.Net.Radio;

namespace Samraksh.AppNote.DotNow.RadarDisplacement.Receiver
{
	/// <summary>
	/// receive radio updates
	/// </summary>
	public class Program
	{
		private static readonly EnhancedEmoteLCD Lcd = new EnhancedEmoteLCD();

		/// <summary>
		/// Main
		/// </summary>
		public static void Main()
		{
			Debug.Print("Radar Displacement Receiver " + VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));
			Lcd.Clear();
			Lcd.Write("rcvr");
			Thread.Sleep(1000);

			CommonItems.RadioUpdates.Radio = new SimpleCSMA(RadioName.RF231RADIO, 140, TxPowerValue.Power_0Point7dBm, CommonItems.RadioUpdates.Channel);
			CommonItems.RadioUpdates.Radio.OnReceive += RadioMonitorUpdates.ReceiveUpdate;
			CommonItems.RadioUpdates.Radio.SetRadioState(SimpleCSMA.RadioStates.On);

			Thread.Sleep(Timeout.Infinite);
		}

	}
}
