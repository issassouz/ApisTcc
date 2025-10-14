using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apis.Models
{
    public class Premio
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int QtdItens { get; set; }
        public int QtdDisponiveis { get; set; }
        public int QtdPontos { get; set; }
    }

    public class Troca
    {
        public int Id { get; set; }
        public int PremioId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime MomentoTroca { get; set; }
    }

    public class Pontuacao
    {
        public int UsuarioId { get; set; }
        public int Saldo { get; set; }
    }
}
