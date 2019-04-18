using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary.Peking_Cs.p11
{
    class Async_StreamT
    {
        async Task<int> WriteFile()

        {

            using (StreamWriter sw = new StreamWriter(

                new FileStream("aaa.txt", FileMode.Create)))

            {

                await sw.WriteAsync("my text");

                return 1;

            }

        }

        async static void Test()

        {

            Async_StreamT a = new Async_StreamT();

            await a.WriteFile();

            Console.WriteLine("Write OK");

        }

        static void Main()

        {

            Test();

        }
    }
}
