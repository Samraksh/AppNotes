/*--------------------------------------------------------------------
 * Persistent Object Storage: app note for the eMote .NOW
 * (c) 2013 The Samraksh Company
 * 
 * Version history
 *  1.0: initial release
 ---------------------------------------------------------------------*/

using System;
using System.Threading;
using System.Collections;
using Microsoft.SPOT;
using Samraksh.SPOT.NonVolatileMemory;

using Samraksh.AppNote.Utility;
using Math = System.Math;

namespace Samraksh.AppNote.DotNOW.PersistentObjectStorage {
    /// <summary>
    /// Exercise the DataStore persistent storage. 
    ///     The objectives are to create new persistent data items, update them, and later recover them directly.
    ///     Recovering directly simulates an application that approaches the DataStore fresh and recovers the data items that have been stored.
    /// </summary>
    /// <remarks>
    /// There are 2 phases:
    /// 1. Sensing Phase. 
    ///     Erase all DataStore data and sample sensors until five sensors have been sampled. 
    ///     Sensor allocation references are stored in a hashtable.
    ///     For each sample, create or update a data allocation with the sensed data, and store the data separately for later comparison.
    /// 2. Comparison Phase. 
    ///     Once five sensors have been sampled, stop sampling and read each allocation directly from DataStore.
    ///     Compare the allocation's data with that stored for comparison. Report discrepencies.
    /// </remarks>
    public class Program {

        private static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();    // Set up the LCD
        private static readonly DataStore DStore = DataStore.Instance(StorageType.NOR);     // Set up the DataStore
        private static readonly AutoResetEvent DoneSampling = new AutoResetEvent(false);    // Set up thread sync to shift between sampling and comparison phases

        private static DataStatus _retVal;  // DataStore and DataAllocation value returned by methods

        private const int SampleTimerInterval = 1000;   // Frequency (in ms) of sampling
        private static readonly SimpleTimer SampleTimer =
            new SimpleTimer(SampleTimer_Callback, null, SampleTimerInterval, SampleTimerInterval);  // Set up a periodic timer for sampling

        // Holds values for a sensor
        //  0: Sensor ID
        //  1: Sum of sensed values
        //  2: Number of times sensed
        private static readonly UInt32[] SensorValues = new UInt32[3];

        private static Hashtable _sensorDataAllocations = new Hashtable();      // Indexed table of data allocations, used for sensing
        private static readonly Hashtable ComparisonTable = new Hashtable();    // Indexed table of sensor values

        private static readonly Random RandomGenerator = new Random();    // Used to generate sensor IDs

        private const int MaxIdValue = 10;  // Maximum sensor ID value; keep it small enuf to encourage multiple sensing for some sensor, but large enuf to be sure we get sufficient number of different IDs
        private const int MaxSensors = 5;   // Maximum number of different simulated sensors

        /// <summary>
        /// Set things up
        /// </summary>
        public static void Main() {
            try {
                Debug.EnableGCMessages(false);  // We're not interested in garbage collector messages

                // Display program info
                Lcd.Display("data");

                // Print version & build info
                Debug.Print("DataStore " + VersionInfo.VersionDateTime);

                // Invalidate existing data
                Debug.Print("Initializing Data Store");
                if ((_retVal = DataStore.DeleteAllData()) != DataStatus.Success) {
                    throw new Exception("Cannot delete the data store; return value " + _retVal);
                }
                
                // Start sampling
                Debug.Print("Starting periodic sampling");
                SampleTimer.Start();

                // Wait till we're finished sampling
                DoneSampling.WaitOne();

                // Begin comparing what we stored with what should be there
                Lcd.Display("comp");
                Debug.Print("\nSampled " + _sensorDataAllocations.Count + " sensors");
                Debug.Print("\nRecovering data directly from DataStore and comparing allocations with earlier references");

                // Report the final sensor values
                foreach (DictionaryEntry entry in _sensorDataAllocations) {
                    var sensorId = (uint)entry.Key;
                    var dalloc = (DataAllocation)entry.Value;
                    if (dalloc == null) {
                        throw new Exception("Data allocation for sensor " + sensorId + " is null");
                    }
                    if (dalloc.Read(SensorValues, 0, 3) != DataStatus.Success) {
                        throw new Exception("Cannot read data allocation values for Id = " + sensorId);
                    }
                    Debug.Print("From Sensor Data Allocations: Sensor " + sensorId + ", Total " + SensorValues[1] + ", Count " + SensorValues[2] + ", Average " + ((double)SensorValues[1] / (double)SensorValues[2]));
                }

                // Null out the data allocations so garbage collector can pick it up
                //  We won't use this info any further since ReadAllDataReferences will cause these refrences to be stale
                _sensorDataAllocations = null;

                // Get back the allocations directly from the DataStore & check to be sure things match
                //  Note that we cannot use the Sensor Data Allocations because the entries are now invalid and hence stale

                var dSDataAllocations = new DataAllocation[Math.Max(MaxSensors / 2, 1)]; // Ensure that we use it at least twice
                var dSOffset = 0;   // An offset into the storage that is updated by the number of allocations retrieved at a time
                var dSNumAllocations = 0; // Count the number of allocations so we can compare at the end
                Debug.Print("");
                while (true) {
                    // Get the next batch of allocation references
                    if ((_retVal = DStore.ReadAllDataReferences(dSDataAllocations, (ushort)dSOffset)) != DataStatus.Success) {
                        throw new Exception("Cannot get data allocations from offset " + dSOffset + "; return value " + _retVal);
                    }
                    // Increment the offset for the next call of ReadAllDataReferences
                    dSOffset += dSDataAllocations.Length;
                    // Run thru this batch
                    foreach (var dSdAlloc in dSDataAllocations) {
                        // A null entry means we've finished
                        if (dSdAlloc == null) {
                            goto breakAll;
                        }
                        // Increment the number of allocations, for later comparison
                        dSNumAllocations++;

                        // Read the allocation from the Data Store 
                        if ((_retVal = dSdAlloc.Read(SensorValues, 0, SensorValues.Length)) != DataStatus.Success) {
                            throw new Exception("Cannot read data from allocation (DS); return value " + _retVal);
                        }

                        // SensorId is the first item
                        var sensorId = SensorValues[0];
                        Debug.Print("Checking sensor " + sensorId);
                        if (!ComparisonTable.Contains(sensorId)) {
                            throw new Exception("DataStore sensor id" + sensorId + " not in ComparisonTable");
                        }

                        // Compare the values read to the values in the Comparison Table
                        var comparisonValue = (uint[])ComparisonTable[sensorId];
                        if (comparisonValue == null) {
                            throw new Exception("No comparison value for sensor id" + sensorId);
                        }

                        // Compare the results
                        if (SensorValues[1] != comparisonValue[1] | SensorValues[2] != comparisonValue[2]) {
                            Debug.Print("  Sensor values do not match: Comparison Table / DataStore Total=" +
                                        SensorValues[1] + " / " + comparisonValue[1] + ", Comparison Table / DataStore Count=" + SensorValues[2] + " / " + comparisonValue[2]);
                        }
                        else {
                            Debug.Print("  Sensor values items match");
                        }
                    }
                }
            breakAll:
                // We're done reading from the DataStore
                //  Check to see if we've read the same number of sensors allocations from Data Store as we stored directly
                Debug.Print("\nComparison table has " + ComparisonTable.Count + " entries, flash has " + dSNumAllocations + " entries");
                if (ComparisonTable.Count != dSNumAllocations) {
                    Debug.Print("  Comparison table and DataStore do not have the same number of entries");
                }

                // Go to sleep
                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception ex) {
                Debug.Print(ex.ToString());
                Lcd.Display("9999");
            }
        }

        private static int _sampleNumber;
        /// <summary>
        /// Sensor timer callback
        /// </summary>
        /// <remarks>
        /// Simulate a sensor reading. Create a new allocation for sensor values if this is a new sensor; else update the existing sensor values allocation
        /// </remarks>
        /// <param name="timerVal"></param>
        private static void SampleTimer_Callback(object timerVal) {
            try {
                // If we've sampled enuf, move on to phase 2
                if (_sensorDataAllocations.Count >= MaxSensors) {
                    Debug.Print("\nStopping sensing");
                    // Stop the timer
                    SampleTimer.Stop();
                    // Signal phase 2
                    DoneSampling.Set();
                    return;
                }
                // Simulate data from some sensor
                var sampleId = (uint)RandomGenerator.Next(MaxIdValue);
                var sampleVal = (uint)RandomGenerator.Next(int.MaxValue / 10000);  // Make sure we don't get overflow anytime soon when we calculate sums
                Debug.Print("\nSample #" + (_sampleNumber++) + ", Id=" + sampleId);

                // Check if this is an existing sensor or a new one
                if (_sensorDataAllocations.Contains(sampleId)) {
                    // Existing sensor: update the values
                    Debug.Print("Updating sensor");
                    // Get the data allocation reference for the sensor
                    var dalloc = (DataAllocation)_sensorDataAllocations[sampleId];
                    // Read the data allocation value
                    if ((_retVal = dalloc.Read(SensorValues, 0, SensorValues.Length)) != DataStatus.Success) {
                        throw new Exception("Failed to read data allocation for Id = " + sampleId + "; return value =" + _retVal);
                    }
                    // Update the values
                    SensorValues[1] += sampleVal;  // Update sum of sample values
                    SensorValues[2]++;             // Update count of samples
                    // Update the allocation with the new values
                    if ((_retVal = dalloc.Write(SensorValues, 0, SensorValues.Length)) != DataStatus.Success) {
                        throw new Exception("Failed to write data allocation during update; return value=" + _retVal);
                    }
                    // Copy the updated values into the Comparison Table
                    // Get the values from the table and update them
                    var comparisonValue = (uint[])ComparisonTable[sampleId];
                    comparisonValue[0] = SensorValues[0];
                    comparisonValue[1] = SensorValues[1];
                    comparisonValue[2] = SensorValues[2];
                    Debug.Print("  Sum=" + SensorValues[1] + ", Count=" + SensorValues[2]);
                }
                else {
                    // New sensor
                    Debug.Print("New sensor");
                    var dalloc = new DataAllocation(DStore, (uint)SensorValues.Length, typeof(UInt32));
                    _sensorDataAllocations.Add(sampleId, dalloc);
                    SensorValues[0] = sampleId;    // Id
                    SensorValues[1] = sampleVal;   // Sum of sample values
                    SensorValues[2] = 1;           // Count of samples
                    if ((_retVal = dalloc.Write(SensorValues, 0, SensorValues.Length)) != DataStatus.Success) {
                        throw new Exception("Failed write data allocation during initial creation; return value=" + _retVal);
                    }
                    // Save the values for later comparison
                    var comparisonValue = new uint[SensorValues.Length];
                    comparisonValue[0] = SensorValues[0];
                    comparisonValue[1] = SensorValues[1];
                    comparisonValue[2] = SensorValues[2];
                    ComparisonTable.Add(sampleId, comparisonValue);
                    Debug.Print("  Sum=" + SensorValues[1] + ", Count=" + SensorValues[2]);
                }
            }
            catch (Exception ex) {
                Debug.Print("Error during SampleTimer callback: " + ex);
                throw;
            }
        }
    }
}


