using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternBehavior.VisitorPattern
{
    public abstract class Orchardist
    {
        public abstract void VisitApple(Apple apple);
        public abstract void VisitOrange(Orange orange);
    }
}
