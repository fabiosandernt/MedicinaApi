using MediatR;
using Medicina.Application.Exame.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medicina.Application.Exame.Dto.EmpresaDto;

namespace Medicina.Application.Exame.Handler.Command
{
    public class CreateEmpresaCommand : IRequest<CreateEmpresaCommandResponse>
    {
        public EmpresaInputDto Empresa { get; set; }

        public Guid IdUsuario { get; set; }
        public CreateEmpresaCommand(EmpresaInputDto empresa)
        {
            Empresa = empresa;
        }
    }

    public class CreateEmpresaCommandResponse
    {
        public EmpresaOutputDto Empresa { get; set; }

        public CreateEmpresaCommandResponse(EmpresaOutputDto empresa)
        {
            Empresa = empresa;
        }
    }
}
