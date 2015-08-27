using System;
using System.Text;
using Microsoft.SPOT;
using Samraksh.AppNote.Samraksh.AppNote.DotNow.Radar;

#if !(DotNow || Sam_Emulator)
#error Conditional build symbol missing
#endif

using Samraksh.AppNote.Utility;
using Samraksh.eMote.NonVolatileMemory;

namespace Samraksh.AppNote.DotNow.Radar.DisplacementAnalysis
{
	/// <summary>
	/// Analyze displacement for a pair of samples
	/// </summary>
	public static partial class AnalyzeDisplacement
	{
		/// <summary>
		/// Method to call to signal major detection
		/// </summary>
		/// <param name="displacing">true iff displacing</param>
		public delegate void EventCallback(bool displacing);

		private static class ClassParameters
		{
			//	/// <summary>Number of milliseconds between samples</summary>
			//	public static int SamplingIntervalMicroSec;    // Larger values => fewer samples/sec

			//	/// <summary>Number of samples per second</summary>
			//	public static int SamplesPerSecond;

			//	/// <summary>Number of minor displacement events that must occur for displacement detection</summary>
			//	public static int M;

			//	/// <summary>Number of seconds for which a displacement detection can last</summary>
			//	public static int N;

			//	/// <summary>Noise rejection trhreshold</summary>
			//	public static int NoiseRejectionThreshold;

			//	/// <summary>Minimum number of cuts (phase unwraps) that must occur for a minor displacement event</summary>
			//	public static int MinCumCuts;

			//	/// <summary>The centimeters traversed by one cut. This is a fixed characteristic of the Bumblebee; do not change this value.</summary>
			//	public const float CutDistanceCm = 5.2f / 2;

			/// <summary>Method to call when M of N confirms displacement</summary>
			public static EventCallback MofNConfirmationCallback;

			/// <summary>Method to call when M of N confirms displacement</summary>
			public static EventCallback DisplacementCallback;
		}


		/// <summary>
		/// Initialize displacement analysis
		/// </summary>
		/// <param name="displacementCallback">Method to call to signal displacement in a snippet</param>
		/// <param name="mofNConfirmationCallback">Method to call to signal M of N confirmation</param>
		public static void Initialize(EventCallback displacementCallback, EventCallback mofNConfirmationCallback)
		{
			ClassParameters.DisplacementCallback = displacementCallback;
			ClassParameters.MofNConfirmationCallback = mofNConfirmationCallback;

			// Initialize analysis classes
			CutAnalysis.Initialize();
			MofNConfirmation.Initialize();

		}

		/// <summary>
		/// Analyze a sample for displacement
		/// </summary>
		/// <remarks>
		/// Samples are partitioned into snippets; currently 1 second.
		/// Displacement occurs if the abs(sum of cuts) in a snippet exceeds a maximum such as 6. 
		///     The assumption is that a fixed object such as a tree will not exhibit this much net displacement.
		/// To further confirm displacement (reduce false positives), look for at least M displacements in N seconds.
		/// For N of M, note that we do not care if the target alternately moves forward and backward the required distance.
		/// </remarks>
		public static void Analyze(Globals.Sample rawSample)
		{
			SampleData.SampleNum++;

			SampleData.SampleSum.I += rawSample.I;
			SampleData.SampleSum.Q += rawSample.Q;

			// Adjust current sample by the current mean 
			SampleData.CompSample.I = rawSample.I - (SampleData.SampleSum.I / SampleData.SampleNum);
			SampleData.CompSample.Q = rawSample.Q - (SampleData.SampleSum.Q / SampleData.SampleNum);

			// Check for a cut
			var isCut = 0;
			// Skip samples below the noise rejection threshold
			if (System.Math.Abs(SampleData.CompSample.I) >= DetectorParameters.NoiseRejectionThreshold ||
				System.Math.Abs(SampleData.CompSample.Q) >= DetectorParameters.NoiseRejectionThreshold)
			{
				isCut = CutAnalysis.CheckForCut(SampleData.CompSample);
			}

			// Record mins and maxes
			SampleData.MinComp.I = System.Math.Min(SampleData.MinComp.I, SampleData.CompSample.I);
			SampleData.MinComp.Q = System.Math.Min(SampleData.MinComp.Q, SampleData.CompSample.Q);

			SampleData.MaxComp.I = System.Math.Max(SampleData.MaxComp.I, SampleData.CompSample.I);
			SampleData.MaxComp.Q = System.Math.Max(SampleData.MaxComp.Q, SampleData.CompSample.Q);

			// Update snippet counter and see if we've reached a snippet boundary (one second)
			CutAnalysis.SnippetCntr++;

			// Do any sample logging
			DoSampleLogging(rawSample, isCut);

			// Check for displacement and confirmation and do any required logging
			if (CutAnalysis.SnippetCntr == DetectorParameters.SamplesPerSecond)
			{
				CheckDisplacementAndConfirmation(rawSample, isCut);
			}


			// Log raw everything if required
			if (Globals.Out.RawEverything.Opt.Logging)
			{
				Globals.Out.RawEverything.LogRawEverything(SampleData.SampleNum, rawSample, SampleData.CompSample, isCut, SampleData.IsDisplacement, MofNConfirmation.IsConfirmed);
			}

			//if (SampleData.SampleNum < 100) {
			//	var arrayVals = new StringBuilder();
			//	foreach (var theVal in Globals.DataStoreItems.Buffer) {
			//		arrayVals.Append(theVal + ",");
			//	}
			//	Debug.Print(arrayVals.ToString());
			//}
			//Globals.DataStoreItems.DRef.si
		}
		
		private static void DoSampleLogging(Globals.Sample rawSample, int isCut)
		{
			// Log raw sample if required
			if (Globals.Out.RawSample.Opt.Logging)
			{
				Globals.Out.RawSample.LogRawSample(rawSample);
			}

			// Print sample and cut if required
			if (Globals.Out.SampleAndCut.Opt.Print)
			{
				var statusStr = new String(Globals.Out.SampleAndCut.BuffDef.Prefix.SampleC) +
					"\t" + SampleData.CompSample.I +
					"\t" + SampleData.CompSample.Q +
					"\t" + isCut;
				Debug.Print(statusStr);
			}

			// Log sample and cut if required
			if (Globals.Out.SampleAndCut.Opt.LogToDebug || Globals.Out.SampleAndCut.Opt.LogToSD)
			{
				LogSampleAndCut(isCut);
			}

		}

		/// <summary>
		/// Check whether displacement and/or confirmation (MofN) has occurred
		/// </summary>
		/// <param name="rawSample">Raw sample (used forlogging)</param>
		/// <param name="isCut">Is cut? (used for logging)</param>
		private static void CheckDisplacementAndConfirmation(Globals.Sample rawSample, int isCut)
		{
			// We've collected cumulative cut data for a snippet. See if snippet displacement has occurred
			//  Displacement occurs only if there are more than MinCumCuts in the snippet
			SampleData.IsDisplacement = (System.Math.Abs(CutAnalysis.CumCuts) >= DetectorParameters.MinCumCuts);
			ClassParameters.DisplacementCallback(SampleData.IsDisplacement);

			// See if we've had displacement in N of the last M snippets
			MofNConfirmation.UpdateConfirmationState(CutAnalysis.SnippetNum, SampleData.IsDisplacement);

			// Do any required snippet logging
			DoSnippetLogging(rawSample, isCut);

			// Update snippet info and reset cumulative cuts values
			CutAnalysis.SnippetNum++;
			CutAnalysis.Reset();

			// Displacement event started
			if (!MofNConfirmation.PrevConf && MofNConfirmation.IsConfirmed)
			{
				ClassParameters.MofNConfirmationCallback(true);
				//Debug.Print("\n-------------------------MofN confirmation started");
			}

				// Displacement event ended
			else if (MofNConfirmation.PrevConf &&
					 !MofNConfirmation.IsConfirmed)
			{
				ClassParameters.MofNConfirmationCallback(false);
				//Debug.Print("\n-------------------------MofN confirmation ended");
			}
		}

		private static void DoSnippetLogging(Globals.Sample rawSample, int isCut)
		{
			// Send radio update, if enabled
			if (Globals.RadioUpdates.EnableRadioUpdates)
			{
				Globals.RadioUpdates.SnippetUpdate(SampleData.IsDisplacement, MofNConfirmation.IsConfirmed);
			}

			// Log snippet displacement and confirmation if required
			if (Globals.Out.SnippetDispAndConf.Opt.LogToDebug || Globals.Out.SnippetDispAndConf.Opt.LogToSD)
			{
				LogSnippetDispAndConf();
			}

			// Print snippet displacement & confirmation if required
			if (Globals.Out.SnippetDispAndConf.Opt.Print)
			{
				PrintSnippetDispAndConf();
			}
		}
		

		private static void LogSampleAndCut(int isCut)
		{
			BitConverter.InsertValueIntoArray(Globals.Out.SampleAndCut.BuffDef.Buffer,
				Globals.Out.RecordPrefix.Header0, Globals.Out.SampleAndCut.BuffDef.Prefix.SampleC[0]);
			BitConverter.InsertValueIntoArray(Globals.Out.SampleAndCut.BuffDef.Buffer,
				Globals.Out.RecordPrefix.Header1, Globals.Out.SampleAndCut.BuffDef.Prefix.SampleC[1]);
			BitConverter.InsertValueIntoArray(Globals.Out.SampleAndCut.BuffDef.Buffer,
				Globals.Out.SampleAndCut.BuffDef.SampleNum, SampleData.SampleNum);
			BitConverter.InsertValueIntoArray(Globals.Out.SampleAndCut.BuffDef.Buffer,
				Globals.Out.SampleAndCut.BuffDef.SampleI, SampleData.CompSample.I);
			BitConverter.InsertValueIntoArray(Globals.Out.SampleAndCut.BuffDef.Buffer,
				Globals.Out.SampleAndCut.BuffDef.SampleQ, SampleData.CompSample.Q);
			BitConverter.InsertValueIntoArray(Globals.Out.SampleAndCut.BuffDef.Buffer,
				Globals.Out.SampleAndCut.BuffDef.IsCut, isCut);

			Globals.WriteDataRefAndUpdateCrc(Globals.Out.SampleAndCut.BuffDef.Buffer);

			//Globals.DataStoreItems.DRef.Write(Globals.DataStoreItems.SampleAndCut.Buffer);

			//Globals.AllocationsWritten++;

			//Globals.CrcWritten = Microsoft.SPOT.Hardware.Utility.ComputeCRC(
			//	Globals.DataStoreItems.SampleAndCut.Buffer,
			//	0,
			//	Globals.DataStoreItems.SampleAndCut.BuffSize,
			//	Globals.CrcWritten);
		}

		private static void PrintSnippetDispAndConf()
		{
			var statusStr =
				new string(Globals.Out.SnippetDispAndConf.BuffDef.Prefix.SnippetC)
				+ "\t" + CutAnalysis.SnippetNum
				+ "\t" + CutAnalysis.CumCuts
				+ "\t" + (SampleData.IsDisplacement ? "1" : "0")
				+ "\t" + (MofNConfirmation.IsConfirmed ? "1" : "0")
				;
			Debug.Print(statusStr);
		}

		private static void LogSnippetDispAndConf()
		{
			BitConverter.InsertValueIntoArray(Globals.Out.SnippetDispAndConf.BuffDef.Buffer,
				Globals.Out.RecordPrefix.Header0, Globals.Out.SnippetDispAndConf.BuffDef.Prefix.SnippetC[0]);
			BitConverter.InsertValueIntoArray(Globals.Out.SnippetDispAndConf.BuffDef.Buffer,
				Globals.Out.RecordPrefix.Header1, Globals.Out.SnippetDispAndConf.BuffDef.Prefix.SnippetC[1]);
			BitConverter.InsertValueIntoArray(Globals.Out.SnippetDispAndConf.BuffDef.Buffer,
				Globals.Out.SnippetDispAndConf.BuffDef.SampleNum, SampleData.SampleNum);

			BitConverter.InsertValueIntoArray(Globals.Out.SnippetDispAndConf.BuffDef.Buffer,
				Globals.Out.SnippetDispAndConf.BuffDef.CumCuts, CutAnalysis.CumCuts);

			BitConverter.InsertValueIntoArray(Globals.Out.SnippetDispAndConf.BuffDef.Buffer,
				Globals.Out.SnippetDispAndConf.BuffDef.IsDisp, SampleData.IsDisplacement ? 1 : 0);
			BitConverter.InsertValueIntoArray(Globals.Out.SnippetDispAndConf.BuffDef.Buffer,
				Globals.Out.SnippetDispAndConf.BuffDef.IsConfirmed, MofNConfirmation.IsConfirmed ? 1 : 0);
			
			Globals.WriteDataRefAndUpdateCrc(Globals.Out.SnippetDispAndConf.BuffDef.Buffer);

			//Globals.DataStoreItems.DRef.Write(Globals.DataStoreItems.SnippetDispAndConf.Buffer);

			//Globals.AllocationsWritten++;

			//Globals.CrcWritten = Microsoft.SPOT.Hardware.Utility.ComputeCRC(
			//	Globals.DataStoreItems.SampleAndCut.Buffer,
			//	0,
			//	Globals.DataStoreItems.SampleAndCut.BuffSize,
			//	Globals.CrcWritten);

		}



		/// <summary>
		/// Cut analysis
		/// </summary>
		/// <remarks>One cut = 5.2 / 2 = 2.6 cm distance</remarks>
		private static class CutAnalysis
		{
			private static readonly Globals.Sample PrevSample = new Globals.Sample();

			/// <summary>Cumulative cuts</summary>
			public static int CumCuts;

			/// <summary>Counts samples to see when a snippet (one second) has been reached</summary>
			public static int SnippetCntr;

			/// <summary>Snippet Number. Incremented once per second.</summary>
			public static int SnippetNum;

			/// <summary>
			/// Constructor: Initialize previous values
			/// </summary>
			public static void Initialize()
			{
				PrevSample.I = PrevSample.Q = 0;
				Reset();
			}

			/// <summary>
			/// Reset the cumulative cuts
			/// </summary>
			public static void Reset()
			{
				CumCuts = 0;
				SnippetCntr = 0;
				//altCumCuts = 0;
			}

			/// <summary>
			/// Increment or decrement the cumulative cuts based on previous and current sample
			/// </summary>
			/// <param name="currSample"></param>
			public static int CheckForCut(Globals.Sample currSample)
			{
				var isCut = 0;
				if (SampleData.SampleNum > 1)
				{
#if DotNow
					// Signal the beginning
					Globals.GpioPorts.LogicJ11Pin4.Write(true);
#endif
					var crossProduct = (PrevSample.Q * currSample.I) - (PrevSample.I * currSample.Q);

					if (crossProduct < 0 && PrevSample.I < 0 && currSample.I > 0)
					{
						isCut = +1;
					}
					else if (crossProduct > 0 && PrevSample.I > 0 && currSample.I < 0)
					{
						isCut = -1;
					}
					CumCuts += isCut;
				}
#if DotNow
				// Signal the end
				Globals.GpioPorts.LogicJ11Pin4.Write(false);
#endif
				PrevSample.I = currSample.I;
				PrevSample.Q = currSample.Q;

				return isCut;
			}
		}


		//private static int altCumCuts = 0;

		/// <summary>
		/// Check if, in the last N seconds, there were M seconds in which displacement occurred
		/// </summary>
		/// <remarks>
		/// Buff is a circular buffer of size M. 
		///     It is initialized to values guaranteed to be sufficiently distant in the past so as to not trigger confirmation.
		/// UpdateConfirmationState is called once per snippet (once per second). 
		///     It checks to see if the current buffer value is sufficiently recent or not and sets the confirmation state accordingly.
		/// If displacement occurred during this snippet, 
		///     then the snippet number is saved and the buffer pointer advances.
		/// When we do a comparison in UpdateConfirmationState, the current buffer entry is the oldest snippet where displacement occurred.
		///     Since all the other snippets are more recent, it suffices to see if the current one occurred within N snippets.
		/// </remarks>
		public static class MofNConfirmation
		{

			//private static readonly int M = ClassParameters.M; // Syntactic sugar
			//private static readonly int N = ClassParameters.N;

			private static int[] _mofNBuff;
			private static int _mofNBuffPtr;

			/// <summary>Initialize current confirmation state</summary>
			public static bool IsConfirmed = false;

			/// <summary>Initialize previous confirmation state</summary>
			public static bool PrevConf = false;

			/// <summary>
			/// Initialize M of N filter
			/// </summary>
			public static void Initialize()
			{
				_mofNBuff = new int[DetectorParameters.M];
				for (var i = 0; i < _mofNBuff.Length; i++)
					_mofNBuff[i] = -DetectorParameters.N; // Any value less than -N will do
			}

			/// <summary>
			/// Determine whether we are detecting motion or not
			/// </summary>
			/// <param name="snippetNumber">Snippet Number</param>
			/// <param name="displacementDetected">true iff displacement detection has occurred</param>
			public static void UpdateConfirmationState(int snippetNumber, bool displacementDetected)
			{
				// Save the current state so we can check if there's been a change
				PrevConf = IsConfirmed;

				// If displacement detected, record it
				if (displacementDetected)
				{
					_mofNBuff[_mofNBuffPtr] = snippetNumber;
					_mofNBuffPtr = (_mofNBuffPtr + 1) % DetectorParameters.M;
				}

				// Check if the snippet number occurred sufficiently recently
				IsConfirmed = (snippetNumber - _mofNBuff[_mofNBuffPtr] < DetectorParameters.N);

				//				Debug.Print("MofN: curr snippet " + snippetNumber + ", curr buff val " + _mofNBuff[MofNBuffPtr] + ", disp state " + IsConfirmed);
			}
		}
	}

}
