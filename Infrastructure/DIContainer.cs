using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Infrastructure.Database;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DIContainer
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IDbContext, SqlContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IWorkshopRepository, WorkshopRepository>();

            services.AddDbContext<SqlContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            

            return services;
        }
    }
}
