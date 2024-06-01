using System.Net;
using GoomerChallenger.Domain.Interfaces.Abstractions;

namespace GoomerChallenger.Application.Abstractions.Response
{
    public class DomainNotification : IResponse
    {
        public DomainNotification(HttpStatusCode StatusCode, List<Dictionary<string, string>> Errors)
        {
            this.Statuscode = StatusCode;
            this.Errors = Errors
                         .SelectMany(dict => dict)
                         .ToDictionary(pair => pair.Key, pair => pair.Value);
        }
        public HttpStatusCode Statuscode { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string> Errors { get; set; }
    }
}
