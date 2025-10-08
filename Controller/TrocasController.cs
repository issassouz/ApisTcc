using Microsoft.AspNetCore.Mvc;
using Apis.Repositories;
using System.Threading.Tasks;


namespace Apis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrocasController : ControllerBase
    {
        private readonly ITrocaRepository _repo;

        public TrocasController(ITrocaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _repo.ListarAsync();
            return Ok(list);
        }

        [HttpGet("usuario/{usuarioId:int}")]
        public async Task<IActionResult> GetByUsuario(int usuarioId)
        {
            var list = await _repo.ListarPorUsuarioAsync(usuarioId);
            return Ok(list);
        }
    }
}
