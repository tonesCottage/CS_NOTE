using Test.test.C_test_MODEL.SIMPLE_MODEL;

namespace Test.test.PatternCreater.FactoryFunctionModel
{
    public abstract class Orchard
    {
        //provider  function  (can  changing static)
        public abstract Fruit Create();
    }
}
