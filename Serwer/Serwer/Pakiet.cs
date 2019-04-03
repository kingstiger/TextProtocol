using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwer
{
    public class Pakiet
    {
        string OP; //operacja
        string OD; //odpowiedz
        string ID; //identyfikator
        string TM; //ile zostalo czasu
        string LB; //liczba kandydat
        string ZC;

        public Pakiet(string OP, string OD, string ID, string TM, string LB)
        {
            setOP(OP);
            setOD(OD);
            setID(ID);
            setTime(TM);
            setLB(LB);
            setZC();
        }
        public Pakiet(string OP, string OD, string ID, int TM, string LB)
        {
            setOP(OP);
            setOD(OD);
            setID(ID);
            setTime(TM);
            setLB(LB);
        }
        public Pakiet(string OP, string OD, string ID, string TM, int LB)
        {
            setOP(OP);
            setOD(OD);
            setID(ID);
            setTime(TM);
            setLB(LB);
        }
        public Pakiet(string OP, string OD, string ID, int TM, int LB)
        {
            setOP(OP);
            setOD(OD);
            setID(ID);
            setTime(TM);
            setLB(LB);
        }

        public void setZC()
        {
            ZC = "ZC?" + DateTime.Now.ToLongTimeString() + "<<";
        }

        public void setZC(string czas)
        {
            ZC = "ZC?" + czas + "<<";
        }


        public void setOP(string operacja)
        {
            OP = "OP?" + operacja + "<<";
        }

        public void setOD(string odpowiedz)
        {
            if (odpowiedz == "" || odpowiedz == "empty")
                OD = "OD?empty<<";
            else OD = "OD?"+odpowiedz+"<<";
        }

        public void setID(string ID)
        {
            if (ID == "" || ID == "empty")
                this.ID = "ID?empty<<";
            else this.ID = "ID?"+ID+"<<";
        }

        public void setTime(string time)
        {
            if (time == "" || time == "empty")
                TM = "TM?empty<<";
            else TM = "TM?"+time+"<<";
        }

        public void setTime(int time)
        {
            if (time != -1)
                TM = "TM?" + Luzem.intStr(time) + "<<";
            else TM = "TM?empty<<";
        }

        public void setLB(string LB)
        {
            if (LB == "" || LB == "empty")
                this.LB = "LB?empty<<";
            else this.LB = "LB?" + LB + "<<";
        }

        public void setLB(int LB)
        {
            if (LB == -1)
            {
                this.LB = "LB?empty<<";
            }
            else
            {
                this.LB = "LB?" + Luzem.intStr(LB) + "<<";
            }
        }

        public string getID()
        {
            string temp = "";
            for (int i = 3; ID[i] != '<'; i++)
            {
                temp += ID[i];
            }
            return temp;
        }

        public string getOP()
        {
            string temp = "";
            for (int i = 3; OP[i] != '<'; i++)
            {
                temp += OP[i];
            }
            return temp;
        }

        public string getOD()
        {
            string temp = "";
            for (int i = 3; OD[i]!='<'; i++)
            {
                temp += OD[i];
            }
            return temp;
        }

        public string getLB()
        {
            string temp = "";
            for (int i = 3; LB[i] != '<'; i++)
            {
                temp += LB[i];
            }
            return temp;
        }

        public string toOneStr()
        {
            string s = OP + OD + ID + TM + LB + ZC;
            return s;
        }

        public byte[] toByte()
        {
            string s = this.toOneStr();
            byte[] prep = Encoding.Unicode.GetBytes(s);
            byte[] p = Encoding.Convert(Encoding.Unicode, Encoding.ASCII, prep);
            return p;
        }

        string ByteToStr(byte[] bytes)
        {
            string s = Encoding.ASCII.GetString(bytes);
            return s;
        }

        public void fromByte(byte[] recv)
        {
            string s = ByteToStr(recv);
            string temp = "";
            int i;

            for (i = 3; s[i] != '<'; i++)
            {
                temp += s[i];
            }
            setOP(temp);
            i += 5;
            temp = "";

            for (; s[i] != '<'; i++)
            {
                temp += s[i];
            }
            setOD(temp);
            i += 5;
            temp = "";

            for (; s[i] != '<'; i++)
            {
                temp += s[i];
            }
            setID(temp);
            i += 5;
            temp = "";

            for (; s[i] != '<'; i++)
            {
                temp += s[i];
            }
            setTime(temp);
            i += 5;
            temp = "";

            for (; s[i] != '<'; i++)
            {
                temp += s[i];
            }
            setLB(temp);
            i += 5;
            temp = "";

            for (; s[i] != '<'; i++)
            {
                temp += s[i];
            }
            setZC(temp);
        }
    }
}
