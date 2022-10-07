using Azure.Core;
using static Medicina.Application.Exame.Dto.EmpresaDto;

namespace Medicina.Application.Exame.Service
{
    public interface IEmpresaService
    {
        Task<EmpresaOutputDto> Criar(EmpresaInputDto dto, Guid usuarioId);
        Task<List<EmpresaOutputDto>> ObterTodos();
        Task<EmpresaOutputDto> Atualizar(EmpresaInputDto dto, Guid usuarioId);
        Task<EmpresaOutputDto> Deletar(EmpresaInputDto dto, Guid usuarioId);
        Task<EmpresaOutputDto> ObterPorId(Guid id);

    }
}
