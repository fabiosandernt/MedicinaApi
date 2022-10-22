using FluentValidation;
using Medicina.Domain.Account.ValueObject;
using System.Text.RegularExpressions;


namespace Medicina.Domain.Account.Rules
{
    public class EmailValidator : AbstractValidator<Email>
    {
        private const string Pattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

        public EmailValidator()
        {
            RuleFor(x => x.Valor)
                .NotEmpty()
                .Must(BeAEmailValid).WithMessage("Email inválido");
        }
        private bool BeAEmailValid(string valor) => Regex.IsMatch(valor, Pattern);

    }
}
