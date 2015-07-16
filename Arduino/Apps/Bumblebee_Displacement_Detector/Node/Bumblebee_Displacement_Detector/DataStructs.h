// DataStructs.h

#ifndef _DATASTRUCTS.H
	#define _DATASTRUCTS.H

	#if defined(ARDUINO) && ARDUINO >= 100
		#include "arduino.h"
	#else
		#include "WProgram.h"
	#endif

//************************************
//		Program data structs.
//			These have to be in a separate header file.
//			See http://stackoverflow.com/questions/17493354/arduino-struct-pointer-as-function-parameter
//************************************

	// Holds the I-Q pair for a sample
	typedef struct SampleValPair {
		//long I;
		//long Q;
		int I;
		int Q;
		};

	// Holds the I-Q pair for the running sum of sample values
	typedef struct RunsumValPair {
		unsigned long long I;
		unsigned long long Q;
		};

	//// Holds the I-Q pair for mean
	//typedef struct MeanValPair {
	//	long I;
	//	long Q;
	//	};

#endif


