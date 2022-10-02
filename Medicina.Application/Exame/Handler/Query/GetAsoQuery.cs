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
    public class GetAsoQuery: IRequest<GetAsoQueryResponse>
    {
        public Guid IdAso { get; set; }
        public GetAsoQuery(Guid id)
        {
            IdAso = id;
        }
    }

    public class GetAsoQueryResponse
    {
        public AsoOutputDto Aso { get; set; }

        public GetAsoQueryResponse(AsoOutputDto aso)
        {
            Aso = aso;
        }

        
    }
}
