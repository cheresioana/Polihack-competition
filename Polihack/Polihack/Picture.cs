﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Polihack
{
    class Picture
    {
        private int     _id;
        private string  _name;
        private Constants.SubTypes  _type;
        private Constants.SubTypes _subtype;
        private Image               _img;

        public int Id
        {
            get { return _id; }
            set { }
        }

        public Image Img
        {
            get { return _img; }
            set { }
        }

        public string Name
        {
            get { return _name; }
            set { }
        }

        public Constants.SubTypes Type
        {
            get { return _type; }
            set {}
        }

        public Constants.SubTypes Subtype
        {
            get { return _subtype; }
            set { }
        }

        public Picture(int id, Constants.SubTypes subtype,Constants.MainTypes main_type )
        {
            Csv csv = new Csv(id, subtype, main_type);
            DataManager data_manager = new DataManager(@"C:\Users\ioana\Desktop\root", Constants.MainTypes.web);

            _id = id;
            _subtype = subtype;
            _name = csv.get_data_name(Constants.SubTypes.Img.ToString());
            _img = data_manager.entry_data(_subtype, Constants.DataType.image, id, _name) as Image;
        }

        
    }
}
