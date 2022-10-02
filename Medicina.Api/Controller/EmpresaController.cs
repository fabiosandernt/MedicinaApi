using MediatR;
using Medicina.Application.Exame.Dto;
using Medicina.Application.Exame.Handler.Command;
using Medicina.Application.Exame.Handler.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Medicina.Application.Exame.Dto.EmpresaDto;

namespace Medicina.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EmpresaController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmpresaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.mediator.Send(new GetAllEmpresaQuery()));
        }

        [HttpPost()]
        public async Task<IActionResult> Criar(EmpresaInputDto dto)
        {
            var result = await this.mediator.Send(new CreateEmpresaCommand(dto));
            return Created($"{result.Empresa.Id}", result.Empresa);
        }

    }
}
