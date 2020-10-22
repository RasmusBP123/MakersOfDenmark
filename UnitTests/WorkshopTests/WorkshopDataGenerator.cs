using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static Domain.Enums.Enums;

namespace UnitTests.WorkshopTests
{
    public class WorkshopDataGenerator : IEnumerable<object[]>
    {

        private readonly List<object[]> _data = new List<object[]>
        {
             new object[]
                {
                    "UCL Workshop",
                    "Seebladsgade 31",
                    "5000", "https://ucl.dk",
                    "facebook.com/ucl",
                    WorkshopTypes.Association,
                    AccessType.Membership,
                    "28929173",
                    "12125",
                    null
                },
                new object[]
                {
                    "Aalborg Workshop",
                    "Bredgade 1",
                    "9000",
                    "https://aalborg.dk",
                    "facebook.com/aalborg",
                    WorkshopTypes.Association,
                    AccessType.Other,
                    "20512511"
                    , "1254634",
                    null
                }
        };
        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

