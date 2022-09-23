using MediatR;
using Medicina.Application.Exame.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Application.Exame.Handler.Command
{
    public class UpdateAsoCommand : IRequest<CreateAsoCommandResponse>
    {
        public AsoInputDto Aso { get; set; }


        public UpdateAsoCommand(AsoInputDto aso)
        {
            Aso = aso;
        }
    }

    public class UpdateAsoCommandResponse
    {
        public AsoOutputDto Aso { get; set; }

        public UpdateAsoCommandResponse(AsoOutputDto aso)
        {
            Aso = aso;
        }
    }
}
