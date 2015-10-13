using System;
using Microsoft.SPOT;
using Samraksh.AppNote.Samraksh.AppNote.DotNow.Radar;
using Samraksh.Appnote.Utility;
using Samraksh.eMote.DotNow;
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
			if (OutputItems.PrintAfterRawLogging)
				if (OutputItems.RawSample.Opt.LogRawSampleToSD)
				{
					OutputItems.RawSample.PrintHeader();
				}
				else if (OutputItems.RawEverything.Opt.LogRawEverythingToSD)
				{
					OutputItems.RawEverything.PrintHeader();
				}
			// Print sample and cut header
			if (OutputItems.SampleAndCut.Opt.LogToDebug)
			{
				OutputItems.SampleAndCut.PrintHeader();
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
			Lcd.Write("tttt");
#endif
			var dRefsOffset = 0;
			var dRefs = new DataReference[1];

			// Set up a buffer that's big enough
			var buffSize = 0;
			buffSize = Math.Max(
				buffSize,
				OutputItems.RawSample.BufferDef.BuffSize);
			buffSize = Math.Max(
				buffSize,
				OutputItems.RawEverything.BufferDef.BuffSize);
			buffSize = Math.Max(
				buffSize,
				OutputItems.SnippetDispAndConf.BuffDef.BuffSize);
			buffSize = Math.Max(
				buffSize,
				OutputItems.SampleAndCut.BuffDef.BuffSize);
			var buffer = new byte[buffSize];

			var refsRead = 0;

			// Read data references until we hit a null, which signifies the end
			while (true)
			{
				var status = OutputItems.DataStore.ReadAllDataReferences(dRefs, dRefsOffset++);
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

				if (OutputItems.SampleAndCut.Opt.Logging)
				{
					OutputItems.SampleAndCut.PrintVals(buffer);
				}

				if (OutputItems.SnippetDispAndConf.Opt.LogToDebug)
				{
					OutputItems.SnippetDispAndConf.PrintVals(buffer);
				}

				if (allocationsRead % DetectorParameters.SamplesPerSecond == 1)
				{
					var snippetNo = allocationsRead / DetectorParameters.SamplesPerSecond;
					Debug.Print("Snippet " + snippetNo);
#if DotNow
					Lcd.Write("t" + (snippetNo % 1000));
#endif
				}

				if (OutputItems.RawSample.Opt.Logging)
				{
					OutputItems.RawSample.WriteToSd(buffer, refsRead);
				}

				if (OutputItems.RawEverything.Opt.Logging)
				{
					OutputItems.RawEverything.WriteToSd(buffer, refsRead);
				}

			}

			// Done reading from DataStore; if outputting to SD, put out eof
			if (OutputItems.LoggingRequired)
			{
				buffer[0] = Eof;
				for (var i = 0; i < 100; i++)
				{
					SdBufferedWrite.Write(buffer, 0, 1);
				}
				SdBufferedWrite.Flush();
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
