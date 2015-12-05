using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Polihack
{
    public partial class Diary : Form
    {
      
        public string s;
        public bool first = true;
        public Diary(string theme)
        {
            InitializeComponent();
            label2.Text = theme;
            label2.ForeColor = textBox1.BackColor;
            s = theme;
             
           // theme_dark();
        }
       
        public Diary()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder g =  new StringBuilder();
            string c;
                c = textBox1.Text;
                
            using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(Constants.root_path + "\\"+c + ".txt"))
            {
                string s;
                s = label2.Text;
                file.Write(s);
            }
        }
        public void theme_dark()
        {
           // s = label2.Text;
           // if ((s == "light")|| ((first == true) && (s == "dark")))
           // {
                s = "dark";
                Diary dark = new Diary();
                Button btn = new Button();
                this.BackColor = System.Drawing.Color.Black;
                btn = button1;
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.FromArgb(33, 33, 33);
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
                label1.ForeColor = Color.White;
                textBox2.BackColor = Color.FromArgb(33, 33, 33);
                textBox1.BackColor = Color.FromArgb(33, 33, 33);
                first = false;
               // label2.Text = s;
               // label2.ForeColor = textBox1.BackColor;
          //  }
            
        }
        public void theme_light()
        {
           // s = label2.Text;
            // if ((s == "dark")|| ((first == true) && (s == "light")))
            //{
                s = "light";
                Diary dark = new Diary();
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
                textBox1.BackColor = btn.BackColor;
                textBox2.BackColor = textBox1.BackColor;
                label1.ForeColor = Color.Black;
                //label2.Text = s;
                //label2.ForeColor = textBox1.BackColor;
                first = false;
           // }

        }
        private void Diary_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string aux1;
            string aux2;
            aux1 = textBox1.Text;
            aux2 =label1.Text;
            if (s == "light")
            theme_dark();
            else
            theme_light();
            label1.Text = aux2;
            textBox1.Text = aux1;
        }

        private void Diary_Load(object sender, EventArgs e)
        {
            if (s == "dark")
                theme_dark();
           if (first ==  true)
               theme_light();
           label2.Hide();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 bec = new Form1();
            bec.Show();
        }

    }
}
