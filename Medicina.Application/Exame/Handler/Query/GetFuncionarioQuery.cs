using MediatR;
using Medicina.Application.Exame.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medicina.Application.Exame.Dto.FuncionarioDto;

namespace Medicina.Application.Exame.Handler.Query
{
    public class GetFuncionarioQuery : IRequest<GetFuncionarioQueryResponse>
    {
        public Guid IdFuncionario { get; set; }

        public GetFuncionarioQuery(Guid idFuncionario)
        {
            IdFuncionario = idFuncionario;
        }
    }

    public class GetFuncionarioQueryResponse
    {
        public FuncionarioOutputDto Funcionario { get; set; }
        public GetFuncionarioQueryResponse(FuncionarioOutputDto funcionario)
        {
            Funcionario = funcionario;
        }
    }
}
