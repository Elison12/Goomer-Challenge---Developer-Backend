using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GoomerChallenger.Domain.Interfaces.Abstractions;

namespace GoomerChallenger.Application.UserCases.Restaurantes.Response
{
    public class DeleteRestauranteError : IResponse
    {
        public HttpStatusCode Statuscode { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string> Errors { get; set; }

        public DeleteRestauranteError(HttpStatusCode statuscode, string message) {
            this.Statuscode = statuscode;
            this.Message = message;
        }
    }
}
