using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public class Phone
    {
        public string Number { get; set; }
        public Phone(string number)
        {
            if (number.Length == 8)
            {
                Number = number;
            }
        }
    }
}
