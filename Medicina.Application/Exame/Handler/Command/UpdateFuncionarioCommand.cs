using MediatR;
using Medicina.Application.Exame.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medicina.Application.Exame.Dto.FuncionarioDto;

namespace Medicina.Application.Exame.Handler.Command
{
    public class UpdateFuncionarioCommand : IRequest<UpdateFuncionarioCommandResponse>
    {
        public FuncionarioInputDto Funcionario { get; set; }
        public Guid IdEmpresa { get; set; }
        public UpdateFuncionarioCommand(FuncionarioInputDto funcionario)
        {
            Funcionario = funcionario;
        }
    }

    public class UpdateFuncionarioCommandResponse
    {
        public FuncionarioOutputDto Funcionario { get; set; }

        public UpdateFuncionarioCommandResponse(FuncionarioOutputDto funcionario)
        {
            Funcionario = funcionario;
        }
    }
}
