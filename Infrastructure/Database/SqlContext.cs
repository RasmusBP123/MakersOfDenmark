using Domain;
using Domain.Abstractions;
using Infrastructure.Database.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class SqlContext : DbContext, IDbContext
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
            base.OnModelCreating(modelBuilder);
        }
    }
}
