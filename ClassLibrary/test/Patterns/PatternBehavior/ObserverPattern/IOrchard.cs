using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Patterns.PatternBehavior.ObserverPattern
{
    public interface IOrchard
    {
        void Add(IMonitor monitor);
        void Remove(IMonitor monitor);
        void Notify();
    }
}
