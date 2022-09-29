

namespace Medicina.Application.Exame.Dto
{
    public class FuncionarioDto
    {
        public record FuncionarioInputDto(string Nome, string Setor, string Cpf, string Pis, DateTime? DataNascimento, string Funcao, string MatriculaEsocial);
        public record FuncionarioOutputDto(Guid Id, string Nome, string Setor, string Cpf, string Pis, DateTime? DataNascimento, string Funcao, string MatriculaEsocial);
    }
}
