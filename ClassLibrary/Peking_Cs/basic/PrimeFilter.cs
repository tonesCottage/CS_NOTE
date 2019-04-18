using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_NOTE.PRACTICE
{
    class PrimeFilter
    {
        //get  素数
        public static void test()
        {
            int N = 100;
            bool[] a = new bool[N + 1];
            for (int i = 2; i <= N; i++) a[i] = true;

            for (int i = 2; i < N; i++)
            {
                if (a[i]) for (int j = i * 2; j <= N; j += i)
                        a[j] = false;
            }

            for (int i = 2; i <= N; i++)
                if (a[i]) Console.Write(i + " ");
        }
    }
}
