//***** M of N Confirmation *******************
const int MinMinorDisplacements = 2;			// M
const int NumSecondsDisplacementLifetime = 8;	// N
const char MofNStateInactive = 'I';
const char MofNStateActive = 'A';
static char MofNConfState = MofNStateInactive;
static char MofNConfPrevState = MofNStateInactive;
//*********************************************


void setup()
{

  /* add setup code here */

}

void loop()
{

  /* add main program code here */

}

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

