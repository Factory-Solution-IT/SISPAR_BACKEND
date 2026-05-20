using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sispar.Core.Notification;
using Sispar.Domain.TitheModule.Abstractions;
using Sispar.Domain.TitheModule.Adapters;
using Sispar.Domain.TitherModule;
using Sispar.Domain.TitherModule.Abstractions;
using Sispar.Domain.TitherModule.Adapters;
using Sispar.Domain.UserModule.Abstractions;
using Sispar.Domain.UserModule.Adapters;
using Sispar.Domain.UserModule.Commands;
using Sispar.Infra.EF;
using Sispar.Infra.EF.Repositories;
using System;
using System.Reflection;

namespace Sispar.Startup
{
    public static class DependencyResolver
    {
        public static void Resolve(IServiceCollection services)
        {
            services.AddScoped<SisparDataContext>();
            services.AddScoped<NotificationContext>();

            var assembly = AppDomain.CurrentDomain.Load("Sispar.Application");

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly)); 
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IUserRepository, EFUserRepository>();

            services.AddTransient<ITitherRepository, EFTitherRepository>();

            services.AddTransient<ITitheRepository, EFTitheRepository>();
        }
    }
}