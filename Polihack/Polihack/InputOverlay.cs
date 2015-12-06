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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InputOverlay_Load(object sender, EventArgs e)
        {
            ContentGenerator generator = new ContentGenerator();
            screenshot = generator.screenCap();
            pictureBox1.Image = screenshot;
            
        }
    }
}
