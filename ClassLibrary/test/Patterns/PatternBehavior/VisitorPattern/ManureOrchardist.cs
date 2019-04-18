using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternBehavior.VisitorPattern
{
    public class ManureOrchardist : Orchardist
    {
        public override void VisitApple(Apple apple)
        {
            apple.PlantApple();
        }

        public override void VisitOrange(Orange orange)
        {
            orange.PlantOrange();
        }
    }
}
