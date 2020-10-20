using Application.ViewModels.Workshop;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class DomainToViewModelsMap : Profile
    {
        public DomainToViewModelsMap()
        {
            CreateMap<Workshop, GetListWorkshopViewModel>();
            CreateMap<Workshop, GetSingleWorkshopViewModel>();
        }
    }
}
