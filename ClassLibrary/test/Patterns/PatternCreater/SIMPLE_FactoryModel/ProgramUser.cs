using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.test.C_test_MODEL.SIMPLE_MODEL;

namespace Test.test.PatternCreater.SIMPLE_FactoryModel
{
    public class ProgramUser
    {
        public void test()
        {
            //P:若出现新的实现类，则需要更改类Orchard  拓展性太差
            Orchard orchard = new Orchard();
            orchard.Create("Apple");
        }
    }
}
