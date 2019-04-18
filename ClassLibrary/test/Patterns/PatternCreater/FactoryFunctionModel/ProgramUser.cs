using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.test.C_test_MODEL.SIMPLE_MODEL;

namespace Test.test.PatternCreater.FactoryFunctionModel
{
    public class ProgramUser
    {
        public void test()
        {
            //依赖倒置，依赖于抽象类而不依赖于具体类
            //若需要新增实现，只需增加继承于Fruit的具体类以及继承于Orchard的实现类即可
            //**对使用者，无需修改已有代码
            Orchard appleOrchard = new AppleOrchard();
            //封装创建具体类
            Fruit apple = appleOrchard.Create();
            apple.Plant();
        }
    }
}
