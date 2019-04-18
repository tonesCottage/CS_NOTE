using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.PatternStructure.ProxyPatterns
{
    public class FruitAgent : FruitSeller
    {
        int money = 5000;
        int fruit = 0;
        FruitSeller orchardist;
        public override int Sell(ref int money)
        {
            if (orchardist == null)
                orchardist = new Orchardist();
            int fruit = money / 10;
            if (fruit > this.fruit)
                this.fruit += this.orchardist.Sell(ref this.money) * 1000;
            this.fruit -= fruit;
            this.money += fruit * 10;
            money -= fruit * 10;
            return fruit;
        }
    }
}
