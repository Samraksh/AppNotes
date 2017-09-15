// Specify protocol & radio

#define OMAC
//#define CSMA

#if (OMAC && CSMA) || !(OMAC || CSMA)
#error Exactly one radio must be defined
#endif

#define RF231	// .NOW on-board radio
//#define SI4468	// WLN on-board radio

#if (RF231 && SI4468) || !(RF231 || SI4468)
#error Exactly one radio must be defined
#endif

using System.Text;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Samraksh.eMote.Net;
using Samraksh.eMote.Net.MAC;
using Samraksh.eMote.Net.Radio;

namespace Samraksh.Appnote.Utility
{
	public static class RadioUtilities
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
        }
#endif


		public static void PrintRadioConfig(MACBase macBase)
		{
			Debug.Print("=======================================");
			var info = "MAC Type: " + macBase.GetType()
					   + ", Channel: " + macBase.MACRadioObj.Channel
					   + ", Power: " + macBase.MACRadioObj.TxPower
					   + ", Radio Address: " + macBase.MACRadioObj.RadioAddress
					   + ", Radio Type: " + macBase.MACRadioObj.RadioName
					   + ", Neighbor Liveness Delay: " + macBase.NeighborLivenessDelay;
			Debug.Print(info);
			Debug.Print("=======================================");
		}

		private static readonly ushort[] SendAllNeighborList = MACBase.NeighborListArray();
		/// <summary>
		/// Send packet to all neighbors
		/// </summary>
		/// <param name="macBase"></param>
		/// <param name="packet"></param>
		/// <param name="printSend"></param>
		public static void SendToAllNeighbors(MACBase macBase, byte[] packet, bool printSend = false)
		{
			macBase.NeighborList(SendAllNeighborList);
			foreach (var neighbor in SendAllNeighborList)
			{
				if (neighbor == 0)
				{
					break;
				}
				macBase.Send(neighbor, packet, 0, (ushort)packet.Length);
				if (printSend)
				{
					Debug.Print("Sent to [" + neighbor + "]");
				}
			}
		}

		private static readonly ushort[] PrintNeighborsList = MACBase.NeighborListArray();
		public static Thread PrintNeighborsPeriodically(MACBase macBase, int periodMs = 1000)
		{
			var t = new Thread(() =>
			{
				macBase.NeighborList(PrintNeighborsList);
				var s = new StringBuilder("Neighbor list for " + macBase.MACRadioObj.RadioAddress + ": ");
				NumberListToString(s,PrintNeighborsList);
				Debug.Print(s.ToString());
				Thread.Sleep(periodMs);
			});
			t.Start();
			return t;
		}

		private static readonly ushort[] PrintNeighborChangeList = MACBase.NeighborListArray();
		/// <summary>
		/// Print old and new neighbor list
		/// </summary>
		/// <param name="macBase"></param>
		public static void PrintNeighborChange(MACBase macBase)
		{
			var s = new StringBuilder("\nOld neighbor list for "+macBase.MACRadioObj.RadioAddress+": ");
			NumberListToString(s,PrintNeighborChangeList);
			Debug.Print(s.ToString());

			macBase.NeighborList(PrintNeighborChangeList);
			s=new StringBuilder("New neighbor list: ");
			Debug.Print(s.ToString());
		}

		private static void NumberListToString(StringBuilder s, ushort[] numberList)
		{
			foreach (var neighbor in numberList)
			{
				s.Append(neighbor.ToString());
				s.Append(' ');
			}
		}
	}


}
