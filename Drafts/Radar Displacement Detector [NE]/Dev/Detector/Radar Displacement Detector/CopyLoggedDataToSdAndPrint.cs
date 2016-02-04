using System;
using Microsoft.SPOT;
using Samraksh.Appnote.Utility;
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
			if (!OutputItems.LoggingRequired.Required)
			{
				return;
			}

			var allocationsRead = 0;

			// Print raw sample header
			if (OutputItems.RawSample.OutOpt.LogToDebug)
			{
				switch (OutputItems.RawSample.CollectionType)
				{
					case OutputItems.RawSample.CollectionOptions.RawSampleOnly:
						OutputItems.RawSample.RawSampleOnly.PrintHeader();
						break;
					case OutputItems.RawSample.CollectionOptions.RawSampleAndAnalysis:
						OutputItems.RawSample.RawSampleAndAnalysis.PrintHeader();
						break;
					case OutputItems.RawSample.CollectionOptions.None:
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}

			// Print sample and cut header
			if (OutputItems.AsciiSampleAndCut.OutOpt.LogToDebug)
			{
				OutputItems.AsciiSampleAndCut.PrintHeader();
			}

			// Print snippet displacement and confirmation header
			if (OutputItems.AsciiSnippetDispAndConf.OutOpt.LogToDebug)
			{
				OutputItems.AsciiSnippetDispAndConf.PrintHeader();
			}

			// Let the user know that copying to SD card is happening
			if (OutputItems.LoggingRequired.ToSDRequired)
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
			buffSize = Math.Max(buffSize, OutputItems.RawSample.RawSampleOnly.BufferDef.BuffSize);
			buffSize = Math.Max(buffSize, OutputItems.RawSample.RawSampleAndAnalysis.BufferDef.BuffSize);
			buffSize = Math.Max(buffSize, OutputItems.AsciiSnippetDispAndConf.BuffDef.BuffSize);
			buffSize = Math.Max(buffSize, OutputItems.AsciiSampleAndCut.BuffDef.BuffSize);
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

				OutputItems.AsciiSampleAndCut.PrintVals(buffer);
				OutputItems.AsciiSnippetDispAndConf.PrintVals(buffer);

				if (allocationsRead % DetectorParameters.SamplesPerSecond == 1)
				{
					var snippetNo = allocationsRead / DetectorParameters.SamplesPerSecond;
					Debug.Print("Snippet " + snippetNo);
#if DotNow
					Globals.Lcd.Write("t" + (snippetNo % 1000));
#endif
				}

				// If logging to SD, copy DataStore buffer to SD

				if (OutputItems.LoggingRequired.ToSDRequired)
				{
					Globals.SDBufferedWrite.Write(buffer, 0, (ushort)theDRef.Size);
				}

				// If logging to Debug, do so according to collection type

				if (OutputItems.RawSample.OutOpt.LogToDebug)
				{
					switch (OutputItems.RawSample.CollectionType)
					{
						case OutputItems.RawSample.CollectionOptions.RawSampleOnly:
							OutputItems.RawSample.RawSampleOnly.PrintVals(buffer);
							break;
						case OutputItems.RawSample.CollectionOptions.RawSampleAndAnalysis:
							OutputItems.RawSample.RawSampleAndAnalysis.PrintVals(buffer);
							break;
						case OutputItems.RawSample.CollectionOptions.None:
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}

				if (OutputItems.AsciiSampleAndCut.OutOpt.LogToDebug)
				{
					OutputItems.AsciiSampleAndCut.PrintVals(buffer);
				}

				if (OutputItems.AsciiSnippetDispAndConf.OutOpt.LogToDebug)
				{
					OutputItems.AsciiSnippetDispAndConf.PrintVals(buffer);
				}
			}

			// Done reading from DataStore; if outputting to SD, put out eof
			if (OutputItems.LoggingRequired.ToSDRequired)
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
