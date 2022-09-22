using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Domain.Account.Rules
{
    public class UsuarioValidator: AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).SetValidator(new EmailValidator());
            RuleFor(x => x.Password).SetValidator(new PasswordValidator());

        }
    }
}
