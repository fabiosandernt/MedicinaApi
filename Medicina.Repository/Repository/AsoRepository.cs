using Medicina.Domain.Cadastro;
using Medicina.Domain.Exame;
using Medicina.Domain.Exame.Repository;
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
    public class AsoRepository : Repository<Aso>, IAsoRepository
    {
        public AsoRepository(MedicinaContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Aso>> ObterTodosAsos()
        {
            return await this.Query.ToListAsync();
        }

    }
}
