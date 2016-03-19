// **************************************************************************************************** 
//	Set Output options
// **************************************************************************************************** 

using RawSample = Samraksh.AppNote.DotNow.RadarDisplacement.Detector.Globals.OutputItems.RawSample;
using SampleAndCut = Samraksh.AppNote.DotNow.RadarDisplacement.Detector.Globals.OutputItems.SampleAndCut;
using SnippetDispAndConf = Samraksh.AppNote.DotNow.RadarDisplacement.Detector.Globals.OutputItems.SnippetDispAndConf;

namespace Samraksh.AppNote.DotNow.RadarDisplacement.Detector
{
	public static partial class RadarDisplacementDetector
	{
		/// <summary>
		/// Set Output Options
		/// </summary>
		public static void SetOutputOptions()
		{
			RawSample.CollectionType = RawSample.CollectionOptions.RawSampleAndAnalysis;
			RawSample.OutOpt.SampleAndPrint = 0;
			RawSample.OutOpt.LogToPrint = 0;
			RawSample.OutOpt.LogToSD = true;

			SampleAndCut.CollectionType = SampleAndCut.CollectionOptions.None;
			SampleAndCut.OutOpt.SampleAndPrint = 0;
			SampleAndCut.OutOpt.LogToPrint = 0;
			SampleAndCut.OutOpt.LogToSD = false;

			SnippetDispAndConf.CollectionType = SnippetDispAndConf.CollectionOptions.Snippet;
			SnippetDispAndConf.OutOpt.SampleAndPrint = -1;
			SnippetDispAndConf.OutOpt.LogToPrint = 0;
			SnippetDispAndConf.OutOpt.LogToSD = false;
		}
	}
}
