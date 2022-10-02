using MediatR;
using Medicina.Application.Exame.Dto;
using Medicina.Application.Exame.Handler.Command;
using Medicina.Application.Exame.Handler.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace Medicina.Api.Controller
{
    [Route("api/controller")]
    [ApiController]
   
    public class AsoController : ControllerBase
    {
        private readonly IMediator mediator;

        public AsoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.mediator.Send(new GetAllAsoQuery()));
        }

        [HttpGet("ObterPorId")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            return Ok(await this.mediator.Send(new GetAsoQuery(id)));
        }

        [HttpPost()]
        public async Task<IActionResult> Criar(AsoInputDto dto)
        {
            var result = await this.mediator.Send(new CreateAsoCommand(dto));
            return Created($"{result.Aso.Id}", result.Aso);
        }

        [HttpPut()]
        public async Task<IActionResult> Atualizar(AsoInputDto dto)
        {
            var result = await this.mediator.Send(new UpdateAsoCommand(dto));
            return Ok(result.Aso);
        }

        [HttpDelete()]
        public async Task<IActionResult> Apagar(AsoInputDto dto)
        {
            var result = await this.mediator.Send(new DeleteAsoCommand(dto));
            return Ok(result.Aso);
        }

    }
}
