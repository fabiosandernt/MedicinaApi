using MediatR;
using Medicina.Application.Exame.Dto;
using Medicina.Application.Exame.Handler.Command;
using Medicina.Application.Exame.Handler.Query;
using Microsoft.AspNetCore.Mvc;
using static Medicina.Application.Exame.Dto.FuncionarioDto;

namespace Medicina.Api.Controller
{
    [Route("api/controller")]
    [ApiController]
    //[Authorize]
    public class FuncionarioController : ControllerBase
    {
        private readonly IMediator mediator;

        public FuncionarioController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.mediator.Send(new GetAllFuncionarioQuery()));
        }

        [HttpPost()]
        public async Task<IActionResult> Criar(FuncionarioInputDto dto)
        {
            var result = await this.mediator.Send(new CreateFuncionarioCommand(dto));
            return Created($"{result.Funcionario.Id}", result.Funcionario);
        }
    }
}
