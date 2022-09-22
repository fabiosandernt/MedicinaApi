using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Domain.Cadastro
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Setor { get; set; }
        public string Cpf { get; set; }
        public string Pis { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Funcao { get; set; }
        public string MatriculaEsocial { get; set; }        
        public IList<Empresa> Empresas { get; set; }
    }
}
