using MediatR;
using Medicina.Application.Exame.Dto;
using Medicina.Domain.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Application.Exame.Handler.Command
{
    public class DeleteEmpresaCommand : IRequest<DeleteEmpresaCommandResponse>
    {
        public EmpresaInputDto Empresa { get; set; }

        public DeleteEmpresaCommand(EmpresaInputDto empresa)
        {
            Empresa = empresa;
        }
    }

    public class DeleteEmpresaCommandResponse
    {
        public EmpresaOutputDto Empresa { get; set; }

        public DeleteEmpresaCommandResponse(EmpresaOutputDto empresa)
        {
            Empresa = empresa;
        }
    }
}
