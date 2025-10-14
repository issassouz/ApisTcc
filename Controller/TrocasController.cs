using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Apis.Models;

namespace Apis.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrocasController : ControllerBase
    {
        private static List<Troca> _trocas = new List<Troca>
        {
            new Troca { Id = 1, PremioId = 1, UsuarioId = 10, MomentoTroca = DateTime.UtcNow.AddDays(-2) },
            new Troca { Id = 2, PremioId = 3, UsuarioId = 5, MomentoTroca = DateTime.UtcNow.AddDays(-1) },
        };

        [HttpGet]
        public ActionResult<IEnumerable<Troca>> GetAll()
        {
            return Ok(_trocas);
        }

        [HttpGet("usuario/{usuarioId}")]
        public ActionResult<IEnumerable<Troca>> GetByUsuario(int usuarioId)
        {
            var trocasUsuario = _trocas.Where(t => t.UsuarioId == usuarioId).ToList();
            return Ok(trocasUsuario);
        }

        [HttpPost]
        public ActionResult<Troca> Create([FromBody] Troca novaTroca)
        {
            if (novaTroca == null)
                return BadRequest("Dados inválidos");

            novaTroca.Id = _trocas.Max(t => t.Id) + 1;
            novaTroca.MomentoTroca = DateTime.UtcNow;
            _trocas.Add(novaTroca);

            return CreatedAtAction(nameof(GetAll), novaTroca);
        }
    }
}
