using System;
using Microsoft.SPOT;
using Samraksh.AppNote.Samraksh.AppNote.DotNow.Radar;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;
using Samraksh.eMote.NonVolatileMemory;
using Math = System.Math;

namespace Samraksh.AppNote.DotNow.RadarDisplacementDetector
{
	public static partial class RadarDisplacementDetector
	{
		/// <summary>Crc for reading</summary>
		private static uint _crcRead;

		/// <summary>
		/// Output log data
		/// </summary>
		private static void OutputLoggedData()
		{
			// If not logging, just return
			if (!Globals.Out.LoggingRequired)
			{
				return;
			}

			var allocationsRead = 0;

			// Print raw sample header
			if (Globals.Out.PrintAfterRawLogging)
				if (Globals.Out.RawSample.Opt.LogRawSampleToSD)
				{
					Debug.Print("RawI,RawQ");
				}
				else if (Globals.Out.RawEverything.Opt.LogRawEverythingToSD)
				{
					Debug.Print("SampleNum,RawI,RawQ,SampleI,SampleQ,IsCut,IsDisplacement,IsConf");
				}
			// Print sample and cut header
			if (Globals.Out.SampleAndCut.Opt.LogToDebug)
			{
				Debug.Print(new string(Globals.Out.SampleAndCut.BuffDef.Prefix.FieldsC) + "\tSampleNum\tSample.I\tSample.Q\tIsCut");
			}

			// Print snippet displacement and confirmation header
			if (Globals.Out.SnippetDispAndConf.Opt.LogToDebug)
			{
				Debug.Print(new string(Globals.Out.SnippetDispAndConf.BuffDef.Prefix.FieldsC) +
							"\tSampleNum\tCumCuts\tIsDisp\tIsConf");
			}

			// Let the use know that copying to SD card is happening
			if (Globals.Out.RawSample.Opt.Logging || Globals.Out.RawEverything.Opt.Logging)
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
				Globals.Out.RawSample.BufferDef.BuffSize);
			buffSize = Math.Max(
				buffSize,
				Globals.Out.RawEverything.BufferDef.BuffSize);
			buffSize = Math.Max(
				buffSize,
				Globals.Out.SnippetDispAndConf.BuffDef.BuffSize);
			buffSize = Math.Max(
				buffSize,
				Globals.Out.SampleAndCut.BuffDef.BuffSize);
			var buffer = new byte[buffSize];

			var refsRead = 0;

			// Read data references until we hit a null, which signifies the end
			while (true)
			{
				var status = Globals.Out.Dstore.ReadAllDataReferences(dRefs, dRefsOffset++);
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

				allocationsRead++;
				refsRead++;

				if (Globals.Out.SampleAndCut.Opt.Logging || Globals.Out.SnippetDispAndConf.Opt.LogToDebug)
				{

					var header0 = BitConverter.ToChar(buffer, Globals.Out.AsciiHeader.Header0);
					var header1 = BitConverter.ToChar(buffer, Globals.Out.AsciiHeader.Header1);

					if (header0 == Globals.Out.SampleAndCut.BuffDef.Prefix.SampleC[0] &&
						header1 == Globals.Out.SampleAndCut.BuffDef.Prefix.SampleC[1])
					{
						PrintSampleAndCut(buffer);
					}

					else if (header0 == Globals.Out.SnippetDispAndConf.BuffDef.Prefix.SnippetC[0] &&
							 header1 == Globals.Out.SnippetDispAndConf.BuffDef.Prefix.SnippetC[1])
					{
						PrintSnippetAndConf(buffer);
					}

					else
					{
						throw new Exception("Invalid header from DataStore: '" + header0 + header1 + "'");
					}
				}

				if (Globals.Out.RawSample.Opt.Logging)
				{
					Debug.Print("# 1");

					// Write raw sample to SD
					SD.Write(buffer, 0, Globals.Out.RawSample.BufferDef.BuffSize);

					if (allocationsRead % DetectorParameters.SamplesPerSecond == 1)
					{
						Debug.Print("Snippet " + allocationsRead / DetectorParameters.SamplesPerSecond);
					}

					// Print
					if (Globals.Out.PrintAfterRawLogging && refsRead < 10)
					{
						var rawI = BitConverter.ToInt32(buffer, Globals.Out.RawSample.BufferDef.RawI);
						var rawQ = BitConverter.ToInt32(buffer, Globals.Out.RawSample.BufferDef.RawQ);
						Debug.Print(rawI + "," + rawQ);
					}

					//var initCrc = Globals.CrcRead;

					_crcRead = CalcCrc(buffer, Globals.Out.RawSample.BufferDef.BuffSize);

					//Debug.Print("CRC init: " + initCrc + ", CRC end: " + Globals.CrcRead);

					//var vals = new StringBuilder("$ ");
					//for (var i = 0; i < Globals.DataStoreItems.RawSample.BuffSize; i++)
					//{
					//	vals.Append(Globals.DataStoreItems.RawSample.Buffer[i] + "\t");
					//}
					//Debug.Print(vals.ToString() + "\n");
				}

				if (Globals.Out.RawEverything.Opt.Logging)
				{
					Debug.Print("# 2");

					// Write everything of interest to SD
					SD.Write(buffer, 0, Globals.Out.RawEverything.BufferDef.BuffSize);

					if (allocationsRead % DetectorParameters.SamplesPerSecond == 1)
					{
						Debug.Print("Snippet " + allocationsRead / DetectorParameters.SamplesPerSecond);
					}

					// Print
					if (Globals.Out.PrintAfterRawLogging && refsRead < 10)
					{
						var sampleNum = BitConverter.ToInt32(buffer, Globals.Out.RawEverything.BufferDef.SampleNum);
						var rawI = BitConverter.ToUInt16(buffer, Globals.Out.RawEverything.BufferDef.RawI);
						var rawQ = BitConverter.ToUInt16(buffer, Globals.Out.RawEverything.BufferDef.RawQ);
						var sampleI = BitConverter.ToInt32(buffer, Globals.Out.RawEverything.BufferDef.SampleI);
						var sampleQ = BitConverter.ToInt32(buffer, Globals.Out.RawEverything.BufferDef.SampleQ);
						var isCut = BitConverter.ToInt32(buffer, Globals.Out.RawEverything.BufferDef.IsCut);
						var isDisplacement = BitConverter.ToBoolean(buffer, Globals.Out.RawEverything.BufferDef.IsDisplacement);
						var isConf = BitConverter.ToBoolean(buffer, Globals.Out.RawEverything.BufferDef.IsConf);

						Debug.Print(sampleNum + "," + rawI + "," + rawQ + "," + sampleI + "," + sampleQ + "," + isCut + "," + isDisplacement + "," + isConf);
					}

					// Update CRC
					_crcRead = CalcCrc(buffer, Globals.Out.RawEverything.BufferDef.BuffSize);

				}

			}

			// Done reading from DataStore; if outputting to SD, put out eof
			if (Globals.Out.RawSample.Opt.Logging || Globals.Out.RawEverything.Opt.Logging)
			{
				buffer[0] = 0x0C;
				for (var i = 0; i < 100; i++)
				{
					SD.Write(buffer, 0, 1);
				}
			}

			Debug.Print("\n* DataStore CRC check:\t" + (Globals.CrcWritten == _crcRead ? "YES" : "NO") + "\n\tWrite CRC:\t" + Globals.CrcWritten + "\n\tRead CRC:\t" + _crcRead);
			Debug.Print("* Allocation check:\t" + (Globals.AllocationsWritten == allocationsRead ? "YES" : "NO") + "\n\tAllocations written:\t" + Globals.AllocationsWritten + "\n\tAllocations read:\t" + allocationsRead);

			//var arrayVals = new StringBuilder("* ");
			//foreach (var theVal in Globals.DataStoreItems.Buffer) {
			//	arrayVals.Append(theVal + ",");
			//}
			//Debug.Print(arrayVals.ToString());

		}

		private static uint CalcCrc(byte[] buffer, int buffSize)
		{
			return Microsoft.SPOT.Hardware.Utility.ComputeCRC(buffer, 0, buffSize, _crcRead);
		}

		private static void PrintSnippetAndConf(byte[] buffer)
		{
			if (!Globals.Out.SnippetDispAndConf.Opt.LogToDebug)
			{
				return;
			}
			var sampleNum = BitConverter.ToInt32(buffer, Globals.Out.SnippetDispAndConf.BuffDef.SampleNum);
			var cumCuts = BitConverter.ToInt32(buffer, Globals.Out.SnippetDispAndConf.BuffDef.CumCuts);
			var isDisp = BitConverter.ToInt32(buffer, Globals.Out.SnippetDispAndConf.BuffDef.IsDisp);
			var isConfirmed = BitConverter.ToInt32(buffer, Globals.Out.SnippetDispAndConf.BuffDef.IsConfirmed);

			Debug.Print(
				new string(Globals.Out.SnippetDispAndConf.BuffDef.Prefix.SnippetC)
				+ "\t" + sampleNum
				+ "\t" + cumCuts
				+ "\t" + isDisp
				+ "\t" + isConfirmed
				);

			_crcRead = Microsoft.SPOT.Hardware.Utility.ComputeCRC(
				Globals.Out.SnippetDispAndConf.BuffDef.Buffer,
				0,
				Globals.Out.SnippetDispAndConf.BuffDef.BuffSize,
				_crcRead);

		}

		private static void PrintSampleAndCut(byte[] buffer)
		{
			if (!Globals.Out.SampleAndCut.Opt.Logging)
			{
				return;
			}
			var sampleNum = BitConverter.ToInt32(buffer, Globals.Out.SampleAndCut.BuffDef.SampleNum);
			var sampleI = BitConverter.ToInt32(buffer, Globals.Out.SampleAndCut.BuffDef.SampleI);
			var sampleQ = BitConverter.ToInt32(buffer, Globals.Out.SampleAndCut.BuffDef.SampleQ);
			var isCut = BitConverter.ToInt32(buffer, Globals.Out.SampleAndCut.BuffDef.IsCut);

			Debug.Print(
				new string(Globals.Out.SampleAndCut.BuffDef.Prefix.SampleC)
				+ "\t" + sampleNum
				+ "\t" + sampleI
				+ "\t" + sampleQ
				+ "\t" + isCut
				);

			_crcRead = Microsoft.SPOT.Hardware.Utility.ComputeCRC(
				Globals.Out.SampleAndCut.BuffDef.Buffer,
				0,
				Globals.Out.SampleAndCut.BuffDef.BuffSize,
				_crcRead);

		}
	}
}
