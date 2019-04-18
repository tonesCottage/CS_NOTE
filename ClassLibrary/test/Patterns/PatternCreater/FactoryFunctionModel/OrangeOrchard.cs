using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.test.C_test_MODEL.SIMPLE_MODEL;

namespace Test.test.PatternCreater.FactoryFunctionModel
{
    public class OrangeOrchard : Orchard
    {
        public override Fruit Create()
        {
            return new Orange();
        }
    }
}
