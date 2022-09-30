using Medicina.CrossCutting.Entity;
using Medicina.Domain.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Domain.Exame
{
    public class Aso : Entity<Guid>
    {
        public string TipoExame { get; set; }
        public DateTime? DataExame { get; set; }
        public string Imagem { get; set; }
        public Guid FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        
    }
}
