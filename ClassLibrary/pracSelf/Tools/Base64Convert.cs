using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransmission.Common.Tools
{
    public class Base64Convert
    {
        public static string ToBase64(string str)
        {
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(str);
            //先转成byte[];
            string content = Convert.ToBase64String(byteArray);
            return content;

        }
    }
}
