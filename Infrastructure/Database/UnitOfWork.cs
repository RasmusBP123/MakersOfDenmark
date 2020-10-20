using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext context;

        public UnitOfWork(IDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
