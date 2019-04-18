using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternBehavior.StrategyPattern
{
    public class Apple : Fruit
    {
        public override void Plant()
        {
            //detail
            Console.WriteLine("apple");
        }
    }
}
