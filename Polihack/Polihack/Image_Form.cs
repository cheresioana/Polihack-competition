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
    public partial class Image_Form : Form
    {
        public int id = 1;

        public Image_Form()
        {
            InitializeComponent();
        }

        public void Load_Image(int start)
        {
            int i;
            DataManager data_manager = new DataManager(Constants.root_path, Constants.MainTypes.web);
            
            Picture[] pic = new Picture[4];

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

            //MessageBox.Show(start.ToString());
            for (i = 0; i < 3 ; i++)
            {
                if (data_manager.entry_exists(Constants.SubTypes.Img, start + i))
                {
                    pic[i] = new Picture(start + i, Constants.SubTypes.Img, Constants.MainTypes.web);
                    switch (i)
                    {
                        case 0:
                            {
                                pictureBox1.Show();
                                label1.Show();
                                label4.Show();
                                pictureBox1.Image = pic[i].Img;
                                label1.Text = pic[i].Caption;
                                label4.Text = pic[i].Description;
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
                    }
                }
            }
        }

        private void Image_Form_Load(object sender, EventArgs e)
        {
            Load_Image(id);
            DataManager data_manager = new DataManager(Constants.root_path, Constants.MainTypes.web);
            if (!(data_manager.entry_exists(Constants.SubTypes.Img, id + 3)))
                button2.Hide();
            else button2.Show();
            if (id == 1)
                button1.Hide();
            else button1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // next
            id += 3;
            DataManager data_manager = new DataManager(Constants.root_path, Constants.MainTypes.web);
            if (!(data_manager.entry_exists(Constants.SubTypes.Img, id + 3)))
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
            if (!(data_manager.entry_exists(Constants.SubTypes.Img, id + 3)))
                button2.Hide();
            else button2.Show();
            if (id == 1)
                button1.Hide();
            else button1.Show();
            Load_Image(id);
           
        }
    }
}
