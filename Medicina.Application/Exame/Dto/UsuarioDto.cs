using Medicina.Domain.Account.ValueObject;
using Medicina.Domain.Enums;
using System.ComponentModel.DataAnnotations;


namespace Medicina.Application.Exame.Dto
{
    public class UsuarioDto
    {
        public record UsuarioInputDto(
        Guid? Id,
        [Required(ErrorMessage = "O nome é requerido!")] string Name,
        [Required(ErrorMessage = "o Tipo é requerido!")] TipoUsuarioEnum TipoUsuario,
        [Required(ErrorMessage = "A Senha é requerida!")] Password Password,
        [Required(ErrorMessage = "O Email é requerido!")] Email Email
    );

        public record UsuarioOutputDto(Guid Id, string Name, TipoUsuarioEnum TipoUsuario, Email Email);
    }
}
