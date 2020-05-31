using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sispar.Core.Notification;
using Sispar.Domain.TitheModule.Abstractions;
using Sispar.Domain.TitherModule.Abstractions;
using Sispar.Domain.UserModule.Abstractions;
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

            services.AddTransient<IUserRepository, EFUserRepository>();

            services.AddTransient<ITitherRepository, EFTitherRepository>();

            services.AddTransient<ITitheRepository, EFTitheRepository>();
        }
    }
}