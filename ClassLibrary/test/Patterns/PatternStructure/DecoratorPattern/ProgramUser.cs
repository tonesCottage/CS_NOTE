using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.test.C_test_MODEL.SIMPLE_MODEL;

namespace Test.test.PatternStructure.DecoratorPattern
{
    public class ProgramUser
    {
        public void test()
        {
            //FruitDecorator 保存Fruit对象，派生类进行方法拓展（装饰）
            //用组合代替继承 进行方法拓展  （类的方法功能的修改）
            Fruit fruit = new Apple();
            FruitDecorator fruitDecorator = new LoosenSoilDecorator(fruit);
            fruitDecorator.Plant();
        }
    }
}
