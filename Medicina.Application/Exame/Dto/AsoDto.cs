using Medicina.Domain.Cadastro;

namespace Medicina.Application.Exame.Dto
{
    public class AsoDto
    {
        public record AsoInputDto(string Cpf, string TipoExame, DateTime? DataExame, string Imagem);
        public record AsoOutputDto(Guid Id, string TipoExame, DateTime? DataExame, string Imagem);
    }
}
