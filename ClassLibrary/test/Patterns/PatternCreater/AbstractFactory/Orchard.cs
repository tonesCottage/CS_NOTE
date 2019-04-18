using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.test.C_test_MODEL.baseClass;

namespace Test.test.PatternCreater.AbstractFactory
{
    public abstract class Orchard
    {
        public abstract Strawberry CreateApple();
        public abstract WaterMelon CreateWatermelon();

    }
}
