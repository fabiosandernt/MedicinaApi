using Medicina.Application.Exame.Dto;
using static Medicina.Application.Exame.Dto.AsoDto;

namespace Medicina.Application.Exame.Service
{
    public interface IAsoService
    {
        Task<AsoOutputDto> Criar(AsoInputDto dto);
        Task<List<AsoOutputDto>> ObterTodos();
        Task<AsoOutputDto> Atualizar(AsoInputDto dto);
        Task<AsoOutputDto> Deletar(AsoInputDto dto);
        Task<AsoOutputDto> ObterPorId(Guid id);
    }
}
