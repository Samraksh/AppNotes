using Samraksh.AppNote.DotNow.RadarDisplacement.Detector.Globals;

namespace Samraksh.AppNote.DotNow.RadarDisplacement.Analysis
{
	public static partial class AnalyzeDisplacement
	{
		/// <summary>
		/// Sample data
		/// </summary>
		public static class SampleData
		{
			/// <summary>Sample Counter</summary>
			public static int SampleNum;

			/// <summary>Current sample, adjusted by mean for comparison</summary>
			public static readonly GlobalItems.Sample CompSample = new GlobalItems.Sample();

			/// <summary>Sum of samples</summary>
			public static readonly GlobalItems.Sample SampleSum = new GlobalItems.Sample();

			/// <summary>Min mean-adjusted I and Q values</summary>
			public static readonly GlobalItems.Sample MinComp = new GlobalItems.Sample(int.MaxValue, int.MaxValue);

			/// <summary>Max mean-adjusted I and Q values</summary>
			public static readonly GlobalItems.Sample MaxComp = new GlobalItems.Sample(int.MinValue, int.MinValue);

			/// <summary>Has displacement occurred?</summary>
			public static bool IsDisplacement;
		}

	}
}