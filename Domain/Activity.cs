using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Calendar Calendar{ get; set; }
        public Guid CalendarId { get; set; }
    }
}
