using Medicina.Application.Exame.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
