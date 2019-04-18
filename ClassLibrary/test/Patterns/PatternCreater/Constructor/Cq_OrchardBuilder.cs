using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.PatternCreater.Constructor
{
    public class Cq_OrchardBuilder : OrchardBuilder
    {
        Orchard Cq_Orchard = new Orchard("cq");
        public override void BuildApple()
        {
            Cq_Orchard.Apple = "cqapple";
        }

        public override void BuildOrange()
        {
            Cq_Orchard.Orange = "cqorange";
        }

        public override Orchard GetOrchard()
        {
            return Cq_Orchard;
        }
    }
}
