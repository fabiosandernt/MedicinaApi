using static Medicina.Application.Exame.Dto.FuncionarioDto;

namespace Medicina.Application.Exame.Service
{
    public interface IFuncionarioService
    {
        Task<FuncionarioOutputDto> Criar(FuncionarioInputDto dto);
        Task<List<FuncionarioOutputDto>> ObterTodos();
        Task<FuncionarioOutputDto> Atualizar(FuncionarioInputDto dto);
        Task<FuncionarioOutputDto> Deletar(FuncionarioInputDto dto);
        Task<FuncionarioOutputDto> ObterPorId(Guid id);
       
    }
}
