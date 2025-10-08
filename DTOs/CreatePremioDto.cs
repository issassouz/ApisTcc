using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apis.DTOs
{
    public class CreatePremioDto
    {
         public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int QtdItens { get; set; }
        public int QtdDisponiveis { get; set; }
        public int QtdPontos { get; set; }
        
    }
}