using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.PatternStructure.AdapterPattern
{
    public class ProgramUser
    {

        public void test()
        {
            //主要将类的接口转换为新的接口
            //接口形式的修改，不改功能

            //类适配器
            IPlant plant = new Wuhan_Orchard();
            plant.Plant();

            //对象适配器
            plant = new Cq_Orchard();
            plant.Plant();
        }
    }
}
