using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternStructure.CompositePattern
{
    public class Orchardist : Area
    {
        public Orchardist(string name):base(name)
        {

        }
        public override void Add(Area area)
        {
            
        }

        public override void Perform()
        {
            
        }

        public override void Remove(Area area)
        {
            Console.Write("pick apple!");
        }
    }
}
