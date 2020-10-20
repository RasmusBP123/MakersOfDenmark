using Domain;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class SqlContext : DbContext, IDbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<ApplicationUser> Users { get ; set; }

        public async Task<bool> SaveChangesAsync()
        {
            return (await base.SaveChangesAsync() > 0);
        }
    }
}
