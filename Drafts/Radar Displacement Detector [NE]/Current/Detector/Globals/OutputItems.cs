using System;
using System.Text;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;
using Samraksh.Appnote.Utility;
using Samraksh.eMote.NonVolatileMemory;

namespace Samraksh.AppNote.Samraksh.AppNote.DotNow.Radar
{
	/// <summary>
	/// Output items
	/// </summary>
	public static class OutputItems
	{
		/// <summary>
		/// DataStore object
		/// </summary>
		public static readonly DataStore DataStore = DataStore.Instance(StorageType.NOR, true);

		/// <summary>Options true iff logging</summary>
		public static bool LoggingRequired;

		/// <summary>Print after logging</summary>
		public static bool PrintAfterRawLogging;

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
				InsertValueIntoArray.Insert(BufferDef.Buffer,
					RecordPrefix.Header0, Prefix[0]);
				InsertValueIntoArray.Insert(BufferDef.Buffer,
					RecordPrefix.Header1, Prefix[1]);

				

				Globals.WriteDataRefAndUpdateCrc(BufferDef.Buffer);

			}
		}

		//********************************************************************************************************
		//		Raw sample
		//********************************************************************************************************

		/// <summary>
		/// Raw sample
		/// </summary>
		public static class RawSample
		{
			/// <summary>Sample values and cut detection (Prefix, Raw.I, Raw.Q)</summary>
			private static readonly char[] Prefix = { '#', 'r' };

			/// <summary>Output options for raw sample</summary>
			public static class Opt
			{
				/// <summary>Log to DataStore and output later to SD</summary>
				public static bool LogRawSampleToSD;
				///// <summary>Log to DataStore and output later to SD and print</summary>
				//public static bool LogRawSampleToSDAndPrint;
				/// <summary>Logging is required</summary>
				public static bool Logging;
			}

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
			private static void PrintVals(byte[] buffer)
			{
				var header0 = BitConverter.ToChar(buffer, RecordPrefix.Header0);
				var header1 = BitConverter.ToChar(buffer, RecordPrefix.Header1);
				var rawI = BitConverter.ToUInt16(buffer, BufferDef.RawI);
				var rawQ = BitConverter.ToUInt16(buffer, BufferDef.RawQ);
				// Explicitly convert header0 to string else will sum header0 and header1 to int and then convert the number to string
				Debug.Print(header0.ToString() + header1
					+ "\t" + rawI
					+ "\t" + rawQ);
			}

			/// <summary>
			/// Log raw sample
			/// </summary>
			/// <param name="rawSample"></param>
			public static void Log(Globals.Sample rawSample)
			{
				InsertValueIntoArray.Insert(BufferDef.Buffer,
					RecordPrefix.Header0, Prefix[0]);
				InsertValueIntoArray.Insert(BufferDef.Buffer,
					RecordPrefix.Header1, Prefix[1]);
				InsertValueIntoArray.Insert(BufferDef.Buffer,
					BufferDef.RawI, (ushort)rawSample.I);
				InsertValueIntoArray.Insert(BufferDef.Buffer,
					BufferDef.RawQ, (ushort)rawSample.Q);

				Globals.WriteDataRefAndUpdateCrc(BufferDef.Buffer);
			}

			/// <summary>
			/// Write to SD card
			/// </summary>
			/// <param name="buffer"></param>
			/// <param name="refsRead"></param>
			public static void WriteToSd(byte[] buffer, int refsRead)
			{
				// Write raw sample to SD
				SdBufferedWrite.Write(buffer, 0, BufferDef.BuffSize);

				// Print
				if (!PrintAfterRawLogging || refsRead >= 10)
				{
					return;
				}
				PrintVals(buffer);
			}

		}

		//********************************************************************************************************
		//		Raw everything
		//********************************************************************************************************

		/// <summary>
		/// Raw everything buffer
		/// </summary>
		/// <remarks>Items stored: SampleNum (int), RawI, RawQ (both short), SampleI, SampleQ (both int), IsCut, IsDisplacement, IsConf (all bool)</remarks>
		public static class RawEverything
		{
			/// <summary>Sample values and cut detection (Prefix, Raw.I, Raw.Q)</summary>
			private static readonly char[] Prefix = { '#', 'e' };

			/// <summary>Output options for raw everything</summary>
			public static class Opt
			{
				/// <summary>Log to DataStore and output later to SD</summary>
				public static bool LogRawEverythingToSD;
				///// <summary>Log to DataStore and output later to SD and print</summary>
				//public static bool LogRawEverythingToSDAndPrint;
				/// <summary>Logging is required</summary>
				public static bool Logging;
			}
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
			private static void PrintVals(byte[] buffer)
			{
				var header0 = BitConverter.ToChar(buffer, RecordPrefix.Header0);
				var header1 = BitConverter.ToChar(buffer, RecordPrefix.Header1);
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
			}

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
			public static void Log(int sampleNum, Globals.Sample sumVals, Globals.Sample rawSample, Globals.Sample compSample, int isCut, bool isDisplacement, bool isConfirmed)
			{
				InsertValueIntoArray.Insert(BufferDef.Buffer,
					RecordPrefix.Header0, Prefix[0]);
				InsertValueIntoArray.Insert(BufferDef.Buffer,
					RecordPrefix.Header1, Prefix[1]);
				InsertValueIntoArray.Insert(BufferDef.Buffer,
					BufferDef.SampleNum, sampleNum);
				InsertValueIntoArray.Insert(BufferDef.Buffer,
					BufferDef.SumI, sumVals.I);
				InsertValueIntoArray.Insert(BufferDef.Buffer,
					BufferDef.SumQ, sumVals.Q);
				InsertValueIntoArray.Insert(BufferDef.Buffer,
					BufferDef.RawI, (ushort)rawSample.I);
				InsertValueIntoArray.Insert(BufferDef.Buffer,
					BufferDef.RawQ, (ushort)rawSample.Q);
				InsertValueIntoArray.Insert(BufferDef.Buffer,
					BufferDef.SampleI, (short)compSample.I);
				InsertValueIntoArray.Insert(BufferDef.Buffer,
					BufferDef.SampleQ, (short)compSample.Q);
				InsertValueIntoArray.Insert(BufferDef.Buffer,
					BufferDef.IsCut, (short)isCut);
				InsertValueIntoArray.Insert(BufferDef.Buffer,
					BufferDef.IsDisplacement, isDisplacement);
				InsertValueIntoArray.Insert(BufferDef.Buffer,
					BufferDef.IsConf, isConfirmed);

				Globals.WriteDataRefAndUpdateCrc(BufferDef.Buffer);
			}

			/// <summary>
			/// Write to SD card
			/// </summary>
			/// <param name="buffer"></param>
			/// <param name="refsRead"></param>
			public static void WriteToSd(byte[] buffer, int refsRead) {
				// Write everything of interest to SD
				SdBufferedWrite.Write(buffer, 0, BufferDef.BuffSize);

				// Print
				if (!PrintAfterRawLogging || refsRead >= 10)
				{
					return;
				}
				PrintVals(buffer);
			}

		}

		//********************************************************************************************************
		//		SampleAndCut
		//********************************************************************************************************

		/// <summary>
		/// ASCII Sample and cut
		/// </summary>
		public static class SampleAndCut
		{
			/// <summary>Sample values and cut detection (SampleNum, Sample.I, Sample.Q, IsCut)</summary>
			public static char[] Prefix = { '#', 'b' };

			/// <summary>Options for sample-level</summary>
			public static class Opt
			{
				/// <summary>Print immediately to Debug</summary>
				public static bool Print;
				/// <summary>Log to DataStore and output later to Debug</summary>
				public static bool LogToDebug;
				/// <summary>Log to DataStore and output later to SD</summary>
				public static bool LogToSD;
				/// <summary>Logging is required</summary>
				public static bool Logging;
			}

			/// <summary>
			/// Byte array for ASCII samples and cuts
			/// </summary>
			/// <remarks>Items stored: Header (2 char), Sample Number, I value, Q value (all int), IsCut (bool)</remarks>
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
			public static void PrintVals(Globals.Sample sample, int isCut)
			{
				var statusStr = new String(Prefix) +
								"\t" + sample.I +
								"\t" + sample.Q +
								"\t" + isCut;
				Debug.Print(statusStr);
			}


			/// <summary>
			/// Print sample and cut after logging
			/// </summary>
			/// <param name="buffer"></param>
			public static void PrintVals(byte[] buffer)
			{
				var header0 = BitConverter.ToChar(buffer, RecordPrefix.Header0);
				var header1 = BitConverter.ToChar(buffer, RecordPrefix.Header1);

				if (header0 != Prefix[0] ||
					header1 != Prefix[1])
				{
					return;
				}
				if (!Opt.Logging)
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
			}

			/// <summary>
			/// Log sample and cut
			/// </summary>
			/// <param name="sampleNum"></param>
			/// <param name="sample"></param>
			/// <param name="isCut"></param>
			public static void Log(int sampleNum, Globals.Sample sample, int isCut)
			{
				InsertValueIntoArray.Insert(BuffDef.Buffer,
					RecordPrefix.Header0, Prefix[0]);
				InsertValueIntoArray.Insert(BuffDef.Buffer,
					RecordPrefix.Header1, Prefix[1]);
				InsertValueIntoArray.Insert(BuffDef.Buffer,
					(int)BuffDef.SampleNum, sampleNum);
				InsertValueIntoArray.Insert(BuffDef.Buffer,
					(int)BuffDef.SampleI, (short)sample.I);
				InsertValueIntoArray.Insert(BuffDef.Buffer,
					(int)BuffDef.SampleQ, (short)sample.Q);
				InsertValueIntoArray.Insert(BuffDef.Buffer,
					BuffDef.IsCut, (short)isCut);

				Globals.WriteDataRefAndUpdateCrc(BuffDef.Buffer);
			}
		}

		//********************************************************************************************************
		//		ASCII snippet displacement and confirmation
		//********************************************************************************************************

		/// <summary>
		/// ASCII snippet displacement and confirmation
		/// </summary>
		public static class SnippetDispAndConf
		{
			/// <summary>Snippet detections (sample num, IsDisplacement, IsConf) chars</summary>
			private static readonly char[] Prefix = { '#', 'd' };

			/// <summary>Options for snippet-level</summary>
			public static class Opt
			{
				/// <summary>Print immediately to Debug</summary>
				public static bool Print;
				/// <summary>Log to DataStore and output later to Debug</summary>
				public static bool LogToDebug;
				/// <summary>Log to DataStore and output later to SD</summary>
				public static bool LogToSD;
				/// <summary>Logging is required</summary>
				public static bool Logging;
			}

			/// <summary>
			/// Byte array for ASCII snippet
			/// </summary>
			/// <remarks>
			/// Items stored: Header (2 char), Sample Number, CumCuts (both int), IsDisp, IsConfirmed (both bool)
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
				var statusStr =
					new string(Prefix)
					+ "\t" + snippetNum
					+ "\t" + cumCuts
					+ "\t" + isDisplacement
					+ "\t" + isConfirmed
					;
				Debug.Print(statusStr);
			}

			/// <summary>
			/// Print snippet displacement and confirmation after logging
			/// </summary>
			/// <param name="buffer"></param>
			public static void PrintVals(byte[] buffer)
			{
				var header0 = BitConverter.ToChar(buffer, RecordPrefix.Header0);
				var header1 = BitConverter.ToChar(buffer, RecordPrefix.Header1);

				if (header0 != Prefix[0] ||
					header1 != Prefix[1])
				{
					return;
				}
				if (!Opt.LogToDebug)
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
			}

			/// <summary>
			/// Log snippet displacement and confirmation
			/// </summary>
			public static void Log(int sampleNum, int cumCuts, bool isDisplacement, bool isConfirmed)
			{
				InsertValueIntoArray.Insert(BuffDef.Buffer,
					RecordPrefix.Header0, Prefix[0]);
				InsertValueIntoArray.Insert(BuffDef.Buffer,
					RecordPrefix.Header1, Prefix[1]);
				InsertValueIntoArray.Insert(BuffDef.Buffer,
					BuffDef.SampleNum, sampleNum);

				InsertValueIntoArray.Insert(BuffDef.Buffer,
					BuffDef.CumCuts, cumCuts);

				InsertValueIntoArray.Insert(BuffDef.Buffer,
					BuffDef.IsDisp, isDisplacement);
				InsertValueIntoArray.Insert(BuffDef.Buffer,
					BuffDef.IsConfirmed, isConfirmed);

				Globals.WriteDataRefAndUpdateCrc(BuffDef.Buffer);
			}
		}

		
	}
}
