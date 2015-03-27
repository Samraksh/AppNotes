
#include <SD.h>
#include <SPI.h>

const int led = 13;			// GPIO pin for LED control
const int sdWrite = 8;  // 

const int sdChipSelect = 4;	// Select SD Card
const int defaultChipSelectPin = 10;
static File sdDataFile;			// SD card datafile


void setup()
	{
	Serial.begin(115200);

	pinMode(sdWrite, OUTPUT);

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

	Serial.println( "Compiled: " __DATE__ ", " __TIME__ ", ");

	}

typedef struct sampVal_t {
	long sampNum;
	word iValue;
	word qValue;
	};
//sampVal_t sampleValue;

typedef union packet_t{
	sampVal_t typed;
	byte packetBytes[sizeof(sampVal_t)];
	};
packet_t packet;


void loop() {
	Serial.println("Starting");
	
	for (int i = 0; i < 5000; i++) {
		if ((i % 10) == 0) { Serial.println(i); }

		digitalWrite(sdWrite, HIGH);

		packet.typed.sampNum = i;
		packet.typed.iValue = i + 1;
		packet.typed.qValue = i + 2;
		sdDataFile.write(packet.packetBytes, sizeof(packet.packetBytes));

		digitalWrite(sdWrite, LOW);
		}
	sdDataFile.close();
	Serial.println("Done");
	while (1) {}
	}
