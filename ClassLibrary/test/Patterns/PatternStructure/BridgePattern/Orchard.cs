using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternStructure.BridgePattern
{
    public abstract class Orchard
    {
        protected Fruit fruit;
        public Fruit Fruit { set { fruit = value; } }
        public abstract void Plant();
    }
}
