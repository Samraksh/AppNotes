// Logging functions

void serialDetectsLogger(bool displacementDetected){			
	// Log snippet results to serial
	if(serialLog != serialDetects) { 
		return; 
		} 
	setLed(profileSerialLed, true);
	Serial.print(outDetectsPrefix);
	Serial.print(sampNum); 
	Serial.print(','); Serial.print(runCuts);
	Serial.print(','); Serial.print(displacementDetected);
	Serial.print(','); Serial.print(ConfState == Yes);
	Serial.println();
	Serial.flush();
	setLed(profileSerialLed, false);
	}

void serialRawInputsLogger() {
	// Log raw samples, if enabled
	if (serialLog != serialRawInputs) {
		return;
		}
	char logLine[100];
	sprintf(logLine,"%s,%li,%i,%i\n",outRawInputsPrefix,sampNum,sampledVal.I,sampledVal.Q);
	Serial.print(logLine);
	Serial.flush();
	}

void serialAllInputsLogger(int isCut, bool displacementDetected) {
	// Log detail sample & results to serial
	if (serialLog != serialAllInputs) { 
		return; 
		}
	setLed(profileSerialLed, true);

	Serial.print(outAllInputsPrefix);
	Serial.print(sampNum); 
	Serial.print(','); Serial.print(interpolatedVal.I); 
	Serial.print(','); Serial.print(interpolatedVal.Q); 

	Serial.print(','); SerialLLPrint(sumVal.I,10); 
	Serial.print(','); SerialLLPrint(sumVal.Q,10); 
	//Serial.print(','); Serial.print(meanVal.I); 
	//Serial.print(','); Serial.print(meanVal.Q); 

	Serial.print(','); Serial.print(sampledVal.I); 
	Serial.print(','); Serial.print(sampledVal.Q); 
	Serial.print(','); Serial.print(currVal.I); 
	Serial.print(','); Serial.print(currVal.Q); 
	Serial.print(','); Serial.print(prevVal.I); 
	Serial.print(','); Serial.print(prevVal.Q); 
	Serial.println();
	Serial.flush();
	setLed(profileSerialLed, false);
	}

void serialAdjustedInputsAndDetectionsLogger(int isCut, bool displacementDetected) {
	// Log detail sample & results to serial
	if (serialLog != serialAdjustedInputsAndDetections) { 
		return; 
		}
	setLed(profileSerialLed, true);

	char logLine[100];
	sprintf(logLine,"%s,%li,%i,%i,%i,%i,%i\n",outAdjustedInputsAndDetectionsPrefix,sampNum,currVal.I,currVal.Q,isCut,displacementDetected,ConfState==Yes);
	Serial.print(logLine);

	//Serial.print(outAdjustedInputsAndDetectionsPrefix); Serial.print("*,");
	//Serial.print(sampNum); 
	//Serial.print(','); Serial.print(currVal.I); 
	//Serial.print(','); Serial.print(currVal.Q); 
	//Serial.print(','); Serial.print(isCut);
	//Serial.print(','); Serial.print(displacementDetected);
	//Serial.print(','); Serial.print(ConfState == Yes);
	//Serial.println();

	Serial.flush();
	setLed(profileSerialLed, false);
	}


void sdInitialize()	{
	if (!sdLog) { return; }
	char sdFileName[] = "datalog.dat";

	Serial.print("Initializing SD card...");
	// make sure that the default chip select pin is set to
	// output, even if you don't use it:
	pinMode(defaultChipSelectPin, OUTPUT);

	// see if the card is present and can be initialized:
	if (!SD.begin(sdChipSelectPin)) {
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


// Definitions for SD card output
//	Structure for packet
typedef struct sampVal_t {
	long sampNum;
	word iValue;
	word qValue;
	word isCut;
	word disp;
	word mofN;
	};
//	Union that lets us map value onto the packet
typedef union packet_t{
	sampVal_t typed;
	byte packetBytes[sizeof(sampVal_t)];
	};
//	The packet
packet_t packet;

void sdLogger(int isCut, bool displacementDetected){
	// Log detail sample & results to SD
	if(!sdLog) { return; }
	setLed(profileSdPin, true);
	packet.typed.sampNum = sampNum;
	packet.typed.iValue = interpolatedVal.I;
	packet.typed.qValue = interpolatedVal.Q;
	packet.typed.isCut = isCut;
	if (displacementDetected) { packet.typed.disp = 1; }
	else {packet.typed.disp = 0;}
	if(ConfState == Yes) { packet.typed.mofN = 1; }
	else { packet.typed.mofN = 0;}
	sdDataFile.write(packet.packetBytes, sizeof(packet.packetBytes));
	setLed(profileSdPin, true);
	}

