#define Testing

using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;



namespace Samraksh.SPOT.AppNote.Utility {

    /// <summary>
    /// Read the temperature sensor with OneWire protocol via user-specified GPIO pin
    /// </summary>
    public class TemperatureSensor {

        /// <summary>Exception thrown in the event no devices are found</summary>
        public class TemperatureSensorDeviceException : Exception {
            /// <summary>No Devices</summary>
            public TemperatureSensorDeviceException() { }
            /// <summary>No Devices</summary>
            public TemperatureSensorDeviceException(string message) : base(message) { }
            /// <summary>No Devices</summary>
            public TemperatureSensorDeviceException(string message, Exception inner) : base(message, inner) { }
        }

        private enum Ds18S20Commands {
            ConverT = 0x44,
            ReadScratchPad = 0xBE,
            SkipRom = 0xCC,
            // Unused commands
            //WriteScratchPad = 0x4E,
            //CopyScratchPad = 0x48,
            //ReadPowerSupply = 0xB4
        }

        // Device family codes. See http://owfs.sourceforge.net/family.html for a list of OneWire devices (and summary of commands)
        private const byte Ds18S20DeviceFamilyCode = 0x10;
        private const byte Ds18B20DeviceFamilyCode = 0x28;

        private readonly OneWire _oneWire;
        private readonly object _temperatureLock = new object();    // Locking is used to avoid race conditions when sensing vs. reading Temp value

        private static readonly bool IsLittleEndian =
                     Microsoft.SPOT.Hardware.Utility.ExtractValueFromArray(new byte[] { 0xaa, 0xbb }, 0, 2) == 0xbbaa;

        private byte DS18x20DeviceFamilyCode;

        /// <summary>
        /// Constructor for temperature sensor
        /// </summary>
        /// <remarks>Assumes that </remarks>
        /// <param name="pin">CPU pin to which the temperature sensor is connected</param>
        /// <exception cref="TemperatureSensorDeviceException">Exception thrown if CPU pin is NONE or if assumptions are not satisfied</exception>
        public TemperatureSensor(Cpu.Pin pin) {
            if (pin == Cpu.Pin.GPIO_NONE) {
                throw new TemperatureSensorDeviceException("Must specify a GPIO pin");
            }
            lock (_temperatureLock) {
                _temperature = 0;
            }

            var mPin = new OutputPort(pin, false);
            _oneWire = new OneWire(mPin);
            var devices = _oneWire.FindAllDevices();

            // There must be at least one device on the OneWire bus
            if (devices == null || devices.Count < 1) {
                throw new TemperatureSensorDeviceException("No devices found");
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
                throw new TemperatureSensorDeviceException(devices.Count + " devices found; s/b only 1");
            }

            // We know that there is exactly one device on the OneWire bus. Make sure it's the right one
            var device = (devices[0] as byte[]);
            DS18x20DeviceFamilyCode = device[0];
            if (DS18x20DeviceFamilyCode != Ds18S20DeviceFamilyCode && DS18x20DeviceFamilyCode != Ds18B20DeviceFamilyCode) {
                throw new TemperatureSensorDeviceException("Device family code is " + device[0] + "; s/b " + Ds18S20DeviceFamilyCode + " or " + Ds18B20DeviceFamilyCode);
            }
        }

        private double _temperature;
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

        /// <summary>
        /// Get the last-sensed temperature in F
        /// </summary>
        public double TemperatureF {
            get { return (TemperatureC * 9 / 5) + 32; }
        }

        /// <summary>
        /// Sense the temperature (in C)
        /// </summary>
        public void Sense() {

            _oneWire.TouchReset();
            _oneWire.WriteByte((int)Ds18S20Commands.SkipRom);
            _oneWire.WriteByte((int)Ds18S20Commands.ConverT);

            Thread.Sleep(750);

            _oneWire.TouchReset();
            _oneWire.WriteByte((int)Ds18S20Commands.SkipRom);
            _oneWire.WriteByte((int)Ds18S20Commands.ReadScratchPad);

#if Testing
            var scratchPad = new byte[8];
            byte calcCrc = 0x00;
            for (var i = 0; i < 8; i++) {
                scratchPad[i] = (byte)_oneWire.ReadByte();
                Debug.Print(" " + i + " " + scratchPad[i]);
                calcCrc ^= scratchPad[i];
            }
            var dsCrc = (byte)_oneWire.ReadByte();
            Debug.Print(" " + 8 + " " + calcCrc + ", " + dsCrc);

            var tempLo = scratchPad[0];
            var tempHi = scratchPad[1];
#else
            var tempLo = (byte)_oneWire.ReadByte();
            var tempHi = (byte)_oneWire.ReadByte();
#endif

#if Testing
            Debug.Print("\nRead " + tempHi + " " + tempLo);
            //// Test conversion to double
            //int vi1, vi2;
            //double vd;
            //byte vh, vl;
            //var varr = new byte[2];
            //vl = 0x92;
            //vh = 0xFF
            //if (IsLittleEndian) {
            //    varr[0] = vl;
            //    varr[1] = vh;
            //}
            //else {
            //    varr[0] = vh;
            //    varr[1] = vl;
            //}
            //vi1 = vh << 8 | vl;
            //vi2 = unchecked((Int16)Microsoft.SPOT.Hardware.Utility.ExtractValueFromArray(varr, 0, 2));
            //vd = vl;
            //Debug.Print("  vh, vl, vi1, vi2, vd: " + vh + ", " + vl + ", " + vi1 + ", " + vi2 + ", " + vd);
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
            double sensedTemperature = unchecked((Int16)Microsoft.SPOT.Hardware.Utility.ExtractValueFromArray(temperatureBytes, 0, 2));
            // Adjust for precision
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
                    // This should never happen
                    throw new TemperatureSensorDeviceException("Invalid Temperature Sensor Device Family Code: " + DS18x20DeviceFamilyCode);
            }
            // Set the temperature property
            lock (_temperatureLock) {
                _temperature = sensedTemperature;
            }
        }

    }
}
