/*--------------------------------------------------------------------
 * Radar Displacement Detector: app note for the eMote .NOW
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *      1.0: initial version
 *      1.1: Removed check for background noise
 *      
---------------------------------------------------------------------*/

using System;
using System.Reflection;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.AppNote.DotNow.Radar.DisplacementAnalysis;
using Samraksh.AppNote.Samraksh.AppNote.DotNow.Radar;
using Samraksh.AppNote.Utility;

#if !(DotNow || Sam_Emulator)
#error Conditional build symbol missing
#endif
using Samraksh.Appnote.Utility;
using Samraksh.eMote.DotNow;
using Samraksh.eMote.Net.Radio;
using Math = System.Math;
#if DotNow
using AnalogInput = Samraksh.eMote.DotNow.AnalogInput;
#endif

#if Sam_Emulator
using AnalogInput = Samraksh.eMote.Emulator.AnalogInput;
#endif

namespace Samraksh.AppNote.DotNow.RadarDisplacementDetector
{

	/// <summary>
	/// Radar Displacement Detector
	///     Snippet displacement (towards or away from the radar)
	///     Filters out "back and forth" movement (such as trees blowing in the wind)
	/// </summary>
	public static partial class RadarDisplacementDetector
	{

		private static readonly ushort[] Ibuffer = new ushort[DetectorParameters.BufferSize];
		private static readonly ushort[] Qbuffer = new ushort[DetectorParameters.BufferSize];

		private const ushort SdBufferSize = 512/2;	// Same as Exfiltrator buffer size
		private const byte Eof = 0xF0;	// Same as Exfiltrator EOF

#if DotNow
		private static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();
#endif

		/// <summary>
		/// Get things started
		/// </summary>
		public static void Main()
		{
			// Basic setup
			//Debug.EnableGCMessages(false);

			VersionInfo.Init(Assembly.GetExecutingAssembly());
			Debug.Print("Radar Displacement Detection " + VersionInfo.Version + " (" + VersionInfo.BuildDateTime + ")");
#if DotNow
			Lcd.Write("radar");
#endif
			// Setup radio
			Globals.RadioUpdates.EnableRadioUpdates = true;
			if (Globals.RadioUpdates.EnableRadioUpdates) {
				Globals.RadioUpdates.Radio = new SimpleCsmaRadio(RadioName.RF231RADIO, 140, TxPowerValue.Power_0Point7dBm,
					_ => { },	// Ignore incoming stuff
					Globals.RadioUpdates.Channel);
			}
	
			// Define output options
			OutputItems.RawSample.Opt.LogRawSampleToSD = false;

			OutputItems.RawEverything.Opt.LogRawEverythingToSD = true;

			OutputItems.PrintAfterRawLogging = true;

			OutputItems.SampleAndCut.Opt.LogToDebug = false;
			OutputItems.SampleAndCut.Opt.LogToSD = false;
			OutputItems.SampleAndCut.Opt.Print = false;

			OutputItems.SnippetDispAndConf.Opt.LogToDebug = false;
			OutputItems.SnippetDispAndConf.Opt.LogToSD = false;
			OutputItems.SnippetDispAndConf.Opt.Print = true;

			// Finish setting output options

			OutputItems.RawSample.Opt.Logging = OutputItems.RawSample.Opt.LogRawSampleToSD;
			OutputItems.RawEverything.Opt.Logging = OutputItems.RawEverything.Opt.LogRawEverythingToSD;
			OutputItems.SampleAndCut.Opt.Logging = OutputItems.SampleAndCut.Opt.LogToDebug || OutputItems.SampleAndCut.Opt.LogToSD;
			OutputItems.SnippetDispAndConf.Opt.Logging = OutputItems.SnippetDispAndConf.Opt.LogToDebug || OutputItems.SnippetDispAndConf.Opt.LogToSD;
			OutputItems.LoggingRequired =
				OutputItems.RawSample.Opt.Logging ||
				OutputItems.RawEverything.Opt.Logging ||
				OutputItems.SampleAndCut.Opt.Logging ||
				OutputItems.SnippetDispAndConf.Opt.Logging;

//			// Check logging output consistency
//			//	CAN mix logging and print since print is immediate and not logged
//			//	CAN do multiple kinds of ASCII logging at the same time because each record has a unique prefix
//			//	CAN'T do multiple kinds of raw logging at the same time because there is no prefix
//			//	CAN'T do ASCII and raw logging at the same time because raw has no prefix
//			var badConfig = false;
//			// Can't do 2 raw logging
//			badConfig |=
//				(OutputItems.RawEverything.Opt.Logging &&
//				OutputItems.RawSample.Opt.Logging);
//			// Can't do any raw logging along with ASCII logging
//			badConfig |=
//					(OutputItems.RawEverything.Opt.Logging ||
//					OutputItems.RawSample.Opt.Logging)
//				&&
//					(OutputItems.SampleAndCut.Opt.Logging ||
//					OutputItems.SnippetDispAndConf.Opt.Logging);
//			if (badConfig)
//			{
//#if DotNow
//				Lcd.Write("Xcfg");
//#endif
//				throw new ApplicationException("*** Error: cannot log raw sample simultaneously with other logging ***");
//			}

			PowerState.ChangePowerLevel(PowerLevel.High);
			Debug.Print("Power Level: " + PowerState.CurrentPowerLevel + " (16=High, 32=Med, 48=Low");

			Debug.Print("Bytes free: " + Debug.GC(true));

			Debug.Print("Parameters");
			Debug.Print("\tSamplingIntervalMicroSec " + DetectorParameters.SamplingIntervalMicroSec);
			Debug.Print("\tBufferSize " + DetectorParameters.BufferSize);
			Debug.Print("\tSamplesPerSecond " + DetectorParameters.SamplesPerSecond);
			Debug.Print("\tCallbackIntervalMicroSec " + DetectorParameters.CallbackIntervalMicroSec);
			Debug.Print("\tM " + DetectorParameters.M);
			Debug.Print("\tN " + DetectorParameters.N);
			Debug.Print("\tNoise Rejection Threshold " + DetectorParameters.NoiseRejectionThreshold);
			Debug.Print("\tMinCumCuts " + DetectorParameters.MinCumCuts);
			Debug.Print("\tCutDistanceCm " + Math.Truncate(DetectorParameters.CutDistanceCm * 100) / 100);
			Debug.Print("");

			// Signal end of collect
			Globals.GpioPorts.EndCollect.OnInterrupt += (d1, s2, t) =>
			{
				if (Globals.LoggingFinished)
				{
					return;
				}
				// Stop the ADC
				AnalogInput.StopSampling();
				Debug.Print("Stopping the ADC");
				// Note that we're finished
				Globals.LoggingFinished = true;
			};

			// Signal sync button press
			Globals.GpioPorts.Sync.OnInterrupt += OutputItems.Sync.Sync_OnButtonPress;

			if (OutputItems.RawSample.Opt.Logging || OutputItems.RawEverything.Opt.Logging)
			{
				Debug.Print("* Log raw samples to SD");
#if DotNow
				Lcd.Write("Init");
#endif
				// ReSharper disable once ObjectCreationAsStatement
				new SD(status => { });  // Even though this seems to be a do-nothing method call, it's still necessary before initializing the SD card
				if (!SD.Initialize())
				{
#if DotNow
					Lcd.Write("Xsd");
#endif
					throw new ApplicationException("*** Error: Cannot initialize microSD");
				}
				if (OutputItems.PrintAfterRawLogging)
				{
					Debug.Print("\tand print");
				}
			}
#if DotNow
			Lcd.Write("IIII");
#endif

			if (OutputItems.SampleAndCut.Opt.LogToDebug)
			{
				Debug.Print("* Log samples and detects to Debug");
			}

			if (OutputItems.SampleAndCut.Opt.Print)
			{
				Debug.Print("* Immediate output samples and detects to Debug not supported");
			}

			if (OutputItems.SnippetDispAndConf.Opt.LogToDebug)
			{
				Debug.Print("* Log snippet displacements and confirmations to Debug");
			}

			if (OutputItems.SnippetDispAndConf.Opt.Print)
			{
				Debug.Print("* Immediate output snippet displacements and confirmations to Debug");
				Debug.Print(new string(OutputItems.FieldNamesHeader) + "\tSnippet\tCumCuts\tDisp\tMofN");
			}

			Thread.Sleep(4000); // Wait a bit before launch

			// Set up a thread to process sample buffers
			//  This lets the ADC callback, AdcBuffer_Callback, finish quickly and avoids issues if processing takes too long
			var processSampleBufferThread = new Thread(ProcessSampleBuffer);
			processSampleBufferThread.Start();

			// Initialize displacement analysis
			AnalyzeDisplacement.Initialize(DisplacementCallback, MofNConfirmationCallback);

			// Initialize SD buffering
			SdBufferedWrite.Init(SdBufferSize, Eof);

			// Start ADC sampling
			AnalogInput.InitializeADC();
			AnalogInput.ConfigureContinuousModeDualChannel(Ibuffer, Qbuffer, (uint)Ibuffer.Length, DetectorParameters.SamplingIntervalMicroSec, AdcBuffer_Callback);
#if DotNow
			Lcd.Write("cccc");
#endif

			// Sleep until we're finished sampling
			//Globals.DoneSampling.WaitOne();
			processSampleBufferThread.Join();
			Debug.Print("*******\nFinished Sampling\n*****");

			Debug.Print("* Min mean-adjusted I and Q values: " + AnalyzeDisplacement.SampleData.MinComp.I + "," + AnalyzeDisplacement.SampleData.MinComp.Q);
			Debug.Print("* Max mean-adjusted I and Q values: " + AnalyzeDisplacement.SampleData.MaxComp.I + "," + AnalyzeDisplacement.SampleData.MaxComp.Q);

			CopyLoggedDataToSdAndPrint();

			Debug.Print("*******\nFinished Output\n*****");

			Lcd.Write("0000");

			//Thread.Sleep(Timeout.Infinite);
		}

		private static int _currentlyProcessingBuffer = IntBool.False;
		private static int _callbackCtr;
		static readonly AutoResetEvent ProcessSampleBufferAutoResetEvent = new AutoResetEvent(false);

		/// <summary>
		/// Callback for buffered ADC
		/// </summary>
		/// <param name="threshold"></param>
		private static void AdcBuffer_Callback(long threshold)
		{
			_callbackCtr++;
			// Check if we're currently processing a buffer. If so, give message and return
			//  The variable _currentlyProcessingBuffer is reset in ProcessSampleBuffer.
			if (Interlocked.CompareExchange(ref _currentlyProcessingBuffer, IntBool.True, IntBool.False) == IntBool.True)
			{
				Debug.Print("***************************************************************** Missed a buffer; callback #" + _callbackCtr);
				return;
			}

			// Not currently processing a buffer. Signal processing and return.
			ProcessSampleBufferAutoResetEvent.Set();
		}

	}
}