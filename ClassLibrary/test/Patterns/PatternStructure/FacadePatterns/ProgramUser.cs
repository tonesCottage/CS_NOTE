using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.PatternStructure.FacadePatterns
{
    public class ProgramUser
    {
        public void test()
        {
            //外观类  隔离具体细节  为复杂的系统提供统一接口
            Plant plant = new Plant();
            plant.PlantAppleOrange();
            plant.PlantAppleStrawberry();
        }
    }
}
