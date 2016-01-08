/*=========================
 * eMote Temperature Sensor
 *  Sense temperature for either Maxim S18S20 or DS18B20 OneWire sensors
 * Versions
 *  1.0 Initial Version
=========================*/


#define TestingX    // Set to Testing to enable diagnostic prints

using System;
using System.Threading;
using Microsoft.SPOT.Hardware;

namespace Samraksh.AppNote.Utility {

    /// <summary>
    /// Read the temperature sensor with OneWire protocol via user-specified GPIO pin
    /// </summary>
    public class TemperatureSensor {

        /// <summary>Any temperature sensor exception</summary>
        /// <remarks>Note that a message must be provided</remarks>
        public class TemperatureSensorException : Exception {
            /// <summary>Any temperature sensor exception</summary>
            public TemperatureSensorException(string message) : base(message) { }
            /// <summary>Any temperature sensor exception</summary>
            public TemperatureSensorException(string message, Exception inner) : base(message, inner) { }
        }

        private enum Ds18x20Commands {
            ConverT = 0x44,
            ReadScratchPad = 0xBE,
            SkipRom = 0xCC,
            // Unused commands
            //  MatchRom = 0x55,
            //  WriteScratchPad = 0x4E,
            //  CopyScratchPad = 0x48,
            //  ReadPowerSupply = 0xB4
        }

        // Device family codes. See http://owfs.sourceforge.net/family.html for a list of OneWire devices (and summary of commands)
        private const byte Ds18S20DeviceFamilyCode = 0x10;
        private const byte Ds18B20DeviceFamilyCode = 0x28;

        private readonly Microsoft.SPOT.Hardware.OneWire _oneWire;  // Temperature sensor uses OneWire interface
        private readonly object _temperatureLock = new object();    // Locking is used to avoid race conditions when sensing vs. reading Temp value

        // Check if CPU is Little Endian or not
        private static readonly bool IsLittleEndian =
                     Microsoft.SPOT.Hardware.Utility.ExtractValueFromArray(new byte[] { 0xaa, 0xbb }, 0, 2) == 0xbbaa;

        // The device family code returned by the sensor
        private byte DS18x20DeviceFamilyCode;

        // Delay betwen OneWire commands
        private const int sensorDelay = 750;

        // Table used by CRC8 calculation
        private readonly byte[] _crc8Table = {
              0, 94,188,226, 97, 63,221,131,194,156,126, 32,163,253, 31, 65,
            157,195, 33,127,252,162, 64, 30, 95,  1,227,189, 62, 96,130,220,
             35,125,159,193, 66, 28,254,160,225,191, 93,  3,128,222, 60, 98,
            190,224,  2, 92,223,129, 99, 61,124, 34,192,158, 29, 67,161,255,
             70, 24,250,164, 39,121,155,197,132,218, 56,102,229,187, 89,  7,
            219,133,103, 57,186,228,  6, 88, 25, 71,165,251,120, 38,196,154,
            101, 59,217,135,  4, 90,184,230,167,249, 27, 69,198,152,122, 36,
            248,166, 68, 26,153,199, 37,123, 58,100,134,216, 91,  5,231,185,
            140,210, 48,110,237,179, 81, 15, 78, 16,242,172, 47,113,147,205,
             17, 79,173,243,112, 46,204,146,211,141,111, 49,178,236, 14, 80,
            175,241, 19, 77,206,144,114, 44,109, 51,209,143, 12, 82,176,238,
             50,108,142,208, 83, 13,239,177,240,174, 76, 18,145,207, 45,115,
            202,148,118, 40,171,245, 23, 73,  8, 86,180,234,105, 55,213,139,
             87,  9,235,181, 54,104,138,212,149,203, 41,119,244,170, 72, 22,
            233,183, 85, 11,136,214, 52,106, 43,117,151,201, 74, 20,246,168,
            116, 42,200,150, 21, 75,169,247,182,232, 10, 84,215,137,107, 53
        };

        /// <summary>
        /// Constructor for temperature sensor
        /// </summary>
        /// <remarks>Ensures that exactly one temperature sensor is found. Automatically adjusts to Ds18S20 or Ds18B20 type device.</remarks>
        /// <param name="pin">CPU pin to which the temperature sensor is connected</param>
        /// <exception cref="TemperatureSensorException">Exception thrown if exactly one temperature sensor is not found.</exception>
        public TemperatureSensor(Cpu.Pin pin) {
            if (pin == Cpu.Pin.GPIO_NONE) {
                throw new TemperatureSensorException("Must specify a GPIO pin");
            }

            var mPin = new OutputPort(pin, false);
            _oneWire = new OneWire(mPin);
            var devices = _oneWire.FindAllDevices();

            // There must be at least one device on the OneWire bus
            if (devices == null || devices.Count < 1) {
                throw new TemperatureSensorException("No devices found");
            }

            #region List device codes (for development testing)
#if Testing
            Debug.Print("IsLittleEndian: " + IsLittleEndian);
            foreach (var theDevice in devices) {
                if (!(theDevice is byte[])) {
                    Debug.Print("   " + theDevice.GetType());
                    break;
                }
                var deviceBytes = (theDevice as byte[]);
                Debug.Print("\n  Device " + devices.IndexOf(theDevice) + ", code " + deviceBytes[0]);
            }
#endif
            #endregion

            // There must be no more than one device on the OneWire bus
            if (devices.Count > 1) {
                throw new TemperatureSensorException(devices.Count + " devices found; s/b only 1");
            }

            // We know that there is exactly one device on the OneWire bus. Make sure it's the right one.
            var device = (devices[0] as byte[]);
            DS18x20DeviceFamilyCode = device[0];
            if (DS18x20DeviceFamilyCode != Ds18S20DeviceFamilyCode && DS18x20DeviceFamilyCode != Ds18B20DeviceFamilyCode) {
                throw new TemperatureSensorException("Device family code is " + device[0] + "; s/b " + Ds18S20DeviceFamilyCode + " or " + Ds18B20DeviceFamilyCode);
            }
        }

        /// <summary>
        /// Sense the temperature (in C) and store it in _temperature
        /// </summary>
        /// <param name="checkCrc">Check the CRC iff true, else false</param>
        public void Sense(bool checkCrc) {
            try {
                // Begin conversion
                _oneWire.TouchReset();
                _oneWire.WriteByte((int) Ds18x20Commands.SkipRom);
                // Since there is exactly one temperature sensor, no need to check codes
                _oneWire.WriteByte((int) Ds18x20Commands.ConverT);

                // Give the device time to do the sensing and conversion, and to store the values in the Scratch Pad.
                Thread.Sleep(sensorDelay);

                // Setup to read the results from the Scratch Pad
                _oneWire.TouchReset();
                _oneWire.WriteByte((int) Ds18x20Commands.SkipRom);
                // Since there is exactly one temperature sensor, no need to check codes
                _oneWire.WriteByte((int) Ds18x20Commands.ReadScratchPad);

                byte tempLo, tempHi; // The low and high order parts of the temperature
                // If we're being safe, get the values while checking the CRC
                if (checkCrc) {
                    var scratchPad = new byte[8];
                    byte calcCrc = 0x00;
                    for (var i = 0; i < 8; i++) {
                        scratchPad[i] = (byte) _oneWire.ReadByte();
                        calcCrc = _crc8Table[calcCrc ^ scratchPad[i]];
#if Testing
                        Debug.Print(" " + i + " Scratchpad: " + scratchPad[i] + ", CRC8: " + calcCrc);
#endif
                    }
                    var dsCrc = (byte) _oneWire.ReadByte();

#if Testing
                    Debug.Print("\n Calculated CRC: " + calcCrc + ", Scratchpad CRC: " + dsCrc);
#endif
                    tempLo = scratchPad[0];
                    tempHi = scratchPad[1];
                }
                    // Otherwise, just get the values
                else {
                    tempLo = (byte) _oneWire.ReadByte();
                    tempHi = (byte) _oneWire.ReadByte();
                }

#if Testing
                Debug.Print("\nRead " + tempHi + " " + tempLo);
#endif
                // Convert from pair of bytes to signed double
                var temperatureBytes = new byte[2];
                // The order of the bytes depends on whether the processor is little or big endian
                if (IsLittleEndian) {
                    temperatureBytes[0] = tempLo;
                    temperatureBytes[1] = tempHi;
                }
                else {
                    temperatureBytes[0] = tempHi;
                    temperatureBytes[1] = tempLo;
                }

                // Convert the temperatureBytes array to a double.
                //  See http://msdn.microsoft.com/en-us/library/a569z7k8.aspx and http://msdn.microsoft.com/en-us/library/ee433587.aspx
                //  (a) ExtractValueFromArray converts the bytes to a Uint
                //  (b) The cast forces it to an Int
                //  (c) the unchecked() lets the high-order bit be regarded as a sign
                double sensedTemperature =
                    unchecked((Int16) Microsoft.SPOT.Hardware.Utility.ExtractValueFromArray(temperatureBytes, 0, 2));

                // Adjust for precision, depending on which kind of sensor we have
                //  Note that for the Ds18S20, additional precision is available. This might be addressed in a future version
                switch (DS18x20DeviceFamilyCode) {
                    case Ds18B20DeviceFamilyCode:
                        // Measurement is in 1/16 degrees C
                        sensedTemperature /= 16;
                        break;
                    case Ds18S20DeviceFamilyCode:
                        // Measurement is in 1/2 degrees C
                        sensedTemperature /= 2;
                        break;
                    default:
                        // This should never happen since we've already checked
                        throw new TemperatureSensorException("Invalid Temperature Sensor Device Family Code: " +
                                                             DS18x20DeviceFamilyCode);
                }
                // Set the temperature property
                lock (_temperatureLock) {
                    _temperature = sensedTemperature;
                }
            }
            catch (Exception ex) {
                throw new TemperatureSensorException("Unexpected exception occurred", ex);
            }
        }

        /// <summary>
        /// Get the last-sensed temperature in C
        /// </summary>
        public double TemperatureC {
            get {
                lock (_temperatureLock) {
                    return _temperature;
                }
            }
        }
        private double _temperature;

        /// <summary>
        /// Get the last-sensed temperature in F
        /// </summary>
        /// <remarks>Note that property TemperatureC handles necessary locking</remarks>
        public double TemperatureF {
            get { return (TemperatureC * 9 / 5) + 32; }
        }

        /// <summary>
        /// Get the time (in ms) needed to wait between commands
        /// </summary>
        public int SensorDelay {get { return sensorDelay; }}


    }
}
