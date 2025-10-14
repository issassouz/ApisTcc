using Apis.Models;
using Apis.Repositories;
using System;
using System.Threading.Tasks;

namespace Apis.Services
{
    public class RecompensaService
    {
        private readonly IPremioRepository _premioRepo;
        private readonly ITrocaRepository _trocaRepo;
        private readonly IPontuacaoRepository _pontRepo;

        public RecompensaService(IPremioRepository premioRepo, ITrocaRepository trocaRepo, IPontuacaoRepository pontRepo)
        {
            _premioRepo = premioRepo;
            _trocaRepo = trocaRepo;
            _pontRepo = pontRepo;
        }

        public Task<System.Collections.Generic.IEnumerable<Premio>> ListarPremiosAsync() => _premioRepo.ListarAsync();
        public Task<Premio?> ObterPremioAsync(int id) => _premioRepo.ObterPorIdAsync(id);
        public Task<Premio> CriarPremioAsync(Premio p) => _premioRepo.InserirAsync(p);

        // Resgate (resgatar prêmio)
        public async Task<(bool Success, string Message, Troca? Troca)> ResgatarPremioAsync(int premioId, int usuarioId)
        {
            var premio = await _premioRepo.ObterPorIdAsync(premioId);
            if (premio == null)
                return (false, "Prêmio não encontrado.", null);

            if (premio.QtdDisponiveis <= 0)
                return (false, "Prêmio indisponível (sem unidades).", null);

            var pont = await _pontRepo.ObterPorUsuarioAsync(usuarioId);
            if (pont == null)
                return (false, "Usuário não possui pontuação registrada.", null);

            if (pont.Saldo < premio.QtdPontos)
                return (false, "Pontos insuficientes para resgatar.", null);

            // Deduz pontos e reduz quantidade
            pont.Saldo -= premio.QtdPontos;
            premio.QtdDisponiveis -= 1;

            await _pontRepo.AtualizarAsync(pont);
            await _premioRepo.AtualizarAsync(premio);

            var troca = new Troca
            {
                PremioId = premio.Id,
                UsuarioId = usuarioId,
            };

            var trocado = await _trocaRepo.InserirAsync(troca);
            return (true, "Prêmio resgatado com sucesso.", trocado);
        }
    }
}
