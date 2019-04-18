using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternBehavior.MediatorPattern
{
    public abstract class Orchard
    {
        protected Orchardist orchardlist;
        public Orchard(Orchardist orchardlist)
        {
            this.orchardlist = orchardlist;
        }
        public abstract void PlantRomote();
        public abstract void Plant();
    }
}
