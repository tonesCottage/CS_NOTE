using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternBehavior.StrategyPattern
{
    public class ProgramUser
    {
        public void test()
        {
            Orchard appleOrchard = new Orchard(new Apple());
            appleOrchard.Plant();
        }
    }
}
