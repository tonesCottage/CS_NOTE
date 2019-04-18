using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.PatternCreater.Constructor
{
    public class OrchardDirector
    {
        OrchardBuilder orchardBuilder;
        public OrchardDirector(OrchardBuilder orchardBuilder)
        {
            this.orchardBuilder = orchardBuilder;
        }
        public Orchard Construct()
        {
            orchardBuilder.BuildApple();
            orchardBuilder.BuildOrange();
            return orchardBuilder.GetOrchard();
        }
    }
}
