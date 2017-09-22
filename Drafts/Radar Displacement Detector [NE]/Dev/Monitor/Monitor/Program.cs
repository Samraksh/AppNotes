using System.Reflection;
using System.Threading;
using Microsoft.SPOT;
using Samraksh.Appnote.Utility;
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
		//private static readonly EnhancedEmoteLCD Lcd = new EnhancedEmoteLCD();

		/// <summary>
		/// Main
		/// </summary>
		public static void Main()
		{
			Debug.Print("Radar Displacement Receiver " + VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));
			Global.Lcd.Clear();
			Global.Lcd.Write("rcvr");
			Thread.Sleep(1000);

			CommonItems.RadioUpdates.MAC = RadioUtilities.GetMAC();
			CommonItems.RadioUpdates.MAC.OnNeighborChange += (o, e) =>
			{
				RadioUtilities.PrintNeighborChange(CommonItems.RadioUpdates.MAC);
			};
			RadioUtilities.PrintRadioConfig(CommonItems.RadioUpdates.MAC);
			RadioUtilities.PrintNeighborsPeriodically(CommonItems.RadioUpdates.MAC);

			CommonItems.RadioUpdates.MAC.OnReceive += RadioMonitorUpdates.ReceiveUpdate;

			Thread.Sleep(Timeout.Infinite);
		}

	}
}
