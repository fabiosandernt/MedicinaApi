﻿using Medicina.Application.Exame.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Application.Exame.Service
{
    public interface IFuncionarioService
    {
        Task<FuncionarioOutputDto> Criar(FuncionarioInputDto dto);
        Task<List<FuncionarioOutputDto>> ObterTodos();
    }
}
