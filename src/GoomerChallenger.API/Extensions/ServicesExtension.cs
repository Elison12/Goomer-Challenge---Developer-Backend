using GoomerChallenger.Application.Abstractions.Restaurantes;
using GoomerChallenger.Application.UserCases.Restaurantes.Handler;
using GoomerChallenger.Domain.Interfaces.UnitOfWork;
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
            string connection = configuration.GetConnectionString("DefaultConnection") ?? throw new NotConnectionDefinedException($"Nenhuma conexão foi definida");

            services.AddDbContext<GoomerContext>(options => options.UseNpgsql(connection));
            #endregion
        }

        public static void AddDependencies(this WebApplicationBuilder builder)
        {
            AddRepository(builder);
            AddRestauranteHandler(builder);
        }

        private static void AddRepository(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(serviceType: typeof(IBaseRepository<>), implementationType: typeof(BaseRepository<>));
            builder.Services.AddScoped<IRestauranteRepository, RestauranteRepository>();
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
        }
        private static void AddRestauranteHandler(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICreateRestaurante, CreateRestauranteHandler>();
        }


    }
}