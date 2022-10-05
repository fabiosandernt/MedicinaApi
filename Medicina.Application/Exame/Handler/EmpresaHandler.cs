using MediatR;
using Medicina.Application.Exame.Handler.Command;
using Medicina.Application.Exame.Handler.Query;
using Medicina.Application.Exame.Service;

namespace Medicina.Application.Exame.Handler
{
    public class EmpresaHandler : IRequestHandler<CreateEmpresaCommand, CreateEmpresaCommandResponse>,
                                  IRequestHandler<UpdateEmpresaCommand, UpdateEmpresaCommandResponse>,
                                  IRequestHandler<DeleteEmpresaCommand, DeleteEmpresaCommandResponse>,
                                  IRequestHandler<GetAllEmpresaQuery, GetAllEmpresaQueryResponse>,
                                  IRequestHandler<GetEmpresaQuery, GetEmpresaQueryResponse>
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaHandler(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        public async Task<CreateEmpresaCommandResponse> Handle(CreateEmpresaCommand request, CancellationToken cancellationToken)
        {
            var result = await this._empresaService.Criar(request.Empresa, request.IdUsuario);
            return new CreateEmpresaCommandResponse(result);
        }

        public async Task<UpdateEmpresaCommandResponse> Handle(UpdateEmpresaCommand request, CancellationToken cancellationToken)
        {
            var result = await this._empresaService.Atualizar(request.Empresa);
            return new UpdateEmpresaCommandResponse(result);
        }

        public async Task<DeleteEmpresaCommandResponse> Handle(DeleteEmpresaCommand request, CancellationToken cancellationToken)
        {
            var result = await this._empresaService.Deletar(request.Empresa);
            return new DeleteEmpresaCommandResponse(result);
        }
        public async Task<GetAllEmpresaQueryResponse> Handle(GetAllEmpresaQuery request, CancellationToken cancellationToken)
        {
            var result = await this._empresaService.ObterTodos();
            return new GetAllEmpresaQueryResponse(result);
        }
        public async Task<GetEmpresaQueryResponse> Handle(GetEmpresaQuery request, CancellationToken cancellationToken)
        {
            var result = await this._empresaService.ObterPorId(request.IdEmpresa);
            return new GetEmpresaQueryResponse(result);
        }
        
    }
}
