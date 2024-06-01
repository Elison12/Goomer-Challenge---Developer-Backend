using System.Net;
using GoomerChallenger.Domain.Interfaces.Abstractions;

namespace GoomerChallenger.Application.UserCases.Restaurantes.Response
{
    public class CreatedSuccessfully : IResponse
    {
        public HttpStatusCode Statuscode { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string> Errors { get; set; }

        public CreatedSuccessfully(HttpStatusCode statuscode, string message)
        {
            Statuscode = statuscode;
            Message = message;
        }
    }
}
