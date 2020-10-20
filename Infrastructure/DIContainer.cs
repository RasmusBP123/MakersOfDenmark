using Domain.Abstractions;
using Domain.Abstractions.Authentication;
using Domain.Abstractions.Repositories;
using Infrastructure.Database;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public static class DIContainer
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUnitOfWork, SqlContext>();
            services.AddScoped<IDbContext, SqlContext>();

            services.AddScoped<IWorkshopRepository, WorkshopRepository>();

            services.AddDbContext<SqlContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            

            return services;
        }
    }
}
