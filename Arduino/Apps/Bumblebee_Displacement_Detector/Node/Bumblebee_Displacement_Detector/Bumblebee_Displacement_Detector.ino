#include "DataStructs.h"
#include <SD.h>
#include <SPI.h>
#include <TimerOne.h>

//***** Serial Bit Rate **************************
//unsigned long const SerialBitRate = 230400;
unsigned long const SerialBitRate = 400000;	// A large value helps ensure that serial speed is not a bottleneck.

//***** Sample Rate **************************
const int DefaultSampRate = 250;
static int sampRate = DefaultSampRate;	// Samples per second
static long sampIntUSec = 1000000 / sampRate; // sample interval in micro seconds

//***** Displacement Analysis ****************
const int MinCumCuts = 6;			// Number of net cuts (positive or negative) for displacement
const int NoiseThreshold = 0;		// Samples with I and Q values below noise threshold will be ignored for cut analysis
const int snippetSize = sampRate;	// Number of samples in a snippet
static int snippetCntr = 0;			// Sample counter within snippet
static int snippetNum = 0;			// Snippet number

//***** M of N Confirmation *******************
const int ConfM = 2;	// Minimum number of displacements required for confirmation
const int ConfN = 8;	// Lifetime of a displacement, in seconds

//*********************************************
//		Serial Logging Options
//*********************************************

enum serialLogging {serialNone, serialAllInputs, serialRawInputs, serialAdjustedInputsAndDetections, serialDetects, };

// Uncomment exactly one of these
//
//const serialLogging serialLog = serialNone;		// Do not write to serial.
//const serialLogging serialLog = serialAllInputs;	// Write all inputs to serial. Useful for validation of input interpolation and averaging. NOTE: this produces too much data for 250 Hz. Must run slower. Only useful for evaluating interpolation and averaging.
const serialLogging serialLog = serialRawInputs;	// Raw inputs, without processing. Useful for validation of BumbleBee and ADC.
//const serialLogging serialLog = serialAdjustedInputsAndDetections;	// Interpolated, mean-adjusted inputs and detection & confirmation results. This is the most common option
//const serialLogging serialLog = serialDetects;	// Detection & confirmation results only.

// Uncomment exactly one of these
//
//const bool sdLog = true;		// Write detail to SD card
const bool sdLog = false;		// Do not write to SD card

//*********************************************
//		I/O Definitions
//*********************************************

// Bumblebee interface ports
const int bumbleBeeIPin = 0;   // ADC port for InPhase signal
const int bumbleBeeQPin = 1;   // ADC port for Quadrature signal

// Displacement detection output GPIOs
const int strobePin = 2;		// HIGH when sample received
const int cutPin = 3;			// HIGH when cut occurs
const int displaceLed = 5;		// HIGH when displacement detected
const int displaceConfLed = 6;	// HIGH when displacement confirmed

// Stop program input GPIO
//	When the user pulls the pin LOW (usually with a push-button switch), the program will close the SD port (if open) and stop.
const int stopDetectionPin = 7;

// Logic analyzer output GPIOs 
const int loopReceivedSamplePin = 8;
const int profileSdPin = 9;
const int profileSerialLed = 10;

// SD card GPIO output GPIOs
const int sdChipSelectPin = 4;		// Select SD Card
const int defaultChipSelectPin = 10;

// Send sync message input GPIO
const int syncPin = 11; 

// General debugging output GPIO
const int debugLedOut = 13;

//*********************************************
//		Global Variables
//*********************************************

static File sdDataFile;			// SD card datafile
bool receivedSampleSemaphore = false;	// Simulated semaphore

//***** Sample variables *************
static long sampNum = 0;				// Sample number
static SampleValPair sampledVal;		// Value actually sampled
static SampleValPair interpolatedVal;	// Interpolated value
static RunsumValPair sumVal;			// Sum of interpolated values to date
static SampleValPair currVal;			// Current, mean-adjusted sample value
static SampleValPair prevVal;			// Previous, mean-adjusted sample value
static SampleValPair MinVals;
static SampleValPair MaxVals;
static SampleValPair MinRaw;
static SampleValPair MaxRaw;

//*********************************************
//		Message Prefixes
//*********************************************
//	Note: out # prefixes must be unique and lower case
//		Similarly for in * prefixes

//***** Out: Info type prefixes
const char outColumnNamesMsgPrefix[] = "#c";
const char outSyncPrefix[] = "#s";
const char outConfMsgPrefix[] = "#p";
const char outMinMaxPrefix[] = "#x";

//***** Out: Logging type prefixes
const char outAllInputsPrefix[] = "#i,";
const char outRawInputsPrefix[] = "#r";
const char outAdjustedInputsAndDetectionsPrefix[] = "#j";
const char outDetectsPrefix[] = "#d,";

//***** In: From PC
const char inReqParamPrefix[] = "*p";

//***** confMsg: parameters
const char paramSampRate[] = "SampRate";
const char confMinCumCuts[] = "MinCumCuts";
const char confM[] = "M";
const char confN[] = "N";

//*********************************************

///
/// Setup
///
void setup() {
	Serial.begin(SerialBitRate);
	serialInputInitialize(200);

	// Set ADC to use AREF (which is wired to 3.3 v)
	analogReference(EXTERNAL);

	// Initialize all the GPIOs
	initializeGpios();

	// Initialize min and max vals
	MaxVals.I = MaxVals.Q = MaxRaw.I = MaxRaw.Q = -2147483647; // Min long (32 bit)
	MinVals.I = MinVals.I = MinRaw.I = MinRaw.Q = 2147483647;	// max long (32 bit)

	// Initialize SD, if enabled
	sdInitialize();

	// Do this first since serialAllInputs changes the sample rate, which is reported below
	char serialHeader[200];
	switch (serialLog){
		case serialNone:
			//Serial.println("Not logging to serial");
			sprintf(serialHeader, "Not logging to serial");
			break;
		case serialAllInputs:
			sampRate = 100;	// force to a lower sample rate to avoid a race condition wrt serial logging
			sampIntUSec = 1000000 / sampRate; // sample interval in micro seconds
			sprintf(serialHeader,"Logging to serial (All Inputs, for Validation)\n%s,Sample,InterpolatedI,InterpolatedQ,SumI,SumQ,SampledI,SampledQ,CurrI,CurrQ,PrevI,PrevQ,isCut,isDisp",outColumnNamesMsgPrefix);
			break;
		case serialRawInputs:
			sprintf(serialHeader,"Logging to serial (Raw Inputs)\n%s,Sample,RawI,RawQ,isCut",outColumnNamesMsgPrefix);
			break;
		case serialAdjustedInputsAndDetections:
			sprintf(serialHeader,"Logging to serial (Adjusted Inputs and Detections)\n%s,Sample,CurrI,CurrQ,IsCut,IsDisp,IsConf",outColumnNamesMsgPrefix);
			break;
		case serialDetects:
			sprintf(serialHeader,"Logging to serial (Detections)\n%s,Sample,RunCuts,Disp,Conf",outColumnNamesMsgPrefix);
			break;
		default:
			sprintf(serialHeader,"Invalid serial logging value");
			break;
		}

	Serial.println( "Compiled: " __DATE__ ", " __TIME__ ", ");
	printParameter("sampRate: ", sampRate, " ");
	printParameter("sampIntUSec: ", sampIntUSec, " ");
	Serial.println();
	printParameter("MinCumCuts: ", MinCumCuts, " ");
	printParameter("ConfM (M): ", ConfM, " ");
	printParameter("ConfN (N): ", ConfN, " ");
	Serial.println();
	Serial.println();

	Serial.println((sdLog)?"Logging to SD card":"Not logging to SD card");

	// Send parameters
	SendParamAllResponses();
	// Send header
	Serial.println(serialHeader);


	Timer1.initialize(sampIntUSec);
	Timer1.attachInterrupt(sampleTimer_tick);

	resetSnippet();

	Serial.flush();

	}

///
/// Main loop
///
void loop() {
	static bool displacementDetected;

	if (digitalRead(stopDetectionPin) == LOW) {
		Timer1.stop();
		sdDataFile.flush();
		sdDataFile.close();

		char logLine[150];
		sprintf(logLine,"\nMean-adjusted vals:\tMin: %li,%li;\tMax vals: %li,%li", MinVals.I, MinVals.Q, MaxVals.I, MaxVals.Q);
		Serial.println(logLine);
		sprintf(logLine,"Raw interpolated vals:\tMin: %li,%li;\tMax vals: %li,%li", MinRaw.I, MinRaw.Q, MaxRaw.I, MaxRaw.Q);
		Serial.println(logLine);
		sprintf(logLine,"Number of samples: %li\tRaw totals: %llu,%llu\tMeans: %li,%li", sampNum, sumVal.I, sumVal.Q, (long)(sumVal.I / sampNum), (long)(sumVal.Q / sampNum) );
		Serial.println(logLine);

		Serial.println("\nFinished");
		while(1) {}	// Stop
		}

	// We're using a simulated semaphore with a bool
	//	It is set in the timer callback and reset here.
	//	This separates the timer callback logic from the loop processing logic.

	if (receivedSampleSemaphore) {

		setLed(loopReceivedSamplePin, true);
		receivedSampleSemaphore = false;	// Reset the semaphore

		// Check for a cut
		int isCut = checkForCut();

		// Log detail to serial, if enabled
		serialAllInputsLogger(isCut, displacementDetected);

		// Log raw detail to serial, if enabled
		serialRawInputsLogger(isCut);

		// Log short detail to serial, if enabled
		serialAdjustedInputsAndDetectionsLogger(isCut, displacementDetected);

		// Log detail to SD, if enabled
		sdLogger(isCut, displacementDetected);

		// Check for displacement
		displacementDetected = DetectDisplacement();

		setLed(loopReceivedSamplePin, false);

		// If snippet boundary, increment snippet number & reset for next one
		//	Do this AFTER logging
		if (snippetCntr == snippetSize) { 
			snippetNum = snippetNum + 1;
			resetSnippet();
			}
		}

	// Check for sync button press
	static bool lastSyncPinInput = HIGH;
	bool syncPinInput = digitalRead(syncPin);
	if (syncPinInput == LOW && lastSyncPinInput == HIGH) {
		Serial.println(outSyncPrefix);
		Serial.flush();
		}
	lastSyncPinInput = syncPinInput;

	// Need delay else timer won't fire
	delay(1);
	}

void setLed(int theLed, bool val) {
	if (val) { digitalWrite(theLed, HIGH); }
	else { digitalWrite(theLed, LOW); }
	}


//void saveLast(short currValue, short *last1Value, short *last2Value){
//	*last2Value = *last1Value;
//	*last1Value = currValue;
//	}

short interpolate(short prevValue, short nextValue) {
	if (prevValue < 0 || nextValue < 0) { 
		return -1; 
		}
	return (prevValue + nextValue ) / 2;
	}


/// <summary>
/// Alternately read from I and Q.
/// </summary>
void sampleTimer_tick() {
	// Channel to read
	static int channel = bumbleBeeQPin;
	// Q values
	static short justReadQValue = -1;
	static short prevReadQValue = -1;
	// I values
	static short justReadIValue = -1;
	static short prevReadIValue = -1;

	// If we haven't finished processing the previous sample yet, don't take another
	if(receivedSampleSemaphore) { 
		return; 
		}

	// Send strobe output
	setLed(strobePin, true);
	setLed(strobePin, false);

	// Get an I or Q sample
	switch (channel) {
		case bumbleBeeIPin:
			// Sample the I channel
			justReadIValue = analogRead(channel);

			// Save the value just read for logging
			//	Unread channel value is set to negative
			sampledVal.I = justReadIValue;
			sampledVal.Q = -1;

			//Serial.print(channel); Serial.print(' ');
			//Serial.print(sampledVal.I); Serial.print(' ');
			//Serial.println(sampledVal.Q);

			// Interpolate this I value and the last one
			interpolatedVal.I = interpolate(justReadIValue, prevReadIValue);

			// Return the previous Q value
			interpolatedVal.Q = justReadQValue;

			//Serial.print("#I "); 
			//Serial.print(sampNum); Serial.print(" ");
			//Serial.print(channel); Serial.print(" ");
			////
			//Serial.print(justReadIValue); Serial.print(" ");
			//Serial.print(prevReadIValue); Serial.print(" ");
			////
			//Serial.print(justReadQValue); Serial.print(" ");
			//Serial.print(prevReadQValue); Serial.print(" ");
			////
			//Serial.print(currIValue); Serial.print(" ");
			//Serial.print(currQValue); Serial.print(" ");
			//Serial.println();

			// Save this value as the last one for future interpolation
			prevReadIValue = justReadIValue;

			// Switch channel
			channel = bumbleBeeQPin;
			break;

		case bumbleBeeQPin:
			// Sample the Q channel
			justReadQValue = analogRead(channel);

			// Save the value just read for logging
			//	Unread channel value is set to negative
			sampledVal.I = -1;
			sampledVal.Q = justReadQValue;

			//Serial.print(channel); Serial.print(' ');
			//Serial.print(sampledVal.I); Serial.print(' ');
			//Serial.println(sampledVal.Q);

			//Serial.print("#Q ");
			//Serial.print(channel); Serial.print(" ");
			//Serial.print(sampledVal.I); Serial.print(" ");
			//Serial.print(sampledVal.Q); Serial.print(" ");
			//Serial.println();

			// Return the previous I value
			interpolatedVal.I = justReadIValue;

			// Interpolate this Q value and the last one
			interpolatedVal.Q = interpolate(justReadQValue, prevReadQValue);

			//Serial.print("#Q "); 
			//Serial.print(sampNum); Serial.print(" ");
			//Serial.print(channel); Serial.print(" ");
			////
			//Serial.print(justReadIValue); Serial.print(" ");
			//Serial.print(prevReadIValue); Serial.print(" ");
			////
			//Serial.print(justReadQValue); Serial.print(" ");
			//Serial.print(prevReadQValue); Serial.print(" ");
			////
			//Serial.print(currIValue); Serial.print(" ");
			//Serial.print(currQValue); Serial.print(" ");
			//Serial.println();

			// Save this value as the last one
			prevReadQValue = justReadQValue;

			// Switch channel
			channel = bumbleBeeIPin;
			break;
		}
	// If we're waiting on interpolation, return
	if (interpolatedVal.I < 0 || interpolatedVal.Q < 0) { 
		serialRawInputsLogger(0);
		serialAllInputsLogger(0,0);
		return; 
		}
	// Indicate that the sample is ready
	sampNum = sampNum + 1;
	receivedSampleSemaphore = true;
	} 