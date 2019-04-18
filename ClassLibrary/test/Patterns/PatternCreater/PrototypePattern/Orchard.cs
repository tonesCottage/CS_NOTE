using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.PatternCreater.PrototypePattern
{
    public class Orchard : IOrchard
    {
        public string Name { set; get; }
        public string Apple { set; get; }
        public string Orange { set; get; }
        public IOrchard Clone()
        {
            return new Orchard()
            {
                Name = Name,
                Apple = Apple,
                Orange= Orange
            };
        }
        public void Plant()
        {
            Console.WriteLine("");
        }
    }
}
