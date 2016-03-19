using System;
using System.Text;
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
			public const int Header1 = Header0 + sizeof(byte);
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
			//private static readonly char[] Prefix = { '#', 's' };
			private static readonly byte[] Prefix = { 0x23, 0x73 };

			/// <summary>
			/// Buffer definition
			/// </summary>
			public static class BuffDef
			{
				/// <summary>The buffer</summary>
				public static byte[] Buffer = new byte[BuffSize];

				/// <summary>Buffer size</summary>
				public const int BuffSize = RecordPrefix.Header1 + sizeof(byte);
			}

			/// <summary>
			/// Sync button is pressed
			/// </summary>
			public static void Sync_OnButtonPress(uint data1, uint data2, DateTime time)
			{
				//BitConverter.InsertValueIntoArray(BuffDef.Buffer, RecordPrefix.Header0, Prefix[0]);
				//BitConverter.InsertValueIntoArray(BuffDef.Buffer, RecordPrefix.Header1, Prefix[1]);
				BuffDef.Buffer[RecordPrefix.Header0] = Prefix[0];
				BuffDef.Buffer[RecordPrefix.Header1] = Prefix[1];

				GlobalItems.WriteDataRefAndUpdateCrc(BuffDef.Buffer);
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
				private static byte[] _prefix;
				private const string PrefixStr = "#r";

				/// <summary>
				/// Initialize the prefix
				/// </summary>
				public static void InitPrefix()
				{
					_prefix = Encoding.UTF8.GetBytes(PrefixStr);
				}


				/// <summary>
				/// Raw sample buffer
				/// </summary>
				/// <remarks>Items stored: prefix, raw I value, raw Q value</remarks>
				public class BuffDef
				{
					/// <summary>The buffer</summary>
					public static byte[] Buffer = new byte[BuffSize];

					/// <summary>Raw I position</summary>
					public const int RawI = RecordPrefix.Header1 + sizeof(byte);
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
					Debug.Print("Raw Sample buffer size is " + BuffDef.BuffSize + " bytes");
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
					//var header0 = BitConverter.ToChar(buffer, RecordPrefix.Header0);
					//var header1 = BitConverter.ToChar(buffer, RecordPrefix.Header1);

					if (buffer[RecordPrefix.Header0]!= _prefix[0] ||
						buffer[RecordPrefix.Header1] != _prefix[1])
					{
						return;
					}

					var rawI = BitConverter.ToUInt16(buffer, BuffDef.RawI);
					var rawQ = BitConverter.ToUInt16(buffer, BuffDef.RawQ);

					Debug.Print(PrefixStr
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
					//BitConverter.InsertValueIntoArray(BuffDef.Buffer,
					//	RecordPrefix.Header0, _prefix[0]);
					//BitConverter.InsertValueIntoArray(BuffDef.Buffer,
					//	RecordPrefix.Header1, _prefix[1]);
					BuffDef.Buffer[RecordPrefix.Header0] = _prefix[0];
					BuffDef.Buffer[RecordPrefix.Header1] = _prefix[1];
					BitConverter.InsertValueIntoArray(BuffDef.Buffer,
						BuffDef.RawI, (ushort)rawSample.I);
					BitConverter.InsertValueIntoArray(BuffDef.Buffer,
						BuffDef.RawQ, (ushort)rawSample.Q);

					GlobalItems.WriteDataRefAndUpdateCrc(BuffDef.Buffer);
					_recordsPrinted2++;
				}
				// ReSharper disable once NotAccessedField.Local
				private static int _recordsPrinted2;

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
				private static byte[] _prefix;
				private const string PrefixStr = "#e";

				/// <summary>
				/// Initialize the prefix
				/// </summary>
				public static void InitPrefix()
				{
					_prefix = Encoding.UTF8.GetBytes(PrefixStr);
				}

				/// <summary>
				/// Raw everything buffer
				/// </summary>
				public static class BuffDef
				{
					/// <summary>The buffer</summary>
					public static byte[] Buffer = new byte[BuffSize];

					/// <summary>Buffer position</summary>
					public const int SampleNum = RecordPrefix.Header1 + sizeof(byte);
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
					Debug.Print("Raw Everything buffer size is " + BuffDef.BuffSize + " bytes");
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
					//var header0 = BitConverter.ToChar(buffer, RecordPrefix.Header0);
					//var header1 = BitConverter.ToChar(buffer, RecordPrefix.Header1);

					if (buffer[RecordPrefix.Header0] != _prefix[0] ||
						buffer[RecordPrefix.Header1] != _prefix[1])
					{
						return;
					}

					var sampleNum = BitConverter.ToInt32(buffer, BuffDef.SampleNum);
					var sumI = BitConverter.ToInt64(buffer, BuffDef.SumI);
					var sumQ = BitConverter.ToInt64(buffer, BuffDef.SumQ);
					var rawI = BitConverter.ToUInt16(buffer, BuffDef.RawI);
					var rawQ = BitConverter.ToUInt16(buffer, BuffDef.RawQ);
					var sampleI = BitConverter.ToInt16(buffer, BuffDef.SampleI);
					var sampleQ = BitConverter.ToInt16(buffer, BuffDef.SampleQ);
					var isCut = BitConverter.ToInt16(buffer, BuffDef.IsCut);
					var isDisplacement = BitConverter.ToBoolean(buffer, BuffDef.IsDisplacement);
					var isConf = BitConverter.ToBoolean(buffer, BuffDef.IsConf);

					// Explicitly convert header0 to string else will sum header0 and header1 to int and then convert the number to string
					Debug.Print(PrefixStr
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
					//BitConverter.InsertValueIntoArray(BuffDef.Buffer,
					//	RecordPrefix.Header0, _prefix[0]);
					//BitConverter.InsertValueIntoArray(BuffDef.Buffer,
					//	RecordPrefix.Header1, _prefix[1]);
					BuffDef.Buffer[RecordPrefix.Header0] = _prefix[0];
					BuffDef.Buffer[RecordPrefix.Header1] = _prefix[1];
					BitConverter.InsertValueIntoArray(BuffDef.Buffer,
						BuffDef.SampleNum, sampleNum);
					BitConverter.InsertValueIntoArray(BuffDef.Buffer,
						BuffDef.SumI, sumVals.I);
					BitConverter.InsertValueIntoArray(BuffDef.Buffer,
						BuffDef.SumQ, sumVals.Q);
					BitConverter.InsertValueIntoArray(BuffDef.Buffer,
						BuffDef.RawI, (ushort)rawSample.I);
					BitConverter.InsertValueIntoArray(BuffDef.Buffer,
						BuffDef.RawQ, (ushort)rawSample.Q);
					BitConverter.InsertValueIntoArray(BuffDef.Buffer,
						BuffDef.SampleI, (short)compSample.I);
					BitConverter.InsertValueIntoArray(BuffDef.Buffer,
						BuffDef.SampleQ, (short)compSample.Q);
					BitConverter.InsertValueIntoArray(BuffDef.Buffer,
						BuffDef.IsCut, (short)isCut);
					BitConverter.InsertValueIntoArray(BuffDef.Buffer,
						BuffDef.IsDisplacement, isDisplacement);
					BitConverter.InsertValueIntoArray(BuffDef.Buffer,
						BuffDef.IsConf, isConfirmed);

					GlobalItems.WriteDataRefAndUpdateCrc(BuffDef.Buffer);
				}
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
			//public static char[] Prefix = { '#', 'b' };
			//public static byte[] Prefix = { 0x23, 0x62 };

			private static byte[] _prefix;
			/// <summary>Sample values and cut detection (SampleNum, Sample.I, Sample.Q, IsCut)</summary>private static byte[] _prefix;
			private const string PrefixStr = "#b";

			/// <summary>
			/// Initialize the prefix
			/// </summary>
			public static void InitPrefix()
			{
				_prefix = Encoding.UTF8.GetBytes(PrefixStr);
			}


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
				public const int SampleNum = RecordPrefix.Header1 + sizeof(byte);
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

				var statusStr = PrefixStr
								+ "\t" + sample.I
								+ "\t" + sample.Q
								+ "\t" + isCut;
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

				//var header0 = BitConverter.ToChar(buffer, RecordPrefix.Header0);
				//var header1 = BitConverter.ToChar(buffer, RecordPrefix.Header1);

				if (buffer[RecordPrefix.Header0]!= _prefix[0] ||
					buffer[RecordPrefix.Header1]!= _prefix[1])
				{
					return;
				}
				var sampleNum = BitConverter.ToInt32(buffer, BuffDef.SampleNum);
				var sampleI = BitConverter.ToInt16(buffer, BuffDef.SampleI);
				var sampleQ = BitConverter.ToInt16(buffer, BuffDef.SampleQ);
				var isCut = BitConverter.ToInt16(buffer, BuffDef.IsCut);

				Debug.Print(
					PrefixStr
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
				//BitConverter.InsertValueIntoArray(BuffDef.Buffer,
				//	RecordPrefix.Header0, _prefix[0]);
				//BitConverter.InsertValueIntoArray(BuffDef.Buffer,
				//	RecordPrefix.Header1, _prefix[1]);
				BuffDef.Buffer[RecordPrefix.Header0] = _prefix[0];
				BuffDef.Buffer[RecordPrefix.Header1] = _prefix[1];
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
			private static byte[] _prefix;
			private const string PrefixStr = "#d";

			/// <summary>
			/// Initialize the prefix
			/// </summary>
			public static void InitPrefix()
			{
				_prefix = Encoding.UTF8.GetBytes(PrefixStr);
			}

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
				public const int SampleNum = RecordPrefix.Header1 + sizeof(byte);
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
				Debug.Print(new string(FieldNamesHeader) + "\tSnippet\tCumCuts\tIsDisp\tIsConf");
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
					new string(Encoding.UTF8.GetChars(_prefix))
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
				//var header0 = BitConverter.ToChar(buffer, RecordPrefix.Header0);
				//var header1 = BitConverter.ToChar(buffer, RecordPrefix.Header1);

				if (buffer[RecordPrefix.Header0] != _prefix[0] ||
					buffer[RecordPrefix.Header1] != _prefix[1])
				{
					return;
				}
				var sampleNum = BitConverter.ToInt32(buffer, BuffDef.SampleNum);
				var cumCuts = BitConverter.ToInt32(buffer, BuffDef.CumCuts);
				var isDisp = BitConverter.ToBoolean(buffer, BuffDef.IsDisp);
				var isConfirmed = BitConverter.ToBoolean(buffer, BuffDef.IsConfirmed);

				Debug.Print(
					new string(Encoding.UTF8.GetChars(_prefix))
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
				//BitConverter.InsertValueIntoArray(BuffDef.Buffer,
				//	RecordPrefix.Header0, _prefix[0]);
				//BitConverter.InsertValueIntoArray(BuffDef.Buffer,
				//	RecordPrefix.Header1, _prefix[1]);
				BuffDef.Buffer[RecordPrefix.Header0] = _prefix[0];
				BuffDef.Buffer[RecordPrefix.Header1] = _prefix[1];
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
