using Medicina.Domain.Account.ValueObject;

namespace Medicina.Application.Exame.Dto
{
    public class EmpresaDto
    {
        public record EmpresaInputDto(string RazaoSocial, string Cnpj, Email Email, string Endereco, string Celular, string Telefone, int Risco);
        public record EmpresaOutputDto(Guid Id, string RazaoSocial, string Cnpj, Email Email, string Endereco, string Celular, string Telefone, int Risco);
    }
}
