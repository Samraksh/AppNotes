/*--------------------------------------------------------------------
 * Sense Temperature (OneWire) app note for eMote .NOW 1.0
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *  1.0: initial release
---------------------------------------------------------------------*/

using System;
using System.Reflection;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;

/*		Kiwi connection to .NOW
	|--------------------------------------------------|
	| Kiwi					||	.NOW				   |
	|-----------------------||-------------------------|
	| Pin Desc	|	Number	||	Pin Desc	|	Number |
	|-----------------------||-------------------------|
	| Temp		|	J2/4	||	GPIO		|	J11/3  |
	| Other Pwr	|	J2/9	||	GPIO		|	J11/4  |
	| Gnd		|	J2/11	||	Ground		|	J12/10 |
	| Vin		|	J2/12	||	VOut 		|	J11/1  |
	|--------------------------------------------------|
*/


namespace Samraksh.AppNote.SenseTemperature
{
	/// <summary>
	/// Temperature Sensor App Note
	/// </summary>
	/// <remarks>
	/// Sensor Board's Other Power is enabled via GPIO Pin 4 and temperature sensor i/o is GPIO Pin 3
	/// </remarks>
	public class Program
	{
		private static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();
		// ReSharper disable once NotAccessedField.Local
		private static OutputPort _otherPower;
		private static TemperatureSensor _tempSensor;

		/// <summary>
		/// Main program
		/// </summary>
		public static void Main()
		{
			try
			{
				Debug.EnableGCMessages(false);
				Debug.Print("\nSense Temperature " + VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));
				Lcd.Write("temp");

				// Turn Kiwi temp sensor on
				_otherPower = new OutputPort(Pins.GPIO_J11_PIN4, true);

				// Initialize the temperature sensor
				_tempSensor = new TemperatureSensor(Pins.GPIO_J11_PIN3);
				
				// Sense the temperature periodically
				while (true)
				{
					// Sense the temperature; keep things fast by skipping the CRC check
					var ms1 = SenseAndMeasureExecutionTime(false);
					Debug.Print("Skip CRC: " + ms1 + " ms required; " + _tempSensor.TemperatureC + "C / " +
								_tempSensor.TemperatureF + "F");

					// Do it again, this time checking CRC
					var ms2 = SenseAndMeasureExecutionTime(true);
					Debug.Print("Check CRC: " + ms2 + " ms required; " + _tempSensor.TemperatureC + "C / " +
								_tempSensor.TemperatureF + "F");

					// Show the difference
					Debug.Print("Skipping saves " + (ms2 - ms1) + " ms");

					// Give a blank line & sleep for a while
					Debug.Print("");
					Thread.Sleep(3000);
				}
			}
			catch (Exception e)
			{
				Debug.Print(e.ToString());
				Lcd.Write("Err");
				Thread.Sleep(Timeout.Infinite);
			}
		}

		/// <summary>
		/// Sense with optional CRC checking, and calculate ms required
		/// </summary>
		/// <param name="checkCrc"></param>
		/// <returns></returns>
		private static double SenseAndMeasureExecutionTime(bool checkCrc)
		{
			var beginSense = DateTime.Now.Ticks;
			_tempSensor.Sense(checkCrc);
			var endSense = DateTime.Now.Ticks;
			// Subtract the sensor delay, as that does not enter into the execution time required
			var ms1 = ((double)(endSense - beginSense) / TimeSpan.TicksPerMillisecond) - _tempSensor.SensorDelay;
			return ms1;
		}
	}
}
