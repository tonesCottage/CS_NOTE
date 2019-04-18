using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.test.C_test_MODEL.baseClass;

namespace Test.test.PatternCreater.AbstractFactory
{
    public class Wuhan_Orchard : Orchard
    {
        public override Strawberry CreateApple()
        {
            return new Wuhan_Strawberry();
        }

        public override WaterMelon CreateWatermelon()
        {
            return new Wuhan_Watermelon();
        }
    }
}
