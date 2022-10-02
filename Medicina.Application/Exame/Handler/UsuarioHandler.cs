using MediatR;
using Medicina.Application.Exame.Handler.Command;
using Medicina.Application.Exame.Handler.Query;
using Medicina.Application.Exame.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Application.Exame.Handler
{
    public class UsuarioHandler : IRequestHandler<CreateUsuarioCommand, CreateUsuarioCommandResponse>,
                                  IRequestHandler<UpdateUsuarioCommand, UpdateUsuarioCommandResponse>,
                                  IRequestHandler<DeleteUsuarioCommand, DeleteUsuarioCommandResponse>,
                                  IRequestHandler<GetAllUsuarioQuery, GetAllUsuarioQueryResponse>,
                                  IRequestHandler<GetUsuarioQuery, GetUsuarioQueryResponse>

    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<CreateUsuarioCommandResponse> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await this._usuarioService.Criar(request.Usuario);
            return new CreateUsuarioCommandResponse(result);
        }

        public async Task<UpdateUsuarioCommandResponse> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await this._usuarioService.Atualizar(request.Usuario);
            return new UpdateUsuarioCommandResponse(result);
        }

        public async Task<DeleteUsuarioCommandResponse> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await this._usuarioService.Deletar(request.Usuario);
            return new DeleteUsuarioCommandResponse(result);
        }

        public async Task<GetAllUsuarioQueryResponse> Handle(GetAllUsuarioQuery request, CancellationToken cancellationToken)
        {
            var result = await this._usuarioService.ObterTodos();
            return new GetAllUsuarioQueryResponse(result);
        }

        public async Task<GetUsuarioQueryResponse> Handle(GetUsuarioQuery request, CancellationToken cancellationToken)
        {
            var result = await this._usuarioService.ObterPorId(request.IdUsuario);
            return new GetUsuarioQueryResponse(result);
        }
    }

}
