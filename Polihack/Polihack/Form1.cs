using System;
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

namespace Polihack
{
    public partial class Form1 : Form
    {
        public string theme = "dark";
        public static Thread IPC_thread;
        public delegate void StartOverlay();
        public StartOverlay overlay_delegate;

        public Form1()
        {
            InitializeComponent();
        }

        public void test()
        {
            //DataManager manager_test = new DataManager(@"C:\Users\Rares\Desktop\store", Constants.MainTypes.web);
            //string rez = manager_test.entry_data(Constants.SubTypes.Text, Constants.DataType.text, 1, "suka.txt") as string;
            //MessageBox.Show(rez);
            //MessageBox.Show(manager_test.error_code.ToString());
            //MessageBox.Show(manager_test.entry_created("TEST").ToString());

        }

        public void pick_call()//socket IPC code
        {
            byte[] buffer;
            Socket sck;
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Bind(new IPEndPoint(0, 1234));
            while (true)//should close sck at some point :)
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
                    MessageBox.Show("Yada");
                    //InputOverlay overaly = new InputOverlay(Constants.SubTypes.Link);
                    this.Invoke(this.overlay_delegate);
                }
                //Console.Write(strData + "\r\n");
                accepted.Close();
                //if (strData == "STOP")
                //    break;

            }
            //sck.Close();
        }
        
        public void startOverlay_method()
        {
            InputOverlay ov = new InputOverlay(Constants.SubTypes.Link);
            ov.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //test();
            overlay_delegate = new StartOverlay(startOverlay_method);
            IPC_thread = new Thread(new ThreadStart(pick_call));//socket IPC thread
            IPC_thread.Start();//socket IPC thread

            Button btn = new Button();
            btn = button1;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.Gray;
            btn.FlatAppearance.BorderSize = 2;
        }
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
            Image_Form obj = new Image_Form();
            obj.Show();
            this.Hide();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Diary obj = new Diary(theme);
            //obj.Show();
            this.Hide();
        }
        private void Diary_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
