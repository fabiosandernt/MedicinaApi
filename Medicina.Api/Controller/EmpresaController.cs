using MediatR;
using Medicina.Application.Exame.Handler.Command;
using Medicina.Application.Exame.Handler.Query;
using Medicina.CrossCutting.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Medicina.Application.Exame.Dto.EmpresaDto;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Medicina.CrossCutting.JwtService.Contracts;

namespace Medicina.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmpresaController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IJwtService _jwtService;

        public EmpresaController(IMediator mediator, IJwtService jwtService)
        {
            this.mediator = mediator;
            _jwtService = jwtService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            return Ok(await this.mediator.Send(new GetAllEmpresaQuery()));
        }

        [HttpGet("ObterPorId")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            return Ok(await this.mediator.Send(new GetEmpresaQuery(id)));
        }

        
        [HttpPost()]
        public async Task<IActionResult> Criar(EmpresaInputDto dto)
        {
            if (dto is null) return UnprocessableEntity();

            try
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var jwtTokenVm = await _jwtService.ReadTokenAsync(token);
                if (jwtTokenVm is null) return Unauthorized();

                var result = await this.mediator.Send(new CreateEmpresaCommand(dto) { IdUsuario = jwtTokenVm.Id });
                
                return Created($"{result.Empresa.Id}", result.Empresa);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponseError(e.Message));
            }

        }

        [HttpPut()]
        public async Task<IActionResult> Atualizar(EmpresaInputDto dto)
        {
            var result = await this.mediator.Send(new UpdateEmpresaCommand(dto));
            return Ok(result.Empresa);
        }

        [HttpDelete()]
        public async Task<IActionResult> Apagar(EmpresaInputDto dto)
        {
            var result = await this.mediator.Send(new DeleteEmpresaCommand(dto));
            return Ok(result.Empresa);
        }

    }
}
