using System;
using Microsoft.SPOT;
using Samraksh.eMote.NonVolatileMemory;
using BitConverter = Samraksh.AppNote.Utility.BitConverter;

namespace Samraksh.AppNote.DotNow.RadarDisplacement.Detector.Globals
{
	/// <summary>
	/// Output items
	/// </summary>
	public static class OutputItems
	{
		/// <summary>
		/// DataStore object
		/// </summary>
		public static readonly DataStore DStore = DataStore.Instance(StorageType.NOR, true);

		/// <summary>
		/// Kind of logging required
		/// </summary>
		public static class LoggingRequired
		{
			/// <summary>True iff output to SD required</summary>
			public static bool ToSDRequired;

			/// <summary>True iff output to debug required</summary>
			public static bool ToDebugRequired;

			/// <summary>Options true iff logging to either</summary>
			public static bool Required;
		}

		/// <summary>Field names header</summary>
		public static char[] FieldNamesHeader = { '#', 'a' };

		/// <summary>
		/// Record prefix
		/// </summary>
		/// <remarks>
		/// Prefixes:
		///		#s	Sync
		///		#r	Raw Sample
		///		#e	Raw Everything
		///		#b	Sample and Cut
		///		#d	Snippet Displacement and Confirmation
		/// </remarks>
		public static class RecordPrefix
		{
			/// <summary>First header char</summary>
			public const int Header0 = 0;
			/// <summary>Second header char</summary>
			public const int Header1 = Header0 + sizeof(char);
		}

		//********************************************************************************************************
		//		Sync message
		//********************************************************************************************************

		/// <summary>
		/// Sync message
		/// </summary>
		public static class Sync
		{
			/// <summary>Sync prefix</summary>
			private static readonly char[] Prefix = { '#', 's' };

			/// <summary>
			/// Buffer definition
			/// </summary>
			public static class BufferDef
			{
				/// <summary>The buffer</summary>
				public static byte[] Buffer = new byte[BuffSize];

				/// <summary>Buffer size</summary>
				public const int BuffSize = RecordPrefix.Header1 + sizeof(char);
			}

			/// <summary>
			/// Sync button is pressed
			/// </summary>
			public static void Sync_OnButtonPress(uint data1, uint data2, DateTime time)
			{
				BitConverter.InsertValueIntoArray(BufferDef.Buffer, RecordPrefix.Header0, Prefix[0]);
				BitConverter.InsertValueIntoArray(BufferDef.Buffer, RecordPrefix.Header1, Prefix[1]);

				GlobalItems.WriteDataRefAndUpdateCrc(BufferDef.Buffer);
			}
		}

		/// <summary>
		/// Raw sample
		/// </summary>
		public static class RawSample
		{
			/// <summary>
			/// Logging options
			/// </summary>
			public enum CollectionOptions
			{
				/// <summary>No logging</summary>
				None,
				/// <summary>Log sample only</summary>
				RawSampleOnly,
				/// <summary>Log sample and analysis</summary>
				RawSampleAndAnalysis,
			}

			/// <summary>User's log-to choice for sample</summary>
			public static CollectionOptions CollectionType = CollectionOptions.None;

			/// <summary>Output options for sample</summary>
			public static class OutOpt
			{
				/// <summary>Print immediately while sampling</summary>
				public static int SampleAndPrint = -1;
				/// <summary>Log to DataStore and output later to SD</summary>
				public static bool LogToSD;
				/// <summary>Log to DataStore and output later to print</summary>
				public static int LogToPrint = -1;
			}

			/// <summary>
			/// Print output options
			/// </summary>
			public static void PrintOutputOptions()
			{
				Debug.Print("Raw Sample ");
				Debug.Print("\tCollection Option: " +
					(CollectionType == CollectionOptions.None ? "None" :
					(CollectionType == CollectionOptions.RawSampleOnly ? "Raw Sample Only" :
					"Raw Sample and Analysis")));
				if (CollectionType == CollectionOptions.None)
				{
					return;
				}
				Debug.Print("\tSample and print: " + OutOpt.SampleAndPrint);
				Debug.Print("\tLog to SD: " + OutOpt.LogToSD);
				Debug.Print("\tLog and print: " + OutOpt.LogToPrint);
			}

			//********************************************************************************************************
			//		Raw sample only
			//********************************************************************************************************

			/// <summary>
			/// Raw sample
			/// </summary>
			public static class RawSampleOnly
			{
				/// <summary>Sample values and cut detection (Prefix, Raw.I, Sample.Q)</summary>
				private static readonly char[] Prefix = { '#', 'r' };

				/// <summary>
				/// Raw sample buffer
				/// </summary>
				/// <remarks>Items stored: prefix, raw I value, raw Q value</remarks>
				public class BufferDef
				{
					/// <summary>The buffer</summary>
					public static byte[] Buffer = new byte[BuffSize];

					/// <summary>Raw I position</summary>
					public const int RawI = RecordPrefix.Header1 + sizeof(char);
					/// <summary>Raw Q position</summary>
					public const int RawQ = RawI + sizeof(ushort);

					/// <summary>Buffer size</summary>
					public const int BuffSize = RawQ + sizeof(ushort);
				}

				/// <summary>
				/// Print header
				/// </summary>
				public static void PrintHeader()
				{
					Debug.Print("Raw Sample buffer size is " + BufferDef.BuffSize + " bytes");
					Debug.Print(new string(FieldNamesHeader) + "\tRawI\tRawQ");
				}

				/// <summary>
				/// Print vals after logging
				/// </summary>
				/// <param name="buffer"></param>
				public static void PrintVals(byte[] buffer)
				{
					if (!(OutOpt.LogToPrint < 0 || _recordsPrinted1 < OutOpt.LogToPrint))
					{
						return;
					}
					var header0 = BitConverter.ToChar(buffer, RecordPrefix.Header0);
					var header1 = BitConverter.ToChar(buffer, RecordPrefix.Header1);

					if (header0 != Prefix[0] ||
						header1 != Prefix[1])
					{
						return;
					}

					var rawI = BitConverter.ToUInt16(buffer, BufferDef.RawI);
					var rawQ = BitConverter.ToUInt16(buffer, BufferDef.RawQ);
					// Explicitly convert header0 to string else will sum header0 and header1 to int and then convert the number to string
					Debug.Print(header0.ToString() + header1
								+ "\t" + rawI
								+ "\t" + rawQ);
					_recordsPrinted1++;
				}
				private static int _recordsPrinted1;

				/// <summary>
				/// Log raw sample
				/// </summary>
				/// <param name="rawSample"></param>
				public static void Log(GlobalItems.Sample rawSample)
				{
					if (!(CollectionType == CollectionOptions.RawSampleOnly && (OutOpt.LogToPrint != 0 || SnippetDispAndConf.OutOpt.LogToSD)))
					{
						return;
					}
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						RecordPrefix.Header0, Prefix[0]);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						RecordPrefix.Header1, Prefix[1]);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						BufferDef.RawI, (ushort)rawSample.I);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						BufferDef.RawQ, (ushort)rawSample.Q);

					GlobalItems.WriteDataRefAndUpdateCrc(BufferDef.Buffer);
					_recordsPrinted2++;
				}
				// ReSharper disable once NotAccessedField.Local
				private static int _recordsPrinted2;

				///// <summary>
				///// Write to SD card
				///// </summary>
				///// <param name="buffer"></param>
				///// <param name="refsRead"></param>
				//public static void WriteToSd(byte[] buffer, int refsRead)
				//{
				//	var header0 = BitConverter.ToChar(buffer, RecordPrefix.Header0);
				//	var header1 = BitConverter.ToChar(buffer, RecordPrefix.Header1);

				//	if (header0 != Prefix[0] ||
				//		header1 != Prefix[1])
				//	{
				//		return;
				//	}

				//	// Write raw sample to SD
				//	GlobalItems.SDBufferedWrite.Write(buffer, 0, BufferDef.BuffSize);

				//	// Print
				//	if (!LogToPrint || refsRead >= 10)
				//	{
				//		return;
				//	}
				//	PrintVals(buffer);
				//}
			}

			//********************************************************************************************************
			//		Raw sample and analysis
			//********************************************************************************************************

			/// <summary>
			/// Log raw + analysis
			/// </summary>
			/// <remarks>Items stored: SampleNum (int), RawI, RawQ (both short), SampleI, SampleQ (both int), IsCut, IsDisplacement, IsConf (all bool)</remarks>
			public static class RawSampleAndAnalysis
			{
				/// <summary>Sample values and cut detection (Prefix, Raw.I, Sample.Q)</summary>
				private static readonly char[] Prefix = { '#', 'e' };

				/// <summary>
				/// Raw everything buffer
				/// </summary>
				public static class BufferDef
				{
					/// <summary>The buffer</summary>
					public static byte[] Buffer = new byte[BuffSize];

					/// <summary>Buffer position</summary>
					public const int SampleNum = RecordPrefix.Header1 + sizeof(char);
					/// <summary>Buffer position</summary>
					public const int SumI = SampleNum + sizeof(int);
					/// <summary>Buffer position</summary>
					public const int SumQ = SumI + sizeof(long);
					/// <summary>Buffer position</summary>
					public const int RawI = SumQ + sizeof(long);	// Last position + size of last item
					/// <summary>Buffer position</summary>
					public const int RawQ = RawI + sizeof(ushort);
					/// <summary>Buffer position</summary>
					public const int SampleI = RawQ + sizeof(ushort);
					/// <summary>Buffer position</summary>
					public const int SampleQ = SampleI + sizeof(short);
					/// <summary>Buffer position</summary>
					public const int IsCut = SampleQ + sizeof(short);
					/// <summary>Buffer position</summary>
					public const int IsDisplacement = IsCut + sizeof(short);
					/// <summary>Buffer position</summary>
					public const int IsConf = IsDisplacement + sizeof(bool);

					/// <summary>Buffer size</summary>
					public const int BuffSize = IsConf + sizeof(bool);
				}

				/// <summary>
				/// Print header
				/// </summary>
				public static void PrintHeader()
				{
					Debug.Print("Raw Everything buffer size is " + BufferDef.BuffSize + " bytes");
					Debug.Print(new string(FieldNamesHeader) + "\tSampleNum\tSumI\tSumQ\tRawI\tRawQ\tSampleI\tSampleQ\tIsCut\tIsDisplacement\tIsConf");
				}

				/// <summary>
				/// Print raw everything after logging
				/// </summary>
				/// <param name="buffer"></param>
				public static void PrintVals(byte[] buffer)
				{
					if (!(OutOpt.SampleAndPrint < 0 || _recordsPrinted1 < OutOpt.SampleAndPrint))
					{
						return;
					}
					var header0 = BitConverter.ToChar(buffer, RecordPrefix.Header0);
					var header1 = BitConverter.ToChar(buffer, RecordPrefix.Header1);

					if (header0 != Prefix[0] ||
						header1 != Prefix[1])
					{
						return;
					}

					var sampleNum = BitConverter.ToInt32(buffer, BufferDef.SampleNum);
					var sumI = BitConverter.ToInt64(buffer, BufferDef.SumI);
					var sumQ = BitConverter.ToInt64(buffer, BufferDef.SumQ);
					var rawI = BitConverter.ToUInt16(buffer, BufferDef.RawI);
					var rawQ = BitConverter.ToUInt16(buffer, BufferDef.RawQ);
					var sampleI = BitConverter.ToInt16(buffer, BufferDef.SampleI);
					var sampleQ = BitConverter.ToInt16(buffer, BufferDef.SampleQ);
					var isCut = BitConverter.ToInt16(buffer, BufferDef.IsCut);
					var isDisplacement = BitConverter.ToBoolean(buffer, BufferDef.IsDisplacement);
					var isConf = BitConverter.ToBoolean(buffer, BufferDef.IsConf);

					// Explicitly convert header0 to string else will sum header0 and header1 to int and then convert the number to string
					Debug.Print(header0.ToString() + header1
								+ "\t" + sampleNum
								+ "\t" + sumI
								+ "\t" + sumQ
								+ "\t" + rawI
								+ "\t" + rawQ
								+ "\t" + sampleI
								+ "\t" + sampleQ
								+ "\t" + isCut
								+ "\t" + isDisplacement
								+ "\t" + isConf);
					_recordsPrinted1++;
				}

				private static int _recordsPrinted1;

				/// <summary>
				/// Log Raw Everything
				/// </summary>
				/// <param name="sampleNum"></param>
				/// <param name="sumVals"></param>
				/// <param name="rawSample"></param>
				/// <param name="compSample"></param>
				/// <param name="isCut"></param>
				/// <param name="isDisplacement"></param>
				/// <param name="isConfirmed"></param>
				public static void Log(int sampleNum, GlobalItems.Sample sumVals, GlobalItems.Sample rawSample, GlobalItems.Sample compSample, int isCut, bool isDisplacement, bool isConfirmed)
				{
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						RecordPrefix.Header0, Prefix[0]);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						RecordPrefix.Header1, Prefix[1]);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						BufferDef.SampleNum, sampleNum);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						BufferDef.SumI, sumVals.I);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						BufferDef.SumQ, sumVals.Q);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						BufferDef.RawI, (ushort)rawSample.I);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						BufferDef.RawQ, (ushort)rawSample.Q);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						BufferDef.SampleI, (short)compSample.I);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						BufferDef.SampleQ, (short)compSample.Q);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						BufferDef.IsCut, (short)isCut);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						BufferDef.IsDisplacement, isDisplacement);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						BufferDef.IsConf, isConfirmed);

					GlobalItems.WriteDataRefAndUpdateCrc(BufferDef.Buffer);
				}

				///// <summary>
				///// Write to SD card
				///// </summary>
				///// <param name="buffer"></param>
				///// <param name="refsRead"></param>
				//public static void WriteToSd(byte[] buffer, int refsRead)
				//{
				//	// Write everything of interest to SD
				//	GlobalItems.SDBufferedWrite.Write(buffer, 0, BufferDef.BuffSize);

				//	// Print
				//	if (!LogToPrint || refsRead >= 10)
				//	{
				//		return;
				//	}
				//	PrintVals(buffer);
				//}

			}
		}



		//********************************************************************************************************
		//		Sample and cut
		//********************************************************************************************************

		/// <summary>
		/// Sample and cut
		/// </summary>
		public static class SampleAndCut
		{
			/// <summary>Sample values and cut detection (SampleNum, Sample.I, Sample.Q, IsCut)</summary>
			public static char[] Prefix = { '#', 'b' };

			/// <summary>Collection options</summary>
			public enum CollectionOptions
			{
				/// <summary>Sample and cut</summary>
				Sample,
				/// <summary>None</summary>
				None,
			}

			/// <summary>Collection type</summary>
			public static CollectionOptions CollectionType = CollectionOptions.None;

			/// <summary>Options for sample-level</summary>
			public static class OutOpt
			{
				/// <summary>Print immediately to Debug</summary>
				public static int SampleAndPrint;
				/// <summary>Log to DataStore and output later to Debug</summary>
				public static int LogToPrint;
				/// <summary>Log to DataStore and output later to SD</summary>
				public static bool LogToSD;
			}

			/// <summary>
			/// Print output options
			/// </summary>
			public static void PrintOutputOptions()
			{
				Debug.Print("Sample and Analysis");
				Debug.Print("\tCollection Option: " +
					(CollectionType == CollectionOptions.None ? "None" : "Sample and Analysis"));
				if (CollectionType == CollectionOptions.None)
				{
					return;
				}
				Debug.Print("\tSample and print: " + OutOpt.SampleAndPrint);
				Debug.Print("\tLog to SD: " + OutOpt.LogToSD);
				Debug.Print("\tLog and print: " + OutOpt.LogToPrint);
			}

			/// <summary>
			/// Byte array for samples and cuts
			/// </summary>
			/// <remarks>Items stored: Header (2 char), Sample Number (int), I value (short), Q value (short), IsCut (short)</remarks>
			public static class BuffDef
			{
				/// <summary>The buffer</summary>
				public static byte[] Buffer = new byte[BuffSize];
				/// <summary>Buffer position</summary>
				public const int SampleNum = RecordPrefix.Header1 + sizeof(char);
				/// <summary>Buffer position</summary>
				public const int SampleI = SampleNum + sizeof(int);
				/// <summary>Buffer position</summary>
				public const int SampleQ = SampleI + sizeof(short);
				/// <summary>Buffer position</summary>
				public const int IsCut = SampleQ + sizeof(short);

				/// <summary>Buffer size</summary>
				public const int BuffSize = IsCut + sizeof(short);
			}

			/// <summary>
			/// Print header
			/// </summary>
			public static void PrintHeader()
			{
				Debug.Print(new string(FieldNamesHeader) + "\tSampleNum\tSample.I\tSample.Q\tIsCut");
			}

			/// <summary>
			/// Print sample and cut during displacement analysis
			/// </summary>
			/// <param name="sample"></param>
			/// <param name="isCut"></param>
			public static void PrintVals(GlobalItems.Sample sample, int isCut)
			{
				if (!(OutOpt.SampleAndPrint < 0 || _recordsPrinted1 < OutOpt.SampleAndPrint))
				{
					return;
				}

				var statusStr = new string(Prefix) +
								"\t" + sample.I +
								"\t" + sample.Q +
								"\t" + isCut;
				Debug.Print(statusStr);
				_recordsPrinted1++;
			}
			private static int _recordsPrinted1;

			/// <summary>
			/// Print sample and cut after logging
			/// </summary>
			/// <param name="buffer"></param>
			public static void PrintVals(byte[] buffer)
			{
				if (!(OutOpt.LogToPrint < 0 || _recordsPrinted2 < OutOpt.LogToPrint))
				{
					return;
				}

				var header0 = BitConverter.ToChar(buffer, RecordPrefix.Header0);
				var header1 = BitConverter.ToChar(buffer, RecordPrefix.Header1);

				if (header0 != Prefix[0] ||
					header1 != Prefix[1])
				{
					return;
				}
				var sampleNum = BitConverter.ToInt32(buffer, BuffDef.SampleNum);
				var sampleI = BitConverter.ToInt16(buffer, BuffDef.SampleI);
				var sampleQ = BitConverter.ToInt16(buffer, BuffDef.SampleQ);
				var isCut = BitConverter.ToInt16(buffer, BuffDef.IsCut);

				Debug.Print(
					new string(Prefix)
					+ "\t" + sampleNum
					+ "\t" + sampleI
					+ "\t" + sampleQ
					+ "\t" + isCut
					);
				_recordsPrinted2++;
			}
			private static int _recordsPrinted2;

			/// <summary>
			/// Log sample and cut
			/// </summary>
			/// <param name="sampleNum"></param>
			/// <param name="sample"></param>
			/// <param name="isCut"></param>
			public static void Log(int sampleNum, GlobalItems.Sample sample, int isCut)
			{
				if (!(CollectionType == CollectionOptions.Sample && (OutOpt.LogToPrint != 0 || OutOpt.LogToSD)))
				{
					return;
				}
				BitConverter.InsertValueIntoArray(BuffDef.Buffer,
					RecordPrefix.Header0, Prefix[0]);
				BitConverter.InsertValueIntoArray(BuffDef.Buffer,
					RecordPrefix.Header1, Prefix[1]);
				BitConverter.InsertValueIntoArray(BuffDef.Buffer,
					BuffDef.SampleNum, sampleNum);
				BitConverter.InsertValueIntoArray(BuffDef.Buffer,
					BuffDef.SampleI, (short)sample.I);
				BitConverter.InsertValueIntoArray(BuffDef.Buffer,
					BuffDef.SampleQ, (short)sample.Q);
				BitConverter.InsertValueIntoArray(BuffDef.Buffer,
					BuffDef.IsCut, (short)isCut);

				GlobalItems.WriteDataRefAndUpdateCrc(BuffDef.Buffer);
			}
		}

		//********************************************************************************************************
		//		Snippet displacement and confirmation
		//********************************************************************************************************

		/// <summary>
		/// Snippet displacement and confirmation
		/// </summary>
		public static class SnippetDispAndConf
		{
			/// <summary>Snippet detections (sample num, IsDisplacement, IsConf) chars</summary>
			private static readonly char[] Prefix = { '#', 'd' };

			/// <summary>Collection options</summary>
			public enum CollectionOptions
			{
				/// <summary>Snippet displacement and confirmation</summary>
				Snippet,
				/// <summary>None</summary>
				None,
			}

			/// <summary>Collection type</summary>
			public static CollectionOptions CollectionType = CollectionOptions.None;

			/// <summary>Options for snippet-level</summary>
			public static class OutOpt
			{
				/// <summary>Print immediately to Debug</summary>
				public static int SampleAndPrint;
				/// <summary>Log to DataStore and output later to Debug</summary>
				public static int LogToPrint;
				/// <summary>Log to DataStore and output later to SD</summary>
				public static bool LogToSD;
			}

			/// <summary>
			/// Print output options
			/// </summary>
			public static void PrintOutputOptions()
			{
				Debug.Print("Snippet Displacement and Confirmation");
				Debug.Print("\tCollection Option: " +
					(CollectionType == CollectionOptions.None ? "None" : "Displacement and Confirmation"));
				if (CollectionType == CollectionOptions.None)
				{
					return;
				}
				Debug.Print("\tSample and print: " + OutOpt.SampleAndPrint);
				Debug.Print("\tLog to SD: " + OutOpt.LogToSD);
				Debug.Print("\tLog and print: " + OutOpt.LogToPrint);
			}


			/// <summary>
			/// Byte array for snippet
			/// </summary>
			/// <remarks>
			/// Items stored: Header (2 char), Sample Number (int), CumCuts (int), IsDisp (bool), IsConfirmed (bool)
			/// </remarks>
			public static class BuffDef
			{
				/// <summary>The Buffer</summary>
				public static byte[] Buffer = new byte[BuffSize];
				/// <summary>Buffer position</summary>
				public const int SampleNum = RecordPrefix.Header1 + sizeof(char);
				/// <summary>Buffer position</summary>
				public const int CumCuts = SampleNum + sizeof(int);
				/// <summary>Buffer position</summary>
				public const int IsDisp = CumCuts + sizeof(int);
				/// <summary>Buffer position</summary>
				public const int IsConfirmed = IsDisp + sizeof(bool);

				/// <summary>Buffer size</summary>
				public const int BuffSize = IsConfirmed + sizeof(bool);
			}

			/// <summary>
			/// Print header
			/// </summary>
			public static void PrintHeader()
			{
				Debug.Print(new string(FieldNamesHeader) + "\tSampleNum\tCumCuts\tIsDisp\tIsConf");
			}

			/// <summary>
			/// Print snippet displacement and confirmation during detection
			/// </summary>
			/// <param name="snippetNum"></param>
			/// <param name="cumCuts"></param>
			/// <param name="isDisplacement"></param>
			/// <param name="isConfirmed"></param>
			public static void PrintVals(int snippetNum, int cumCuts, bool isDisplacement, bool isConfirmed)
			{
				if (!(OutOpt.SampleAndPrint < 0 || _recordsPrinted1 < OutOpt.SampleAndPrint))
				{
					return;
				}
				var statusStr =
					new string(Prefix)
					+ "\t" + snippetNum
					+ "\t" + cumCuts
					+ "\t" + isDisplacement
					+ "\t" + isConfirmed
					;
				Debug.Print(statusStr);
				_recordsPrinted1++;
			}
			private static int _recordsPrinted1;

			/// <summary>
			/// Print snippet displacement and confirmation after logging
			/// </summary>
			/// <param name="buffer"></param>
			public static void PrintVals(byte[] buffer)
			{
				if (!(OutOpt.LogToPrint < 0 || _recordsPrinted2 < OutOpt.LogToPrint))
				{
					return;
				}
				var header0 = BitConverter.ToChar(buffer, RecordPrefix.Header0);
				var header1 = BitConverter.ToChar(buffer, RecordPrefix.Header1);

				if (header0 != Prefix[0] ||
					header1 != Prefix[1])
				{
					return;
				}
				var sampleNum = BitConverter.ToInt32(buffer, BuffDef.SampleNum);
				var cumCuts = BitConverter.ToInt32(buffer, BuffDef.CumCuts);
				var isDisp = BitConverter.ToBoolean(buffer, BuffDef.IsDisp);
				var isConfirmed = BitConverter.ToBoolean(buffer, BuffDef.IsConfirmed);

				Debug.Print(
					new string(Prefix)
					+ "\t" + sampleNum
					+ "\t" + cumCuts
					+ "\t" + isDisp
					+ "\t" + isConfirmed
					);
				_recordsPrinted2++;
			}
			private static int _recordsPrinted2;

			/// <summary>
			/// Log snippet displacement and confirmation
			/// </summary>
			public static void Log(int sampleNum, int cumCuts, bool isDisplacement, bool isConfirmed)
			{
				BitConverter.InsertValueIntoArray(BuffDef.Buffer,
					RecordPrefix.Header0, Prefix[0]);
				BitConverter.InsertValueIntoArray(BuffDef.Buffer,
					RecordPrefix.Header1, Prefix[1]);
				BitConverter.InsertValueIntoArray(BuffDef.Buffer,
					BuffDef.SampleNum, sampleNum);

				BitConverter.InsertValueIntoArray(BuffDef.Buffer,
					BuffDef.CumCuts, cumCuts);

				BitConverter.InsertValueIntoArray(BuffDef.Buffer,
					BuffDef.IsDisp, isDisplacement);
				BitConverter.InsertValueIntoArray(BuffDef.Buffer,
					BuffDef.IsConfirmed, isConfirmed);

				GlobalItems.WriteDataRefAndUpdateCrc(BuffDef.Buffer);
			}
		}
	}
}
