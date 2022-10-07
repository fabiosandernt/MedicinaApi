using Medicina.Domain.Account;
using Medicina.Domain.Account.Repository;
using Medicina.Domain.Cadastro;
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
    public class UsuarioRepository: Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(MedicinaContext context): base(context)
        {

        }

        public async Task<IEnumerable<Usuario>> ObterTodosUsuarios()
        {
            return await this.Query.ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> ObterUsuarioPorId(Guid id)
        {
            return await this.Query.Where(x => x.Id == id).ToListAsync();
        }
    }
}
