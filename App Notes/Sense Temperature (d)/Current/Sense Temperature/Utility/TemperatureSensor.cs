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
            _oneWire.WriteByte(0xCC);
            _oneWire.WriteByte((int)Ds18S20Commands.ConverT);

            Thread.Sleep(750);

            _oneWire.TouchReset();
            _oneWire.WriteByte(0xCC);
            _oneWire.WriteByte((int)Ds18S20Commands.ReadScratchPad);

            var tempLo = _oneWire.ReadByte();
            var tempHi = _oneWire.ReadByte();

            double temp;
            switch (DS18x20DeviceFamilyCode) {
                case Ds18B20DeviceFamilyCode:
                    temp = (tempHi << 8 | tempLo) / 16D;
                    if ((tempHi & 0xF0) == 0xF0) {
                        temp *= -1;
                    }
                    break;
                case Ds18S20DeviceFamilyCode:
                    temp = tempHi << 8 | tempLo;
                    temp /= 2;
                    break;
                default:
                    // This should never happen
                    throw new TemperatureSensorDeviceException("Invalid Temperature Sensor Device Family Code: " + DS18x20DeviceFamilyCode);
            }
            // Set the temperature property
            lock (_temperatureLock) {
                _temperature = temp;
            }
        }


    }
}
