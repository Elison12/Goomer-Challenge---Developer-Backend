using System.Net;
using GoomerChallenger.Application.Abstractions.Produtos;
using GoomerChallenger.Application.UserCases.Produtos.Request;
using GoomerChallenger.Application.UserCases.Restaurantes.Response;
using Microsoft.AspNetCore.Mvc;

namespace GoomerChallenger.API.Controllers.Produto
{
    public static class ProcutoController
    {
        public static void AddProdutoRoutes(this RouteGroupBuilder route)
        {
            var produtoRoute = route.MapGroup("produto");

            produtoRoute.MapPost("/Produto", async ([FromForm] CreateProdutoRequest request,
                                               [FromServices] CreateProdutoInterface handler,
                                               CancellationToken cancellationToken
                                ) =>
            {
                var response = await handler.Handle(request, cancellationToken);

                if (response.Statuscode == HttpStatusCode.BadRequest)
                {
                    return Results.BadRequest(response);
                }
                return Results.Created("", response);
            }
            )
                .Produces(StatusCodes.Status200OK, typeof(CreatedSuccessfully))
                .Produces(StatusCodes.Status400BadRequest, typeof(InvalidRequest))
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Cadastro",
                    Description = "Endpoint para cadastrar novo produto.",
                })
                .DisableAntiforgery();
        }
    }
}