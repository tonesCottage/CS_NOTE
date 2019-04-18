using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.PatternCreater.SingleInstance
{
    public class Helicopter
    {
        public static Helicopter helicopter;
        public static Helicopter Instance
        {
            get
            {
                if (helicopter == null)
                    helicopter = new Helicopter();
                return helicopter;
            }
        }
        protected Helicopter() { }
        int insecticide = 100;
        public void SprayInsecticide(string city)
        {
            insecticide -= 50;
            Console.WriteLine("");
            if (insecticide == 0)
            {
                Console.Write("");
            }
            else
            {
                Console.Write("");
            }
        }
    }
}
