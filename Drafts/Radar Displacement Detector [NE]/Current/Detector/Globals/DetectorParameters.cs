using System;
using Microsoft.SPOT;

namespace Samraksh.AppNote.Samraksh.AppNote.DotNow.Radar
{
	/// <summary>
	/// Displacement detection parameters
	/// </summary>
	public static class DetectorParameters
	{
		/// <summary>Number of microseconds between samples</summary>
		public const int SamplingIntervalMicroSec = 4000;    // Larger values => fewer samples/sec
		//public const int SamplingIntervalMicroSec = 3096;    // Larger values => fewer samples/sec

		/// <summary>Number of samples to collect before presenting for processing</summary>
		//public const int BufferSize = 500;
		public const int BufferSize = 256;

		/// <summary>Number of samples per second (rounded)</summary>
		public const int SamplesPerSecond = (int)(((float)1000000 / SamplingIntervalMicroSec) + .5);

		/// <summary>Number of microseconds between invocation of buffer processing callback</summary>
		public const int CallbackIntervalMicroSec = BufferSize * SamplingIntervalMicroSec / 1000;

		/// <summary>Number of minor displacement events that must occur for displacement detection</summary>
		public const int M = 2;

		/// <summary>Number of seconds for which a displacement detection can last</summary>
		public const int N = 8;

		/// <summary>Noise rejection threshold</summary>
		public const int NoiseRejectionThreshold = 7;

		/// <summary>Minimum number of cuts (phase unwraps) that must occur for a minor displacement event</summary>
		//public const int MinCumCuts = 4;
		public const int MinCumCuts = 9;

		/// <summary>The centimeters traversed by one cut. This is a fixed characteristic of the Bumblebee; do not change this value.</summary>
		public const float CutDistanceCm = 2.6f;
	}
}
