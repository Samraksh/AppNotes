using System;
using Microsoft.SPOT;
using System.Threading;

using Samraksh.SPOT.Hardware.EmoteDotNow;

namespace Hello_World {
    public class Program {
        public static void Main() {
            Debug.Print(Resources.GetString(Resources.StringResources.String1));
            EmoteLCD lcd = new EmoteLCD();
            string msg = "Hello World  ";
            lcd.Initialize();
            lcd.Write(LCD.CHAR_1, LCD.CHAR_2, LCD.CHAR_3, LCD.CHAR_4);
            Thread.Sleep(3000);

            LCD char1, char2, char3, char4;
            for (int index = 0; index < 10000; index++) {
                GetFour(msg, index, out char1, out char2, out char3, out char4);
                lcd.Write(char1, char2, char3, char4);
                Thread.Sleep(500);
            }

        }

        static void GetFour(string msg, int index, out LCD char1, out LCD char2, out LCD char3, out LCD char4) {
            int msglen = msg.Length;
            if (msglen == 0) {
                char1 = char2 = char3 = char4 = LCD.CHAR_0;
                return;
            }
            string msg4 = msg + msg + msg + msg;
            index = index % msglen;
            char1 = GetChar(msg4.Substring(index + 0, 1));
            char2 = GetChar(msg4.Substring(index + 1, 1));
            char3 = GetChar(msg4.Substring(index + 2, 1));
            char4 = GetChar(msg4.Substring(index + 3, 1));
        }

        static LCD GetChar(string theChar) {
            switch (theChar) {
                case "A": return LCD.CHAR_A; 
                case "B": return LCD.CHAR_B;
                case "C": return LCD.CHAR_C;
                case "D": return LCD.CHAR_D;
                case "E": return LCD.CHAR_E;
                case "F": return LCD.CHAR_F;
                case "G": return LCD.CHAR_G;
                case "H": return LCD.CHAR_H;
                case "I": return LCD.CHAR_I;
                case "J": return LCD.CHAR_J;
                case "K": return LCD.CHAR_K;
                case "L": return LCD.CHAR_K;
                case "M": return LCD.CHAR_M;
                case "N": return LCD.CHAR_N;
                case "O": return LCD.CHAR_O;
                case "P": return LCD.CHAR_P;
                case "Q": return LCD.CHAR_Q;
                case "R": return LCD.CHAR_R;
                case "S": return LCD.CHAR_S;
                case "T": return LCD.CHAR_T;
                case "U": return LCD.CHAR_U;
                case "V": return LCD.CHAR_V;
                case "W": return LCD.CHAR_W;
                case "X": return LCD.CHAR_X;
                case "Y": return LCD.CHAR_Y;
                case "Z": return LCD.CHAR_Z;

                case "a": return LCD.CHAR_a;
                case "b": return LCD.CHAR_b;
                case "c": return LCD.CHAR_c;
                case "d": return LCD.CHAR_d;
                case "e": return LCD.CHAR_e;
                case "f": return LCD.CHAR_f;
                case "g": return LCD.CHAR_g;
                case "h": return LCD.CHAR_h;
                case "i": return LCD.CHAR_i;
                case "j": return LCD.CHAR_j;
                case "k": return LCD.CHAR_k;
                case "l": return LCD.CHAR_l;
                case "m": return LCD.CHAR_m;
                case "n": return LCD.CHAR_n;
                case "o": return LCD.CHAR_o;
                case "p": return LCD.CHAR_p;
                case "q": return LCD.CHAR_q;
                case "r": return LCD.CHAR_r;
                case "s": return LCD.CHAR_s;
                case "t": return LCD.CHAR_t;
                case "u": return LCD.CHAR_u;
                case "v": return LCD.CHAR_v;
                case "w": return LCD.CHAR_w;
                case "x": return LCD.CHAR_x;
                case "y": return LCD.CHAR_y;
                case "z": return LCD.CHAR_z;

                case "0": return LCD.CHAR_0;
                case "1": return LCD.CHAR_1;
                case "2": return LCD.CHAR_2;
                case "3": return LCD.CHAR_3;
                case "4": return LCD.CHAR_4;
                case "5": return LCD.CHAR_5;
                case "6": return LCD.CHAR_6;
                case "7": return LCD.CHAR_7;
                case "8": return LCD.CHAR_8;
                case "9": return LCD.CHAR_9;

                default: return LCD.CHAR_NULL;
            }
        }

    }
}
