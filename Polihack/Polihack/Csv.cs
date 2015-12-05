using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace Polihack
{
    class Csv
    {
        public struct info
        {
            public string _name;
            public string _type;
        }

        public info[] infos;

        public Csv(Int64 id, Constants.SubTypes sub_type, Constants.MainTypes main_type)
        {
            DataManager manager = new DataManager(Constants.root_path, main_type);
            string data = manager.entry_csv_contents(sub_type, id);
            string[] rows;
            string[] col;
            int i = 0;

            rows = data.Split('\n');
            foreach (string s in rows)
            {
                col = s.Split(';');
                infos[i] = new info();
                infos[i]._name = col[0];
                infos[i]._type = col[1];
                i++;

            }
        }

        public string get_data_name(string data_requested)
        {
            foreach (info info in infos)
            {
                if (info._type == data_requested)
                    return info._name;
            }
            return null;
        }
        public string get_data_type(string data_requested)
        {
            foreach (info info in infos)
            {
                if (info._type == data_requested)
                    return info._type;
            }
            return null;
        }
    }
}
