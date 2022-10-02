using MediatR;
using Medicina.Application.Exame.Handler.Command;
using Medicina.Application.Exame.Handler.Query;
using Medicina.Application.Exame.Service;


namespace Medicina.Application.Exame.Handler
{
    public class FuncionarioHandler : IRequestHandler<CreateFuncionarioCommand, CreateFuncionarioCommandResponse>,
                                  IRequestHandler<UpdateFuncionarioCommand, UpdateFuncionarioCommandResponse>,
                                  IRequestHandler<DeleteFuncionarioCommand, DeleteFuncionarioCommandResponse>,
                                  IRequestHandler<GetAllFuncionarioQuery, GetAllFuncionarioQueryResponse>,
                                  IRequestHandler<GetFuncionarioQuery, GetFuncionarioQueryResponse>
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioHandler(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        public async Task<CreateFuncionarioCommandResponse> Handle(CreateFuncionarioCommand request, CancellationToken cancellationToken)
        {
            var result = await this._funcionarioService.Criar(request.Funcionario);
            return new CreateFuncionarioCommandResponse(result);
        }

        public async Task<UpdateFuncionarioCommandResponse> Handle(UpdateFuncionarioCommand request, CancellationToken cancellationToken)
        {
            var result = await this._funcionarioService.Atualizar(request.Funcionario);
            return new UpdateFuncionarioCommandResponse(result);
        }

        public async Task<DeleteFuncionarioCommandResponse> Handle(DeleteFuncionarioCommand request, CancellationToken cancellationToken)
        {
            var result = await this._funcionarioService.Deletar(request.Funcionario);
            return new DeleteFuncionarioCommandResponse(result);
        }
        public async Task<GetAllFuncionarioQueryResponse> Handle(GetAllFuncionarioQuery request, CancellationToken cancellationToken)
        {
            var result = await this._funcionarioService.ObterTodos();
            return new GetAllFuncionarioQueryResponse(result);
        }
        public async Task<GetFuncionarioQueryResponse> Handle(GetFuncionarioQuery request, CancellationToken cancellationToken)
        {
            var result = await this._funcionarioService.ObterPorId(request.IdFuncionario);
            return new GetFuncionarioQueryResponse(result);
        }

    }
}
