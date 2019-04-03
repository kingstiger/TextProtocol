
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Collections;

namespace Serwer
{
    
    public class Gracz
    {
        public IPEndPoint EP;
        public Pakiet pck = new Pakiet("", "", "", "", "");

        public Gracz(Pakiet p, IPEndPoint ep)
        {
            EP = new IPEndPoint(ep.Address, ep.Port);
            pck = p;
        }
    }

    
    public class Rozgrywka
    {
        public static List<Gracz> gracze = new List<Gracz>();
        UdpClient klient = new UdpClient(8080);
        IPEndPoint from = new IPEndPoint(IPAddress.Any, 0);

        int time = 0, liczba = 0, time_all;
        bool trwa_rozgrywka, has_been_started = false;

        public Rozgrywka()
        {
            trwa_rozgrywka = false;
            RCV();
        }


        static public void PrintBuff(byte [] buff)
        {
            foreach(byte b in buff)
            {
                Console.Write(b.ToString() + " ");
            }
        }
        public void RCV()
        {
            Thread thread = new Thread(send_rem_time);
            Pakiet received = new Pakiet("", "", "", "", "");
            Pakiet answer;
            byte[] buffer = new byte[1024];
            Console.WriteLine("ODBIERANIE> Rozpoczynam odbieranie danych...");
            while (true)
            {
                try
                {
                    buffer = klient.Receive(ref from);
                } catch (Exception e)
                {
                    Console.WriteLine("ROZGRYWKA> Klient wszedl w nadprzestrzen, stracilismy kontakt");
                }
                received.fromByte(buffer);
                Console.WriteLine("ODBIERANIE> Odebrano komunikat:");
                Console.WriteLine(received.toOneStr());
                if (czy_nowy(from))
                {
                    if (received.getOP() == "HelloThere" && received.getOD() == "empty")
                    {
                        Console.WriteLine("ODBIERANIE> Nowy klient!");
                        answer = new Pakiet("HelloThere", "GeneralKenobi", Luzem.RandomSessionId(), "", "");
                        Console.WriteLine("ODBIERANIE> Przydzielono ID -> " + answer.getID());

                        Gracz temp = new Gracz(answer, from);

                        buffer = answer.toByte();
                        klient.Send(buffer, buffer.Length, from);
                        temp.pck.setOP("");
                        temp.pck.setOD("");
                        gracze.Add(temp);
                        if (gracze.Count >= 2 && trwa_rozgrywka == false)
                        {
                            liczba = Luzem.RandomInt();
                            Console.WriteLine("ROZGRYWKA> Rozpoczynam rozgrywke! Wylosowana liczba to: " + liczba);
                            trwa_rozgrywka = true;
                            has_been_started = true;
                            losuj_czas();
                            thread = new Thread(send_rem_time);
                            thread.Start();
                        }
                    }
                    else if (received.getOP() == "GN" && received.getOD() == "RogerRoger")
                    {
                        Console.WriteLine("ODBIERANIE> Klient {0} odebral komunkiat {1}, potwierdza", received.getID(), received.getOP());
                    }
                    else
                    {
                        Console.WriteLine("ODBIERANIE> Nieznany komunikat, odsylam NOK");
                        answer = new Pakiet("", "NOK", "", "", "");
                        buffer = answer.toByte();
                        klient.Send(buffer, buffer.Length, from);
                    }

                }
                else if (!czy_nowy(from))
                {
                    if (received.getOP() == "HelloThere" && received.getOD() == "RogerRoger")
                    {
                        Console.WriteLine("ODBIERANIE> Klient {0} potwierdza odebranie ID", received.getID());
                    }
                    else if (received.getOP() == "HelloThere" && received.getOD() != "RogerRoger")
                    {
                        Console.WriteLine("ODBIERANIE> Klient ktory juz ma ID, wyslal prosbe o ID. Wysylam NOK");
                        answer = new Pakiet("HelloThere", "NOK", "", "", "");
                        buffer = answer.toByte();
                        klient.Send(buffer, buffer.Length, from);
                    }
                    else
                    {
                        if (received.getOP() == "GN" && received.getOD() != "RogerRoger")
                        {
                            Console.WriteLine("ODBIERANIE> Host " + received.getID() + " wyslal liczbe " + received.getLB());
                            string s = received.getLB();
                            string s2 = Luzem.intStr(liczba);
                            if (s == s2)
                            {
                                Console.WriteLine("ODBIERANIE> Liczba zostala odgadnieta przez hosta " + received.getID());
                                answer = new Pakiet("GN", "WIN", received.getID(), "", "");
                                buffer = answer.toByte();
                                klient.Send(buffer, buffer.Length, from);
                                endGame();
                            }
                            else
                            {
                                Console.WriteLine("ODBIERANIE> Liczba nie zostala odgadnieta, rozgrywka trwa dalej. Prawidlowa liczba: " + liczba);
                                answer = new Pakiet("GN", "WN", received.getID(), "", "");
                                buffer = answer.toByte();
                                klient.Send(buffer, buffer.Length, from);
                            }
                        }
                       
                        else if (received.getOP() == "TR" && received.getOD() == "RogerRoger")
                        {
                            Console.WriteLine("ODBIERANIE> Host " + received.getID() + " odebral komunikat z pozostalym czasem. Liczba do zgadniecia: " + liczba);
                        }
                        else if (received.getOP() == "ItIsOverAnakin")
                        {
                            Console.WriteLine("ODBIERANIE> Klient " + received.getID() + " wyszedl z gry");
                            answer = new Pakiet("ItIsOverAnakin", "RogerRoger", received.getID(), "", "");
                            buffer = answer.toByte();
                            klient.Send(buffer, buffer.Length, from);
                            gracze.RemoveAt(FindGracz(received.getID()));
                            if (gracze.Count < 2)
                            {
                                Console.WriteLine("Za malo graczy, koniec gry");
                                endGame();
                                thread.Join();
                            }
                        }
                        else if (received.getOD() == "RogerRoger" || received.getOD() == "OK")
                        {
                            //w sumie to nic
                            Console.WriteLine("ODBIERANIE> Klient {0} odebral komunkiat {1}, potwierdza", received.getID(), received.getOP());
                        }
                        else
                        {
                            Console.WriteLine("ODBIERANIE> Nieznany kommunikat od hosta " + received.getID());
                            Console.WriteLine("Tresc komunikatu: " + received.toOneStr());
                            answer = new Pakiet("", "NOK", "", "", "");
                            buffer = answer.toByte();
                            klient.Send(buffer, buffer.Length, from);
                        }
                        if (!trwa_rozgrywka && has_been_started) thread.Join();
                    }
                }
            }
        }

        public int FindGracz(string ID)
        {
            for (int i = 0; i < gracze.Count; i++)
            {
                if (gracze[i].pck.getID() == ID) return i;
            }
            return -1; 
        }

        public void endGame()
        {
            Pakiet RT;
            byte[] bff;
            foreach (Gracz g in gracze)
            {
                RT = new Pakiet("ItIsOverAnakin", "", g.pck.getID(), "", "");
                bff = RT.toByte();
                klient.Send(bff, bff.Length, g.EP);
            }
            if (time <= 0)
            {
                Console.WriteLine("ROZGRYWKA> Zakonczono rozgrywke. Calkowity czas rozgrywki: " + time_all);
            } else
            {
                time_all = time_all - time;
                Console.WriteLine("ROZGRYWKA> Zakonczono rozgrywke. Calkowity czas rozgrywki: " + time_all);
            }
            trwa_rozgrywka = false;
            gracze = new List<Gracz>();
        }

        public bool czy_nowy(IPEndPoint endp)
        {
            for (int i = 0; i < gracze.Count; i++)
            {
                if(gracze[i].EP.Port == endp.Port)
                {
                    return false;
                }
            }

            return true;
        }

        public void losuj_czas()
        {
            int one = Luzem.strInt(gracze[0].pck.getID());
            int two = Luzem.strInt(gracze[1].pck.getID());
            time = (((one + two) * 99) % 100) + 30;
            time_all = time;
        }

        public void send_rem_time()
        {
            int j = 0;
            while (trwa_rozgrywka)
            {
                
                Pakiet RT;
                byte[] bff;
                if (time > 0 && j%10 == 0)
                {
                    Console.WriteLine("POZOSTAŁY CZAS> " + time);
                    for (int i = 0; i < gracze.Count; i++)
                    {
                        RT = new Pakiet("TR", "", gracze[i].pck.getID(), Luzem.intStr(time), "");
                        bff = RT.toByte();
                        klient.Send(bff, bff.Length, gracze[i].EP);
                    }
                }
                else if(time < 0)
                {
                    endGame();
                }
                Thread.Sleep(1000);
                j++;
                time = time - 1;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rozgrywka game = new Rozgrywka();
        }
    }
}
