using System.Net;

namespace GoomerChallenger.Domain.Interfaces.Abstractions
{
    public interface IResponse
    {
        HttpStatusCode Statuscode { get; set; }
        string Message { get; set; }
        Dictionary<string, string> Erros { get; set; }
    }
}
