using Medicina.CrossCutting.Entity;
using Medicina.Domain.Account;
using Medicina.Domain.Account.ValueObject;
using Medicina.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Medicina.Domain.Cadastro
{
    public class Empresa : Entity<Guid>
    {

        public string RazaoSocial { get; set; }
        public Email Email { get; set; }
        public string Endereco { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public int Risco { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public virtual IList<Funcionario> Funcionarios { get; set; }
                
    }
}
