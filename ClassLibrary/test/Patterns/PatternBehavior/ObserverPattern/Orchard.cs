using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternBehavior.ObserverPattern
{
    public class Orchard : IOrchard
    {
        private List<IMonitor> list = new List<IMonitor>();
        public string state { set; get; }
        public void Add(IMonitor monitor)
        {
            list.Add(monitor);
        }

        public void Notify()
        {
            foreach (var item in list)
            {
                item.update();
            }
        }

        public void Remove(IMonitor monitor)
        {
            list.Remove(monitor);
        }
    }
}
