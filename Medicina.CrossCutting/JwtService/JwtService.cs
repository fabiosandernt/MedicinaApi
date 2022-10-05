using Medicina.CrossCutting.JwtService.Contracts;
using Medicina.CrossCutting.JwtService.Dto;
using Medicina.CrossCutting.JwtService.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Medicina.CrossCutting.JwtService
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async ValueTask<string> GenerateToken(JwtDto jwtDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(GetTokenDescriptor(jwtDto));

            return tokenHandler.WriteToken(token);
        } 

        private SecurityTokenDescriptor GetTokenDescriptor(JwtDto jwtDto)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSecurity:SecurityKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, jwtDto.Email.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, jwtDto.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(double.Parse(_configuration["JwtSecurity:Expiration"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenDescriptor;
        }

        public async ValueTask<JwtTokenViewModel> ReadTokenAsync(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            return await ValueTask.FromResult( 
                new JwtTokenViewModel
                {
                    Id = Guid.Parse(jwtSecurityToken.Claims.FirstOrDefault(u => u.Type == "sub")?.Value),
                    Email = jwtSecurityToken.Claims.FirstOrDefault(u => u.Type == "email")?.Value
                }
            );
        }
    }
}
