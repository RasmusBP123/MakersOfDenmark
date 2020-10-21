using Domain;
using Domain.Abstractions;
using Infrastructure.Database.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class SqlContext : IdentityDbContext, IDbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
            
        }

        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        public async Task<bool> SaveChangesAsync()
        {
            return (await base.SaveChangesAsync() > 0);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkshopBuilder());
            modelBuilder.ApplyConfiguration(new RoleBuilder());
            base.OnModelCreating(modelBuilder);
        }
    }
}
