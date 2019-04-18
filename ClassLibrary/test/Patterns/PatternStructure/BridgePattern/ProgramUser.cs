using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternStructure.BridgePattern
{
    public class ProgramUser
    {
        public void test()
        {
            Orchard Wuhan_Orchard = new Wuhan_Orchard();
            Wuhan_Orchard.Fruit = new Apple();
            Wuhan_Orchard.Plant();
            Wuhan_Orchard.Fruit = new Orange();
            Wuhan_Orchard.Plant();
        }
    }
}
