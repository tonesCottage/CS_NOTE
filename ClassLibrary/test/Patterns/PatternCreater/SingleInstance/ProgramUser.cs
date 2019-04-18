using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.PatternCreater.SingleInstance
{
    public class ProgramUser
    {
        public void test()
        {
            Helicopter wuhan_helicoper = Helicopter.Instance;
            wuhan_helicoper.SprayInsecticide("wuhan");

            Helicopter cq_helicoper = Helicopter.Instance;
            cq_helicoper.SprayInsecticide("cq");
        }
    }
}
