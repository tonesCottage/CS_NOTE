using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestReflect.Common.practice.接口协定
{
    public class Person:IPerson
    {
        public Person(string firstName,string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age {get; set;}
        public void ChangeName(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
