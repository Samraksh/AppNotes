using System;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.Net;
using Samraksh.eMote.Net.MAC;
using BitConverter = Samraksh.AppNote.Utility.BitConverter;
using CommonItems = Samraksh.AppNote.DotNow.RadarDisplacementDetector.Common.CommonItems;

namespace Samraksh.AppNote.DotNow.RadarDisplacement.Receiver
{
	/// <summary>
	/// Radio Updates
	/// </summary>
	public static class RadioMonitorUpdates
	{

		/// <summary>
		/// Receive and handle an update message
		/// </summary>
		public static void ReceiveUpdate(IMAC mac, DateTime dateTime, Packet packet)
		{
			// Show results in LCD positions 1, 3 and 4 (from left)
			const int lcdTogglePos = 5 - 1;
			const int lcdIsDisplacementPos = 5 - 3;
			const int lcdIsConfPos = 5 - 4;

			Debug.Print("Received update");
			var rcvMsg = packet.Payload;
			if (rcvMsg.Length < CommonItems.RadioUpdates.BufferDef.BuffSize)
			{
				Debug.Print("\tBad length: " + rcvMsg.Length);
				return;
			}
			var appIdentifier = BitConverter.ToChar(rcvMsg, CommonItems.RadioUpdates.BufferDef.AppIdentifier);
			if (appIdentifier != CommonItems.RadioUpdates.AppIdentifierHdr)
			{
				Debug.Print("\tBad app identifier: " + appIdentifier);
				return;
			}
			var seqNum = BitConverter.ToInt32(rcvMsg, CommonItems.RadioUpdates.BufferDef.SeqNum);
			var isDisplacement = BitConverter.ToBoolean(rcvMsg, CommonItems.RadioUpdates.BufferDef.IsDisplacement);
			var isConf = BitConverter.ToBoolean(rcvMsg, CommonItems.RadioUpdates.BufferDef.IsConf);
			Debug.Print(string.Empty + 
				CommonItems.MonitorDelimiter.Start1 + CommonItems.MonitorDelimiter.Start2 + CommonItems.MonitorDelimiter.Start3 +
				"\t" + seqNum + "\t" + isDisplacement + "\t" + isConf
				+ CommonItems.MonitorDelimiter.End1);
			Global.Lcd.Clear();
			Global.Lcd.WriteN(lcdTogglePos, _toggle ? 'X'.ToLcd() : ' '.ToLcd());
			Global.Lcd.WriteN(lcdIsDisplacementPos, isDisplacement ? 'd'.ToLcd() : ' '.ToLcd());
			Global.Lcd.WriteN(lcdIsConfPos, isConf ? 'C'.ToLcd() : ' '.ToLcd());
			_toggle = !_toggle;
		}
		//private static readonly EnhancedEmoteLCD Lcd = new EnhancedEmoteLCD();
		private static bool _toggle = true;
	}

}
