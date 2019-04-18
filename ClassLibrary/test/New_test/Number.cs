using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.test.New_test
{
    public class Number
    {
        public static int i = 123;
        public virtual void ShowInfo()
        {
            Console.WriteLine("base class");
        }
        public virtual void ShowNumber()
        {
            Console.WriteLine(i.ToString());
        }
    }
}
