using Apis.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apis.Repositories
{
    public class PremioRepository : IPremioRepository
    {
        private readonly List<Premio> _store = new();
        
        private int _nextId = 1;

        public PremioRepository()
        {
            // seed sample
            _store.Add(new Premio { Id = _nextId++, Nome = "Caneca Sustentável", Descricao = "Caneca de vidro reciclado", QtdItens = 10, QtdDisponiveis = 10, QtdPontos = 100 });
            _store.Add(new Premio { Id = _nextId++, Nome = "Camiseta", Descricao = "Camiseta com logo", QtdItens = 20, QtdDisponiveis = 5, QtdPontos = 250 });
        }

        public Task<Premio> InserirAsync(Premio p)
        {
            p.Id = _nextId++;
            _store.Add(p);
            return Task.FromResult(p);
        }

        public Task<Premio?> ObterPorIdAsync(int id)
        {
            var p = _store.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(p);
        }

        public Task<IEnumerable<Premio>> ListarAsync()
        {
            return Task.FromResult<IEnumerable<Premio>>(_store.ToList());
        }

        public Task AtualizarAsync(Premio p)
        {
            var existing = _store.FirstOrDefault(x => x.Id == p.Id);
            if (existing != null)
            {
                existing.Nome = p.Nome;
                existing.Descricao = p.Descricao;
                existing.QtdItens = p.QtdItens;
                existing.QtdDisponiveis = p.QtdDisponiveis;
                existing.QtdPontos = p.QtdPontos;
            }
            return Task.CompletedTask;
        }
        public class TrocaRepository
        {
             private readonly List<Troca> _store = new();
        private int _nextId = 1;

        public Task<Troca> InserirAsync(Troca t)
        {
            t.Id = _nextId++;
            t.MomentoTroca = DateTime.UtcNow;
            _store.Add(t);
            return Task.FromResult(t);
        }

        public Task<IEnumerable<Troca>> ListarAsync()
        {
            return Task.FromResult<IEnumerable<Troca>>(_store.ToList());
        }

        public Task<IEnumerable<Troca>> ListarPorUsuarioAsync(int usuarioId)
        {
            var res = _store.Where(x => x.UsuarioId == usuarioId).ToList();
            return Task.FromResult<IEnumerable<Troca>>(res);
        }

        }
        public class PontuacaoRepository
        {
             private readonly List<Pontuacao> _store = new();

        public PontuacaoRepository()
        {
            // seed: exemplo de usuários com pontos
            _store.Add(new Pontuacao { UsuarioId = 1, Saldo = 500 });
            _store.Add(new Pontuacao { UsuarioId = 42, Saldo = 150 });
            _store.Add(new Pontuacao { UsuarioId = 99, Saldo = 30 });
        }

        public Task InserirAsync(Pontuacao p)
        {
            _store.Add(p);
            return Task.CompletedTask;
        }

        public Task<Pontuacao?> ObterPorUsuarioAsync(int usuarioId)
        {
            var p = _store.FirstOrDefault(x => x.UsuarioId == usuarioId);
            return Task.FromResult(p);
        }

        public Task AtualizarAsync(Pontuacao p)
        {
            var ex = _store.FirstOrDefault(x => x.UsuarioId == p.UsuarioId);
            if (ex != null)
            {
                ex.Saldo = p.Saldo;
            }
            return Task.CompletedTask;
        }

        }
    }
}
