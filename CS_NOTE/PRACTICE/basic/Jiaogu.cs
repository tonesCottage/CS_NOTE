using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_NOTE.PRACTICE.basic
{
    class Jiaogu
    {
        //角谷猜想
        public static void test()
        {
            for (int n = 1; n <= 100; n++)
            {
                int a = n;
                while (a != 1)
                {
                    Console.Write(" " + a);
                    if (a % 2 == 1) a = a * 3 + 1; else a /= 2;
                }
                Console.WriteLine(" " + a);
            }
        }
    }
}
