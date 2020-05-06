using System;
using System.Collections.Generic;
using System.Text;
#nullable disable

namespace EssentialCSharp8.Tests.NullableReferenceTypes
{
    interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }

        string MiddleName 
        {
            get => "";
            set { }
        }

        string GetName() => $"{FirstName} {LastName}";

        protected string GetNameImplemantation() => "";
    }

    public class Person : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string GetName() => $"{LastName} {FirstName}";

        string IPerson.GetNameImplemantation()
        {
            //IPerson person = new Person();
            //person.GetName();
            return "";
        }

        public void Foo()
        {
            ((IPerson)this).GetNameImplemantation();
        }
    }
}
