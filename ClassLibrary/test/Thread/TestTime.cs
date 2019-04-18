using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Test.test.ThreadT
{
    public class TestTime
    {
        public void Test1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //do  something 
            sw.Stop();
            TimeSpan ts= sw.Elapsed;
        }

        public void t_parallel()
        {
            int[] num = new int[] { 1, 2, 3, 4, 5 };
            int total = 0;
            Parallel.For(0, num.Length,
                () =>
                {
                    return 0;
                },
                (i,loopState,subtotal)=> 
                {
                    subtotal += num[i];
                    return subtotal;
                },
                (x)=>
                    Interlocked.Add(ref total,x));
            int ss = total;
        }
    }
}
