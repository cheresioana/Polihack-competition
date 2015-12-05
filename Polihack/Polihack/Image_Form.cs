using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Polihack
{
    public partial class Image_Form : Form
    {
        public int id = 1;
        public Constants.SubTypes sub_type = Constants.SubTypes.Img;
        public string[] urls;
        public Image_Form()
        {
            InitializeComponent();
            urls = new string[3];
        }
       

        public void Load_Image(int start)
        {
            int i;
            DataManager data_manager = new DataManager(Constants.root_path, Constants.MainTypes.web);
            
            Picture[] pic = new Picture[4];

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

            if (!(data_manager.entry_exists(sub_type, id + 3)))
                button2.Hide();
            else button2.Show();
            if (id == 1)
                button1.Hide();
            else button1.Show();

            for (i = 0; i < 3 ; i++)
            {
                if (data_manager.entry_exists(sub_type, start + i))
                {
                    pic[i] = new Picture(start + i, sub_type, Constants.MainTypes.web);
                    switch (i)
                    {
                        #region img
                        case 0:
                            {
                               
                                pictureBox1.Show();
                                label1.Show();
                                label4.Show();
                                pictureBox1.Image = pic[i].Img;
                                label1.Text = pic[i].Caption;
                                label4.Text = pic[i].Description;
                                urls[0] = pic[i].Url;
                                break;
                            }
                        case 1:
                            {
                                pictureBox2.Show();
                                label2.Show();
                                label5.Show();
                                pictureBox2.Image = pic[i].Img;
                                label2.Text = pic[i].Caption;
                                label5.Text = pic[i].Description;
                                urls[1] = pic[i].Url;
                                break;
                            }
                        case 2:
                            {
                                pictureBox3.Show();
                                label3.Show();
                                label6.Show();
                                pictureBox3.Image = pic[i].Img;
                                label3.Text = pic[i].Caption;
                                label6.Text = pic[i].Description;
                                urls[2] = pic[i].Url;
                                break;
                            }
                                #endregion
                    }
                }
                else
                {
                    #region hide
                    switch (i)
                    {
                        case 0:
                            {
                                pictureBox1.Hide();
                                label1.Hide();
                                label4.Hide();
                                break;
                            }
                        case 1:
                            {
                                pictureBox2.Hide();
                                label2.Hide();
                                label5.Hide();
                                break;
                            }
                        case 2:
                            {
                                pictureBox3.Hide();
                                label3.Hide();
                                label6.Hide();
                                break;
                            }
                    #endregion
                    }
                }
            }
           
        }
        public Image_Form(string theme)
        {
            InitializeComponent();
            s = theme;
        }
        public bool first = true;
        public void theme_dark()
        {
            // s = label2.Text;
            // if ((s == "light")|| ((first == true) && (s == "dark")))
            // {
            s = "dark";
           Image_Form dark = new Image_Form();
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
            btn = button4;
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.FromArgb(33, 33, 33); ;
            btn.ForeColor = Color.Gray;
            btn.FlatAppearance.BorderColor = Color.Gray;
            btn.FlatAppearance.BorderSize = 1;
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            pictureBox2.BackColor = Color.FromArgb(33, 33, 33);
            pictureBox1.BackColor = Color.FromArgb(33, 33, 33);
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
            Image_Form dark = new Image_Form();
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
            pictureBox1.BackColor = btn.BackColor;
            pictureBox2.BackColor = pictureBox1.BackColor;
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            btn = button3;
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.FlatAppearance.BorderColor = Color.Aquamarine;
            btn.FlatAppearance.BorderSize = 1;
            btn = button4;
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.FlatAppearance.BorderColor = Color.Aquamarine;
            btn.FlatAppearance.BorderSize = 1;

            //label2.Text = s;
            //label2.ForeColor = textBox1.BackColor;
            first = false;
            // }

        }
        public string s;

        private void Image_Form_Load(object sender, EventArgs e)
        {
            Load_Image(id);
            sub_type = Constants.SubTypes.Img;
            DataManager data_manager = new DataManager(Constants.root_path, Constants.MainTypes.web);
            if (!(data_manager.entry_exists(Constants.SubTypes.Img, id + 3)))
                button2.Hide();
            else button2.Show();
            if (id == 1)
                button1.Hide();
            else button1.Show();
            if (s == "dark")
                theme_dark();
            else
                theme_light();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // next
            id += 3;
            DataManager data_manager = new DataManager(Constants.root_path, Constants.MainTypes.web);
            if (!(data_manager.entry_exists(sub_type, id + 3)))
                button2.Hide();
            else button2.Show();
            if (id == 1)
                button1.Hide();
            else button1.Show();
            Load_Image(id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //prev
            id -= 3;
            DataManager data_manager = new DataManager(Constants.root_path, Constants.MainTypes.web);
            if (!(data_manager.entry_exists(sub_type, id + 3)))
                button2.Hide();
            else button2.Show();
            if (id == 1)
                button1.Hide();
            else button1.Show();
            Load_Image(id);
           
        }

        private void Image_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (s == "light")
                theme_dark();
            else
                theme_light();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 bec = new Form1();
            bec.Show();
        }

        
        private void button5_Click(object sender, EventArgs e)
        {
            if (sub_type != Constants.SubTypes.Img)
            {
                sub_type = Constants.SubTypes.Img;
                id = 1;
                Load_Image(id);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (sub_type != Constants.SubTypes.Vid)
            {
            sub_type = Constants.SubTypes.Vid;
             id = 1;
                Load_Image(id);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (sub_type != Constants.SubTypes.Link)
            {
                sub_type = Constants.SubTypes.Link;
                id = 1;
                Load_Image(id);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("chrome.exe", urls[0]);
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("chrome.exe", urls[1]);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("chrome.exe", urls[2]);
        }
        
    }
}
