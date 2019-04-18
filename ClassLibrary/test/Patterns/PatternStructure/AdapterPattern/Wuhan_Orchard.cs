using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.PatternStructure.AdapterPattern
{
    public class Wuhan_Orchard : Orchard, IPlant
    {
        public void Plant()
        {
            Plant("wuhan","apple");
        }
    }
}
