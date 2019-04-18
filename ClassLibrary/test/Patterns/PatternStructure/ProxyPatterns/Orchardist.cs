using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.PatternStructure.ProxyPatterns
{
    public class Orchardist : FruitSeller
    {
        int money;
        int fruit = 100000000;
        public override int Sell(ref int money)
        {
            int fruit = money / 5000;
            int price = fruit * 5000;
            money -= price;
            this.money += price;
            this.fruit -=fruit;
            return fruit;
        }
    }
}
