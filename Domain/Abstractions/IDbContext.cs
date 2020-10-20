using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IDbContext
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        Task<bool> SaveChangesAsync();
    }
}
