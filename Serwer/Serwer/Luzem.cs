using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwer
{
    public static class Luzem
    {
        static public string RandomSessionId()
        {
            Random random = new Random();
            string SessionId;
            const string chars = "0123456789";
            SessionId = new string(Enumerable.Repeat(chars, 2)
            .Select(s => s[random.Next(s.Length)]).ToArray());
            return SessionId;
        }

        static public int RandomInt()
        {
            int wynik = 0;
            Random rand = new Random();
            wynik = rand.Next(0, 100);
            return wynik;
        }

        static public int strInt(string s)
        {
            int wynik = 0, j = 1;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '1') wynik += 1 * j;
                if (s[i] == '2') wynik += 2 * j;
                if (s[i] == '3') wynik += 3 * j;
                if (s[i] == '4') wynik += 4 * j;
                if (s[i] == '5') wynik += 5 * j;
                if (s[i] == '6') wynik += 6 * j;
                if (s[i] == '7') wynik += 7 * j;
                if (s[i] == '8') wynik += 8 * j;
                if (s[i] == '9') wynik += 9 * j;
                j = j * 10;
            }
            return wynik;
        }

        static public string intStr(int s)
        {
            string wynik = "";
            int temp = s;
            while (temp >= 1)
            {
                if (temp % 10 == 0) wynik = '0' + wynik;
                if (temp % 10 == 1) wynik = '1' + wynik;
                if (temp % 10 == 2) wynik = '2' + wynik;
                if (temp % 10 == 3) wynik = '3' + wynik;
                if (temp % 10 == 4) wynik = '4' + wynik;
                if (temp % 10 == 5) wynik = '5' + wynik;
                if (temp % 10 == 6) wynik = '6' + wynik;
                if (temp % 10 == 7) wynik = '7' + wynik;
                if (temp % 10 == 8) wynik = '8' + wynik;
                if (temp % 10 == 9) wynik = '9' + wynik;
                temp = temp / 10;
            }
            return wynik;
        }

    }
}
