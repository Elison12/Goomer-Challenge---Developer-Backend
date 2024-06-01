using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GoomerChallenger.Domain.Interfaces.Abstractions;

namespace GoomerChallenger.Application.UserCases.Restaurantes.Response
{
    public class AlreadyExists : IResponse
    {
        public HttpStatusCode Statuscode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Dictionary<string, string> Errors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public AlreadyExists(HttpStatusCode statuscode, string message)
        {
            Statuscode = statuscode;
            Message = message;
        }

    }
}
