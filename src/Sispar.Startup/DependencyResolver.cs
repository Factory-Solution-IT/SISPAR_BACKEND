using Microsoft.Extensions.DependencyInjection;
using Sispar.Business.Services;
using Sispar.Domain.Contracts;
using Sispar.Domain.Contracts.Services;
using Sispar.Infra.EF;
using Sispar.Infra.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, EFUserRepository>();
            services.AddTransient<ITitherService, TitherService>();
            services.AddTransient<ITitherRepository, EFTitherRepository>();

        }
    }
}
