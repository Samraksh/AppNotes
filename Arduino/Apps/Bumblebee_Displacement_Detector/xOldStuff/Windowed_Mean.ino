#include "DataStructs.h"

//const int NumWindowMilliSeconds = 1000;
const int NumMeanVals = 50; 
//const int NumMeanVals = 10; 
static MeanValPair MeanBuff[NumMeanVals];

//static int MeanBuffActualSize = 0;
static int MeanBuffCurrLen = 0;		// Current length. Max is MeanBuffActualSize. Handles initialization when buffer is only partially filled.
static int MeanBuffPtr = 0;		// Next position to write. Modulo MeanBuffActualSize.
static MeanValPair MeanBuffSum;	// Sum of values in buffer

SampleValPair WindowedMean(SampleValPair currSample) {
	//if (MeanBuffActualSize == 0) {
	//	MeanBuffActualSize = min((sampRate * NumWindowMilliSeconds) / 1000, NumMeanVals);
	//	}
	// Subtract the last sample written
	int earliestBuffPtr = (MeanBuffPtr + NumMeanVals - 1) % NumMeanVals;
	MeanBuffSum.I -= MeanBuff[earliestBuffPtr].I;
	MeanBuffSum.Q -= MeanBuff[earliestBuffPtr].Q;

	// Write the current sample, increment the pointer and increment buffer length
	MeanBuff[MeanBuffPtr].I = (long)currSample.I;
	MeanBuff[MeanBuffPtr].Q = (long)currSample.Q;
	MeanBuffPtr = (MeanBuffPtr + 1) % NumMeanVals;
	if (MeanBuffCurrLen < NumMeanVals) {
		MeanBuffCurrLen++;
		}

	// Add in the sample values
	MeanBuffSum.I += currSample.I;
	MeanBuffSum.Q += currSample.Q;

	// Calculate the mean & return it
	SampleValPair mean;
	mean.I = MeanBuffSum.I / MeanBuffCurrLen;
	mean.Q = MeanBuffSum.Q / MeanBuffCurrLen;
	return mean;
	}
