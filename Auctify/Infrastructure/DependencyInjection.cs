using Application.Services;
using Application.Services.Common;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer("Server=TNTRA-SNEHAL;Database=AuctifyMVCDatabase;Trusted_Connection=True; TrustServerCertificate=True");
            });

            //Registered the interface with the repository.
            services.AddScoped<IRegister, RegisterRepository>();

            // Registered the specific services.
            services.AddScoped<AuthConfigService>();
            services.AddScoped<RegisterService>();
            //services.AddScoped<IdeaService>();

            //return services;
        }
    }
}
