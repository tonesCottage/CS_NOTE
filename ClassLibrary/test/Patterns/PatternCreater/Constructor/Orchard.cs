using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.PatternCreater.Constructor
{
    public class Orchard
    {
        string name;
        public string Apple { set; get; }
        public string Orange { set; get; }
        public Orchard(string name)
        {
            this.name = name;
            Console.WriteLine("constructor");
        }
        public void plant()
        {
        }
    }
}
