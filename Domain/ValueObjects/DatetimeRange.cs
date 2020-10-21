using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public class DatetimeRange
    {
        public DatetimeRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; }
        public DateTime End { get; }
    }
}
