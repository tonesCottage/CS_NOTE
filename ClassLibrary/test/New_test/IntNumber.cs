using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.test.New_test
{
    public class IntNumber:Number
    {
        new public static int i = 456;
        public new virtual void ShowInfo()
        {
            Console.WriteLine("intnumber class");
        }
        public override void ShowNumber()
        {
            Console.WriteLine(Number.i.ToString());
            Console.WriteLine(i.ToString());
        }
    }
}
