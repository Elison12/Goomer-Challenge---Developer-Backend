using GoomerChallenger.Application.Abstractions.Restaurantes;
using GoomerChallenger.Application.UserCases.Restaurantes.Request;
using GoomerChallenger.Application.UserCases.Restaurantes.Response;
using Microsoft.AspNetCore.Mvc;

namespace GoomerChallenger.API.Controller
{

    public static class RestauranteController
    {


        //public RestauranteController() { }

        public static void AddRestauranteRoutes(this RouteGroupBuilder route)
        {
            var restauranteRoute = route.MapGroup("restaurante");

            restauranteRoute.MapPost("/Restaurante", async ([FromForm] CreateRestauranteRequest request,
                                        [FromServices] ICreateRestaurante handler
                                 ) =>
            {
                var response = await handler.Handle(request);

                if (response.Statuscode == System.Net.HttpStatusCode.BadRequest)
                    return Results.BadRequest(response);

                return Results.Created("users/activate-user", response);
            })
                .Produces(StatusCodes.Status200OK, typeof(CreatedSuccessfully))
                .Produces(StatusCodes.Status400BadRequest, typeof(InvalidRequest))
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Realizar login",
                    Description = "Permite realizar login na aplicação, retorna um token de acesso que deve ser configurado para ser utilizado nos endpoints que o solicitem.",
                })
                .DisableAntiforgery();
        }


        //[HttpPost]
        //public async Task<IResult> Create(CreateRestauranteRequest request, [FromServices] ICreateRestaurante handler)
        //{
        //    try
        //    {
        //        var response = await handler.Handle(request);
        //        if (response.Statuscode == System.Net.HttpStatusCode.BadRequest) {
        //            return Results.BadRequest(response);
        //        }
        //        return Results.Ok(response);
        //    }
        //    catch (Exception ex)
        //    {


        //    }
        //}

        //[HttpGet]
        //public Task<ActionResult> Get(int id)
        //{
        //    try
        //    {
        //        throw new NotImplementedException();
        //    }
        //    catch ( Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public Task<ActionResult> GetAll()
        //{
        //    try
        //    {
        //        throw new NotImplementedException();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public Task<ActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        throw new NotImplementedException();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public Task<ActionResult> Update(int id)
        //{
        //    try
        //    {
        //        throw new NotImplementedException();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
    }


}