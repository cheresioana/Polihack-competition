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
        public int id = 0;

        public Image_Form()
        {
            InitializeComponent();
        }

        private void Image_Form_Load(object sender, EventArgs e)
        {
            Picture[] pic = new Picture[3];

            for (id = 0; id < 3; id++)
            {
                pic[id] = new Picture(id, Constants.SubTypes.Img, Constants.MainTypes.web);
                switch (id % 3)
                {
                    case 0:
                        {
                            pictureBox1.Image = pic[id].Img;
                            break;
                        }
                    case 1:
                        {
                            pictureBox2.Image = pic[id].Img;
                            break;
                        }
                    case 2:
                        {
                            pictureBox3.Image = pic[id].Img;
                            break;
                        }
                }
            }
        }
    }
}
