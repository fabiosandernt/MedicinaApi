using MediatR;
using Microsoft.AspNetCore.Http;
using Medicina.Application.Exame.Dto;
using Medicina.Application.Exame.Handler.Command;
using Medicina.Application.Exame.Handler.Query;
using Medicina.CrossCutting.Utils;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("ObterPorId")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            return Ok(await this.mediator.Send(new GetFuncionarioQuery(id)));
        }

    
        [HttpPost()]
        public async Task<IActionResult> Criar(FuncionarioInputDto dto)
        {
            if (dto is null) return UnprocessableEntity();

            try
            {
                var result = await this.mediator.Send(new CreateFuncionarioCommand(dto));
                return Created($"{result.Funcionario.Id}", result.Funcionario);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponseError(e.Message));
            }            
           
        }

        [HttpPut()]
        public async Task<IActionResult> Atualizar(FuncionarioInputDto dto)
        {
            var result = await this.mediator.Send(new UpdateFuncionarioCommand(dto));
            return Ok(result.Funcionario);
        }

        [HttpDelete()]
        public async Task<IActionResult> Apagar(FuncionarioInputDto dto)
        {
            var result = await this.mediator.Send(new DeleteFuncionarioCommand(dto));
            return Ok(result.Funcionario);
        }

    }
}
