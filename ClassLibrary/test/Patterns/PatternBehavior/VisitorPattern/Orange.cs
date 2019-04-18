using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternBehavior.VisitorPattern
{
    public class Orange : Fruit
    {
        public override void Accept(Orchardist orchardist)
        {
            orchardist.VisitOrange(this);
        }
        public void PlantOrange()
        {
            Console.Write("");
        }
    }
}
