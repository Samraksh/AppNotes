/*=========================
 * eMote LCD Enhanced Class
 *  Define the LCD with enhanced interface
 * Versions
 *  1.0 
 *      - Initial Version
 ========================*/

using System;
using Samraksh.eMote.DotNow;

namespace Samraksh.AppNote.Utility
{
	/// <summary>
	/// EmoteLCD with initialization and extended methods
	/// </summary>
	/// <remarks>Includes LCD initialization as part of constructor</remarks>
	public class EnhancedEmoteLCD : EmoteLCD
	{
		// Critical section lock
		private object _criticalSectionLock = new object();

		/// <summary>
		/// Current values displayed
		/// </summary>
		public LCD[] CurrentChars { get; private set; }

		/// <summary>
		/// Current decimal points displayed
		/// </summary>
		public bool[] CurrentDPs { get; private set; }

		/// <summary>
		/// Initialize the LCD
		/// </summary>
		public EnhancedEmoteLCD()
		{
			// Initialize the display
			Initialize();

			// Initialize CurrentChars
			CurrentChars = new LCD[4];
			for (var i = 0; i < CurrentChars.Length; i++)
			{
				CurrentChars[i] = LCD.CHAR_NULL;
			}

			// Initialize CurrentDPs
			CurrentDPs = new bool[4];
		}

		/// <summary>
		/// Display an integer. If more than 4 decimal digits, display first 4 only
		/// </summary>
		/// <param name="num">The number to be displayed</param>
		[Obsolete("Use Write method instead")]
		public void Display(int num)
		{
			Write(num);
		}

		/// <summary>
		/// Write an integer. If more than 4 decimal digits, display first 4 only
		/// </summary>
		/// <param name="num">The number to be displayed</param>
		public void Write(int num)
		{
			Write(num.ToString());
		}

		/// <summary>
		/// Display a string. If more than 4 characters, display first 4 only
		/// </summary>
		/// <param name="str">The string to be displayed</param>
		[Obsolete("Use method Write instead")]
		public void Display(string str)
		{
			var msgChar = (str + "    ").ToCharArray();
			Write(msgChar[0].ToLcd(), msgChar[1].ToLcd(), msgChar[2].ToLcd(), msgChar[3].ToLcd());
		}

		/// <summary>
		/// Write a string. If more than 4 characters, write first 4 only
		/// </summary>
		/// <param name="str">The string to be displayed</param>
		public void Write(string str)
		{
			var msgChar = (str + "    ").ToCharArray();
			Write(msgChar[0].ToLcd(), msgChar[1].ToLcd(), msgChar[2].ToLcd(), msgChar[3].ToLcd());
		}

		#region Overrides //############################################################

		/// <summary>
		/// Clear the display, set CurrentChars to blank and CurrentDPs to false (not present)
		/// </summary>
		/// <returns></returns>
		public new bool Clear()
		{
			lock (_criticalSectionLock)
			{
				for (var i = 0; i < CurrentChars.Length; i++)
				{
					CurrentChars[i] = LCD.CHAR_NULL;
					CurrentDPs[i] = false;
				}
				return base.Clear();
			}
		}

		/// <summary>
		/// Set decimal point
		/// </summary>
		/// <param name="dp1"></param>
		/// <param name="dp2"></param>
		/// <param name="dp3"></param>
		/// <param name="dp4"></param>
		/// <returns></returns>
		// ReSharper disable once InconsistentNaming
		public new bool SetDP(bool dp4, bool dp3, bool dp2, bool dp1)
		{
			lock (_criticalSectionLock)
			{
				CurrentDPs[0] = dp1;
				CurrentDPs[1] = dp2;
				CurrentDPs[2] = dp3;
				CurrentDPs[3] = dp4;
				return base.SetDP(dp4, dp3, dp2, dp1);
			}
		}

		/// <summary>
		/// Write the LCD characters to the display and record in CurrentChars
		/// </summary>
		/// <param name="data4"></param>
		/// <param name="data3"></param>
		/// <param name="data2"></param>
		/// <param name="data1"></param>
		/// <returns></returns>
		public new bool Write(LCD data4, LCD data3, LCD data2, LCD data1)
		{
			lock (_criticalSectionLock)
			{
				CurrentChars[4 - 1] = data4;
				CurrentChars[3 - 1] = data3;
				CurrentChars[2 - 1] = data2;
				CurrentChars[1 - 1] = data1;
				return base.Write(data4, data3, data2, data1);
			}
		}

		/// <summary>
		/// Write the LCD character in the designated column and record in CurrentChars
		/// </summary>
		/// <param name="column"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public new bool WriteN(int column, LCD data)
		{
			lock (_criticalSectionLock)
			{
				CurrentChars[column - 1] = data;
				return base.WriteN(column, data);
			}
		}

		/// <summary>
		/// Write raw bytes to the display and record in CurrentChars
		/// </summary>
		/// <param name="data4"></param>
		/// <param name="data3"></param>
		/// <param name="data2"></param>
		/// <param name="data1"></param>
		/// <returns></returns>
		public new bool WriteRawBytes(int data4, int data3, int data2, int data1)
		{
			lock (_criticalSectionLock)
			{
				CurrentChars[4 - 1] = (LCD) data4;
				CurrentChars[3 - 1] = (LCD) data3;
				CurrentChars[2 - 1] = (LCD) data2;
				CurrentChars[1 - 1] = (LCD) data1;
				return base.WriteRawBytes(data4, data3, data2, data1);
			}
		}

		#endregion

	}

	/// <summary>
	/// Extend the char class with a method that converts to LCD
	/// </summary>
	public static class LcdExtensions
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="lcdArg"></param>
		/// <returns></returns>
		public static char ToChar(this LCD lcdArg)
		{
			switch (lcdArg)
			{
				case LCD.CHAR_NULL:
					return ' ';

				case LCD.CHAR_A:
					return 'A';
				case LCD.CHAR_B:
					return 'B';
				case LCD.CHAR_C:
					return 'C';
				case LCD.CHAR_D:
					return 'D';
				case LCD.CHAR_E:
					return 'E';
				case LCD.CHAR_F:
					return 'F';
				case LCD.CHAR_G:
					return 'G';
				case LCD.CHAR_H:
					return 'H';
				case LCD.CHAR_I:
					return 'I';
				case LCD.CHAR_J:
					return 'J';
				case LCD.CHAR_K:
					return 'K';
				case LCD.CHAR_L:
					return 'L';
				case LCD.CHAR_M:
					return 'M';
				case LCD.CHAR_N:
					return 'N';
				case LCD.CHAR_O:
					return 'O';
				case LCD.CHAR_P:
					return 'P';
				case LCD.CHAR_Q:
					return 'Q';
				case LCD.CHAR_R:
					return 'R';
				case LCD.CHAR_S:
					return 'S';
				case LCD.CHAR_T:
					return 'T';
				case LCD.CHAR_U:
					return 'U';
				case LCD.CHAR_V:
					return 'V';
				case LCD.CHAR_W:
					return 'W';
				case LCD.CHAR_X:
					return 'X';
				case LCD.CHAR_Y:
					return 'Y';
				case LCD.CHAR_Z:
					return 'Z';

				case LCD.CHAR_a:
					return 'a';
				case LCD.CHAR_b:
					return 'b';
				case LCD.CHAR_c:
					return 'c';
				case LCD.CHAR_d:
					return 'd';
				case LCD.CHAR_e:
					return 'e';
				case LCD.CHAR_f:
					return 'f';
				case LCD.CHAR_g:
					return 'g';
				case LCD.CHAR_h:
					return 'h';
				case LCD.CHAR_i:
					return 'i';
				case LCD.CHAR_j:
					return 'j';
				case LCD.CHAR_k:
					return 'k';
				case LCD.CHAR_l:
					return 'l';
				case LCD.CHAR_m:
					return 'm';
				case LCD.CHAR_n:
					return 'n';
				case LCD.CHAR_o:
					return 'o';
				case LCD.CHAR_p:
					return 'p';
				case LCD.CHAR_q:
					return 'q';
				case LCD.CHAR_r:
					return 'r';
				case LCD.CHAR_s:
					return 's';
				case LCD.CHAR_t:
					return 't';
				case LCD.CHAR_u:
					return 'u';
				case LCD.CHAR_v:
					return 'v';
				case LCD.CHAR_w:
					return 'w';
				case LCD.CHAR_x:
					return 'x';
				case LCD.CHAR_y:
					return 'y';
				case LCD.CHAR_z:
					return 'z';

				case LCD.CHAR_0:
					return '0';
				case LCD.CHAR_1:
					return '1';
				case LCD.CHAR_2:
					return '2';
				case LCD.CHAR_3:
					return '3';
				case LCD.CHAR_4:
					return '4';
				case LCD.CHAR_5:
					return '5';
				case LCD.CHAR_6:
					return '6';
				case LCD.CHAR_7:
					return '7';
				case LCD.CHAR_8:
					return '8';
				case LCD.CHAR_9:
					return '9';

				default:
					return '*';
			}
		}

		/// <summary>
		/// Converts a char to LCD
		/// </summary>
		/// <remarks>
		/// Example: 'a'.ToLCD()
		/// </remarks>
		/// <param name="charArg">The input as a char</param>
		/// <returns>The corresponding LCD value</returns>
		public static LCD ToLcd(this char charArg)
		{
			switch (charArg)
			{
				case ' ':
					return LCD.CHAR_NULL;

				case 'A':
					return LCD.CHAR_A;
				case 'B':
					return LCD.CHAR_B;
				case 'C':
					return LCD.CHAR_C;
				case 'D':
					return LCD.CHAR_D;
				case 'E':
					return LCD.CHAR_E;
				case 'F':
					return LCD.CHAR_F;
				case 'G':
					return LCD.CHAR_G;
				case 'H':
					return LCD.CHAR_H;
				case 'I':
					return LCD.CHAR_I;
				case 'J':
					return LCD.CHAR_J;
				case 'K':
					return LCD.CHAR_K;
				case 'L':
					return LCD.CHAR_K;
				case 'M':
					return LCD.CHAR_M;
				case 'N':
					return LCD.CHAR_N;
				case 'O':
					return LCD.CHAR_O;
				case 'P':
					return LCD.CHAR_P;
				case 'Q':
					return LCD.CHAR_Q;
				case 'R':
					return LCD.CHAR_R;
				case 'S':
					return LCD.CHAR_S;
				case 'T':
					return LCD.CHAR_T;
				case 'U':
					return LCD.CHAR_U;
				case 'V':
					return LCD.CHAR_V;
				case 'W':
					return LCD.CHAR_W;
				case 'X':
					return LCD.CHAR_X;
				case 'Y':
					return LCD.CHAR_Y;
				case 'Z':
					return LCD.CHAR_Z;

				case 'a':
					return LCD.CHAR_a;
				case 'b':
					return LCD.CHAR_b;
				case 'c':
					return LCD.CHAR_c;
				case 'd':
					return LCD.CHAR_d;
				case 'e':
					return LCD.CHAR_e;
				case 'f':
					return LCD.CHAR_f;
				case 'g':
					return LCD.CHAR_g;
				case 'h':
					return LCD.CHAR_h;
				case 'i':
					return LCD.CHAR_i;
				case 'j':
					return LCD.CHAR_j;
				case 'k':
					return LCD.CHAR_k;
				case 'l':
					return LCD.CHAR_l;
				case 'm':
					return LCD.CHAR_m;
				case 'n':
					return LCD.CHAR_n;
				case 'o':
					return LCD.CHAR_o;
				case 'p':
					return LCD.CHAR_p;
				case 'q':
					return LCD.CHAR_q;
				case 'r':
					return LCD.CHAR_r;
				case 's':
					return LCD.CHAR_s;
				case 't':
					return LCD.CHAR_t;
				case 'u':
					return LCD.CHAR_u;
				case 'v':
					return LCD.CHAR_v;
				case 'w':
					return LCD.CHAR_w;
				case 'x':
					return LCD.CHAR_x;
				case 'y':
					return LCD.CHAR_y;
				case 'z':
					return LCD.CHAR_z;

				case '0':
					return LCD.CHAR_0;
				case '1':
					return LCD.CHAR_1;
				case '2':
					return LCD.CHAR_2;
				case '3':
					return LCD.CHAR_3;
				case '4':
					return LCD.CHAR_4;
				case '5':
					return LCD.CHAR_5;
				case '6':
					return LCD.CHAR_6;
				case '7':
					return LCD.CHAR_7;
				case '8':
					return LCD.CHAR_8;
				case '9':
					return LCD.CHAR_9;

				default:
					return LCD.CHAR_NULL;
			}
		}
	}
}
