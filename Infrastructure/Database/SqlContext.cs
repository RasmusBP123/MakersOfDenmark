using Domain;
using Domain.Abstractions;
using Infrastructure.Database.Mappings;
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
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Calendar> Calendars { get; set; }

        public async Task<bool> SaveChangesAsync()
        {
            return (await base.SaveChangesAsync() > 0);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new WorkshopBuilder());
        }
    }
}
