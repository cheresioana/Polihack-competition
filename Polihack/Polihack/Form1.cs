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
    public partial class Form1 : Form
    {
        public string theme = "dark";
        public Form1()
        {
            InitializeComponent();
        }

        public void test()
        {
            DataManager manager_test = new DataManager(@"C:\Users\Rares\Desktop\store", Constants.MainTypes.web);
            //string rez = manager_test.entry_data(Constants.SubTypes.Text, Constants.DataType.text, 1, "suka.txt") as string;
            //MessageBox.Show(rez);
            //MessageBox.Show(manager_test.error_code.ToString());
            //MessageBox.Show(manager_test.entry_created("TEST").ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            test();
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
            Diary obj = new Diary(theme);
            obj.Show();
            this.Hide();
        }
        private void Diary_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
