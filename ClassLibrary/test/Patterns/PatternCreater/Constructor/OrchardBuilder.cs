using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.PatternCreater.Constructor
{
    public abstract class OrchardBuilder
    {
        public abstract void BuildApple();
        public abstract void BuildOrange();
        public abstract Orchard GetOrchard();
    }
}
