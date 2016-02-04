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
using Samraksh.AppNote.DotNow.DisplacementAnalysis;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;
using Samraksh.eMote.Net.Radio;
using Samraksh.eMote.NonVolatileMemory;
using Math = System.Math;
using RawSample = Samraksh.AppNote.DotNow.RadarDisplacementDetector.OutputItems.RawSample;
using AsciiSampleAndCut = Samraksh.AppNote.DotNow.RadarDisplacementDetector.OutputItems.AsciiSampleAndCut;
using AsciiSnippetDispAndConf = Samraksh.AppNote.DotNow.RadarDisplacementDetector.OutputItems.AsciiSnippetDispAndConf;

#if !(DotNow || Sam_Emulator)
#error Conditional build symbol missing
#endif

#if (DotNow && Sam_Emulator)
#error Cannot define both
#endif

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


		/// <summary>
		/// Get things started
		/// </summary>
		public static void Main()
		{
			try
			{
				VersionInfo.Init(Assembly.GetExecutingAssembly());
				Debug.Print("Radar Displacement Detection " + VersionInfo.Version + " (" + VersionInfo.BuildDateTime + ")");
#if DotNow
				Globals.Lcd.Write("radar");
#endif

				// **************************************************************************************************** 
				//	Output options
				// **************************************************************************************************** 

				RawSample.CollectionType = RawSample.CollectionOptions.None;
				RawSample.OutOpt.PrintImmediate = true;
				RawSample.OutOpt.MaxPrint = 10;
				RawSample.OutOpt.LogToDebug = true;
				RawSample.OutOpt.LogToSD = true;

				AsciiSampleAndCut.CollectionType = AsciiSampleAndCut.CollectionOptions.SampleAndAnalysis;
				AsciiSampleAndCut.OutOpt.PrintImmediate = true;
				AsciiSampleAndCut.OutOpt.MaxPrint = 0;
				AsciiSampleAndCut.OutOpt.LogToDebug = true;
				AsciiSampleAndCut.OutOpt.LogToSD = true;

				AsciiSnippetDispAndConf.CollectionType = AsciiSnippetDispAndConf.CollectionOptions.SnippetDisplacementAndConfirmation;
				AsciiSnippetDispAndConf.OutOpt.PrintImmediate = true;
				AsciiSnippetDispAndConf.OutOpt.LogToDebug = false;
				AsciiSnippetDispAndConf.OutOpt.LogToSD = false;

				// **************************************************************************************************** 

				OutputItems.LoggingRequired.ToDebugRequired = AsciiSnippetDispAndConf.OutOpt.LogToDebug ||
					AsciiSampleAndCut.OutOpt.LogToDebug ||
					AsciiSnippetDispAndConf.OutOpt.LogToDebug;

				OutputItems.LoggingRequired.ToSDRequired = AsciiSnippetDispAndConf.OutOpt.LogToSD ||
					AsciiSampleAndCut.OutOpt.LogToSD ||
					AsciiSnippetDispAndConf.OutOpt.LogToSD;

				OutputItems.LoggingRequired.Required = OutputItems.LoggingRequired.ToDebugRequired ||
					OutputItems.LoggingRequired.ToSDRequired;

				// Setup radio
				Globals.RadioUpdates.EnableRadioUpdates = true;
				if (Globals.RadioUpdates.EnableRadioUpdates)
				{
					Globals.RadioUpdates.Radio = new SimpleCSMA(RadioName.RF231RADIO, 140, TxPowerValue.Power_0Point7dBm, Globals.RadioUpdates.Channel);
				}

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

				if (OutputItems.LoggingRequired.Required)
				{
#if DotNow
					Globals.Lcd.Write("Init");
#endif
					Debug.Print("\tInitializing DataStore");

					DataStoreReturnStatus retVal;
					if ((retVal = OutputItems.DStore.DeleteAllData()) != DataStoreReturnStatus.Success)
					{
						throw new Exception("Cannot delete the data store; return value " + retVal);
					}

					//var buffer = new byte[30];
					//var dataStoreReference = new DataReference(
					//	OutputItems.DStore,
					//	buffer.Length,
					//ReferenceDataType.BYTE
					//);
					//dataStoreReference.Write(buffer);
					//Debug.Print("\t\t... write successful");
				}

				if (OutputItems.LoggingRequired.ToSDRequired)
				{
					Debug.Print("\tInitializing SD");
					// ReSharper disable once ObjectCreationAsStatement
					new SD(status => { });	// Even though this seems to be a do-nothing method call, it's still necessary before initializing the SD card
					if (!SD.Initialize())
					{
#if DotNow
						Globals.Lcd.Write("Xsd");
#endif
						throw new ApplicationException("*** Error: Cannot initialize microSD");
					}
				}

				Debug.Print("Initialization done");

#if DotNow
				Globals.Lcd.Write("IIII");
#endif
				// Print output options
				Debug.Print("");
				RawSample.PrintOutputOptions();
				AsciiSampleAndCut.PrintOutputOptions();
				AsciiSnippetDispAndConf.PrintOutputOptions();
				Debug.Print("");

				// Print header(s) for immediate print
				if (RawSample.OutOpt.PrintImmediate)
				{
					switch (RawSample.CollectionType)
					{
						case RawSample.CollectionOptions.None:
							break;
						case RawSample.CollectionOptions.RawSampleOnly:
							RawSample.RawSampleOnly.PrintHeader();
							break;
						case RawSample.CollectionOptions.RawSampleAndAnalysis:
							RawSample.RawSampleAndAnalysis.PrintHeader();
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
				if (AsciiSampleAndCut.CollectionType == AsciiSampleAndCut.CollectionOptions.SampleAndAnalysis &&
					AsciiSampleAndCut.OutOpt.PrintImmediate)
				{
					AsciiSampleAndCut.PrintHeader();
				}
				if (AsciiSnippetDispAndConf.CollectionType == AsciiSnippetDispAndConf.CollectionOptions.SnippetDisplacementAndConfirmation &&
					AsciiSnippetDispAndConf.OutOpt.PrintImmediate)
				{
					AsciiSnippetDispAndConf.PrintHeader();
				}


				Thread.Sleep(4000); // Wait a bit before launch

				// Set up a thread to process sample buffers
				//  This lets the ADC callback, AdcBuffer_Callback, finish quickly and avoids issues if processing takes too long
				var processSampleBufferThread = new Thread(ProcessSampleBuffer);
				processSampleBufferThread.Start();

				// Initialize displacement analysis
				AnalyzeDisplacement.Initialize(DisplacementCallback, MofNConfirmationCallback);

				// Start ADC sampling
				AnalogInput.InitializeADC();
				AnalogInput.ConfigureContinuousModeDualChannel(Ibuffer, Qbuffer, (uint)Ibuffer.Length, DetectorParameters.SamplingIntervalMicroSec, AdcBuffer_Callback);
#if DotNow
				Globals.Lcd.Write("cccc");
#endif
				// Sleep until we're finished sampling
				//Globals.DoneSampling.WaitOne();
				processSampleBufferThread.Join();
				Debug.Print("*******\nFinished Sampling\n*****");

				Debug.Print("* Min mean-adjusted I and Q values: " + AnalyzeDisplacement.SampleData.MinComp.I + "," + AnalyzeDisplacement.SampleData.MinComp.Q);
				Debug.Print("* Max mean-adjusted I and Q values: " + AnalyzeDisplacement.SampleData.MaxComp.I + "," + AnalyzeDisplacement.SampleData.MaxComp.Q);

				CopyLoggedDataToSdAndPrint();

				Debug.Print("*******\nFinished Output\n*****");

				Globals.Lcd.Write("0000");

				//Thread.Sleep(Timeout.Infinite);
			}
			catch (Exception ex)
			{
				Debug.Print("Exception " + ex);
				Globals.Lcd.Write("Err");
			}
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