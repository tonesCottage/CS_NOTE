using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternBehavior.VisitorPattern
{
    public class Apple : Fruit
    {
        public override void Accept(Orchardist orchardist)
        {
            orchardist.VisitApple(this);
        }
        public void PlantApple()
        {
            Console.Write("");
        }
    }
}
