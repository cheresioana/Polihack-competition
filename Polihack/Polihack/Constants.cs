using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polihack
{
    public class Constants
    {
        //the enum names are also used as strings to build the path to the folders
        public static string root_path = @"C:\Users\ioana\Desktop\root";
        public enum DataType
        {
            image,
            text,
            link
        }

        public enum SubTypes
        {
            Vid,
            Img,
            Link,
            Text
        }

        public enum MainTypes
        {
            web
            //text,
            //contact
        }
    }
}
