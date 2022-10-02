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
        private string jwtsecret = "FBAs3rR4yTLuQP7d8WeJ";
        private string audience = "medicina-api";
        private string issuer = "";

        private readonly IUsuarioRepository _usuarioRepository;

        public AuthenticationController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
      
        [HttpPost]
        public IActionResult Token([FromForm] string email, [FromForm] string password)
        {
            var isLogged = this.AuthenticateUser(email, password);

            if (!isLogged)
                return Unauthorized();

            return Ok(GenerateToken());
        }

        private bool AuthenticateUser(string email, string password)
        {
            //Vai na base de dados, caso esteja logado return true;                                 

            var databaseUser = _usuarioRepository.GetbyExpressionAsync(x => x.Email.Valor == email && x.Password.Valor == password);
            
            if (databaseUser.Result.Email.Valor == email && databaseUser.Result.Password.Valor == password)
                return true;

            return false;
        }
        private string GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtsecret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, "Fabio"),
                new Claim("role","Admin")
            };

            var token = new JwtSecurityToken(issuer,
               audience,
               claims,
               expires: DateTime.Now.AddMinutes(15),
               signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }

}
