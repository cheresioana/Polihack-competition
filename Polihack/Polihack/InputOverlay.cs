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
    public partial class InputOverlay : Form
    {
        public Image screenshot;
        public Constants.SubTypes type;
        public string s;

        private string filter_input(string raw_input)
        {
            raw_input = raw_input.Replace(Environment.NewLine, " ");
            raw_input = raw_input.Replace(";", ",");
            raw_input = raw_input.Replace("\n", " ");
            return (raw_input);
        }

        public InputOverlay()
        {
            InitializeComponent();
            type = Constants.SubTypes.Link;
            radioButton1.Checked = true;
            this.TopMost = true;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public InputOverlay(string theme)
        {
            InitializeComponent();
            type = Constants.SubTypes.Link;
            radioButton1.Checked = true;
            this.TopMost = true;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            s = theme;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                MessageBox.Show("Please fill in all the fields!");
            else
            {
                if (radioButton1.Checked)
                    type = Constants.SubTypes.Link;
                else if (radioButton2.Checked)
                    type = Constants.SubTypes.Img;
                else if (radioButton3.Checked)
                    type = Constants.SubTypes.Vid;
                DataManager manager = new DataManager(Constants.root_path, Constants.MainTypes.web);
                Int64 lastid = manager.last_id_get(type);

                manager.add_subType_csv(type, filter_input(textBox1.Text), lastid + 1);//used for search indexing

                manager.last_id_set(type, lastid + 1);
                manager.create_entry(type, lastid + 1);
                manager.add_entry_data(Constants.DataType.text, type, lastid + 1, "title_desc.txt",
                    filter_input(textBox1.Text) + ";" + filter_input(textBox2.Text) + ";" + filter_input(textBox3.Text));

                manager.add_entry_data(Constants.DataType.image, type, lastid + 1, "ss.png", screenshot as object);
                this.Close();
            }
        }
        #region
        public void theme_dark()
        {
            InputOverlay dark = new InputOverlay();
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
            textBox1.ForeColor = Color.Gray;
            textBox1.BackColor = Color.FromArgb(33, 33, 33);
            textBox2.ForeColor = Color.Gray;
            textBox2.BackColor = Color.FromArgb(33, 33, 33);
            textBox3.ForeColor = Color.Gray;
            textBox3.BackColor = Color.FromArgb(33, 33, 33);
            label1.ForeColor = Color.Gray;
            label2.ForeColor = Color.Gray;
            label3.ForeColor = Color.Gray;
            groupBox1.ForeColor = Color.Gray;
            groupBox1.BackColor = Color.FromArgb(33, 33, 33);
            radioButton1.ForeColor = Color.Gray;
            radioButton2.ForeColor = Color.Gray;
            radioButton3.ForeColor = Color.Gray;
        }
        #endregion
        #region
        public void theme_light()
        {
            InputOverlay dark = new InputOverlay();
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
            textBox1.ForeColor = Color.Black;
            textBox1.BackColor = Color.Aquamarine;
            textBox2.ForeColor = Color.Black;
            textBox2.BackColor = Color.Aquamarine;
            textBox3.ForeColor = Color.Black;
            textBox3.BackColor = Color.Aquamarine;
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            groupBox1.ForeColor = Color.Gray;
            groupBox1.BackColor = Color.White;
            radioButton1.ForeColor = Color.Black;
            radioButton2.ForeColor = Color.Black;
            radioButton3.ForeColor = Color.Black;
        }
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InputOverlay_Load(object sender, EventArgs e)
        {
            ContentGenerator generator = new ContentGenerator();
            screenshot = generator.screenCap();
            pictureBox1.Image = screenshot;
            if (s == "dark")
                theme_dark();
            else
                theme_light();
        }
    }
}
