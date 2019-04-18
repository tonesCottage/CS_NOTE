using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.test.C_test_MODEL.SIMPLE_MODEL;

namespace Test.test.PatternStructure.DecoratorPattern
{
    public class FruitDecorator : Fruit
    {
        protected Fruit fruit;
        public FruitDecorator(Fruit fruit)
        {
            this.fruit = fruit;
        }
        public override void Plant()
        {
            fruit?.Plant();
        }
    }
}
