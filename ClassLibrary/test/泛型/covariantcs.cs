using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.test.泛型;

namespace Test.test.Delegate
{
    public class covariantcs
    {
        public void test()
        {
            Interface_covar<Entity1> cd = new CovarD<Entity1>();
            ShowCorvar(cd);
        }
       


        //add T  on  functionName for covariant;
        static void ShowCorvar<T>(Interface_covar<T> co)
        {
            co.pay();
        }
    }
}
