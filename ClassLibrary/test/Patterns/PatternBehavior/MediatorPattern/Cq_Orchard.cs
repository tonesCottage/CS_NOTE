using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternBehavior.MediatorPattern
{
    public class Cq_Orchard : Orchard
    {
        public Cq_Orchard(Orchardist orchardlist) : base(orchardlist) { }
        public override void Plant()
        {
            Console.Write("");
        }

        public override void PlantRomote()
        {
            orchardlist.PlantRemote(this);
        }
    }
}
