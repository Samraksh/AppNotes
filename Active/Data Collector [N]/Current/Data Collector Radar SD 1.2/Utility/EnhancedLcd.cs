/*=========================
 * eMote LCD Enhanced Class
 *  Define the LCD with enhanced interface
 * Versions
 *  1.0 Initial Version
 *  1.1 Made Display more efficient
=========================*/

using Samraksh.eMote.DotNow;

namespace Samraksh.AppNote.Utility {

    /// <summary>
    /// EmoteLCD with initialization and extended methods
    /// </summary>
    /// <remarks>Includes LCD initialization as part of constructor</remarks>
    public class EnhancedEmoteLcd : EmoteLCD {
        /// <summary>
        /// Initialize the LCD
        /// </summary>
        public EnhancedEmoteLcd() {
            // Initialize the display
            Initialize();
        }

        /// <summary>
        /// Display an integer. If more than 4 decimal digits, display first 4 only
        /// </summary>
        /// <param name="num">The number to be displayed</param>
        public void Display(int num) {
            Display(num.ToString());
        }

        /// <summary>
        /// Display a string. If more than 4 characters, display first 4 only
        /// </summary>
        /// <param name="str">The string to be displayed</param>
        public void Display(string str) {
            var msgChar = (str + "    ").ToCharArray();
            Write(msgChar[0].ToLcd(), msgChar[1].ToLcd(), msgChar[2].ToLcd(), msgChar[3].ToLcd());
        }

    }

    /// <summary>
    /// Extend the char class with a method that converts to LCD
    /// </summary>
    public static class LcdExtensions {
        /// <summary>
        /// Converts a char to LCD
        /// </summary>
        /// <remarks>
        /// Example: 'a'.ToLCD()
        /// </remarks>
        /// <param name="charArg">The input as a char</param>
        /// <returns>The corresponding LCD value</returns>
        public static LCD ToLcd(this char charArg) {
            switch (charArg) {
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
