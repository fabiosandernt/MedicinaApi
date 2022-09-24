﻿using Medicina.Application.Exame.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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