using Medicina.Domain.Cadastro;

namespace Medicina.Application.Exame.Dto
{
    public class AsoDto
    {
        public record AsoInputDto(string TipoExame, DateTime? DataExame, string Imagem, Funcionario Funcionario);
        public record AsoOutputDto(Guid Id, string TipoExame, DateTime? DataExame, string Imagem, Funcionario Funcionario);
    }
}
