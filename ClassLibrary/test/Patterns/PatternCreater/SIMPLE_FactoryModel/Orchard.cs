using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.test.C_test_MODEL.SIMPLE_MODEL;

namespace Test.test.PatternCreater.SIMPLE_FactoryModel
{
    public class Orchard
    {
        //provider  function  (can  changing static)
        public Fruit Create(string name)
        {
            switch (name)
            {
                case "Apple":
                    return new Apple();
                case "Orange":
                    return new Orange();
                default:
                    throw new Exception("name  not  exist");
            }
        }
        public void UseFunction()
        {
            Fruit fruit = Create("Apple");
        }
    }
}
