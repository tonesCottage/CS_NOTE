using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternBehavior.MediatorPattern
{
    public class ProgramUser
    {
        //封装中介 互相调用
        public void test()
        {
            Wuhan_Orchardist orchardist = new Wuhan_Orchardist();
            Orchard wuhan_orchard = new Wuhan_Orchard(orchardist);
            Orchard cq_orchard = new Cq_Orchard(orchardist);
            orchardist.Wuhan_Orchard = wuhan_orchard;
            orchardist.Cq_Orchard = cq_orchard;
            wuhan_orchard.PlantRomote();
            cq_orchard.PlantRomote();
        }
    }
}
