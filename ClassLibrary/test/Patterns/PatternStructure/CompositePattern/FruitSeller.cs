using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternStructure.CompositePattern
{
    public class FruitSeller : Area
    {
        public FruitSeller(string name) : base(name) { }
        public override void Add(Area area)
        {
            
        }

        public override void Perform()
        {
            
        }

        public override void Remove(Area area)
        {
            Console.WriteLine("pick orange!");
        }
    }
}
