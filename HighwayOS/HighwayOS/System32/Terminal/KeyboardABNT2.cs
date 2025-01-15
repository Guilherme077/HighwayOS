using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayOS.System32.Terminal
{
    internal static class KeyboardABNT2
    {
        public static string ConvertToABNT(int nkey, bool upperCase)
        {
            char ckey = ' ';
            string skey = "";
            switch (nkey)
            {
                case 17:
                    ckey = '"';
                    break;
                case 18:
                    ckey = '1';
                    break;
                case 19:
                    ckey = '2';
                    break;
                case 20:
                    ckey = '3';
                    break;
                case 21:
                    ckey = '4';
                    break;
                case 22:
                    ckey = '5';
                    break;
                case 23:
                    ckey = '6';
                    break;
                case 24:
                    ckey = '7';
                    break;
                case 25:
                    ckey = '8';
                    break;
                case 26:
                    ckey = '9';
                    break;
                case 27:
                    ckey = '0';
                    break;
                case 28:
                    ckey = '-';
                    break;
                case 29:
                    ckey = '=';
                    break;
                case 33:
                    ckey = 'q';
                    break;
                case 34:
                    ckey = 'w';
                    break;
                case 35:
                    ckey = 'e';
                    break;
                case 36:
                    ckey = 'r';
                    break;
                case 37:
                    ckey = 't';
                    break;
                case 38:
                    ckey = 'y';
                    break;
                case 39:
                    ckey = 'u';
                    break;
                case 40:
                    ckey = 'i';
                    break;
                case 41:
                    ckey = 'o';
                    break;
                case 42:
                    ckey = 'p';
                    break;
                case 47:
                    ckey = 'a';
                    break;
                case 48:
                    ckey = 's';
                    break;
                case 49:
                    ckey = 'd';
                    break;
                case 50:
                    ckey = 'f';
                    break;
                case 51:
                    ckey = 'g';
                    break;
                case 52:
                    ckey = 'h';
                    break;
                case 53:
                    ckey = 'j';
                    break;
                case 54:
                    ckey = 'k';
                    break;
                case 55:
                    ckey = 'l';
                    break;
                case 56:
                    ckey = 'ç';
                    break;
                case 66:
                    ckey = 'z';
                    break;
                case 67:
                    ckey = 'x';
                    break;
                case 68:
                    ckey = 'c';
                    break;
                case 69:
                    ckey = 'v';
                    break;
                case 70:
                    ckey = 'b';
                    break;
                case 71:
                    ckey = 'n';
                    break;
                case 72:
                    ckey = 'm';
                    break;
                    

            }
            skey = ckey.ToString();
            if(upperCase) skey = ckey.ToString().ToUpper();
            return skey;
        }
    }
}
