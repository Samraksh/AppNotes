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

	//SampleValPair mean = WindowedMean(interpolatedVal);
	//currVal.I = interpolatedVal.I - mean.I;
	//currVal.Q = interpolatedVal.Q - mean.Q;


	// Increment sums
	sumVal.I += interpolatedVal.I;
	sumVal.Q += interpolatedVal.Q;
	// Adjust by running mean
	currVal.I = interpolatedVal.I - (sumVal.I / sampNum);
	currVal.Q = interpolatedVal.Q - (sumVal.Q / sampNum);

	// If not first time, check for cut
	int isCut = 0;	// flag for whether a cut occurred or not
	if (!firstTime) {
		// Calculate the cross-product of the vectors.
		//	Positive is counter-clockwise, negative is clockwise
		long crossProduct = (prevVal.Q * currVal.I) - (prevVal.I * currVal.Q);	

		// Check for clockwise cut (away from radar)
		//	Cut the negative Q axis iff the I value changes from negative to positive
		if (crossProduct < 0 && prevVal.I < 0 && currVal.I > 0) {
			isCut = +1;
			}
		// Check for clockwise cut (towards radar)
		//	Cut the negative Q axis iff the I value changes from positive to negative
		else if (crossProduct > 0 && prevVal.I > 0 && currVal.I < 0) {
			isCut = -1;
			}
		// Sum the cuts
		currCuts = currCuts + isCut;
		runCuts = runCuts + isCut;
		}

	prevVal = currVal;
	firstTime = false;

	setLed(cutPin, isCut == 0);

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
	if (snippetCntr < snippetSize) { 
		return displacementDetected; 
		}

	// If so, see if a snippet displacement has occurred
	displacementDetected = (abs(currCuts) >= MinCumCuts);

	// Set displaceLed according to whether displacement was detected
	setLed(displaceLed, displacementDetected);

	// Check for M of N confirmation
	checkMofN(snippetNum, displacementDetected);
	//	Set displaceConfLed according to whether displacement confirmation was made
	setLed(displaceConfLed, ConfState == Yes);

	// Log snippet to serial, if enabled
	serialDetectsLogger(displacementDetected);

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
/// <param name="snippetN">Snippet Number</param>
/// <param name="displacementDetected">true iff displacement detection has occurred</param>
void checkMofN(int snippetN, bool displacementDetected) {
	static bool firstTime = true;
	static int MofNBuff[ConfM];
	static int MofNBuffPtr = 0;
	// Initialize buffer if first time thru
	if (firstTime) {
		for (int i = 0; i < ConfM; i = i + 1) {
			MofNBuff[i] = -ConfN;
			}
		firstTime = false;
		}
	// If displacement detected, record it
	if (displacementDetected) { 
		MofNBuff[MofNBuffPtr] = snippetN;
		MofNBuffPtr = (MofNBuffPtr + 1) % ConfM;
		}
	// Check if the snippet number occurred sufficiently recently
	ConfState = No;
	if (snippetN - MofNBuff[MofNBuffPtr] < ConfN) {
		ConfState = Yes;
		}
	}



