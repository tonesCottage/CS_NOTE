using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternBehavior.VisitorPattern
{
    public abstract class Fruit
    {
        public abstract void Accept(Orchardist orchardist);
    }
}
