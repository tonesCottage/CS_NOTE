using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.test.C_test_MODEL.baseClass;

namespace Test.test.PatternCreater.AbstractFactory
{
    public class ProgramUser
    {
        public void test()
        {
            //依赖倒置 创建型设计模式  不同场景
            //1.简单抽象 利用一个工厂类，具体创建
            //2.工厂方法 利用抽象工厂类，抽象创建方法，创建单一实例
            //3.抽象工厂 利用抽象工厂类，多个抽象方法，创建一组实例
            Orchard wuhanOrchard = new Wuhan_Orchard();
            Strawberry strawberry= wuhanOrchard.CreateApple();
            WaterMelon waterMelon = wuhanOrchard.CreateWatermelon();
            strawberry.plant();
            waterMelon.plant();
        }
    }
}
