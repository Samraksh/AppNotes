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

namespace Samraksh {
    namespace AppNote {
        namespace PersistentObjectStorage {
            /// <summary>
            /// ***
            /// </summary>
            public class Program {

                private static readonly EasyLcd Lcd = new EasyLcd();    // Set up the LCD
                private static readonly DataStore DStore = DataStore.Instance((int)StorageType.NOR);  // Set up the DataStore
                private static readonly AutoResetEvent DoneSampling =
                    new AutoResetEvent(false);    // Set up thread sync to shift between sampling and checking

                private static DataStatus _retVal;  // DataStore and DataAllocation value returned by methods

                private const int SampleTimerInterval = 1000;   // Frequency (in ms) of sampling
                private static readonly SimpleTimer SampleTimer =
                    new SimpleTimer(SampleTimer_Callback, null, SampleTimerInterval, SampleTimerInterval);  // Set up a periodic timer for sampling

                // Holds an aggregate of values for a sensor
                //  0: Sensor ID
                //  1: Sum of sensed values
                //  2: Number of times sensed
                private static readonly UInt32[] SensorAggregateItem = new UInt32[3];

                private static readonly Hashtable SensorDataAllocations = new Hashtable();  // Indexed table of data allocations, used for sensing
                private static readonly Hashtable ComparisonAggregates = new Hashtable();   // Indexed table of sensor aggregate values

                private static readonly Random RandomIdGenerator = new Random();    // Used to generate sensor IDs
                private static readonly Random RandomValueGenerator = new Random(); // Used to generate sensor values

                private const int MaxIdValue = 10;  // Maximum sensor ID value; keep it small enuf to encourage multiple sensing for some sensor, but large enuf to be sure we get sufficient number of different IDs
                private const int MaxSensors = 5;   // Maximum number of different simulated sensors

                /// <summary>
                /// Set things up
                /// </summary>
                public static void Main() {
                    try {
                        Debug.EnableGCMessages(false);  // We're not interested in garbage collector messages

                        // Initialize and print build info
                        Lcd.Display("data");
                        Debug.Print("DataStore " + VersionInfo.Version + " (" + VersionInfo.BuildDateTime + ")");

                        Debug.Print("Initializing Data Store");

                        if ((_retVal = DataStore.EraseAll()) != DataStatus.Success) {
                            throw new Exception("Cannot erase the data store; return value " + _retVal);
                        }

                        Debug.Print("Starting periodic sampling");
                        SampleTimer.Start();

                        // Wait till we're finished sampling
                        DoneSampling.WaitOne();
                        Lcd.Display("1111");
                        Debug.Print("\nSampled " + SensorDataAllocations.Count + " sensors");
                        Debug.Print("\nRecovering data directly from ROM and comparing allocations with earlier references");

                        // Report the sensor aggregates from those kept in the hash table
                        foreach (DictionaryEntry entry in SensorDataAllocations) {
                            var sensorId = (uint)entry.Key;
                            var dalloc = (DataAllocation)entry.Value;
                            if (dalloc == null) {
                                throw new Exception("Data allocation for sensor " + sensorId + " is null");
                            }
                            if (dalloc.Read(SensorAggregateItem, 0, 3) != DataStatus.Success) {
                                throw new Exception("Cannot read data allocation values for Id = " + sensorId);
                            }
                            Debug.Print("From HashTable allocation: Sensor " + sensorId + ", Total " + SensorAggregateItem[1] + ", Count " + SensorAggregateItem[2] + ", Average " + ((double)SensorAggregateItem[1] / (double)SensorAggregateItem[2]));
                        }

                        // Get back the allocations directly from the DataStore & check to be sure things match
                        //  Note that we cannot use the original hash table set of allocations because the entries are now invalid
                        var dSDataAllocations = new DataAllocation[Math.Max(MaxSensors / 2, 1)]; // Ensure that we use it at least twice
                        var dSOffset = 0;   // An offset into the storage that is updated by the number of allocations retrieved at a time
                        var dSNumAllocations = 0; // Count the number of allocations so we can compare at the end
                        while (true) {
                            if ((_retVal = DStore.ReadAllDataReferences(dSDataAllocations, (ushort)dSOffset)) != DataStatus.Success) {
                                throw new Exception("Cannot get data allocations from offset " + dSOffset + "; return value " + _retVal);
                            }
                            dSOffset += dSDataAllocations.Length;
                            foreach (var dSdAlloc in dSDataAllocations) {
                                if (dSdAlloc == null) {
                                    goto breakAll;
                                }
                                dSNumAllocations++;

                                // Read the allocation from the Data Store 
                                if ((_retVal = dSdAlloc.Read(SensorAggregateItem, 0, SensorAggregateItem.Length)) != DataStatus.Success) {
                                    throw new Exception("Cannot read data from allocation (DS); return value " + _retVal);
                                }
                                var sensorId = SensorAggregateItem[0];
                                Debug.Print("Checking sensor " + sensorId);
                                if (!SensorDataAllocations.Contains(sensorId)) {
                                    throw new Exception("Sensor aggregate item " + sensorId + " not in Hash Table");
                                }

                                // Compare to the values that were stored directly
                                var comparisonAggregateItem = (uint[])ComparisonAggregates[sensorId];
                                if (comparisonAggregateItem == null) {
                                    throw new Exception("No comparison sensor aggregate data for id" + sensorId);
                                }

                                // Compare the results
                                if (SensorAggregateItem[1] != comparisonAggregateItem[1] | SensorAggregateItem[2] != comparisonAggregateItem[2]) {
                                    Debug.Print("  Sensor aggregate items do not match: HashTable / ROM Total=" +
                                                SensorAggregateItem[1] + " / " + comparisonAggregateItem[1] + ", HashTable / ROM Count=" + SensorAggregateItem[2] + " / " + comparisonAggregateItem[2]);
                                }
                                else {
                                    Debug.Print("  Sensor aggregate items match");
                                }
                            }
                        }
                    breakAll:
                        // Check to see if we've read the same number of sensor aggregates from Data Store as we stored directly
                        Debug.Print("Comparison Table has " + ComparisonAggregates.Count + "entries, ROM has " + dSNumAllocations + " entries");
                        if (SensorDataAllocations.Count != dSNumAllocations) {
                            Debug.Print("  HashTable and ROM do not have the same number of allocations");
                        }

                        // Go to sleep
                        Thread.Sleep(Timeout.Infinite);
                    }
                    catch (Exception ex) {
                        Debug.Print(ex.ToString());
                        Lcd.Display("9999");
                    }
                }

                private static void SampleTimer_Callback(object timerVal) {
                    try {
                        // Simulate data from some sensor
                        var sampleId = (uint)RandomIdGenerator.Next(MaxIdValue);
                        var sampleVal = (uint)RandomValueGenerator.Next(int.MaxValue / 10000);  // Make sure we don't get overflow anytime soon when we calculate sums
                        Debug.Print("\nSample #" + SensorDataAllocations.Count + ", Id=" + sampleId);
                        if (SensorDataAllocations.Contains(sampleId)) {
                            Debug.Print("Updating sensor");
                            var dalloc = (DataAllocation)SensorDataAllocations[sampleId];
                            if ((_retVal = dalloc.Read(SensorAggregateItem, 0, SensorAggregateItem.Length)) != DataStatus.Success) {
                                throw new Exception("Failed to read data allocation for Id = " + sampleId + "; return value =" + _retVal);
                            }
                            SensorAggregateItem[1] += sampleVal;  // Update sum of sample values
                            SensorAggregateItem[2]++;             // Update count of samples
                            if ((_retVal = dalloc.Write(SensorAggregateItem, 0, SensorAggregateItem.Length)) != DataStatus.Success) {
                                throw new Exception("Failed to write data allocation during update; return value=" + _retVal);
                            }
                            // Copy the updated values into ComparisonAggregates
                            var comparisonAggregateItem = (uint[])ComparisonAggregates[sampleId];
                            comparisonAggregateItem[0] = SensorAggregateItem[0];
                            comparisonAggregateItem[1] = SensorAggregateItem[1];
                            comparisonAggregateItem[2] = SensorAggregateItem[2];
                            Debug.Print("  Sum=" + SensorAggregateItem[1] + ", Count=" + SensorAggregateItem[2]);
                        }
                        else {
                            if (SensorDataAllocations.Count >= MaxSensors) {
                                Debug.Print("\nStopping sensing");
                                SampleTimer.Stop();
                                DoneSampling.Set();
                                return;
                            }
                            Debug.Print("New sensor");
                            var dalloc = new DataAllocation(DStore, (uint)SensorAggregateItem.Length, typeof(UInt32));
                            SensorDataAllocations.Add(sampleId, dalloc);
                            SensorAggregateItem[0] = sampleId;    // Id
                            SensorAggregateItem[1] = sampleVal;   // Sum of sample values
                            SensorAggregateItem[2] = 1;           // Count of samples
                            if ((_retVal = dalloc.Write(SensorAggregateItem, 0, SensorAggregateItem.Length)) != DataStatus.Success) {
                                throw new Exception("Failed write data allocation during initial creation; return value=" + _retVal);
                            }
                            // Save the values for later comparison
                            var comparisonAggregateItem = new uint[SensorAggregateItem.Length];
                            comparisonAggregateItem[0] = SensorAggregateItem[0];
                            comparisonAggregateItem[1] = SensorAggregateItem[1];
                            comparisonAggregateItem[2] = SensorAggregateItem[2];
                            ComparisonAggregates.Add(sampleId, comparisonAggregateItem);
                            Debug.Print("  Sum=" + SensorAggregateItem[1] + ", Count=" + SensorAggregateItem[2]);
                        }
                    }
                    catch (Exception ex) {
                        Debug.Print("Error during SampleTimer callback: " + ex);
                        throw;
                    }
                }
            }
        }
    }
}
