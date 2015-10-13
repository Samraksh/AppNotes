

static String serialInputString = "";

void serialInputInitialize(int amountToPreallocate) {
	serialInputString.reserve(amountToPreallocate);
	}

///
// Called when there's serial input
///
void serialEvent() {
	while (Serial.available()) {
		char nextChar = (char)Serial.read();
		//Serial.print("$$1 "); Serial.print(serialInputString); Serial.print(" "); Serial.println(nextCharInt);
		// Ignore carriage return
		if (nextChar == '\r') { return; }
		// If other than newline, append
		if (nextChar != '\n') {
			if (serialInputString.length() >= 200) { 
				serialInputString = "";
				return; 
				}
			serialInputString += nextChar;
			//Serial.print("$$2 "); Serial.print(serialInputString); Serial.print(" "); Serial.println(nextCharInt);
			continue;
			}
		// We've hit a new line ... check what we need to do
		if (serialInputString == inReqParamPrefix) {
			setLed(debugLedOut, !digitalRead(debugLedOut));
			SendParamAllResponses();			}
		serialInputString = "";
		}
	}

void SendParamAllResponses() {
	SendParamResponse(outConfMsgPrefix,paramSampRate,sampRate);
	SendParamResponse(outConfMsgPrefix,confMinCumCuts,MinCumCuts);
	SendParamResponse(outConfMsgPrefix,confM,ConfM);
	SendParamResponse(outConfMsgPrefix,confN,ConfN);
	}

void SendParamResponse (const char *hdr, const char *label, int value) {
	char respLine[100];
	sprintf(respLine,"%s,%s,%i\n", hdr, label, value);
	Serial.print(respLine);
	Serial.flush();
	}

