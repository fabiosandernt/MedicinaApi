using MediatR;
using Medicina.Application.Exame.Dto;
using Medicina.Application.Exame.Handler.Command;
using Medicina.Application.Exame.Handler.Query;
using Medicina.CrossCutting.Utils;
using Medicina.Domain.Account.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Medicina.Application.Exame.Dto.UsuarioDto;

namespace Medicina.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }
      
        [HttpPost]
        public async Task<IActionResult> Token([FromBody] LoginDto dto)
        {
            if (dto is null) return UnprocessableEntity();

            try
            {
                var result = await _mediator.Send(dto);

                if (string.IsNullOrWhiteSpace(result)) 
                    return Unauthorized("Usuário ou senha inválidos");

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponseError(e.Message));
            }
        }
    }

}
