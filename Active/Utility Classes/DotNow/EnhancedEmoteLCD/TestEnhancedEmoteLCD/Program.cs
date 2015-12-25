using System;
using System.Text;
using System.Threading;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.DotNow;

namespace TestEnhancedeMoteLCD
{
	public class Program
	{
		private const string OtherAssemblyName = "Samraksh.AppNote.Utility.EnhancedeMoteLcd";
		private static readonly EnhancedEmoteLCD Lcd = new EnhancedEmoteLCD();

		private static int _testNo;

		public static void Main()
		{
			var otherAssemblyFullName = GetOtherAssemblyFullName(OtherAssemblyName);
			Debug.Print("\n\nTest " + otherAssemblyFullName + "\n");

			Thread.Sleep(2000);

			var allPassed = true;

			PrintTestName("Write number");
			Lcd.Write(1234);
			LCD[] charsNumber = { LCD.CHAR_1, LCD.CHAR_2, LCD.CHAR_3, LCD.CHAR_4, };
			allPassed &= PrintCurrentChars(charsNumber);
			Thread.Sleep(3000);

			PrintTestName("Write string");
			Lcd.Write("ABCD");
			LCD[] charsStr = { LCD.CHAR_A, LCD.CHAR_B, LCD.CHAR_C, LCD.CHAR_D, };
			allPassed &= PrintCurrentChars(charsStr);
			Thread.Sleep(3000);

			PrintTestName("Clear");
			Lcd.Clear();
			LCD[] charsClear = { LCD.CHAR_NULL, LCD.CHAR_NULL, LCD.CHAR_NULL, LCD.CHAR_NULL, };
			allPassed &= PrintCurrentChars(charsClear);
			Thread.Sleep(3000);

			PrintTestName("Decimal Points");
			var dP = new bool[4];
			for (var i = 0; i <= dP.Length; i++)
			{
				dP[dP.Length - i - 1] = true;
				Lcd.SetDP(dP[3], dP[2], dP[1], dP[0]);
				Thread.Sleep(1000);
				allPassed &= PrintCurrentDps(dP);
			}
			for (var i = 0; i <= dP.Length; i++)
			{
				dP[4 - i] = false;
				Lcd.SetDP(dP[3], dP[2], dP[1], dP[0]);
				Thread.Sleep(1000);
				allPassed &= PrintCurrentDps(dP);
			}
			Thread.Sleep(2000);

			PrintTestName("Write LCD chars");
			Lcd.Write(LCD.CHAR_9, LCD.CHAR_8, LCD.CHAR_7, LCD.CHAR_6);
			LCD[] charsWrite = { LCD.CHAR_9, LCD.CHAR_8, LCD.CHAR_7, LCD.CHAR_6 };
			allPassed &= PrintCurrentChars(charsWrite);
			Thread.Sleep(3000);

			PrintTestName("Write N");
			Lcd.Write("xxxx");
			for (var i = 0; i < 4; i++)
			{
				Lcd.WriteN(4 - i, (LCD)((int)LCD.CHAR_0 + i));
			}
			LCD[] charsN = { LCD.CHAR_0, LCD.CHAR_1, LCD.CHAR_2, LCD.CHAR_3, };
			allPassed &= PrintCurrentChars(charsN);
			Thread.Sleep(3000);

			PrintTestName("Write Raw");
			Lcd.WriteRawBytes((int)LCD.CHAR_5, (int)LCD.CHAR_4, (int)LCD.CHAR_3, (int)LCD.CHAR_2);
			LCD[] charsRaw = { LCD.CHAR_5, LCD.CHAR_4, LCD.CHAR_3, LCD.CHAR_2 };
			allPassed &= PrintCurrentChars(charsRaw);
			Thread.Sleep(3000);

			Debug.Print("\n==== All passed: " + (allPassed ? "Yes" : "No"));
		}

		private static void PrintTestName(string testName)
		{
			Debug.Print("\n--- Test " + _testNo++ + " " + testName);
		}

		private static bool PrintCurrentChars(LCD[] reqLcdChars)
		{
			var lcdChars = Lcd.CurrentChars;
			var lcdStrBld = new StringBuilder();
			var matches = true;
			for (var i = lcdChars.Length - 1; i > -1; i--)
			{
				if (reqLcdChars[reqLcdChars.Length - 1 - i] != lcdChars[i])
				{
					matches = false;
				}
				lcdStrBld.Append(lcdChars[i].ToChar());
			}
			var lcdStr = lcdStrBld.ToString();
			Debug.Print("\t<<" + lcdStr + ">> Matches: " + (matches ? "Yes" : "No"));
			return matches;
		}

		private static bool PrintCurrentDps(bool[] reqDps)
		{
			var lcdDps = Lcd.CurrentDps;
			var dpsStr = new StringBuilder();
			var matches = true;
			for (var i = lcdDps.Length - 1; i > -1; i--)
			{
				if (reqDps[lcdDps.Length - 1 - i] != lcdDps[i])
				{
					matches = false;
				}
				dpsStr.Append(lcdDps[i] ? 'x' : ' ');
			}
			Debug.Print("\t  4 3 2 1\n\t<<" + dpsStr + ">> Matches: " + (matches ? "Yes" : "No"));
			return matches;
		}

		private static string GetOtherAssemblyFullName(string assemblyName)
		{
			var domainAssemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (var theAssembly in domainAssemblies)
			{
				if (theAssembly.GetName().Name.ToUpper() == assemblyName.ToUpper())
				{
					return theAssembly.FullName;
				}
			}
			return assemblyName + " -- not found --";
		}
	}
}
