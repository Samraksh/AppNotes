using System;
using Microsoft.SPOT;
using Samraksh.Appnote.Utility;
using Samraksh.AppNote.DotNow.Radar;
using Samraksh.eMote.NonVolatileMemory;
using Math = System.Math;

namespace Samraksh.AppNote.DotNow.RadarDisplacementDetector
{
	public static partial class RadarDisplacementDetector
	{
		/// <summary>
		/// Output log data
		/// </summary>
		private static void CopyLoggedDataToSdAndPrint()
		{
			// If not logging, just return
			if (!OutputItems.LoggingRequired)
			{
				return;
			}

			var allocationsRead = 0;

			// Print raw sample header
			if (OutputItems.Sample.Opt.PrintAfterLogging)
				if (OutputItems.Sample.Opt.LogToSD)
				{
					OutputItems.Sample.RawSample.PrintHeader();
				}
				else if (OutputItems.Sample.RawAndAnalysis.Opt.LogRawEverythingToSD)
				{
					OutputItems.Sample.RawAndAnalysis.PrintHeader();
				}
			// Print sample and cut header
			if (OutputItems.SampleAndAnalysis.Opt.LogToDebug)
			{
				OutputItems.SampleAndAnalysis.PrintHeader();
			}

			// Print snippet displacement and confirmation header
			if (OutputItems.SnippetDispAndConf.Opt.LogToDebug)
			{
				OutputItems.SnippetDispAndConf.PrintHeader();
			}

			// Let the user know that copying to SD card is happening
			if (OutputItems.LoggingRequired)
			{
				Debug.Print("Copying logged data to microSD card");
			}

			// Read all data references
#if DotNow
			Globals.Lcd.Write("tttt");
#endif
			var dRefsOffset = 0;
			var dRefs = new DataReference[1];

			// Set up a buffer that's big enough
			var buffSize = 0;
			buffSize = Math.Max(
				buffSize,
				OutputItems.Sample.RawSample.BufferDef.BuffSize);
			buffSize = Math.Max(
				buffSize,
				OutputItems.Sample.RawAndAnalysis.BufferDef.BuffSize);
			buffSize = Math.Max(
				buffSize,
				OutputItems.SnippetDispAndConf.BuffDef.BuffSize);
			buffSize = Math.Max(
				buffSize,
				OutputItems.SampleAndAnalysis.BuffDef.BuffSize);
			var buffer = new byte[buffSize];

			var refsRead = 0;

			// Read data references until we hit a null, which signifies the end
			while (true)
			{
				var status = OutputItems.DStore.ReadAllDataReferences(dRefs, dRefsOffset++);
				if (status != DataStoreReturnStatus.Success)
				{
					throw new Exception("Error reading from DataStore. Return code: " + status);
				}
				var theDRef = dRefs[0];
				if (theDRef == null)
				{
					break;
				}
				theDRef.Read(buffer, theDRef.Size);

				// Update the CRC
				Globals.CrcRead = Microsoft.SPOT.Hardware.Utility.ComputeCRC(buffer, 0, theDRef.Size, Globals.CrcRead);

				allocationsRead++;
				refsRead++;

				OutputItems.SampleAndAnalysis.PrintVals(buffer);
				OutputItems.SnippetDispAndConf.PrintVals(buffer);

				if (allocationsRead % DetectorParameters.SamplesPerSecond == 1)
				{
					var snippetNo = allocationsRead / DetectorParameters.SamplesPerSecond;
					Debug.Print("Snippet " + snippetNo);
#if DotNow
					Globals.Lcd.Write("t" + (snippetNo % 1000));
#endif
				}
#error output buffer unconditionally if (OutputItems.OutputToSDRequired). Need to use the data reference size

				if (OutputItems.OutputToSDRequired)
				{
					// Write raw sample to SD
					Globals.SDBufferedWrite.Write(buffer, 0, (ushort)theDRef.Size);

					// Print
					if (!PrintAfterRawLogging || refsRead >= 10)
					{
						return;
					}
					PrintVals(buffer);

				}

				if (OutputItems.Sample.Opt.Logging)
				{
					OutputItems.Sample.RawSample.WriteToSd(buffer, refsRead);
				}

				if (OutputItems.Sample.RawAndAnalysis.Opt.Logging)
				{
					OutputItems.Sample.RawAndAnalysis.WriteToSd(buffer, refsRead);
				}

			}

			// Done reading from DataStore; if outputting to SD, put out eof
			if (OutputItems.LoggingRequired)
			{
				buffer[0] = Globals.Eof;
				for (var i = 0; i < 100; i++)
				{
					Globals.SDBufferedWrite.Write(buffer, 0, 1);
				}
				Globals.SDBufferedWrite.Flush();
			}

			Debug.Print("\n* DataStore CRC check:\t" + (Globals.CrcWritten == Globals.CrcRead ? "YES" : "NO") + "\n\tWrite CRC:\t" + Globals.CrcWritten + "\n\tRead CRC:\t" + Globals.CrcRead);
			Debug.Print("* Allocation check:\t" + (Globals.AllocationsWritten == allocationsRead ? "YES" : "NO") + "\n\tAllocations written:\t" + Globals.AllocationsWritten + "\n\tAllocations read:\t" + allocationsRead);

			//var arrayVals = new StringBuilder("* ");
			//foreach (var theVal in Globals.DataStoreItems.Buffer) {
			//	arrayVals.Append(theVal + ",");
			//}
			//Debug.Print(arrayVals.ToString());

		}
	}
}
