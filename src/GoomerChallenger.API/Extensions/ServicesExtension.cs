using GoomerChallenger.Application.Abstractions.Restaurantes;
using GoomerChallenger.Application.UserCases.Restaurantes.Handler;
using GoomerChallenger.Domain.Interfaces.BaseRepository;
using GoomerChallenger.Domain.Interfaces.Queries;
using GoomerChallenger.Domain.Interfaces.RestauranteRepository;
using GoomerChallenger.Domain.Interfaces.Services;
using GoomerChallenger.Domain.Interfaces.UnitOfWork;
using GoomerChallenger.Domain.Queries;
using GoomerChallenger.Infra.Data.Context;
using GoomerChallenger.Infra.Repositories;
using GoomerChallenger.Infra.Services;
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
            AddServices(builder);
            AddQueries(builder);
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

        private static void AddServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IRestauranteQueriesServices, RestauranteQueriesServices>();

        }

        private static void AddQueries(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IRestauranteQueries, RestauranteQueries>();

        }


    }
}