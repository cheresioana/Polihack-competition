﻿using System;
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
        public InputOverlay(Constants.SubTypes sub_type)
        {
            InitializeComponent();
            type = sub_type;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("Please fill in all the fields!");
            else
            {
                DataManager manager = new DataManager(Constants.root_path, Constants.MainTypes.web);
                Int64 lastid = manager.last_id_get(type);
                manager.last_id_set(type, lastid + 1);
                manager.create_entry(type, lastid + 1);
                manager.add_entry_data(Constants.DataType.text, type, lastid + 1, "title_desc.txt", textBox1.Text + ";" + textBox2.Text);
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