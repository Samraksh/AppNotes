using System;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.Net.Mac;
using Samraksh.eMote.Net.Radio;

namespace Receiver
{
	/// <summary>
	/// Radio Updates
	/// </summary>
	public static class RadioUpdates
	{
		/// <summary>Radio object</summary>
		public static SimpleCsmaRadio Radio;

		/// <summary>Radio channel to use</summary>
		public const Channels Channel = Channels.Channel_11;

		/// <summary>Whether or not to send radio updates</summary>
		public static bool EnableRadioUpdates = false;

		/// <summary>Prepended to each packet to identify the app</summary>
		public static char AppIdentifierHdr = 'D';

		/// <summary>
		/// Radio buffer definition
		/// </summary>
		public static class BufferDef
		{
			/// <summary>Radio buffer</summary>
			public static byte[] Buffer = new byte[BuffSize];

			/// <summary>Message type position</summary>
			public const int AppIdentifier = 0;
			/// <summary>Is Displacement? position</summary>
			public const int IsDisplacement = AppIdentifier + sizeof(char);
			/// <summary>Is Confirmed? position</summary>
			public const int IsConf = IsDisplacement + sizeof(bool);
			/// <summary>Buffer size</summary>
			public const int BuffSize = IsConf + sizeof(bool);
		}

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
			if (rcvPayloadBytes.Length < BufferDef.BuffSize)
			{
				Debug.Print("\tBad length: " + rcvPayloadBytes.Length);
				return;
			}
			var appIdentifier = BitConverter.ToChar(rcvPayloadBytes, BufferDef.AppIdentifier);
			if (appIdentifier != AppIdentifierHdr)
			{
				Debug.Print("\tBad app identifier: " + appIdentifier);
				return;
			}
			var isDisplacement = BitConverter.ToBoolean(rcvPayloadBytes, BufferDef.IsDisplacement);
			var isConf = BitConverter.ToBoolean(rcvPayloadBytes, BufferDef.IsConf);
			Debug.Print("\t" + isDisplacement + "\t" + isConf);
			Lcd.Clear();
			Lcd.WriteN(lcdTogglePos, _toggle ? 'X'.ToLcd() : ' '.ToLcd());
			Lcd.WriteN(lcdIsDisplacementPos, isDisplacement ? 'd'.ToLcd() : ' '.ToLcd());
			Lcd.WriteN(lcdIsConfPos, isConf ? 'C'.ToLcd() : ' '.ToLcd());
			_toggle = !_toggle;
		}
		private static readonly EnhancedEmoteLcd Lcd = new EnhancedEmoteLcd();
		private static bool _toggle = true;

		///// <summary>
		///// Send update message
		///// </summary>
		///// <param name="isDisplacement"></param>
		///// <param name="isConf"></param>
		//public static void Update(bool isDisplacement, bool isConf)
		//{
		//	BitConverter.InsertValueIntoArray(BufferDef.Buffer, BufferDef.AppIdentifier, AppIdentifierHdr);
		//	BitConverter.InsertValueIntoArray(BufferDef.Buffer, BufferDef.IsDisplacement, isDisplacement);
		//	BitConverter.InsertValueIntoArray(BufferDef.Buffer, BufferDef.IsConf, isConf);
		//	Radio.SetRadioState(SimpleCsmaRadio.RadioStates.On);
		//	Radio.Send(Addresses.BROADCAST, BufferDef.Buffer);
		//	Radio.SetRadioState(SimpleCsmaRadio.RadioStates.Off);
		//}
	}

}
