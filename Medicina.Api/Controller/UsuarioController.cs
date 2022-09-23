using MediatR;
using Medicina.Application.Exame.Dto;
using Medicina.Application.Exame.Handler.Command;
using Medicina.Application.Exame.Handler.Query;
using Medicina.Domain.Account.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Medicina.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsuarioController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.mediator.Send(new GetAllUsuarioQuery()));
        }

        [HttpGet("ObterPorId")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            return Ok(await this.mediator.Send(new GetUsuarioQuery(id)));
        }

        [HttpPost()]
        public async Task<IActionResult> Criar(UsuarioInputDto dto)
        {
            var result = await this.mediator.Send(new CreateUsuarioCommand(dto));
            return Created($"{result.Usuario.Id}", result.Usuario);
        }

        [HttpPut()]
        public async Task<IActionResult> Atualizar(UsuarioInputDto dto)
        {
            var result = await this.mediator.Send(new UpdateUsuarioCommand(dto));
            return Ok(result.Usuario);
        }

        [HttpDelete()]
        public async Task<IActionResult> Apagar(UsuarioInputDto dto)
        {
            var result = await this.mediator.Send(new DeleteUsuarioCommand(dto));
            return Ok(result.Usuario);
        }
    }
}
