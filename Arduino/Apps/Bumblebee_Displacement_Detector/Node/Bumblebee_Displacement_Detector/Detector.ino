// Cut analysis variables
static int currCuts = 0;
static int runCuts = 0; // Running total of cuts

// M of N confirmation state
enum Conf{No, Yes};
static Conf ConfState = No;	// Initially no confirmation


/// <summary>
/// Check for a cut. 
/// A cut occurs when the negative Q axis is crossed.
///	The crossing can be clockwise or counter-clockwise, indicating motion towards or from the Bumblebee.
/// </summary>
int checkForCut() {
	static boolean firstTime = true;
	static int prevIValue = -1;
	static int prevQValue = -1;

	prevValues.I = prevIValue;
	prevValues.Q = prevQValue;

	// Increment sums
	sumIValue += currIValue;
	sumQValue += currQValue;
	// Adjust by running mean
	meanIValue = currIValue - (sumIValue / sampNum);
	meanQValue = currQValue - (sumQValue / sampNum);

	//Serial.print("FT "); Serial.println(firstTime);
	// If not first time, check for cut
	int isCut = 0;	// flag for whether a cut occurred or not
	if (!firstTime) {
		//int crossProduct = (meanQValue * prevIValue) - (meanIValue * prevQValue);
		int crossProduct = (prevQValue * meanIValue) - (prevIValue * meanQValue);

		//Serial.print("#x3"); 
		//Serial.print(","); Serial.print(sampIValue); Serial.print(","); Serial.print(sampQValue);
		//Serial.print(","); Serial.print(sumIValue); Serial.print(","); Serial.print(sumQValue);
		//Serial.print(","); Serial.print(meanIValue); Serial.print(","); Serial.print(meanQValue);
		//Serial.print(","); Serial.print(crossProduct); 
		//Serial.print(","); Serial.print(sampNum); 
		//Serial.println();
		//Serial.print("dP "); Serial.println(crossProduct);

		// Check for clockwise cut (towards radar)
		if (crossProduct < 0 && prevIValue < 0 && meanIValue > 0) {
			isCut = +1;
			currCuts = currCuts + 1;
			runCuts = runCuts + 1;
			}
		// Check for counter-clockwise cut (away from radar)
		else if (crossProduct > 0 && prevIValue > 0 && meanIValue < 0) {
			isCut = -1;
			currCuts = currCuts - 1;
			runCuts = runCuts - 1;
			}
		}
	prevIValue = meanIValue;
	prevQValue = meanQValue;
	firstTime = false;

	if (isCut == 0)	{
		setLed(cutPin, false);
		}
	else {
		setLed(cutPin, true);
		}

	return isCut;
	}

/// <summary>
///	Check to see if we've reached a snippet boundary.
///	If so, see if the abs(sum of cuts in snippet) is at least the minimum.
///	If not, return false
///	If so, check whether MofN confirmation is satisfied and return true (displacement detected)
/// </summary>
int DetectDisplacement() {
	// See if we've reached a snippet boundary
	snippetCntr = snippetCntr + 1;
	static bool displacementDetected = false;
	if (snippetCntr < snippetSize) { return displacementDetected; }

	// If so, see if a snippet displacement has occurred
	displacementDetected = (abs(currCuts) >= MinCumCuts);

	// Set displaceLed according to whether displacement was detected
	setLed(displaceLed, displacementDetected);

	// Check for M of N confirmation
	checkMofN(snippetNum, displacementDetected);
	//	Set displaceConfLed according to whether displacement confirmation was made
	setLed(displaceConfLed, ConfState == Yes);

	// Log snippet to serial, if enabled
	serialSnippetLog(displacementDetected);

	return displacementDetected;
	}

void resetSnippet() {
	currCuts = 0;
	snippetCntr = 0;
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
	static int MofNBuff[ConfM];
	static int MofNBuffPtr = 0;
	// Initialize buffer if first time thru
	if (firstTime) {
		for (int i = 0; i < ConfM; i = i + 2) {
			MofNBuff[i] = -ConfN;
			}
		firstTime = false;
		}
	// Check if the snippet number occurred sufficiently recently
	ConfState = No;
	if (snippetNum - MofNBuff[MofNBuffPtr] < ConfN) {
		ConfState = Yes;
		}
	// If no displacement occurred then return
	if (!displacementDetected) { return; }
	// Otherwise, record the snippet number and advance the buffer pointer
	MofNBuff[MofNBuffPtr] = snippetNum;
	MofNBuffPtr = (MofNBuffPtr + 1) % ConfM;
	}



