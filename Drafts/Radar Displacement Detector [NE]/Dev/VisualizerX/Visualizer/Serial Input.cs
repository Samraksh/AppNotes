using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.SPOT.Debugger;
using Samraksh.AppNote.DotNow.RadarDisplacementDetector.Common;

namespace Visualizer
{
	public static class SerialStuff
	{
		public static class ManageSerialConnection
		{
			public static event Action<List<char>> MsgReady;

			private static Stream _serialStream;
			public static string SerialPortName;

			public static void OpenPort(string serialPortName)
			{
				if (serialPortName == null)
				{
					return;
				}

				serialPortName = serialPortName.Trim();
				_serialStream = null;
				SerialPortName = serialPortName;

				var serialPortNumberStr = serialPortName.Substring(3, serialPortName.Length - 3);
				int serialPortNumber;
				var success = int.TryParse(serialPortNumberStr, out serialPortNumber);
				if (!success || serialPortNumber >= 10)
				{
					ShowPortInvalid(serialPortName);
					return;
				}

				// Set up serial port
				const int serialBitRate = 115200;
				var serialPortDef = PortDefinition.CreateInstanceForSerial(serialPortName, serialPortName, serialBitRate);
				try
				{
					_serialStream = serialPortDef.Open();
				}
				catch (Exception ex)
				{
					ShowPortCannotBeOpened(ex);
					return;
				}

				ShowPortConnected(serialPortName);

				SerialRead();
			}

			public static void ClosePort()
			{
				_serialStream.Close();
				_serialStream.Dispose();

				ShowPortDisconnected();
			}

			private static void ShowPortDisconnected()
			{
			}

			private static void ShowPortConnected(string serialPortName)
			{

			}

			private static void ShowPortCannotBeOpened(Exception ex)
			{

			}

			internal static void ShowPortInvalid(string serialPortName)
			{

			}

			public static void SafeSerialWrite(byte[] buffer, int offset, int count)
			{
				try
				{
					if (!_serialStream.CanWrite)
					{
						return;
					}
					_serialStream.Write(buffer, offset, count);
				}
				catch (Exception)
				{
					// Ignore all exceptions
				}
			}

			/// <summary>
			/// Serial read
			/// </summary>
			/// <remarks>
			/// Using ReadAsync instead of BeginRead.
			/// See https://msdn.microsoft.com/query/dev12.query?appId=Dev12IDEF1&l=EN-US&k=k(System.IO.Stream.BeginRead);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.5);k(DevLang-csharp)&rd=true
			/// and https://msdn.microsoft.com/en-us/library/hh137813(v=vs.110).aspx
			/// </remarks>
			private static async void SerialRead()
			{
				try
				{
					var inputBytes = new byte[1];
					//var inputBuff = new byte[100];
					//int[] inputBuffIndex = { 0 };
					var msgChars = new List<char>();
					while (true)
					{
						await _serialStream.ReadAsync(inputBytes, 0, inputBytes.Length);
						lock (inputBytes)
						{
							foreach (var theByte in inputBytes)
							{
								var theChar = Convert.ToChar(theByte);
								switch (InputStateMachine.InputState)
								{
									case InputStateMachine.InputStates.Waiting:
										if (theChar == CommonItems.MonitorDelimiter.Start1)
										{
											msgChars.Clear();
											InputStateMachine.InputState = InputStateMachine.InputStates.Start1;
										}
										break;
									case InputStateMachine.InputStates.Start1:
										if (theChar == CommonItems.MonitorDelimiter.Start2)
										{
											InputStateMachine.InputState = InputStateMachine.InputStates.Start2;
										}
										break;
									case InputStateMachine.InputStates.Start2:
										if (theChar == CommonItems.MonitorDelimiter.Start3)
										{
											InputStateMachine.InputState = InputStateMachine.InputStates.Reading;
										}
										break;
									case InputStateMachine.InputStates.Reading:
										if (theChar == CommonItems.MonitorDelimiter.End1)
										{
											if (MsgReady != null)
											{
												MsgReady(msgChars);
											}
											InputStateMachine.InputState = InputStateMachine.InputStates.Waiting;
										}
										msgChars.Add(theChar);
										break;
									default:
										break;
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					var errorMsg = string.Format("\n********** Error reading from or processing serial stream\n{0}\n", ex);
					Debug.Print(errorMsg);
				}
			}
		}

		private static class InputStateMachine
		{
			public static InputStates InputState = InputStates.Waiting;

			public enum InputStates
			{
				Waiting,
				Start1,
				Start2,
				Reading,
			}
		}

	}
}
