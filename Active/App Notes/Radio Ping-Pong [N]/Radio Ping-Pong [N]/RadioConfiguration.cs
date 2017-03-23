// Specify protocol & radio

//#define OMAC
#define CSMA

#define RF231
//#define SI4468

using System;
using Microsoft.SPOT;
using Samraksh.eMote.Net;
using Samraksh.eMote.Net.MAC;
using Samraksh.eMote.Net.Radio;


namespace Samraksh.AppNote.DotNow.PingPong
{
    public static class RadioConfiguration
    {
        /// <summary>
        /// Get the MAC
        /// </summary>
        /// <returns></returns>
        public static MACBase GetMAC()
        {
#if SI4468
            Debug.Print("Configuring SI4468 radio with power " + RadioProperties.Power + ", channel " +
                        RadioProperties.RadioChannel);
            var radioConfig = new SI4468RadioConfiguration(RadioProperties.Power, RadioProperties.RadioChannel);
#elif RF231
            Debug.Print("Configuring RF231 radio with power " + RadioProperties.Power + ", channel " +
                        RadioProperties.RadioChannel);
            var radioConfig = new RF231RadioConfiguration(RadioProperties.Power, RadioProperties.RadioChannel);
#endif

#if CSMA
            Debug.Print("Configuring CSMA");
            var mac = new CSMA(radioConfig) { NeighborLivenessDelay = 10 * 60 + 20 };
            Debug.Print("NeighborLivenessDelay = " + mac.NeighborLivenessDelay);
#elif OMAC
            Debug.Print("Configuring OMAC");
            var mac = new OMAC(radioConfig);
            mac.NeighborLivenessDelay = 10 * 60 + 20;
            Debug.Print("NeighborLivenessDelay = " + mac.NeighborLivenessDelay);
#endif
            Debug.Print("Radio Power: " + mac.MACRadioObj.TxPower);
            return mac;
        }

#if RF231
        /// <summary>
        /// Radio properties
        /// </summary>
        public class RadioProperties
        {
            ///// <summary>Radio name</summary>
            //public const RadioName Radio = RadioName.RF231;

            /// <summary>CCA sense time</summary>
            public const byte CCASenseTime = 140;

            /// <summary>Transmit power level</summary>
            public const RF231TxPower Power = RF231TxPower.Power_Minus17dBm;

            /// <summary>Radio channel</summary>
            public const RF231Channel RadioChannel = RF231Channel.Channel_13;
        }
#elif SI4468
        /// <summary>
        /// Radio properties
        /// </summary>
        public class RadioProperties
        {
            ///// <summary>Radio name</summary>
            //public const RadioName Radio = RadioName.RF231;

            /// <summary>CCA sense time</summary>
            public const byte CCASenseTime = 140;

            /// <summary>Transmit power level</summary>
            public const SI4468TxPower Power = SI4468TxPower.Power_20dBm;

            /// <summary>Radio channel</summary>
            public const SI4468Channel RadioChannel = SI4468Channel.Channel_00;
            //public const SI4468Channel RadioChannel = SI4468Channel.Channel_02;
        }
#endif

    }


}
