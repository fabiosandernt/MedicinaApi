using MediatR;
using Medicina.Application.Exame.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medicina.Application.Exame.Dto.AsoDto;

namespace Medicina.Application.Exame.Handler.Query
{
    public class GetAllAsoQuery : IRequest<GetAllAsoQueryResponse>
    {
    }

    public class GetAllAsoQueryResponse
    {
        public IList<AsoOutputDto> Asos { get; set; }

        public GetAllAsoQueryResponse(IList<AsoOutputDto> asos)
        {
            Asos = asos;
        }
    }
}
