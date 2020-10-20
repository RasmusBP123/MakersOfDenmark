using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Calendar
    {
        public Guid Id { get; set; }
        //public Workshop Workshop { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
