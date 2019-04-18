using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.PRACTICE.p3
{
    struct Struct
    {
        double x, y;
        Struct(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public double R()
        {
            return Math.Sqrt(x * y);
        }

        enum MyEnum
        {
            red,
            green = 1,
            black = 2
        }
        public void test()
        {
            MyEnum color = MyEnum.red;
            color.ToString();
        }
    }
}
