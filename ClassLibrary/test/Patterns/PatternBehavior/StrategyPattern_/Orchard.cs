using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternBehavior.StrategyPattern
{
    public class Orchard
    {
        Fruit fruit;
        public Orchard(Fruit fruit)
        {
            this.fruit = fruit;
        }
        public void Plant()
        {
            fruit.Plant();
        }
    }
}
