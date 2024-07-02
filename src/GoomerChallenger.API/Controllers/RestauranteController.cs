using System.Net;
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

                if (response.Statuscode == HttpStatusCode.BadRequest)
                    return Results.BadRequest(response);

                return Results.Created("", response);
            })
                .Produces(StatusCodes.Status200OK, typeof(CreatedSuccessfully))
                .Produces(StatusCodes.Status400BadRequest, typeof(InvalidRequest))
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Cadastro",
                    Description = "Endpoint para cadastrar novo restaurante.",
                })
                .DisableAntiforgery();


            restauranteRoute.MapGet("/Restaurante", async ([FromServices] IRestauranteQueriesServices services) =>
            {
                var response = await services.GetAllAsync();

                return Results.Ok(response);

            }).Produces(StatusCodes.Status200OK, typeof(IEnumerable<RestauranteDTO>))
              .WithOpenApi(operation => new(operation)
              {
                  Summary = "Listar",
                  Description = "Endpoint para retornar todos os restaurantes cadastrados.",
              });

            restauranteRoute.MapDelete("/Restaurante", async ([FromQuery] int idRestaurante,
                                                             [FromServices] DeleteRestauranteInterface handler,
                                                             CancellationToken cancellationToken) =>
            {
                var request = new DeleteRestauranteRequest(idRestaurante);
                var response = await handler.Handler(request, cancellationToken);

                if (response.Statuscode == HttpStatusCode.BadRequest)
                {
                    return Results.BadRequest(response);
                }
                if (response.Statuscode == HttpStatusCode.InternalServerError)
                    return Results.StatusCode(500);

                return Results.Ok(response);
            })
                .Produces(StatusCodes.Status200OK, typeof(DeletedSuccessfully))
                .Produces(StatusCodes.Status400BadRequest, typeof(InvalidRequest))
                .Produces(StatusCodes.Status500InternalServerError, typeof(DeleteRestauranteError))
                .WithOpenApi(operation => new(operation)
              {
                  Summary = "Excluir",
                  Description = "Endpoint para exclusão de um restaurante com base no seu ID",
              });

            restauranteRoute.MapPut("/Restaurante", async ([FromForm] UpdateRestauranteRequest request,
                                                     [FromServices] UpdateRestauranteInterface handler,
                                                     CancellationToken cancellationToken
             ) =>
            {
                var response = await handler.Handle(request, cancellationToken);
                if (response.Statuscode == HttpStatusCode.BadRequest)
                {
                    return Results.BadRequest(response);
                }

                if (response.Statuscode == HttpStatusCode.InternalServerError)
                {
                    return Results.StatusCode(500);
                }

                return Results.Ok(response);
            }
            ).WithOpenApi(operation => new(operation)
            {
                Summary = "Atualização dos dados de um restaurante.",
                Description = "Endpoint para atualizar o nome do usuário.",
            })
            .DisableAntiforgery();
        }
    }


}