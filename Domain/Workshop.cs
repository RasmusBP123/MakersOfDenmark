using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;
using static Domain.Enums.Enums;

namespace Domain
{
    public class Workshop
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Logo { get; set; }
        public Location Address { get; set; }
        public string Url { get; set; }
        public string FacebookLink { get; set; }
        //public Calendar Calendar { get; set; } = new Calendar();
        //public Guid CalendarId { get; set; }
        public WorkshopTypes Type { get; set; }
        public AccessType Access { get; set; }
        public Phone Phone { get; set; }
        public string CvrNumber { get; set; }
        public Guid? SchooldId { get; set; }

        public Workshop() { }

        public static Workshop Create(string name, 
                                      string address, 
                                      string zipcode, 
                                      string url, 
                                      string facebookLink, 
                                      WorkshopTypes type,
                                      AccessType access,
                                      string phoneNumber,
                                      string cvrNumber,
                                      Guid? schooldId)
        {
            return new Workshop
            {
                Name = name,
                Address = new Location
                {
                    Address = address,
                    Zipcode = zipcode
                },
                Logo = new byte[0],
                Url = url,
                FacebookLink = facebookLink,
                Type = type,
                Access = access,
                Phone = new Phone(phoneNumber),
                CvrNumber = cvrNumber,
                SchooldId = schooldId
            };
        }
        
    }
}
