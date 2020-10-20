using Application.Interfaces;
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
        private readonly IDbContext context;

        public WorkshopService(IWorkshopRepository workshopRepository, IDbContext context)
        {
            this.workshopRepository = workshopRepository;
            this.context = context;

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

            context.Workshops.Add(model);
            var result = await context.SaveChangesAsync();

            return result;
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CreateWorkshopViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<GetSingleWorkshopViewModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
