using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Apis.Models;
namespace Apis.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DicasController : ControllerBase
    {
        // Cria uma lista estática para simular o banco de dados
        private static List<Dica> _dicas = new List<Dica>
        {
            new Dica { IdDica = 1, Categoria = "Programação", Descricao = "Use o debugger!"},
            new Dica { IdDica = 2, Categoria = "Comida", Descricao = "Experimente o pastel de feira daqui." },
        };

        private static int _nextId = 4; // Um ID inicial para novos itens

        // GET
        [HttpGet]
        public ActionResult<IEnumerable<Dica>> GetDicas()
        {
            return _dicas;
        }

        // GET /{id}
        [HttpGet("{id}")]
        public ActionResult<Dica> GetDica(int id)
        {
            var dica = _dicas.FirstOrDefault(d => d.IdDica == id);
            if (dica == null)
            {
                return NotFound();
            }
            return dica;
        }

        // POST
        [HttpPost]
        public ActionResult<Dica> PostDica(Dica dica)
        {
            dica.IdDica = _nextId++; // Atribui um novo ID
            _dicas.Add(dica);
            return CreatedAtAction(nameof(GetDica), new { id = dica.IdDica }, dica);
        }

        // PUT /{id}
        [HttpPut("{id}")]
        public IActionResult PutDica(int id, Dica dica)
        {
            if (id != dica.IdDica)
            {
                return BadRequest();
            }

            var existingDica = _dicas.FirstOrDefault(d => d.IdDica == id);
            if (existingDica == null)
            {
                return NotFound();
            }

            // Atualiza as propriedades da dica existente
            existingDica.IdLocal = dica.IdLocal;
            existingDica.IdUsuario = dica.IdUsuario;
            existingDica.Categoria = dica.Categoria;
            existingDica.Descricao = dica.Descricao;

            return NoContent();
        }

        // DELETE /{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteDica(int id)
        {
            var dica = _dicas.FirstOrDefault(d => d.IdDica == id);
            if (dica == null)
            {
                return NotFound();
            }

            _dicas.Remove(dica);
            return NoContent();
        }
    }
}