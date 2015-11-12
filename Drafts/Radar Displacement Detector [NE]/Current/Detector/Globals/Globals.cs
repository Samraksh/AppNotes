using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;
using Samraksh.eMote.Net.Mac;
using Samraksh.eMote.Net.Radio;
using Samraksh.eMote.NonVolatileMemory;

#if !(DotNow || Sam_Emulator)
#error Conditional build symbol missing
#endif

namespace Samraksh.AppNote.DotNow.Radar
{
	/// <summary>
	/// Global values and parameters
	/// </summary>
	public class Globals {

#if DotNow
		/// <summary>Lcd</summary>
		public static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();
#endif
		private static readonly object WriteLock = new object();

		/// <summary>
		/// Write the data reference and update the CRC
		/// </summary>
		/// <param name="buffer"></param>
		public static void WriteDataRefAndUpdateCrc(byte[] buffer)
		{
			try {
				// Prevent attempt to write from separate threads
				lock (WriteLock) {
					DataStoreReference = new DataReference(
						OutputItems.DStore,
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
			catch (Exception ex) {
				Debug.Print("Error "+ ex);
				Lcd.Write("Err");
			}
		}

		/// <summary>
		/// Min for type long
		/// </summary>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
		public static long LongMin(long arg1, long arg2)
		{
			return arg1 < arg2 ? arg1 : arg2;
		}

		/// <summary>
		/// Maxfor type long
		/// </summary>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
		public static long LongMax(long arg1, long arg2)
		{
			return arg1 > arg2 ? arg1 : arg2;
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
			public Sample(long i, long q)
			{
				I = i;
				Q = q;
			}

			/// <summary>I value</summary>
			public long I;

			/// <summary>Q value</summary>
			public long Q;
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

		/// <summary>Crc for reading</summary>
		public static uint CrcRead;
		
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
			private const char AppIdentifierHdr = 'D';

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
				InsertValueIntoArray.Insert(BufferDef.Buffer, BufferDef.AppIdentifier, AppIdentifierHdr);
				InsertValueIntoArray.Insert(BufferDef.Buffer, BufferDef.IsDisplacement, isDisplacement);
				InsertValueIntoArray.Insert(BufferDef.Buffer, BufferDef.IsConf, isConf);
				Radio.SetRadioState(SimpleCsmaRadio.RadioStates.On);
				Radio.Send(Addresses.BROADCAST, BufferDef.Buffer);
				Radio.SetRadioState(SimpleCsmaRadio.RadioStates.Off);
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
