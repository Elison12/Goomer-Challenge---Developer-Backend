using System.Net;
using GoomerChallenger.Domain.Interfaces.Abstractions;

namespace GoomerChallenger.Application.UserCases.Restaurantes.Response
{
    public class UnsupportedFile : IResponse
    {
        public UnsupportedFile(HttpStatusCode statuscode, string message)
        {
            Statuscode = statuscode;
            Message = message;
        }

        public HttpStatusCode Statuscode { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string> Errors { get; set; }
    }
}
