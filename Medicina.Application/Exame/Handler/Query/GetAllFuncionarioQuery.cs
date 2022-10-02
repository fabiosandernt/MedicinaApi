using MediatR;

using static Medicina.Application.Exame.Dto.FuncionarioDto;

namespace Medicina.Application.Exame.Handler.Query
{
    public class GetAllFuncionarioQuery : IRequest<GetAllFuncionarioQueryResponse>
    {
    }

    public class GetAllFuncionarioQueryResponse
    {
        public IList<FuncionarioOutputDto> Funcionarios { get; set; }

        public GetAllFuncionarioQueryResponse(IList<FuncionarioOutputDto> funcionarios)
        {
            Funcionarios = funcionarios;
        }
    }
}
