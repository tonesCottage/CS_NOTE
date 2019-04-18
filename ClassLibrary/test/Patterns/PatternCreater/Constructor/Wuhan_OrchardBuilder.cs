using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.PatternCreater.Constructor
{
    public class Wuhan_OrchardBuilder : OrchardBuilder
    {
        Orchard Wuhan_Orchard = new Orchard("wuhan");
        public override void BuildApple()
        {
            Wuhan_Orchard.Apple = "wuhanapple";
        }

        public override void BuildOrange()
        {
            Wuhan_Orchard.Orange = "wuhanorange";
        }

        public override Orchard GetOrchard()
        {
            return Wuhan_Orchard;
        }
    }
}
