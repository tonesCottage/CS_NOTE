using ClassLibrary.pracSelf.IO;
using ClassLibrary.test.New_test;
using System;
using System.Diagnostics;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Number number = new Number();
            number.ShowInfo();
            number.ShowNumber();

            IntNumber inn= new IntNumber();
            inn.ShowNumber();
            inn.ShowInfo();

            Number num = new IntNumber();
            num.ShowInfo();
            num.ShowNumber();



            FileOperatecs fo = new FileOperatecs();
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            fo.downLoad1("x.msi");
            sw1.Stop();
            TimeSpan ts1 = sw1.Elapsed;
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //fo.downLoad("x.msi");
            //sw.Stop();
            //TimeSpan ts = sw.Elapsed;


        }
    }
}
