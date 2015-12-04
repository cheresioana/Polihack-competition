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

        public DataManager(string rootPath, Constants.MainTypes manager_type)
        {
            this.rootPath = rootPath;
            if (Directory.Exists(rootPath))
                this.error_code = 0;
            else
                this.error_code = 1;
            this.type = manager_type;
        }

        public bool entry_exists(Constants.SubTypes entry_type, Int64 entry_ID)
        {
            return (
                File.Exists(
                Path.Combine(rootPath, type.ToString(), entry_type.ToString(), entry_ID.ToString()
                )));
        }

        public string entry_csv_contents(Constants.SubTypes entry_type, Int64 entry_ID)
        {
            if (this.entry_exists(entry_type, entry_ID))
            {
                string path = 
                    Path.Combine(rootPath, type.ToString(), entry_type.ToString(), entry_ID.ToString());
                if (File.Exists(path))
                {
                    return (File.ReadAllText(path));
                }
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
