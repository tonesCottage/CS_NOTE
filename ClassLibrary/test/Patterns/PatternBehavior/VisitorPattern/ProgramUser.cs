using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternBehavior.VisitorPattern
{
    public class ProgramUser
    {
        //将数据结构与数据对数据结构的元素调用分离  （interface自动判断）
        public void test()
        {
            Orchard orchard = new Orchard();
            orchard.Attach(new Apple());
            orchard.Attach(new Orange());
            orchard.Accept(new LoosenOrchardist());
            orchard.Accept(new ManureOrchardist());
        }
        
    }
}
