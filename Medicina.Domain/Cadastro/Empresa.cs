using Medicina.Domain.Account;
using Medicina.Domain.Account.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Domain.Cadastro
{
    public class Empresa
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public Email Email { get; set; }
        public string Endereco { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public int Risco { get; set; }
        public IList<Funcionario> Funcionarios { get; set; }
        public Usuario Usuario { get; set; }
    }
}
