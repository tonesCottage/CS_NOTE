using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.PatternCreater.PrototypePattern
{
    public class ProgramUser
    {
        public void test()
        {
            Orchard wuhan_orchard = new Orchard();
            wuhan_orchard.Name = "wuhan";
            wuhan_orchard.Apple = "wuhanapple";
            wuhan_orchard.Orange = "wuhanorange";
            wuhan_orchard.Plant();

            Orchard cq_orchard = wuhan_orchard.Clone() as Orchard;
            cq_orchard.Name = "cq";
            cq_orchard.Plant();
        }
    }
}
