using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Interfaces;
using NorthWind.Repositories.EFCore.DataContext;
using NorthWind.Repositories.EFCore.Repositories;

using NorthWind.UseCases.Common.Validators;
using NorthWind.UseCases.CreateOrder;
using NorthWind.UseCasesPorts.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.loC
{
    public static class DependencyContainer
    {

        public static IServiceCollection AddNorthWindServices(
     this IServiceCollection services,
     IConfiguration configuration)
        {
            services.AddDbContext<NorthWindContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("NorthWindDB")));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IUnitOFWork, UnitOfWork>();

           
            services.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
            services.AddScoped<ICreateOrderInputPort, CreateOrderInteractor>();
         
            return services;
        }

    }
}
