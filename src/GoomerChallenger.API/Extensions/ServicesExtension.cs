using GoomerChallenger.Infra.Data.Context;
using GoomerChallenger.Infra.Interfaces;
using GoomerChallenger.Infra.Repositories;
using GoomerChallenger.Notification.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GoomerChallenger.API.Extension
{


    public static class ServicesExtensions
    {
        public static void AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            #region Connection
            string connection = configuration.GetConnectionString("Database") ?? throw new NotConnectionDefinedException($"Nenhuma conexão foi definida");

            services.AddDbContext<GoomerContext>(options => options.UseNpgsql(connection));
            #endregion
        }

        public static void AddDependencies(this WebApplicationBuilder builder)
        {
            //AddRepository(builder);
        }

        private static void AddRepository(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(serviceType: typeof(IBaseRepository<>), implementationType: typeof(BaseRepository<>));
            //builder.Services.AddScoped<Interface, Implementação>();
        }


    }
}