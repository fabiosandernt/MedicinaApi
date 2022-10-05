using Medicina.CrossCutting.JwtService.Dto;
using Medicina.CrossCutting.JwtService.ViewModel;

namespace Medicina.CrossCutting.JwtService.Contracts
{
    public interface IJwtService
    {
        ValueTask<string> GenerateToken(JwtDto jwtDto);
        ValueTask<JwtTokenViewModel> ReadTokenAsync(string token);
    }
}
