using Medicina.Domain.Account.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Medicina.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AsoController : ControllerBase
    {
        public IUsuarioRepository UsuarioRepository { get; }

        public AsoController(IUsuarioRepository usuarioRepository)
        {
            UsuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.UsuarioRepository.GetAll());
        }
    }
}
