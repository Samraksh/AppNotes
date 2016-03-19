using System;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.Net.Mac;

using CommonItems=Samraksh.AppNote.DotNow.RadarDisplacementDetector.Common.CommonItems;

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
		public static void ReceiveUpdate(CSMA csma)
		{
			const int lcdTogglePos = 5 - 1;
			const int lcdIsDisplacementPos = 5 - 3;
			const int lcdIsConfPos = 5 - 4;

			Debug.Print("Received update");
			if (csma == null)
			{
				Debug.Print("\tNull");
				return;
			}
			var rcvMsg = csma.GetNextPacket();
			var rcvPayloadBytes = rcvMsg.GetMessage();
			if (rcvPayloadBytes.Length < CommonItems.RadioUpdates.BufferDef.BuffSize)
			{
				Debug.Print("\tBad length: " + rcvPayloadBytes.Length);
				return;
			}
			var appIdentifier = BitConverter.ToChar(rcvPayloadBytes, CommonItems.RadioUpdates.BufferDef.AppIdentifier);
			if (appIdentifier != CommonItems.RadioUpdates.AppIdentifierHdr)
			{
				Debug.Print("\tBad app identifier: " + appIdentifier);
				return;
			}
			var isDisplacement = BitConverter.ToBoolean(rcvPayloadBytes, CommonItems.RadioUpdates.BufferDef.IsDisplacement);
			var isConf = BitConverter.ToBoolean(rcvPayloadBytes, CommonItems.RadioUpdates.BufferDef.IsConf);
			Debug.Print("\t" + isDisplacement + "\t" + isConf);
			Lcd.Clear();
			Lcd.WriteN(lcdTogglePos, _toggle ? 'X'.ToLcd() : ' '.ToLcd());
			Lcd.WriteN(lcdIsDisplacementPos, isDisplacement ? 'd'.ToLcd() : ' '.ToLcd());
			Lcd.WriteN(lcdIsConfPos, isConf ? 'C'.ToLcd() : ' '.ToLcd());
			_toggle = !_toggle;
		}
		private static readonly EnhancedEmoteLCD Lcd = new EnhancedEmoteLCD();
		private static bool _toggle = true;
	}

}
