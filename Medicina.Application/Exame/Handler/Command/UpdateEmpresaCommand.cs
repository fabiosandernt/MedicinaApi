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
    public class UpdateEmpresaCommand : IRequest<UpdateEmpresaCommandResponse>
    {
        public EmpresaInputDto Empresa { get; set; }

        public Guid IdUsuario { get; set; }
        public UpdateEmpresaCommand(EmpresaInputDto empresa)
        {
            Empresa = empresa;
        }
    }

    public class UpdateEmpresaCommandResponse
    {
        public EmpresaOutputDto Empresa { get; set; }

        public UpdateEmpresaCommandResponse(EmpresaOutputDto empresa)
        {
            Empresa = empresa;
        }
    }
}
