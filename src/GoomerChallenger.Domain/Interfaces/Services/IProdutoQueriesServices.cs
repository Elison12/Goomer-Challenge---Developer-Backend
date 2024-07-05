using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoomerChallenger.Domain.DTO;
using GoomerChallenger.Notification.Results;

namespace GoomerChallenger.Domain.Interfaces.Services
{
    public interface IProdutoQueriesServices
    {
        Task<Result<IEnumerable<ProdutoDTO>>> GetAllAsync();
    }
}
