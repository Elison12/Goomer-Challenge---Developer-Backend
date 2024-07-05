using System.Net;
using GoomerChallenger.Domain.Interfaces.Abstractions;

namespace GoomerChallenger.Application.UserCases.Produtos.Response
{
    public class NotFoundProduto : IResponse
    {
        public HttpStatusCode Statuscode { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string> Errors { get; set; }

        public NotFoundProduto(HttpStatusCode statusCode, string message)
        {
            this.Statuscode = statusCode;
            this.Message = message;
        }

    }
}
