using MediatR;
using Medicina.Application.Exame.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medicina.Application.Exame.Dto.UsuarioDto;

namespace Medicina.Application.Exame.Handler.Query
{
    public class GetAllFuncionarioQuery : IRequest<GetAllUsuarioQueryResponse>
    {
    }

    public class GetAllFuncionarioQueryResponse
    {
        public IList<UsuarioOutputDto> Funcionarios { get; set; }

        public GetAllFuncionarioQueryResponse(IList<UsuarioOutputDto> funcionarios)
        {
            Funcionarios = funcionarios;
        }
    }
}
