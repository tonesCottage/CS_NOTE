using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternStructure.CompositePattern
{
    public class ProgramUser
    {
        public void test()
        {
            //组合成树形结构，提供一致的访问接口
            Area wuhan_area = new ConcreteArea("wuhan  zongbu");
            Area hzSell = new ConcreteArea("wuhan sell fenbu");
            Area whSell = new ConcreteArea("wuhan pick fenbu");
            wuhan_area.Add(hzSell);wuhan_area.Add(whSell);
            hzSell.Add(new FruitSeller("north"));
            hzSell.Add(new FruitSeller("south"));
            whSell.Add(new Orchardist("east"));
            whSell.Add(new Orchardist("west"));
        }
    }
}
