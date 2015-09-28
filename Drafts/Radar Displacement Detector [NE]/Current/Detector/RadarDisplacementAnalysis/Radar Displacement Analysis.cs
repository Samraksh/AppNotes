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
		/// For a sample to be considered for displacement, the absolute values of the I and Q must be at least a specified NoiseRejectionThreshold.
		/// Displacement occurs if the abs(sum of cuts) in a snippet exceeds the value of MinCumCuts. 
		///     The assumption is that a fixed object such as a tree will not exhibit this much net displacement in one snippet.
		/// To further confirm displacement (reduce false positives), look for at least M displacements in N seconds.
		/// For N of M, note that we do not care if the target alternately displaces forward and backward.
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
			SampleData.MinComp.I = Globals.LongMin(SampleData.MinComp.I, SampleData.CompSample.I);
			SampleData.MinComp.Q = Globals.LongMin(SampleData.MinComp.Q, SampleData.CompSample.Q);

			SampleData.MaxComp.I = Globals.LongMax(SampleData.MaxComp.I, SampleData.CompSample.I);
			SampleData.MaxComp.Q = Globals.LongMax(SampleData.MaxComp.Q, SampleData.CompSample.Q);

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
			if (OutputItems.RawEverything.Opt.Logging)
			{
				OutputItems.RawEverything.Log(SampleData.SampleNum, SampleData.SampleSum, rawSample, SampleData.CompSample, isCut, SampleData.IsDisplacement, MofNConfirmation.IsConfirmed);
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
			if (OutputItems.RawSample.Opt.Logging)
			{
				OutputItems.RawSample.Log(rawSample);
			}

			// Print sample and cut if required
			if (OutputItems.SampleAndCut.Opt.Print)
			{
				OutputItems.SampleAndCut.PrintVals(SampleData.CompSample, isCut);
			}

			// Log sample and cut if required
			if (OutputItems.SampleAndCut.Opt.LogToDebug || OutputItems.SampleAndCut.Opt.LogToSD)
			{
				OutputItems.SampleAndCut.Log(SampleData.SampleNum, SampleData.CompSample, isCut);
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
			if (OutputItems.SnippetDispAndConf.Opt.LogToDebug || OutputItems.SnippetDispAndConf.Opt.LogToSD)
			{
				OutputItems.SnippetDispAndConf.Log(SampleData.SampleNum, CutAnalysis.CumCuts, SampleData.IsDisplacement, MofNConfirmation.IsConfirmed);
			}

			// Print snippet displacement & confirmation if required
			if (OutputItems.SnippetDispAndConf.Opt.Print)
			{
				OutputItems.SnippetDispAndConf.PrintVals(CutAnalysis.SnippetNum, CutAnalysis.CumCuts, SampleData.IsDisplacement, MofNConfirmation.IsConfirmed);
			}
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
