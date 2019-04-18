using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternStructure.BridgePattern
{
    public class Wuhan_Orchard : Orchard
    {
        public override void Plant()
        {
            Console.Write("");
            fruit.Plant();
        }
    }
}
