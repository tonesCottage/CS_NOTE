using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternStructure.BridgePattern
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
