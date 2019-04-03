using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace KLIENTTEKSTOWY
{
    public partial class MainWindow : Form
    {
       
    //Pola do wykorzystania
    private string MessageToSend;
    public byte[] buffer;
    public static UdpClient client_socket;

        public MainWindow()
        {
            InitializeComponent();
            client_socket = new UdpClient(0);
            Thread t = new Thread(new ThreadStart(Recieve));
            t.Start();
        }


        //Moje metody-------------------------------

        public void SetReadyToSend(bool val) //Metoda ustawiająca wartość i kolor czekboksa ReadyToSend
    {
        if (val == false)
        {
                ReadyToSend.Invoke(new Action (() => ReadyToSend.Checked = false));
                ReadyToSend.Invoke(new Action(() => ReadyToSend.BackColor = Color.Crimson));
        }

        else
        {
                ReadyToSend.Invoke(new Action(() => ReadyToSend.Checked = true));
                ReadyToSend.Invoke(new Action(() => ReadyToSend.BackColor = Color.SpringGreen));
            }
    }

    public void SetMessage(string manual) //W celach testowych
    {
        MessageToSend = manual;
    }

    public void SetMessage(string operation, string answer, string sessid, string timer, string number)
    {
        if (operation == "") operation = "empty";
        if (answer == "") answer = "empty";
        if (sessid == "") sessid = "empty";
        if (timer == "") timer = "empty";
        if (number == "") number = "empty";

        MessageToSend = "OP?" + operation + "<<OD?" + answer + "<<ID?" + sessid + "<<TM?" + timer + "<<LB?" + number + "<<ZC?" + DateTime.Now.ToLongTimeString() + "<<";
    } //Metoda ustawiająca pole MessageToSend

    public void SendMessageToServer(int variant) //Metoda wysyłająca wiadomość do servera i ustawiająca flage answer na false
    {
        //Zmienna variant określa przypadki wysyłania wiadomości
        //0 - SendMessage wysyła tab z id sesji
        //1 - SendMessage wysyła tab ze zgadywaniem lub wątek reciever
        //2 - SendMessage ma pozostawić flagę ReadyToSend na true

        //Klika wyjątków do obsłużenia...
        if (variant == 0) //Zakładka Id sesji
        {
            if (MessageToSend == "")
            {
                LogTextBox.Invoke(new Action(() => LogTextBox.AppendText("CORE> User tried to send an empty message!\r\n")));
                MessageToSend = "";
                buffer = null;
                return;
            }
        }

        else if (variant == 1) //Zakładka Zgaduj Liczbę i wątek reciever
        {
            if (MessageToSend == "")
            {
                LogTextBox.Invoke(new Action (() => LogTextBox.AppendText("CORE> User tried to send an empty message!\r\n")));
                MessageToSend = "";
                buffer = null;
                return;
            }

            if (ReadyToSend.Checked == false)
            {
                LogTextBox.Invoke(new Action(() => LogTextBox.AppendText("CORE> Server has not acknoledged previous message!\r\n")));
                GuessNumberInfo.Invoke(new Action(() => GuessNumberInfo.Text = "Nie możesz teraz zgadywać!"));
                MessageToSend = "";
                buffer = null;
                return;
            }
        }
        //Kilka wyjątków do obsłużenia...

        //Jeżeli wszystko jest OK...
        //Adres servera i jego port
        IPAddress server_addr = IPAddress.Parse(ServerIP.Text);
        int server_port;
        Int32.TryParse(ServerPort.Text, out server_port);

        //Tworzenie endpointu i wypełnienie bufora
        IPEndPoint server = new IPEndPoint(server_addr, server_port);
        buffer = Encoding.ASCII.GetBytes(this.MessageToSend);

        //Wysyłanie wiadomości i ustawienie checkboxa ReadyToSend na False
        try
        {
            client_socket.Send(buffer, buffer.Length, server);
        }
        catch (Exception e)
        {
            LogTextBox.Invoke(new Action (() => LogTextBox.AppendText("CORE> WinSock error ocurred while sending a message " + e.ToString() + "\r\n")));
            SetReadyToSend(false);
            MessageToSend = "";
            buffer = null;
            return;
        }
            LogTextBox.Invoke(new Action(() => LogTextBox.AppendText("CORE> User sent message : " + MessageToSend + "\r\n")));

        //Czyszczenie wiadomości i bufora, oraz odznaczenie czekboksa
        if (variant != 2) SetReadyToSend(false);
        MessageToSend = "";
        buffer = null;
    }

        //Reciever
        //------------------------------------------
        //Pola komunikatu
        public string op, od, id, tm, lb, zc;

        //kilka metod...
        string ByteToString(byte[] bytes)
        {
            
            string s = Encoding.ASCII.GetString(bytes);
            return s;
        }

        public void FromByte(byte[] recv)
        {
            string s = ByteToString(recv);
            string temp = "";
            int i;

            for (i = 3; s[i] != '<'; i++)
            {
                temp += s[i];
            }
            op = temp;
            i += 5;
            temp = "";

            for (; s[i] != '<'; i++)
            {
                temp += s[i];
            }
            od = temp;
            i += 5;
            temp = "";

            for (; s[i] != '<'; i++)
            {
                temp += s[i];
            }
            id = temp;
            i += 5;
            temp = "";

            for (; s[i] != '<'; i++)
            {
                temp += s[i];
            }
            tm = temp;
            i += 5;
            temp = "";

            for (; s[i] != '<'; i++)
            {
                temp += s[i];
            }
            lb = temp;
            i += 5;
            temp = "";
            for(; s[i] != '<'; i++)
            {
                temp += s[i];
            }
            zc = temp;
        }

        public void WrongMessage()
        {
            LogTextBox.Invoke(new Action (() => LogTextBox.AppendText("RECIEVER> Server has sent a bad message!\r\n")));
            TimeLeft.Invoke(new Action (() => TimeLeft.Text = ""));
            SessionID.Invoke(new Action (() => SessionID.Text = ""));
            SetReadyToSend(false);
        }

        public void ExecAndAck()
        {
            FromByte(this.buffer);
            //Wybór co robimy na podstawie operacji:

            if (this.op == "HelloThere") //Przydział ID
            {
                if (this.od == "GeneralKenobi") //Serwer przysłał nam nowe ID!
                {
                    SessionID.Invoke(new Action (() => SessionID.Text = this.id));
                    SessionIDInfo.Invoke(new Action(() => SessionIDInfo.Text = "Otrzymano nowe ID od serwera!"));
                    SetReadyToSend(true);

                    //Potwierdzenie komunikatu

                    SetMessage(op, "RogerRoger", id, tm, lb);
                    SendMessageToServer(1);

                    //Sprzątanie

                    SetMessage("");
                    this.buffer = null;
                    return;
                }

                if (this.od == "NOK") //Serwer nie przysłał nam nowego ID!
                {
                    SessionID.Invoke(new Action(() => SessionIDInfo.Text = "Serwer odmówił przydziału ID!"));
                    SetReadyToSend(true);

                    //Potwierdzenie komunikatu

                    SetMessage(op, "RogerRoger", "", tm, lb);
                    SendMessageToServer(1);

                    //Sprzątanie

                    SetMessage("");
                    this.buffer = null;
                    return;
                }
            }

            if (this.op == "TR") //Pozostały czas
            {
                SetReadyToSend(true);
                GuessNumberInfo.Invoke(new Action (() => GuessNumberInfo.Text = "Czas ucieka!"));
                TimeLeft.Invoke(new Action(() => TimeLeft.Text = tm));

                //Potwierdzenie komunikatu

                SetMessage(op, "RogerRoger", id, tm, lb);
                SendMessageToServer(2);

                //Sprzątanie

                SetMessage("");
                this.buffer = null;
                return;
            }

            if (this.op == "GN") //Zgadywanie liczby
            {
                if (this.od == "WN") //Nie zgadłeś
                {
                    GuessNumberInfo.Invoke(new Action(() => GuessNumberInfo.Text = "Zła liczba!"));
                    SetReadyToSend(true);

                    //Potwierdzenie komunikatu

                    SetMessage(op, "RogerRoger", id, tm, lb);
                    SendMessageToServer(2);

                    //Sprzątanie

                    SetMessage("");
                    this.buffer = null;
                    return;
                }

                if (this.od == "WIN")
                {
                    GuessNumberInfo.Invoke(new Action(() => GuessNumberInfo.Text = "Brawo! O tą liczbę mi chodziło!"));
                    Number.Invoke(new Action(() => Number.BackColor = Color.PaleGreen));
                    SetReadyToSend(true);

                    //Potwierdzenie komunikatu

                    SetMessage(op, "RogerRoger", id, tm, lb);
                    SendMessageToServer(1);

                    //Sprzątanie po wygranej!!!
                    LogTextBox.Invoke(new Action (() => LogTextBox.AppendText("RECIEVER> User has won the game! Terminating connection...\r\n")));
                    TimeLeft.Invoke(new Action (() => TimeLeft.Text = ""));
                    SessionID.Invoke(new Action(() => SessionID.Text = ""));
                    SetReadyToSend(false);

                    SetMessage("");
                    this.buffer = null;
                    return;
                }
            }

            if (this.op == "ItIsOverAnakin") //Koniec gry
            {
                LogTextBox.Invoke(new Action(() => LogTextBox.AppendText("RECIEVER> It is over! Server has terminated the communication.\r\n")));
                TimeLeft.Invoke(new Action(() => TimeLeft.Text = ""));
                SessionID.Invoke(new Action(() => SessionID.Text = ""));
                GuessNumberInfo.Invoke(new Action (() => GuessNumberInfo.Text = "To koniec Anakinie, mam wysoką ziemię!"));
                SetReadyToSend(false);

                //?potfierdzenie?

                return;
            }

            //W przypadku, gdy nie trafiliśmy w żadnego ifa
            WrongMessage();
            return;
        }

        public void Recieve()
        {
            IPEndPoint from = new IPEndPoint(IPAddress.Any, 0);
            Thread.Sleep(1000); //Pozbycie się niewygodnych wyjątków

            while (true)
            { 
                LogTextBox.Invoke(new Action(() => LogTextBox.AppendText("RECIEVER> Waiting for data...\r\n")));

                try
                {
                    this.buffer = client_socket.Receive(ref from);
                }
                catch(Exception e)
                {
                    LogTextBox.Invoke(new Action(() => LogTextBox.AppendText("RECIEVER> Socket error while recieving the message! " + e.ToString() + "\r\n")));
                }

                if (buffer.Length > 0)
                {
                    LogTextBox.Invoke(new Action(() => LogTextBox.AppendText("SERVER> " + ByteToString(this.buffer) + "\r\n")));
                    ExecAndAck(); //Uzupełnienie pól klasy
                    LogTextBox.Invoke(new Action(() => LogTextBox.AppendText("\n")));
                }
            }
        }
        //OnClicks----------------------------------

    private void GetSessionID_Click(object sender, EventArgs e)
    {
        if (SessionID.Text != "")
        {
            SessionID.Invoke(new Action(() => SessionIDInfo.Text = "Po co Ci drugie ID?"));
            return;
        }
        else
        {
            SetMessage("HelloThere", "", "", "", "");
            SendMessageToServer(0);
        }
    } //Chcę moje ID!

    private void GuessNumber_Click(object sender, EventArgs e) //Zgaduj liczbę!
    {
        if (Number.Text == "")
        {
            GuessNumberInfo.Invoke(new Action (() => GuessNumberInfo.Text = "Ale podaj tą liczbę, co?"));
            return;
        }

        else if (SessionID.Text == "")
        {
                GuessNumberInfo.Invoke(new Action(() => GuessNumberInfo.Text = "Nie masz ID sesji!"));
            return;
        }

        else
        {
            SetMessage("GN", "", SessionID.Text, "", Number.Text);
            SendMessageToServer(1);
        }
    }

    private void DeleteID_Click(object sender, EventArgs e)
        {
            SessionID.Invoke(new Action(() => SessionID.Text = ""));
            SessionIDInfo.Invoke(new Action(() => SessionIDInfo.Text = "Użytkownik usunął ID sesji!"));
            LogTextBox.Invoke(new Action(() => LogTextBox.Text = "RECIEVER> Waiting for data..."));
        } //DELET ID

        //------------------------------------------



        //Obsolete
        private void ServerIP_TextChanged(object sender, EventArgs e)
    {

    }

    private void ServerPort_TextChanged(object sender, EventArgs e)
    {

    }

    private void SessionIDInfo_TextChanged(object sender, EventArgs e)
    {

    }

    private void SessionID_TextChanged(object sender, EventArgs e)
    {

    }

        private void LogTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Log_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
    {

    }

    private void MainWindow_Load(object sender, EventArgs e)
    {

    }

    private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
    {
        Application.Exit();
        Environment.Exit(Environment.ExitCode);
    }

    private void ReadyToSend_CheckedChanged(object sender, EventArgs e) { }
}
}
