using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternStructure.CompositePattern
{
    public abstract class Area
    {
        protected string name;
        public Area(string name)
        {
            this.name = name;
        }
        public abstract void Add(Area area);
        public abstract void Remove(Area area);
        public abstract void Perform();
    }
}
