void initializeGpios() {

	// Pin is toggled when a sample is taken
	//	Can be used by a digital/analog logic analyzer to indicate when a sample was taken
	pinMode(strobePin, OUTPUT);
	setLed(strobePin, false);

	// GPIOs for profiling
	pinMode(loopReceivedSamplePin, OUTPUT);
	setLed(loopReceivedSamplePin, true);
	delay(25);
	setLed(loopReceivedSamplePin, false);

	pinMode(profileSdPin, OUTPUT);
	setLed(profileSdPin, true);
	delay(25);
	setLed(profileSdPin, false);

	pinMode(profileSerialLed, OUTPUT);
	setLed(profileSerialLed, true);
	delay(25);
	setLed(profileSerialLed, false);

	pinMode(debugLedOut, OUTPUT);
	setLed(debugLedOut, true);
	delay(25);
	setLed(debugLedOut, false);

	// Displacement indicators
	pinMode(cutPin, OUTPUT);
	pinMode(displaceLed, OUTPUT);
	pinMode(displaceConfLed, OUTPUT);

	// Toggle them briefly
	setLed(cutPin, true);
	delay(500);
	setLed(cutPin, false);
	delay(500);
	setLed(displaceLed, true);
	delay(500);
	setLed(displaceLed, false);
	delay(500);
	setLed(displaceConfLed, true);
	delay(500);
	setLed(displaceConfLed, false);

	// Initialize pin for program stop
	pinMode(stopForSdPin, INPUT_PULLUP);

	// Initialize pin for sync message
	pinMode(syncPin, INPUT_PULLUP);

	}

void printParameter(String tag, long val, String suffix) {
	Serial.print(tag); Serial.print(val); Serial.print(suffix);
	}

