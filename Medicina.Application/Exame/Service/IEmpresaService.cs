﻿using static Medicina.Application.Exame.Dto.EmpresaDto;

namespace Medicina.Application.Exame.Service
{
    public interface IEmpresaService
    {
        Task<EmpresaOutputDto> Criar(EmpresaInputDto dto);
        Task<List<EmpresaOutputDto>> ObterTodos();
        Task<EmpresaOutputDto> Atualizar(EmpresaInputDto dto);
        Task<EmpresaOutputDto> Deletar(EmpresaInputDto dto);
        Task<EmpresaOutputDto> ObterPorId(Guid id);

    }
}
