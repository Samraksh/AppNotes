#include <SD.h>
#include <SPI.h>
#include <TimerOne.h>

//***** Sample Rate **************************
const int sampRate = 250;	// Samples per second

//***** Cut Analysis *************************
const int MinCumCuts = 6;			// Number of net cuts (positive or negative) for displacement
const int snippetSize = sampRate;	// Number of samples in a snippet

//***** M of N Confirmation *******************
const int ConfM = 2;	// Minimum number of displacements required for confirmation
const int ConfN = 8;	// Lifetime of a displacement, in seconds

//// ***** Current sample ***********************
//int sampIValue = 0;
//int sampQValue = 0;

//*********************************************


// Values for serial logging
enum serialLogging {serialNone, serialDetail, serialSnippet};

// Uncomment exactly one of these
//
//const serialLogging serialLog = serialNone;		// Do not write to serial
const serialLogging serialLog = serialDetail;		// Write detail to serial
//const serialLogging serialLog = serialSnippet;		// Write summary to serial

// Uncomment exactly one of these
//
//const bool sdLog = true;		// Write detail to SD card
const bool sdLog = false;		// Do not write to SD card

// ****************************** I/O Definitions

const long sampIntUSec = 1000000 / sampRate; // sample interval in micro seconds

// Bumblebee interface ports
const int bumbleBeeQPin = 0;   // ADC port for Quadrature signal
const int bumbleBeeIPin = 1;   // ADC port for InPhase signal

// Displacement detection output GPIOs
const int strobePin = 2;		// HIGH when sample received
const int cutPin = 3;			// HIGH when cut occurs
const int displaceLed = 5;		// HIGH when displacement detected
const int displaceConfLed = 6;	// HIGH when displacement confirmed

// Stop program input GPIO
//	Only necessary if SD output is selected. 
//	When the user pulls the pin LOW (usually with a push-button switch), the program will close the SD port and stop.
const int stopForSdPin = 7;

// Logic analyzer output GPIOs 
const int loopReceivedSamplePin = 8;
const int profileSdPin = 9;
const int profileSerialLed = 10;

// SD card GPIO output pins
const int sdChipSelectPin = 4;		// Select SD Card
const int defaultChipSelectPin = 10;

const int debugLedOut = 13;			// GPIO pin for general debugging

// **************************** Global variables

static File sdDataFile;			// SD card datafile
bool receivedSampleSemaphore = false;	// Simulated semaphore

//***** Current Sample variables *************
static int currIValue;	// Current I value
static int currQValue;	// Current Q value
static long sampNum = 0;	// Sample number
static long sumIValue = 0;	// Sum of I values to date
static long sumQValue = 0;	// Sum of Q values to date
static long compQValue;
static long compIValue;
//*********************************************

//******* Message prefixes ***********
const String outColumnNamesMsgPrefix = "#1,";
const String outSnippetDataMsgPrefix = "#2,";
const String outParamMsgPrefix = "#3,";

const String inReqParamPrefix = "*1";

const String paramSampRate = "SampRate";
const String paramMinCumCuts = "MinCumCuts";
const String paramM = "M";
const String paramN = "N";


//*********************************************

///
/// Setup
///
void setup() {
	Serial.begin(115200);
	serialInputInitialize(200);

	// Initialize all the GPIOs
	initializeGpios();

	// Initialize SD, if enabled
	sdInitialize();

	Serial.println( "Compiled: " __DATE__ ", " __TIME__ ", ");

	printParameter("sampRate: ", sampRate, " ");
	printParameter("sampIntUSec: ", sampIntUSec, " ");
	Serial.println();
	printParameter("MinCumCuts: ", MinCumCuts, " ");
	printParameter("ConfM (M): ", ConfM, " ");
	printParameter("ConfN (N): ", ConfN, " ");
	Serial.println();
	Serial.println();
	if(sdLog) {
		Serial.println("Logging to SD card");
		}
	else {
		Serial.println("Not logging to SD card");
		}
	if(serialLog == serialDetail) {
		Serial.println("Logging to serial (detail)");
		Serial.print(outColumnNamesMsgPrefix);
		Serial.println("Sample,I,Q,SumI,SumQ,CompI,CompQ,IsCut,CurrCuts,RunCuts,Disp,Conf");
		}
	else if (serialLog == serialSnippet) {
		Serial.println("Logging to serial (shippet)");
		Serial.print(outColumnNamesMsgPrefix);
		Serial.println("Sample,RunCuts,Disp,Conf");
		}
	else {
		Serial.println("Not logging to serial");
		}

	Timer1.initialize(sampIntUSec);
	Timer1.attachInterrupt(sampleTimer_tick);

	resetSnippet();
	}

///
/// Main loop
///
void loop() {
	if (digitalRead(stopForSdPin) == LOW) {
		Timer1.stop();
		sdDataFile.flush();
		sdDataFile.close();
		Serial.println("Finished");
		while(1) {}	// Stop
		}

	// We're using a simulated semaphore with a bool
	//	It is set in the timer callback and reset here.
	//	As contrasted with a real semaphore, this has to be set and reset in the code.
	//	This separates the callback logic from the loop processing logic.
	if (receivedSampleSemaphore) {
		setLed(loopReceivedSamplePin, true);
		receivedSampleSemaphore = false;	// Reset the semaphore

		// Check for a cut
		int isCut = checkForCut();

		//Serial.print("#x1,"); Serial.print(currIValue); Serial.print(","); Serial.print(currQValue);
		//Serial.println();

		// Check for displacement
		bool displacementDetected = DetectDisplacement();

		// Log detail to serial, if enabled
		serialDetailLogger(isCut, displacementDetected);

		// Log detail to SD, if enabled
		sdLogger(isCut, displacementDetected);

		}

	setLed(loopReceivedSamplePin, false);

	// Need delay else timer won't fire
	delay(1);
	}

void sendResponse (String hdr, String label, int value) {
	Serial.print(hdr);
	Serial.print(label); Serial.print(",");
	Serial.println(value);
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
	if(receivedSampleSemaphore) { return; }

	// Send strobe output
	setLed(strobePin, true);
	setLed(strobePin, false);

	// Get an I or Q sample
	switch (channel) {
		case bumbleBeeQPin:
			// Sample the Q channel
			justReadQValue = analogRead(channel);

			// Return the previous I value
			currIValue = justReadIValue;

			// Interpolate this Q value and the last one
			currQValue = interpolate(justReadQValue, prevReadQValue);

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
		case bumbleBeeIPin:
			// Sample the I channel
			justReadIValue = analogRead(channel);

			// Interpolate this I value and the last one
			currIValue = interpolate(justReadIValue, prevReadIValue);

			// Return the previous Q value
			currQValue = justReadQValue;

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
		}
	// If we don't yet have real I and Q values, return
	if (currIValue < 0 || currQValue < 0) { 
		return; 
		}
	// Indicate that the sample is ready
	sampNum = sampNum + 1;
	receivedSampleSemaphore = true;
	}