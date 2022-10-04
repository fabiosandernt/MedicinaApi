using MediatR;
using Medicina.Application.Exame.Handler.Command;
using Medicina.Application.Exame.Handler.Query;
using Medicina.CrossCutting.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Medicina.Application.Exame.Dto.UsuarioDto;

namespace Medicina.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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
            var result = await this.mediator.Send(new GetAllUsuarioQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}/ObterPorId")]
        public async Task<IActionResult> ObterPorId([FromRoute] Guid id)
        {
            var result = await this.mediator.Send(new GetUsuarioQuery(id));

            return result?.Usuario is null ? NotFound() : Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> Criar([FromBody] UsuarioInputDto dto)
        {
            if (dto is null) return UnprocessableEntity();

            try
            {
                var result = await this.mediator.Send(new CreateUsuarioCommand(dto));
                return Created($"{result.Usuario.Id}", result.Usuario);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponseError(e.Message));
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Atualizar([FromBody] UsuarioInputDto dto)
        {
            if (dto is null) return UnprocessableEntity();

            try
            {
                var result = await this.mediator.Send(new UpdateUsuarioCommand(dto));
                return Ok(result.Usuario);
            }
            catch(Exception e)
            {
                return BadRequest(new ApiResponseError(e.Message));
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Apagar(UsuarioInputDto dto)
        {
            var result = await this.mediator.Send(new DeleteUsuarioCommand(dto));
            return Ok(result.Usuario);
        }
    }
}
