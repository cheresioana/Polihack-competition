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
        public Diary()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder g =  new StringBuilder();
            string c;
                c = textBox1.Text;
                 c.Replace(";","");
                
            using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(Constants.root_path + "\\"+textBox1.Text + ".txt"))
            {
                file.WriteLine(textBox1.Text);
                string s;
                s = textBox2.Text;
                file.Write(s);
            }
        }
    }
}
