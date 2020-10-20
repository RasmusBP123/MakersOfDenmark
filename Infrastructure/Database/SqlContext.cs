﻿using Domain;
using Domain.Abstractions;
using Infrastructure.Database.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class SqlContext : DbContext, IDbContext, IUnitOfWork
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
            var result = await base.SaveChangesAsync();
            return (result > 0);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new WorkshopBuilder());
        }
    }
}
