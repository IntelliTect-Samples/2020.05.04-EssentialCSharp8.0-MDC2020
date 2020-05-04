using System;
using System.Collections.Generic;
using System.Text;

namespace EssentialCSharp8.Tests.NullableReferenceTypes
{

    class Address
    {
        public string Street1 { get; }
        public string? Street2 { get; }
        public string City { get; }
        public string Zip { get; }
        public string Country { get; }

        public Address(
            string street1,
            string? street2,
            string city,
            string zip,
            string country
        )
        {
            Street1 = street1;
            Street2 = street2;
            City = city;
            Zip = zip;
            Country = country;
        }

        public Address(
            string street1,
            string city,
            string zip,
            string country
        ):this(street1, null, city, zip, country)
        {        }
    }
}
