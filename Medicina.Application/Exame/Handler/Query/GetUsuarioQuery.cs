using MediatR;
using Medicina.Application.Exame.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Medicina.Application.Exame.Dto.UsuarioDto;

namespace Medicina.Application.Exame.Handler.Query
{
    public class GetUsuarioQuery : IRequest<GetUsuarioQueryResponse>
    {
        public Guid IdUsuario { get; set; }

        public GetUsuarioQuery(Guid id)
        {
            IdUsuario = id;
        }

    }

    public class GetUsuarioQueryResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public GetUsuarioQueryResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;
        }
    }
}
