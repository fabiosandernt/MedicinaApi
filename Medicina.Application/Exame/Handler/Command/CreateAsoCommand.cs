using MediatR;
using Medicina.Application.Exame.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Application.Exame.Handler.Command
{
   
        public class CreateAsoCommand : IRequest<CreateAsoCommandResponse>
        {
            public AsoInputDto Aso { get; set; }
                   

            public CreateAsoCommand(AsoInputDto aso)
            {
                Aso = aso;
            }
        }

        public class CreateAsoCommandResponse
        {
            public AsoOutputDto Aso { get; set; }

            public CreateAsoCommandResponse(AsoOutputDto aso)
            {
                Aso = aso;
            }
        }

 }
