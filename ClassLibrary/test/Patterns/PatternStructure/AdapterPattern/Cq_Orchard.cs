using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.PatternStructure.AdapterPattern
{
    public class Cq_Orchard : IPlant
    {
        Orchard orchard = new Orchard();
        public void Plant()
        {
            orchard.Plant("cq","strawberry");
        }
    }
}
