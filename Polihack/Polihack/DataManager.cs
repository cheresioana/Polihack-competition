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
        public DataManager(string rootPath)
        {
            this.rootPath = rootPath;
            if (Directory.Exists(rootPath))
                this.error_code = 0;
            else
                this.error_code = 1;
        }
        public bool entry_created(string ID)
        {
            return (Directory.Exists(Path.Combine(rootPath, ID)));
        }
    }
}
