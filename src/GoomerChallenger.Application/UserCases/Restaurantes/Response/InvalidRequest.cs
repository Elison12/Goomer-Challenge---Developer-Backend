using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GoomerChallenger.Domain.Interfaces.Abstractions;

namespace GoomerChallenger.Application.UserCases.Restaurantes.Response
{
    public class InvalidRequest : IResponse
    {
        public InvalidRequest(HttpStatusCode statuscode, string message, Dictionary<string, string> errors)
        {
            Statuscode = statuscode;
            Message = message;
            Errors = errors;
        }

        public HttpStatusCode Statuscode { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string> Errors { get; set; }
    }
}
