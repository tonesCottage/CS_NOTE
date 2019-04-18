using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternBehavior.VisitorPattern
{
    public class Orchard
    {
        List<Fruit> list = new List<Fruit>();
        public void Attach(Fruit fruit)
        {
            list.Add(fruit);
        }
        public void Detach(Fruit fruit)
        {
            list.Remove(fruit);
        }
        public void Accept(Orchardist orchardist)
        {
            foreach (var item in list)
            {
                item.Accept(orchardist);
            }
        }
    }
}
