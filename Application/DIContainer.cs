using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Application
{
    public static class DIContainer
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddScoped<IWorkshopService, WorkshopService>();
            services.AddScoped<IAuthServiceProvider, AuthServiceProvider>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            return services;
        }
    }
}
