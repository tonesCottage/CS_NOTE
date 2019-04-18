using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.C_test
{
    public static class Class_ExampleExtension
    {
        public static string GetSexString(this Class_Example class_Example)
        {
            return class_Example.GetSex() == true ? "nan" : "nv";
        }
    }
}
