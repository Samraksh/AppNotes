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
                private static readonly Hashtable SensorAggregates = new Hashtable();
                private static readonly Hashtable SensorAggregateVals = new Hashtable();
                private static readonly Random RandomIdGenerator = new Random();
                private static readonly Random RandomValueGenerator = new Random();
                private static readonly DataStore DStore = DataStore.Instance;
                private static readonly UInt32[] HTsensorAggregateItem = new UInt32[3];
                private static readonly UInt32[] DSsensorAggregateItem = new uint[HTsensorAggregateItem.Length];

                private static readonly AutoResetEvent DoneSampling = new AutoResetEvent(false);
                private const int MaxIdValue = 10;
                private const int MaxDataAllocations = 5;
                private static DataStatus _retVal;

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
                        if ((_retVal = DataStore.DeleteAllData()) != DataStatus.Success) {
                            throw new Exception("Cannot delete the data store contents; return value " + _retVal);
                        }
                        SampleTimer.Start();

                        // Wait till we're finished sampling
                        DoneSampling.WaitOne();
                        Lcd.Display("1111");
                        Debug.Print("\nSampled " + SensorAggregates.Count + " sensors");
                        Debug.Print("\nRecovering data directly from ROM and comparing allocations with earlier references");

                        // Report the sensor aggregates from those kept in the hash table
                        foreach (DictionaryEntry entry in SensorAggregates) {
                            var sensorId = (uint)entry.Key;
                            var dalloc = (DataAllocation)entry.Value;
                            if (dalloc == null) {
                                throw new Exception("Data allocation for sensor " + sensorId + " is null");
                            }
                            if (dalloc.Read(HTsensorAggregateItem, 0, 3) != DataStatus.Success) {
                                throw new Exception("Cannot read data allocation values for Id = " + sensorId);
                            }
                            Debug.Print("From HashTable allocation: Sensor " + sensorId + ", Total " + HTsensorAggregateItem[1] + ", Count " + HTsensorAggregateItem[2] + ", Average " + ((double)HTsensorAggregateItem[1] / (double)HTsensorAggregateItem[2]));
                        }

                        // Get back the allocations directly from the DataStore & check to be sure things match
                        //  Note that we cannot use the original hash table set of allocations because the entries are now invalid
                        var dSDataAllocations = new DataAllocation[10];
                        var dSOffset = 0;
                        var dSNumAllocations = 0; // Count the number of allocations so we can compare at the end
                        var sma = new uint[DSsensorAggregateItem.Length];
                        while (true) {
                            if ((_retVal = DStore.ReadAllDataReferences(dSDataAllocations, (ushort)dSOffset)) != DataStatus.Success) {
                                throw new Exception("Cannot get data allocations from offset " + dSOffset + "; return value " + _retVal);
                            }
                            dSOffset += dSDataAllocations.Length;
                            foreach (var dSDAlloc in dSDataAllocations) {
                                if (dSDAlloc == null) {
                                    goto breakAll;
                                }
                                dSNumAllocations++;

                                // Read the allocation from the Data Store 
                                if ((_retVal = dSDAlloc.Read(DSsensorAggregateItem, 0, (uint)DSsensorAggregateItem.Length)) != DataStatus.Success) {
                                    throw new Exception("Cannot read data from allocation (DS); return value " + _retVal);
                                }
                                var sensorId = DSsensorAggregateItem[0];
                                Debug.Print("Checking sensor " + sensorId);
                                if (!SensorAggregates.Contains(sensorId)) {
                                    throw new Exception("Sensor aggregate item " + sensorId + " not in Hash Table");
                                }

                                // Compare to the values store directly
                                sma = (uint[])SensorAggregateVals[sensorId];
                                if (sma == null) {
                                    throw new Exception("No data for sensor id" + sensorId);
                                }
                                //var hTDalloc = (DataAllocation)SensorAggregates[sensorId];
                                //if (hTDalloc == null) {
                                //    throw new Exception("Data allocation from Hash Table is null for sensor id " + sensorId);
                                //}
                                //if ((_retVal = hTDalloc.Read(HTsensorAggregateItem, 0, (UInt32)HTsensorAggregateItem.Length)) != DataStatus.Success) {
                                //    throw new Exception("Cannot read data from allocation (Hash Table); return value " + _retVal);
                                //}

                                // Compare the results
                                if (DSsensorAggregateItem[1] != sma[1] | DSsensorAggregateItem[2] != sma[2]) {
                                    Debug.Print("Sensor aggregate items do not match: HashTable / ROM Total=" +
                                                DSsensorAggregateItem[1] + " / " + sma[1] + ", HashTable / ROM Count=" + DSsensorAggregateItem[2] + " / " + sma[2]);
                                }
                                else {
                                    Debug.Print("Sensor aggregate items match");
                                }
                            }
                        }
                    breakAll:
                        Debug.Print("HashTable has " + SensorAggregates.Count + "entries, ROM has " + dSNumAllocations + " entries");
                        if (SensorAggregates.Count != dSNumAllocations) {
                            Debug.Print("HashTable and ROM do not have the same number of allocations");
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
                        Debug.Print("\nSample #" + SensorAggregates.Count + ", Id=" + sampleId);
                        if (SensorAggregates.Contains(sampleId)) {
                            Debug.Print("Updating sensor");
                            var dalloc = (DataAllocation)SensorAggregates[sampleId];
                            if ((_retVal = dalloc.Read(HTsensorAggregateItem, 0, (UInt32)HTsensorAggregateItem.Length)) != DataStatus.Success) {
                                throw new Exception("Failed to read data allocation for Id = " + sampleId + "; return value =" + _retVal);
                            }
                            HTsensorAggregateItem[1] += sampleVal;  // Update sum of sample values
                            HTsensorAggregateItem[2]++;             // Update count of samples
                            if ((_retVal = dalloc.Write(HTsensorAggregateItem, 0, (UInt32)HTsensorAggregateItem.Length)) != DataStatus.Success) {
                                throw new Exception("Failed to write data allocation during update; return value=" + _retVal);
                            }
                            // Copy the updated values into SensorAggregateVals
                            var sva = (uint[])SensorAggregateVals[sampleId];
                            sva[0] = HTsensorAggregateItem[0];
                            sva[1] = HTsensorAggregateItem[1];
                            sva[2] = HTsensorAggregateItem[2];
                            Debug.Print("  Sum=" + HTsensorAggregateItem[1] + ", Count=" + HTsensorAggregateItem[2]);
                        }
                        else {
                            if (SensorAggregates.Count >= MaxDataAllocations) {
                                Debug.Print("\nStopping sensing");
                                SampleTimer.Stop();
                                DoneSampling.Set();
                                return;
                            }
                            Debug.Print("New sensor");
                            var dalloc = new DataAllocation(DStore, (uint)HTsensorAggregateItem.Length, typeof(UInt32));
                            SensorAggregates.Add(sampleId, dalloc);
                            HTsensorAggregateItem[0] = sampleId;    // Id
                            HTsensorAggregateItem[1] = sampleVal;   // Sum of sample values
                            HTsensorAggregateItem[2] = 1;           // Count of samples
                            if ((_retVal = dalloc.Write(HTsensorAggregateItem, 0, (UInt32)HTsensorAggregateItem.Length)) != DataStatus.Success) {
                                throw new Exception("Failed write data allocation during initial creation; return value=" + _retVal);
                            }
                            // Save the values for later comparison
                            var sva = new uint[HTsensorAggregateItem.Length];
                            sva[0] = HTsensorAggregateItem[0];
                            sva[1] = HTsensorAggregateItem[1];
                            sva[2] = HTsensorAggregateItem[2];
                            SensorAggregateVals.Add(sampleId, sva);
                            Debug.Print("  Sum=" + HTsensorAggregateItem[1] + ", Count=" + HTsensorAggregateItem[2]);
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
