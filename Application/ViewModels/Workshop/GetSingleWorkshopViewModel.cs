using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Enums.Enums;

namespace Application.ViewModels.Workshop
{
    public class GetSingleWorkshopViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Logo { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string Url { get; set; }
        public string FacebookLink { get; set; }
        public WorkshopTypes Type { get; set; }
        public AccessType Access { get; set; }
        public string Phone { get; set; }
        public string CvrNumber { get; set; }
        public Guid? SchooldId { get; set; }
        public bool Approved { get; set; }
    }
}
