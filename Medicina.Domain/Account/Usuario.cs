using FluentValidation;
using Medicina.CrossCutting.Entity;
using Medicina.CrossCutting.Utils;
using Medicina.Domain.Account.Rules;
using Medicina.Domain.Account.ValueObject;
using Medicina.Domain.Enums;
using Medicina.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Domain.Account
{
    public class Usuario : Entity<Guid>
    {
        public string Name { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }
        public List<Empresa> Empresas { get; set; }

        public void SetPassword()
        {
            this.Password.Valor = SecurityUtils.HashSHA1(this.Password.Valor);
        }

        public void Validate() =>
            new UsuarioValidator().ValidateAndThrow(this);

    }
}
