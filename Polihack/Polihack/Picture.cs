using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polihack
{
    class Picture
    {
        private int     _id;
        private string  _name;
        private Constants.SubTypes  _type;
        private Constants.SubTypes _subtype;

        public int Id
        {
            get { return _id; }
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

            _id = id;
            _subtype = subtype;
            _name = csv.get_data_name(Constants.SubTypes.Img.ToString());
            _type = csv.get_data_type(Constants.SubTypes.Img.ToString());
        }
    }
}
