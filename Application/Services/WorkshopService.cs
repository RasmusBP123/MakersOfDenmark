using Application.Interfaces;
using Application.ViewModels;
using Application.ViewModels.Workshop;
using AutoMapper;
using Domain;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class WorkshopService : IWorkshopService
    {
        private readonly IWorkshopRepository workshopRepository;
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public WorkshopService(IWorkshopRepository workshopRepository, 
                               IUnitOfWork uow,
                               IMapper mapper)
        {
            this.workshopRepository = workshopRepository;
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<bool> Create(CreateWorkshopViewModel ws)
        {
            var model = Workshop.Create(ws.Name,
                                        ws.Address,
                                        ws.Zipcode,
                                        ws.Url,
                                        ws.FacebookLink,
                                        ws.Type,
                                        ws.Access,
                                        ws.Phone,
                                        ws.CvrNumber,
                                        ws.SchooldId);

            workshopRepository.Add(model);
            var result = await uow.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<GetListWorkshopViewModel>> GetAllApproved()
        {
            var workshops = await workshopRepository.GetAllApproved();
            var viewModels = mapper.Map<IEnumerable<GetListWorkshopViewModel>>(workshops);

            return viewModels;
        }

        public async Task<GetSingleWorkshopViewModel> GetById(Guid id)
        {
            if (id == null || Guid.Empty == id)
                return null;
            
            var workshop = await workshopRepository.GetById(id);
            var viewmodel = mapper.Map<GetSingleWorkshopViewModel>(workshop);

            return viewmodel;
        }

        public async Task Delete(Guid id)
        {
            await workshopRepository.Delete(id);
            await uow.SaveChangesAsync();
        }

        public async Task<GetSingleWorkshopViewModel> ToggleApprovedStateOfWorkshop(Guid id)
        {
            var workshop = await workshopRepository.GetById(id);
            workshop.Approved = !workshop.Approved;

            await uow.SaveChangesAsync();

            var viewModel = mapper.Map<GetSingleWorkshopViewModel>(workshop);

            return viewModel;
        }

        public async Task<IEnumerable<GetListWorkshopViewModel>> GetAllPending()
        {
            var workshops = await workshopRepository.GetAllPending();
            var viewModels = mapper.Map<IEnumerable<GetListWorkshopViewModel>>(workshops);

            return viewModels;
        }
    }
}
