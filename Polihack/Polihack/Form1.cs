﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

namespace Polihack
{
    public partial class Form1 : Form
    {
        public static string theme; = "dark";
        public static Thread IPC_thread;
        public delegate void StartOverlay();
        public StartOverlay overlay_delegate;
        public static bool loaded_already = false;
        public Form1()
        {
            InitializeComponent();
            if (!loaded_already)
            {
                Process[] proc = Process.GetProcessesByName("Key_grab");
                foreach (Process p in proc)
                    p.Kill();
                try
                {
                    Process.Start("Key_grab.exe");
                }
                catch
                {
                    MessageBox.Show("Error opening key_catcher");
                }
                Form1.loaded_already = true;
                overlay_delegate = new StartOverlay(startOverlay_method);
                IPC_thread = new Thread(new ThreadStart(pick_call));
                IPC_thread.IsBackground = true;
                IPC_thread.Start();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Process[] proc = Process.GetProcessesByName("Key_grab");
            foreach (Process p in proc)
            {
                try
                {
                    p.Kill();
                }
                catch
                {
                }
            }
        }

        public void test()
        {
        }

        public void pick_call()
        {
            byte[] buffer;
            Socket sck;
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Bind(new IPEndPoint(0, 1234));
            while (true)
            {
                sck.Listen(100);
                Socket accepted = sck.Accept();
                buffer = new byte[accepted.SendBufferSize];
                int bytesRead = accepted.Receive(buffer);
                byte[] formatted = new byte[bytesRead];
                for (int i = 0; i < bytesRead; i++)
                {
                    formatted[i] = buffer[i];
                }
                string strData = Encoding.ASCII.GetString(formatted);
                if (strData == "yada")//We got the call
                {
                    this.Invoke(this.overlay_delegate);
                }
                accepted.Close();

            }
        }
        
        public void startOverlay_method()
        {
            bool can_be_opened = true;
            FormCollection forms = Application.OpenForms;
            foreach (Form i in forms)
            {
                if (i.Text == "InputOverlay")
                    can_be_opened = false;
            }
            if (can_be_opened)
            {
                InputOverlay ov = new InputOverlay(Form1.theme);
                ov.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //test();
            

            Button btn = new Button();
            btn = button1;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.Gray;
            btn.FlatAppearance.BorderSize = 2;
        }
        #region
        public void theme_light()
        {
            Form1 dark = new Form1();
            Button btn = new Button();
            this.BackColor = System.Drawing.Color.White;
            btn = button1;
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.FlatAppearance.BorderColor = Color.Aquamarine;
            btn.FlatAppearance.BorderSize = 2;
            btn = button2;
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.FlatAppearance.BorderColor = Color.Aquamarine;
            btn.FlatAppearance.BorderSize = 1;
            btn = button3;
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.FlatAppearance.BorderColor = Color.Aquamarine;
            btn.FlatAppearance.BorderSize = 1;

        }

        public void theme_dark()
        {
            Form1 dark = new Form1();
            Button btn = new Button();
            this.BackColor = System.Drawing.Color.Black;
            btn = button1;
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.FromArgb(33, 33, 33); ;
            btn.ForeColor = Color.Gray;
            btn.FlatAppearance.BorderColor = Color.Gray;
            btn.FlatAppearance.BorderSize = 2;
            btn = button2;
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.FromArgb(33, 33, 33); ;
            btn.ForeColor = Color.Gray;
            btn.FlatAppearance.BorderColor = Color.Gray;
            btn.FlatAppearance.BorderSize = 1;
            btn = button3;
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.FromArgb(33, 33, 33); ;
            btn.ForeColor = Color.Gray;
            btn.FlatAppearance.BorderColor = Color.Gray;
            btn.FlatAppearance.BorderSize = 1;

        }
        #endregion
        public void doit()
        {
            if (theme == "dark")
            {
                theme = "light";
                theme_light();
            }
            else
            {
                theme_dark();
                theme = "dark";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            doit();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image_Form obj = new Image_Form(theme);
            obj.Show();
            this.Hide();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Diary obj = new Diary(theme);
            obj.Show();
            this.Hide();
        }
        private void Diary_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GoogleDriveManager manager = new GoogleDriveManager();
            manager.backup_data();
        }
    }
}
