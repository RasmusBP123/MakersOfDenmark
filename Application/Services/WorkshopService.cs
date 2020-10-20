﻿using Application.Interfaces;
using Application.ViewModels;
using Application.ViewModels.Workshop;
using Domain;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class WorkshopService : IWorkshopService
    {
        private readonly IWorkshopRepository workshopRepository;
        private readonly IUnitOfWork uow;

        public WorkshopService(IWorkshopRepository workshopRepository, IUnitOfWork uow)
        {
            this.workshopRepository = workshopRepository;
            this.uow = uow;
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

        public async Task Delete(Guid id)
        {
            await workshopRepository.Delete(id);
            await uow.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetListWorkshopViewModel>> GetAll()
        {
            var workshops = await workshopRepository.GetAll();
            return null;

        }

        public Task<GetSingleWorkshopViewModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
