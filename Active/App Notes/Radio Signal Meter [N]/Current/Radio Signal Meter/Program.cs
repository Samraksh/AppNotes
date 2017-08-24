/*--------------------------------------------------------------------
 * Radio Signal Meter: app note for the eMote .NOW
 * (c) 2013 The Samraksh Company

 *  Remarks
 *      In RadioConfiguration.cs, specify the protocol and radio
---------------------------------------------------------------------*/

using System;
using System.Reflection;
using System.Text;
using System.Threading;
using Microsoft.SPOT;
using Samraksh.Appnote.Utility;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.Net;
using Samraksh.eMote.Net.MAC;

namespace Samraksh.AppNote.DotNow.SignalMeter
{

	/// <summary>
	/// This program listens for radio packets and prints information about identity, signal strength, etc.
	/// It also periodically sends radio packets that another mote can listen to.
	/// It can help you debug another program by "sniffing" what's coming over the radio.
	/// </summary>
	public class Program
	{
		private static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();
		private static MACBase _macBase;

		private static int _sendCounter;
		private const string Header = "SignalMeter";
		private const int SendDelay = 1000; // ms

		/// <summary>
		/// Set up the radio to listen and to send
		/// </summary>
		public static void Main()
		{

			//Debug.EnableGCMessages(false); // We don't want to see garbage collector messages in the Output window

			// Print out the program name and version
			Debug.Print(VersionInfo.VersionBuild(Assembly.GetExecutingAssembly()));

			// Set up LCD and display a welcome message
			Lcd.Write("Strt");
			Thread.Sleep(4000);

			_macBase = RadioConfiguration.GetMAC();
			_macBase.OnReceive += RadioReceive;
			_macBase.OnNeighborChange += MacBase_OnNeighborChange;

			RadioUtilities.PrintMacInfo(_macBase);


			// Show that we've initialized and are running
			Lcd.Write("Run");

			while (true)
			{
				try
				{
					// Send a probe
					RadioUtilities.SendToAllNeighbors(_macBase, Header + " " + _sendCounter++);
					Thread.Sleep(SendDelay);
				}
				catch
				{
					Lcd.Write("Errr");
					Thread.Sleep(Timeout.Infinite);
				}
			}
			// ReSharper disable once FunctionNeverReturns
		}

		/// <summary>
		/// Handle a received message
		/// </summary>
		/// <param name="imac"></param>
		/// <param name="dateTime"></param>
		/// <param name="packet"></param>
		private static void RadioReceive(IMAC imac, DateTime dateTime, Packet packet)
		{
			var rcvPayloadBytes = packet.Payload;
			Debug.Print("\nReceived " + " message # " + _rcvCntr + " from src: " + packet.Src + ", size: " + packet.Size + ", rssi: " + packet.RSSI + ", lqi: " + packet.LQI);
			var rcvPayloadStrBldr = new StringBuilder();
			foreach (var theByte in rcvPayloadBytes)
			{
				rcvPayloadStrBldr.Append(theByte.ToString());
				rcvPayloadStrBldr.Append(" ");
			}
			Debug.Print("   " + rcvPayloadStrBldr);
			Lcd.Write(_rcvCntr++);
		}

		private static int _rcvCntr;

		static void MacBase_OnNeighborChange(IMAC imac, DateTime dateTime)
		{
			var neighborList = MACBase.NeighborListArray();
			imac.NeighborList(neighborList);
			RadioUtilities.PrintNeighborList("\nNeighbor list CHANGE for Node [" + _macBase.MACRadioObj.RadioAddress + "]: ", neighborList);
		}


	}
}


