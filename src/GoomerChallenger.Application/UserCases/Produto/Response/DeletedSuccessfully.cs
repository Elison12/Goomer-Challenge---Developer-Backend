using System.Net;
using GoomerChallenger.Domain.Interfaces.Abstractions;

namespace GoomerChallenger.Application.UserCases.Produtos.Response
{
    public class DeletedSuccessfully : IResponse
    {

        public HttpStatusCode Statuscode { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string> Errors { get; set; }
        public DeletedSuccessfully(HttpStatusCode statuscode, string message)
        {
            Statuscode = statuscode;
            Message = message;
        }

    }
}
