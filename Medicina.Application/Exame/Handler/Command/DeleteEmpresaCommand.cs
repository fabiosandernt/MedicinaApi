using MediatR;
using static Medicina.Application.Exame.Dto.EmpresaDto;

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
