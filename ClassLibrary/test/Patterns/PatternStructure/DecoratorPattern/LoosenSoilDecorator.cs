using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.test.C_test_MODEL.SIMPLE_MODEL;

namespace Test.test.PatternStructure.DecoratorPattern
{
    public class LoosenSoilDecorator:FruitDecorator
    {
        public LoosenSoilDecorator(Fruit fruit):base(fruit)
        {

        }
        public override void Plant()
        {
            base.Plant();
            Loosen();
        }
        public void Loosen()
        {
            Console.WriteLine("");
        }
    }
}
