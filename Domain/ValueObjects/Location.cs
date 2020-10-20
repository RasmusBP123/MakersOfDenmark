using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public class Location
    {
        public Location(string address, string zipcode)
        {
            Address = address;
            Zipcode = zipcode;
        }
        public string Address { get; }
        public string Zipcode { get;}

    }
}
