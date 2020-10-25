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
            CreateMap<Workshop, GetListWorkshopViewModel>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Location.Address))
                .ForMember(dest => dest.Zipcode, opt => opt.MapFrom(src => src.Location.Zipcode))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone.Number));

            CreateMap<Workshop, GetSingleWorkshopViewModel>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Location.Address))
                .ForMember(dest => dest.Zipcode, opt => opt.MapFrom(src => src.Location.Zipcode))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone.Number));
            CreateMap<Blog, GetListBlogViewModel>();
            CreateMap<Blog, GetSingleBlogViewModel>();

            CreateMap<RegisterAccountViewModel, ApplicationUser>();
        }
    }
}
