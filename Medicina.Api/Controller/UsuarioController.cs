using Medicina.Application.Exame.Dto;
using Medicina.Application.Exame.Handler.Command;
using Medicina.Domain.Account.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Medicina.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public IUsuarioRepository UsuarioRepository { get; }

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            UsuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.UsuarioRepository.GetAll());
        }

        //[HttpPost()]
        //public async Task<IActionResult> Criar(UsuarioInputDto dto)
        //{
        //    var result = await this.mediator.Send(new CreateUsuarioCommand(dto));
        //    return Created($"{result.Usuario.Id}", result.Usuario);
        //}
    }
}
