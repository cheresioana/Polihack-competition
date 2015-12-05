using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace Polihack
{
    class DataManager
    {
        public string rootPath;
        public int error_code;
        public Constants.MainTypes type;

        public void add_subType_csv(Constants.SubTypes sub_type, string title, Int64 entry_id)
        {
            string content = entry_id.ToString();
            string[] keywords = title.Split(' ');
            foreach (string keyword in keywords)
                content += ";" + keyword;
            content += Environment.NewLine;
            File.AppendAllText(Path.Combine(rootPath, type.ToString(), sub_type.ToString(), "sub.csv"), content);
        }

        public string get_subType_csv(Constants.SubTypes sub_type)
        {
            string path = Path.Combine(rootPath, type.ToString(), sub_type.ToString(), "sub.csv");
            if (File.Exists(path))
            {
                string ret_val = File.ReadAllText(path);
                return (ret_val);
            }
            return (null);
        }

        public Int64 last_id_get(Constants.SubTypes sub_type)
        {
            string path = Path.Combine(rootPath, type.ToString(), sub_type.ToString(), "lastid.csv");
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "0");
                return (0);
            }
            string last_id = File.ReadAllText(path);
            return (Convert.ToInt64(last_id));
        }

        public void last_id_set(Constants.SubTypes sub_type, Int64 new_id)
        {
            string path = Path.Combine(rootPath, type.ToString(), sub_type.ToString(), "lastid.csv");
            File.WriteAllText(path, new_id.ToString());
        }

        public DataManager(string rootPath, Constants.MainTypes manager_type)
        {
            this.rootPath = rootPath;
            if (Directory.Exists(rootPath))
                this.error_code = 0;
            else
                this.error_code = 1;
            this.type = manager_type;
        }

        public void create_entry(Constants.SubTypes sub_type, Int64 ent_ID)
        {
            string path = Path.Combine(rootPath, type.ToString(), sub_type.ToString(), ent_ID.ToString());
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            if (!File.Exists(Path.Combine(path, "info.csv")))
            {
                var to_close = File.Create(Path.Combine(path, "info.csv"));
                to_close.Close();
            }
        }

        public void
            add_entry_data(Constants.DataType data_type, Constants.SubTypes sub_type,
            Int64 ent_id, string obj_name, object data)
        {
            create_entry(sub_type, ent_id);
            string[] pre_path = new string[5];
            pre_path[0] = rootPath;
            pre_path[1] = type.ToString();
            pre_path[2] = sub_type.ToString();
            pre_path[3] = ent_id.ToString();
            pre_path[4] = obj_name;
            string path = Path.Combine(pre_path);
            if (data_type == Constants.DataType.text)
            {
                File.WriteAllText(path, data as string);
                pre_path[4] = "info.csv";
                string csv_line = obj_name + ";" + data_type.ToString() + Environment.NewLine;
                File.AppendAllText(Path.Combine(pre_path), csv_line);
            }
            else if (data_type == Constants.DataType.image)
            {
                Image temp = data as Image;
                temp.Save(path);
                pre_path[4] = "info.csv";
                string csv_line = obj_name + ";" + data_type.ToString() + Environment.NewLine;
                File.AppendAllText(Path.Combine(pre_path), csv_line);
            }
            else if (data_type == Constants.DataType.link)
            {
                File.WriteAllText(path, data as string);
                pre_path[4] = "info.csv";
                string csv_line = obj_name + ";" + data_type.ToString() + Environment.NewLine;
            }
        }

        public bool entry_exists(Constants.SubTypes entry_type, Int64 entry_ID)
        {
            return (
                Directory.Exists(
                Path.Combine(rootPath, type.ToString(), entry_type.ToString(), entry_ID.ToString()
                )));
        }

        public string entry_csv_contents(Constants.SubTypes entry_type, Int64 entry_ID)
        {
            if (this.entry_exists(entry_type, entry_ID))
            {
                string path = 
                    Path.Combine(rootPath, type.ToString(), entry_type.ToString(), entry_ID.ToString());
                path = Path.Combine(path, "info.csv");
                if (File.Exists(path))
                    return (File.ReadAllText(path));
                else
                    return (null);
            }
            else
                return (null);
        }

        public object entry_data
            (Constants.SubTypes sub_type, Constants.DataType data_type, Int64 ent_ID, string data_name)
        {
            string[] pre_path = new string[5];
            pre_path[0] = rootPath;
            pre_path[1] = type.ToString();
            pre_path[2] = sub_type.ToString();
            pre_path[3] = ent_ID.ToString();
            pre_path[4] = data_name;
            string path = Path.Combine(pre_path);
            if (!File.Exists(path))
                return null;
            if (data_type == Constants.DataType.text)
                return (File.ReadAllText(path) as object);
            if (data_type == Constants.DataType.image)
                return (Image.FromFile(path) as object);
            return null;
        }
    }
}
