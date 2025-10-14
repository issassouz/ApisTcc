using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Apis.Models;

namespace Apis.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PontosTuristicosController : ControllerBase
   {
        private static List<PontoTuristico> _pontoTuristico = new List<PontoTuristico>
        {
            new PontoTuristico { Id = 1, Nome = "Praça Central", Descricao = "Tem uma estatu muito famosa", Localizacao = "Praça principal", ImagemUrl = "https://exemplo.com/praça.jpg" },
            new PontoTuristico { Id = 3, Nome = "Parque Ecológico", Descricao = "Área verde com trilhas e lago", Localizacao = "Bairro Verde", ImagemUrl = "https://exemplo.com/parque.jpg" },
            new PontoTuristico { Id = 4, Nome = "Igreja Matriz", Descricao = "Construção histórica do bairro", Localizacao = "Avenida", ImagemUrl = "https://exemplo.com/igreja.jpg" },
            new PontoTuristico { Id = 5, Nome = "Mirante", Descricao = "Vista panorâmica da cidade", Localizacao = "Serra Alta", ImagemUrl = "https://exemplo.com/mirante.jpg" },
            new PontoTuristico { Id = 6, Nome = "Feira de Artesanato", Descricao = "Produtos locais e cultura regional", Localizacao = "Praça principal", ImagemUrl = "https://exemplo.com/feira.jpg" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<PontoTuristico>> GetAll()
        {
            return Ok( _pontoTuristico);
        }

        [HttpGet("{id}")]
        public ActionResult<PontoTuristico> GetById(int id)
        {
            var ponto =  _pontoTuristico.FirstOrDefault(p => p.Id == id);
            if (ponto == null)
                return NotFound();
            return Ok(ponto);
        }

        [HttpPost]
        public ActionResult<PontoTuristico> Create(PontoTuristico novoPonto)
        {
            novoPonto.Id =  _pontoTuristico.Max(p => p.Id) + 1;
             _pontoTuristico.Add(novoPonto);
            return CreatedAtAction(nameof(GetById), new { id = novoPonto.Id }, novoPonto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PontoTuristico pontoAtualizado)
        {
            var ponto =  _pontoTuristico.FirstOrDefault(p => p.Id == id);
            if (ponto == null)
                return NotFound();

            ponto.Nome = pontoAtualizado.Nome;
            ponto.Descricao = pontoAtualizado.Descricao;
            ponto.Localizacao = pontoAtualizado.Localizacao;
            ponto.ImagemUrl = pontoAtualizado.ImagemUrl;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ponto =  _pontoTuristico.FirstOrDefault(p => p.Id == id);
            if (ponto == null)
                return NotFound();

             _pontoTuristico.Remove(ponto);
            return NoContent();
        }
    }
}
