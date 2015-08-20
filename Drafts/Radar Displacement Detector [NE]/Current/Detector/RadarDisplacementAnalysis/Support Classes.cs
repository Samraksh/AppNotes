namespace Samraksh.AppNote.DotNow.Radar.DisplacementAnalysis
{
	public static partial class AnalyzeDisplacement
	{

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
		/// Sample data
		/// </summary>
		public static class SampleData
		{
			/// <summary>Sample Counter</summary>
			public static int SampleNum;

			/// <summary>Current sample, adjusted by mean for comparison</summary>
			public static readonly Sample CompSample = new Sample();

			/// <summary>Sum of samples</summary>
			public static readonly Sample SampleSum = new Sample();

			/// <summary>Min mean-adjusted I and Q values</summary>
			public static readonly Sample MinComp = new Sample(int.MaxValue, int.MaxValue);

			/// <summary>Max mean-adjusted I and Q values</summary>
			public static readonly Sample MaxComp = new Sample(int.MinValue, int.MinValue);

			/// <summary>Has displacement occurred?</summary>
			public static bool IsDisplacement;
		}

	}
}