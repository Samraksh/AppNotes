//#include <osw_mini.h>
//#include <os_wrap.h>
#include <SD.h>
#include <SPI.h>
#include <TimerOne.h>

//const bool serialLog = true;	// Whether or not to write a log to serial
const bool serialLog = false;	// Whether or not to write a log to serial

const bool sdLog = true;		// Whether or not to log to SD card
//const bool sdLog = false;		// Whether or not to log to SD card

static File sdDataFile;			// SD card datafile

const int sampRate = 250;   // samples per second
//const long sampRate = 100;   // samples per second
//const long sampFreq = sampRate * 2;  // frequency for interleaved sampling
const long sampFreq = sampRate;  // frequency for interleaved sampling
const long sampIntUSec = 1000000 / sampFreq; // sample interval in micro seconds

const int bumbleBeeQPin = 0;   // analog port assigned to Quadrature
const int bumbleBeeIPin = 1;   // analog port assigned to InPhase

const int strobeOut = 2;	// GPIO pin for strobing on sample
const int sdChipSelect = 4;	// Select SD Card
const int displaceOut = 5;  // HIGH when displacement detected
const int displaceConfOut = 6; // HIGH when displacement confirmed
const int stopPin = 7;		// Stop program
const int profile8 = 8;	// Use for logic analyzer profiling
const int profile9 = 9;		// Use for logic analyzer profiling

const int defaultChipSelectPin = 10;
const int led = 13;			// GPIO pin for LED control

bool receivedVal = false;	// Fake sempahore

//***** Current Sample variables *************
static int currIValue;	// Current I value
static int currQValue;	// Current Q value
static long sampNum = 0;	// Sample number
static long sumIValue = 0;	// Sum of I values to date
static long sumQValue = 0;	// Sum of Q values to date
//*********************************************

//***** Snippet & Cut Analysis ****************
const int MinCumCuts = 6;
static int currCuts = 0;
static int runCuts = 0; // Running total of cuts
static int snippetCntr = 0;
const int snippetSize = sampRate;
static int snippetNum = 0;
//*********************************************

//***** M of N Confirmation *******************
const int MinMinorDisplacements = 2;			// M
const int NumSecondsDisplacementLifetime = 8;	// N
const char MofNStateInactive = 'I';
const char MofNStateActive = 'A';
static char MofNConfState = MofNStateInactive;
static char MofNConfPrevState = MofNStateInactive;
//*********************************************

///
/// Setup
///
void setup() {
	Serial.begin(115200);

	// Pin is toggled when a sample is taken
	//	Can be used by a digital/analog logic analyzer to indicate when a sample was taken
	pinMode(strobeOut, OUTPUT);
	digitalWrite(strobeOut, LOW);

	// Profile GPIOs
	pinMode(profile8, OUTPUT);
	digitalWrite(profile8, HIGH);
	delay(25);
	digitalWrite(profile8, LOW);

	pinMode(profile9, OUTPUT);
	digitalWrite(profile9, HIGH);
	delay(25);
	digitalWrite(profile9, LOW);

	// Displacement indicators
	pinMode(displaceOut, OUTPUT);
	pinMode(displaceConfOut, OUTPUT);
	// Toggle them briefly
	digitalWrite(displaceOut, HIGH);
	delay(500);
	digitalWrite(displaceOut, LOW);
	delay(500);
	digitalWrite(displaceConfOut, HIGH);
	delay(500);
	digitalWrite(displaceConfOut, LOW);

	// LED used for user feedback
	pinMode(led, OUTPUT);
	digitalWrite(led, LOW);

	pinMode(stopPin, INPUT_PULLUP);

	if (sdLog) {
		char sdFileName[] = "datalog.dat";

		Serial.print("Initializing SD card...");
		// make sure that the default chip select pin is set to
		// output, even if you don't use it:
		pinMode(defaultChipSelectPin, OUTPUT);

		// see if the card is present and can be initialized:
		if (!SD.begin(sdChipSelect)) {
			Serial.println("SD card initialization failed or not present");
			// don't do anything more:
			return;
			}

		// Delete the file if present
		if (SD.exists(sdFileName)) {
			SD.remove(sdFileName);
			}

		//sdDataFile = SD.open("datalog.txt", FILE_WRITE);
		sdDataFile = SD.open(sdFileName, O_CREAT | O_WRITE);

		if (!sdDataFile) {
			Serial.println("Error opening SD data file for write");
			return;
			}

		Serial.println("SD card initialized and output file open");
		}

	Serial.println( "Compiled: " __DATE__ ", " __TIME__ ", ");

	print3("sampRate: ", sampRate, " ");
	print3("sampFreq: ", sampFreq, " ");
	print3("sampIntUSec: ", sampIntUSec, " ");
	Serial.println();
	print3("MinCumCuts: ", MinCumCuts, " ");
	print3("MinMinorDisplacements (M): ", MinMinorDisplacements, " ");
	print3("NumSecondsDisplacementLifetime (N): ", NumSecondsDisplacementLifetime, " ");
	Serial.println();
	Serial.println();
	if(sdLog) {
		Serial.println("Logging to SD card");
		}
	else {
		Serial.println("Not logging to SD card");
		}
	if(serialLog) {
		Serial.println("Logging to serial");
		Serial.println("Sample,I,Q,CurrCuts,RunCuts,Disp,Conf");
		}
	else {
		Serial.println("Not logging to serial");
		}

	Timer1.initialize(sampIntUSec);
	Timer1.attachInterrupt( sampleTimer_tick );

	resetSnippet();
	}

void print3(String tag, long val, String suffix) {
	Serial.print(tag); Serial.print(val); Serial.print(suffix);
	}

typedef struct sampVal_t {
	long sampNum;
	word iValue;
	word qValue;
	word disp;
	word mofN;
	};

typedef union packet_t{
	sampVal_t typed;
	byte packetBytes[sizeof(sampVal_t)];
	};
packet_t packet;

///
/// Main loop
///
void loop() {
	if (digitalRead(stopPin) == LOW) {
		Timer1.stop();
		sdDataFile.flush();
		sdDataFile.close();
		Serial.println("Finished");
		while(1){}	// Stop
		}
	if (receivedVal) {
		Serial.print("#L "); Serial.println(sampNum); 
		digitalWrite(profile8, HIGH);
		receivedVal = false;

		// Check for a cut
		checkForCut();
		// See if we've reached a snippet boundary
		snippetCntr = snippetCntr + 1;
		static bool displacementDetected = false;
		if (snippetCntr >= snippetSize) {
			// If so, see if a snippet displacement has occurred
			displacementDetected = (abs(currCuts) >= MinCumCuts);
			setLed(displaceOut, displacementDetected);
			// Check for M of N confirmation
			checkMofN(snippetNum, displacementDetected);
			setLed(displaceConfOut, MofNConfState == MofNStateActive);
			// Increment snippet number & reset for next one
			snippetNum = snippetNum + 1;
			resetSnippet();
			}

		// Log sample & results to serial
		if (serialLog) {
			Serial.print(sampNum); 
			Serial.print(','); Serial.print(currIValue); 
			Serial.print(','); Serial.print(currQValue); 

			// Set detection values
			String dispLog = "";
			if (displacementDetected) { dispLog = "*"; }
			String dispConfLog = "";
			if (MofNConfState == MofNStateActive) { dispConfLog = "*"; }
			// Log them
			Serial.print(','); Serial.print(currCuts);
			Serial.print(','); Serial.print(runCuts);
			Serial.print(','); Serial.print(dispLog);
			Serial.print(','); Serial.print(dispConfLog);
			Serial.println();
			}
		// Log sample & results to SD
		if(sdLog) {
			digitalWrite(profile9, HIGH);
			packet.typed.sampNum = sampNum;
			packet.typed.iValue = currIValue;
			packet.typed.qValue = currQValue;
			if (displacementDetected) { packet.typed.disp = 1; }
			else {packet.typed.disp = 0;}
			if(MofNConfState == MofNStateActive) { packet.typed.mofN = 1; }
			else { packet.typed.mofN = 0;}


			sdDataFile.write(packet.packetBytes, sizeof(packet.packetBytes));
			digitalWrite(profile9, LOW);
			}

		}
	digitalWrite(profile8, LOW);
	delay(1);	// Need delay else timer won't fire
	}

void setLed(int theLed, bool val) {
	if (val) { digitalWrite(theLed, HIGH); }
	else { digitalWrite(theLed, LOW); }
	}

void checkForCut() {
	static boolean firstTime = true;
	static int prevQValue = -1;
	static int prevIValue = -1;
	int compQValue;
	int compIValue;
	// Adjust by running mean
	compQValue = currQValue - (sumQValue / sampNum);
	compIValue = currIValue - (sumIValue / sampNum);
	//Serial.print("FT "); Serial.println(firstTime);
	// If not first time, check for cut
	if (firstTime == 0) {
		int dotProduct = (compQValue * prevIValue) - (compIValue * prevQValue);
		//Serial.print("dP "); Serial.println(dotProduct);
		// Check for clockwise cut
		if (dotProduct < 0 && prevQValue < 0 && compQValue > 0) {
			currCuts = currCuts + 1;
			runCuts = runCuts + 1;
			}
		// Check for counter-clockwise cut
		else if (dotProduct > 0 && prevQValue > 0 && compQValue < 0) {
			currCuts = currCuts - 1;
			runCuts = runCuts - 1;
			}
		}
	prevQValue = compQValue;
	prevIValue = compIValue;
	firstTime = false;
	}


/// <summary>
/// Check if, in the last N snippets, there were M snippets in which displacement occurred
/// </summary>
/// <remarks>
/// Buff is a circular buffer of size M. 
///     It is initialized to values guaranteed to be sufficiently distant in the past so as to not trigger confirmation.
/// The method is called once per snippet (in this case, once per second). 
///     It checks to see if the current buffer value is sufficiently recent or not and sets the confirmation state accordingly.
/// If displacement occurred during this snippet, 
///     then the snippet number is saved and the buffer pointer advances.
/// When we do a comparison in UpdateDetectionState, the current buffer entry is the oldest snippet where displacement occurred.
///     Since all the other snippets are more recent, it suffices to see if the current one occurred within N snippets.
/// </remarks>
/// <param name="snippetNum">Snippet Number</param>
/// <param name="displacementDetected">true iff displacement detection has occurred</param>
void checkMofN(int snippetNum, bool displacementDetected) {
	static bool firstTime = true;
	static int MofNBuff[MinMinorDisplacements];
	static int MofNBuffPtr = 0;
	// Initialize buffer if first time thru
	if (firstTime) {
		for (int i = 0; i < MinMinorDisplacements; i = i + 2) {
			MofNBuff[i] = -NumSecondsDisplacementLifetime;
			}
		firstTime = false;
		}
	// Save current state so we can check if there's been a change
	MofNConfPrevState = MofNConfState;
	// Check if the snippet number occurred sufficiently recently
	MofNConfState = MofNStateInactive;
	if (snippetNum - MofNBuff[MofNBuffPtr] < NumSecondsDisplacementLifetime) {
		MofNConfState = MofNStateActive;
		}
	// If no displacement occurred then return
	if (!displacementDetected) { return; }
	// Otherwise, record the snippet number and advance the buffer pointer
	MofNBuff[MofNBuffPtr] = snippetNum;
	MofNBuffPtr = (MofNBuffPtr + 1) % MinMinorDisplacements;
	}

void resetSnippet() {
	currCuts = 0;
	snippetCntr = 0;
	}

void saveLast(short currValue, short *last1Value, short *last2Value){
	*last2Value = *last1Value;
	*last1Value = currValue;
	}

short interpolate(short last1Value, short last2Value) {
	if (last1Value < 0 || last2Value < 0) { 
		return -1; 
		}
	return (last1Value + last2Value ) / 2;
	}


/// --------------------------
/// Sample Timer callback
/// --------------------------
void sampleTimer_tick() {
	// static values that are preserved between function calls
	static int channel = bumbleBeeQPin;
	static short last1QValue = -1;
	static short last2QValue = -1;
	static short last1IValue = -1;
	static short last2IValue = -1;

	if(receivedVal) {
		digitalWrite(led, HIGH);
		Serial.println("#r");
		return;
		}
	digitalWrite(led, LOW);

	switch (channel) {
		case bumbleBeeQPin:
			// Sample the Q channel
			//	Interpolate I
			currQValue = analogRead(channel);
			// Send strobe output
			digitalWrite(strobeOut, HIGH);
			digitalWrite(strobeOut, LOW);

			saveLast(currQValue, &last1QValue, &last2QValue);
			currIValue = interpolate(last1IValue, last2IValue);

			//Serial.print("Q: currQValue, last1QValue, last2QValue: ");
			//Serial.print(currQValue); Serial.print(", "); Serial.print(last1QValue); Serial.print(", "); Serial.print(last2QValue); Serial.println();
			//Serial.print(".  currIValue, last1IValue, last2IValue: ");
			//Serial.print(currIValue); Serial.print(", "); Serial.print(last1IValue); Serial.print(", "); Serial.print(last2IValue); Serial.println();
			//Serial.println();

			channel = bumbleBeeIPin;
			break;
		case bumbleBeeIPin:
			// Sample the I channel
			//	Interpolate Q
			currIValue = analogRead(channel);
			// Send strobe output
			digitalWrite(strobeOut, HIGH);
			digitalWrite(strobeOut, LOW);

			saveLast(currIValue, &last1IValue, &last2IValue);
			currQValue = interpolate(last1QValue, last2QValue);

			//Serial.print("I: currIValue, last1IValue, last2IValue: ");
			//Serial.print(currIValue); Serial.print(", "); Serial.print(last1IValue); Serial.print(", "); Serial.print(last2IValue); Serial.println();
			//Serial.print(".  currQValue, last1QValue, last2QValue: ");
			//Serial.print(currQValue); Serial.print(", "); Serial.print(last1QValue); Serial.print(", "); Serial.print(last2QValue); Serial.println();
			//Serial.println();

			channel = bumbleBeeQPin;
			break;
		}
	// Set sempahore if initial interpolation complete
	if (last1IValue >= 0 && last2IValue >= 0 && last1QValue >= 0 && last2QValue >= 0) {
		sumIValue = sumIValue + currIValue;
		sumQValue = sumQValue + currQValue;
		sampNum = sampNum + 1;
		//Serial.print("#C "); Serial.print(sampNum); Serial.print(" ");
		//Serial.print(last1IValue); Serial.print(" ");
		//Serial.print(last2IValue); Serial.print(" ");
		//Serial.print(last1QValue); Serial.print(" ");
		//Serial.print(last2QValue); Serial.print(" ");
		receivedVal = true;
		}
	}