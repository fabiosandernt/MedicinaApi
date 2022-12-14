using Medicina.Application.Exame.Dto;
using Medicina.Domain.Account;
using System.Linq.Expressions;
using static Medicina.Application.Exame.Dto.UsuarioDto;

namespace Medicina.Application.Exame.Service
{
    public interface IUsuarioService
    {
        Task<UsuarioOutputDto> Criar(UsuarioInputDto dto);
        Task<List<UsuarioOutputDto>> ObterTodos();
        Task<UsuarioOutputDto> Atualizar(UsuarioInputDto dto);
        Task<UsuarioOutputDto> Deletar(UsuarioInputDto dto);
        Task<UsuarioOutputDto> ObterPorId(Guid id);
        Task<string> ObterTokenJwtAsync(LoginDto dto);

    }
}
