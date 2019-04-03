namespace KLIENTTEKSTOWY
{
    partial class MainWindow
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabControl = new System.Windows.Forms.TabControl();
            this.Connect = new System.Windows.Forms.TabPage();
            this.SessionIDInfo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GetSessionID = new System.Windows.Forms.Button();
            this.SessionID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ServerPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ServerIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Guess = new System.Windows.Forms.TabPage();
            this.TimeLeft = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.GuessNumberInfo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ReadyToSend = new System.Windows.Forms.CheckBox();
            this.GuessNumber = new System.Windows.Forms.Button();
            this.Number = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Log = new System.Windows.Forms.TabPage();
            this.LogTextBox = new System.Windows.Forms.RichTextBox();
            this.DeleteID = new System.Windows.Forms.Button();
            this.TabControl.SuspendLayout();
            this.Connect.SuspendLayout();
            this.Guess.SuspendLayout();
            this.Log.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.Connect);
            this.TabControl.Controls.Add(this.Guess);
            this.TabControl.Controls.Add(this.Log);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Multiline = true;
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(672, 398);
            this.TabControl.TabIndex = 0;
            // 
            // Connect
            // 
            this.Connect.Controls.Add(this.DeleteID);
            this.Connect.Controls.Add(this.SessionIDInfo);
            this.Connect.Controls.Add(this.label4);
            this.Connect.Controls.Add(this.GetSessionID);
            this.Connect.Controls.Add(this.SessionID);
            this.Connect.Controls.Add(this.label3);
            this.Connect.Controls.Add(this.ServerPort);
            this.Connect.Controls.Add(this.label2);
            this.Connect.Controls.Add(this.ServerIP);
            this.Connect.Controls.Add(this.label1);
            this.Connect.Location = new System.Drawing.Point(4, 22);
            this.Connect.Name = "Connect";
            this.Connect.Padding = new System.Windows.Forms.Padding(3);
            this.Connect.Size = new System.Drawing.Size(664, 372);
            this.Connect.TabIndex = 0;
            this.Connect.Text = "Zdobądź ID Sesji!";
            this.Connect.UseVisualStyleBackColor = true;
            // 
            // SessionIDInfo
            // 
            this.SessionIDInfo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SessionIDInfo.Location = new System.Drawing.Point(112, 68);
            this.SessionIDInfo.Name = "SessionIDInfo";
            this.SessionIDInfo.Size = new System.Drawing.Size(232, 20);
            this.SessionIDInfo.TabIndex = 8;
            this.SessionIDInfo.TextChanged += new System.EventHandler(this.SessionIDInfo_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Info";
            // 
            // GetSessionID
            // 
            this.GetSessionID.Location = new System.Drawing.Point(218, 22);
            this.GetSessionID.Name = "GetSessionID";
            this.GetSessionID.Size = new System.Drawing.Size(126, 33);
            this.GetSessionID.TabIndex = 6;
            this.GetSessionID.Text = "Chce moje ID!";
            this.GetSessionID.UseVisualStyleBackColor = true;
            this.GetSessionID.Click += new System.EventHandler(this.GetSessionID_Click);
            // 
            // SessionID
            // 
            this.SessionID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SessionID.Location = new System.Drawing.Point(6, 68);
            this.SessionID.Name = "SessionID";
            this.SessionID.ReadOnly = true;
            this.SessionID.Size = new System.Drawing.Size(100, 20);
            this.SessionID.TabIndex = 5;
            this.SessionID.TextChanged += new System.EventHandler(this.SessionID_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "ID Sesji";
            // 
            // ServerPort
            // 
            this.ServerPort.Location = new System.Drawing.Point(112, 29);
            this.ServerPort.Name = "ServerPort";
            this.ServerPort.Size = new System.Drawing.Size(100, 20);
            this.ServerPort.TabIndex = 3;
            this.ServerPort.Text = "8080";
            this.ServerPort.TextChanged += new System.EventHandler(this.ServerPort_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // ServerIP
            // 
            this.ServerIP.Location = new System.Drawing.Point(6, 29);
            this.ServerIP.Name = "ServerIP";
            this.ServerIP.Size = new System.Drawing.Size(100, 20);
            this.ServerIP.TabIndex = 1;
            this.ServerIP.Text = "192.168.0.1";
            this.ServerIP.TextChanged += new System.EventHandler(this.ServerIP_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adres IP";
            // 
            // Guess
            // 
            this.Guess.Controls.Add(this.TimeLeft);
            this.Guess.Controls.Add(this.label7);
            this.Guess.Controls.Add(this.GuessNumberInfo);
            this.Guess.Controls.Add(this.label6);
            this.Guess.Controls.Add(this.ReadyToSend);
            this.Guess.Controls.Add(this.GuessNumber);
            this.Guess.Controls.Add(this.Number);
            this.Guess.Controls.Add(this.label5);
            this.Guess.Cursor = System.Windows.Forms.Cursors.No;
            this.Guess.Location = new System.Drawing.Point(4, 22);
            this.Guess.Name = "Guess";
            this.Guess.Padding = new System.Windows.Forms.Padding(3);
            this.Guess.Size = new System.Drawing.Size(664, 372);
            this.Guess.TabIndex = 1;
            this.Guess.Text = "Zgadnij co to za liczba!";
            this.Guess.UseVisualStyleBackColor = true;
            // 
            // TimeLeft
            // 
            this.TimeLeft.Location = new System.Drawing.Point(270, 73);
            this.TimeLeft.Name = "TimeLeft";
            this.TimeLeft.ReadOnly = true;
            this.TimeLeft.Size = new System.Drawing.Size(79, 20);
            this.TimeLeft.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(267, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Pozostały czas:";
            // 
            // GuessNumberInfo
            // 
            this.GuessNumberInfo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GuessNumberInfo.Location = new System.Drawing.Point(82, 30);
            this.GuessNumberInfo.Name = "GuessNumberInfo";
            this.GuessNumberInfo.ReadOnly = true;
            this.GuessNumberInfo.Size = new System.Drawing.Size(267, 20);
            this.GuessNumberInfo.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(82, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Info";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // ReadyToSend
            // 
            this.ReadyToSend.Appearance = System.Windows.Forms.Appearance.Button;
            this.ReadyToSend.AutoCheck = false;
            this.ReadyToSend.AutoSize = true;
            this.ReadyToSend.BackColor = System.Drawing.Color.Crimson;
            this.ReadyToSend.Location = new System.Drawing.Point(199, 73);
            this.ReadyToSend.Name = "ReadyToSend";
            this.ReadyToSend.Size = new System.Drawing.Size(65, 23);
            this.ReadyToSend.TabIndex = 3;
            this.ReadyToSend.Text = "Gotowość";
            this.ReadyToSend.UseVisualStyleBackColor = false;
            this.ReadyToSend.CheckedChanged += new System.EventHandler(this.ReadyToSend_CheckedChanged);
            // 
            // GuessNumber
            // 
            this.GuessNumber.Location = new System.Drawing.Point(6, 56);
            this.GuessNumber.Name = "GuessNumber";
            this.GuessNumber.Size = new System.Drawing.Size(70, 37);
            this.GuessNumber.TabIndex = 2;
            this.GuessNumber.Text = "Zgaduj!";
            this.GuessNumber.UseVisualStyleBackColor = true;
            this.GuessNumber.Click += new System.EventHandler(this.GuessNumber_Click);
            // 
            // Number
            // 
            this.Number.Location = new System.Drawing.Point(6, 30);
            this.Number.Name = "Number";
            this.Number.Size = new System.Drawing.Size(70, 20);
            this.Number.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Liczba";
            // 
            // Log
            // 
            this.Log.Controls.Add(this.LogTextBox);
            this.Log.Location = new System.Drawing.Point(4, 22);
            this.Log.Name = "Log";
            this.Log.Padding = new System.Windows.Forms.Padding(3);
            this.Log.Size = new System.Drawing.Size(671, 375);
            this.Log.TabIndex = 2;
            this.Log.Text = "Log";
            this.Log.UseVisualStyleBackColor = true;
            this.Log.Click += new System.EventHandler(this.Log_Click);
            // 
            // LogTextBox
            // 
            this.LogTextBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.LogTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.LogTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogTextBox.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.LogTextBox.Location = new System.Drawing.Point(6, 6);
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.Size = new System.Drawing.Size(659, 363);
            this.LogTextBox.TabIndex = 0;
            this.LogTextBox.Text = "";
            this.LogTextBox.TextChanged += new System.EventHandler(this.LogTextBox_TextChanged);
            // 
            // DeleteID
            // 
            this.DeleteID.BackColor = System.Drawing.Color.OrangeRed;
            this.DeleteID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DeleteID.Location = new System.Drawing.Point(6, 94);
            this.DeleteID.Name = "DeleteID";
            this.DeleteID.Size = new System.Drawing.Size(75, 23);
            this.DeleteID.TabIndex = 9;
            this.DeleteID.Text = "delet dis id";
            this.DeleteID.UseVisualStyleBackColor = false;
            this.DeleteID.Click += new System.EventHandler(this.DeleteID_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 422);
            this.Controls.Add(this.TabControl);
            this.Name = "MainWindow";
            this.Text = "Nie zganiesz co to za liczba - Klient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.TabControl.ResumeLayout(false);
            this.Connect.ResumeLayout(false);
            this.Connect.PerformLayout();
            this.Guess.ResumeLayout(false);
            this.Guess.PerformLayout();
            this.Log.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage Connect;
        private System.Windows.Forms.TabPage Guess;
        private System.Windows.Forms.TabPage Log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public  System.Windows.Forms.RichTextBox LogTextBox;
        public System.Windows.Forms.TextBox ServerIP;
        public System.Windows.Forms.TextBox ServerPort;
        public System.Windows.Forms.Button GetSessionID;
        public System.Windows.Forms.TextBox SessionID;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox SessionIDInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button GuessNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.CheckBox ReadyToSend;
        public System.Windows.Forms.TextBox TimeLeft;
        private System.Windows.Forms.Label label7;
		public System.Windows.Forms.TextBox GuessNumberInfo;
        public System.Windows.Forms.Button DeleteID;
        public System.Windows.Forms.TextBox Number;
    }
}

