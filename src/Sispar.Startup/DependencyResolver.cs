using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sispar.Core.Notification;
using Sispar.Domain.TitheModule.Abstractions;
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
            // Gera toda vez uma nova instância
            // services.AddTransient

            // Gera uma única instância por requisição
            // services.AddScoped

            // Uma instância única por aplicação
            // services.AddSingleton

            services.AddScoped<SisparDataContext>();
            services.AddScoped<NotificationContext>();

            var assembly = AppDomain.CurrentDomain.Load("Sispar.Application");
            services.AddMediatR(assembly);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TItherProfile());
                //mc.AddProfile(new TitheProfile());
                mc.AddProfile(new UserProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IUserRepository, EFUserRepository>();

            services.AddTransient<ITitherRepository, EFTitherRepository>();

            services.AddTransient<ITitheRepository, EFTitheRepository>();
        }
    }
}