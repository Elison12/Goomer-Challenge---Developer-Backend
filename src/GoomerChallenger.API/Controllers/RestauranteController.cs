using GoomerChallenger.Application.Abstractions.Restaurantes;
using GoomerChallenger.Application.UserCases.Restaurantes.Request;
using GoomerChallenger.Application.UserCases.Restaurantes.Response;
using GoomerChallenger.Domain.DTO;
using GoomerChallenger.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoomerChallenger.API.Controller
{

    public static class RestauranteController
    {

        public static void AddRestauranteRoutes(this RouteGroupBuilder route)
        {
            var restauranteRoute = route.MapGroup("restaurante");

            restauranteRoute.MapPost("/Restaurante", async ([FromForm] CreateRestauranteRequest request,
                                        [FromServices] ICreateRestaurante handler,
                                        CancellationToken cancellationToken
                                 ) =>
            {
                var response = await handler.Handle(request, cancellationToken);

                if (response.Statuscode == System.Net.HttpStatusCode.BadRequest)
                    return Results.BadRequest(response);

                return Results.Created("", response);
            })
                .Produces(StatusCodes.Status200OK, typeof(CreatedSuccessfully))
                .Produces(StatusCodes.Status400BadRequest, typeof(InvalidRequest))
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Realiza cadastro de um restaurante",
                    Description = "",
                })
                .DisableAntiforgery();


            restauranteRoute.MapGet("/", async ([FromServices] IRestauranteQueriesServices services) =>
            {
                var users = await services.GetAllAsync();

                return Results.Ok(users);

            }).Produces(StatusCodes.Status200OK, typeof(IEnumerable<RestauranteDTO>))
              .WithOpenApi(operation => new(operation)
              {
                  Summary = "Retorna todos os restaurantes",
                  Description = "Endpoint para retornar todos os restaurantes cadastrados.",
              });
        }
    }


}