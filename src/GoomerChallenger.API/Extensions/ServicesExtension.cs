using GoomerChallenger.Application.Abstractions.Produtos;
using GoomerChallenger.Application.Abstractions.Restaurantes;
using GoomerChallenger.Application.UserCases.Produtos.Handler;
using GoomerChallenger.Application.UserCases.Restaurantes.Handler;
using GoomerChallenger.Domain.Interfaces.BaseRepository;
using GoomerChallenger.Domain.Interfaces.ProdutoRepository;
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
            RestauranteHandler(builder);
            ProdutoHandler(builder);
            AddServices(builder);
            AddQueries(builder);
        }

        private static void ProdutoHandler(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<CreateProdutoInterface, CreateProdutoHandler>();
        }

        private static void AddRepository(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(serviceType: typeof(IBaseRepository<>), implementationType: typeof(BaseRepository<>));
            builder.Services.AddScoped<IRestauranteRepository, RestauranteRepository>();
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
        }
        private static void RestauranteHandler(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICreateRestaurante, CreateRestauranteHandler>();
            builder.Services.AddScoped<DeleteRestauranteInterface, DeleteRestauranteHandler>();
            builder.Services.AddScoped<UpdateRestauranteInterface, UpdateRestauranteHandler>();
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