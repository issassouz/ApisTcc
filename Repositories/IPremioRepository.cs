using Apis.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apis.Repositories
{
    public interface IPremioRepository
    {
        Task<IEnumerable<Premio>> ListarAsync();
        Task<Premio?> ObterPorIdAsync(int id);
        Task<Premio> InserirAsync(Premio p);
        Task AtualizarAsync(Premio p);
    }
    public interface ITrocaRepository
    {
        Task<Troca> InserirAsync(Troca t);
        Task<IEnumerable<Troca>> ListarAsync();
        Task<IEnumerable<Troca>> ListarPorUsuarioAsync(int usuarioId);
    }
     public interface IPontuacaoRepository
    {
        Task<Pontuacao?> ObterPorUsuarioAsync(int usuarioId);
        Task AtualizarAsync(Pontuacao p);
        Task InserirAsync(Pontuacao p);
    }
}
