using System.Net;
using GoomerChallenger.Domain.Interfaces.Abstractions;

namespace GoomerChallenger.Application.UserCases.Restaurantes.Response
{
    public class NotFoundRestaurante : IResponse
    {
        public HttpStatusCode Statuscode { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string> Errors { get; set; }

        public NotFoundRestaurante(HttpStatusCode statusCode, string message)
        {
            this.Statuscode = statusCode;
            this.Message = message;
        }

    }
}
