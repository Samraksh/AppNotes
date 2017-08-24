using System.Text;
using Microsoft.SPOT;
using Samraksh.eMote.Net;

namespace Samraksh.Appnote.Utility
{
	public static class RadioUtilities
	{
		public static void PrintMacInfo(MACBase macBase)
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

		/// <summary>
		/// Send a message to all neighbors
		/// </summary>
		/// <remarks></remarks>
		/// <param name="macBase"></param>
		/// <param name="toSend">String to be sent</param>
		public static void SendToAllNeighbors(MACBase macBase, string toSend)
		{
			var toSendByte = Encoding.UTF8.GetBytes(toSend);
			var neighborList = MACBase.NeighborListArray();
			macBase.NeighborList(neighborList);
			foreach (var theNeighbor in neighborList)
			{
				if (theNeighbor == 0)
				{
					break;
				}
				Debug.Print("Sending message \"" + toSend + "\" to " + theNeighbor);
				macBase.Send(theNeighbor, toSendByte, 0, (ushort)toSendByte.Length);
			}
		}

		/// <summary>
		/// Print the neighbor list
		/// </summary>
		/// <param name="prefix">String to be prepended to the list of neighbors</param>
		/// <param name="neighborList">List of neighbors</param>
		public static void PrintNeighborList(string prefix, ushort[] neighborList)
		{
			PrintNumericVals(prefix, neighborList);
		}

		/// <summary>
		/// Print ushort values of an array
		/// </summary>
		/// <param name="prefix">String to be prepended to the print</param>
		/// <param name="ushortArray">List of ushorts</param>
		public static void PrintNumericVals(string prefix, ushort[] ushortArray)
		{
			var msgBldr = new StringBuilder(prefix);
			foreach (var val in ushortArray)
			{
				msgBldr.Append(val + " ");
			}
			Debug.Print(msgBldr.ToString());
		}

		public static string PacketInfo(Packet packet)
		{
			return packet.Src + ", size: " +
			       packet.Size + ", rssi: " +
			       packet.RSSI + ", lqi: " +
			       packet.LQI;
		}
	}
}
