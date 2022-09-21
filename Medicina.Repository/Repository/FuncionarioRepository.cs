using Medicina.Domain.Models;
using Medicina.Domain.Models.Repository;
using Medicina.Repository.Context;
using Medicina.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Repository.Repository
{
    public class FuncionarioRepository: Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(MedicinaContext context) : base(context)
        {

        }
    }
}
