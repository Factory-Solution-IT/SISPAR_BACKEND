using Microsoft.Extensions.DependencyInjection;
using Sispar.Core.Notification;
using Sispar.Domain.Contracts.Repositories;
using Sispar.Infra.EF;
using Sispar.Infra.EF.Repositories;

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

            services.AddTransient<IUserRepository, EFUserRepository>();

            services.AddTransient<ITitherRepository, EFTitherRepository>();

            services.AddTransient<ITitheRepository, EFTitheRepository>();
        }
    }
}