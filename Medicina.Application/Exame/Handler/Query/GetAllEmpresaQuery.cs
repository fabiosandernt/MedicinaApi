using MediatR;
using Medicina.Application.Exame.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Application.Exame.Handler.Query
{
    public class GetAllEmpresaQuery : IRequest<GetAllEmpresaQueryResponse>
    {
    }

    public class GetAllEmpresaQueryResponse
    {
        public IList<EmpresaOutputDto> Empresas { get; set; }

        public GetAllEmpresaQueryResponse(IList<EmpresaOutputDto> empresas)
        {
            Empresas = empresas;
        }
    }
}
