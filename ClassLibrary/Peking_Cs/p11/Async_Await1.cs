using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Peking_Cs.p11
{
    class Async_Await1
    {
        Task<double> FacAsync(int n)

        {

            return Task<double>.Run(() => {

                double s = 1;

                for (int i = 1; i < n; i++) s = s * i;

                return s;

            });

        }

        async void Test()

        {

            // 调用异步方法

            double result = await FacAsync(10);

            Console.WriteLine(result); //想想这句在哪个线程

        }



        static void Main()

        {

            new Async_Await1().Test();

            Console.ReadKey();

        }
    }
}
