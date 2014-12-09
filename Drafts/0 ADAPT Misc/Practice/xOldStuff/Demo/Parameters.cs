using System;

namespace ParameterClass
{
    class Parameters
    {
	// required TestRig parameters
	public bool useLogic = false;
	public double sampleTimeMs = 4000;
	public double sampleFrequency = 4000000;
	public bool useExecutable = false;
	public string executableName = "example.exe";
	public int testRunTimeMs = 9000;
	public bool useMatlabAnalysis = false;
	public string matlabScriptName = "analyze.m";
	public bool usePowershellAnalysis = false;
	public string powershellName = "analyze.ps1";
	// Do not change text format above this point
	
	// test specific parameters
	public double frequency = 2.5;
	public double upperAllowedFrequency = 2.7;
	public double lowerAllowedFrequency = 2.3;
	public double expectedFrequency = 2.5;
    }
}
