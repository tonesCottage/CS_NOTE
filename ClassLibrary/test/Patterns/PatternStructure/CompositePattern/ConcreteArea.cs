using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternStructure.CompositePattern
{
    public class ConcreteArea : Area
    {
        List<Area> list = new List<Area>();
        public ConcreteArea(string name) : base(name) { }
        public override void Add(Area area)
        {
            list.Add(area);
        }

        public override void Perform()
        {
            foreach (var item in list)
            {
                item.Perform();
            }
        }

        public override void Remove(Area area)
        {
            list.Remove(area);
        }
    }
}
