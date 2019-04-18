using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace TestReflect.Common.practice.接口协定
{
    [ContractClassFor(typeof(IPerson))]
    public abstract class PersonContract:IPerson
    {
        string IPerson.FirstName
        {
            get { return Contract.Result<string>(); }
            set { Contract.Requires(value != null); }
        }
        string IPerson.LastName
        {
            get { return Contract.Result<string>(); }
            set { Contract.Requires(value != null); }
        }
        int IPerson.Age
        {
            get
            {
                Contract.Ensures(Contract.Result<int>()>=0 &&
                    Contract.Result<int>() < 121);
                return Contract.Result<int>();
            }
            set
            {
                Contract.Requires(value >= 0 && value<123);
            }
        }
        //批量可用该方法
        //[ContractAbbreviator]
        void IPerson.ChangeName(string firstName, string lastName)
        {
            Contract.Requires(firstName != null);
            Contract.Requires(lastName != null);
        }
    }
}
