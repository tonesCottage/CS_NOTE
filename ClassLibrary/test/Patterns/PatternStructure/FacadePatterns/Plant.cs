using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.test.C_test_MODEL.baseClass;
using Test.test.C_test_MODEL.SIMPLE_MODEL;

namespace Test.test.PatternStructure.FacadePatterns
{
    public class Plant
    {
        Apple apple = new Apple();
        Orange orange = new Orange();
        Strawberry strawberry = new Wuhan_Strawberry();

        public void PlantAppleOrange()
        {
            apple.Plant();
            orange.Plant();
        }
        public void PlantAppleStrawberry()
        {
            apple.Plant();
            strawberry.plant();
        }
    }
}
