using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternBehavior.MediatorPattern
{
    public class Wuhan_Orchard : Orchard
    {
        public Wuhan_Orchard(Orchardist orchardlist):base(orchardlist) { }
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
