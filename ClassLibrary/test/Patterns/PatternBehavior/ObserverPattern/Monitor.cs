using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternBehavior.ObserverPattern
{
    public class Monitor : IMonitor
    {
        private Orchard orchard;
        private string name;
        public Monitor(Orchard orchard,string name)
        {
            this.orchard = orchard;
            this.orchard.Add(this);
            this.name = name;
        }
        public void update()
        {
            Console.WriteLine(orchard.state);
        }
    }
}
