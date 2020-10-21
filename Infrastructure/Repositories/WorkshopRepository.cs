using Domain;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class WorkshopRepository : IWorkshopRepository
    {
        private readonly IDbContext context;

        public WorkshopRepository(IDbContext context)
        {
            this.context = context;
        }
        public void Add(Workshop workshop)
        {
            context.Workshops.Add(workshop);
        }

        public async Task Delete(Guid id)
        {
            var workshop = await GetById(id);
            context.Workshops.Remove(workshop);
        }

        public async Task<IEnumerable<Workshop>> GetAllApproved()
        {
            var workshops = await context.Workshops.Include(x => x.Location)
                                                   .Include(x => x.Phone)
                                                   .Where(x => x.Approved == true)
                                                   .ToListAsync();
            return workshops;
        }

        public async Task<IEnumerable<Workshop>> GetAllPending()
        {
            var workshops = await context.Workshops.Include(x => x.Location)
                                          .Include(x => x.Phone)
                                          .Where(x => x.Approved == false)
                                          .ToListAsync();
            return workshops;
        }

        public async Task<Workshop> GetById(Guid id)
        {
            var workshop = await context.Workshops.FirstOrDefaultAsync(x => x.Id == id);
            return workshop;
        }
    }
}
