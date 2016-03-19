using System;
using Microsoft.SPOT;
using Samraksh.AppNote.DotNow.RadarDisplacement.Detector.Globals;
using Samraksh.eMote.NonVolatileMemory;
using Math = System.Math;

using RawSample = Samraksh.AppNote.DotNow.RadarDisplacement.Detector.Globals.OutputItems.RawSample;
using SampleAndCut = Samraksh.AppNote.DotNow.RadarDisplacement.Detector.Globals.OutputItems.SampleAndCut;
using SnippetDispAndConf = Samraksh.AppNote.DotNow.RadarDisplacement.Detector.Globals.OutputItems.SnippetDispAndConf;

namespace Samraksh.AppNote.DotNow.RadarDisplacement.Detector
{
	public static partial class RadarDisplacementDetector
	{
		/// <summary>
		/// Output log data
		/// </summary>
		private static void ProcessDataStore()
		{
			// If not logging, just return
			if (!OutputItems.LoggingRequired.Required)
			{
				return;
			}

			var allocationsRead = 0;

			// Print raw sample header
			if (RawSample.OutOpt.LogToPrint > 0)
			{
				switch (RawSample.CollectionType)
				{
					case RawSample.CollectionOptions.RawSampleOnly:
						RawSample.RawSampleOnly.PrintHeader();
						break;
					case RawSample.CollectionOptions.RawSampleAndAnalysis:
						RawSample.RawSampleAndAnalysis.PrintHeader();
						break;
					case RawSample.CollectionOptions.None:
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}

			// Print sample and cut header
			if (SampleAndCut.OutOpt.LogToPrint > 0)
			{
				SampleAndCut.PrintHeader();
			}

			// Print snippet displacement and confirmation header
			if (SnippetDispAndConf.OutOpt.LogToPrint > 0)
			{
				SnippetDispAndConf.PrintHeader();
			}

			// Let the user know that copying to SD card is happening
			if (OutputItems.LoggingRequired.ToSDRequired)
			{
				Debug.Print("Copying logged data to microSD card");
			}

			// Read all data references
			GlobalItems.Lcd.Write("tttt");
			var dRefsOffset = 0;
			var dRefs = new DataReference[1];	// Get data references one at a time

			// Set up a buffer that's big enough
			var buffSize = 0;
			buffSize = Math.Max(buffSize, RawSample.RawSampleOnly.BuffDef.BuffSize);
			buffSize = Math.Max(buffSize, RawSample.RawSampleAndAnalysis.BuffDef.BuffSize);
			buffSize = Math.Max(buffSize, SnippetDispAndConf.BuffDef.BuffSize);
			buffSize = Math.Max(buffSize, SampleAndCut.BuffDef.BuffSize);
			var buffer = new byte[buffSize];

			// Read data references until we hit a null, which signifies the end
			while (true)
			{
				var status = OutputItems.DStore.ReadAllDataReferences(dRefs, dRefsOffset++);
				if (status != DataStoreReturnStatus.Success)
				{
					throw new Exception("Error reading from DataStore. Return code: " + status);
				}
				var theDRef = dRefs[0];	// Data reference array is size 1
				if (theDRef == null)
				{
					break;
				}
				theDRef.Read(buffer, theDRef.Size);

				// Update the CRC
				GlobalItems.CrcRead = Microsoft.SPOT.Hardware.Utility.ComputeCRC(buffer, 0, theDRef.Size, GlobalItems.CrcRead);

				allocationsRead++;

				if (allocationsRead % 100 == 1)
				{
					//var snippetNo = allocationsRead / DetectorParameters.SamplesPerSecond;
					Debug.Print("Allocation " + allocationsRead);
					GlobalItems.Lcd.Write("t" + allocationsRead);
				}

				// If logging to SD, copy DataStore buffer to SD
				if (OutputItems.LoggingRequired.ToSDRequired)
				{
					GlobalItems.SDBufferedWrite.Write(buffer, 0, (ushort)theDRef.Size);
				}

				// If print vals after logging, do so according to collection type
				RawSample.RawSampleOnly.PrintVals(buffer);
				RawSample.RawSampleAndAnalysis.PrintVals(buffer);
				SampleAndCut.PrintVals(buffer);
				SnippetDispAndConf.PrintVals(buffer);
			}

			// Done reading from DataStore; if outputting to SD, put out eof
			if (OutputItems.LoggingRequired.ToSDRequired)
			{
				buffer[0] = GlobalItems.Eof;
				for (var i = 0; i < 100; i++)
				{
					GlobalItems.SDBufferedWrite.Write(buffer, 0, 1);
				}
				GlobalItems.SDBufferedWrite.Flush();
			}

			Debug.Print("\n* DataStore CRC check:\t" + (GlobalItems.CrcWritten == GlobalItems.CrcRead ? "YES" : "NO") + "\n\tWrite CRC:\t" + GlobalItems.CrcWritten + "\n\tRead CRC:\t" + GlobalItems.CrcRead);
			Debug.Print("* Allocation check:\t" + (GlobalItems.AllocationsWritten == allocationsRead ? "YES" : "NO") + "\n\tAllocations written:\t" + GlobalItems.AllocationsWritten + "\n\tAllocations read:\t" + allocationsRead);

			//var arrayVals = new StringBuilder("* ");
			//foreach (var theVal in GlobalItems.DataStoreItems.Buffer) {
			//	arrayVals.Append(theVal + ",");
			//}
			//Debug.Print(arrayVals.ToString());
		}
	}
}
