using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.PatternStructure.ProxyPatterns
{
    public class ProgramUser
    {
        public void test()
        {
            //对实际类Orchardist进行替换的proxy代理类访问 （或者建立中间层）
            FruitAgent fruitAgent = new FruitAgent();
            int money = 1234;
            int fruit = fruitAgent.Sell(ref money);

        }
    }
}
