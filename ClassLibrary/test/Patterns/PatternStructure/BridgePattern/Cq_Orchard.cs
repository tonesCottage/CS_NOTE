using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternStructure.BridgePattern
{
    public class Cq_Orchard : Orchard
    {
        public override void Plant()
        {
            fruit.Plant();
        }
    }
}
