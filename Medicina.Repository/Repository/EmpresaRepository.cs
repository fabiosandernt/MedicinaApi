using Medicina.Domain.Cadastro;
using Medicina.Domain.Cadastro.Repository;
using Medicina.Repository.Context;
using Medicina.Repository.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Repository.Repository
{
    public class EmpresaRepository: Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(MedicinaContext context): base(context)
        {

        }
        public async Task<IEnumerable<Empresa>> ObterTodasEmpresas()
        {
            return await this.Query.Include(x => x.RazaoSocial).ToListAsync();
        }

    }
}
