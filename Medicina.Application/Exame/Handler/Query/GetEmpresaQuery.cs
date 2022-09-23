using MediatR;
using Medicina.Application.Exame.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Application.Exame.Handler.Query
{
    public  class GetEmpresaQuery: IRequest<GetEmpresaQueryResponse>
    {
        public Guid IdEmpresa { get; set; }

        public GetEmpresaQuery(Guid idEmpresa)
        {
            IdEmpresa = idEmpresa;
        }
    }

    public class GetEmpresaQueryResponse
    {
        public EmpresaOutputDto Empresa { get; set; }
        public GetEmpresaQueryResponse(EmpresaOutputDto empresa)
        {
            Empresa = empresa;
        }
    }
}
