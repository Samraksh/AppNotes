void setup() {
	Serial.begin(9600);
	////Serial.begin(119200);  
 //   delay(3000);
	//Serial.write(12);                 // Clear             

	//delay(3000);

	//Serial.write(17);                 // Turn backlight on
	//delay(5);                           // Required delay

	//Serial.print("Hello, Bill...");  // First line
	//Serial.write(12);

	//delay(1000);

	//Serial.print("Hello, Bill...");  // First line
	//Serial.write(13);                 // Form feed
	//Serial.print("from Parallax!");   // Second line

	//Serial.write(212);                // Quarter note
	//Serial.write(220);                // A tone

	//delay(10000);                        // Wait 3 seconds

	//Serial.write(212);                // Quarter note
	//Serial.write(220);                // A tone
	//delay(10000);                        // Wait 3 seconds

	//Serial.write(18);                 // Turn backlight off

}

void loop() {
	Serial.write(12);

	Serial.write(232);	// Pause
	Serial.write(214);	// Whole note
	Serial.write(215);	//	A=220

	int i;
	for (i=220; i<=231;i=i+1) {
		Serial.print(i); Serial.print(" ");
		Serial.write(i);
		delay(2*1000);
	}
	
	//Serial.write(232);	// Pause
	//Serial.write(220);	//	A
	//Serial.write(232);	// Pause
	//Serial.write(221);	//	A#
	//Serial.write(232);	// Pause
	//Serial.write(222);	//	B
	//Serial.write(232);	// Pause
	//Serial.write(223);	//	C
	
	Serial.write(232);	// Pause
	Serial.write(232);	// Pause

}
