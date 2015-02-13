using System;
using Microsoft.SPOT;
using GHI = GHIElectronics.NETMF.Hardware;

/*
 * Copyright 2012-2014 Stefan Thoolen (http://www.netmftoolbox.com/)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace Toolbox.NETMF.Hardware
{
    /// <summary>Collection of Fez wrappers</summary>
    /// <remarks>I made this as a class so people actually have to type Fez.PWM. This, to avoid conflicts with any other PWM class.</remarks>
    public static partial class Fez
    {
        /// <summary>
        /// Fez ADC Wrapper
        /// </summary>
        public class ADC : IADCPort
        {
            /// <summary>Reference to the ADC port</summary>
            private GHI.AnalogIn _port;

            /// <summary>Defines a Fez ADC pin</summary>
            /// <param name="Pin">The Fez pin</param>
            public ADC(GHI.AnalogIn.Pin Pin)
            {
                this._port = new GHI.AnalogIn(Pin);
                this._port.SetLinearScale(0, 1024);
            }

            /// <summary>Reads out a value between 0 and 1</summary>
            public override double AnalogRead()
            {
                return (double)this._port.Read() / 1024;
            }

            /// <summary>Disposes the ADC object</summary>
            public override void Dispose()
            {
                this._port.Dispose();
            }
        }
    }
}
