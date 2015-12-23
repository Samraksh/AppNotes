/*--------------------------------------------------------------------
 * Kiwi Buzzer: app note for the eMote .NOW
 * (c) 2015 The Samraksh Company
 * 
 * Generate a tone on the Kiwi buzzer
 * 
 * Version history
 *      1.0: initial release
---------------------------------------------------------------------*/

using System.Reflection;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;

namespace Samraksh.eMote.KiwiBuzzer
{
	public class Program
	{
		// Set the desired frequency
		private const double Freq = 4000;

		/// <summary>
		/// The program
		/// </summary>
		public static void Main()
		{
			Debug.Print("Kiwi Buzzer");
			Debug.Print(VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));
			var lcd = new EnhancedEmoteLcd();
			lcd.Write("1111");
			Thread.Sleep(1000);

			// GPIO J12 Pin 1 is set to true (high) to enable the Kiwi board
			// ReSharper disable once UnusedVariable
			var enable = new OutputPort(Pins.GPIO_J12_PIN2, true);
			// GPIO J12 Pin 2 is used to create the sound
			var buzzer = new AppNote.Utility.KiwiBuzzer(Pins.GPIO_J12_PIN2, Freq);
			lcd.Write("2222");
			buzzer.Enable(true);
			Thread.Sleep(10 * 1000);
			buzzer.Enable(false);
			lcd.Write("3333");
		}
	}
}
