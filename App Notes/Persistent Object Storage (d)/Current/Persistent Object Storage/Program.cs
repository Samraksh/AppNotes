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

namespace Samraksh {
    namespace AppNote {
        namespace PersistentObjectStorage {
            /// <summary>
            /// ***
            /// </summary>
            public class Program {

                private static readonly EasyLcd Lcd = new EasyLcd();

                private const int SampleTimerInterval = 1000;
                private static readonly SimpleTimer SampleTimer = new SimpleTimer(SampleTimer_Callback, null, SampleTimerInterval, SampleTimerInterval);
                private const int MaxIdValue = 5;
                private static readonly Hashtable SensorAggregates = new Hashtable();
                private static readonly Random RandomIdGenerator = new Random();
                private static readonly Random RandomValueGenerator = new Random();
                private static readonly DataStore DStore = DataStore.Instance;
                private static readonly UInt32[] SensorAggregateItem = new UInt32[3];
                private const int NumberOfSamples = 10;
                //private static int _totalSamples;
                private static readonly AutoResetEvent DoneSampling = new AutoResetEvent(false);
                private const int MaxDataAllocations = 256;

                /// <summary>
                /// Set things up
                /// </summary>
                public static void Main() {
                    try {
                        Debug.EnableGCMessages(false);
                        Lcd.Write('0'.ToLcd(), '0'.ToLcd(), '0'.ToLcd(), '0'.ToLcd());
                        Lcd.Display("data");
                        Debug.Print("DataStore " + VersionInfo.Version + " (" + VersionInfo.BuildDateTime + ")");
                        Thread.Sleep(3000);

                        if (!DStore.InitDataStore((int)StorageType.NOR)) {
                            throw new Exception("Cannot initialize the data store");
                        }
                        if (DataStore.DeleteAllData() != DataStatus.Success) {
                            throw new Exception("Cannot delete the data store contents");
                        }
                        SampleTimer.Start();

                        // Wait till we're finished sampling
                        DoneSampling.WaitOne();
                        Lcd.Display("1111");
                        Debug.Print("\nSampled sensors " + SensorAggregates.Count + " times");
                        Debug.Print("\nRecovering data directly from ROM and comparing allocations with earlier references");

                        // Report the sensor aggregates from those kept in the hash table
                        for (var sensorId = 0; sensorId < SensorAggregates.Count; sensorId++) {
                            var dalloc = (DataAllocation)SensorAggregates[sensorId];
                            if (dalloc.Read(SensorAggregateItem, 0, 3) != DataStatus.Success) {
                                throw new Exception("Cannot read data allocation values for Id = " + sensorId);
                            }
                            Debug.Print("From HashTable allocation: Sensor " + sensorId + ", Total " + SensorAggregateItem[2] + ", Count " + SensorAggregateItem[3] + "Average " + ((double)SensorAggregateItem[2] / (double)SensorAggregateItem[3]));
                        }
                        // Get back the references directly from the DataStore & check to be sure things match
                        var dataAllocations = new DataAllocation[10];
                        var dataStoreOffset = 0;
                        var numAllocations = 0; // Store the number of allocations so we can compare at the end
                        while (true) {
                            if (DStore.ReadAllDataReferences(dataAllocations, (ushort)dataStoreOffset) != DataStatus.Success) {
                                throw new Exception("Cannot get data allocations from offset " + dataStoreOffset);
                            }
                            dataStoreOffset += dataAllocations.Length;
                            foreach (var theAllocation in dataAllocations) {
                                if (theAllocation == null) {
                                    goto breakAll;
                                }
                                numAllocations++;
                                var sensorAggregateDs = new uint[SensorAggregateItem.Length];
                                if (theAllocation.Read(sensorAggregateDs, 0, (uint)sensorAggregateDs.Length) != DataStatus.Success) {
                                    throw new Exception("Cannot read data from allocation");
                                }
                                if (!SensorAggregates.Contains(sensorAggregateDs[0])) {
                                    throw new Exception("Sensor aggregate item " + sensorAggregateDs[0] + " not in Hash Table");
                                }
                                if (sensorAggregateDs[1] != SensorAggregateItem[1] | sensorAggregateDs[2] != SensorAggregateItem[2]) {
                                    throw new Exception("Sensor aggregate items do not match: HashTable / ROM Total=" + sensorAggregateDs[1] + " / " + SensorAggregateItem[1] + ", HashTable / ROM Count=" + sensorAggregateDs[2] + " / " + SensorAggregateItem[2]);
                                }
                            }
                        }
                    breakAll:
                        Debug.Print("HashTable has " + SensorAggregates.Count + "entries, ROM has " + numAllocations + " entries");
                        if (SensorAggregates.Count != numAllocations) {
                            throw new Exception("HashTable and ROM do not have the same number of allocations\nHashTable has " + SensorAggregates.Count + "entries, ROM has " + numAllocations + " entries");
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
                        if (SensorAggregates.Count >= NumberOfSamples) {
                            Debug.Print("Stopping sensing");
                            SampleTimer.Stop();
                            DoneSampling.Set();
                        }
                        // Simulate data from some sensor
                        var sampleId = (uint)RandomIdGenerator.Next(MaxIdValue);
                        var sampleVal = (uint)RandomValueGenerator.Next(int.MaxValue / 10000);  // Make sure we don't get overflow anytime soon when we calculate sums
                        Debug.Print("Sample #" + SensorAggregates.Count + ", Id=" + sampleId + ", Val=" + sampleVal);
                        if (SensorAggregates.Contains(sampleId)) {
                            Debug.Print("## Getting the allocation");
                            var dalloc = (DataAllocation)SensorAggregates[sampleId];
                            Debug.Print("## Reading the data values");
                            DataStatus returnVal;
                            returnVal = dalloc.Read(SensorAggregateItem, 0, (UInt32)SensorAggregateItem.Length);
                            SensorAggregateItem[1] += sampleVal;  // Update sum of sample values
                            SensorAggregateItem[2]++;             // Update number of samples
                            Debug.Print("## Testing return value: " + returnVal);
                            if (returnVal != DataStatus.Success) {
                                throw new Exception("Failed to read data allocation for Id = " + sampleId + "; return value =" + returnVal);
                            }
                            Debug.Print("## Updating allocation values");
                            returnVal = dalloc.Write(SensorAggregateItem, 0, (UInt32)SensorAggregateItem.Length);
                            Debug.Print("## Testing return value: " + returnVal);
                            if (returnVal != DataStatus.Success) {
                                throw new Exception("Failed to write data allocation during update; return value=" + returnVal);
                            }
                            Debug.Print("## Finished updating");
                        }
                        else {
                            if (SensorAggregates.Count >= MaxDataAllocations) {
                                SampleTimer.Stop();
                                DoneSampling.Set();
                            }
                            var dalloc = new DataAllocation(DStore, (uint)SensorAggregateItem.Length, typeof(UInt32));
                            SensorAggregates.Add(sampleId, dalloc);
                            SensorAggregateItem[0] = sampleId;    // Id
                            SensorAggregateItem[1] = sampleVal;   // Sum of sample values
                            SensorAggregateItem[2] = 1;           // Number of samples
                            var returnVal = dalloc.Write(SensorAggregateItem, 0, (UInt32)SensorAggregateItem.Length);
                            if (returnVal != DataStatus.Success) {
                                throw new Exception("Failed write data allocation during initial creation; return value=" + returnVal);
                            }
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
