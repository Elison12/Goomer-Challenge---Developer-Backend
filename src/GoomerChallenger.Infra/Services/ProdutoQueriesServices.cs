using GoomerChallenger.Domain.DTO;
using GoomerChallenger.Domain.Interfaces.Services;
using GoomerChallenger.Infra.Data.Context;
using GoomerChallenger.Notification.Results;
using Microsoft.EntityFrameworkCore;

namespace GoomerChallenger.Infra.Services
{
    public class ProdutoQueriesServices : IProdutoQueriesServices
    {
        private readonly GoomerContext _goomerContext;

        public ProdutoQueriesServices(GoomerContext goomerContext)
        {
            _goomerContext = goomerContext;
        }

        public async Task<Result<IEnumerable<ProdutoDTO>>> GetAllAsync()
        {
            try
            {
                var produtosList = await _goomerContext
                        .Produto
                        .AsNoTracking()
                        .Select(x => new ProdutoDTO
                        {
                            Id = x.IdProduto,
                            Nome = x.Nome,
                            Codigo = x.Codigo,
                            Valor = x.Valor,
                            Departamento = x.Departamento,
                            Categoria = x.Categoria,
                            Lote = x.Lote,
                            DtAquisicao = x.DtAquisicao,
                            DtValidade = x.DtValidade,
                            IsPromocao = x.IsPromocao,
                            CaminhoFoto = x.CaminhoFoto,

                        }).ToListAsync();

                return Result<IEnumerable<ProdutoDTO>>.Success(produtosList);

            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }
    }
}
