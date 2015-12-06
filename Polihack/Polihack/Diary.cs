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
        int id = 1;
        public bool first = true;
        public Diary(string theme)
        {
            InitializeComponent();
            s = theme;
        }
       
        public Diary()
        {
            InitializeComponent();

        }

        public void Load_data(int start)
        {
            
            int i;
            Constants.SubTypes sub_type = Constants.SubTypes.Text;
            DataManager data_manager = new DataManager(Constants.root_path, Constants.MainTypes.text);
           
           
            if (!(data_manager.entry_exists(sub_type, id + 3)))
                button6.Hide();
            else button6.Show();
            if (id == 1)
                button5.Hide();
            else button5.Show();

            for (i = 0; i < 3 ; i++)
            {
               
                if (data_manager.entry_exists(sub_type, start + i))
                {
                    
                    string data = data_manager.entry_data(sub_type, Constants.DataType.text, start + i, "title_desc.txt") as string;
              
                    data = data.Replace(";", System.Environment.NewLine);
                    switch (i)
                    {
                        case 0:
                            {
                                textBox3.Text = data;
                                break;
                            }
                        case 1:
                            {
                                textBox4.Text = data;
                                break;
                            }
                        case 2:
                            {
                                textBox5.Text = data;
                                break;
                            }
                    }
                }
                else
                {
                    switch (i)
                    {
                        case 0:
                            {
                                textBox3.Hide();
                                break;
                            }
                        case 1:
                            {
                                textBox4.Hide();
                                break;
                            }
                        case 2:
                            {
                                textBox5.Hide();
                                break;
                            }
                    }
                }
             }
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            Constants.SubTypes type = Constants.SubTypes.Text;

            DataManager manager = new DataManager(Constants.root_path, Constants.MainTypes.text);
            Int64 lastid = manager.last_id_get(type);
            
            manager.add_subType_csv(type, textBox1.Text, lastid + 1);//used for search indexing

            manager.last_id_set(type, lastid + 1);
            manager.create_entry(type, lastid + 1);
            manager.add_entry_data(Constants.DataType.text, type, lastid + 1, "title_desc.txt",
                textBox1.Text + ";" + textBox2.Text);
            textBox1.Text = null;
            textBox2.Text = null;
            main_page();
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
                //textBox2.BackColor = Color.FromArgb(33, 33, 33);
                //textBox1.BackColor = Color.FromArgb(33, 33, 33);
                textBox2.ForeColor = Color.White;
                textBox3.ForeColor = Color.White;
                textBox4.ForeColor = Color.White;
                textBox5.ForeColor = Color.White;
                textBox2.BackColor = Color.Black;
                textBox3.BackColor = Color.Black;
                textBox4.BackColor = Color.Black;
                textBox5.BackColor = Color.Black;
                btn = button4;
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.FromArgb(33, 33, 33); ;
                btn.ForeColor = Color.Gray;
                btn.FlatAppearance.BorderColor = Color.Gray;
                btn.FlatAppearance.BorderSize = 1;
                label1.ForeColor = Color.White;
                btn = button5;
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.FromArgb(33, 33, 33); ;
                btn.ForeColor = Color.Gray;
                btn.FlatAppearance.BorderColor = Color.Gray;
                btn.FlatAppearance.BorderSize = 1;
                label1.ForeColor = Color.White;
                btn = button6;
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.FromArgb(33, 33, 33); ;
                btn.ForeColor = Color.Gray;
                btn.FlatAppearance.BorderColor = Color.Gray;
                btn.FlatAppearance.BorderSize = 1;
                label1.ForeColor = Color.White;
                textBox3.BackColor = Color.Gray;
                textBox4.BackColor = Color.Gray;
                textBox5.BackColor = Color.Gray;
              
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
                textBox2.ForeColor = Color.Black;
                textBox3.ForeColor = Color.Black;
                textBox4.ForeColor = Color.Black;
                textBox5.ForeColor = Color.Black;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                btn = button4;
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
                btn.FlatAppearance.BorderColor = Color.Aquamarine;
                btn.FlatAppearance.BorderSize = 1;
                btn = button5;
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
                btn.FlatAppearance.BorderColor = Color.Aquamarine;
                btn.FlatAppearance.BorderSize = 1;
                btn = button6;
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
                btn.FlatAppearance.BorderColor = Color.Aquamarine;
                btn.FlatAppearance.BorderSize = 1;
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

        public void main_page()
        {
            label1.Hide();
            textBox1.Hide();
            textBox2.Hide();
            button1.Hide();
            button4.Show();
            textBox3.Show();
            textBox4.Show();
            textBox5.Show();
            Load_data(id);

        }

        public void second_page()
        {
            label1.Show();
            textBox1.Show();
            textBox2.Show();
            button1.Show();
            button4.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
            button5.Hide();
            button6.Hide();
        }

        private void Diary_Load(object sender, EventArgs e)
        {
           if (s == "dark")
                theme_dark();
           if (first ==  true)
               theme_light();
           main_page();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 bec = new Form1();
            bec.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            second_page();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            id += 3;
            Load_data(id);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            id -= 3;
            Load_data(id);
        }

    }
}
