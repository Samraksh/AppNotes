using System;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;
using Samraksh.eMote.Net.Mac;
using Samraksh.eMote.Net.Radio;
using Samraksh.eMote.NonVolatileMemory;

#if !(DotNow || Sam_Emulator)
#error Conditional build symbol missing
#endif

namespace Samraksh.AppNote.Samraksh.AppNote.DotNow.Radar
{
	/// <summary>
	/// Global values and parameters
	/// </summary>
	public class Globals {

		private static readonly object WriteLock = new object();

		/// <summary>
		/// Write the data reference and update the CRC
		/// </summary>
		/// <param name="buffer"></param>
		public static void WriteDataRefAndUpdateCrc(byte[] buffer)
		{
			// Prevent attempt to write from separate threads
			lock (WriteLock) {
				DataStoreReference = new DataReference(
					Out.DataStore,
					buffer.Length,
					ReferenceDataType.BYTE
					);
				DataStoreReference.Write(buffer);

				AllocationsWritten++;

				CrcWritten = Microsoft.SPOT.Hardware.Utility.ComputeCRC(
					buffer,
					0,
					buffer.Length,
					CrcWritten);
			}
		}

		/// <summary>
		/// Hold a sample pair
		/// </summary>
		public class Sample
		{
			/// <summary>
			/// Constructor
			/// </summary>
			public Sample() { }

			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="i"></param>
			/// <param name="q"></param>
			public Sample(int i, int q)
			{
				I = i;
				Q = q;
			}

			/// <summary>I value</summary>
			public int I;

			/// <summary>Q value</summary>
			public int Q;
		}
		/// <summary>
		/// Data store reference for writing
		/// </summary>
		public static DataReference DataStoreReference;

		/// <summary>
		/// User has signaled to stop sampling
		/// </summary>
		public static bool LoggingFinished = false;

		/// <summary>Crc for writing</summary>
		public static uint CrcWritten = 0;

		/// <summary>Allocations written</summary>
		public static int AllocationsWritten = 0;


		/// <summary>
		/// Radio Updates
		/// </summary>
		public static class RadioUpdates
		{
			/// <summary>Radio object</summary>
			public static SimpleCsmaRadio Radio;

			/// <summary>Radio channel to use</summary>
			public const Channels Channel = Channels.Channel_11;

			/// <summary>Whether or not to send radio updates</summary>
			public static bool EnableRadioUpdates = false;

			/// <summary>Prepended to each packet to identify the app</summary>
			public static char AppIdentifierHdr = 'D';

			/// <summary>
			/// Radio buffer definition
			/// </summary>
			public static class BufferDef
			{
				/// <summary>Radio buffer</summary>
				public static byte[] Buffer = new byte[BuffSize];

				/// <summary>Message type position</summary>
				public const int AppIdentifier = 0;
				/// <summary>Is Displacement? position</summary>
				public const int IsDisplacement = AppIdentifier + sizeof(char);
				/// <summary>Is Confirmed? position</summary>
				public const int IsConf = IsDisplacement + sizeof(bool);
				/// <summary>Buffer size</summary>
				public const int BuffSize = IsConf + sizeof(bool);
			}

			/// <summary>
			/// Send update message
			/// </summary>
			/// <param name="isDisplacement"></param>
			/// <param name="isConf"></param>
			public static void SnippetUpdate(bool isDisplacement, bool isConf)
			{
				BitConverter.InsertValueIntoArray(BufferDef.Buffer, BufferDef.AppIdentifier, AppIdentifierHdr);
				BitConverter.InsertValueIntoArray(BufferDef.Buffer, BufferDef.IsDisplacement, isDisplacement);
				BitConverter.InsertValueIntoArray(BufferDef.Buffer, BufferDef.IsConf, isConf);
				Radio.SetRadioState(SimpleCsmaRadio.RadioStates.On);
				Radio.Send(Addresses.BROADCAST, BufferDef.Buffer);
				Radio.SetRadioState(SimpleCsmaRadio.RadioStates.Off);
			}
		}

		/// <summary>
		/// Output items
		/// </summary>
		public static class Out
		{
			/// <summary>
			/// DataStore object
			/// </summary>
			public static readonly DataStore DataStore = DataStore.Instance(StorageType.NOR, true);

			/// <summary>Options true iff logging</summary>
			public static bool LoggingRequired;

			/// <summary>Print after logging</summary>
			public static bool PrintAfterRawLogging;


			/// <summary>
			/// Record prefix
			/// </summary>
			public static class RecordPrefix
			{
				/// <summary>Buffer position</summary>
				public const int Header0 = 0;
				/// <summary>Buffer position</summary>
				public const int Header1 = Header0 + sizeof(char);
			}

			/// <summary>
			/// Sync message
			/// </summary>
			public static class Sync
			{
				/// <summary>Sync prefix</summary>
				public static char[] SyncPrefix = { '#', 's' };

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
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						RecordPrefix.Header0, SyncPrefix[0]);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						RecordPrefix.Header1, SyncPrefix[1]);

					WriteDataRefAndUpdateCrc(BufferDef.Buffer);

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
				/// <remarks>Items stored: raw I value, raw Q value</remarks>
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
				/// Prefixes
				/// </summary>
				public static class Prefix
				{
					/// <summary>Sample values and cut detection (Prefix, Raw.I, Raw.Q)</summary>
					public static char[] RawSamplePrefix = { '#', 'e' };
				}

				/// <summary>
				/// Log raw sample
				/// </summary>
				/// <param name="rawSample"></param>
				public static void LogRawSample(Sample rawSample)
				{
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						RecordPrefix.Header0, Prefix.RawSamplePrefix[0]);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						RecordPrefix.Header1, Prefix.RawSamplePrefix[1]);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						BufferDef.RawI, rawSample.I);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						BufferDef.RawQ, rawSample.Q);

					WriteDataRefAndUpdateCrc(BufferDef.Buffer);
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
					public const int RawI = SampleNum + sizeof(int);	// Last position + size of last item
					/// <summary>Buffer position</summary>
					public const int RawQ = RawI + sizeof(short);
					/// <summary>Buffer position</summary>
					public const int SampleI = RawQ + sizeof(short);
					/// <summary>Buffer position</summary>
					public const int SampleQ = SampleI + sizeof(int);
					/// <summary>Buffer position</summary>
					public const int IsCut = SampleQ + sizeof(int);
					/// <summary>Buffer position</summary>
					public const int IsDisplacement = IsCut + sizeof(int);
					/// <summary>Buffer position</summary>
					public const int IsConf = IsDisplacement + sizeof(bool);

					/// <summary>Buffer size</summary>
					public const int BuffSize = IsConf + sizeof(bool);
				}
				/// <summary>
				/// Prefixes
				/// </summary>
				public static class Prefix
				{
					/// <summary>Sample values and cut detection (Prefix, Raw.I, Raw.Q)</summary>
					public static char[] RawEverythingPrefix = { '#', 'f' };
				}

				/// <summary>
				/// Log Raw Everything
				/// </summary>
				/// <param name="sampleNum"></param>
				/// <param name="rawSample"></param>
				/// <param name="compSample"></param>
				/// <param name="isCut"></param>
				/// <param name="isDisplacement"></param>
				/// <param name="isConfirmed"></param>
				public static void LogRawEverything(int sampleNum, Sample rawSample, Sample compSample, int isCut, bool isDisplacement, bool isConfirmed)
				{
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						RecordPrefix.Header0, Prefix.RawEverythingPrefix[0]);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						RecordPrefix.Header1, Prefix.RawEverythingPrefix[1]);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						BufferDef.SampleNum, sampleNum);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						BufferDef.RawI, (uint)rawSample.I);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						BufferDef.RawQ, (uint)rawSample.Q);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						BufferDef.SampleI, compSample.I);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						BufferDef.SampleQ, compSample.Q);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						BufferDef.IsCut, isCut);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						BufferDef.IsDisplacement, isDisplacement);
					BitConverter.InsertValueIntoArray(BufferDef.Buffer,
						BufferDef.IsConf, isConfirmed);

					WriteDataRefAndUpdateCrc(BufferDef.Buffer);

					//Globals.DataStoreItems.DRef.Write(Globals.DataStoreItems.RawSample.Buffer);

					//Globals.AllocationsWritten++;

					//Debug.Print("# " + rawSample.I + "\t" + rawSample.Q);
					//Debug.Print("CRC init: " + initCrc + ", CRC end: " + Globals.CrcWritten);

					//var vals = new StringBuilder("$ ");
					//for (var i = 0; i < Globals.Out.RawEverything.BufferDef.BuffSize; i++)
					//{
					//	vals.Append(Globals.Out.RawEverything.BufferDef.Buffer[i] + "\t");
					//}
					//Debug.Print(vals + "\n");

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
					public const int SampleQ = SampleI + sizeof(int);
					/// <summary>Buffer position</summary>
					public const int IsCut = SampleQ + sizeof(int);

					/// <summary>Buffer size</summary>
					public const int BuffSize = IsCut + sizeof(int);

					/// <summary>
					/// Prefixes
					/// </summary>
					public static class Prefix
					{
						/// <summary>Sample and cut detection header as chars</summary>
						public static char[] FieldsC = { '#', 'a' };
						///// <summary>Sample and cut detection header as string</summary>
						//public static string Fields = string.Empty;
						/// <summary>Sample values and cut detection (SampleNum, Sample.I, Sample.Q, IsCut) as chars</summary>
						public static char[] SampleC = { '#', 'b' };
						///// <summary>Sample values and cut detection as string</summary>
						//public static string Sample = string.Empty;
					}
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

					/// <summary>Prefixes</summary>
					public static class Prefix
					{
						/// <summary>Snippet log header chars</summary>
						public static char[] FieldsC = { '#', 'c' };
						///// <summary>Snippet log header string</summary>
						//public static string Fields = string.Empty;
						/// <summary>Snippet detections (sample num, IsDisplacement, IsConf) chars</summary>
						public static char[] SnippetC = { '#', 'd' };
						///// <summary>Snippet detections string</summary>
						//public static string Snippet = string.Empty;
					}

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
			}

		}

		/// <summary>
		/// Define GPIO ports
		/// </summary>
		public static class GpioPorts
		{
#if Sam_Emulator
            public static Cpu.Pin Led1Pin = 0;
            public static Cpu.Pin Led2Pin = (Cpu.Pin)1;
            public static Cpu.Pin Led3Pin = (Cpu.Pin)2;
            public static Cpu.Pin Button1Pin = (Cpu.Pin)3;
            public static Cpu.Pin Button2Pin = (Cpu.Pin)4;
            public static Cpu.Pin Button3Pin = (Cpu.Pin)5;
            /// <summary>On iff snippet displacement</summary>
            public static OutputPort DisplacementPort = new OutputPort(Led1Pin, false);
            /// <summary>On iff MofN confirms displacement</summary>
            public static OutputPort MofNConfirmationPort = new OutputPort(Led2Pin, false);
#endif
#if DotNow
			//****************************** J12 ***************************

			/// <summary>Indicate when sample is processed</summary>
			public static OutputPort SampleProcessed = new OutputPort(Pins.GPIO_J12_PIN1, false);

			//****************************** J11 ***************************

			/// <summary>Enable the BumbleBee. Set this false to disable. </summary>
			public static OutputPort EnableBumbleBee = new OutputPort(Pins.GPIO_J11_PIN3, true);

			/// <summary>For a logic analyzer. Put toggle wherever needed.</summary>
			public static OutputPort LogicJ11Pin4 = new OutputPort(Pins.GPIO_J11_PIN4, false);

			///<summary>(input)Signal end of collect</summary>
			public static InterruptPort EndCollect = new InterruptPort(Pins.GPIO_J11_PIN5, true, Port.ResistorMode.PullUp, Port.InterruptMode.InterruptEdgeBoth);

			///<summary>(input)Signal sync event</summary>
			public static InterruptPort Sync = new InterruptPort(Pins.GPIO_J11_PIN6, true, Port.ResistorMode.PullUp, Port.InterruptMode.InterruptEdgeBoth);

			/// <summary>Displacement detected</summary>
			public static OutputPort DetectDisplacement = new OutputPort(Pins.GPIO_J11_PIN7, false);

			/// <summary>Confirmation detected</summary>
			public static OutputPort DetectConf = new OutputPort(Pins.GPIO_J11_PIN8, false);
#endif
		}
	}
}
