using Medicina.Domain.Cadastro;

namespace Medicina.Application.Exame.Dto
{
    public record AsoInputDto( string TipoExame, DateTime? DataExame ,string Imagem, Funcionario Funcionario );
    public record AsoOutputDto(Guid Id , string TipoExame, DateTime? DataExame ,string Imagem, Funcionario Funcionario );

}
