using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.PatternCreater.Constructor
{
    public class ProgramUser
    {
        public void test()
        {
            //适用于结构较复杂的对象的创建（存在多个部分需要被创建，（封装创建））
            OrchardDirector orchardDirector = new OrchardDirector(new Wuhan_OrchardBuilder());
            Orchard wuhan_orchard= orchardDirector.Construct();
            wuhan_orchard.plant();
        }
    }
}
