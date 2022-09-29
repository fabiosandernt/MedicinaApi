using MediatR;
using Medicina.Application.Exame.Dto;
using Medicina.Domain.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medicina.Application.Exame.Dto.FuncionarioDto;

namespace Medicina.Application.Exame.Handler.Command
{
    public class DeleteFuncionarioCommand : IRequest<DeleteFuncionarioCommandResponse>
    {
        public FuncionarioInputDto Funcionario { get; set; }

        public DeleteFuncionarioCommand(FuncionarioInputDto funcionario)
        {
            Funcionario = funcionario;
        }
    }

    public class DeleteFuncionarioCommandResponse
    {
        public FuncionarioOutputDto Funcionario { get; set; }

        public DeleteFuncionarioCommandResponse(FuncionarioOutputDto funcionario)
        {
            Funcionario = funcionario;
        }
    }
}
