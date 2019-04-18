using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace TestReflect.Common.practice.接口协定
{
    [ContractClass(typeof(PersonContract))]
    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get;set; }
        int Age { get;set; }
        void ChangeName (string firstName,string lastName );
    }
}
