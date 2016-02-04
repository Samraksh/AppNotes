using Samraksh.AppNote.DotNow.RadarDisplacementDetector;

namespace Samraksh.AppNote.DotNow.DisplacementAnalysis
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
			public static readonly Globals.Sample CompSample = new Globals.Sample();

			/// <summary>Sum of samples</summary>
			public static readonly Globals.Sample SampleSum = new Globals.Sample();

			/// <summary>Min mean-adjusted I and Q values</summary>
			public static readonly Globals.Sample MinComp = new Globals.Sample(int.MaxValue, int.MaxValue);

			/// <summary>Max mean-adjusted I and Q values</summary>
			public static readonly Globals.Sample MaxComp = new Globals.Sample(int.MinValue, int.MinValue);

			/// <summary>Has displacement occurred?</summary>
			public static bool IsDisplacement;
		}

	}
}