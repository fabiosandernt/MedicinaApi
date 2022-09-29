using Medicina.CrossCutting.Entity;
using Medicina.Domain.Exame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Domain.Cadastro
{
    public class Funcionario: Entity<Guid>
    {
        public string Name { get; set; }
        public string Setor { get; set; }
        public string Cpf { get; set; }
        public string Pis { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Funcao { get; set; }
        public string MatriculaEsocial { get; set; }        
        public virtual IList<Empresa> Empresas { get; set; }
        public virtual IList<Aso> Asos { get; set; }
    }
}
