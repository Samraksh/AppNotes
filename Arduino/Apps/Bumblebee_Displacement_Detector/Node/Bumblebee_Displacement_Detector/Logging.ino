// Logging functions

void serialSnippetLog(bool displacementDetected){			
	// Log snippet results to serial
	if(serialLog != serialSnippet) { 
		return; 
		} 
	setLed(profileSerialLed, true);
	Serial.print(outSnippetDataMsgPrefix);
	Serial.print(sampNum); 
	Serial.print(','); Serial.print(runCuts);
	Serial.print(','); Serial.print(displacementDetected);
	Serial.print(','); Serial.print(ConfState == Yes);
	Serial.println();
	setLed(profileSerialLed, false);
	}

void serialDetailLogger(int isCut, bool displacementDetected) {

	// Log detail sample & results to serial
	if (serialLog != serialDetail) { 
		return; 
		}
	setLed(profileSerialLed, true);
	Serial.print("$2,");
	Serial.print(sampNum); 
	Serial.print(','); Serial.print(currIValue); 
	Serial.print(','); Serial.print(currQValue); 
	// Debugging values
	Serial.print(','); Serial.print(sumIValue); 
	Serial.print(','); Serial.print(sumQValue); 
	Serial.print(','); Serial.print(compIValue); 
	Serial.print(','); Serial.print(compQValue); 

	Serial.print(','); Serial.print(isCut);
	Serial.print(','); Serial.print(currCuts);
	Serial.print(','); Serial.print(runCuts);
	Serial.print(','); Serial.print(displacementDetected);
	Serial.print(','); Serial.print(ConfState == Yes);
	Serial.println();
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
	packet.typed.iValue = currIValue;
	packet.typed.qValue = currQValue;
	packet.typed.isCut = isCut;
	if (displacementDetected) { packet.typed.disp = 1; }
	else {packet.typed.disp = 0;}
	if(ConfState == Yes) { packet.typed.mofN = 1; }
	else { packet.typed.mofN = 0;}
	sdDataFile.write(packet.packetBytes, sizeof(packet.packetBytes));
	setLed(profileSdPin, true);
	}

