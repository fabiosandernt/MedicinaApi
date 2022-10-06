using MediatR;
using Medicina.Application.Exame.Dto;
using Medicina.Application.Exame.Handler.Command;
using Medicina.Application.Exame.Handler.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using static Medicina.Application.Exame.Dto.AsoDto;
using Microsoft.AspNetCore.Authorization;
using Medicina.Application.AzureBlob;
using System.IO;
using Azure;
using System.Net.Http;

namespace Medicina.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AsoController : ControllerBase
    {
        private readonly IMediator mediator;
        private AzureBlobStorage storage;

        public AsoController(IMediator mediator, AzureBlobStorage storage)
        {
            this.mediator = mediator;
            this.storage = storage;
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

            storage.UploadBase64(dto.Imagem, "images");
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
