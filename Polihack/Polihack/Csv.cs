using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private string _caption;
        private string _description;
        private string _url;
        public info[] infos;

        public string Caption
        {
            get { return _caption; }
            set { }
        }

        public string Url
        {
            get { return _url; }
            set { }
        }

        public string Description
        {
            get { return _description; }
            set { }
        }

        public string epur(string myString)
        {
            myString = myString.Replace(System.Environment.NewLine, "replacement text");
            return myString;
        }

        public Csv(Int64 id, Constants.SubTypes sub_type, Constants.MainTypes main_type)
        {
            DataManager manager = new DataManager(Constants.root_path, main_type);
            if (manager.entry_exists(sub_type, id))
            {
                string data = manager.entry_csv_contents(sub_type, id);
                string[] rows = new string[20];
                string[] col = new string[20];
           
                int i;

                rows = data.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                i = rows.Length;
                infos = new info[i];
                foreach (string s in rows)
                {
               
                    col = s.Split(new char[]{';'},StringSplitOptions.RemoveEmptyEntries);
                    infos[i - 1] = new info();
                    infos[i - 1]._name = epur(col[0]);
                    infos[i - 1]._type = epur(col[1]);
                    i--;
                }
                data = manager.entry_data(sub_type, Constants.DataType.text, id, "title_desc.txt") as string;
                string[] r = new string[3];
                r = data.Split(';');
                _caption = r[0];
                _description = r[1];
                _url = get_url(r[2]);
            }
        }

        public string get_url(string data)
        {
            if (data.StartsWith("https://") || data.StartsWith("http://"))
                return data;
            return "https://www.google.ro/search?q=" + data + "&oq=" + data;
        }

        public string get_data_name(string data_requested)
        {
            foreach (info str in infos)
            {
                if (str._type == data_requested)
                {
                    return (str._name);
                }
            }
            return infos[0]._name;
        }
        public Constants.DataType get_data_type(string data_requested)
        {

            foreach (info info in infos)
            {
                if (info._type == data_requested)
                {
                    if (data_requested == "Img")
                        return (Constants.DataType.image);
                    if (data_requested == "Text")
                        return (Constants.DataType.text);
                    if (data_requested == "Link")
                        return (Constants.DataType.image);
                }
            }
            return Constants.DataType.image;
        }
    }
}
