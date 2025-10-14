using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Apis.Models;

namespace Apis.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PremiosController : ControllerBase
    {
        // Lista simulando o "banco de dados"
        private static List<Premio> _premios = new List<Premio>
        {
            new Premio { Id = 1, Nome = "Caneca Sustentável", Descricao = "Feita com vidro reciclado", QtdItens = 10, QtdDisponiveis = 10, QtdPontos = 100 },
            new Premio { Id = 2, Nome = "Camiseta Ecológica", Descricao = "Feita de algodão orgânico", QtdItens = 15, QtdDisponiveis = 8, QtdPontos = 200 },
            new Premio { Id = 3, Nome = "Squeeze Inox", Descricao = "Garrafa reutilizável", QtdItens = 12, QtdDisponiveis = 5, QtdPontos = 150 }
        };

        // GET: api/premios
        [HttpGet]
        public ActionResult<IEnumerable<Premio>> GetAll()
        {
            return Ok(_premios);
        }

        // GET: api/premios/2
        [HttpGet("{id}")]
        public ActionResult<Premio> GetById(int id)
        {
            var premio = _premios.FirstOrDefault(p => p.Id == id);
            if (premio == null)
                return NotFound("Prêmio não encontrado");

            return Ok(premio);
        }

        // POST: api/premios
        [HttpPost]
        public ActionResult<Premio> Create([FromBody] Premio novoPremio)
        {
            if (novoPremio == null)
                return BadRequest("Dados inválidos");

            novoPremio.Id = _premios.Max(p => p.Id) + 1;
            _premios.Add(novoPremio);

            return CreatedAtAction(nameof(GetById), new { id = novoPremio.Id }, novoPremio);
        }

        // PUT: api/premios/2
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Premio premioAtualizado)
        {
            var premio = _premios.FirstOrDefault(p => p.Id == id);
            if (premio == null)
                return NotFound("Prêmio não encontrado");

            premio.Nome = premioAtualizado.Nome;
            premio.Descricao = premioAtualizado.Descricao;
            premio.QtdItens = premioAtualizado.QtdItens;
            premio.QtdDisponiveis = premioAtualizado.QtdDisponiveis;
            premio.QtdPontos = premioAtualizado.QtdPontos;

            return Ok(premio);
        }

        // DELETE: api/premios/2
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var premio = _premios.FirstOrDefault(p => p.Id == id);
            if (premio == null)
                return NotFound("Prêmio não encontrado");

            _premios.Remove(premio);
            return NoContent();
        }
    }
}
