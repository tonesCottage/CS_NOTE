using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternBehavior.ObserverPattern
{
    public class ProgramUser
    {
        public void test()
        {
            //对象间状态的一致性
            Orchard orchard = new Orchard();
            IMonitor wuhan_monitor = new Monitor(orchard, "");
            IMonitor Cq_monitor = new Monitor(orchard, "");
            orchard.state = "";
            orchard.Notify();
        }
    }
}
