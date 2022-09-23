using MediatR;
using Medicina.Application.Exame.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Application.Exame.Handler.Command
{
    public class DeleteAsoCommand : IRequest<DeleteAsoCommandResponse>
    {
        public AsoInputDto Aso { get; set; }

        public DeleteAsoCommand(AsoInputDto aso)
        {
            Aso = aso;
        }
    }

    public class DeleteAsoCommandResponse
    {
        public AsoOutputDto Aso { get; set; }

        public DeleteAsoCommandResponse(AsoOutputDto aso)
        {
            Aso = aso;
        }
    }
}
