using MediatR;
using Medicina.Application.Exame.Handler.Command;
using Medicina.Application.Exame.Handler.Query;
using Medicina.Application.Exame.Service;


namespace Medicina.Application.Exame.Handler
{
    public class AsoHandler : IRequestHandler<CreateAsoCommand, CreateAsoCommandResponse>,
                                  IRequestHandler<UpdateAsoCommand, UpdateAsoCommandResponse>,
                                  IRequestHandler<DeleteAsoCommand, DeleteAsoCommandResponse>,
                                  IRequestHandler<GetAllAsoQuery, GetAllAsoQueryResponse>,
                                  IRequestHandler<GetAsoQuery, GetAsoQueryResponse>
    {
        private readonly IAsoService _asoService;

        public AsoHandler(IAsoService asoService)
        {
            _asoService = asoService;
        }

        public async Task<CreateAsoCommandResponse> Handle(CreateAsoCommand request, CancellationToken cancellationToken)
        {
            var result = await this._asoService.Criar(request.Aso);
            return new CreateAsoCommandResponse(result);
        }

        public async Task<UpdateAsoCommandResponse> Handle(UpdateAsoCommand request, CancellationToken cancellationToken)
        {
            var result = await this._asoService.Atualizar(request.Aso);
            return new UpdateAsoCommandResponse(result);
        }

        public async Task<DeleteAsoCommandResponse> Handle(DeleteAsoCommand request, CancellationToken cancellationToken)
        {
            var result = await this._asoService.Deletar(request.Aso);
            return new DeleteAsoCommandResponse(result);
        }
        public async Task<GetAllAsoQueryResponse> Handle(GetAllAsoQuery request, CancellationToken cancellationToken)
        {
            var result = await this._asoService.ObterTodos();
            return new GetAllAsoQueryResponse(result);
        }
        public async Task<GetAsoQueryResponse> Handle(GetAsoQuery request, CancellationToken cancellationToken)
        {
            var result = await this._asoService.ObterPorId(request.IdAso);
            return new GetAsoQueryResponse(result);
        }

    }
}
