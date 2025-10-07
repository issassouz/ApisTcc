using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Apis.Models
{
    public class Dica
    {
        [Key]
        public int IdDica { get; set; }

        [Required]
        public int IdLocal { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [MaxLength(50)]
        public string Categoria { get; set; }

        [MaxLength(200)]
        public string Descricao { get; set; }
        
        
    }
}