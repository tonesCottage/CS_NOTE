using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternBehavior.MediatorPattern
{
    public class Wuhan_Orchardist : Orchardist
    {
        Orchard wuhan_orchard;
        Orchard cq_orchard;
        public Orchard Wuhan_Orchard
        {
            set { wuhan_orchard = value; }
        }
        public Orchard Cq_Orchard
        {
            set { cq_orchard = value; }
        }
        public override void PlantRemote(Orchard orchard)
        {
            if (orchard == wuhan_orchard)
            {
                cq_orchard.Plant();
            }
            else if (orchard==cq_orchard)
            {
                wuhan_orchard.Plant();
            }
        }
    }
}
